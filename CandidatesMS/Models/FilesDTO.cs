using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class FilesDTO
    {
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public string Name { get; set; }
        public string Identifier { get; set; }
        public string IdentifierLink { get; set; }
        public int FileTypeId { get; set; }
        public string FileType { get; set; }
        public string uploaderName { get; set; }
        public string uploadDate { get; set; }
        public string uploadDateEnglish { get; set; }
        public string CreationInfoPup { get; set; }
        public string CreationInfoPupEnglish { get; set; }
        public string CreationShortInfo { get; set; }
        public string Initials { get; set; }
        public string Photo { get; set; }
        public string NameMember { get; set; }
        public string NameMemberUser { get; set; }
        public string SurnameMemberUser { get; set; }
        public string EmailMemberUser { get; set; }
        public bool MemberDeleted { get; set; }
        public string Hash { get; set; }
        public string SizeKb { get; set; }
    }
}
