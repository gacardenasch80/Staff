namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Evaluation_EvaluationCriteria
    {
        public int Evaluation_EvaluationCriteriaId { get; set; }

        public int EvaluationId { get; set; }
        public Evaluation Evaluation { get; set; }

        public int EvaluationCriteriaId { get; set; }

        public int EvaluationCriteriaTypeId { get; set; }
        public int CompanyUserId { get; set; }

        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public int MaxPercent { get; set; }
        public bool IsMandatory { get; set; }

        public int Value { get; set; }
    }
}
