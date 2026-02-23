using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CandidatesMS.Persistence.Entities
{
    public class Candidate_Wellness
    {
        public int Candidate_WellnessId { get; set; }

        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }
        public Wellness Wellness { get; set; }
        public int WellnessId { get; set; }
    }
}
