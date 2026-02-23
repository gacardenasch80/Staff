namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class EvaluationCriteria
    {
        public int EvaluationCriteriaId { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public int MaxPercent { get; set; }
        public bool IsMandatory { get; set; }

        public int EvaluationCriteriaTypeId { get; set; }
        public EvaluationCriteriaType EvaluationCriteriaType { get; set; }

        public int CompanyUserId { get; set; }
        public CompanyUser CompanyUser { get; set; }
    }
}
