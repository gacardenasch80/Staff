using System.Collections.Generic;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class TagListInDTO
    {
        public int tagId { get; set; }
        public string name { get; set; }
        public int tagCount { get; set; }
        public int companyUserId { get; set; }

        public List<CandidateTagInDTO> candidate_Tags { get; set; }
    }

    public class TagInStructureDTO
    {
        public string message { get; set; }
        public List<TagListInDTO> obj { get; set; }
    }
}
