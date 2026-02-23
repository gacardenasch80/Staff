namespace CandidatesMS.Models
{
    public class CandidateAffinityDTO
    {
        public int CandidateId { get; set; }

        public int CompanyUserId { get; set; }

        public string Email { get; set; }
        public string Name { get; set; }

        public double Affinity { get; set; }
    }
}
