using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Entities
{
    public class CC
    {
        public int CCId { get; set; }
        public string Email { get; set; }

        public int MailId { get; set; }
        public Mail Mail { get; set; }
    }
}
