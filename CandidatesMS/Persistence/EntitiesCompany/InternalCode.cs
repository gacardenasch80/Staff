using static CandidatesMS.Models.RemoteModels.In.PostulationRemoteDTO;
using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class InternalCode
    {
        public int InternalCodeId { get; set; }
        public string InternalCodeName { get; set; }
        public int CompanyUserId { get; set; }
        public CompanyUser CompanyUser { get; set; }
        public List<Job> Jobs { get; set; }
        public ICollection<TalentGroup> TalentGroup { get; set; }
    }
}
