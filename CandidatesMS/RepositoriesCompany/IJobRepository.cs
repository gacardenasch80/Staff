using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using System.Threading.Tasks;

namespace CandidatesMS.RepositoriesCompany
{
    public interface IJobRepository : IRepositoryCompany<Job>
    {
        Task<Job> GetByJobId(int jobId);
    }
}