using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Entities
{
    public class LanguageLevel
    {
        public int LanguageLevelId { get; set; }
        public string LanguageLevelGuid { get; set; }
        public string LanguageLevelName { get; set; }
        public string LanguageLevelNameEnglish { get; set; }

        public ICollection<Candidate_Language> Candidate_Language { get; set; }
        public ICollection<Candidate_LanguageOther> Candidate_LanguageOther { get; set; }
    }
}
