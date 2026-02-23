using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class BasicInformationOverViewDTO
    {
        public int BasicInformationId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Document { get; set; }
        public string DocumentAdmin { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public string PhotoByAdmin { get; set; }
        public string Cellphone { get; set; }
        public string BirthDate { get; set; }
        public string BirthDateCompany { get; set; }
        public string Gender { get; set; }
        public int HaveWorkExperience { get; set; }
        public int HaveWorkExperienceFromCompany { get; set; }
        public int GenderId { get; set; }
        public string SalaryAspiration { get; set; }
        public string SalaryAspirationFromCompany { get; set; }
        public string MaritalStatus { get; set; }
        public string DocumentType { get; set; }
        public string NameMemberUser { get; set; }
        public string EmailMemberUser { get; set; }
        public string OtherDocument { get; set; }
        public bool DeleteMember { get; set; }
        public List<EmailDTO> Emails { get; set; }
        public List<PhoneDTO> Phones { get; set; }
        public List<SocialNetworkDTO> SocialNetworks { get; set; }
        public List<UserLinkDTO> UserLinks { get; set; }
        public int CurrencyId { get; set; }
        public CurrencyDTO Currency { get; set; }
        public int CurrencyIdFromCompany { get; set; }
        public CurrencyDTO CurrencyFromCompany { get; set; }
        public int? DocumentTypeId { get; set; }
    }
}
