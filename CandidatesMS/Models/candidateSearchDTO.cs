using System;
using System.Collections.Generic;

namespace CandidatesMS.Models
{
    public class candidateSearchDTO
    {
        public int CandidateId { get; set; }
        public string Photo { get; set; }
        public string Initials { get; set; }
        public string Name { get; set; }
        public int CompanyUserId { get; set; }
        public string CreationDateString { get; set; }
        public DateTime CreationDateNotFormat { get; set; }
        public string CreationDate { get; set; }
        public string CreationDateEnglish { get; set; }
        public string CreationDatePopUp { get; set; }
        public string CreationDatePopUpEnglish { get; set; }
        public string DeleteDate { get; set; }
        public string DeleteDatePopUp { get; set; }
        public bool IsDeleteProccess { get; set; }
        public int TotalJobs { get; set; }
        public int TotalTalentGroups { get; set; }
        public List<string> Jobs { get; set; }
        public List<string> TalentGroups { get; set; }
        public List<string> Find { get; set; }
        public int Previous { get; set; }
        public int Next { get; set; }

        public int ColourFlag { get; set; }
        public string ColourFlagToltip { get; set; }

        public bool IsPotential { get; set; }

        public List<Candidate_TechnicalAbilityDTO> Candidate_TechnicalAbilityList { get; set; }
        public List<Candidate_LanguageDTO> Candidate_LanguageList { get; set; }
        public List<StudyDTO> StudyList { get; set; }
        public List<WorkExperienceDTO> WorkExperienceList { get; set; }
    }
}
