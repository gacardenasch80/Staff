using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ILanguageLevelRepository : IRepository<LanguageLevel>
    {
        Task<LanguageLevel> GetByGuid(string guid);
        Task<List<LanguageLevel>> GetAllTidy();
    }
}
