using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class DocumentCheckRepository : Repository<DocumentCheck>, IDocumentCheckRepository
    {
        public DocumentCheckRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<List<DocumentCheck>> GetAllByCandidateId(int candidateId, int companyUserId)
        {
            List<DocumentCheck> documentsChecks = await _entities.Where(x => x.CandidateId == candidateId && x.CompanyUserId == companyUserId).OrderBy(x => x.OrderId).ToListAsync();

            return documentsChecks;
        }

        public async Task<List<DocumentCheck>> GetByCandidateIdAndLimitGroups(int candidateId, int companyUserId, int start, int end)
        {
            List<DocumentCheck> documentsChecks = await _entities.Where(x => x.CandidateId == candidateId && x.CompanyUserId == companyUserId && 
            x.DocumentCheckGroupId >= start && x.DocumentCheckGroupId <= end).OrderBy(x => x.OrderId).ToListAsync();

            return documentsChecks;
        }

        public async Task<List<DocumentCheck>> GetAllByCandidateIdAndGroupId(int candidateId, int groupId, int companyUserId)
        {
            List<DocumentCheck> documentsChecks = await _entities.Where(x => x.CandidateId == candidateId && x.DocumentCheckGroupId == groupId && x.CompanyUserId == companyUserId).ToListAsync();

            return documentsChecks;
        }

        public async Task<List<DocumentCheck>> GetAllByCandidateIdAndOrderId(int candidateId, int orderId, int companyUserId)
        {
            List<DocumentCheck> documentsChecks = await _entities.Where(x => x.CandidateId == candidateId && x.OrderId == orderId && x.CompanyUserId == companyUserId).ToListAsync();

            return documentsChecks;
        }

        public async Task<DocumentCheck> GetByCandidateIdAndOrderId(int candidateId, int orderId, int companyUserId)
        {
            DocumentCheck documentsCheck = await _entities.Where(x => x.CandidateId == candidateId && x.OrderId == orderId && x.CompanyUserId == companyUserId).FirstOrDefaultAsync();

            return documentsCheck;
        }

        public async Task<bool> ExistByOrderId(int orderId, int companyUserId)
        {
            var response = await _entities.Where(x => x.OrderId == orderId && x.CompanyUserId == companyUserId).ToListAsync();
            if (response.Count == 0)
            {
                return false;
            }
            return true;
        }
    }
}
