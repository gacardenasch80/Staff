using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Duration
    {
        public int DurationId { get; set; }
        public string DurationName { get; set; }
        public string DurationNameEnglish { get; set; }

        public ICollection<Event> Event { get; set; }
    }
}
