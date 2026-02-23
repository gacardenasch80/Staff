using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace CandidatesMS.Repositories
{
    public interface IBasicInformationRepository : IRepository<BasicInformation>
    {
        Task<List<BasicInformation>> GetAllWithEmailsAndPhones();
        Task<BasicInformation> GetByGuid(string guid);
        Task<BasicInformation> GetByCandidateId(int candidateId);
        Task<BasicInformation> GetByCandidateIdAndNotInclude(int candidateId);
        Task<List<BasicInformation>> GetPageSectionCandidate(int page, int pageSize);
        Task<bool> BasicInformationExists(int candidateId);        
        Task<bool> EditCompanyBirthDate(int candidateId, string birthDateCompany);
        Task<bool> EditCompanyHaveWorkExperience(int candidateId, int haveWorkExperienceCompany);
        Task<bool> EditCompanyAspirationAndCurrency(int candidateId, int currency, string salary);
        Task<bool> EditDocument (int candidateId, int documentTypeId, string document,string otherDocumente);
    }
}
