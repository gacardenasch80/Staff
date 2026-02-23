namespace CandidatesMS.Persistence.Entities
{
    public class CandidateOrigin
    {
        public int CandidateOriginId { get; set; }
        public int IsMigrated { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }
    }
}
