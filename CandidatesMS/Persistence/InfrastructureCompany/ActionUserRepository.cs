using CandidatesMS.ModelsCompany;
using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Persistence.Infraestructure;
using CandidatesMS.RepositoriesCompany;
using CandidatesMS.KeyVault.SecretsModels;
using Microsoft.Extensions.Options;
using Npgsql;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.InfrastructureCompany
{
    public class ActionUserRepository : RepositoryCompany<ActionUser>, IActionUserRepository
    {
        private readonly ConnectionStringDTO _connectionString;

        public ActionUserRepository(CompanyContext context, IOptions<ConnectionStringDTO> connectionString) : base(context)
        {
            _connectionString = connectionString.Value;
        }

        public async Task<ActionUserDTO> GetByValidationString(string validationString)
        {
            /**/

            List<ActionUserWithAuxFieldsDTO> actionUsersWithAuxFieldsDTO = new List<ActionUserWithAuxFieldsDTO>();

            ActionUserDTO actionUser = new ActionUserDTO();

            string quote = "\"";

            DataTable table = new DataTable();

            string sqlDataSource = _connectionString.ConnectionStringCompany;

            NpgsqlDataReader dataReader;

            /**/

            string queryActionUserByString =
                @"SELECT " +

                quote + "ActionUser" + quote + "." + quote + "ActionUserId" + quote + ", " +

                quote + "ActionUser" + quote + "." + quote + "Name" + quote + ", " +
                quote + "ActionUser" + quote + "." + quote + "Description" + quote + ", " +

                quote + "ActionUser" + quote + "." + quote + "StringId" + quote + ", " +

                quote + "Permission_ActionUser" + quote + "." + quote + "Permission_ActionUserId" + quote + " AS " + quote + "Permission_ActionUserId" + quote + ", " +
                quote + "Permission_ActionUser" + quote + "." + quote + "PermissionId" + quote + " AS " + quote + "PermissionId" + quote + " " +

                "FROM " + quote + "ActionUser" + quote + " " +

                "LEFT JOIN " + quote + "Permission_ActionUser" + quote + " " +
                "ON " + quote + "ActionUser" + quote + "." + quote + "ActionUserId" + quote + " = " + quote + "Permission_ActionUser" + quote + "." + quote + "ActionUserId" + quote + " " +

                "WHERE " + quote + "ActionUser" + quote + "." + quote + "StringId" + quote + " = " + "'" + validationString + "'" + " " +

                ";";

            using (NpgsqlConnection connection = new NpgsqlConnection(sqlDataSource))
            {
                connection.Open();

                using (NpgsqlCommand sqlCommand = new NpgsqlCommand(queryActionUserByString, connection))
                {
                    dataReader = await sqlCommand.ExecuteReaderAsync();

                    table.Load(dataReader);

                    actionUsersWithAuxFieldsDTO = table.AsEnumerable().Select(row =>
                        new ActionUserWithAuxFieldsDTO
                        {
                            ActionUserId = row.Field<int>("ActionUserId"),

                            Name = row.Field<string>("Name"),
                            Description = row.Field<string>("Description"),

                            StringId = row.Field<string>("StringId"),

                            Permission_ActionUserId = row.Field<int>("ActionUserId"),

                            PermissionId = row.Field<int>("PermissionId"),
                        }).ToList();

                    connection.Close();
                }
            }

            /**/

            if (actionUsersWithAuxFieldsDTO != null && actionUsersWithAuxFieldsDTO.Count > 0)
            {
                foreach (ActionUserWithAuxFieldsDTO actionUserWithAuxFieldsDTO in actionUsersWithAuxFieldsDTO)
                {
                    if (actionUser.ActionUserId == 0)
                    {
                        actionUser = new ActionUserDTO
                        {
                            ActionUserId = actionUserWithAuxFieldsDTO.ActionUserId,

                            Name = actionUserWithAuxFieldsDTO.Name,
                            Description = actionUserWithAuxFieldsDTO.Description,

                            StringId = actionUserWithAuxFieldsDTO.StringId,

                            Permission_ActionUser = new List<Permission_ActionUserDTO>()
                        };
                    }

                    actionUser.Permission_ActionUser.Add
                    (
                        new Permission_ActionUserDTO
                        {
                            Permission_ActionUserId = actionUserWithAuxFieldsDTO.Permission_ActionUserId,

                            PermissionId = actionUserWithAuxFieldsDTO.PermissionId,
                            ActionUserId = actionUserWithAuxFieldsDTO.ActionUserId
                        }
                    );
                }
            }

            /**/

            return actionUser;
        }
    }
}
