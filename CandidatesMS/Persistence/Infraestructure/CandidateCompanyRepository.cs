using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class CandidateCompanyRepository : Repository<CandidateCompany>, ICandidateCompanyRepository
    {
        public CandidateCompanyRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<List<CandidateCompany>> GetByCandidateId(int candidateId)
        {
            return await _entities.Where(x => x.CandidateId == candidateId).ToListAsync();
        }

        public async Task<CandidateCompany> GetByCandidateAndCompanyId(int candidateId, int companyUserId)
        {
            return await _entities.Where(x => x.CandidateId == candidateId && x.CompanyUserId == companyUserId).FirstOrDefaultAsync();
        }

        public async Task<bool> AddCandidateCompany(CandidateCompany candidateCompany)
        {
            await _context.CandidateCompany.AddAsync(candidateCompany);
            int states = await _context.SaveChangesAsync();

            if (states != 0)
                return true;

            return false;
        }
    }
}
