namespace CandidatesMS.Models
{
    public class AnalyzeCVQueueDTO
    {
        public int analyzefileid { get; set; }
        public bool isprocessed { get; set; }
        public bool issuccess { get; set; }
        public string parameters { get; set; }
        public string emailmemberuser { get; set; }
        public string namememberuser { get; set; }
        public string surnnamememberuser { get; set; }
        public string creationdate { get; set; }
        public string editiondate { get; set; }
        public string filegroupguid { get; set; }
        public string fileTokenDalitica { get; set; }
    }
}
