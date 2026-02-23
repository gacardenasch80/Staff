using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface IDocumentCheckGroupRepository : IRepository<DocumentCheckGroup>
    {
        Task<List<DocumentCheckGroup>> GetAllInRange(int start, int end);
    }
}
