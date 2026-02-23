namespace CandidatesMS.ModelsCompany
{
    public class Job_JobLanguageDTO
    {
        public int Job_JobLanguageId { get; set; }
        public int JobId { get; set; }
        public int JobLanguageId { get; set; }
        public int JobLanguageLevelId { get; set; }
        public JobLanguageLevelDTO JobLanguageLevel { get; set; }
        public JobLanguageDTO JobLanguage { get; set; }
    }
}
