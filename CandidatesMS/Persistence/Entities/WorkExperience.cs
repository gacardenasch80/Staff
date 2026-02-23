using System;
using System.Collections.Generic;

namespace CandidatesMS.Persistence.Entities
{
    public class WorkExperience
    {
        public int WorkExperienceId { get; set; }
        public string WorkExperienceGuid { get; set; }
        public string Company { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string Position { get; set; }
        public string BossName { get; set; }
        public string BossCellphone { get; set; }
        public string OfficePhone { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public bool CurrentlyWorking { get; set; }
        public bool Authorization { get; set; }
        public string Functions { get; set; }
        public string OtherIndustry { get; set; }
        /* One Candidate, Many Work Experience */
        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }
        /* One Industry, Many Work Experiences */
        //public Industry Industry { get; set; }
        public int? IndustryId { get; set; }
        public Industry Industry { get; set; }
        /* One Equivalent Position, Many Work Experiences */
        public EquivalentPosition EquivalentPosition { get; set; }
        public int? EquivalentPositionId { get; set; }

        public bool AdminView { get; set; }
        public int CompanyUserId { get; set; }
    }
}
