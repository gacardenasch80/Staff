using System.Collections.Generic;

namespace CandidatesMS.ModelsCompany
{
    public class GuestUserDTO
    {
        public int GuestUserId { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public bool IsAccepted { get; set; }
        public string InvitationDate { get; set; }
        public string InvitationDateFormat { get; set; }
        public string InvitationMessage { get; set; }
        public string RoleName { get; set; }

        public int CompanyUserId { get; set; }
        public int RoleId { get; set; }
        public ICollection<int> JobsIds { get; set; }
        public ICollection<int> TalentGroupsIds { get; set; }
    }
}
