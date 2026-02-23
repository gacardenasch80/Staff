using CandidatesMS.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface IDocumentCheckRepository: IRepository<DocumentCheck>
    {
        Task<List<DocumentCheck>> GetAllByCandidateId(int candidateId, int companyUserId);
        Task<List<DocumentCheck>> GetByCandidateIdAndLimitGroups(int candidateId, int companyUserId, int start, int end);

        Task<List<DocumentCheck>> GetAllByCandidateIdAndGroupId(int candidateId, int groupId, int companyUserId);

        Task<List<DocumentCheck>> GetAllByCandidateIdAndOrderId(int candidateId, int orderId, int companyUserId);
        Task<DocumentCheck> GetByCandidateIdAndOrderId(int candidateId, int orderId, int companyUserId);
        Task<bool> ExistByOrderId(int orderId, int companyUserId);
    }
}
