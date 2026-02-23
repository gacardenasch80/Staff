namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Candidate_TalentGroup
    {
        public int Candidate_TalentGroupId { get; set; }
        public int CandidateId { get; set; }
        public int TalentGroupId { get; set; }
        public TalentGroup TalentGroup { get; set; }

        public int CompanyUserId { get; set; }
    }
}
