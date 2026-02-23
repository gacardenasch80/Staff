using System.Collections.Generic;

namespace CandidatesMS.Persistence.Entities
{
    public class RemoteMail
    {
        public int RemoteMailId { get; set; }
        public string Subject { get; set; }
        public string MailDescription { get; set; }
        public string CreationDate { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public string MailOwnerId { get; set; }
        public int CompanyUserId { get; set; }

        public string MessageId { get; set; }

        public ICollection<AttachedFileRemoteMail> AttachedFilesRemoteMail { get; set; }
        public ICollection<CCRemote> CC { get; set; }
        public ICollection<CCORemote> CCO { get; set; }
    }
}
