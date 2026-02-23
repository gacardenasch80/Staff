using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class TimeZoneEvent
    {
        public int TimeZoneEventId { get; set; }
        public string Name { get; set; }
        public string GMT { get; set; }

        public ICollection<Event> Event { get; set; }
    }
}
