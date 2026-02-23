using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Entities
{
    public class EquivalentPosition
    {
        public int EquivalentPositionId { get; set; }
        public string EquivalentPositionGuid { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }
        /* One EquivalentPosition -  Many Work Experiencies */
        //public ICollection<WorkExperience> WorkExperienceList { get; set; }
    }
}
