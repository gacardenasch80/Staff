using CandidatesMS.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface IMaritalStatusCompanyRepository : IRepository<MaritalStatusCompany>
    {
        Task<MaritalStatusCompany> GetMaritalStatusCompanyById(int maritalStatusId);
        Task<MaritalStatusCompany> GetMaritalStatusCompanyByIdcompany(int maritalStatusCompanyId);
        public Task<bool> MartialStatusExist(int maritalStatusId);
        Task<MaritalStatusCompany> GetMaritalStatusById(int maritalStatusCompanyId);
    }
}
