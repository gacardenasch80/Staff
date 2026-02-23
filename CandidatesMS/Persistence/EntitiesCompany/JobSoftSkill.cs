using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class JobSoftSkill
    {
        public int JobSoftSkillId { get; set; }
        public string SoftSkillName { get; set; }
        public string SoftSkillNameEnglish { get; set; }
        public ICollection<Job_JobSoftSkill> Job_JobSoftSkills { get; set; }
    }
}
