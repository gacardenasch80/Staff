using CandidatesMS.Repositories;
using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class EquivalentPositionRepository : Repository<EquivalentPosition>, IEquivalentPositionRepository
    {
        public EquivalentPositionRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<EquivalentPosition> GetByGuid(string guid)
        {
            EquivalentPosition equivalentPosition = await _entities.Where(x => x.EquivalentPositionGuid == guid).FirstOrDefaultAsync();

            return equivalentPosition;
        }

        public CandidateContext context
        {
            get { return _context as CandidateContext; }
        }
    }
}
