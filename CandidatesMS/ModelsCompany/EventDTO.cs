using System.Collections.Generic;
using System;

namespace CandidatesMS.ModelsCompany
{
    public class EventDTO
    {
        public int EventId { get; set; }
        public string DateInitial { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string StartTime { get; set; }
        public string EndingTime { get; set; }
        public int CandidateId { get; set; }
        public string EmailMemberUser { get; set; }
        public int CompanyUserId { get; set; }
        public int MemberUserId { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string? Note { get; set; }
        public string? PrivateNote { get; set; }

        public int DurationId { get; set; }
        public DurationDTO Duration { get; set; }
        public int EventTypeId { get; set; }
        public EventTypeDTO EventType { get; set; }
        public int TimeZoneEventId { get; set; }
        public TimeZoneEventDTO TimeZoneEvent { get; set; }
        public List<int> MemberUserIds { get; set; }

        public bool SendEmailCandidate { get; set; }
        public bool SendEmailInterviewers { get; set; }

        public int CalendarEventId { get; set; }
    }
}
