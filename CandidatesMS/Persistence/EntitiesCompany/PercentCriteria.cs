using System;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class PercentCriteria
    {
        public int PercentCriteriaId { get; set; }

        public int PercentObjectiveValue { get; set; }
        public double PercentObjectiveDecimal { get; set; }

        public int PercentSubjectiveValue { get; set; }
        public double PercentSubjectiveDecimal { get; set; }

        public DateTime EditionDate { get; set; }

        public int CompanyUserId { get; set; }
        public CompanyUser CompanyUser { get; set; }
    }
}
