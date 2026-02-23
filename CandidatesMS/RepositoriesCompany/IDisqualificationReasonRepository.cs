using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.RepositoriesCompany
{
    public interface IDisqualificationReasonRepository : IRepositoryCompany<DisqualificationReason>
    {
        Task<List<DisqualificationReason>> GetByCompanyUserId(int companyUserId);
    }
}
