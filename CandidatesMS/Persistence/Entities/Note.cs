using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Entities
{
    public class Note
    {
        public int NoteId { get; set; }
        public string NoteDescription { get; set; }       
        public int MemberId { get; set; }
        public string NameMemberUser { get; set; }
        public string SurnameMemberUser { get; set; }
        public string CreationDate { get; set; }
        public string FileName { get; set; }
        public string FileIdentifier { get; set; }
        public string FileUploadDate { get; set; }
        public string EmailMember { get; set; }
        public bool PinUp { get; set; }
        public bool Available { get; set; }
        public DateTime? DatePinUp { get; set; }
        public int? NoteOwnerId { get; set; }

        /* One Note -  Candidates */
        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }

        /* One (Note), Many MentionMemberUser */
        public ICollection<MentionMemberUser> MentionMemberUsers { get; set; }

        public int CompanyUserId { get; set; }
    }
}
