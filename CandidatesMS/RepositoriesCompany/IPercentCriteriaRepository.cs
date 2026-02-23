using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using System.Threading.Tasks;

namespace CandidatesMS.RepositoriesCompany
{
    public interface IPercentCriteriaRepository : IRepositoryCompany<PercentCriteria>
    {
        Task<PercentCriteria> GetByCompanyUserId(int companyUserId);
    }
}