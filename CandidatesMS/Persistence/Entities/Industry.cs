using System.Collections.Generic;

namespace CandidatesMS.Persistence.Entities
{
    public class Industry
    {
        public int IndustryId { get; set; }
        public string IndustryGuid { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }
        /* One Industry -  Many Work Experiencies */
        public ICollection<WorkExperience> WorkExperienceList { get; set; }
    }
}
