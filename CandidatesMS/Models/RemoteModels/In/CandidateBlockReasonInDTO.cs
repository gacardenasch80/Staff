using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class CandidateBlockReasonInDTO
    {
        public int Candidate_BlockReasonId { get; set; }
        public string BlockDate { get; set; }
        public string BlockDatePup { get; set; }
        public int CandidateId { get; set; }
        public int BlockReasonId { get; set; }
        public string BlockReasonName { get; set; }
    }
}
