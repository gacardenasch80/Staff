namespace CandidatesMS.ModelsCompany
{
    public class Job_JobSoftSkillDTO
    {
        public int Job_JobSoftSkillId { get; set; }
        public int JobId { get; set; }
        public int JobSoftSkillId { get; set; }
        public string Name { get; set; }
        public JobSoftSkillDTO JobSoftSkill { get; set; }
    }
}
