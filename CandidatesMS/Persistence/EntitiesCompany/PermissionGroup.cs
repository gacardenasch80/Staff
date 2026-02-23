using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class PermissionGroup
    {
        public int PermissionGroupId { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }
        public List<Permission> Permissions { get; set; }
    }
}
