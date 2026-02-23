using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class JobExperience
    {
        public int JobExperienceId { get; set; }
        public string Experience { get; set; }
        public string ExperienceEnglish { get; set; }

        public List<Job> Job { get; set; }
    }
}
