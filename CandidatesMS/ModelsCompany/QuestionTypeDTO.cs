using System.Collections.Generic;

namespace CandidatesMS.ModelsCompany
{
    public class QuestionTypeDTO
    {
        public int QuestionTypeId { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public List<QuestionDTO> Questions { get; set; }
    }
}
