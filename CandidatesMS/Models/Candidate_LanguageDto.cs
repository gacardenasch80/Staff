namespace CandidatesMS.Models
{
    public class Candidate_LanguageDTO
    {
        public int Candidate_LanguageId { get; set; }
        public string Candidate_LanguageGuid { get; set; }

        public CandidateDTO Candidate { get; set; }
        public int CandidateId { get; set; }
        public LanguageDTO Language { get; set; }
        public int LanguageId { get; set; }
        public LanguageLevelDTO LanguageLevel { get; set; }
        public int LanguageLevelId { get; set; }

        public string LanguageOtherName { get; set; }
        public bool AdminView { get; set; }
    }
}
