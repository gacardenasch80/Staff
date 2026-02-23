using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;


namespace CandidatesMS.Persistence.Infraestructure
{
    public class CCRepository : Repository<CC>, ICCRepository
    {
        public CCRepository(CandidateContext context) : base(context)
        {
        }
    }
}
