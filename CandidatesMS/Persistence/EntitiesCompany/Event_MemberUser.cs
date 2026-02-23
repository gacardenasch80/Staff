namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Event_MemberUser
    {
        public int Event_MemberUserId { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public int MemberUserId { get; set; }
        public MemberUser MemberUser { get; set; }
    }
}
