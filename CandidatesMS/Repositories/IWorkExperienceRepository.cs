using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface IWorkExperienceRepository : IRepository<WorkExperience>
    {
        Task<WorkExperience> GetByGuid(string guid);
        Task<List<WorkExperience>> GetByCandidateId(int candidateId);
        Task<List<WorkExperience>> GetAdminViewByCandidateId(int candidateId, int companyUserId);
        Task<List<WorkExperience>> GetAdminViewByCandidateIdMaster(int candidateId);
        Task<List<WorkExperience>> GetToOverview(int candidateId, int companyUserId);
    }
}
