using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandidatesMS.Persistence.Entities
{
    public class Candidate_LanguageOther
    {
        public int Candidate_LanguageOtherId { get; set; }
        public string Candidate_LanguageOtherGuid { get; set; }

        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }
        public LanguageOther LanguageOther { get; set; }        
        public int LanguageOtherId { get; set; }
        public LanguageLevel LanguageLevel { get; set; }
        public int LanguageLevelId { get; set; }

        public bool AdminView { get; set; }
        public int CompanyUserId { get; set; }
    }
}
