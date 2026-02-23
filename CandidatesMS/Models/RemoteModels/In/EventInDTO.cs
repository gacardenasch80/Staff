using System;
using System.Collections.Generic;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class EventInDTO
    {
        public int eventId { get; set; }
        public DateTime date { get; set; }
        public string startTime { get; set; }
        public string endingTime { get; set; }
        public int candidateId { get; set; }
        public int companyUserId { get; set; }
        public string? location { get; set; }
        public string? note { get; set; }
        public string? privateNote { get; set; }
        public string summary { get; set; }
        public int durationId { get; set; }
        public DurationInDTO duration { get; set; }
        public int eventTypeId { get; set; }
        public EventTypeInDTO eventType { get; set; }
        public int timeZoneEventId { get; set; }
        public TimeZoneEventInDTO timeZoneEvent { get; set; }
        public ICollection<Event_MemberUserInDTO> event_MemberUser { get; set; }
    }

    public class EventResponseDTO
    {
        public string message { get; set; }
        public List<EventInDTO> obj { get; set; }
    }
}
