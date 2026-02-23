namespace CandidatesMS.Models
{
    public class Candidate_TechnicalAbilityDTO
    {
        public int Candidate_TechnicalAbilityId { get; set; }
        public string Candidate_TechnicalAbilityGuid { get; set; }
        public string Other { get; set; }
        public int CandidateId { get; set; }
        public string Discipline { get; set; }
        public string TechnicalAbilityTechnologyName { get; set; }
        public int TechnicalAbilityTechnologyId { get; set; }
        public TechnicalAbilityTechnologyDTO TechnicalAbilityTechnology { get; set; }
        public TechnicalAbilityLevelDTO TechnicalAbilityLevel { get; set; }
        public int? TechnicalAbilityLevelId { get; set; }
        public bool IsFromEmpresaAdded { get; set; }
    }
}
