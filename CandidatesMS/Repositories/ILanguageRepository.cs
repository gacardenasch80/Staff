using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ILanguageRepository : IRepository<Language>
    {
        Task<Language> GetByGuid(string guid);
    }
}
