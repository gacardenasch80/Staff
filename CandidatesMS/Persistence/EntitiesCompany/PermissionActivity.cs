namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class PermissionActivity
    {
        public int PermissionActivityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsAllowed { get; set; }

        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
