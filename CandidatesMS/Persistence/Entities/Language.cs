using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Entities
{
    public class Language
    {
        public int LanguageId { get; set; }
        public string LanguageGuid { get; set; }
        public string LanguageName { get; set; }
        public string LanguageNameEnglish { get; set; }

        public ICollection<Candidate_Language> Candidate_Language { get; set; }
    }
}
