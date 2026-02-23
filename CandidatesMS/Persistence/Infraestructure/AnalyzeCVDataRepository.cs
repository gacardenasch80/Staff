using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class AnalyzeCVDataRepository : Repository<AnalyzeCVData>, IAnalyzeCVDataRepository
    {
        public AnalyzeCVDataRepository(CandidateContext context) : base(context)
        {

        }
    }
}