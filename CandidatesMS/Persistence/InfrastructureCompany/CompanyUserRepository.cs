using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Persistence.Infraestructure;
using CandidatesMS.RepositoriesCompany;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.InfrastructureCompany
{
    public class CompanyUserRepository : RepositoryCompany<CompanyUser>, ICompanyUserRepository
    {
        //private readonly CompanyContext _context;
        public CompanyUserRepository(CompanyContext context) : base(context)
        {
            //_context = context;
        }

        public async Task<bool> AddCompanyUser(CompanyUser company)
        {
            await _context.AddAsync(company);
            int states = await _context.SaveChangesAsync();

            if (states != 0)
                return true;

            return false;
        }

        public async Task<CompanyUser> GetByEmail(string email)
        {
            var company = await _context.CompanyUser.Where(x => x.Email == email).FirstOrDefaultAsync();
            return company;
        }

        public async Task<List<CompanyUser>> GetAllCompaniesWithFormatAndPagination(int page, int pageSize)
        {
            List<CompanyUser> companies = await _entities.Where(x => x.Email != "recruitment_owner@exsis.com.co").AsNoTracking()
                .Include(x => x.MemberUsers)
                .ThenInclude(x => x.Role).ToListAsync();

            foreach (CompanyUser company in companies)
            {
                List<MemberUser> auxMemberUsers = company.MemberUsers.ToList();

                foreach (MemberUser memberUser in company.MemberUsers)
                {
                    if (memberUser.Role.Name != "SuperAdministrador")
                    {
                        auxMemberUsers.Remove(memberUser);
                    }
                }

                company.MemberUsers = auxMemberUsers;
            }

            List<CompanyUser> pageCompanies = new List<CompanyUser>();

            if (pageSize != 0)
                pageCompanies = companies.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            else
                pageCompanies = companies;

            return pageCompanies;
        }

        public async Task<List<CompanyUser>> GetCompanyUsersByString(string search, int page, int pageSize)
        {
            search = search.ToLower().TrimStart().TrimEnd();

            List<CompanyUser> companyUsers = new List<CompanyUser>();

            if (pageSize != 0)
            {
                companyUsers = await _entities.Include(x => x.MemberUsers).ThenInclude(y => y.Role)
                    .Where(x => x.Name.ToLower().Contains(search)
                    || (x.MemberUsers.Any(x => x.Role.Name == "SuperAdministrador" && (x.Name + x.Surname).ToLower().Contains(search))))
                .OrderByDescending(x => x.CompanyUserId)
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .AsNoTracking()
                    .ToListAsync();
            }
            else
            {
                companyUsers = await _entities.Include(x => x.MemberUsers).ThenInclude(y => y.Role)
                    .Where(x => x.Name.ToLower().Contains(search)
                    || (x.MemberUsers.Any(x => x.Role.Name == "SuperAdministrador" && (x.Name + x.Surname).ToLower().Contains(search))))
                    .OrderByDescending(x => x.CompanyUserId)
                    .AsNoTracking()
                    .ToListAsync();
            }

            return companyUsers;
        }
    }
}
