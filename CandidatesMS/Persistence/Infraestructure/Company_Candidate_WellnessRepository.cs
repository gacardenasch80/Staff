using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class Company_Candidate_WellnessRepository : Repository<Company_Candidate_Wellness>, ICompany_Candidate_WellnessRepository
    {
        public Company_Candidate_WellnessRepository(CandidateContext context) : base(context)
        {

        }

        public async Task<List<Company_Candidate_Wellness>> GetToOverview(int candidateId, int companyUserId)
        {
            List<Company_Candidate_Wellness> timeAvailabilities = await _entities.Where(x => x.CandidateId == candidateId && x.CompanyUserId == companyUserId).ToListAsync();

            return timeAvailabilities;
        }
    }
}
