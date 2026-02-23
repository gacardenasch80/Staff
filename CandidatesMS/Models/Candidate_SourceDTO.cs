namespace CandidatesMS.Models
{
    public class Candidate_SourceDTO
    {
        public int Candidate_SourceId { get; set; }
        public int CandidateId { get; set; }
        public int? CompanyUserId { get; set; }
        public int SourceId { get; set; }
        public string Name { get; set; }
    }
}
