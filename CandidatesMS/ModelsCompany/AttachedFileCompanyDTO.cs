using Microsoft.AspNetCore.Http;

namespace CandidatesMS.ModelsCompany
{
    public class AttachedFileCompanyDTO
    {
        public int AttachedFileCompanyId { get; set; }
        public string Name { get; set; }
        public string FileIdentifier { get; set; }
        public int JobId { get; set; }
        public string UploadDate { get; set; }
        public IFormFile FormFile { get; set; }

        public string NameMemberUser { get; set; }
        public string SurnameMemberUser { get; set; }
        public string EmailMemberUser { get; set; }
    }
}
