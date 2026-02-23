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
    public class SocialNetworkRepository : Repository<SocialNetwork>, ISocialNetworkRepository
    {
        public SocialNetworkRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<List<SocialNetwork>> GetAllOrderedById()
        {
            List<SocialNetwork> socialNetworks = await _entities.OrderBy(x => x.SocialNetworkId).ToListAsync();
            return socialNetworks;
        }

        public async Task<List<SocialNetwork>> GetByBasicInfoIdAsync(int basicInfoId)
        {
            var socialNetworks = await _entities.Where(x => x.BasicInformationId == basicInfoId).ToListAsync();
            return socialNetworks;
        }

        public async Task RemoveByBasicInfoIdAsync(int basicInfoId)
        {
            var emails = await _entities.Where(x => x.BasicInformationId == basicInfoId).ToListAsync();
            _entities.RemoveRange(emails);
            _context.SaveChanges();
        }

        public async Task<List<SocialNetwork>> GetByBasicInformationAndCompanyUserId(int basicInformationId, int companyUserId)
        {
            var socialNetworks = await _entities.Where(x => x.BasicInformationId == basicInformationId && x.CompanyUserId == companyUserId).ToListAsync();

            return socialNetworks;
        }
    }
}