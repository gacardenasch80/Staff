using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandidatesMS.Persistence.Entities
{
    public class Candidate_SoftSkill
    {
        public int Candidate_SoftSkillId { get; set; }
        public string Candidate_SoftSkillGuid { get; set; }
        public string Description { get; set; }
        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }
        public SoftSkill SoftSkill { get; set; }        
        public int SoftSkillId { get; set; }

        public bool IsFromEmpresaAdded { get; set; }
        public int CompanyUserId { get; set; }

    }
}
