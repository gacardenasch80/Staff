using AutoMapper;
using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;
using System;
using CandidatesMS.Repositories.RemoteRepositories;
using CandidatesMS.Repositories;
using S3bucketDemo.Services;
using Microsoft.Extensions.Options;
using CandidatesMS.Helpers;
using CandidatesMS.Services;
using CandidatesMS.KeyVault.SecretsModels;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.RepositoriesCompany;
using CandidatesMS.KeyVault.SecretsModels;

namespace CandidatesMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CvHiringController:ControllerBase
    {
        private ICandidateRepository _candidateRepository;
        private ICVHiringRepository _cvHiringRepository;
        private IMemberUserRepository _memberUserRepository;

        private IAuthorizationHelper _authorizationHelper;
        private IMatchServerDate _matchServerDate;
        private ICryptoHelper _cryptoHelper;

        private IAWSS3FileService _AWSS3FileService;
        private IBlockchainService _blockchainService;

        private ICompanyRemoteRepository _companyRemoteRepository;

        private IMapper _mapper;

        private ServiceConfigurationDTO _settings;

        public CvHiringController
        (
                                  ICandidateRepository candidateRepository,
                                  ICVHiringRepository cvHiringRepository,
                                  IMemberUserRepository memberUserRepository,

                                  IAWSS3FileService AWSS3FileService,
                                  IBlockchainService blockchainService,

                                  IAuthorizationHelper authorizationHelper,
                                  IMatchServerDate matchServerDate,
                                  ICryptoHelper cryptoHelper,
                                  
                                  ICompanyRemoteRepository companyRemoteRepository,

                                  IMapper mapper,
                                  
                                  IOptions<ServiceConfigurationDTO> settings
        )
        {
            _candidateRepository = candidateRepository;
            _cvHiringRepository = cvHiringRepository;
            _memberUserRepository = memberUserRepository;

            _companyRemoteRepository = companyRemoteRepository;

            _AWSS3FileService = AWSS3FileService;
            _blockchainService = blockchainService;

            _authorizationHelper = authorizationHelper;
            _matchServerDate = matchServerDate;
            _cryptoHelper = cryptoHelper;

            _mapper = mapper;

            _settings = settings.Value;
        }


        [HttpPost("uploadFileByCompany")]
        public async Task<IActionResult> UploadFileByCompanyAsync([FromForm] CVHiringDTO req)
        {
            /* MODIFICAR MÉTODO DESPUÉS DE TERMINAR EL MULTIEMPRESA */

            StringValues values = "";
            Request.Headers.TryGetValue("Authorization", out values);

            var email = "";
            var name = "";
            var surname = "";
            var member = await _companyRemoteRepository.GetMemberUserFromCandidate(values.ToString());
            if (member != null)
            {
                email = member.email;
                name = member.name;
                surname = member.surname;
            }


            bool candidateExists = _candidateRepository.CandidateExistById(req.CandidateId);

            if (!candidateExists)
                return StatusCode(404, new { message = "El candidato no existe." });


            decimal lengthFile = (decimal)(req.FormFile.Length) / 1024;

            double lengthFileDouble = (double)(decimal.Round(lengthFile, 2, MidpointRounding.AwayFromZero));
            string token =
                _cryptoHelper.EncodeSHA256(req.FormFile.FileName, req.FormFile.ContentType, lengthFileDouble);

            bool isStoredInBlockChain = await _blockchainService.SaveFile(req.FormFile.FileName, req.FormFile.ContentType,
                            lengthFileDouble, token);

            if (!isStoredInBlockChain)
                return StatusCode(400, new { message = "El documento ya existe" });

            var result = await _AWSS3FileService.UploadCVFile(req.FormFile, "CV");
            if (result == null)
                return BadRequest(result);

            CVHiring cvUser = _mapper.Map<CVHiringDTO, CVHiring>(req);

            
            cvUser.CvIdentifier = result[0];
            cvUser.CvIdentifierLink = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + result[0];
            if (result.Count == 2)
                cvUser.CvIdentifierLink = "https://recruitment-bucket.s3.amazonaws.com/" + result[1];

            await _cvHiringRepository.DeleteOverViewCv(req.CandidateId);
            cvUser.OverViewCv = true;

            cvUser.IsFromCandidate = false;

            string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
            MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

            cvUser.Name = req.FormFile.FileName;
            cvUser.FileTypeHiringId = 1;
            cvUser.EmailMemberUser = email;
            cvUser.NameMemberUser = name;
            cvUser.SurnameMemberUser = surname;
            cvUser.Weight = lengthFileDouble;
            cvUser.IsFromCandidate = false;
            cvUser.Hash = token;
            cvUser.UploadDate = _matchServerDate.GetDateTimeByServer().ToString();

            if (memberUser != null)
                cvUser.CompanyUserId = memberUser.CompanyUserId;

            try
            {
                bool created = await _cvHiringRepository.Add(cvUser);
                if (created)
                    return Created("", new { message = "Almacenado exitosamente", filename = cvUser.Name });
                else
                    return BadRequest(new { message = "El documento no fue almacenado" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

        }




    }
}
