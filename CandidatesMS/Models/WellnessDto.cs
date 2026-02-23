using System.Collections.Generic;

namespace CandidatesMS.Models
{
    public class WellnessDTO
    {
        public int WellnessId { get; set; }
        public string WellnessGuid { get; set; }
        public string WellnessName { get; set; }
        public string WellnessNameEnglish { get; set; }
        //public ICollection<Candidate_JobPreferenceDto> Candidate_JobPreference { get; set; }
    }
}
