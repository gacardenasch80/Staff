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
    public class CompanyDescriptionRepository : Repository<CompanyDescription>, ICompanyDescriptionRepository
    {
        public CompanyDescriptionRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<bool> CompanyDescriptionExists(int candidateId)
        {
            CompanyDescription companyDescription = await _entities.Where(x => x.CandidateId == candidateId).FirstOrDefaultAsync();

            if (companyDescription != null)
                return true;

            return false;
        }

        public async Task<bool> CompanyDescriptionExistsByCandidateAndCompanyUserId(int candidateId, int companyUserId)
        {
            CompanyDescription companyDescription = await _entities.Where(x => x.CandidateId == candidateId && x.CompanyUserId == companyUserId).FirstOrDefaultAsync();

            if (companyDescription != null)
                return true;

            return false;
        }

        public async Task<CompanyDescription> GetByCandidateId(int candidateId)
        {
            CompanyDescription companyDescription = await _entities.Where(x => x.CandidateId == candidateId).FirstOrDefaultAsync();

            return companyDescription;
        }

        public async Task<CompanyDescription> GetByCandidateAndCompanyId(int candidateId, int companyUserId)
        {
            CompanyDescription companyDescription = await _entities.Where(x => x.CandidateId == candidateId && x.CompanyUserId == companyUserId).FirstOrDefaultAsync();

            return companyDescription;
        }

        public async Task<List<CompanyDescription>> GetAllByCandidateId(int candidateId, int companyUserId)
        {
            List<CompanyDescription> companyDescriptions = await _entities.Where(x => x.CandidateId == candidateId && x.CompanyUserId == companyUserId).ToListAsync();

            return companyDescriptions;
        }

        public async Task<CompanyDescription> DeleteByCompanyUserId(int candidateId)
        {
            CompanyDescription companyDescription = await _entities.Where(x => x.CandidateId == candidateId).FirstOrDefaultAsync();

            return companyDescription;
        }
    }
}