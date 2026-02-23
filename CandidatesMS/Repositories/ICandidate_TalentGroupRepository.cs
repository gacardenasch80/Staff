using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ICandidate_TalentGroupRepository : IRepository<Candidate_TalentGroupAux>
    {
        Task<List<Candidate_TalentGroupAux>> GetByTalentGroupId(int candidate_talentGroup);
        Task<List<Candidate_TalentGroupAux>> GetByCandidateId(int candidateId);
        Task<bool> RemoveByTalentGroupId(int candidate_talentGroup);
    }
}
