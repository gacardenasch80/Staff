using System.Collections.Generic;
using System;

namespace CandidatesMS.ModelsCompany
{
    public class EvaluationsResumeByJobOrTGId
    {
        public int JobId { get; set; }
        public int TalentGroupId { get; set; }

        public string Name { get; set; }

        public int Evaluations { get; set; }
        public int Interviewers { get; set; }

        public string EvaluationsAndInterviewersFormat { get; set; }
        public string EvaluationsAndInterviewersFormatEnglish { get; set; }

        public string LastEvaluationFormat { get; set; }
        public string LastEvaluationFormatEnglish { get; set; }

        public string LastEvaluationToltip { get; set; }
        public string LastEvaluationToltipEnglish { get; set; }

        public DateTime CreationDateLastEvaluation { get; set; }

        public double Percent { get; set; }
        public string PercentFormat { get; set; }

        public int PercentObjecitve { get; set; }
        public int PercentSubjective { get; set; }

        public double PercentObjecitveValue { get; set; }
        public double PercentSubjectiveValue { get; set; }

        public double PercentObjecitveAverage { get; set; }
        public double PercentSubjectiveAverage { get; set; }

        public string PercentObjecitveAverageFormat { get; set; }
        public string PercentSubjectiveAverageFormat { get; set; }

        public int ColourFlag { get; set; }

        public List<EvaluationDTO> EvaluationsJob { get; set; }
        public List<EvaluationDTO> EvaluationsTG { get; set; }

        public List<EvaluationCriteriaDTO> ObjectiveCriterias { get; set; }
        public List<EvaluationCriteriaDTO> SubjectiveCriterias { get; set; }

        public List<MemberUserDTO> MemberUsers { get; set; }
    }
}
