using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class CandidateLanguageRepository : Repository<Candidate_Language>, ICandidateLanguageRepository
    {

        public CandidateLanguageRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<List<Candidate_Language>> GetAllWithLanguageAndLevel()
        {
            List<Candidate_Language> candidateLanguages = await _entities.Include(x => x.Language).Include(x => x.LanguageLevel).AsNoTracking().ToListAsync();

            return candidateLanguages;
        }

        public async Task<Candidate_Language> GetByGuid(string candidateLanguageId)
        {
            Candidate_Language candidateLanguage = await context.Candidate_Language
                .Where(x => x.Candidate_LanguageGuid == candidateLanguageId) // Include??
                .FirstOrDefaultAsync();

            return candidateLanguage;
        }

        public async Task<List<Candidate_Language>> GetByCandidateEmail(string candidateEmail)
        {
            Candidate candidate = await context.Candidate.Where(x => x.Email == candidateEmail).FirstOrDefaultAsync();
            List<Candidate_Language> candidateLanguages = new List<Candidate_Language>();

            if (candidate != null)
            {
                
                candidateLanguages = await context.Candidate_Language
                .Where(x => x.CandidateId == candidate.CandidateId) // Include??
                .Include(l => l.Language)
                .Include(ll => ll.LanguageLevel)
                .AsNoTracking()
                .ToListAsync();
            }
            return candidateLanguages;
        }

        public async Task<List<Candidate_Language>> GetByCandidateId(int candidateId)
        {
            List<Candidate_Language> languages = await _entities.Where(x => x.CandidateId == candidateId && x.AdminView == false)
                .Include(l => l.Language).Include(ll => ll.LanguageLevel).ToListAsync();

            return languages;
        }

        public async Task<List<Candidate_Language>> GetByCandidateIdAdminView(int candidateId)
        {
            List<Candidate_Language> languages = await _entities.Where(x => x.CandidateId == candidateId)
                .Include(l => l.Language).Include(ll => ll.LanguageLevel).ToListAsync();

            return languages;
        }

        public async Task<List<Candidate_Language>> GetToOverview(int candidateId, int companyUserId)
        {
            List<Candidate_Language> languages = await _entities.Where(x => x.CandidateId == candidateId && (x.AdminView == false || (x.AdminView == true && x.CompanyUserId == companyUserId))).ToListAsync();

            return languages;
        }

        /// <summary>
        /// Getting context
        /// </summary>
        public CandidateContext context
        {
            get { return _context as CandidateContext; }
        }
    }
}
