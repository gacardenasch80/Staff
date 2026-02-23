namespace CandidatesMS.Persistence.Entities
{
    public class CVHiring
    {
        public int CVHiringId { get; set; }

        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }

        public string UploadDate { get; set; }
        public string CvIdentifier { get; set; }
        public string CvIdentifierLink { get; set; }
        public string Name { get; set; }
        public string NameMemberUser { get; set; }
        public string SurnameMemberUser { get; set; }
        public string EmailMemberUser { get; set; }
        public bool OverViewCv { get; set; }

        public int CompanyUserId { get; set; }
        public int HiringId { get; set; }

        public double Weight { get; set; }
        public string Hash { get; set; }

        public bool IsFromCandidate { get; set; }

        /* One FileType, Many Attached Files */
        public FileTypeHiring FileTypeHiring { get; set; }
        public int FileTypeHiringId { get; set; }
    }
}
