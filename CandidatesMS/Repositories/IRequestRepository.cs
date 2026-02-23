using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface IRequestRepository : IRepository<Request>
    {
        Task<Request> GetLastRequest(int candidateId,int requestType);
        Task<List<Request>> getDeleteRequest(int candidateId);
    }
}
