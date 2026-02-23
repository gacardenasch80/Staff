using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class MemberUserRemoteDTO
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
        public int State { get; set; }
    }
}
