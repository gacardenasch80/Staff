using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class BlockReasonInDTO
    {
        public int blockReasonId { get; set; }
        public string name { get; set; }
        public string nameEnglish { get; set; }
        public int companyUserId { get; set; }
    }
}
