using CandidatesMS.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ITitleRepository : IRepository<Title>
    {
        Task<Title> GetByGuid(string Guid);
        Task<Title> GetByTitleId(int studyId);
    }
}
