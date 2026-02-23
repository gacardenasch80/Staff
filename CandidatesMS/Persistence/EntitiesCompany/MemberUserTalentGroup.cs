namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class MemberUserTalentGroup
    {
        public int MemberUserTalentGroupId { get; set; }
        public int MemberUserId { get; set; }
        public MemberUser MemberUser { get; set; }
        public int TalentGroupId { get; set; }
        public TalentGroup TalentGroup { get; set; }
    }
}
