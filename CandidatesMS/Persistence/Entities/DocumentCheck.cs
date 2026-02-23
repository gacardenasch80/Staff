namespace CandidatesMS.Persistence.Entities
{
    public class DocumentCheck
    {
        public int DocumentCheckId { get; set; }
        public int OrderId { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }
        public bool IsCheck { get; set; }
        public bool IsEnabled { get; set; }
        public string Text { get; set; }

        public int DocumentCheckStateId { get; set; }
        public DocumentCheckState DocumentCheckState { get; set; }

        public int DocumentCheckGroupId { get; set; }
        public DocumentCheckGroup DocumentCheckGroup { get; set; }

        public int CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }

        public int CompanyUserId { get; set; }
    }
}
