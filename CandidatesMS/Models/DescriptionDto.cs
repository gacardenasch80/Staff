namespace CandidatesMS.Models
{
    public class DescriptionDTO
    {
        public int DescriptionId { get; set; }
        public string DescriptionGuid { get; set; }
        public string Text { get; set; }
        public int CandidateId { get; set; }
        public string CandidateEditionDate { get; set; }
        public string CreationInfo { get; set; }
        public string CreationShortInfo { get; set; }
    }
}
