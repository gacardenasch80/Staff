using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class EventType
    {
        public int EventTypeId { get; set; }
        public string EventName { get; set; }
        public string EventNameEnglish { get; set; }

        public ICollection<Event> Event { get; set; }
    }
}
