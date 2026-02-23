using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class TalentGroupPostingStatus
    {
        public int TalentGroupPostingStatusId { get; set; }
        public string Status { get; set; }
        public string StatusAction { get; set; }
        public ICollection<TalentGroup> TalentGroup { get; set; }
    }
}
