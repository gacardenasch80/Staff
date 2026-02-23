using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class WellnessRepository : Repository<Wellness>, IWellnessRepository
    {
        public WellnessRepository(CandidateContext context) : base(context)
        {

        }
    }
}
