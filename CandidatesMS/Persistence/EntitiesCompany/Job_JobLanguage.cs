namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Job_JobLanguage
    {
        public int Job_JobLanguageId { get; set; }

        public int? JobId { get; set; }
        public Job Job { get; set; }

        public int? JobLanguageId { get; set; }
        public JobLanguage JobLanguage { get; set; }

        public int? JobLanguageLevelId { get; set; }
        public JobLanguageLevel JobLanguageLevel { get; set; }
    }
}
