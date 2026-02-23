namespace CandidatesMS.Persistence.Entities
{
    public class AnalyzeCVData
    {
        public int AnalyzeCVDataId { get; set; }
        public int AnalyzeCVId { get; set; }

        public string FileToken { get; set; }

        public string FileIdentifier { get; set; }
        public string FileName { get; set; }
        public int NumberPages { get; set; }

        public bool IsAnalyzed { get; set; }

        public string CreationDate { get; set; }

        public string EmailMember { get; set; }

        public int CompanyUserId { get; set; }
    }
}
