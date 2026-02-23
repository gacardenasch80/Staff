using CandidatesMS.Models.RemoteModels.In;
using System.Collections.Generic;
using System;

namespace CandidatesMS.ModelsCompany
{
    public class EventOverViewDTO
    {
        public int EventId { get; set; }
        public DateTime StartDate { get; set; }
        public bool CreatedEvent { get; set; }
        public string StartTime { get; set; }
        public string EndingTime { get; set; }
        public int CandidateId { get; set; }
        public int CompanyUserId { get; set; }
        public string? Location { get; set; }
        public string? Note { get; set; }
        public string? PrivateNote { get; set; }
        public string EmailMemberUser { get; set; }
        public string Summary { get; set; }

        public string CandidateName { get; set; }

        public string CandidateInitials { get; set; }
        public string CandidatePhoto { get; set; }
        public PostulationDTO Postulation { get; set; }
        public Candidate_TGDTO TalentGroup { get; set; }
        public int DurationId { get; set; }
        public DurationDTO Duration { get; set; }
        public int EventTypeId { get; set; }
        public EventTypeDTO EventType { get; set; }
        public int TimeZoneEventId { get; set; }
        public TimeZoneEventDTO TimeZoneEvent { get; set; }
        public ICollection<Event_MemberUserDTO> Event_MemberUser { get; set; }

        public int CalendarEventId { get; set; }
    }
}
