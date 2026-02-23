using System.Collections.Generic;
using System;

namespace CandidatesMS.ModelsCompany
{
    public class EvaluationCriteriasMappingDTO
    {
        public List<EvaluationCriteriaDTO> ObjectiveCriterias { get; set; }
        public List<EvaluationCriteriaDTO> SubjectiveCriterias { get; set; }

        public MemberUserEvaluationDTO MemberUser { get; set; }

        public int EvaluationId { get; set; }

        public int JobOrTalentGroupId { get; set; }
        public string JobOrTalentGroupName { get; set; }
        public bool IsFromJob { get; set; }

        public double Percent { get; set; }
        public string PercentFormat { get; set; }

        public int PercentObjective { get; set; }
        public int PercentSubjective { get; set; }

        public double TotalValueObjective { get; set; }
        public double TotalValueSubjective { get; set; }

        public double PercentCalculateObjective { get; set; }
        public double PercentCalculateSubjective { get; set; }

        public int ColourFlag { get; set; } // 1 rojo, 2 amarillo, 3 verde

        public string Observation { get; set; }

        public bool Delete { get; set; }
        public bool Editable { get; set; }

        public DateTime CreationDate { get; set; }

        public string CreationInfo { get; set; }
        public string CreationInfoEnglish { get; set; }

        public string CreationInfoPup { get; set; }
        public string CreationInfoPupEnglish { get; set; }

        public int CompanyUserId { get; set; }

        public bool MemberDeleted { get; set; }
    }
}
