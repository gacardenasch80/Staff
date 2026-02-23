using System.Collections.Generic;

namespace CandidatesMS.Models
{
    public class DocumentCheckGroupDTO
    {
        public int DocumentCheckGroupId { get; set; }

        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public List<DocumentCheckDTO> DocumentCheckItems { get; set; }
    }
}
