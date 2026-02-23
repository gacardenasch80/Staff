namespace CandidatesMS.Models.RemoteModels.In
{
    public class AnswerInDTO
    {
        public int answerId { get; set; }

        public string text { get; set; }

        public bool yesNoResponse { get; set; }

        public string videoURL { get; set; }

        public int questionId { get; set; }

        public int postulationId { get; set; }
    }
}
