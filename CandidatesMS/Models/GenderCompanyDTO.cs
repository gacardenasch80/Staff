using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class GenderCompanyDTO
    {
        public int? GenderCompanyId { get; set; }
        public string GenderGuid { get; set; }
        public string Name { get; set; }        
        public int GenderId { get; set; }
        public int? CandidateId { get; set; }
    }
}
