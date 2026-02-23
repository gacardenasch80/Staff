using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandidatesMS.Persistence.Entities
{
    public class Candidate_Language
    {
        public int Candidate_LanguageId { get; set; }
        public string Candidate_LanguageGuid { get; set; }

        
        public int CandidateId { get; set; }
        public Language Language { get; set; }        
        public int LanguageId { get; set; }        
        public LanguageLevel LanguageLevel { get; set; }
        public int LanguageLevelId { get; set; }

        public bool AdminView { get; set; }
        public int CompanyUserId { get; set; }

    }
}
