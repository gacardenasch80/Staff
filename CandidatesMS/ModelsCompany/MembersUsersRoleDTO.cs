using CandidatesMS.Persistence.EntitiesCompany;
using System.Collections.Generic;

namespace CandidatesMS.ModelsCompany
{
    public class MembersUsersRoleDTO
    {
        public List<MemberUser> SuperAdministrador { get; set; }
        public List<MemberUser> Auxiliar { get; set; }
        public List<MemberUser> Analista { get; set; }
        public List<MemberUser> Corporativo { get; set; }
        public List<MemberUser> Administrador { get; set; }
        public List<MemberUser> Comercial { get; set; }
    }
}
