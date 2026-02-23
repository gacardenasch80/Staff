namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Permission_ActionUser
    {
        public int Permission_ActionUserId { get; set; }
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
        public int ActionUserId { get; set; }
        public ActionUser ActionUser { get; set; }
    }
}
