using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Entities
{
    public class RelationType
    {
        public int RelationTypeId { get; set; }
        public string RelationTypeGuid { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }
        public ICollection<PersonalReference> PersonalReferenceList { get; set; }
    }
}
