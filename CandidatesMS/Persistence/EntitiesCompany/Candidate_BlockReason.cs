using System;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Candidate_BlockReason
    {
        public int Candidate_BlockReasonId { get; set; }
        
        public int CandidateId { get; set; }
        public int BlockReasonId { get; set; }

        public DateTime CandidateBlockDate { get; set; }
        public BlockReason BlockReason { get; set; }
    }
}
