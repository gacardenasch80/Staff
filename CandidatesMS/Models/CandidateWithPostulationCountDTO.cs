using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class CandidateWithPostulationCountDTO
    {
        public int CandidateId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Initials { get; set; }
        public string Photo { get; set; }
        public int CompanyUserId { get; set; }
        public string CreationDate { get; set; }
        public string CreationDateEnglish { get; set; }
        public string CreationDateToltip { get; set; }
        public string CreationDatePopUpEnglish { get; set; }
        public string DeleteDate { get; set; }
        public string DeleteDateToltip { get; set; }
        public bool IsDeleteProccess { get; set; }
        public bool IsAuthDocuments { get; set; }
        public bool IsAuthDocumentsHiring { get; set; }
        public int TotalJobs { get; set; }
        public int TotalTalentGroups { get; set; }
        public List<string> Jobs { get; set; }
        public List<string> TalentGroups { get; set; }
        public int Previous { get; set; }
        public int Next { get; set; }

        public int ColourFlag { get; set; }
        public string ColourFlagToltip { get; set; }
    }

    public class CandidateWithPostulationCountResponseDTO
    {
        public int Total { get; set; }
        public List<CandidateWithPostulationCountDTO> Candidates { get; set; }
    }
}
