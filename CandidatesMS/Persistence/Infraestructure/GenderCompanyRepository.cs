using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class GenderCompanyRepository : Repository<GenderCompany>, IGenderCompanyRepository
    {
        public  GenderCompanyRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<bool> GenderCompanyExist(int genderId)
        {
            try
            {
                var response = await _entities.Where(x => x.GenderId == genderId).AsNoTracking().ToListAsync();
                if (response.Count == 0)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async  Task<GenderCompany> GetGenderCompanyById(int genderId)
        {
            var gendercomany = await _entities.Where(x => x.GenderId == genderId).FirstOrDefaultAsync();
            return gendercomany;
        }

        public async Task<GenderCompany> GetGenderCompanyByIdcompany(int genderCompanyId)
        {
            var gendercomany = await _entities.Where(x => x.GenderCompanyId == genderCompanyId).AsNoTracking().FirstOrDefaultAsync();

            return gendercomany;
        }
    }
}
