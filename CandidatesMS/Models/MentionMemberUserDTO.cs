using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class MentionMemberUserDTO
    {
        public int MentionMemberUserId { get; set; }
        public int MemberId { get; set; }                
        public int NoteId { get; set; }
    }
}
