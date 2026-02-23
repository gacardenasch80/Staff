using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CandidatesMS.Persistence.Entities
{
    public class Candidate_TimeAvailability
    {
        public int Candidate_TimeAvailabilityId { get; set; }

        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }
        public TimeAvailability TimeAvailability { get; set; }
        public int TimeAvailabilityId { get; set; }
    }
}
