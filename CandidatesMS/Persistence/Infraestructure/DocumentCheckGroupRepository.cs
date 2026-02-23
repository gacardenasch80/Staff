using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class DocumentCheckGroupRepository : Repository<DocumentCheckGroup>, IDocumentCheckGroupRepository
    {
        public DocumentCheckGroupRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<List<DocumentCheckGroup>> GetAllInRange(int start, int end)
        {
            List<DocumentCheckGroup> documentsCheckGroups = await _entities.Where(x => x.DocumentCheckGroupId >= start && x.DocumentCheckGroupId <= end).OrderBy(x => x.DocumentCheckGroupId).ToListAsync();

            return documentsCheckGroups;
        }
    }
}
