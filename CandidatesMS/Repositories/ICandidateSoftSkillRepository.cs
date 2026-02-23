using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ICandidateSoftSkillRepository : IRepository<Candidate_SoftSkill>
    {
        Task<List<Candidate_SoftSkill>> GetByCandidateId(int candidateId);
        Task<List<Candidate_SoftSkill>> GetByCandidateAndCompanyId(int candidateId, int companyUserId);
        Task<List<Candidate_SoftSkill>> GetByCandidateIdAndNoCompany(int candidateId);
        Task<bool> ExistsByCandidateAndSoftSkillId(int candidateId, int softSkillId);
        Task<bool> ExistsByCandidateAndSoftSkillIdDescription(int candidateId, int Candidate_SoftSkillId);
        Task<Candidate_SoftSkill> GetByGuid(string candidateSoftSkillGuid);
        Task RemovefromByCandidateIdAsync(int candidateId);
        Task<List<Candidate_SoftSkill>> GetToOverview(int candidateId, int companyUserId);
    }
}
