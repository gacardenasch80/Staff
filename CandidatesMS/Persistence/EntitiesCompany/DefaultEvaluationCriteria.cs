namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class DefaultEvaluationCriteria
    {
        public int DefaultEvaluationCriteriaId { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public int MaxPercent { get; set; }

        public int EvaluationCriteriaTypeId { get; set; }
        public EvaluationCriteriaType EvaluationCriteriaType { get; set; }
    }
}
