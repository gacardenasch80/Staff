using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Entities
{
    public class AttachedFileRemoteMail
    {
        public int AttachedFileRemoteMailId { get; set; }
        public string Name { get; set; }
        public string FileIdentifier { get; set; }
        public string UploadDate { get; set; }

        public string NameMemberUser { get; set; }
        public string SurnameMemberUser { get; set; }
        public string EmailMemberUser { get; set; }

        public int RemoteMailId { get; set; }
        public RemoteMail RemoteMail { get; set; }
    }
}
