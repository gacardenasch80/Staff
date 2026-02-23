using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class QuestionType
    {
        public int QuestionTypeId { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public ICollection<Question> Questions { get; set; }
    }
}
