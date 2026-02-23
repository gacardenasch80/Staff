using System.Collections.Generic;

namespace CandidatesMS.Persistence.Entities
{
    public class DocumentCheckState
    {
        public int DocumentCheckStateId { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public ICollection<DocumentCheck> DocumentCheks { get; set; }
    }
}
