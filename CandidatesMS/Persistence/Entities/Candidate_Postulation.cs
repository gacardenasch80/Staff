namespace CandidatesMS.Persistence.Entities
{
    public class Candidate_Postulation
    {
        public int Candidate_PostulationId { get; set; }
        public int PostulationId { get; set; }
        public int CompanyUserId { get; set; }


        public int JobPostingStatusId { get; set; }
        public int JobId { get; set; }

        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }
    }
}
