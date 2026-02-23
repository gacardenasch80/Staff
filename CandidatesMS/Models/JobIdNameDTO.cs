using CandidatesMS.Models.RemoteModels.In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class JobIdNameDTO
    {
        public int JobId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int JobPostingStausId { get; set; }

        public ICollection<QuestionInDTO> Questions { get; set; }
    }
}
