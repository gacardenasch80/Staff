using System.Collections.Generic;

namespace CandidatesMS.Models
{
    public class LanguageDTO
    {
        public int LanguageId { get; set; }
        public string LanguageGuid { get; set; }
        public string LanguageName { get; set; }
        public string LanguageNameEnglish { get; set; }

        public ICollection<Candidate_LanguageDTO> Candidate_Language { get; set; }
    }
}
