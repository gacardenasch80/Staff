using System.Collections.Generic;
using System;
using CandidatesMS.Models;

namespace CandidatesMS.ModelsCompany
{
    public class PostulationDTO
    {
        public int PostulationId { get; set; }
        public int CandidateId { get; set; }
        public string CandidateEmail { get; set; }
        public DateTime PostulationDate { get; set; }
        public DateTime PostulationBlockDate { get; set; }
        public string BlockDate { get; set; }
        public string BlockDatePup { get; set; }
        public int? BlockReasonId { get; set; }
        public BlockReasonDTO BlockReason { get; set; }
        public int JobId { get; set; }
        public JobListsDTO Job { get; set; }
        public int PostulationStageId { get; set; }
        public PostulationStageDTO PostulationStage { get; set; }
        public CandidateDTO Candidate { get; set; }
        public bool SendMail { get; set; }
        public int DisqualificationReasonId { get; set; }
        public string DisqualificationReason { get; set; }
        public bool IsCreatedByCandidate { get; set; }
        public bool IsLiked { get; set; }
        public bool IsNew { get; set; }

        public string TextState { get; set; }
        public int TextColor { get; set; }

        public int ColourFlag { get; set; }
        public DateTime CreationDateLastEvaluation { get; set; }
        public string PercentResumeFormat { get; set; }

        public int? CompanyUserId { get; set; }

        public bool AcceptResponses { get; set; }

        public List<AnswerDTO> Answers { get; set; }
    }
}
