using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class GuestUser
    {
        public int GuestUserId { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public bool IsAccepted { get; set; }
        public string InvitationDate { get; set; }
        public string InvitationDateFormat { get; set; }
        public string InvitationMessage { get; set; }

        public CompanyUser CompanyUser { get; set; }
        public int CompanyUserId { get; set; }

        public Role Role { get; set; }
        public int RoleId { get; set; }
        public ICollection<GuestUser_Job> GuestUser_Job { get; set; }
        public ICollection<GuestUser_TG> GuestUser_TG { get; set; }
    }
}
