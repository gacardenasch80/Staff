using CandidatesMS.ModelsCompany;
using CandidatesMS.Persistence.EntitiesCompany;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using CandidatesMS.RepositoriesCompany;
using System.Linq;
using AutoMapper;

namespace CandidatesMS.ServicesCompany
{
    public interface ICandidate_TalentGroupService
    {
        Task<List<TalentGroupDTO>> GetAllCandidate_TalentGroupsById(int candidateId, MemberUser memberUser, int companyUserId);
        public Task<List<CandidateTalentGroupNameDTO>> GetAllCandidateTalentGroupsWithNameAndEvaluations(List<int> candidateIds, PercentCriteria percentCriteria, string token);
        Task<List<CandidateTalentGroupNameDTO>> GetAllCandidateTalentGroupNameAndCandidateList(List<int> candidateIds, int companyUserId);
    }

    public class Candidate_TalentGroupService
    (
        ICandidate_TalentGroupRepository candidate_TalentGroupRepository,
        IEvaluationRepository evaluationRepository,
        IPercentCriteriaRepository percentCriteriaRepository,
        IPostulationRepository postulationRepository,
        ITalentGroupRepository talentGroupRepository,

        IEvaluationService evaluationService,
        IValidateMethodsService validateMethodsService,

        IMapper mapper
    )
    :
    ICandidate_TalentGroupService
    {
        private readonly ICandidate_TalentGroupRepository _candidate_TalentGroupRepository = candidate_TalentGroupRepository;
        private readonly IEvaluationRepository _evaluationRepository = evaluationRepository;
        private readonly IPercentCriteriaRepository _percentCriteriaRepository = percentCriteriaRepository;
        private readonly IPostulationRepository _postulationRepository = postulationRepository;
        private readonly ITalentGroupRepository _talentGroupRepository = talentGroupRepository;

        private readonly IEvaluationService _evaluationService = evaluationService;
        private readonly IValidateMethodsService _validateMethodsService = validateMethodsService;

        private readonly IMapper _mapper = mapper;

        public async Task<List<TalentGroupDTO>> GetAllCandidate_TalentGroupsById(int candidateId, MemberUser memberUser, int companyUserId)
        {
            List<Candidate_TalentGroup> candidateTalentGroupList = [];

            if (memberUser != null)
                candidateTalentGroupList = await _candidate_TalentGroupRepository.GetAllByCandidateAndCompanyUserId(candidateId, companyUserId);
            else
                candidateTalentGroupList = await _candidate_TalentGroupRepository.GetByCandidateId(candidateId);

            PercentCriteria percentCriteria = await _percentCriteriaRepository.GetByCompanyUserId(companyUserId);

            if (candidateTalentGroupList.Count > 0)
            {
                List<TalentGroupDTO> talentGroupListDTO = [];

                foreach (var talenGroupId in candidateTalentGroupList)
                {
                    TalentGroup talentGroup = await _talentGroupRepository.GetById(talenGroupId.TalentGroupId);
                    TalentGroupDTO talentGroupDTO = _mapper.Map<TalentGroup, TalentGroupDTO>(talentGroup);

                    List<Evaluation> evaluations = await _evaluationRepository.GetEvaluationsByCandidateAndTalentGroupIdAfterEditionDate(candidateId, talentGroup.TalentGroupId, percentCriteria);

                    List<EvaluationsResumeByJobOrTGId> evaluationsLists = new List<EvaluationsResumeByJobOrTGId>();

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

                        talentGroupDTO.ColourFlag = evaluationsLists[0].ColourFlag;

                        talentGroupDTO.CreationDateLastEvaluation = evaluationsLists[0].CreationDateLastEvaluation;

                        talentGroupDTO.PercentResumeFormat = evaluationsLists[0].PercentFormat;
                    }

                    if (talentGroup != null)
                        talentGroupListDTO.Add(talentGroupDTO);
                }

                return talentGroupListDTO;
            }

            return [];
        }

        public async Task<List<CandidateTalentGroupNameDTO>> GetAllCandidateTalentGroupsWithNameAndEvaluations(List<int> candidateIds, PercentCriteria percentCriteria, string token)
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

                List<CandidateTalentGroupNameDTO> candidateTalentGroupNameDTO = await GetAllCandidateTalentGroupNameAndCandidateList(candidateIds, companyUserId);

                if (candidateTalentGroupNameDTO == null || candidateTalentGroupNameDTO.Count == 0)
                    return null;

                /**/

                /* Get Evaluations */

                if (candidateTalentGroupNameDTO != null && candidateTalentGroupNameDTO.Count > 0)
                {
                    foreach (CandidateTalentGroupNameDTO tg in candidateTalentGroupNameDTO)
                    {
                        List<Evaluation> evaluations = await _evaluationRepository.GetEvaluationsByCandidateAndTalentGroupIdAfterEditionDate(tg.CandidateId, tg.TalentGroupId, percentCriteria);

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

                            tg.ColourFlag = evaluationsLists[0].ColourFlag;

                            tg.CreationDate = evaluationsLists[0].CreationDateLastEvaluation;
                        }
                    }
                }

                /**/

                return candidateTalentGroupNameDTO;
            }
            catch (Exception ex)
            {
                return new List<CandidateTalentGroupNameDTO>();
            }
        }

        public async Task<List<CandidateTalentGroupNameDTO>> GetAllCandidateTalentGroupNameAndCandidateList(List<int> candidateIds, int companyUserId)
        {
            List<CandidateTalentGroupNameDTO> candidateTalentGroupNameListDTO = [];

            List<Candidate_TalentGroup> candidate_TalentGroup = await _candidate_TalentGroupRepository.GetAllByCandidateAndCompanyUserIdByCandidateIds(candidateIds, companyUserId);

            if (candidate_TalentGroup != null && candidate_TalentGroup.Count > 0)
            {
                foreach (Candidate_TalentGroup candidateTalentGroup in candidate_TalentGroup)
                {
                    if (candidateTalentGroup != null)
                    {
                        CandidateTalentGroupNameDTO candidateTalentGroupJobNameDTO = new()
                        {
                            CandidateId = candidateTalentGroup.CandidateId,
                            TalentGroupId = candidateTalentGroup.TalentGroupId,
                            TalentGroupName = candidateTalentGroup.TalentGroup.Name
                        };
                        candidateTalentGroupNameListDTO.Add(candidateTalentGroupJobNameDTO);
                    }
                }

                if (candidateTalentGroupNameListDTO != null && candidateTalentGroupNameListDTO.Count > 0)
                    return candidateTalentGroupNameListDTO;
                else
                    return null;
            }
            else
                return null;
        }
    }
}
