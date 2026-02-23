using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class JobPostingStatus
    {
        public int JobPostingStatusId { get; set; }
        public string Status { get; set; }
        public string StatusEnglish { get; set; }
        public string StatusAction { get; set; }
        public ICollection<Job> Job { get; set; }
    }
}
