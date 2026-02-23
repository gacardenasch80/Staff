namespace CandidatesMS.Models
{
    public class CandidateNotificationDTO
    {
        public int CandidateId { get; set; }
        public string CandidateGuid { get; set; }

        public string Email { get; set; }
        public bool FullData { get; set; }

        public int CompanyUserId { get; set; }

        public string CreationDate { get; set; }
        public string EditionDate { get; set; }
        public string FirstLoginDate { get; set; }
        public string DeleteDate { get; set; }
        public string LoginCode { get; set; }

        public int IsMigrated { get; set; }
        public bool IsFromCompanyAndLogin { get; set; }
        public string Source { get; set; }
        public bool IsNew { get; set; }
        public bool isAuthorized { get; set; }
        public bool IsDeleteProccess { get; set; }
        public bool IsAuthDocuments { get; set; }
        public bool IsAuthDocumentsHiring { get; set; }

        public string NameMemberUser { get; set; }
        public string SurnameMemberUser { get; set; }
        public string EmailMember { get; set; }
    }
}
