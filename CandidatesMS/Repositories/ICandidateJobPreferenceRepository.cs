using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ICandidateJobPreferenceRepository : IRepository<Candidate_Wellness>
    {
        #region Wellness
        Task<List<Candidate_Wellness>> GetWellnessByCandidateId(int candidateId);
        Task<List<Wellness>> GetAllWellness();
        Task<Candidate_Wellness> GetCandidateWellnessByIds(int candidateId, int wellnessId);
        Task<bool> AddWellness(int candidateId, List<Candidate_Wellness> wellness);
        Task<Candidate_Wellness> RemoveWellness(Candidate_Wellness candidateWellness);
        #endregion

        #region Time Availability
        Task<List<Candidate_TimeAvailability>> GetTimeAvailabilityByCandidateId(int candidateId);
        Task<List<TimeAvailability>> GetAllTimeAvailabilities();
        Task<Candidate_TimeAvailability> GetCandidateTimeAvailabilityByIds(int candidateId, int timeAvailabilityId);
        Task<bool> AddTimeAvailabilities(int candidateId, List<Candidate_TimeAvailability> timeAvailabilities);
        Task<Candidate_TimeAvailability> RemoveTimeAvailability(Candidate_TimeAvailability candidateTimeAvailability);
        #endregion
    }
}
