using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class JobProfession
    {
        public int JobProfessionId { get; set; }
        public string Profession { get; set; }
        public string ProfessionEnglish { get; set; }

        //public List<Job_JobProfession> Job_JobProfession { get; set; }
    }
}
