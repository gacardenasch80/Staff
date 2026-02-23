namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class ICS
    {
        public int ICSId { get; set; }
        public int MemberUserId { get; set; }
        public MemberUser MemberUser { get; set; }
    }
}
