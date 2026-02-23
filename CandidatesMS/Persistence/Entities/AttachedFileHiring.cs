namespace CandidatesMS.Persistence.Entities
{
    public class AttachedFileHiring
    {
        public int AttachedFileHiringId { get; set; }

        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }

        public string Name { get; set; }
        public string FileIdentifier { get; set; }
        public string UploadDate { get; set; }

        public string NameMemberUser { get; set; }
        public string SurnameMemberUser { get; set; }
        public string EmailMemberUser { get; set; }

        public int CompanyUserId { get; set; }

        public string OtherName { get; set; }
        public int HiringId { get; set; }

        public double Weight { get; set; }
        public string Hash { get; set; }

        public bool IsUploadedByCandidate { get; set; }

        /* One FileType, Many Attached Files */
        public FileTypeHiring FileTypeHiring { get; set; }
        public int FileTypeHiringId { get; set; }
    }
}
