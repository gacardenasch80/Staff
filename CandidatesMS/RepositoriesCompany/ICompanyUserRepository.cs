using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.RepositoriesCompany
{
    public interface ICompanyUserRepository : IRepository<CompanyUser>
    {
        Task<bool> AddCompanyUser(CompanyUser company);
        Task<CompanyUser> GetByEmail(string email);
        Task<List<CompanyUser>> GetCompanyUsersByString(string search, int page, int pageSize);
        Task<List<CompanyUser>> GetAllCompaniesWithFormatAndPagination(int page, int pageSize);
    }
}
