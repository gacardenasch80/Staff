namespace CandidatesMS.ModelsCompany
{
    public class PostulationStageDTO
    {
        public int PostulationStageId { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public int PostulationStateId { get; set; }
        public PostulationStateDTO PostulationState { get; set; }
    }
}
