using System.Collections.Generic;

namespace CandidatesMS.Models
{
    public class LanguageOtherDTO
    {
        public int LanguageOtherId { get; set; }
        public string LanguageOtherGuid { get; set; }
        public string LanguageOtherName { get; set; }
        public int CandidateId { get; set; }
        public ICollection<Candidate_LanguageDTO> Candidate_Language { get; set; }
    }
}
