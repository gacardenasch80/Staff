using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class ChangeLinkDTO
    {
        public int CandidateId { get; set; }
        public string GitHubURL { get; set; }
        public string BitBucketURL { get; set; }
    }
}
