using CandidatesMS.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ICVRepository : IRepository<CV>
    {
        Task<CV> GetByCandidateId(int candidateId);
        Task<List<CV>> GetAllByCandidateId(int candidateId);
        Task<List<CV>> GetAllByCandidateIdAndCompanyUserId(int candidateId, int companyUserId);
        Task<List<CV>> GetByCandidateIdAndOnlyCompanyFiles(int candidateId, int companyUserId);

        Task<List<CV>> GetUploadByCandidateByCandidateId(int candidateId);
        Task<List<CV>> GetByCandidateAndFileTypeId(int candidateId, int fileTypeId);
        Task<List<CV>> GetAllByCandidateIdMaster(int candidateId);
        Task<CV> GetByCandidateIdToCandidate(int candidateId);
        Task<CV> ExsistOverViewCvByCandidateId(int candidateId);
        Task<CV> ExsistOverViewCvByCandidateAndCompanyId(int candidateId, int companyUserId);
        Task<CV> ExsistOverViewCvByCandidateIdMaster(int candidateId);
        Task<CV> DeleteOverViewCv(int candidateId);
        Task<CV> DeleteOverViewCvByCvId(int companyUserId, int cvId);
        Task<bool> DeleteAllOverViewCvByCvId(int candidateId, int companyUserId);
    }
}
