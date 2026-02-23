namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Answer
    {
        public int AnswerId { get; set; }

        public string Text { get; set; }

        public bool YesNoResponse { get; set; }

        public string VideoURL { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }

        public int PostulationId { get; set; }
        public Postulation Postulation { get; set; }
    }
}
