using Microsoft.AspNetCore.Http;

namespace CandidatesMS.ModelsCompany
{
    public class AnswerDTO
    {
        public int AnswerId { get; set; }

        public string Text { get; set; }

        public bool YesNoResponse { get; set; }

        public string VideoURL { get; set; }
        public IFormFile FormFile { get; set; }

        public int QuestionId { get; set; }

        public int PostulationId { get; set; }

        public int QuestionTypeId { get; set; }
    }
}
