namespace CandidatesMS.ModelsCompany
{
    public class Job_JobTechnicalAbilityDTO
    {
        public int Job_JobTechnicalAbilityId { get; set; }
        public int JobId { get; set; }
        public int JobTechnicalAbilityLevelId { get; set; }
        public JobTechnicalAbilityLevelDTO JobTechnicalAbilityLevel { get; set; }
        public int JobTechnicalAbilityId { get; set; }
        public JobTechnicalAbilityDTO JobTechnicalAbility { get; set; }
    }
}
