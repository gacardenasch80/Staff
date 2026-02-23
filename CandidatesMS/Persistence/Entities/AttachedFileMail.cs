using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Entities
{
    public class AttachedFileMail
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

        public int MailId { get; set; }
        public Mail Mail { get; set; }
    }
}
