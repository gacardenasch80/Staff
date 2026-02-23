using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class CandidateRecruiteeRepository : Repository<CandidateRecruitee>, ICandidateRecruiteeRepository
    {
        public CandidateRecruiteeRepository(CandidateContext context) : base(context)
        {
        }
    }
}
