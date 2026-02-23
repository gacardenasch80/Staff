using System.Collections.Generic;

namespace CandidatesMS.Models
{
    public class Company_Candidate_JobPreferenceDto
    {
        public int CandidateId { get; set; }
        public int CompanyUserId { get; set; }

        public ICollection<TimeAvailabilityDTO> TimeAvailabilityList { get; set; }
        public ICollection<WellnessDTO> WellnessList { get; set; }
    }
}