using System.Collections.Generic;
using System;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Evaluation
    {
        public int EvaluationId { get; set; }

        public string Observation { get; set; }

        public int CandidateId { get; set; }

        public int CompanyUserId { get; set; }
        public CompanyUser CompanyUser { get; set; }

        public string MemberUserName { get; set; }
        public string MemberUserInitials { get; set; }
        public string MemberUserEmail { get; set; }
        public string MemberUserPhoto { get; set; }
        public int MemberUserId { get; set; }

        public DateTime CreationDate { get; set; }

        public ICollection<Evaluation_EvaluationCriteria> Evaluation_EvaluationCriteria { get; set; }


        public int JobId { get; set; }

        public int TalentGroupId { get; set; }
    }
}
