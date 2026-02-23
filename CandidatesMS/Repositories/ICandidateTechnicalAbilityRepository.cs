using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ICandidateTechnicalAbilityRepository : IRepository<Candidate_TechnicalAbility>
    {
        Task<List<Candidate_TechnicalAbility>> GetAllWithLevel();
        Task<List<Candidate_TechnicalAbility>> GetAllWithLevelAndTechnology();
        Task<List<Candidate_TechnicalAbility>> GetByCandidateId(int candidateId);
        Task<List<Candidate_TechnicalAbility>> GetByCandidateIdMaster(int candidateId);
        Task<Candidate_TechnicalAbility> GetSkillcanditateByid(int Candidate_TechnicalAbilityId);
        Task<Candidate_TechnicalAbility> GetByGuid(string candidateTechnicalAbilityGuid);
        Task<bool> ExistByIds(int? technicalAbilityTechnologyId, int candidateId);
        Task<bool> ExistByIdAndName(string name, int candidateId);
        Task<bool> ExistByIdsOnCompany(int? technicalAbilityTechnologyId, int candidateId);
        Task<bool> ExistByIdAndNameOnCompany(string name, int candidateId);
        bool UpdateOwn(Candidate_TechnicalAbility candidateTechnicalAbility);
        Task<List<Candidate_TechnicalAbility>> GetToOverview(int candidateId, int companyUserId);
    }
}
