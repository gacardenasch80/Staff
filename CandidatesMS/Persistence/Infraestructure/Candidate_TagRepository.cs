using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CandidatesMS.Persistence.Infraestructure
{
    public class Candidate_TagRepository : Repository<Candidate_Tag>, ICandidate_TagRepository
    {
        public Candidate_TagRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<List<Candidate_Tag>> GetByCandidateId(int candidateId)
        {
            List<Candidate_Tag> candidate_tags = await _entities.Where(x => x.CandidateId == candidateId).ToListAsync();

            return candidate_tags;
        }

        public async Task<Candidate_Tag> GetByTagId(int candidate_tagId)
        {
            Candidate_Tag candidate_tag = await _entities.Where(x => x.Candidate_TagId == candidate_tagId).FirstOrDefaultAsync();

            return candidate_tag;
        }

        public async Task<bool> RemoveByTagId(int tagId)
        {
            Candidate_Tag candidateTag = await _entities.Where(x => x.Candidate_TagId == tagId).FirstOrDefaultAsync();

            _entities.Remove(candidateTag);

            int states = await _context.SaveChangesAsync();

            if (states != 0)
                return true;

            return false;
        }
    }
}