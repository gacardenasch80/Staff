using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Persistence.Infraestructure;
using CandidatesMS.RepositoriesCompany;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.InfrastructureCompany
{
    public class PostulationRepository
    (
        CompanyContext context
    )
    :
    RepositoryCompany<Postulation>(context), IPostulationRepository
    {
        public async Task<List<Postulation>> GetByPublishedAndClosedByCandidateIds(List<int> candidateIds, int companyUserId)
        {
            try
            {
                List<Postulation> postulations =
                await _entities
                .Where
                (
                    postulation
                    =>
                    candidateIds != null
                    &&
                    candidateIds.Count > 0
                    &&
                    postulation != null
                    &&
                    postulation.Job != null
                    &&
                    (
                        postulation.Job.JobPostingStatusId == 2
                        ||
                        postulation.Job.JobPostingStatusId == 3
                    )
                    &&
                    postulation.Job.CompanyUserId == companyUserId
                    &&
                    candidateIds.Any(candidateId => candidateId == postulation.CandidateId)
                )
                .Include(postulation => postulation.Job)
                .AsNoTracking()
                .ToListAsync();

                return postulations;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<List<Postulation>> GetAllByCandidateAndCompanyUserIdOnlyAvailable(int candidateId, int companyUserId, int isMigrated, bool isFromCompanyAndLogin)
        {
            List<Postulation> postulations = [];

            if (isMigrated == 0 || isFromCompanyAndLogin)
            {
                postulations =
                    await _entities
                .Where
                (
                    postulation
                    =>
                    postulation.CandidateId == candidateId
                    &&
                    postulation.CompanyUserId == companyUserId
                    &&
                    (
                        postulation.Job.JobPostingStatusId == 2
                        ||
                        postulation.Job.JobPostingStatusId == 3
                        ||
                        postulation.Job.JobPostingStatusId == 4
                        ||
                        postulation.Job.JobPostingStatusId == 5
                    )
                )
                .Include(postulation => postulation.Job)
                .Include(postulation => postulation.Job.JobLocation)
                .Include(postulation => postulation.PostulationStage).ThenInclude(postulationStage => postulationStage.PostulationState)
                .Include(postulation => postulation.Job.JobExperience)
                //.Include(postulation => postulation.Job.Job_JobProfession)
                .Include(postulation => postulation.Job.JobPostingStatus)
                .Include(postulation => postulation.BlockReason)
                .Include(postulation => postulation.Job).ThenInclude(job => job.Job_JobLanguage).ThenInclude(job_jobLanguage => job_jobLanguage.JobLanguageLevel)
                .Include(postulation => postulation.Job).ThenInclude(job => job.Job_JobLanguage).ThenInclude(job_jobLanguage => job_jobLanguage.JobLanguage)
                .Include(postulation => postulation.Job).ThenInclude(job => job.Job_OtherLanguage).ThenInclude(job_toherLanguage => job_toherLanguage.JobLanguageLevel)
                //.Include(postulation => postulation.Job).ThenInclude(job => job.Job_JobProfession).ThenInclude(job_jobProfession => job_jobProfession.JobProfession)
                //.Include(postulation => postulation.Job).ThenInclude(job => job.Job_OtherProfession)
                .Include(postulation => postulation.Job).ThenInclude(job => job.JobLevel)
                .Include(postulation => postulation.Job).ThenInclude(job => job.JobSubLevel)
                .Include(postulation => postulation.Job).ThenInclude(job => job.WorkArea)
                .Include(postulation => postulation.Job).ThenInclude(job => job.JobEducationLevel)
                .Include(postulation => postulation.Job).ThenInclude(job => job.JobExperience)
                .Include(postulation => postulation.Job).ThenInclude(job => job.JobModality)
                .Include(postulation => postulation.Job).ThenInclude(job => job.JobSector)
                .Include(postulation => postulation.Job).ThenInclude(job => job.InternalCode)
                .Include(postulation => postulation.Job).ThenInclude(job => job.JobCurrency)
                .Include(postulation => postulation.Job).ThenInclude(job => job.JobLocationModality)
                .Include(postulation => postulation.Job.JobContract)
                .Include(postulation => postulation.Job.Job_OtherLanguage)
                .ToListAsync();
            }
            else
            {
                postulations =
                    await _entities
                .Where
                (
                    portulation => portulation.CandidateId == candidateId
                    &&
                    portulation.CompanyUserId == companyUserId
                )
                .Include(postulation => postulation.Job)
                .Include(postulation => postulation.Job.JobLocation)
                .Include(postulation => postulation.PostulationStage).ThenInclude(postulationStage => postulationStage.PostulationState)
                .Include(postulation => postulation.Job.JobExperience)
                //.Include(postulation => postulation.Job.Job_JobProfession)
                .Include(postulation => postulation.Job.JobPostingStatus)
                .Include(postulation => postulation.BlockReason)
                .Include(postulation => postulation.Job).ThenInclude(x => x.Job_JobLanguage).ThenInclude(job_jobLanguage => job_jobLanguage.JobLanguageLevel)
                .Include(postulation => postulation.Job).ThenInclude(x => x.Job_JobLanguage).ThenInclude(job_jobLanguage => job_jobLanguage.JobLanguage)
                .Include(postulation => postulation.Job).ThenInclude(x => x.Job_OtherLanguage).ThenInclude(job_otherLanguage => job_otherLanguage.JobLanguageLevel)
                //.Include(postulation => postulation.Job).ThenInclude(x => x.Job_JobProfession).ThenInclude(job_jobProfession => job_jobProfession.JobProfession)
                //.Include(postulation => postulation.Job).ThenInclude(job => job.Job_OtherProfession)
                .Include(postulation => postulation.Job).ThenInclude(job => job.JobLevel)
                .Include(postulation => postulation.Job).ThenInclude(job => job.JobSubLevel)
                .Include(postulation => postulation.Job).ThenInclude(job => job.WorkArea)
                .Include(postulation => postulation.Job).ThenInclude(job => job.JobEducationLevel)
                .Include(postulation => postulation.Job).ThenInclude(job => job.JobExperience)
                .Include(postulation => postulation.Job).ThenInclude(job => job.JobModality)
                .Include(postulation => postulation.Job).ThenInclude(job => job.JobSector)
                .Include(postulation => postulation.Job).ThenInclude(job => job.InternalCode)
                .Include(postulation => postulation.Job).ThenInclude(job => job.JobCurrency)
                .Include(postulation => postulation.Job).ThenInclude(job => job.JobLocationModality)
                .Include(postulation => postulation.Job.JobContract)
                .Include(postulation => postulation.Job.Job_OtherLanguage)
                .ToListAsync();
            }

            return postulations;
        }
    }
}
