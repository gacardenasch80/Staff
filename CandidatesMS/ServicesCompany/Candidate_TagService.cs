using AutoMapper;
using CandidatesMS.ModelsCompany;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.RepositoriesCompany;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.ServicesCompany
{
    public interface ICandidate_TagService
    {
        Task<List<Candidate_TagDTO>> GetCandidate_TagsByCandidateId(int candidateId, MemberUser memberUser, int companyUserId);
    }

    public class Candidate_TagService
    (
        ICandidate_TagRepository candidate_TagRepository,
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
    ICandidate_TagService
    {
        private readonly ICandidate_TagRepository _candidate_TagRepository = candidate_TagRepository;
        private readonly ICandidate_TalentGroupRepository _candidate_TalentGroupRepository = candidate_TalentGroupRepository;
        private readonly IEvaluationRepository _evaluationRepository = evaluationRepository;
        private readonly IPercentCriteriaRepository _percentCriteriaRepository = percentCriteriaRepository;
        private readonly IPostulationRepository _postulationRepository = postulationRepository;
        private readonly ITalentGroupRepository _talentGroupRepository = talentGroupRepository;

        private readonly IEvaluationService _evaluationService = evaluationService;
        private readonly IValidateMethodsService _validateMethodsService = validateMethodsService;

        private readonly IMapper _mapper = mapper;

        public async Task<List<Candidate_TagDTO>> GetCandidate_TagsByCandidateId(int candidateId, MemberUser memberUser, int companyUserId)
        {
            List<Candidate_Tag> candidateTags = [];

            if (memberUser != null)
                candidateTags = await _candidate_TagRepository.GetTagsByCandidateAndCompanyUserId(candidateId, memberUser.CompanyUserId);
            else
                candidateTags = await _candidate_TagRepository.GetTagsByCandidateId(candidateId);

            if (candidateTags != null && candidateTags.Count > 0)
            {
                List<Candidate_TagDTO> candidateTagsDTO = _mapper.Map<List<Candidate_Tag>, List<Candidate_TagDTO>>(candidateTags);

                return candidateTagsDTO;
            }
            
            return [];            
        }
    }
}
