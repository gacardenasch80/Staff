using System.Collections.Generic;

namespace CandidatesMS.ModelsCompany
{
    public class QuestionDTO
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }

        public bool IsMandatory { get; set; }

        public int QuestionTypeId { get; set; }

        public int JobId { get; set; }

        public List<AnswerDTO> Answers { get; set; }
    }
}
