using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class MailDTO
    {
        public int MailId { get; set; }
        public string Subject { get; set; }
        public string MailDescription { get; set; }        
        public string EmailMember { get; set; }
        public string NameMemberUser { get; set; }
        public string SurnameMemberUser { get; set; }
        public bool DeleteMember { get; set; }

        public string FromPrefix { get; set; }
        public string ToPrefix { get; set; }

        public string From { get; set; }
        public string To { get; set; }

        public string InitialsFrom { get; set; }
        public string CreationDate { get; set; }
        public string CreationInfo { get; set; }        
        public string CreationInfoPup { get; set; }
        public string Photo { get; set; }
        public int MailOwnerId { get; set; }
        public int CompanyUserId { get; set; }
        public int CandidateId { get; set; }

        public string EmailCandidate { get; set; }
        public string MessageId { get; set; }

        public List<IFormFile> FormFile { get; set; }

        public List<CCDTO> CC { get; set; }
        public List<CCODTO> CCO { get; set; }

        public List<LinkAndNameDTO> AttachedFilesString { get; set; }
        public List<AttachedFileMailDTO> AttachedFilesMail { get; set; }



        public List<string> CCOString { get; set; }
        public List<string> CCString { get; set; }

        public List<MailDTO> MailsChildren { get; set; }
    }
}
