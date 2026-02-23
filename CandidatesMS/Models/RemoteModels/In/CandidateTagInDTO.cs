using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class CandidateTagInDTO
    {
        public int candidate_TagId { get; set; }
        public int candidateId { get; set; }
        public int companyUserId { get; set; }
        public int tagId { get; set; }
        public string name { get; set; }
    }
    public class CandidateIdAndTagResponseDTO
    {
        public List<CandidateTagInDTO> search { get; set; }
    }

    public class CandidateTagInStructureDTO
    {
        public string message { get; set; }
        public List<CandidateTagInDTO> obj { get; set; }
    }
}
