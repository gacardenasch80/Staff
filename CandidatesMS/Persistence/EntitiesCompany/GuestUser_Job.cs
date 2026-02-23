namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class GuestUser_Job
    {
        public int GuestUser_JobId { get; set; }
        public int GuestUserId { get; set; }
        public GuestUser GuestUser { get; set; }
        public int JobId { get; set; }
    }
}
