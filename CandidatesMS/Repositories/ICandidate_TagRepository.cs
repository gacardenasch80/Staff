using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ICandidate_TagRepository : IRepository<Candidate_Tag>
    {
        Task<List<Candidate_Tag>> GetByCandidateId(int candidateId);
        Task<Candidate_Tag> GetByTagId(int candidate_tagId);
        Task<bool> RemoveByTagId(int tagId);
    }
}
