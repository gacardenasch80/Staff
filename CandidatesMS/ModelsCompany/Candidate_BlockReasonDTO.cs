using CandidatesMS.Persistence.EntitiesCompany;
using System;

namespace CandidatesMS.ModelsCompany
{
    public class Candidate_BlockReasonDTO
    {
        public int Candidate_BlockReasonId { get; set; }

        public int CandidateId { get; set; }
        public int BlockReasonId { get; set; }

        public string BlockDate { get; set; }
        public string BlockDatePup { get; set; }
        public string BlockReasonName { get; set; }

        public DateTime CandidateBlockDate { get; set; }
        public BlockReasonDTO BlockReason { get; set; }
    }
}
