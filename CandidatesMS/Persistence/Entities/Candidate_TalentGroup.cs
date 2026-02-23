namespace CandidatesMS.Persistence.Entities
{
    public class Candidate_TalentGroupAux
    {
        public int Candidate_TalentGroupAuxId { get; set; }
        public int TalentGroupId { get; set; }
        public int CompanyUserId { get; set; }
        public int TalentGroupStatusId { get; set; }
        public int TalentGroupPostingStatusId { get; set; }

        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }
    }
}
