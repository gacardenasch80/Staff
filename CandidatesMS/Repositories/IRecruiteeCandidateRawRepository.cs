using CandidatesMS.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface IRecruiteeCandidateRawRepository : IRepository<RecruiteeCandidateRaw>
    {
        Task<RecruiteeCandidateRaw> GetByRecruiteeId(int recruiteeId);
    }
}
