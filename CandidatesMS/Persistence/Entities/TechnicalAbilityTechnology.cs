using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CandidatesMS.Persistence.Entities
{
    public class TechnicalAbilityTechnology
    {
        public int TechnicalAbilityTechnologyId { get; set; }
        public string Discipline { get; set; }
        public string DisciplineEnglish { get; set; }
        public string Technology { get; set; }
        public string TechnologyEnglish { get; set; }

        public ICollection<Candidate_TechnicalAbility> Candidate_TechnicalAbility { get; set; }
    }
}
