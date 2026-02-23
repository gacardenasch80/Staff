using System.Collections.Generic;
using System;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Event
    {
        public int EventId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartTime { get; set; }
        public string EndingTime { get; set; }
        public int CandidateId { get; set; }
        public string EmailMemberUser { get; set; }
        public int CompanyUserId { get; set; }
        public int MemberUserId { get; set; }
        public string? Location { get; set; }
        public string? Note { get; set; }
        public string? PrivateNote { get; set; }

        public int DurationId { get; set; }
        public Duration Duration { get; set; }
        public int EventTypeId { get; set; }
        public EventType EventType { get; set; }
        public int TimeZoneEventId { get; set; }
        public TimeZoneEvent TimeZoneEvent { get; set; }

        public string UID { get; set; }

        public int CalendarEventId { get; set; }

        public ICollection<Event_MemberUser> Event_MemberUser { get; set; }
    }
}
