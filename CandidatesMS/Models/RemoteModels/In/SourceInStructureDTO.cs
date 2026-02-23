using System.Collections.Generic;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class SourceListInDTO
    {
        public int sourceId { get; set; }
        public string name { get; set; }
        public int sourceCount { get; set; }
        public int companyUserId { get; set; }

        public List<CandidateSourceInDTO> candidate_Sources { get; set; }
    }

    public class SourceInStructureDTO
    {
        public string message { get; set; }
        public List<SourceListInDTO> obj { get; set; }
    }
}
