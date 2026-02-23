using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class JobLanguageLevel
    {
        public int JobLanguageLevelId { get; set; }
        public string LanguageLevel { get; set; }
        public string LanguageLevelEnglish { get; set; }

        public ICollection<Job_JobLanguage> Job_JobLanguage { get; set; }
        public ICollection<Job_OtherLanguage> Job_OtherLanguage { get; set; }
    }
}
