using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Entities
{
    public class Mail
    {
        public int MailId { get; set; }
        public string Subject { get; set; }
        public string MailDescription { get; set; }                        
        public string CreationDate { get; set; }
        public string EmailMember { get; set; }
        public string NameMemberUser { get; set; }
        public string SurnameMemberUser { get; set; }
        public int MailOwnerId { get; set; }
        public int CompanyUserId { get; set; }                

        /* One Note -  Candidates */
        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }

        public string MessageId { get; set; }

        //public List<string> CCString { get; set; }
        //public List<string> CCOString { get; set; }

        public ICollection<AttachedFileMail> AttachedFilesMail { get; set; }
        public ICollection<CC> CC { get; set; }
        public ICollection<CCO> CCO { get; set; }
    }
}
