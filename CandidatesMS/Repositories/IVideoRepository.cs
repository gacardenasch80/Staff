using System;
using System.Collections.Generic;
using System.Linq;
using CandidatesMS.Persistence.Entities;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface IVideoRepository : IRepository<Video>
    {
        Task<Video> GetByGuid(string guid);
        Task<bool> VideoExists(int candidateId);
        Task<Video> GetByCandidateId(int candidateId);

    }
}
