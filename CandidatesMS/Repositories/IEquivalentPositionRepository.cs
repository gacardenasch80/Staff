using CandidatesMS.Persistence.Entities;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface IEquivalentPositionRepository : IRepository<EquivalentPosition>
    {
        Task<EquivalentPosition> GetByGuid(string guid);
    }
}
