namespace CandidatesMS.ModelsCompany
{
    public class Job_OtherTechnicalAbilityDTO
    {
        public int Job_OtherTechnicalAbilityId { get; set; }
        public int JobId { get; set; }
        public int JobTechnicalAbilityLevelId { get; set; }
        public JobTechnicalAbilityLevelDTO JobTechnicalAbilityLevel { get; set; }
        public string TechnicalAbility { get; set; }
    }
}
