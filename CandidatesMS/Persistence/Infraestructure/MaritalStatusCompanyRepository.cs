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
    public class MaritalStatusCompanyRepository : Repository<MaritalStatusCompany>, IMaritalStatusCompanyRepository
    {
        public    MaritalStatusCompanyRepository(CandidateContext context) : base(context)
        {
        }
        public async Task<MaritalStatusCompany> GetMaritalStatusCompanyById(int maritalStatusId)
        {
            var martialcomany = await _entities.Where(x => x.MaritalStatusId == maritalStatusId).FirstOrDefaultAsync();
            return martialcomany;
        }

        public async  Task<MaritalStatusCompany> GetMaritalStatusCompanyByIdcompany(int MaritalStatusCompanyId)
        {
            MaritalStatusCompany martialcomany = await _entities.Where(x => x.MaritalStatusCompanyId == MaritalStatusCompanyId).FirstOrDefaultAsync();
            return martialcomany;
        }

        public async Task<bool> MartialStatusExist(int martialStatusId)
        {
            try
            {
                var response = await _entities.Where(x => x.MaritalStatusId == martialStatusId).AsNoTracking().ToListAsync();
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

        public async Task<MaritalStatusCompany> GetMaritalStatusById(int maritalStatusCompanyId)
        {
            MaritalStatusCompany listmartials = await _entities.Where(x => x.MaritalStatusCompanyId == maritalStatusCompanyId).AsNoTracking().FirstAsync();
            return listmartials;
        }
    }
}
