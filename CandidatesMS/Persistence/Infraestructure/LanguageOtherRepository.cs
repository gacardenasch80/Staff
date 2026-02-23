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
    public class LanguageOtherRepository : Repository<LanguageOther>, ILanguageOtherRepository
    {

        public LanguageOtherRepository(CandidateContext context) : base(context)
        {
        }        

        public async Task<LanguageOther> GetByGuid(string languageGuid)
        {
            LanguageOther language = await context.LanguageOther
                .Where(x => x.LanguageOtherGuid == languageGuid) // Include??
                .FirstOrDefaultAsync();

            return language;
        }

        public async Task<List<LanguageOther>> GetByCandidateId(int candidateId)
        {
            List<LanguageOther> languages = await _entities.Where(x => x.CandidateId == candidateId && x.AdminView == false).ToListAsync();

            return languages;
        }

        public async Task<List<LanguageOther>> GetByCandidateIdAdminView(int candidateId)
        {
            List<LanguageOther> languages = await _entities.Where(x => x.CandidateId == candidateId).ToListAsync();

            return languages;
        }

        public async Task<List<LanguageOther>> GetToOverview(int candidateId, int companyUserId)
        {
            List<LanguageOther> languages = await _entities.Where(x => x.CandidateId == candidateId && (x.AdminView == false || (x.AdminView == true && x.CompanyUserId == companyUserId))).ToListAsync();

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
