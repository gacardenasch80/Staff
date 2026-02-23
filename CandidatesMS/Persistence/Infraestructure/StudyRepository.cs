using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class StudyRepository : Repository<Study>, IStudyRepository
    {
        public StudyRepository(CandidateContext context) : base(context)
        {
        }

        public CandidateContext context
        {
            get { return _context as CandidateContext; }
        }

        public async Task<List<Study>> GetByCandidateIdAdminView(int candidateId, int companyUserId = 0)
        {
            List<Study> study = await _entities.Where(x => x.CandidateId == candidateId && x.CompanyUserId == companyUserId)
                .Include(x => x.StudyArea).Include(x => x.StudyType).Include(x => x.Title)
                .Include(x => x.StudyState)
                .Include(x => x.CertificationState).Include(x => x.StudyCertificate).OrderByDescending(x => x.StudyId)
                .ToListAsync();
            
            return study;      
        }

        public async Task<List<Study>> GetToOverview(int candidateId, int companyUserId)
        {
            List<Study> study = await _entities.Where(x => x.CandidateId == candidateId && (x.IsFromCandidate == true || (x.IsFromCandidate == false && x.CompanyUserId == companyUserId))).ToListAsync();

            return study;
        }

        public async Task<List<Study>> GetByCandidateIdAdminViewMaster(int candidateId)
        {
            List<Study> study = await _entities.Where(x => x.CandidateId == candidateId && x.IsFromCandidate==true)
                .Include(x => x.StudyArea).Include(x => x.StudyType).Include(x => x.Title)
                .Include(x => x.CertificationState).Include(x => x.StudyCertificate).OrderByDescending(x => x.StudyId)
                .ToListAsync();

            return study;
        }

        public async Task<List<Study>> GetByCandidateId(int candidateId)
        {
            List<Study> study = await _entities.Where(x => x.CandidateId == candidateId && x.IsFromCandidate)
                .Include(x => x.StudyArea).Include(x => x.StudyType).Include(x => x.Title)
                .Include(x => x.StudyState)
                .Include(x => x.CertificationState).Include(x => x.StudyCertificate).OrderByDescending(x => x.StudyId)
                .ToListAsync();

            return study;
        }

        public new async Task<Study> Add(Study study)
        {
            await _entities.AddAsync(study);
            int states = await _context.SaveChangesAsync();

            if (states != 0)
                return study;

            return null;
        }

        public new async Task<Study> GetById(int id)
        {
            var study = await _entities.Where(x => x.StudyId == id)
                .Include(x => x.StudyArea).Include(x => x.StudyType).Include(x => x.Title)
                .Include(x => x.CertificationState).Include(x => x.StudyCertificate)
                .FirstOrDefaultAsync();
            return study;            
        }

        public async Task<bool> StudyExist(int studyId, bool _isFromCandidate)
        {
            try
            {
                var response = await _entities.Where(x => x.StudyId == studyId && x.IsFromCandidate == _isFromCandidate).ToListAsync();
                if (response.Count == 0)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
