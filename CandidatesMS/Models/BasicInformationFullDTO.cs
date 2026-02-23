using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class BasicInformationFullDTO
    {
        public int BasicInformationId { get; set; }

        //

        public string Photo { get; set; }
        public string PhotoByAdmin { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        public string EmailMemberUser { get; set; }
        public string NameMemberUser { get; set; }

        public string Document { get; set; }
        public string DocumentAdmin { get; set; }
        public string OtherDocument { get; set; }

        public string SalaryAspiration { get; set; }
        public string SalaryAspirationFromCompany { get; set; }

        public string Address { get; set; }
        public string AddressAdmin { get; set; }

        //

        public int DocumentTypeId { get; set; }
        public DocumentTypeDTO DocumentType { get; set; }
        public int DocumentTypeIdAdmin { get; set; }
        public DocumentTypeDTO DocumentTypeAdmin { get; set; }

        public int MaritalStatusId { get; set; }
        public MaritalStatusDTO MaritalStatus { get; set; }
        public int? MaritalStatusCompanyId { get; set; }
        public MaritalStatusDTO MaritalStatusCompany { get; set; }


        public int GenderId { get; set; }
        public GenderDTO Gender { get; set; }
        public int? GenderCompanyId { get; set; }
        public GenderDTO GenderCompany { get; set; }

        //

        public string LinkedInURL { get; set; }
        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
        public string GitHubURL { get; set; }
        public string BitBucketURL { get; set; }

        //

        public List<PhoneDTO> Phones { get; set; }
        public List<EmailDTO> Emails { get; set; }
        public List<SocialNetworkDTO> SocialNetworks { get; set; }
        public List<UserLinkDTO> UserLinks { get; set; }
    }
}
