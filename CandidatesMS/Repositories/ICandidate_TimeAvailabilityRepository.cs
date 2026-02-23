using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ICandidate_TimeAvailabilityRepository : IRepository<Candidate_TimeAvailability>
    {
        Task<List<Candidate_TimeAvailability>> GetToOverview(int candidateId, int companyUserId);
    }
}
