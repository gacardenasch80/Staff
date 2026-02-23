using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface IStudyRepository : IRepository<Study>
    {
        Task<List<Study>> GetByCandidateId(int candidateId);
        Task<List<Study>> GetByCandidateIdAdminView(int candidateId, int companyUserId);
        Task<List<Study>> GetToOverview(int candidateId, int companyUserId);
        Task<List<Study>> GetByCandidateIdAdminViewMaster(int candidateId);
        public Task<bool> StudyExist(int studyId, bool isFromCandidate);
        new Task<Study> Add(Study study);
    }
}
