using CandidatesMS.Models;
using CandidatesMS.Models.RemoteModels.Out;
using CandidatesMS.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ICandidateRepository : IRepository<Candidate>
    {
        Task<bool> AddMigration(Candidate entity);
        Task<Candidate> GetByEmail(string email);
        Task<Candidate> GetByCandidateId(int candidateId);
        Task<Candidate> GetByGuid(string guid);
        Task<List<Candidate>> GetPageSectionCandidate(int page, int pageSize, int userType, int companyUserId);
        Task<List<Candidate>> GetPageSectionCandidateMaster(int page, int pageSize);
        Task<List<Candidate>> GetPageSectionAscendingCandidate(int page, int pageSize, int userType, int companyUserId);
        Task<List<Candidate>> GetPageSectionAscendingCandidateMaster(int page, int pageSize);
        Task<int> CountAllCandidatesToExsis(int companyUserId);

        Task<Candidate> GetCandidateOverviewWithCompany(int candidateId, int companyUserId);

        Task<int> CountAllCandidateMaster();
        bool CandidateExist(Study study);
        bool CandidateExistById(int candidateId);
        Task<Candidate> GetCandidateProfileOverViewById(int candidateId);
        Task<bool> CandidateExistByEmail(string email);
        Task<bool> CandidateExistByEmailAndAlternativeEmails(string email);
        Task<bool> CandidateExistByEmailAndSecondBigMigration(string email);
        Task<ExperienceCount> ExperienceCountByCandidateId(int candidateId);
        Task<bool> AddExperienceCounter(ExperienceCount experienceCount);
        Task<object[]> EditEditionDate(int candidateId);
        int CountAllCandidates();
        Task<int> CountAllCandidatesFromCompany(int companyUserId);
        Task<List<Candidate>> GetCandidatesByString(string search, int pageSize, int companyUserId, int userType);
        Task<List<Candidate>> GetCandidatesByStringWithoutSearch(int companyUserId, int userType);
        Task<List<Candidate>> GetCandidatesByFilter(string search, int userType, int companyUserId);
        Task<List<Candidate>> GetCandidatesByFilterAndJobOrTalentGroupList(string search, int companyUserId, List<int> candidatesIds);
        Task<List<Candidate>> GetCandidatesByFilterAndJobOrTalentGroupFullList(SearchByIdAndTextWithPaginationDTO searchObject,
            int companyUserId, List<int> candidatesIds);

        /**/

        Task<Dictionary<string, dynamic>> GetCandidatesByFilterAndTalentGroup(SearchByIdAndTextWithPaginationDTO searchObject,
            int companyUserId, CultureInfo culture, string token);

        /**/

        Task<Dictionary<string, dynamic>> GetCandidatesByFilterAndJob(
            SearchByIdAndTextWithPaginationDTO searchObject,
            int companyUserId, CultureInfo culture, string token);

        /**/

        Task<Dictionary<string, dynamic>> GetCandidatesByFilterGeneral(
            SearchByIdAndTextWithPaginationDTO searchObject,
            int companyUserId, bool isExsis, bool isMaster, CultureInfo culture, string token);

        /**/

        Task<List<Candidate>> GetCandidatesByFilterMaster(string search);
        Task<List<Candidate>> GetCandidateWithJobProfessions(List<int> jobProfessionIds,int companyUserId);
        Task<List<Candidate>> GetCandidateWithJobProfessionsMaster(List<int> jobProfessionIds);
        Task<List<Candidate>> GetCandidatesWithIdsAndSearch(List<int> candidateIds,string search);
        Task<List<Candidate>> GetCandidateForCurrencyCompany(int currency,int companyUserId);
        List<Candidate> GetAllCandidateWithDate(DateTime leftDate, DateTime rightDate);
        public List<Candidate> GetAllCandidateWithDateAndFilter
        (
            bool isLanguagesFilter, bool isFullLanguages, List<Candidate_LanguageDTO> languagesFilter,
            bool isTechnicalAbilitiesFilter, bool isFullTechnicalAbilities, List<Candidate_TechnicalAbilityDTO> technicalAbilitiesFilter,
            bool isLocationFilter, bool isFullLocations, string country, string state, string city,
            bool isSalaryAspirationFilter, bool isFullSalaryAspirations, List<SalaryAspirationFromSearchDTO> salaryAspirationFilter
        );
        List<Candidate> GetAllCandidateWithDateAndCompanyUserId(DateTime leftDate, DateTime rightDate, int companyUserId);
        List<Candidate> GetAllCandidateWithDateAndCompanyUserIdAndFilter
        (
            int companyUserId,
            bool isLanguagesFilter, bool isFullLanguages, List<Candidate_LanguageDTO> languagesFilter,
            bool isTechnicalAbilitiesFilter, bool isFullTechnicalAbilities, List<Candidate_TechnicalAbilityDTO> technicalAbilitiesFilter,
            bool isLocationFilter, bool isFullLocations, string country, string state, string city,
            bool isSalaryAspirationFilter, bool isFullSalaryAspirations, List<SalaryAspirationFromSearchDTO> salaryAspirationFilter
        );
        List<Candidate> GetAllCandidateMasterWithDate(DateTime leftDate, DateTime rightDate);
        List<Candidate> GetAllCandidateMasterWithDateAndFilter
        (
            bool isLanguagesFilter, bool isFullLanguages, List<Candidate_LanguageDTO> languagesFilter,
            bool isTechnicalAbilitiesFilter, bool isFullTechnicalAbilities, List<Candidate_TechnicalAbilityDTO> technicalAbilitiesFilter,
            bool isLocationFilter, bool isFullLocations, string country, string state, string city,
            bool isSalaryAspirationFilter, bool isFullSalaryAspirations, List<SalaryAspirationFromSearchDTO> salaryAspirationFilter
        );
        List<Candidate> GetAllCandidateCompanyWithDate(DateTime leftDate, DateTime rightDate, int companyUserId);
        //

        Task<Candidate> GetCandidateFullDataByCandidateId(int candidateId);
        Task<Candidate> GetOnlyCandidateDataByCandidateId(int candidateId);
        Task<Candidate> GetCandidateToRequest(string email);

        Task<Candidate> ChangeDeleteState(int candidateId,string MemberEmail);
        Task<Candidate> ChangeViewSelectionFiles(int candidateId);
        Task<Candidate> ChangeViewHiringFiles(int candidateId);
        Task<Candidate> ChangeDeleteStateCandidate(int candidateId);

        Task<List<Candidate>> GetAllCandidatesFromCompany(int companyUserId);
        Task<List<Candidate>> GetAllCandidatesFromCompanyOrMigrated(int companyUserId);
        Task<List<Candidate>> GetCandidatesExceptEmail(string email, int companyUserId);
    }
}
