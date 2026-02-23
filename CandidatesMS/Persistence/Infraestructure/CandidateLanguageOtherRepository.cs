using AutoMapper;
using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class CandidateLanguageOtherRepository : Repository<Candidate_LanguageOther>, ICandidateLanguageOtherRepository
    {

        public CandidateLanguageOtherRepository(CandidateContext context) : base(context)
        {
        }        

        public async Task<Candidate_LanguageOther> GetByGuid(string candidateLanguageGuid)
        {
            Candidate_LanguageOther candidateLanguage = await context.Candidate_LanguageOther
                .Where(x => x.Candidate_LanguageOtherGuid == candidateLanguageGuid) // Include??
                .FirstOrDefaultAsync();

            return candidateLanguage;
        }

        public async Task<List<Candidate_LanguageOther>> GetByCandidateEmail(string candidateEmail)
        {
            Candidate candidate = await context.Candidate.Where(x => x.Email == candidateEmail).FirstOrDefaultAsync();
            List<Candidate_LanguageOther> candidateLanguages = new List<Candidate_LanguageOther>();

            if (candidate != null)
            {
                candidateLanguages = await context.Candidate_LanguageOther
                .Where(x => x.CandidateId == candidate.CandidateId) // Include??
                .Include(l => l.LanguageOther)
                .Include(ll => ll.LanguageLevel)
                .AsNoTracking()
                .ToListAsync();
            }
            return candidateLanguages;
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
