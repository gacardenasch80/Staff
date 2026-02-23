using System.Collections.Generic;
using System;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class PostulationQuestionsAnswersInDTO
    {
        public int postulationId { get; set; }
        public int candidateId { get; set; }

        public DateTime postulationDate { get; set; }

        public int jobId { get; set; }
        public string jobName { get; set; }
        public string postulationInfo { get; set; }
        public string postulationInfoEnglish { get; set; }
        public string postulationToltip { get; set; }
        public string postulationToltipEnglish { get; set; }

        public int? companyUserId { get; set; }

        public bool acceptResponses { get; set; }

        public List<QuestionInDTO> questions { get; set; }
    }

    public class PostulationQuestionsAnswersInStructureDTO
    {
        public string message { get; set; }
        public List<PostulationQuestionsAnswersInDTO> obj { get; set; }
    }
}
