using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models.RemoteModels.In
{    
    public class CandidateTalentGroupNameInDTO
    {
        public int candidateId { get; set; }
        public int talentGroupId { get; set; }
        public string talentGroupName { get; set; }

        public int colourFlag { get; set; }

        public DateTime creationDate { get; set; }
    }

    public class CandidateTalentNameDTO
    {
        public string message { get; set; }
        public List<CandidateTalentGroupNameInDTO> obj { get; set; }
    }
}
