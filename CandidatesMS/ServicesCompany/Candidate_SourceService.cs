using AutoMapper;
using CandidatesMS.ModelsCompany;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.RepositoriesCompany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.ServicesCompany
{
    public interface ICandidate_SourceService
    {
        Task<List<Candidate_SourceDTO>> GetCandidate_SourcesByCandidateId(int candidateId, MemberUser memberUser, int companyUserId);
    }

    public class Candidate_SourceService
    (
        ICandidate_SourceRepository candidate_SourceRepository,
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
    ICandidate_SourceService
    {
        private readonly ICandidate_SourceRepository _candidate_SourceRepository = candidate_SourceRepository;
        private readonly ICandidate_TalentGroupRepository _candidate_TalentGroupRepository = candidate_TalentGroupRepository;
        private readonly IEvaluationRepository _evaluationRepository = evaluationRepository;
        private readonly IPercentCriteriaRepository _percentCriteriaRepository = percentCriteriaRepository;
        private readonly IPostulationRepository _postulationRepository = postulationRepository;
        private readonly ITalentGroupRepository _talentGroupRepository = talentGroupRepository;

        private readonly IEvaluationService _evaluationService = evaluationService;
        private readonly IValidateMethodsService _validateMethodsService = validateMethodsService;

        private readonly IMapper _mapper = mapper;

        public async Task<List<Candidate_SourceDTO>> GetCandidate_SourcesByCandidateId(int candidateId, MemberUser memberUser, int companyUserId)
        {
            List<Candidate_Source> candidateSources = [];

            if (memberUser != null)
                candidateSources = await _candidate_SourceRepository.GetSourcesByCandidateAndCompanyUserId(candidateId, memberUser.CompanyUserId);

            else
                candidateSources = await _candidate_SourceRepository.GetSourcesByCandidateId(candidateId);

            if (candidateSources != null && candidateSources.Count > 0)
            {
                List<Candidate_SourceDTO> candidateSourcesDTO = _mapper.Map<List<Candidate_Source>, List<Candidate_SourceDTO>>(candidateSources);

                return candidateSourcesDTO;
            }

            return [];
        }
    }
}
