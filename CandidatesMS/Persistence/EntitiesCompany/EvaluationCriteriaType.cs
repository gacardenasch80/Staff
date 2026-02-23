using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class EvaluationCriteriaType
    {
        public int EvaluationCriteriaTypeId { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public ICollection<DefaultEvaluationCriteria> DefaultEvaluationCriteria { get; set; }
        public ICollection<EvaluationCriteria> EvaluationCriteria { get; set; }
    }
}
