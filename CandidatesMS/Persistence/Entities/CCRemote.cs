using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Entities
{
    public class CCRemote
    {
        public int CCRemoteId { get; set; }
        public string Email { get; set; }

        public int RemoteMailId { get; set; }
        public RemoteMail RemoteMail { get; set; }
    }
}
