using CandidatesMS.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ICompanyDescriptionRepository : IRepository<CompanyDescription>
    {
        Task<bool> CompanyDescriptionExists(int candidateId);
        Task<bool> CompanyDescriptionExistsByCandidateAndCompanyUserId(int candidateId, int companyUserId);
        Task<CompanyDescription> GetByCandidateId(int candidateId);
        Task<CompanyDescription> GetByCandidateAndCompanyId(int candidateId, int companyUserId);
        Task<List<CompanyDescription>> GetAllByCandidateId(int candidateId, int companyUserId);
    }
}