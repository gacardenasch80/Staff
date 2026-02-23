using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Entities
{
    public class CandidateRecruitee
    {
        public int CandidateRecruiteeId { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool FullData { get; set; }
        public string CreationDate { get; set; }
    }
}
