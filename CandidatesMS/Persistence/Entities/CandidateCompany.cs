namespace CandidatesMS.Persistence.Entities
{
    public class CandidateCompany
    {
        public int CandidateCompanyId { get; set; }

        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }

        public int CompanyUserId { get; set; }

        public string Document { get; set; }
        public string OtherDocument { get; set; }
        public int? DocumentTypeId { get; set; }

        public string Address { get; set; }
        public string BirthDate { get; set; }
        public int? HaveWorkExperience { get; set; }
        public string SalaryAspiration { get; set; }
        public string Photo { get; set; }

        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public int? DescriptionId { get; set; }
        public int? MaritalStatusId { get; set; }
        public int? GenderId { get; set; }
        public int? CurrencyId { get; set; }

        public bool IsPotential { get; set; }
    }
}
