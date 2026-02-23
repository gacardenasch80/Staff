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
    public class CVRepository : Repository<CV>, ICVRepository
    {
        public CVRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<CV> GetByCandidateId(int candidateId)
        {
            CV cv = await _entities.Where(x => x.CandidateId == candidateId).FirstOrDefaultAsync();
            return cv;
        }

        public async Task<List<CV>> GetAllByCandidateId(int candidateId)
        {
            List<CV> cv = await _entities.Where(x => x.CandidateId == candidateId && x.EmailMemberUser != "recruitment_owner@exsis.com.co" ).Include(x => x.FileType).ToListAsync();
            return cv;
        }

        public async Task<List<CV>> GetAllByCandidateIdAndCompanyUserId(int candidateId, int companyUserId)
        {
            List<CV> cv = await _entities.Where(x => x.CandidateId == candidateId &&
                ((x.EmailMemberUser != "recruitment_owner@exsis.com.co" && x.EmailMemberUser != "recruitmentmaster@exsis.com.co") &&
                ((x.FileTypeId == 5 || x.FileTypeId == 6 || x.FileTypeId == 8) || x.CompanyUserId == companyUserId)))
                .Include(x => x.FileType).ToListAsync();
            return cv;
        }

        public async Task<List<CV>> GetByCandidateIdAndOnlyCompanyFiles(int candidateId, int companyUserId)
        {
            List<CV> cv = await _entities.Where(x => x.CandidateId == candidateId &&
                ((x.EmailMemberUser != "recruitment_owner@exsis.com.co" && x.EmailMemberUser != "recruitmentmaster@exsis.com.co") && x.CompanyUserId == companyUserId))
                .Include(x => x.FileType).ToListAsync();
            return cv;
        }

        public async Task<List<CV>> GetByCandidateAndFileTypeId(int candidateId, int fileTypeId)
        {
            return await _entities.Where(x => x.CandidateId == candidateId && x.FileTypeId == fileTypeId).ToListAsync();
        }

        public async Task<List<CV>> GetAllByCandidateIdMaster(int candidateId)
        {
            List<CV> cv = await _entities.Where(x => x.CandidateId == candidateId &&
                (
                ((x.FileTypeId == 5 || x.FileTypeId == 7 || x.FileTypeId == 6) || (x.CompanyUserId == 0 || x.CompanyUserId == 1))))
                .Include(x => x.FileType).ToListAsync();
            return cv;
        }

        public async Task<CV> GetByCandidateIdToCandidate(int candidateId)
        {
            CV cv = await _entities.Where(x => x.CandidateId == candidateId && x.FileTypeId == 5).FirstOrDefaultAsync();
            return cv;
        }

        public async Task<CV> ExsistOverViewCvByCandidateId(int candidateId)
        {
            CV cv = await _entities.Where(x => x.CandidateId == candidateId && x.IsFromCandidate == true && !x.CvIdentifierLink.ToLower().Contains(".html"))
                .OrderByDescending(x => x.UploadDate)
                .FirstOrDefaultAsync();
            if (cv != null)
                return cv;
            return null;
        }

        public async Task<CV> ExsistOverViewCvByCandidateAndCompanyId(int candidateId, int companyUserId)
        {
            CV cv = await _entities.Where(x => x.CandidateId == candidateId && x.CompanyUserId == companyUserId && x.IsFromCandidate == false && !x.CvIdentifierLink.ToLower().Contains(".html"))
                .OrderByDescending(x => x.UploadDate)
                .FirstOrDefaultAsync();
            if (cv != null)
                return cv;
            return null;
        }

        public async Task<CV> ExsistOverViewCvByCandidateIdMaster(int candidateId)
        {
            CV cv = await _entities.Where(x => x.CandidateId == candidateId && x.OverViewCv == true && x.EmailMemberUser== "recruitment_owner@exsis.com.co").FirstOrDefaultAsync();
            if (cv != null)
                return cv;
            return null;
        }

        public async Task<CV> DeleteOverViewCv(int candidateId)
        {
            CV cv = await _entities.Where(x => x.CandidateId == candidateId && x.OverViewCv == true).FirstOrDefaultAsync();
            if(cv != null)
            {
                cv.OverViewCv = false;
                _context.SaveChanges();
            }
            return cv;
        }

        public async Task<CV> DeleteOverViewCvByCvId(int companyUserId, int cvId)
        {
            CV cv = await _entities.Where(x => x.CompanyUserId == companyUserId && x.CVId == cvId).FirstOrDefaultAsync();

            if (cv != null)
            {
                _entities.Remove(cv);

                _context.SaveChanges();
            }
            return cv;
        }

        public async Task<bool> DeleteAllOverViewCvByCvId(int candidateId, int companyUserId)
        {
            List<CV> cvs = await _entities.Where(x => x.CompanyUserId == companyUserId && x.CandidateId == candidateId && x.IsFromCandidate == false && !x.CvIdentifierLink.ToLower().Contains(".html")).ToListAsync();

            if (cvs != null)
            {
                _entities.RemoveRange(cvs);

                _context.SaveChanges();
            }

            return true;
        }

        public async Task<List<CV>> GetUploadByCandidateByCandidateId(int candidateId)
        {
            List<CV> Cv = await _entities.Where(x => x.CandidateId == candidateId &&
                x.FileTypeId == 5)
                .Include(x => x.FileType)
                .ToListAsync();
            return Cv;
        }
    }
}
