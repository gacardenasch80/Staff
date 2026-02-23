using System.Collections.Generic;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class Candidate_TalentGroupRemoteDTO
    {
    }

    public class Candidate_TGDTO
    {
        public string message { get; set; }
        public List<Candidate_TG> obj { get; set; }
    }

    public class Candidate_TG
    {
        public int candidate_TalentGroupId { get; set; }
        public int candidateId { get; set; }
        public int talentGroupId { get; set; }
        public int talentGroupStatusId { get; set; }
        public int talentGroupPostingStatusId { get; set; }

        public int companyUserId { get; set; }
    }
}
