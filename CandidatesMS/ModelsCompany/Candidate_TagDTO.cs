namespace CandidatesMS.ModelsCompany
{
    public class Candidate_TagDTO
    {
        public int Candidate_TagId { get; set; }
        public int CandidateId { get; set; }
        public int? CompanyUserId { get; set; }
        public int TagId { get; set; }
        public string Name { get; set; }
    }
}
