using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class RequestRepository : Repository<Request>, IRequestRepository
    {
        public RequestRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<List<Request>> getDeleteRequest(int candidateId)
        {
            List<Request> request = await _entities.Include(x => x.RequestType)
                .Where(x => x.CandidateId == candidateId && x.RequestTypeId == 2)
                .OrderByDescending(x => x.RequestId)
                .ToListAsync();

            return request;
        }

        public async Task<Request> GetLastRequest(int candidateId, int requestType)
        {
            Request request = await _entities.Include(x => x.RequestType)
                .Where(x => x.CandidateId == candidateId && x.RequestTypeId == requestType)
                .OrderByDescending(x => x.RequestId)
                .FirstOrDefaultAsync();
                
            return request;
        }
    }
}
