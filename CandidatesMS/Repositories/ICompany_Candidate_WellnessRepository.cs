using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ICompany_Candidate_WellnessRepository : IRepository<Company_Candidate_Wellness>
    {
        Task<List<Company_Candidate_Wellness>> GetToOverview(int candidateId, int companyUserId);
    }
}
