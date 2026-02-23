namespace CandidatesMS.Persistence.Entities
{
    public class ExperienceCount
    {
        public int ExperienceCountId { get; set; }
        public string Years { get; set; }
        public int CompaniesNumber { get; set; }

        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }
    }
}
