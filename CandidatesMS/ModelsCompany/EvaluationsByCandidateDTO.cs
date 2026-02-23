using System.Collections.Generic;
using System;
using CandidatesMS.Models;

namespace CandidatesMS.ModelsCompany
{
    public class EvaluationsByCandidateDTO
    {
        public List<EvaluationByReportDTO> Evaluations { get; set; }
        public int EvaluationsCount { get; set; }

        public List<MemberUserByEvaluationReportDTO> Interviewers { get; set; }
        public int InterviewersCount { get; set; }

        public int CandidateId { get; set; }
        public string CandidateName { get; set; }

        public string TotalPercentObjectiveCriteriasFormat { get; set; }
        public string TotalPercentSubjectiveCriteriasFormat { get; set; }
        public string TotalPercentFormat { get; set; }

        public List<StudyDTO> Studies { get; set; }
        public List<WorkExperienceDTO> WorkExperiences { get; set; }

        public string YearsExperience { get; set; }

        public DateTime CreationDateLastEvaluation { get; set; }
    }

    public class EvaluationByReportDTO
    {
        public int EvaluationId { get; set; }

        public string Observation { get; set; }

        public DateTime CreationDate { get; set; }

        public double TotalValueObjective { get; set; }
        public string TotalValueObjectiveFormat { get; set; }

        public double TotalValueSubjective { get; set; }
        public string TotalValueSubjectiveFormat { get; set; }

        public double TotalValue { get; set; }
        public string TotalValueFormat { get; set; }

        public List<EvaluationCriteriaByReportDTO> ObjectiveCriterias { get; set; }
        public List<EvaluationCriteriaByReportDTO> SubjectiveCriterias { get; set; }

        public List<StudyDTO> Studies { get; set; }
        public List<WorkExperienceDTO> WorkExperiences { get; set; }
    }

    public class EvaluationCriteriaByReportDTO
    {
        public int EvaluationCriteriaId { get; set; }

        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public int MaxPercent { get; set; }
        public int Value { get; set; }

        public int EvaluationCriteriaTypeId { get; set; }
        public int CompanyUserId { get; set; }
    }

    public class MemberUserByEvaluationReportDTO
    {
        public int MemberUserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleNameEnglish { get; set; }
    }
}
