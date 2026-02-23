using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Persistence.Infraestructure;
using CandidatesMS.RepositoriesCompany;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.InfrastructureCompany
{
    public class EvaluationCriteriaRepository(CompanyContext context) : RepositoryCompany<EvaluationCriteria>(context), IEvaluationCriteriaRepository
    {
        public async Task<List<EvaluationCriteria>> GetByCompanyUserId(int companyUserId)
        {
            List<EvaluationCriteria> evaluationCriterias =
                await _entities
                .Where
                (
                    evaluationCriteria => evaluationCriteria.CompanyUserId == companyUserId
                )
                .ToListAsync();
            
            return evaluationCriterias;
        }

        public async Task<List<EvaluationCriteria>> GetByCompanyUserAndEvaluationCriteriaTypeId(int companyUserId, int evaluationCriteriaTypeId)
        {
            List<EvaluationCriteria> evaluationCriterias = 
                await _entities
                .Where
                (
                    evaluationCriteria
                    =>
                    evaluationCriteria.CompanyUserId == companyUserId
                    &&
                    evaluationCriteria.EvaluationCriteriaTypeId == evaluationCriteriaTypeId
                )
                .AsNoTracking()
                .ToListAsync();

            return evaluationCriterias;
        }
    }
}
