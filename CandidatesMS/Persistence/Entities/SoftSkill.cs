using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Entities
{
    public class SoftSkill
    {
        public int SoftSkillId { get; set; }
        public string SoftSkillName { get; set; }
        public string SoftSkillNameEnglish { get; set; }

        public ICollection<Candidate_SoftSkill> Candidate_SoftSkill { get; set; }
    }
}
