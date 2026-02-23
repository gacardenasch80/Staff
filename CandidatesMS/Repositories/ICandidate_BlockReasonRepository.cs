using CandidatesMS.Persistence.EntitiesCompany;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ICandidate_BlockReasonRepository : IRepository<Candidate_BlockReason>
    {
        Task<Candidate_BlockReason> GetByCandidateId(int candidateId);
        Task<Candidate_BlockReason> GetByCandidateAndCompanyId(int candidateId, int companyUserId);
        Task<Candidate_BlockReason> GetByBlockReasonId(int blockReasonId);
        Task<bool> RemoveByCandidateId(int candidateId);
    }
}
