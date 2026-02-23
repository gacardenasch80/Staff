using CandidatesMS.Repositories;
using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class WorkExperienceRepository : Repository<WorkExperience>, IWorkExperienceRepository
    {
        public WorkExperienceRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<WorkExperience> GetByGuid(string guid)
        {
            WorkExperience workExperience = await _entities.Where(x => x.WorkExperienceGuid == guid).FirstOrDefaultAsync();

            return workExperience;
        }

        public async Task<List<WorkExperience>> GetByCandidateId(int candidateId)
        {
            List<WorkExperience> workExperiences = await _entities.Where(x => x.CandidateId == candidateId && !x.AdminView).Include(x => x.Industry).ToListAsync();

            return workExperiences;
        }

        public async Task<List<WorkExperience>> GetAdminViewByCandidateId(int candidateId, int companyUserId)
        {
            List<WorkExperience> workExperiences = await _entities.Where(x => x.CandidateId == candidateId && x.CompanyUserId == companyUserId).Include(x => x.Industry).ToListAsync();

            return workExperiences;
        }

        public async Task<List<WorkExperience>> GetAdminViewByCandidateIdMaster(int candidateId)
        {
            List<WorkExperience> workExperiences = await _entities.Where(x => x.CandidateId == candidateId && x.AdminView == false).Include(x => x.Industry).ToListAsync();

            return workExperiences;
        }

        public new async Task<WorkExperience> GetById(int id)
        {
            var workExperience = await _entities.Where(x => x.WorkExperienceId == id)
                .Include(x => x.Industry).FirstOrDefaultAsync();
            return workExperience;
        }

        public async Task<List<WorkExperience>> GetToOverview(int candidateId, int companyUserId)
        {
            List<WorkExperience> workExperiences = await _entities.Where(x => x.CandidateId == candidateId && (x.AdminView == false || (x.AdminView == true && x.CompanyUserId == companyUserId))).ToListAsync();

            return workExperiences;
        }

        public CandidateContext context
        {
            get { return _context as CandidateContext; }
        }
    }
}
