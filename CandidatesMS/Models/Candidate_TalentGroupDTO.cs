namespace CandidatesMS.Models
{
    public class Candidate_TalentGroupDTO
    {
        public int Candidate_TalentGroupId { get; set; }
        public int TalentGroupId { get; set; }
        public int CompanyUserId { get; set; }
        public int TalentGroupStatusId { get; set; }
        public int TalentGroupPostingStatusId { get; set; }

        public CandidateDTO Candidate { get; set; }
        public int CandidateId { get; set; }
    }
}
