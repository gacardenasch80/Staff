using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CandidatesMS.Persistence.Entities
{
    public class Wellness
    {
        public int WellnessId { get; set; }
        public string WellnessGuid { get; set; }
        public string WellnessName { get; set; }
        public string WellnessNameEnglish { get; set; }

        public ICollection<Candidate_Wellness> Candidate_WellnessList { get; set; }
        public ICollection<Company_Candidate_Wellness> Company_Candidate_WellnessList { get; set; }
    }
}
