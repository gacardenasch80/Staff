using System;

namespace CandidatesMS.Models
{
    public class WorkExperienceDTO
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
        public bool AdminView { get; set; }
        public string Functions { get; set; }
        public string OtherIndustry { get; set; }
        public int CandidateId { get; set; }
        public int? IndustryId { get; set; }
        public IndustryDTO industry { get; set; }
        public EquivalentPositionDTO EquivalentPositionGroup { get; set; }
        public int? EquivalentPositionId { get; set; }
        public string EquivalentPosition { get; set; }
        public string EquivalentPositionEnglish { get; set; }
    }
}
