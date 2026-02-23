using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ICVHiringRepository:IRepository<CVHiring>
    {
        Task<CVHiring> DeleteOverViewCv(int candidateId);
        Task<List<CVHiring>> GetAllByCandidateIdAndCompanyUserId(int candidateId, int companyUserId);
        Task<List<CVHiring>> GetAllByCandidateIdAndOnlyCompanyUserId(int candidateId, int companyUserId);
        Task<List<CVHiring>> GetUploadByCandidateByCandidateId(int candidateId);
    }
}
