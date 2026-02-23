namespace CandidatesMS.Models
{
    public class Candidate_SoftSkillDTO
    {
        public int Candidate_SoftSkillId { get; set; }
        public string Candidate_SoftSkillGuid { get; set; }
        public string Description { get; set; }


        public string SoftSkillName { get; set; }
        public string SoftSkillNameEnglish { get; set; }

        public int CandidateId { get; set; }
        public SoftSkillDTO SoftSkill { get; set; }
        public int SoftSkillId { get; set; }
        public bool IsFromEmpresaAdded { get; set; }
    }
}
