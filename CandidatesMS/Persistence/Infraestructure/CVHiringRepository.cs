using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class CVHiringRepository : Repository<CVHiring>, ICVHiringRepository
    {
        public CVHiringRepository(CandidateContext context) : base(context)
        {
        }

        public async  Task<CVHiring> DeleteOverViewCv(int candidateId)
        {
            CVHiring cvHiring = await _entities.Where(x => x.CandidateId == candidateId && x.OverViewCv == true).FirstOrDefaultAsync();
            if (cvHiring != null)
            {
                cvHiring.OverViewCv = false;
                _context.SaveChanges();
            }
            return cvHiring;
        }

        public async Task<List<CVHiring>> GetAllByCandidateIdAndCompanyUserId(int candidateId, int companyUserId)
        {
            List<CVHiring> cv = await _entities.Where(x => x.CandidateId == candidateId && (x.CompanyUserId == companyUserId || x.CompanyUserId == 0))
                .Include(x => x.FileTypeHiring).ToListAsync();
            return cv;
        }

        public async Task<List<CVHiring>> GetAllByCandidateIdAndOnlyCompanyUserId(int candidateId, int companyUserId)
        {
            List<CVHiring> cv = await _entities.Where(x => x.CandidateId == candidateId && x.CompanyUserId == companyUserId)
                .Include(x => x.FileTypeHiring).ToListAsync();
            return cv;
        }

        public async Task<List<CVHiring>> GetUploadByCandidateByCandidateId(int candidateId)
        {
            List<CVHiring> cv = await _entities.Where(x => x.CandidateId == candidateId && x.CompanyUserId == 0)
                .Include(x => x.FileTypeHiring).ToListAsync();
            return cv;
        }
    }
}
