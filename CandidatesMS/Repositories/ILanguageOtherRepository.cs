using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ILanguageOtherRepository : IRepository<LanguageOther>
    {
        Task<LanguageOther> GetByGuid(string guid);
        Task<List<LanguageOther>> GetByCandidateId(int candidateId);
        Task<List<LanguageOther>> GetByCandidateIdAdminView(int candidateId);
        Task<List<LanguageOther>> GetToOverview(int candidateId, int companyUserId);
    }
}
