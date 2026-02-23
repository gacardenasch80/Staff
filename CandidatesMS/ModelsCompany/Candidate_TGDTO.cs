namespace CandidatesMS.ModelsCompany
{
    public class Candidate_TGDTO
    {
        public int Candidate_TalentGroupId { get; set; }
        public int CandidateId { get; set; }
        public int TalentGroupId { get; set; }
        public int TalentGroupStatusId { get; set; }
        public int TalentGroupPostingStatusId { get; set; }

        public TalentGroupDTO TalentGroup { get; set; }

        public int CompanyUserId { get; set; }
    }
}
