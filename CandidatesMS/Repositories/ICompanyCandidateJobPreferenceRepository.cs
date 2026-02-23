using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ICompanyCandidateJobPreferenceRepository : IRepository<Company_Candidate_Wellness>
    {
        #region Wellness

        Task<List<Company_Candidate_Wellness>> GetCompanyCandidateWellnessByCandidateId(int candidateId);
        Task<List<Company_Candidate_Wellness>> GetCompanyCandidateWellnessByCandidateAndCompanyId(int candidateId, int companyUserId);
        Task<bool> AddCompanyCandidateWellness(int candidateId, List<Company_Candidate_Wellness> companyCandidateWellness);
        Task<Company_Candidate_Wellness> RemoveCompanyCandidateWellness(Company_Candidate_Wellness companyCandidateWellness);
        Task<Company_Candidate_Wellness> GetCompanyCandidateWellnessByIds(int candidateId, int wellnessId);
        bool UpdateCompanyCandidateWellnessByIds(Company_Candidate_Wellness candidateWellness);

        #endregion

        #region Time Availability

        Task<List<Company_Candidate_TimeAvailability>> GetCompanyCandidateTimeAvailabilityByCandidateId(int candidateId);
        Task<List<Company_Candidate_TimeAvailability>> GetCompanyCandidateTimeAvailabilityByCandidateAndCompanyId(int candidateId, int companyUserId);
        Task<bool> AddCompanyCandidateTimeAvailabilities(int candidateId, List<Company_Candidate_TimeAvailability> companyCandidateTimeAvailabilities);
        Task<Company_Candidate_TimeAvailability> RemoveCompanyCandidateTimeAvailability(Company_Candidate_TimeAvailability companyCandidateTimeAvailability);
        Task<Company_Candidate_TimeAvailability> GetCompanyCandidateTimeAvailabilityByIds(int candidateId, int timeAvailabilityId);
        bool UpdateCompanyCandidateTimeByIds(Company_Candidate_TimeAvailability candidateTime);

        #endregion
    }
}
