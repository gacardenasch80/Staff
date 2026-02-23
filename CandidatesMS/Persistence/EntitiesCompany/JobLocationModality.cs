using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class JobLocationModality
    {
        public int JobLocationModalityId { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public List<Job> Jobs { get; set; }
    }
}
