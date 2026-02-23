using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.RepositoriesCompany
{
    public interface IEvaluationRepository : IRepositoryCompany<Evaluation>
    {
        Task<List<Evaluation>> GetEvaluationsByCandidateAndJobIdAfterEditionDate(int candidateId, int jobId, PercentCriteria percentCriteria);
        Task<List<Evaluation>> GetEvaluationsByCandidateAndTalentGroupIdAfterEditionDate(int candidateId, int talentGroupId, PercentCriteria percentCriteria);
        Task<Evaluation> GetEvaluationByIdWithCriterias(int evaluationId);
    }
}