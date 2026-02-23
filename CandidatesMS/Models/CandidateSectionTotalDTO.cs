using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class CandidateSectionTotalDTO
    {
        public List<CandidateSectionDTO> CandidateSectionList { get; set; }
        public int TotalCandidates { get; set; }
    }
}
