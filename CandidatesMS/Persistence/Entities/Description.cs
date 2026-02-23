namespace CandidatesMS.Persistence.Entities
{
    public class Description
    {
        public int DescriptionId { get; set; }
        public string DescriptionGuid { get; set; }
        public string Text { get; set; }
        /* One Candidate, One Description */
        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }
        public string EditionDate { get; set; }

    }
}
