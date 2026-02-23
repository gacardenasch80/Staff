using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models.RemoteModels.Out
{
    public class MailSendOutDTO
    {
        public string Subject { get; set; }
        public string Description { get; set; }
        public string EmailMember { get; set; }
        public string EmailCandidate { get; set; }
        public string CreatorName { get; set; }
        public string CandidateName { get; set; }
        public List<IFormFile> FormFile { get; set; }
    }
}
