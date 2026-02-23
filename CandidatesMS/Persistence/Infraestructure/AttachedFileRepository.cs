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
    public class AttachedFileRepository : Repository<AttachedFile>, IAttachedFileRepository
    {
        public AttachedFileRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<List<AttachedFile>> GetByCandidateId(int candidateId)
        {
            List<AttachedFile> attachedFile = await _entities.Where(x => x.CandidateId == candidateId && (x.EmailMemberUser != "recruitment_owner@exsis.com.co" || x.EmailMemberUser != "recruitmentmaster@exsis.com.co"))
                .Include(x => x.FileType).ToListAsync();
            return attachedFile;
        }

        public async Task<List<AttachedFile>> GetByCandidateIdAndCompanyId(int candidateId, int companyUserId)
        {
            List<AttachedFile> attachedFile = await _entities.Where(x => x.CandidateId == candidateId && 
                ((x.EmailMemberUser != "recruitment_owner@exsis.com.co" && x.EmailMemberUser != "recruitmentmaster@exsis.com.co") &&
                ((x.FileTypeId == 5 || x.FileTypeId == 7 || x.FileTypeId == 6) || x.CompanyUserId == companyUserId)))
                .Include(x => x.FileType).ToListAsync();
            return attachedFile;
        }

        public async Task<List<AttachedFile>> GetByCandidateIdAndOnlyCompanyFiles(int candidateId, int companyUserId)
        {
            List<AttachedFile> attachedFile = await _entities.Where(x => x.CandidateId == candidateId &&
                ((x.EmailMemberUser != "recruitment_owner@exsis.com.co" && x.EmailMemberUser != "recruitmentmaster@exsis.com.co") && x.CompanyUserId == companyUserId))
                .Include(x => x.FileType).ToListAsync();

            return attachedFile;
        }


        public async Task<List<AttachedFile>> GetByCandidateIdMaster(int candidateId)
        {
            List<AttachedFile> attachedFile = await _entities.Where(x => x.CandidateId == candidateId &&
                ((x.EmailMemberUser != "recruitment_owner@exsis.com.co" && x.EmailMemberUser != "recruitmentmaster@exsis.com.co") &&
                ((x.FileTypeId == 5 || x.FileTypeId == 7 || x.FileTypeId == 6) || x.CompanyUserId == 0)))
                .Include(x => x.FileType).ToListAsync();
            return attachedFile;
        }

        public async Task<List<AttachedFile>> GetByFileTypeId(int fileTypeId)
        {
            List<AttachedFile> attachedFiles = await _entities.Where(x => x.FileTypeId == fileTypeId).ToListAsync();
            return attachedFiles;
        }

        public async Task<List<AttachedFile>> GetByFileTypeAndCandidateId(int candidateId, int fileTypeId)
        {
            List<AttachedFile> attachedFiles = await _entities.Where(x => x.CandidateId == candidateId 
                && x.FileTypeId == fileTypeId).ToListAsync();
            return attachedFiles;
        }

        public async Task<List<AttachedFile>> GetByFileTypeAndCompanyIdAndCandidateId(int candidateId, int companyUserId, int fileTypeId)
        {
            List<AttachedFile> attachedFiles = await _entities.Where(x => x.CandidateId == candidateId && x.CompanyUserId == companyUserId
                && x.FileTypeId == fileTypeId).ToListAsync();
            return attachedFiles;
        }

        public async Task<List<AttachedFile>> GetByFileTypeAndCompanyIdOrOwnAndCandidateId(int candidateId, int companyUserId, int fileTypeId)
        {
            List<AttachedFile> attachedFiles = await _entities.Where(x => x.CandidateId == candidateId && 
                (x.CompanyUserId == companyUserId || x.CompanyUserId == 0)
                && x.FileTypeId == fileTypeId).ToListAsync();
            return attachedFiles;
        }

        public async Task<List<AttachedFile>> GetUploadByCandidateByCandidateId(int candidateId)
        {
            List<AttachedFile> attachedFile = await _entities.Where(x => x.CandidateId == candidateId && 
                x.FileTypeId == 7)
                .Include(x => x.FileType)
                .ToListAsync();
            return attachedFile;
        }

        public async Task<List<AttachedFile>> GetAllUploadByCandidate()
        {
            List<AttachedFile> attachedFile = await _entities.Where(x => x.FileTypeId == 7).ToListAsync();
            return attachedFile;
        }

        public async Task<bool> AddByCandidate(AttachedFile attachedFile)
        {
            await _entities.AddAsync(attachedFile);
            int states = await _context.SaveChangesAsync();

            if (states != 0)
                return true;

            return false;
        }

        public async Task<List<AttachedFile>> GetAllFileDataTreatmentForCandidateId(int candidateId)
        {
            List<AttachedFile> attachedFile = await _entities.Where(x => x.CandidateId == candidateId 
                                                && x.EmailMemberUser != "recruitment_owner@exsis.com.co" && x.FileTypeId==9).ToListAsync();
            return attachedFile;
        }
    }
}
