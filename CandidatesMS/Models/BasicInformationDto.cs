using CandidatesMS.Persistence.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace CandidatesMS.Models
{
    public class BasicInformationDTO
    {
        public int BasicInformationId { get; set; }
        public string BasicInformationGuid { get; set; }

        public int CandidateId { get; set; }
        public CandidateDTO Candidate { get; set; }

        public string Photo { get; set; }
        public string PhotoByAdmin { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        public string Document { get; set; }
        public string DocumentAdmin { get; set; }
        public string OtherDocument { get; set; }
        public int DocumentTypeId { get; set; }
        public DocumentTypeDTO DocumentType { get; set; }
        public int DocumentTypeIdAdmin { get; set; }

        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string AddressAdmin { get; set; }

        public string Email { get; set; }
        public List<EmailDTO> Emails { get; set; }

        public string Phone { get; set; }
        public string Cellphone { get; set; }
        public List<PhoneDTO> Phones { get; set; }

        public string BirthDate { get; set; }
        public string BirthDateCompany { get; set; }

        public int HaveWorkExperience { get; set; }
        public int HaveWorkExperienceFromCompany { get; set; }

        public string SalaryAspiration { get; set; }
        public string SalaryAspirationFromCompany { get; set; }

        public CurrencyDTO Currency { get; set; }
        public int CurrencyId { get; set; }
        public int CurrencyIdFromCompany { get; set; }

        public List<SocialNetworkDTO> SocialNetworks { get; set; }
        public List<UserLinkDTO> UserLinks { get; set; }

        public string LinkedInURL { get; set; }
        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
        public string GitHubURL { get; set; }
        public string BitBucketURL { get; set; }

        public int MaritalStatusId { get; set; }
        public int? MaritalStatusCompanyId { get; set; }

        public int GenderId { get; set; }
        public int? GenderCompanyId { get; set; }

        public DocumentCheckDTO DocumentCheck { get; set; }

        public string EmailMemberUser { get; set; }
        public string NameMemberUser { get; set; }

        public bool DeleteMember { get; set; }

        public string CreationInfo { get; set; }
        public string CreationShortInfo { get; set; }
        public string CreationInfoPup { get; set; }
        public string FirstLoginInfoPup { get; set; }

        public int IsMigrated { get; set; }
        public bool IsFromCompanyAndLogin { get; set; }

        public int NumberNotes { get; set; }

        public IFormFile FormFile { get; set; }
    }
}
