using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class JobLanguage
    {
        public int JobLanguageId { get; set; }
        public string Language { get; set; }
        public string LanguageEnglish { get; set; }

        public ICollection<Job_JobLanguage> Job_JobLanguages { get; set; }
    }
}
