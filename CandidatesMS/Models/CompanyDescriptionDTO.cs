namespace CandidatesMS.Models
{
    public class CompanyDescriptionDTO
    {
        public int CompanyDescriptionId { get; set; }
        public string Text { get; set; }
        public string YearsExperience { get; set; }
        public string NumberCompanies { get; set; }

        public int CompanyUserId { get; set; }

        public int CandidateId { get; set; }
    }
}
