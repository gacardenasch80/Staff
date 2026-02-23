using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface IAttachedFileHiringRepository : IRepository<AttachedFileHiring>
    {
        Task<bool> AddByCandidate(AttachedFileHiring attachedFile);
        Task<List<AttachedFileHiring>> GetByCandidateIdAndCompanyId(int candidateId, int companyUserId);
        Task<List<AttachedFileHiring>> GetByCandidateIdAndOnlyCompanyId(int candidateId, int companyUserId);
        Task<List<AttachedFileHiring>> GetByFileTypeAndCompanyIdOrOwnAndCandidateId(int candidateId, int companyUserId, int fileTypeId);
        Task<AttachedFileHiring> GetByHash(string hash);
        Task<List<AttachedFileHiring>> GetUploadByCandidateByCandidateId(int candidateId);
        Task<List<AttachedFileHiring>> GetOwnUploadedCandidateId(int candidateId);
    }
}
