using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace CandidatesMS.Models
{
    public class AttachedFileHiringDTO
    {
        public int AttachedFileHiringId { get; set; }
        public string Name { get; set; }
        public string FileIdentifier { get; set; }
        public string IdentifierLink { get; set; }

        public string UploadDate { get; set; }
        public int CandidateId { get; set; }
        public int FileTypeId { get; set; }
        public IFormFile FormFile { get; set; }

        public string NameMemberUser { get; set; }
        public string SurnameMemberUser { get; set; }
        public string EmailMemberUser { get; set; }
        public int CompanyUserId { get; set; }

        public string OtherName { get; set; }

        public double Weight { get; set; }
        public string Hash { get; set; }

        public bool IsUploadedByCandidate { get; set; }
    }

    public class AttachedFileHiringFormDTO
    {
        public List<IFormFile> Files { get; set; }
        public List<int> Types { get; set; }
        public List<string> Others { get; set; }
        public int CandidateId { get; set; }
        public int HiringId { get; set; }
    }
}
