using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class Candidate_WellnessRepository : Repository<Candidate_Wellness>, ICandidate_WellnessRepository
    {
        public Candidate_WellnessRepository(CandidateContext context) : base(context)
        {

        }

        public async Task<List<Candidate_Wellness>> GetToOverview(int candidateId, int companyUserId)
        {
            List<Candidate_Wellness> wellnesses = await _entities.Where(x => x.CandidateId == candidateId).ToListAsync();

            return wellnesses;
        }
    }
}