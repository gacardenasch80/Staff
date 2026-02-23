using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Persistence.Infraestructure;
using CandidatesMS.RepositoriesCompany;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.InfrastructureCompany
{
    public class PermissionActionUserRepository : RepositoryCompany<Permission_ActionUser>, IPermissionActionUserRepository
    {
        public PermissionActionUserRepository(CompanyContext context) : base(context)
        {
        }

        public async Task<List<Permission_ActionUser>> GetAllByPermissionId(int permissionId)
        {
            List<Permission_ActionUser> permissions_ActionUser = new List<Permission_ActionUser>();

            permissions_ActionUser = await _entities.Where(x => x.PermissionId == permissionId).ToListAsync();

            return permissions_ActionUser;
        }
    }
}
