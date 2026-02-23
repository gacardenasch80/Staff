using AutoMapper;
using CandidatesMS.ModelsCompany;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using System.Threading.Tasks;

namespace CandidatesMS.Services
{
    public interface ICandidate_BlockReasonService
    {
        Task<Candidate_BlockReasonDTO> GetCandidateBlockReasonByCandidateAndCompanyId(int candidateId, int companyUserId);
    }

    public class Candidate_BlockReasonService : ICandidate_BlockReasonService
    {
        private readonly ICandidate_BlockReasonRepository _candidate_BlockReasonRepository;

        private readonly IUploadTimeService _uploadTimeService;

        private readonly IMapper _mapper;

        public Candidate_BlockReasonService
        (
            ICandidate_BlockReasonRepository candidate_BlockReasonRepository,

            IUploadTimeService uploadTimeService,

            IMapper mapper
        )
        {
            _candidate_BlockReasonRepository = candidate_BlockReasonRepository;

            _uploadTimeService = uploadTimeService;

            _mapper = mapper;
        }

        public async Task<Candidate_BlockReasonDTO> GetCandidateBlockReasonByCandidateAndCompanyId(int candidateId, int companyUserId)
        {
            Candidate_BlockReason candidateBlockReason = await _candidate_BlockReasonRepository.GetByCandidateAndCompanyId(candidateId, companyUserId);

            Candidate_BlockReasonDTO candidateBlockReasonDTO = _mapper.Map<Candidate_BlockReason, Candidate_BlockReasonDTO>(candidateBlockReason);

            if (candidateBlockReasonDTO == null)
                return null;

            candidateBlockReasonDTO.BlockReasonName = candidateBlockReason.BlockReason.Name;
            candidateBlockReasonDTO.BlockDate = _uploadTimeService.GetBlockInfo(candidateBlockReason.CandidateBlockDate);
            candidateBlockReasonDTO.BlockDatePup = _uploadTimeService.GetBlockPupInfo(candidateBlockReason.CandidateBlockDate);

            return candidateBlockReasonDTO;
        }
    }
}
