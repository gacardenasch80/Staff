namespace CandidatesMS.Persistence.Entities
{
    public class CompanyDescription
    {
        public int CompanyDescriptionId { get; set; }
        public string Text { get; set; }
        public string YearsExperience { get; set; }
        public string NumberCompanies { get; set; }

        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }

        public int CompanyUserId { get; set; }
    }
}
