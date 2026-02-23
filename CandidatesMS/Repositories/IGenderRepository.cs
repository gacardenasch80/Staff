using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface IGenderRepository : IRepository<Gender>
    {
        Task<Gender> GetByGuid(string Guid);
        Task<Gender> GetByIdWithoutNull(int genderId);
        Task<List<Gender>> GetAllGenders();
        Task<List<Gender>> GetAllGendersExceptZero();
        //Task<Gender> GetById(int id);
    }
}
