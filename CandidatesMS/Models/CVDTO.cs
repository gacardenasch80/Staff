using Microsoft.AspNetCore.Http;

namespace CandidatesMS.Models
{
    public class CVDTO
    {
        public int CVId { get; set; }

        public int CandidateId { get; set; }

        public string UploadDate {get;set;}

        public string CvIdentifier { get; set; }
        public string CvIdentifierLink { get; set; }

        public string Name { get; set; }

        public string NameMemberUser { get; set; }
        public string SurnameMemberUser { get; set; }
        public string EmailMemberUser { get; set; }

        public bool OverViewCv { get; set; }

        public IFormFile FormFile { get; set; }

        public bool IsFromCandidate { get; set; }

        public int CompanyUserId { get; set; }
    }
}
