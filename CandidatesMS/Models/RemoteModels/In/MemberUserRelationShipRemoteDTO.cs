using System.Collections.Generic;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class MemberUserRelationShipRemoteDTO
    {
        public string message { get; set; }
        public MemberByToken obj { get; set; }
    }
    public class Role
    {
        public int roleId { get; set; }
        public object roleGuid { get; set; }
        public string name { get; set; }
        public object description { get; set; }
        public int companyUserId { get; set; }
    }

    public class MemberByToken
    {
        public int memberUserId { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string photo { get; set; }
        public string photoName { get; set; }
        public int companyUserId { get; set; }
        public int roleId { get; set; }
        public string roleName { get; set; }
        public Role role { get; set; }
        public int state { get; set; }
    }

    public class MemberUserByToken
    {
        public int MemberUserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Photo { get; set; }
        public string PhotoName { get; set; }
        public int CompanyUserId { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public Role Role { get; set; }
        public int State { get; set; }
    }

    public class MemberUserAllDTO
    {
        public string message { get; set; }
        public List<MemberByToken> obj { get; set; }
    }
}
