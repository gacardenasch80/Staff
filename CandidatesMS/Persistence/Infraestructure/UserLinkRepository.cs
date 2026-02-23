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
    public class UserLinkRepository : Repository<UserLink>, IUserLinkRepository
    {
        public UserLinkRepository(CandidateContext context) : base(context)
        {

        }

        public async Task<List<UserLink>> GetByBasicInfoIdAsync(int basicInfoId)
        {
            var userLinks = await _entities.Where(x => x.BasicInformationId == basicInfoId).ToListAsync();
            return userLinks;
        }

        public async Task RemoveByBasicInfoIdAsync(int basicInfoId)
        {
            var userLinks = await _entities.Where(x => x.BasicInformationId == basicInfoId).ToListAsync();
            _entities.RemoveRange(userLinks);
            _context.SaveChanges();
        }

        public async Task<List<UserLink>> GetByBasicInformationAndCompanyUserId(int basicInformationId, int companyUserId)
        {
            var userLinks = await _entities.Where(x => x.BasicInformationId == basicInformationId && x.CompanyUserId == companyUserId).ToListAsync();

            return userLinks;
        }
    }
}
