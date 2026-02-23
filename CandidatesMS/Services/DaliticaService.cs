using System.Threading.Tasks;
using System;
using CandidatesMS.Models;
using CandidatesMS.Models.RemoteModels.In;
using System.Linq;
using System.Collections.Generic;
using CandidatesMS.Persistence.Entities;
using iText.Html2pdf.Attach;

namespace CandidatesMS.Services
{
    public interface IDaliticaService
    {
        Task<CandidateDTO> MappingCandidateFromDalitica(DaliticaInDTO daliticaInDTO);
    }

    public class DaliticaService : IDaliticaService
    {
        public async Task<CandidateDTO> MappingCandidateFromDalitica(DaliticaInDTO daliticaInDTO)
        {
            try
            {
                CandidateDTO candidateDTO = new CandidateDTO();
                BasicInformationDTO basicInformationDTO = new BasicInformationDTO();
                CandidateCompanyDTO candidateCompanyDTO = new CandidateCompanyDTO();

                if (daliticaInDTO != null && daliticaInDTO.result != null)
                {
                    DaliticaResultInDTO result = daliticaInDTO.result;

                    List<string> auxEmailsString = new List<string>();
                    List<EmailDTO> auxEmails = new List<EmailDTO>();

                    List<string> auxPhonesString = new List<string>();
                    List<PhoneDTO> auxPhones = new List<PhoneDTO>();

                    CompanyDescriptionDTO companyDescriptionDTO = new CompanyDescriptionDTO();

                    if (result.emails != null && result.emails.Count > 1)
                    {
                        auxEmailsString = result.emails.GetRange(1, result.emails.Count - 1);

                        foreach(string auxEmailString in auxEmailsString)
                        {
                            auxEmails.Add
                            (
                                new EmailDTO
                                {
                                    EmailId = 0,
                                    Mail = auxEmailString,
                                    BasicInformationId = 0
                                }
                            );
                        }
                    }

                    if (result.phoneNumbers != null && result.phoneNumbers.Count > 1)
                    {
                        auxPhonesString = result.emails.GetRange(1, result.phoneNumbers.Count - 1);

                        foreach (string auxPhoneString in auxPhonesString)
                        {
                            auxPhones.Add
                            (
                                new PhoneDTO
                                {
                                    PhoneId = 0,
                                    Number = auxPhoneString,
                                    CompanyUserId = 0,
                                    BasicInformationId = 0
                                }
                            );
                        }
                    }

                    candidateDTO = new CandidateDTO
                    {
                        CandidateId = 0,
                        CandidateGuid = string.Empty,

                        CompanyUserId = 0,

                        Email = result.emails != null && result.emails.Count > 0 ? result.emails[0] : string.Empty,

                        FullData = false,

                        CreationDate = string.Empty,
                        EditionDate = string.Empty,
                        FirstLoginDate = string.Empty,
                        DeleteDate = string.Empty,
                        LoginCode = string.Empty,

                        IsMigrated = 0,
                        IsFromCompanyAndLogin = false,
                        isAuthorized = false,
                        IsNew = false,
                        IsDeleteProccess = false,
                        IsAuthDocuments = false,
                        IsAuthDocumentsHiring = false,

                        Source = string.Empty,

                        NameMemberUser = string.Empty,
                        SurnameMemberUser = string.Empty,
                        EmailMember = string.Empty,

                        VideoList = null,
                        StudyList = null,
                        PersonalReferenceList = null,
                        Candidate_TechnicalAbilityList = null,
                        Candidate_LifePreferenceList = null,
                        Candidate_SoftSkillList = null,
                        WorkExperienceList = null,
                        Candidate_Language = null,
                        Candidate_LanguageOther = null,
                        LanguageOther = null,
                        Notes = null,
                        Mails = null,

                        BasicInformation = null,
                        Description = null,
                        CompanyDescription = null,
                        ExperienceCount = null,
                    };

                    basicInformationDTO = new BasicInformationDTO
                    {
                        BasicInformationId = 0,
                        BasicInformationGuid = string.Empty,

                        CandidateId = 0,
                        Candidate = null,

                        Photo = string.Empty,
                        PhotoByAdmin = string.Empty,

                        Name = result.firstName,
                        Surname = result.lastName,

                        Document = string.Empty,
                        DocumentAdmin = string.Empty,
                        OtherDocument = string.Empty,
                        DocumentTypeId = 0,
                        DocumentTypeIdAdmin = 0,
                        DocumentType = null,

                        Country = !string.IsNullOrEmpty(result.country) ? result.country : string.Empty,
                        State = !string.IsNullOrEmpty(result.city) ? result.city : string.Empty,
                        City = !string.IsNullOrEmpty(result.city) ? result.city : string.Empty,

                        Address = string.Empty,
                        AddressAdmin = !string.IsNullOrEmpty(result.address) ? result.address : string.Empty,

                        Email = result.emails != null && result.emails.Count > 0 ? result.emails[0] : string.Empty,
                        //Emails = auxEmails,

                        Phone = result.phoneNumbers != null && result.phoneNumbers.Count > 0 ? result.phoneNumbers[0] : string.Empty,
                        //Phones = auxPhones,

                        BirthDate = string.Empty,
                        BirthDateCompany = !string.IsNullOrEmpty(result.dateOfBirth) ? result.dateOfBirth : string.Empty,

                        HaveWorkExperience = 0,
                        HaveWorkExperienceFromCompany = 0,

                        SalaryAspiration = string.Empty,
                        SalaryAspirationFromCompany = string.Empty,

                        Currency = null,
                        CurrencyId = 0,
                        CurrencyIdFromCompany = 0,

                        SocialNetworks = null,
                        UserLinks = null,

                        LinkedInURL = string.Empty,
                        FacebookURL = string.Empty,
                        TwitterURL = string.Empty,
                        GitHubURL = string.Empty,
                        BitBucketURL = string.Empty,

                        MaritalStatusId = 0,
                        MaritalStatusCompanyId = 0,

                        GenderId = 0,
                        GenderCompanyId = 0,

                        DocumentCheck = null,

                        EmailMemberUser = string.Empty,
                        NameMemberUser = string.Empty,

                        DeleteMember = false,

                        CreationInfo = string.Empty,
                        CreationShortInfo = string.Empty,
                        CreationInfoPup = string.Empty,
                        FirstLoginInfoPup = string.Empty,

                        IsMigrated = 0,
                        IsFromCompanyAndLogin = false,

                        FormFile = null,
                    };

                    companyDescriptionDTO = new CompanyDescriptionDTO
                    {
                        CompanyDescriptionId = 0,

                        Text = !string.IsNullOrEmpty(result.summary) ? result.summary : string.Empty,

                        YearsExperience = !string.IsNullOrEmpty(result.totalYearsOfExperience) ? result.totalYearsOfExperience : string.Empty,

                        NumberCompanies = string.Empty,

                        CompanyUserId = 0,
                        CandidateId = 0
                    };

                    candidateCompanyDTO = new CandidateCompanyDTO
                    {
                        CandidateCompanyId = 0,

                    };

                    candidateDTO.BasicInformation = basicInformationDTO;
                }

                return candidateDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
