using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Persistence.Infraestructure;
using CandidatesMS.RepositoriesCompany;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.InfrastructureCompany
{
    public class PercentCriteriaRepository
    (
        CompanyContext context
    )
    :
    RepositoryCompany<PercentCriteria>(context), IPercentCriteriaRepository
    {
        public async Task<PercentCriteria> GetByCompanyUserId(int companyUserId)
        {
            try
            {
                PercentCriteria percentCriteria =
                    await _entities
                    .Where
                    (
                        percentCriteria => percentCriteria.CompanyUserId == companyUserId
                    )
                    .FirstOrDefaultAsync();

                return percentCriteria;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
