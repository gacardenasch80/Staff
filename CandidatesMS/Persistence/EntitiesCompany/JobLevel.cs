using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class JobLevel
    {
        public int JobLevelId { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public List<Job> Job { get; set; }
        public List<JobSubLevel> JobSubLevels { get; set; }
    }
}
