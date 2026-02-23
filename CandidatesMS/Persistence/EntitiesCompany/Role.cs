using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleGuid { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }
        public CompanyUser CompanyUser { get; set; }
        public int CompanyUserId { get; set; }

        public ICollection<Permission_Role> Permission_RoleList { get; set; }

        public ICollection<GuestUser> GuestUserList { get; set; }
        public ICollection<MemberUser> MemberUserList { get; set; }
    }
}
