namespace CandidatesMS.Models.RemoteModels.In
{
    public class Event_MemberUserInDTO
    {
        public int event_MemberUserId { get; set; }

        public int memberUserId { get; set; }
        public MemberUserInDTO memberUser { get; set; }
    }
}
