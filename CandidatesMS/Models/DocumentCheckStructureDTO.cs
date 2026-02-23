using System.Collections.Generic;

namespace CandidatesMS.Models
{
    public class DocumentCheckStructureDTO
    {
        public List<DocumentCheckGroupDTO> DocumentCheckGroups { get; set; }

        public int CandidateId { get; set; }
    }
}
