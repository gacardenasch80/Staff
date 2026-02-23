using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class JobTechnicalAbility
    {
        public int JobTechnicalAbilityId { get; set; }
        public string Discipline { get; set; }
        public string DisciplineEnglish { get; set; }

        public ICollection<Job_JobTechnicalAbility> Job_JobTechnicalAbilities { get; set; }
    }
}
