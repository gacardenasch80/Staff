using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandidatesMS.Models;
using AutoMapper;
using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.Repositories.RemoteRepositories;

namespace CandidatesMS.Services
{
    public interface IStudyService
    {
        Task<List<StudyDTO>> GetStudiesCandidateOrderByDate(int candidateId, bool isFromCandidate, StringValues values, int companyUserId = 0);
    }
    public class StudyService : IStudyService
    {
        private IStudyRepository _studyRepository;
        private IMapper _mapper;
        private ICompanyRemoteRepository _companyRemoteRepository;
        public StudyService(IStudyRepository studyRepository, IMapper mapper, ICompanyRemoteRepository companyRemoteRepository)
        {
            _studyRepository = studyRepository;
            _mapper = mapper;
            _companyRemoteRepository = companyRemoteRepository;
        }

        public async Task<List<StudyDTO>> GetStudiesCandidateOrderByDate(int candidateId, bool isFromCandidate, StringValues values, int companyUserId = 0)
        {
            List<Study> studiesFromRepo = new List<Study>() { };
            if (isFromCandidate)
                studiesFromRepo = await _studyRepository.GetByCandidateId(candidateId);
            else
                studiesFromRepo = await _studyRepository.GetToOverview(candidateId, companyUserId);
            List<StudyDTO> studiesDTO = _mapper.Map<List<Study>, List<StudyDTO>>(studiesFromRepo);

            List<StudyDTO> candidateStudies = new List<StudyDTO>();
            List<StudyDTO> companyStudies = new List<StudyDTO>();

            foreach (StudyDTO study in studiesDTO)
            {
                JobProfessionRemoteDTO jobProfession = await _companyRemoteRepository.GetJobProfessionById(
                            study.JobProfessionId, values.ToString());
                if (jobProfession != null)
                {
                    study.JobProfession = jobProfession.Profession;
                    study.JobProfessionEnglish = jobProfession.ProfessionEnglish;
                }

                if (!string.IsNullOrEmpty(study.StartDate))
                {
                    study.CompareDate = double.Parse(study.StartDate);
                }
                else if (!string.IsNullOrEmpty(study.EndDate))
                {
                    study.CompareDate = double.Parse(study.EndDate);
                }

                if (study.IsFromCandidate)
                    candidateStudies.Add(study);
                else
                    companyStudies.Add(study);
            }

            var candidateStudiesDTO = candidateStudies.OrderByDescending(x => x.CompareDate).ToList();
            var companyStudiesDTO = companyStudies.OrderByDescending(x => x.CompareDate).ToList();

            var studies = new List<StudyDTO>();

            studies.AddRange(candidateStudiesDTO);
            studies.AddRange(companyStudiesDTO);

            return studies;
        }
    }
}
