using System.Collections.Generic;

namespace CandidatesMS.ModelsCompany
{
    public class Candidate_TalentGroupDTO
    {
        public int CandidateId { get; set; }
        public ICollection<int> JobsIds { get; set; }
        public ICollection<int> TalentGroupsIds { get; set; }
    }
}
