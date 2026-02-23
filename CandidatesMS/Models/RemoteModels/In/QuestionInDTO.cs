using System.Collections.Generic;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class QuestionInDTO
    {
        public int questionId { get; set; }
        public string text { get; set; }

        public bool isMandatory { get; set; }

        public int questionTypeId { get; set; }

        public int jobId { get; set; }

        public List<AnswerInDTO> answers { get; set; }
    }
}
