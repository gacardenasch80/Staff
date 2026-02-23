using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class SourceInDTO
    {
        public int SourceId { get; set; }
        public string Name { get; set; }
        public int SourceCount { get; set; }
        public int CompanyUserId { get; set; }
    }
}
