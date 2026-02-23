using System.Collections.Generic;
using System;

namespace CandidatesMS.ModelsCompany
{
    public class ListEvaluationCriteriasMappingDTO
    {
        public List<ListEvaluationCriteriasWithDatesDTO> EvaluationsPerDay { get; set; }
        public int Total { get; set; }
    }

    public class ListEvaluationCriteriasWithDatesDTO
    {
        public List<EvaluationCriteriasMappingDTO> Evaluations { get; set; }

        public DateTime CreationDate { get; set; }

        public string CreationInfo { get; set; }
        public string CreationInfoEnglish { get; set; }
    }
}
