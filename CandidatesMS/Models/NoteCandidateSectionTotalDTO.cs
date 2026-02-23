using System.Collections.Generic;

namespace CandidatesMS.Models
{
    public class NoteCandidateSectionTotalDTO
    {
        public List<NoteSectionDTO> CandidateSectionList { get; set; }
        public int TotalNotes { get; set; }
    }
}
