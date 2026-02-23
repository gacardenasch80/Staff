using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Entities
{
    public class MentionMemberUser
    {
        public int MentionMemberUserId { get; set; }            
        public int MemberId { get; set; }

        /* MentionMemberUser -  Notes */
        public Note Note { get; set; }
        public int NoteId { get; set; }
    }
}
