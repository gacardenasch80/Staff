using System.Collections.Generic;
using System;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Postulation
    {
        public int PostulationId { get; set; }
        public int CandidateId { get; set; }
        public DateTime PostulationDate { get; set; }
        public DateTime PostulationBlockDate { get; set; }
        public int? BlockReasonId { get; set; }
        public BlockReason BlockReason { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int DisqualificationReasonId { get; set; }
        public int PostulationStageId { get; set; }
        public int LastPostulationStageId { get; set; }
        public bool IsLiked { get; set; }
        public bool IsNew { get; set; }
        public PostulationStage PostulationStage { get; set; }

        public bool IsCreatedByCandidate { get; set; }
        public int? CompanyUserId { get; set; }

        public bool AcceptResponses { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
