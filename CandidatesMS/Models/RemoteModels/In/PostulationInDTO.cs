using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class PostulationInDTO
    {
        public int postulationId { get; set; }
        public int candidateId { get; set; }
        public string candidateEmail { get; set; }
        public DateTime postulationDate { get; set; }
        public DateTime postulationBlockDate { get; set; }
        public string blockDate { get; set; }
        public string blockDatePup { get; set; }
        public int? blockReasonId { get; set; }
        public BlockReasonInDTO blockReason { get; set; }
        public int jobId { get; set; }
        public JobInDTO job { get; set; }
        public int postulationStageId { get; set; }
        public PostulationStageInDTO postulationStage { get; set; }
        public bool sendMail { get; set; }
        public int disqualificationReasonId { get; set; }
        public string disqualificationReason { get; set; }
        public bool isCreatedByCandidate { get; set; }
        public bool isLiked { get; set; }
        public bool isNew { get; set; }

        public int colourFlag { get; set; }
        public DateTime creationDateLastEvaluation { get; set; }
        public string percentResumeFormat { get; set; }

        public string textState { get; set; }
        public int textColor { get; set; }

        public bool acceptResponses { get; set; }

        public List<AnswerInDTO> answers { get; set; }
    }

    public class PostulationInStructureDTO
    {
        public string message { get; set; }
        public List<PostulationInDTO> obj { get; set; }
    }
}
