using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ICandidateLifePreferenceRepository : IRepository<Candidate_LifePreference>
    {
        Task<List<Candidate_LifePreference>> GetByCandidateId(int candidateId, bool isFromCandidate);
        Task<bool> ExistsByCandidateAndLifePreferenceId(int candidateId, int lifePreferenceId, bool isFromCandidate);
        Task<Candidate_LifePreference> GetByGuid(string Guid);
        Task<List<Candidate_LifePreference>> GetToOverview(int candidateId, int companyUserId);
    }
}
