namespace CandidatesMS.Models.RemoteModels.In
{
    public class ListIntCandidateWithTagDTO
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public CandidateIdAndTagResponseDTO obj { get; set; }
    }
}
