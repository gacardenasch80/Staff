namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Permission_Role
    {
        public int Permission_RoleId { get; set; }

        public Permission Permission { get; set; }
        public int PermissionId { get; set; }

        public bool IsCheck { get; set; }
        public bool IsDisabled { get; set; }

        public Role Role { get; set; }
        public int RoleId { get; set; }
    }
}
