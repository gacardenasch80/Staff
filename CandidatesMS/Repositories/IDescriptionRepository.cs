using CandidatesMS.Persistence.Entities;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface IDescriptionRepository : IRepository<Description>
    {
        Task<Description> GetByGuid(string guid);
        Task<bool> DescriptionExists(int candidateId);
        Task<Description> GetByCandidateId(int candidateId);
        Task<bool> EditDescription(Description description);

    }
}
