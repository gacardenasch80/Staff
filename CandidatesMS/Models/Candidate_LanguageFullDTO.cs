using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class Candidate_LanguageFullDTO
    {
        public int Candidate_LanguageId { get; set; }

        public int CandidateId { get; set; }
        public LanguageDTO Language { get; set; }
        public LanguageLevelDTO LanguageLevel { get; set; }
        public bool AdminView { get; set; }
    }
}
