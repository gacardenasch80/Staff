namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Job_OtherTechnicalAbility
    {
        public int Job_OtherTechnicalAbilityId { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int JobTechnicalAbilityLevelId { get; set; }
        public JobTechnicalAbilityLevel JobTechnicalAbilityLevel { get; set; }
        public string TechnicalAbility { get; set; }
    }
}
