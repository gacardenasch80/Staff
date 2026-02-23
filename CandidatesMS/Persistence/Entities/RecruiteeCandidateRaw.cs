using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Entities
{
    public class RecruiteeCandidateRaw
    {
        public int RecruiteeCandidateRawId { get; set; }
        public int RecruiteeId { get; set; }
        public string BasicData { get; set; }
        public string  OtherData { get; set; }
        public string Notes { get; set; }
        public string Photo { get; set; }
        public string CV { get; set; }
    }
}
