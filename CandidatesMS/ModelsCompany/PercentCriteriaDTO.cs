using CandidatesMS.Models.RemoteModels.In;
using System;

namespace CandidatesMS.ModelsCompany
{
    public class PercentCriteriaDTO
    {
        public int PercentCriteriaId { get; set; }

        public int PercentObjectiveValue { get; set; }
        public double PercentObjectiveDecimal { get; set; }
        public string PercentObjectiveFormat { get; set; }

        public int PercentSubjectiveValue { get; set; }
        public double PercentSubjectiveDecimal { get; set; }
        public string PercentSubjectiveFormat { get; set; }

        public DateTime EditionDate { get; set; }

        public string EditionDateFormat { get; set; }
        public string EditionDateFormatEnglish { get; set; }

        public string EditionDateToltip { get; set; }
        public string EditionDateToltipEnglish { get; set; }

        public int CompanyUserId { get; set; }
        public CompanyUserDTO CompanyUser { get; set; }
    }
}
