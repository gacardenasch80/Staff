using CandidatesMS.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface IPhoneRepository : IRepository<Phone>
    {
        Task<List<Phone>> GetByBasicInformationId(int basicInformationId);
        Task<List<Phone>> GetByBasicInformationAndCompanyUserId(int basicInformationId, int companyUserId);
        Task RemoveByBasicInfoIdAsync(int basicInfoId);
    }
}