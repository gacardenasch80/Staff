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
    public class LanguageLevelRepository : Repository<LanguageLevel>, ILanguageLevelRepository
    {

        public LanguageLevelRepository(CandidateContext context) : base(context)
        {
        }        

        public async Task<LanguageLevel> GetByGuid(string languagelevelGuid)
        {
            LanguageLevel languagelevel = await context.LanguageLevel
                .Where(x => x.LanguageLevelGuid == languagelevelGuid) // Include??
                .FirstOrDefaultAsync();

            return languagelevel;
        }

        public async Task<List<LanguageLevel>> GetAllTidy()
        {
            List<LanguageLevel> languageslevel = await context.LanguageLevel
                .OrderBy(x => x.LanguageLevelName).ToListAsync();

            return languageslevel;
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
