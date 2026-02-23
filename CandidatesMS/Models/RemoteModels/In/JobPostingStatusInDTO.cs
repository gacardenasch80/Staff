using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class JobPostingStatusInDTO
    {
        public int jobPostingStatusId { get; set; }
        public string status { get; set; }
        public string statusAction { get; set; }
    }
}
