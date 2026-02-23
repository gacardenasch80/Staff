using System.Collections.Generic;

namespace CandidatesMS.Persistence.Entities
{
    public class DocumentCheckGroup
    {
        public int DocumentCheckGroupId { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public ICollection<DocumentCheck> DocumentCheks { get; set; }
    }
}
