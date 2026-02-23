namespace CandidatesMS.ModelsCompany
{
    public class Job_OtherLenguageDTO
    {
        public int Job_OtherLenguageId { get; set; }
        public int JobId { get; set; }
        public int OtherLanguageId { get; set; }
        public int JobLanguageLevelId { get; set; }
        public JobLanguageLevelDTO JobLanguageLevel { get; set; }
        public string Language { get; set; }
    }
}
