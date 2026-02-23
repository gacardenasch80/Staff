namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Job_JobSoftSkill
    {
        public int Job_JobSoftSkillId { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int JobSoftSkillId { get; set; }
        public JobSoftSkill JobSoftSkill { get; set; }
        public string Name { get; set; }
    }
}
