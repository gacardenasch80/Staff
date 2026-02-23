using CandidatesMS.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface  IGenderCompanyRepository: IRepository<GenderCompany>
    {
        Task<GenderCompany> GetGenderCompanyById(int genderId);
        Task<GenderCompany> GetGenderCompanyByIdcompany(int genderCompanyId);
        public Task<bool> GenderCompanyExist(int genderId);
    }
}
