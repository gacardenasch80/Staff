using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Persistence.Infraestructure;
using CandidatesMS.RepositoriesCompany;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.InfrastructureCompany
{
    public class JobRepository
    (
        CompanyContext context
    )
    :
    RepositoryCompany<Job>(context), IJobRepository
    {
        public async Task<Job> GetByJobId(int jobId)
        {
            Job job = await _entities
                .Where
                (
                    job => job.JobId == jobId
                )
                .AsNoTracking()

                .Include(job => job.JobPostingStatus)
                .Include(job => job.InternalCode)
                .Include(job => job.JobLocation)
                .Include(job => job.JobLevel)
                .Include(job => job.JobSubLevel)
                .Include(job => job.WorkArea)
                .Include(job => job.JobContract)
                .Include(job => job.JobEducationLevel)
                .Include(job => job.JobExperience)
                .Include(job => job.JobModality)
                .Include(job => job.JobSector)
                .Include(job => job.JobCurrency)
                .Include(job => job.JobLocationModality)
                .Include(job => job.FollowJob)
                .Include(job => job.Postulations)
                .Include(job => job.Job_OtherSector)
                .Include(job => job.Questions)
                .Include(job => job.JobType)
                
                .AsNoTracking()

                .AsSplitQuery()

                .FirstOrDefaultAsync();

            return job;
        }
    }
}
