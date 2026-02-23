using CandidatesMS.Repositories;
using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class IndustryRepository : Repository<Industry>, IIndustryRepository
    {
        public IndustryRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<Industry> GetByGuid(string guid)
        {
            Industry industry = await _entities.Where(x => x.IndustryGuid == guid).FirstOrDefaultAsync();
            
            return industry;
        }

        public CandidateContext context
        {
            get { return _context as CandidateContext; }
        }
    }
}
