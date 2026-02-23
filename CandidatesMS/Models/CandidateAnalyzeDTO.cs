using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class CandidateAnalyzeDTO
    {
        public List<IFormFile> files { get; set; }
        public List<int> jobs { get; set; }
        public List<int> talentGroups { get; set; }
        public int numberPages { get; set; }
        public string emailMemberUser { get; set; }
    }
}
