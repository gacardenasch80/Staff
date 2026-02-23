using CandidatesMS.Persistence.Infraestructure;
using CandidatesMS.RepositoriesCompany;
using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.EntitiesCompany;

namespace CandidatesMS.Persistence.InfrastructureCompany
{
    public class JobProfessionRepository
    (
        CompanyContext context
    )
    :
    RepositoryCompany<JobProfession>(context), IJobProfessionRepository
    {

    }
}
