using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class CCORepository : Repository<CCO>, ICCORepository
    {
        public CCORepository(CandidateContext context) : base(context)
        {
        }
    }
}
