using System.Collections.Generic;
using System;

namespace CandidatesMS.ModelsCompany
{
    public class EvaluationDTO
    {
        public int EvaluationId { get; set; }

        public int CandidateId { get; set; }
        public int CompanyUserId { get; set; }
        public int MemberUserId { get; set; }

        public int JobId { get; set; }
        public int TalentGroupId { get; set; }

        public string Observation { get; set; }

        public DateTime CreationDate { get; set; }

        public string MemberUserName { get; set; }
        public string MemberUserInitials { get; set; }
        public bool MemberDeleted { get; set; }

        public List<EvaluationCriteriaDTO> ObjectiveCriterias { get; set; }
        public List<EvaluationCriteriaDTO> SubjectiveCriterias { get; set; }
    }
}
