using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class MaritalStatusCompanyDTO
    {
        public int? MaritalStatusCompanyId { get; set; }
        public string MaritalStatusGuid { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }
        public int MaritalStatusId { get; set; }
        public int? CandidateId { get; set; }

    }
}
