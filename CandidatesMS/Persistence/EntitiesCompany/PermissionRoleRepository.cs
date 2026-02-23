using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Infraestructure;
using CandidatesMS.RepositoriesCompany;
using CandidatesMS.KeyVault.SecretsModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class PermissionRoleRepository : RepositoryCompany<Permission_Role>, IPermissionRoleRepository
    {
        private readonly ConnectionStringDTO _connectionString;

        public PermissionRoleRepository(CompanyContext context, IOptions<ConnectionStringDTO> connectionString) : base(context)
        {
            _connectionString = connectionString.Value;
        }

        public async Task<List<Permission_Role>> GetByRoleId(int roleId)
        {
            List<Permission_Role> permissionRoles = await _entities.Where(x => x.RoleId == roleId)
            .Include(x => x.Role)
                .Include(x => x.Permission).ThenInclude(y => y.PermissionGroup)
                .ToListAsync();
            return permissionRoles;
        }

        public async Task<List<Permission_Role>> GetByRoleIdOnlyChecked(int roleId)
        {
            List<Permission_Role> permissionRoles = await _entities.Where(x => x.RoleId == roleId && x.IsCheck == true)
                .Include(x => x.Role)
                .Include(x => x.Permission).ThenInclude(y => y.PermissionGroup)
                .ToListAsync();
            return permissionRoles;
        }

        public async Task<List<Permission_Role>> GetByRoleIdOnlyCheckedGeneralMethod(int roleId)
        {
            /**/

            List<Permission_Role> permissionRoles = new List<Permission_Role>();

            string quote = "\"";

            DataTable table = new DataTable();

            string sqlDataSource = _connectionString.ConnectionStringCompany;

            NpgsqlDataReader dataReader;

            /**/

            string queryAllCheckedPermissionRoles =
                @"SELECT " +

                quote + "Permission_Role" + quote + "." + quote + "Permission_RoleId" + quote + ", " +

                quote + "Permission_Role" + quote + "." + quote + "PermissionId" + quote + ", " +
                quote + "Permission_Role" + quote + "." + quote + "RoleId" + quote + ", " +

                quote + "Permission_Role" + quote + "." + quote + "IsCheck" + quote + ", " +
                quote + "Permission_Role" + quote + "." + quote + "IsDisabled" + quote + " " +

                "FROM " + quote + "Permission_Role" + quote + " " +

                "WHERE " + quote + "Permission_Role" + quote + "." + quote + "RoleId" + quote + " = " + roleId.ToString() + " " +
                "AND " + quote + "Permission_Role" + quote + "." + quote + "IsCheck" + quote + " = true " +

                ";";

            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();

                using (NpgsqlCommand sqlCommand = new NpgsqlCommand(queryAllCheckedPermissionRoles, connection))
                {
                    dataReader = await sqlCommand.ExecuteReaderAsync();

                    table.Load(dataReader);

                    permissionRoles = table.AsEnumerable().Select(row =>
                        new Permission_Role
                        {
                            Permission_RoleId = row.Field<int>("Permission_RoleId"),

                            PermissionId = row.Field<int>("PermissionId"),
                            RoleId = row.Field<int>("RoleId"),

                            IsCheck = row.Field<bool>("IsCheck"),
                            IsDisabled = row.Field<bool>("IsDisabled")
                        }).ToList();

                    connection.Close();
                }
            }

            /**/

            return permissionRoles;
        }
    }
}
