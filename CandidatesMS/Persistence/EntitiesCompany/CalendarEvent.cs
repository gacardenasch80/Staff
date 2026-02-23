using System;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class CalendarEvent
    {
        public int CalendarEventId { get; set; }

        public string Name { get; set; }
        public string NameEnlgish { get; set; }
        public string UID { get; set; }
        public string Parameters { get; set; }
        public DateTime SyncDate { get; set; }
        public string Icon { get; set; }

        public string Token { get; set; }
        public string RefreshToken { get; set; }

        public MemberUser MemberUser { get; set; }
        public int MemberUserId { get; set; }
    }
}
