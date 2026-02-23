using System.Collections.Generic;

namespace CandidatesMS.Persistence.Entities
{
    public class JobProfession
    {
        public int JobProfessionId { get; set; }
        public string Profession { get; set; }
        public string ProfessionEnglish { get; set; }

        public ICollection<Study> Studies { get; set; }
    }
}
