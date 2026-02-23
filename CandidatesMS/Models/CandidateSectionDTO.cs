using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class CandidateSectionDTO
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
        public string DeleteDate { get; set; }
        public string CreationDatePopUp { get; set; }
        public string CreationDatePopUpEnglish { get; set; }
        public string DeleteDateePopUp { get; set; }
        public bool IsDeleteProccess { get; set; }
        public int TotalJobs { get; set; }
        public int TotalTalentGroups { get; set; }
        public List<string> Jobs { get; set; }
        public List<string> TalentGroups { get; set; }
        public int Previous { get; set; }
        public int Next { get; set; }

        public int ColourFlag { get; set; }
        public string ColourFlagToltip { get; set; }
    }
}
