using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class AttachedFileMailDTO
    {
        public int AttachedFileMailId { get; set; }
        public string Name { get; set; }
        public string FileIdentifier { get; set; }
        public int CandidateId { get; set; }
        public string UploadDate { get; set; }

        public string NameMemberUser { get; set; }
        public string SurnameMemberUser { get; set; }
        public string EmailMemberUser { get; set; }
        public int CompanyUserId { get; set; }
    }
}
