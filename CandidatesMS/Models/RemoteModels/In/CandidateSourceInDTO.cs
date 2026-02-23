using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class CandidateSourceInDTO
    {
        public int candidate_SourceId { get; set; }
        public int candidateId { get; set; }
        public int companyUserId { get; set; }
        public int sourceId { get; set; }
        public string name { get; set; }
    }
    public class CandidateIdAndSourceResponseDTO
    {
        public List<CandidateSourceInDTO> search { get; set; }
    }

    public class CandidateSourceInStructureDTO
    {
        public string message { get; set; }
        public List<CandidateSourceInDTO> obj { get; set; }
    }
}
