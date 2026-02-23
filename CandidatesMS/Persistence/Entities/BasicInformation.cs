using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandidatesMS.Persistence.Entities
{
    public class BasicInformation
    {
        public int BasicInformationId { get; set; }
        public string BasicInformationGuid { get; set; }

        public string Photo { get; set; }
        public string PhotoByAdmin { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Document { get; set; }
        public string DocumentAdmin { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string AddressAdmin { get; set; }
        public string Phone { get; set; }
        public string Cellphone { get; set; }
        public string BirthDate { get; set; }
        public string BirthDateCompany { get; set; }
        public int HaveWorkExperience { get; set; }
        public int HaveWorkExperienceFromCompany { get; set; }
        public string SalaryAspiration { get; set; }
        public string SalaryAspirationFromCompany { get; set; }
        public string OtherDocument { get; set; }
        public int DocumentTypeIdAdmin { get; set; }

        public List<Phone> Phones { get; set; }
        public List<Email> Emails { get; set; }
        public List<SocialNetwork> SocialNetworks { get; set; }
        public List<UserLink> UserLinks { get; set; }

        public string LinkedInURL { get; set; }
        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
        public string GitHubURL { get; set; }
        public string BitBucketURL { get; set; }

        public int MaritalStatusId { get; set; }
        public MaritalStatus MaritalStatus { get; set; }

        public int? MaritalStatusCompanyId { get; set; }

        public Gender Gender { get; set; }
        public int GenderId { get; set; }

        public int? GenderCompanyId { get; set; }

        public int? CurrencyIdFromCompany { get; set; }
        public int CurrencyId { get; set; }
        public Currency Currency { get; set; }
        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }
        public DocumentType DocumentType { get; set; }
        public int? DocumentTypeId { get; set; }
        public DocumentCheck DocumentCheck { get; set; }

        public string NameMemberUser { get; set; }
        public string EmailMemberUser { get; set; }
    }
}
