namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Job_JobTechnicalAbility
    {
        public int Job_JobTechnicalAbilityId { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int JobTechnicalAbilityId { get; set; }
        public JobTechnicalAbility JobTechnicalAbility { get; set; }

        public int JobTechnicalAbilityLevelId { get; set; }
        public JobTechnicalAbilityLevel JobTechnicalAbilityLevel { get; set; }
    }
}
