using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.RepositoriesCompany
{
    public interface IEvaluationCriteriaRepository : IRepository<EvaluationCriteria>
    {
        Task<List<EvaluationCriteria>> GetByCompanyUserId(int companyUserId);
        Task<List<EvaluationCriteria>> GetByCompanyUserAndEvaluationCriteriaTypeId(int companyUserId, int evaluationCriteriaTypeId);
    }
}
