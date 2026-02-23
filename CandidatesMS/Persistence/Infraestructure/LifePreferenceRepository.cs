using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.Infraestructure;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Infraestructure
{
    public class LifePreferenceRepository : Repository<LifePreference>, ILifePreferenceRepository
    {
        public LifePreferenceRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<LifePreference> GetByGuid(string lifePreferenceyGuid)
        {
            LifePreference lifePreference = await _context.LifePreference
                .Where(x => x.LifePreferenceGuid == lifePreferenceyGuid)
                .FirstOrDefaultAsync();

            //LifePreferenceDTO lifePreferenceDTO = _mapper.Map<LifePreference, LifePreferenceDTO>(lifePreference);

            return lifePreference;
        }

        /// <summary>
        /// Getting context
        /// </summary>
        public CandidateContext context
        {
            get { return _context as CandidateContext; }
        }
    }
}
