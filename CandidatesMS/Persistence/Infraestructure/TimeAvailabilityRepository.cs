using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class TimeAvailabilityRepository : Repository<TimeAvailability>, ITimeAvailabilityRepository
    {
        public TimeAvailabilityRepository(CandidateContext context) : base(context)
        {

        }
    }
}