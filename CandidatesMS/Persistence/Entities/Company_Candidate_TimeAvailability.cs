using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CandidatesMS.Persistence.Entities
{
    public class Company_Candidate_TimeAvailability
    {
        public int Company_Candidate_TimeAvailabilityId { get; set; }

        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }
        public TimeAvailability TimeAvailability { get; set; }
        public int TimeAvailabilityId { get; set; }

        public int CompanyUserId { get; set; }
    }
}
