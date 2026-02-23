using AutoMapper;
using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class LanguageRepository : Repository<Language>, ILanguageRepository
    {

        public LanguageRepository(CandidateContext context) : base(context)
        {
        }        

        public async Task<Language> GetByGuid(string languageGuid)
        {
            Language language = await context.Language
                .Where(x => x.LanguageGuid == languageGuid) // Include??
                .FirstOrDefaultAsync();

            return language;
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
