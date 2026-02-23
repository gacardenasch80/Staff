namespace CandidatesMS.Persistence.Entities
{
    public class CV
    {
        public int CVId { get; set; }
        public string CVGuid { get; set; }

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

        public FileType FileType { get; set; }
        public int FileTypeId { get; set; }

        public bool IsFromCandidate { get; set; }

        public int CompanyUserId { get; set; }
    }
}
