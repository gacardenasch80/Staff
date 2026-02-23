using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CandidatesMS.Persistence.Entities
{
    public class TechnicalAbilityLevel
    {
        public int TechnicalAbilityLevelId { get; set; }
        public string Level { get; set; }
        public string LevelEnglish { get; set; }

        public ICollection<Candidate_TechnicalAbility> Candidate_TechnicalAbility { get; set; }
    }
}
