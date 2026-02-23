using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface IMaritalStatusRepository : IRepository<MaritalStatus>
    {
        Task<List<MaritalStatus>> GetAllmarital();
        //Task<MaritalStatusDTO> GetById(int id);
        Task<MaritalStatus> GetByGuid(string Guid);
        Task<MaritalStatus> GetByIdWithoutNull(int maritalStatusId);
        Task<List<MaritalStatus>> GetAllMaritalStatusesExceptZero();

    }
}
