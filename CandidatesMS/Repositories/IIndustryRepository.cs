using CandidatesMS.Persistence.Entities;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface IIndustryRepository : IRepository<Industry>
    {
        Task<Industry> GetByGuid(string guid);
    }
}
