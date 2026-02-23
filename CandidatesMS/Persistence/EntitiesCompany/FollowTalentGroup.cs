namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class FollowTalentGroup
    {
        public int FollowTalentGroupId { get; set; }
        public int TalentGroupId { get; set; }
        public TalentGroup TalentGroup { get; set; }
        public int MemberUserId { get; set; }
        public MemberUser MemberUser { get; set; }
    }
}
