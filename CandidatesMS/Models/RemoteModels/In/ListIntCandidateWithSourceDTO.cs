namespace CandidatesMS.Models.RemoteModels.In
{
    public class ListIntCandidateWithSourceDTO
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public CandidateIdAndSourceResponseDTO obj { get; set; }
    }
}
