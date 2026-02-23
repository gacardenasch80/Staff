using System.Collections.Generic;
using System;

namespace CandidatesMS.ModelsCompany
{
    public class PostulationQuestionsAnswersDTO
    {
        public int PostulationId { get; set; }
        public int CandidateId { get; set; }

        public DateTime PostulationDate { get; set; }

        public int JobId { get; set; }
        public string JobName { get; set; }
        public string PostulationInfo { get; set; }
        public string PostulationInfoEnglish { get; set; }
        public string PostulationToltip { get; set; }
        public string PostulationToltipEnglish { get; set; }

        public int? CompanyUserId { get; set; }

        public bool AcceptResponses { get; set; }

        public List<QuestionDTO> Questions { get; set; }
    }
}
