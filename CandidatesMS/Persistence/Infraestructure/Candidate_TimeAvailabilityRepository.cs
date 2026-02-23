using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class Candidate_TimeAvailabilityRepository : Repository<Candidate_TimeAvailability>, ICandidate_TimeAvailabilityRepository
    {
        public Candidate_TimeAvailabilityRepository(CandidateContext context) : base(context)
        {

        }

        public async Task<List<Candidate_TimeAvailability>> GetToOverview(int candidateId, int companyUserId)
        {
            List<Candidate_TimeAvailability> timeAvailabilities = await _entities.Where(x => x.CandidateId == candidateId).ToListAsync();

            return timeAvailabilities;
        }
    }
}