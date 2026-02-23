using System.Collections.Generic;

namespace CandidatesMS.Models
{
    public class DatesReportWithFiltersDTO
    {
        public string EmailMemberUser { get; set; }
        public int PortalId { get; set; }
        public int CompanyUserId { get; set; }

        public bool IsLanguagesFilter { get; set; }
        public bool IsFullLanguages { get; set; }
        public List<Candidate_LanguageDTO> LanguagesFilter { get; set; }

        public bool IsTechnicalAbilitiesFilter { get; set; }
        public bool IsFullTechnicalAbilities { get; set; }
        public List<Candidate_TechnicalAbilityDTO> TechnicalAbilitiesFilter { get; set; }

        public bool IsLocationFilter { get; set; }
        public bool IsFullLocations { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }

        public bool IsSalaryAspirationFilter { get; set; }
        public bool IsFullSalaryAspirations { get; set; }
        public List<SalaryAspirationFromSearchDTO> SalaryAspirationFilter { get; set; }

        public int Language { get; set; }
    }
}
