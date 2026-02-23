using CandidatesMS.Repositories;
using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CandidatesMS.Persistence.Infraestructure;
using System.Collections.Generic;

namespace CandidatesMS.Infraestructure
{
    public class BasicInformationRepository : Repository<BasicInformation>, IBasicInformationRepository
    {
        public BasicInformationRepository(CandidateContext context) : base(context)
        {
        }

        public new async Task<BasicInformation> GetById(int id)
        {
            BasicInformation basicInformation = await _entities.Where(x => x.BasicInformationId == id).Include(x => x.Currency).AsNoTracking().FirstOrDefaultAsync();

            return basicInformation;
        }

        public async Task<List<BasicInformation>> GetAllWithEmailsAndPhones()
        {
            List<BasicInformation> basicInformations = await _entities.Include(x => x.Emails).Include(x => x.Phones).AsNoTracking().ToListAsync();

            if (basicInformations != null && basicInformations.Count > 0)
            {
                foreach (BasicInformation basicInformation in basicInformations)
                {
                    basicInformation.Candidate = null;
                }
            }

            return basicInformations;
        }

        public async Task<BasicInformation> GetByGuid(string Guid)
        {
            BasicInformation basicInformation = await _entities.Where(x => x.BasicInformationGuid == Guid).Include(x => x.Currency).AsNoTracking().FirstOrDefaultAsync();

            return basicInformation;
        }

        public new async Task<bool> Update(BasicInformation basicInformation)
        {
            var updated = _entities.Update(basicInformation);
            int states = await _context.SaveChangesAsync();
            if (states != 0)
                return true;

            return false;
        }

        public async Task<bool> BasicInformationExists(int candidateId)
        {
            BasicInformation basicInformation = await _entities.Where(x => x.CandidateId == candidateId).FirstOrDefaultAsync();

            if (basicInformation != null)
                return true;

            return false;
        }

        public async Task<BasicInformation> GetByCandidateId(int candidateId)
        {
            BasicInformation basicInformation = await _entities.Where(x => x.CandidateId == candidateId)
                .Include( x => x.Emails).Include( x => x.UserLinks).Include( x => x.Phones).Include( x => x.SocialNetworks)
                .Include(x => x.Currency)
                .FirstOrDefaultAsync();

            return basicInformation;
        }

        public async Task<BasicInformation> GetByCandidateIdAndNotInclude(int candidateId)
        {
            BasicInformation basicInformation = await _entities.Where(x => x.CandidateId == candidateId)
                .FirstOrDefaultAsync();

            return basicInformation;
        }

        public async Task<List<BasicInformation>> GetPageSectionCandidate(int page, int pageSize)
        {
            List<BasicInformation> basicInformationList = await _entities.Include(x => x.Currency).AsNoTracking().ToListAsync();

            List<BasicInformation> pageSources = basicInformationList.Skip((page) * pageSize).Take(pageSize).ToList();

            return pageSources;
        }
        public async Task<bool> EditCompanyBirthDate(int candidateId, string birthDateCompany)
        {
            BasicInformation basicInformation = await _entities.Where(x => x.CandidateId == candidateId)
                .Include(x => x.Emails).Include(x => x.UserLinks).Include(x => x.Phones).Include(x => x.SocialNetworks)
                .Include(x => x.Currency)
                .FirstOrDefaultAsync();

            basicInformation.BirthDateCompany = birthDateCompany;

            _entities.Update(basicInformation);
            int states = await _context.SaveChangesAsync();

            if (states != 0)
                return true;

            return false;
        }

        public async Task<bool> EditCompanyHaveWorkExperience(int candidateId, int haveWorkExperienceCompany)
        {
            BasicInformation basicInformation = await _entities.Where(x => x.CandidateId == candidateId)
                .Include(x => x.Emails).Include(x => x.UserLinks).Include(x => x.Phones).Include(x => x.SocialNetworks)
                .Include(x => x.Currency)
                .FirstOrDefaultAsync();

            basicInformation.HaveWorkExperienceFromCompany = haveWorkExperienceCompany;

            _entities.Update(basicInformation);
            int states = await _context.SaveChangesAsync();

            if (states != 0)
                return true;

            return false;
        }

        public async Task<bool> EditCompanyAspirationAndCurrency(int candidateId, int currency, string salary)
        {
            BasicInformation basicInformation = await _entities.Where(x => x.CandidateId == candidateId)
                 .Include(x => x.Emails).Include(x => x.UserLinks).Include(x => x.Phones).Include(x => x.SocialNetworks)
                 .Include(x => x.Currency)
                 .FirstOrDefaultAsync();
            
            basicInformation.CurrencyIdFromCompany = currency;
            basicInformation.SalaryAspirationFromCompany = salary;

            _entities.Update(basicInformation);
            int states = await _context.SaveChangesAsync();

            if (states != 0)
                return true;

            return false;
        }

        public async Task<bool> EditDocument(int candidateId, int documentTypeId, string document, string otherDocumente)
        {
            BasicInformation basicInformation = await _entities.Where(x => x.CandidateId == candidateId)
                 .Include(x => x.Emails).Include(x => x.UserLinks).Include(x => x.Phones).Include(x => x.SocialNetworks)
                 .Include(x => x.Currency)
                 .FirstOrDefaultAsync();

            basicInformation.DocumentTypeId = documentTypeId;
            basicInformation.Document = document;
            basicInformation.OtherDocument = otherDocumente;

            _entities.Update(basicInformation);
            int states = await _context.SaveChangesAsync();

            if (states != 0)
                return true;

            return false;
        }


        public CandidateContext context
        {
            get { return _context as CandidateContext; }
        }
    }
}
