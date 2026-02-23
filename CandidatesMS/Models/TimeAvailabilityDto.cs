using System.Collections.Generic;

namespace CandidatesMS.Models
{
    public class TimeAvailabilityDTO
    {
        public int TimeAvailabilityId { get; set; }
        public string TimeAvailabilityGuid { get; set; }
        public string TimeAvailabilityName { get; set; }
        public string TimeAvailabilityNameEnglish { get; set; }
        //public ICollection<Candidate_JobPreferenceDto> Candidate_JobPreference { get; set; }
    }
}
