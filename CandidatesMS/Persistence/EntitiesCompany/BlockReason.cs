using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class BlockReason
    {
        public int BlockReasonId { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public int CompanyUserId { get; set; }
        public List<Candidate_BlockReason> Candidate_BlockReasons { get; set; }
    }
}
