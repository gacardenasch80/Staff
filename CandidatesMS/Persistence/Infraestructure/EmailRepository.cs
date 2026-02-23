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
    public class EmailRepository : Repository<Email>, IEmailRepository
    {
        public EmailRepository(CandidateContext context) : base(context)
        {
        }

        public void RemoveById(int emailId)
        {
            var email = _entities.Where(x => x.EmailId == emailId).FirstOrDefault();
            _entities.Remove(email);
            _context.SaveChanges();
        }

        public async Task RemoveByBasicInfoIdAsync(int basicInfoId)
        {
            var emails = await _entities.Where(x => x.BasicInformationId == basicInfoId).ToListAsync();
            _entities.RemoveRange(emails);
            _context.SaveChanges();
        }

        public async Task<List<Email>> GetByBasicInfoIdAsync(int basicInfoId)
        {
            var emails = await _entities.Where(x => x.BasicInformationId == basicInfoId).ToListAsync();
            return emails;
        }

        public async Task<List<Email>> GetByBasicInformationAndCompanyUserId(int basicInformationId, int companyUserId)
        {
            var emails = await _entities.Where(x => x.BasicInformationId == basicInformationId && x.CompanyUserId == companyUserId).ToListAsync();

            return emails;
        }

        public async Task<List<Email>> GetEmailsFromCandidateOrCompany(int basicInformationId, int companyUserId)
        {
            var emails =
                await _entities.Where(x => x.BasicInformationId == basicInformationId && (x.CompanyUserId == 0 || x.CompanyUserId == companyUserId))
                .ToListAsync();

            return emails;
        }
    }
}
