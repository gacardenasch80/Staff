using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class AnalyzeDTO
    {
        
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Facebook { get; set; }
        public string Twitter { get; set; }
        public string LinkedIn { get; set; }
        public string GitHub { get; set; }
        public string BitBucket { get; set; }
        public string FileName { get; set; }
        public string UrlCV { get; set; }
        public bool Exists { get; set; }
        public int CandidateId { get; set; }
    }
}
