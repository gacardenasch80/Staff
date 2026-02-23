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
    public class DisqualificationReasonRepository
    (
        CompanyContext context
    )
    :
    RepositoryCompany<DisqualificationReason>(context), IDisqualificationReasonRepository
    {

        public async Task<List<DisqualificationReason>> GetByCompanyUserId(int companyUserId)
        {
            List<DisqualificationReason> reasons = await _entities.Where(x => x.CompanyUserId == companyUserId).ToListAsync();

            return reasons;
        }
    }
}
