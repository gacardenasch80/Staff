using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ICompany_Candidate_TimeAvailabilityRepository : IRepository<Company_Candidate_TimeAvailability>
    {
        Task<List<Company_Candidate_TimeAvailability>> GetToOverview(int candidateId, int companyUserId);
    }
}
