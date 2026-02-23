using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CandidatesMS.Persistence.Infraestructure
{
    public class Candidate_SourceRepository : Repository<Candidate_Source>, ICandidate_SourceRepository
    {
        public Candidate_SourceRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<List<Candidate_Source>> GetByCandidateId(int candidateId)
        {
            List <Candidate_Source> candidate_sources = await _entities.Where(x => x.CandidateId == candidateId).ToListAsync();

            return candidate_sources;
        }

        public async Task<List<Candidate_Source>> GetBySourceId(int candidate_sourceId)
        {
            List<Candidate_Source> candidate_sources = await _entities.Where(x => x.Candidate_SourceId == candidate_sourceId).ToListAsync();

            return candidate_sources;
        }

        public async Task<bool> RemoveBySourceId(int sourceId)
        {
            Candidate_Source candidateSource = await _entities.Where(x => x.Candidate_SourceId == sourceId).FirstOrDefaultAsync();

            _entities.Remove(candidateSource);

            int states = await _context.SaveChangesAsync();

            if (states != 0)
                return true;

            return false;
        }
    }
}
