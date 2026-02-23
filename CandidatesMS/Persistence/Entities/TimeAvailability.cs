using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CandidatesMS.Persistence.Entities
{
    public class TimeAvailability
    {
        public int TimeAvailabilityId { get; set; }
        public string TimeAvailabilityGuid { get; set; }
        public string TimeAvailabilityName { get; set; }
        public string TimeAvailabilityNameEnglish { get; set; }

        public ICollection<Candidate_TimeAvailability> Candidate_TimeAvailabilityList { get; set; }
        public ICollection<Company_Candidate_TimeAvailability> Company_Candidate_TimeAvailabilityList { get; set; }
    }
}
