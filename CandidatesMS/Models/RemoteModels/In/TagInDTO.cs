using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class TagInDTO
    {
        public int TagId { get; set; }
        public string Name { get; set; }
        public int TagCount { get; set; }
        public int CompanyUserId { get; set; }
    }
}
