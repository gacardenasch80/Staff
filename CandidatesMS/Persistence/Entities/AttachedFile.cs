using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Entities
{
    public class AttachedFile
    {
        public int AttachedFileId { get; set; }
        public string Name { get; set; }
        public string FileIdentifier { get; set; }
        public int CandidateId { get; set; }
        public string UploadDate { get; set; }

        public string NameMemberUser { get; set; }
        public string SurnameMemberUser { get; set; }
        public string EmailMemberUser { get; set; }
        public int CompanyUserId { get; set; }

        public string OtherName { get; set; }


        /* One FileType, Many Attached Files */
        public FileType FileType { get; set; }
        public int FileTypeId { get; set; }

    }
}
