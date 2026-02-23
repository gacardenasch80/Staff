using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }

        public bool IsMandatory { get; set; }

        public int QuestionTypeId { get; set; }
        public QuestionType QuestionType { get; set; }

        public int JobId { get; set; }
        public Job Job { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
