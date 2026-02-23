using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class JobTechnicalAbilityLevel
    {
        public int JobTechnicalAbilityLevelId { get; set; }
        public string Level { get; set; }
        public string LevelEnglish { get; set; }

        public ICollection<Job_JobTechnicalAbility> Job_JobTechnicalAbility { get; set; }
        public ICollection<Job_OtherTechnicalAbility> Job_OtherTechnicalAbility { get; set; }
    }
}
