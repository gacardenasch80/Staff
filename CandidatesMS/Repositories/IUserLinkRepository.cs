using CandidatesMS.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface IUserLinkRepository : IRepository<UserLink>
    {
        Task RemoveByBasicInfoIdAsync(int basicInfoId);
        Task<List<UserLink>> GetByBasicInfoIdAsync(int basicInfoId);
        Task<List<UserLink>> GetByBasicInformationAndCompanyUserId(int basicInformationId, int companyUserId);
    }
}
