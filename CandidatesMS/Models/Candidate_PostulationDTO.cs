namespace CandidatesMS.Models
{
    public class Candidate_PostulationDTO
    {
        public int Candidate_PostulationId { get; set; }
        public int PostulationId { get; set; }
        public int CompanyUserId { get; set; }

        public int JobPostingStatusId { get; set; }
        public int JobId { get; set; }

        public CandidateDTO Candidate { get; set; }
        public int CandidateId { get; set; }
    }
}
