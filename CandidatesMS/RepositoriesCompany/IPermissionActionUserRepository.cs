using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.RepositoriesCompany
{
    public interface IPermissionActionUserRepository : IRepositoryCompany<Permission_ActionUser>
    {
        Task<List<Permission_ActionUser>> GetAllByPermissionId(int permissionId);
    }
}
