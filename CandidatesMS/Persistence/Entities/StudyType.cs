using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Entities
{
    public class StudyType
    {
        public int StudyTypeId { get; set; }
        public string StudyTypeGuid { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }
        public ICollection<Study> StudyList { get; set; }
    }
}
