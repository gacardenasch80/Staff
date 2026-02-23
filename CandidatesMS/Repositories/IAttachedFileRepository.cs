using CandidatesMS.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface IAttachedFileRepository : IRepository<AttachedFile>
    {
        Task<List<AttachedFile>> GetByCandidateId(int candidateId);
        Task<List<AttachedFile>> GetByCandidateIdMaster(int candidateId);
        Task<List<AttachedFile>> GetByCandidateIdAndCompanyId(int candidateId, int companyUserId);
        Task<List<AttachedFile>> GetByCandidateIdAndOnlyCompanyFiles(int candidateId, int companyUserId);
        Task<List<AttachedFile>> GetByFileTypeId(int fileTypeId);
        Task<List<AttachedFile>> GetByFileTypeAndCandidateId(int candidateId, int fileTypeId);
        Task<List<AttachedFile>> GetByFileTypeAndCompanyIdAndCandidateId(int candidateId, int companyUserId, int fileTypeId);
        Task<List<AttachedFile>> GetByFileTypeAndCompanyIdOrOwnAndCandidateId(int candidateId, int companyUserId, int fileTypeId);
        Task<List<AttachedFile>> GetAllUploadByCandidate();
        Task<bool> AddByCandidate(AttachedFile attachedFile);
        Task<List<AttachedFile>> GetUploadByCandidateByCandidateId(int candidateId);
        Task<List<AttachedFile>> GetAllFileDataTreatmentForCandidateId(int candidateId);
    }
}
