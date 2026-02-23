namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Job_OtherLanguage
    {
        public int Job_OtherLanguageId { get; set; }

        public int? JobId { get; set; }
        public Job Job { get; set; }

        public int? JobLanguageLevelId { get; set; }
        public JobLanguageLevel JobLanguageLevel { get; set; }
        public string Language { get; set; }
    }
}
