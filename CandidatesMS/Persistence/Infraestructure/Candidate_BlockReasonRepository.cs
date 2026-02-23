using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class Candidate_BlockReasonRepository : RepositoryCompany<Candidate_BlockReason>, ICandidate_BlockReasonRepository
    {
        public Candidate_BlockReasonRepository(CompanyContext context) : base(context)
        {
        }

        public async Task<Candidate_BlockReason> GetByCandidateId(int candidateId)
        {
            Candidate_BlockReason blockedCandidate = await _entities.Where(x => x.CandidateId == candidateId).Include(x => x.BlockReason).FirstOrDefaultAsync();

            return blockedCandidate;
        }

        public async Task<Candidate_BlockReason> GetByCandidateAndCompanyId(int candidateId, int companyUserId)
        {
            List<Candidate_BlockReason> blockedCandidate = await _entities.Where(x => x.CandidateId == candidateId)
                .Include(x => x.BlockReason).ToListAsync();

            Candidate_BlockReason candidate_BlockReason = blockedCandidate.Where(x => x.BlockReason.CompanyUserId == companyUserId).FirstOrDefault();

            return candidate_BlockReason;
        }

        public async Task<Candidate_BlockReason> GetByBlockReasonId(int blockReasonId)
        {
            Candidate_BlockReason blockedCandidate = await _entities.Where(x => x.BlockReasonId == blockReasonId).FirstOrDefaultAsync();

            return blockedCandidate;
        }

        public async Task<bool> RemoveByCandidateId(int candidateId)
        {
            var entity = await _entities.Where(x => x.CandidateId == candidateId).FirstOrDefaultAsync();
            if (entity != null)
            {
                _entities.Remove(entity);
                var states = await _context.SaveChangesAsync();
                if (states != 0)
                    return true;
            }
            return false;
        }
    }
}
