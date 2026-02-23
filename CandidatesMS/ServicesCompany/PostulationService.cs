using AutoMapper;
using CandidatesMS.ModelsCompany;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.RepositoriesCompany;
using CandidatesMS.KeyVault.SecretsModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.ServicesCompany
{
    public interface IPostulationService
    {
        public Task<List<PostulationJobNameDTO>> GetAllPostulationsWithJobNameAndEvaluations(List<int> candidateIds, PercentCriteria percentCriteria, string token);
        Task<List<PostulationJobNameDTO>> GetAllPostulationsJobNameAndCandidateList(List<int> candidateIds, int companyUserId);
        Task<List<PostulationDTO>> GetAllPostulationsByCandidateIdWithoutFiled(Candidate candidate, int candidateId, MemberUser memberUser, int companyUserId);
        Task<List<PostulationDTO>> GetAllByCandidateAndCompanyUserIdByCV(int candidateId, int companyUserId, int isMigrated, bool isFromCompanyAndLogin);
        Task<List<PostulationDTO>> GetAllByCandidateId(int candidateId);
    }

    public class PostulationService
    (
        ICompanyUserRepository companyUserRepository,
        IDisqualificationReasonRepository disqualificationReasonRepository,
        IEvaluationRepository evaluationRepository,
        IJobRepository jobRepository,
        IPercentCriteriaRepository percentCriteriaRepository,
        IPostulationRepository postulationRepository,

        IEvaluationService evaluationService,
        IPublicationTimeService publicationTimeService,
        IValidateMethodsService validateMethodsService,

        IOptions<ServiceConfigurationDTO> settings,

        IMapper mapper
    )
    :
    IPostulationService
    {
        private readonly ICompanyUserRepository _companyUserRepository = companyUserRepository;
        private readonly IDisqualificationReasonRepository _disqualificationReasonRepository = disqualificationReasonRepository;
        private readonly IEvaluationRepository _evaluationRepository = evaluationRepository;
        private readonly IJobRepository _jobRepository = jobRepository;
        private readonly IPercentCriteriaRepository _percentCriteriaRepository = percentCriteriaRepository;
        private readonly IPostulationRepository _postulationRepository = postulationRepository;

        private readonly IEvaluationService _evaluationService = evaluationService;
        private readonly IPublicationTimeService _publicationTimeService = publicationTimeService;
        private readonly IValidateMethodsService _validateMethodsService = validateMethodsService;

        private readonly ServiceConfigurationDTO _settings = settings.Value;

        private readonly IMapper _mapper = mapper;

        public async Task<List<PostulationJobNameDTO>> GetAllPostulationsWithJobNameAndEvaluations(List<int> candidateIds, PercentCriteria percentCriteria, string token)
        {
            try
            {
                /* Get CompanyUserId and MemberUser */

                int companyUserId = 0;

                MemberUser memberUser = await _validateMethodsService.GetMemberUserByToken(token);

                if (memberUser != null)
                    companyUserId = memberUser.CompanyUserId;

                /**/

                /* Get Postulations */

                List<PostulationJobNameDTO> postulations = await GetAllPostulationsJobNameAndCandidateList(candidateIds, companyUserId);

                if (postulations == null || postulations.Count == 0)
                    return null;

                /**/

                /* Get Evaluations */

                if (postulations != null && postulations.Count > 0)
                {
                    foreach (PostulationJobNameDTO postulation in postulations)
                    {
                        List<Evaluation> evaluations = await _evaluationRepository.GetEvaluationsByCandidateAndJobIdAfterEditionDate(postulation.CandidateId, postulation.JobId, percentCriteria);

                        List<EvaluationsResumeByJobOrTGId> evaluationsLists = [];

                        if (evaluations != null && evaluations.Count > 0)
                        {
                            evaluationsLists = await _evaluationService.GroupEvaluationsByJobAndTalentGroup(evaluations, memberUser);

                            evaluationsLists = await _evaluationService.TotalEvaluationsByJobAndTalentGroupResume(evaluationsLists, memberUser);

                            evaluationsLists = await _evaluationService.GetMemberUserEvaluations(evaluationsLists, memberUser);

                            evaluationsLists = await _evaluationService.CalculatePercentEvaluationCriterias(evaluationsLists, memberUser);
                        }

                        if (evaluationsLists != null && evaluationsLists.Count > 0)
                        {
                            evaluationsLists = evaluationsLists.OrderByDescending(x => x.CreationDateLastEvaluation).ToList();

                            postulation.ColourFlag = evaluationsLists[0].ColourFlag;

                            postulation.CreationDate = evaluationsLists[0].CreationDateLastEvaluation;
                        }
                    }
                }

                /**/

                return postulations;
            }
            catch(Exception ex)
            {
                return new List<PostulationJobNameDTO>();
            }
        }

        public async Task<List<PostulationJobNameDTO>> GetAllPostulationsJobNameAndCandidateList(List<int> candidateIds, int companyUserId)
        {
            List<PostulationJobNameDTO> postulationJobNameListDTO = [];

            List<Postulation> postulations = await _postulationRepository.GetByPublishedAndClosedByCandidateIds(candidateIds, companyUserId);

            if (postulations != null && postulations.Count > 0)
            {
                foreach (Postulation postulation in postulations)
                {
                    if (postulation != null)
                    {
                        PostulationJobNameDTO postulationJobNameDTO = new()
                        {
                            CandidateId = postulation.CandidateId,
                            JobId = postulation.JobId,
                            JobName = postulation.Job.Name
                        };
                        postulationJobNameListDTO.Add(postulationJobNameDTO);
                    }
                }

                if (postulationJobNameListDTO != null && postulationJobNameListDTO.Count > 0)
                    return postulationJobNameListDTO;
                else
                    return null;
            }
            else
                return null;
        }

        public async Task<List<PostulationDTO>> GetAllPostulationsByCandidateIdWithoutFiled(Candidate candidate, int candidateId, MemberUser memberUser, int companyUserId)
        {
            List<PostulationDTO> postulations = [];

            int isMigrated = 0;
            bool isFromCompanyAndLogin = true;

            if (candidate != null)
            {
                isMigrated = candidate.IsMigrated;
                isFromCompanyAndLogin = candidate.IsFromCompanyAndLogin;
            }

            if (memberUser != null)
                postulations = await GetAllByCandidateAndCompanyUserIdByCV(candidateId, companyUserId, isMigrated, isFromCompanyAndLogin);
            else
                postulations = await GetAllByCandidateId(candidateId);

            if (postulations.Count == 0)
                return [];

            PercentCriteria percentCriteria = await _percentCriteriaRepository.GetByCompanyUserId(companyUserId);

            if (postulations != null && postulations.Count > 0)
            {
                foreach (PostulationDTO postulation in postulations)
                {
                    List<Evaluation> evaluations = await _evaluationRepository.GetEvaluationsByCandidateAndJobIdAfterEditionDate(postulation.CandidateId, postulation.JobId, percentCriteria);

                    List<EvaluationsResumeByJobOrTGId> evaluationsLists = [];

                    if (evaluations != null && evaluations.Count > 0)
                    {
                        evaluationsLists = await _evaluationService.GroupEvaluationsByJobAndTalentGroup(evaluations, memberUser);

                        evaluationsLists = await _evaluationService.TotalEvaluationsByJobAndTalentGroupResume(evaluationsLists, memberUser);

                        evaluationsLists = await _evaluationService.GetMemberUserEvaluations(evaluationsLists, memberUser);

                        evaluationsLists = await _evaluationService.CalculatePercentEvaluationCriterias(evaluationsLists, memberUser);
                    }

                    if (evaluationsLists != null && evaluationsLists.Count > 0)
                    {
                        evaluationsLists = evaluationsLists.OrderByDescending(x => x.CreationDateLastEvaluation).ToList();

                        postulation.ColourFlag = evaluationsLists[0].ColourFlag;

                        postulation.CreationDateLastEvaluation = evaluationsLists[0].CreationDateLastEvaluation;

                        postulation.PercentResumeFormat = evaluationsLists[0].PercentFormat;
                    }
                }
            }

            return postulations;
        }

        public async Task<List<PostulationDTO>> GetAllByCandidateAndCompanyUserIdByCV(int candidateId, int companyUserId, int isMigrated, bool isFromCompanyAndLogin)
        {
            List<PostulationDTO> postulationsDTO = [];

            List<Postulation> postulations = await  _postulationRepository.GetAllByCandidateAndCompanyUserIdOnlyAvailable(candidateId, companyUserId, isMigrated, isFromCompanyAndLogin);

            if (postulations.Count == 0)
                return postulationsDTO;

            postulationsDTO = _mapper.Map<List<Postulation>, List<PostulationDTO>>(postulations);

            foreach (var postulation in postulationsDTO)
            {
                var job = await _jobRepository.GetById(postulation.Job.JobId);

                JobOutDTO jobOutDTO = _mapper.Map<Job, JobOutDTO>(job);

                postulation.Job.PublicationDate = jobOutDTO.PublicationDate;
                postulation.Job.CreationDate = DateTime.Parse(postulation.Job.CreationDate).ToString("dd MMMM yyyy", new CultureInfo("es-ES"));
                postulation.Job.EditedDate = DateTime.Parse(postulation.Job.EditedDate).ToString("dd MMMM yyyy", new CultureInfo("es-ES"));
                postulation.Job.IsConfidential = jobOutDTO.IsConfidential;

                CompanyUser companyUser = await _companyUserRepository.GetById(jobOutDTO.CompanyUserId);

                string logo = null;

                if (companyUser.LogoIdentifier != null && companyUser.LogoIdentifier.Length > 0)
                    logo = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + companyUser.LogoIdentifier;

                CompanyUserJobsDTO companyJob = new()
                {
                    Name = companyUser.Name,
                    LogoIdentifier = logo
                };

                postulation.Job.companyUser = companyJob;

                if (postulation.BlockReasonId != null && postulation.BlockReasonId != 0)
                    postulation.BlockDatePup = _publicationTimeService.GetBlockPupInfo(postulation.PostulationBlockDate);

                postulation.TextState = postulation.PostulationStage.PostulationState.Name;
                postulation.TextColor = postulation.PostulationStage.PostulationState.PostulationStateId;

                DisqualificationReason DisqualificationReason = new();

                if (postulation.DisqualificationReasonId != 0)
                {
                    DisqualificationReason = await _disqualificationReasonRepository.GetById(postulation.DisqualificationReasonId);
                    postulation.DisqualificationReason = DisqualificationReason.Name;
                };

                if (postulation.PostulationStageId == 8)
                    postulation.TextColor = 5;
            }

            return postulationsDTO;
        }

        public async Task<List<PostulationDTO>> GetAllByCandidateId(int candidateId)
        {
            List<PostulationDTO> postulationsDTO = await GetAllByCandidateId(candidateId);

            if (postulationsDTO.Count == 0)
                return postulationsDTO;

            foreach (var postulation in postulationsDTO)
            {
                var job = await _jobRepository.GetById(postulation.Job.JobId);
                JobOutDTO jobOutDTO = _mapper.Map<Job, JobOutDTO>(job);
                postulation.Job.PublicationDate = jobOutDTO.PublicationDate;
                postulation.Job.CreationDate = DateTime.Parse(postulation.Job.CreationDate).ToString("dd MMMM yyyy", new CultureInfo("es-ES"));
                postulation.Job.EditedDate = DateTime.Parse(postulation.Job.EditedDate).ToString("dd MMMM yyyy", new CultureInfo("es-ES"));
                postulation.Job.IsConfidential = jobOutDTO.IsConfidential;
                CompanyUser companyUser = await _companyUserRepository.GetById(jobOutDTO.CompanyUserId);
                string logo = null;
                if (companyUser.LogoIdentifier != null && companyUser.LogoIdentifier.Length > 0)
                    logo = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + companyUser.LogoIdentifier;

                CompanyUserJobsDTO companyJob = new()
                {
                    Name = companyUser.Name,
                    LogoIdentifier = logo
                };

                postulation.Job.companyUser = companyJob;

                if (postulation.BlockReasonId != null && postulation.BlockReasonId != 0)
                    postulation.BlockDatePup = _publicationTimeService.GetBlockPupInfo(postulation.PostulationBlockDate);

                postulation.TextState = postulation.PostulationStage.PostulationState.Name;
                postulation.TextColor = postulation.PostulationStage.PostulationState.PostulationStateId;

                DisqualificationReason DisqualificationReason = new DisqualificationReason();
                if (postulation.DisqualificationReasonId != 0)
                {
                    DisqualificationReason = await _disqualificationReasonRepository.GetById(postulation.DisqualificationReasonId);
                    postulation.DisqualificationReason = DisqualificationReason.Name;
                };

                if (postulation.PostulationStageId == 8)
                    postulation.TextColor = 5;
            }

            return postulationsDTO;
        }
    }
}
