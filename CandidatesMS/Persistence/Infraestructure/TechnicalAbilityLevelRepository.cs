using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class TechnicalAbilityLevelRepository : Repository<TechnicalAbilityLevel>, ITechnicalAbilityLevelRepository
    {
        public TechnicalAbilityLevelRepository(CandidateContext context) : base(context)
        {
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
