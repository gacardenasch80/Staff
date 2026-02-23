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
    public class PhoneRepository : Repository<Phone>, IPhoneRepository
    {
        public PhoneRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<List<Phone>> GetByBasicInformationId(int basicInformationId)
        {
            var phones = await _entities.Where(x => x.BasicInformationId == basicInformationId).ToListAsync();

            return phones;
        }

        public async Task<List<Phone>> GetByBasicInformationAndCompanyUserId(int basicInformationId, int companyUserId)
        {
            var phones = await _entities.Where(x => x.BasicInformationId == basicInformationId && x.CompanyUserId == companyUserId).ToListAsync();

            return phones;
        }

        public async Task RemoveByBasicInfoIdAsync(int basicInfoId)
        {
            var emails = await _entities.Where(x => x.BasicInformationId == basicInfoId).ToListAsync();
            _entities.RemoveRange(emails);
            _context.SaveChanges();
        }
    }
}