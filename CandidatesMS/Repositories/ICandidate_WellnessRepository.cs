using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ICandidate_WellnessRepository : IRepository<Candidate_Wellness>
    {
        Task<List<Candidate_Wellness>> GetToOverview(int candidateId, int companyUserId);
    }
}
