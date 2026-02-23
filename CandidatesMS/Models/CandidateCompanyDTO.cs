using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class CandidateCompanyDTO
    {
        public int CandidateCompanyId { get; set; }
        public int CandidateId { get; set; }
        public int CompanyUserId { get; set; }

        public string Document { get; set; }
        public DocumentTypeDTO DocumentType { get; set; }

        public string Address { get; set; }
        public string BirthDate { get; set; }
        public string Photo { get; set; }
        public int? HaveWorkExperience { get; set; }

        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public MaritalStatusDTO MaritalStatus { get; set; }

        public GenderDTO Gender { get; set; }

        public string SalaryAspiration { get; set; }
        public CurrencyDTO Currency { get; set; }

        public CVDTO CV { get; set; }

        public bool IsPotential { get; set; }
    }
}
