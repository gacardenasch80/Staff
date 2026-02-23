using System.Collections.Generic;

namespace CandidatesMS.Models
{
    public class MergeCandidatesDTO
    {
        public string MainCandidate { get; set; }
        public List<string> OtherCandidates { get; set; }
    }
}
