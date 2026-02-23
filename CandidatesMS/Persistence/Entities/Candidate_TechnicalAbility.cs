using CandidatesMS.Models.RemoteModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandidatesMS.Persistence.Entities
{
    public class Candidate_TechnicalAbility
    {
        public int Candidate_TechnicalAbilityId { get; set; }
        public string Candidate_TechnicalAbilityGuid { get; set; }
        public string Other { get; set; }

        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }
        public string Discipline { get; set; }
        public TechnicalAbilityTechnology TechnicalAbilityTechnology { get; set; }
        public int TechnicalAbilityTechnologyId { get; set; }
        public TechnicalAbilityLevel TechnicalAbilityLevel { get; set; }
        public int? TechnicalAbilityLevelId { get; set; }

        public bool IsFromEmpresaAdded { get; set; }
        public int CompanyUserId { get; set; }

    }
}
