using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CandidatesMS.Persistence.Entities
{
    public class Company_Candidate_Wellness
    {
        public int Company_Candidate_WellnessId { get; set; }

        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }
        public Wellness Wellness { get; set; }
        public int WellnessId { get; set; }

        public int CompanyUserId { get; set; }
    }
}
