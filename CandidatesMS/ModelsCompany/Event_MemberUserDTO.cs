namespace CandidatesMS.ModelsCompany
{
    public class Event_MemberUserDTO
    {
        public int Event_MemberUserId { get; set; }

        public int EventId { get; set; }
        public int MemberUserId { get; set; }

        public MemberUserOutDTO MemberUser { get; set; }
    }
}
