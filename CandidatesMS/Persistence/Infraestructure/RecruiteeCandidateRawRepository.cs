using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class RecruiteeCandidateRawRepository : Repository<RecruiteeCandidateRaw>, IRecruiteeCandidateRawRepository
    {
        public RecruiteeCandidateRawRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<RecruiteeCandidateRaw> GetByRecruiteeId(int recruiteeId)
        {
            RecruiteeCandidateRaw candidate = await _entities.Where(x => x.RecruiteeId == recruiteeId).FirstOrDefaultAsync();

            return candidate;
        }
    }
}
