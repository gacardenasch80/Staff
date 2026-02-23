using CandidatesMS.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface IEmailRepository : IRepository<Email>
    {
        void RemoveById(int basicInformationId);
        Task RemoveByBasicInfoIdAsync(int basicInfoId);
        Task<List<Email>> GetByBasicInfoIdAsync(int basicInfoId);
        Task<List<Email>> GetByBasicInformationAndCompanyUserId(int basicInformationId, int companyUserId);
        Task<List<Email>> GetEmailsFromCandidateOrCompany(int basicInformationId, int companyUserId);
    }
}
