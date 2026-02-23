using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ICandidate_SourceRepository : IRepository<Candidate_Source>
    {
        Task<List<Candidate_Source>> GetByCandidateId(int candidateId);
        Task<List<Candidate_Source>> GetBySourceId(int candidate_sourceId);
        Task<bool> RemoveBySourceId(int sourceId);
    }
}
