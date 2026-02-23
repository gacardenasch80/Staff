using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class JobEducationLevel
    {
        public int JobEducationLevelId { get; set; }
        public string EducationLevel { get; set; }
        public string EducationLevelEnglish { get; set; }

        public List<Job> Job { get; set; }
    }
}
