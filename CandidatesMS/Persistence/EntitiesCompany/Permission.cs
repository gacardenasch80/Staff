using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Permission
    {
        public int PermissionId { get; set; }
        public string PermissionGuid { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }
        public string Description { get; set; }
        public string DescriptionEnglish { get; set; }
        public int PermissionGroupId { get; set; }
        public PermissionGroup PermissionGroup { get; set; }

        public ICollection<Permission_Role> Permission_RoleList { get; set; }
        public ICollection<PermissionActivity> PermissionActivities { get; set; }
        public ICollection<Permission_ActionUser> Permission_ActionUser { get; set; }
    }
}
