using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class ActionUser
    {
        public int ActionUserId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string StringId { get; set; }
        public ICollection<Permission_ActionUser> Permission_ActionUser { get; set; }
    }
}
