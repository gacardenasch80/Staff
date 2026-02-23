using System.Collections.Generic;

namespace CandidatesMS.Models
{
    public class candidateSearchTotalDTO
    {
        public List<candidateSearchDTO> candidates { get; set; }
        public int total { get; set; }
    }
}
