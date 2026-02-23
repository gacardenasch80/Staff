using AutoMapper;
using CandidatesMS.Models;
using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.Infraestructure.Services;
using CandidatesMS.Repositories;
using CandidatesMS.Repositories.RemoteRepositories;
using CandidatesMS.KeyVault.SecretsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using S3bucketDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Services
{
    public interface ICvService
    {
        Task<bool> UploadCvRecordAsync(string identifier, int candidateId, string token);
        Task<bool> UploadCvRecordWithCompanyAsync(string identifier, int candidateId, int companyUserId, string token);
        Task<bool> UploadCvFromAnalyze(IFormFile CV, int candidateId, string emailMember);
    }
    public class CvService : ICvService
    {
        private ICVRepository _cvRepository;
        private ICandidateRepository _candidateRepository;
        private IBasicInformationRepository _basicInformationRepository;
        private ICompanyRemoteRepository _companyRemoteRepository;
        private IMatchServerDate _matchServerDate;
        private IMapper _mapper;
        private readonly IAWSS3FileService _AWSS3FileService;
        private readonly ServiceConfigurationDTO _settings;


        public CvService(ICVRepository cVRepository, ICandidateRepository candidateRepository, IBasicInformationRepository basicInformationRepository,
                        ICompanyRemoteRepository companyRemoteRepository, IMatchServerDate matchServerDate, IMapper mapper,
                        IAWSS3FileService AWSS3FileService, IOptions<ServiceConfigurationDTO> settings)
        {
            _cvRepository = cVRepository;
            _candidateRepository = candidateRepository;
            _basicInformationRepository = basicInformationRepository;
            _companyRemoteRepository = companyRemoteRepository;
            _matchServerDate = matchServerDate;
            _AWSS3FileService = AWSS3FileService;
            _settings = settings.Value;
            _mapper = mapper;
        }

        public async Task<bool> UploadCvRecordAsync(string identifier, int candidateId, string token)
        {
            var candidate = await _basicInformationRepository.GetByCandidateId(candidateId);
            var member = await _companyRemoteRepository.GetMemberUserFromCandidate(token);

            CV cvUser = new CV() { };
            cvUser.CandidateId = candidateId;
            cvUser.CVGuid = Convert.ToString(Guid.NewGuid());
            cvUser.CvIdentifier = identifier;
            cvUser.CvIdentifierLink = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + identifier;
            cvUser.OverViewCv = false;
            cvUser.EmailMemberUser = member.email;
            cvUser.NameMemberUser = member.name;
            cvUser.SurnameMemberUser = member.surname;
            cvUser.CompanyUserId = member.companyUserId;
            cvUser.Name = $"{candidate.Name} {candidate.Surname}CV.html";
            cvUser.FileTypeId = 8;
            cvUser.IsFromCandidate = false;
            cvUser.UploadDate = _matchServerDate.GetDateTimeByServer().ToString();

            try
            {
                bool created = await _cvRepository.Add(cvUser);
                if (created)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> UploadCvRecordWithCompanyAsync(string identifier, int candidateId, int companyUserId, string token)
        {
            var candidate = await _basicInformationRepository.GetByCandidateId(candidateId);
            var members = await _companyRemoteRepository.GetAllMemberUserByToken(token);

            MemberByToken member = new MemberByToken();

            if (members != null && members.Count > 0)
                member = members[0];

            CV cvUser = new CV() { };
            cvUser.CandidateId = candidateId;
            cvUser.CVGuid = Convert.ToString(Guid.NewGuid());
            cvUser.CvIdentifier = identifier;
            cvUser.CvIdentifierLink = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + identifier;
            cvUser.OverViewCv = false;
            cvUser.EmailMemberUser = member.email;
            cvUser.NameMemberUser = member.name;
            cvUser.SurnameMemberUser = member.surname;
            cvUser.CompanyUserId = companyUserId;
            cvUser.Name = $"{candidate.Name} {candidate.Surname}CV.html";
            cvUser.FileTypeId = 8;
            cvUser.IsFromCandidate = false;
            cvUser.UploadDate = _matchServerDate.GetDateTimeByServer().ToString();

            try
            {
                bool created = await _cvRepository.Add(cvUser);
                if (created)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<bool> UploadCvFromAnalyze(IFormFile CV, int candidateId, string emailMember)
        {
            bool candidateExists = _candidateRepository.CandidateExistById(candidateId);

            if (!candidateExists)
                return false;

            var result = await _AWSS3FileService.UploadCVFile(CV, "CV");
            if (result == null)
                return false;

            CV cvUser = new CV();
            cvUser.CandidateId = candidateId;            
            cvUser.CVGuid = Convert.ToString(Guid.NewGuid());
            cvUser.CvIdentifier = result[0];
            cvUser.CvIdentifierLink = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + result[0];
            if (result.Count == 2)
                cvUser.CvIdentifierLink = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + result[1];
            await _cvRepository.DeleteOverViewCv(candidateId);
            cvUser.OverViewCv = true;

            cvUser.Name = CV.FileName;
            cvUser.FileTypeId = 8;
            cvUser.EmailMemberUser = emailMember;
            cvUser.UploadDate = _matchServerDate.GetDateTimeByServer().ToString();

            try
            {
                bool created = await _cvRepository.Add(cvUser);
                if (created)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }            
        }
    }
}
