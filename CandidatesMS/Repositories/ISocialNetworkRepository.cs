using CandidatesMS.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ISocialNetworkRepository : IRepository<SocialNetwork>
    {
        Task<List<SocialNetwork>> GetAllOrderedById();
        Task<List<SocialNetwork>> GetByBasicInfoIdAsync(int basicInfoId);
        Task<List<SocialNetwork>> GetByBasicInformationAndCompanyUserId(int basicInformationId, int companyUserId);
        Task RemoveByBasicInfoIdAsync(int basicInfoId);
    }
}