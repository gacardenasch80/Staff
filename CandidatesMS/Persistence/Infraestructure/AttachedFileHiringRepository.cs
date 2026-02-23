using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class AttachedFileHiringRepository : Repository<AttachedFileHiring>, IAttachedFileHiringRepository
    {
        public AttachedFileHiringRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<bool> AddByCandidate(AttachedFileHiring attachedFile)
        {
            await _entities.AddAsync(attachedFile);
            int states = await _context.SaveChangesAsync();

            if (states != 0)
                return true;

            return false;
        }

        public async Task<List<AttachedFileHiring>> GetByCandidateIdAndCompanyId(int candidateId, int companyUserId)
        {
            List<AttachedFileHiring> attachedFile = await _entities.Where(x => x.CandidateId == candidateId && (x.CompanyUserId == companyUserId || x.CompanyUserId == 0 || x.IsUploadedByCandidate))
                 .Include(x => x.FileTypeHiring).ToListAsync();

            return attachedFile;
        }

        public async Task<List<AttachedFileHiring>> GetByCandidateIdAndOnlyCompanyId(int candidateId, int companyUserId)
        {
            List<AttachedFileHiring> attachedFile = await _entities.Where(x => x.CandidateId == candidateId && x.CompanyUserId == companyUserId)
                 .Include(x => x.FileTypeHiring).ToListAsync();

            return attachedFile;
        }

        public async Task<List<AttachedFileHiring>> GetByFileTypeAndCompanyIdOrOwnAndCandidateId(int candidateId, int companyUserId, int fileTypeId)
        {
            List<AttachedFileHiring> attachedFiles = await _entities.Where(x => x.CandidateId == candidateId &&
                (x.CompanyUserId == companyUserId || x.CompanyUserId == 0)
                && x.FileTypeHiringId == fileTypeId).ToListAsync();
            return attachedFiles;
        }

        public async Task<AttachedFileHiring> GetByHash(string hash)
        {
            AttachedFileHiring attachedFile = await _entities.Where(x => x.Hash == hash)
                 .Include(x => x.FileTypeHiring).FirstOrDefaultAsync();

            return attachedFile;
        }

        public async Task<List<AttachedFileHiring>> GetUploadByCandidateByCandidateId(int candidateId)
        {
            List<AttachedFileHiring> attachedFile = await _entities.Where(x => x.CandidateId == candidateId && x.CompanyUserId == 0)
                .Include(x => x.FileTypeHiring).ToListAsync();

            return attachedFile;
        }

        public async Task<List<AttachedFileHiring>> GetOwnUploadedCandidateId(int candidateId)
        {
            List<AttachedFileHiring> attachedFiles = await _entities.Where(x => x.CandidateId == candidateId && (x.CompanyUserId == 0 || x.IsUploadedByCandidate))
                 .Include(x => x.FileTypeHiring).ToListAsync();
            return attachedFiles;
        }
    }
}
