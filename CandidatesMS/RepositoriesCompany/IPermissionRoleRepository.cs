using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.RepositoriesCompany
{
    public interface IPermissionRoleRepository : IRepositoryCompany<Permission_Role>
    {
        Task<List<Permission_Role>> GetByRoleId(int roleId);
        Task<List<Permission_Role>> GetByRoleIdOnlyChecked(int roleId);
        Task<List<Permission_Role>> GetByRoleIdOnlyCheckedGeneralMethod(int roleId);
    }
}
