namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class FollowJob
    {
        public int FollowJobId { get; set; }
        public int JobId { get; set; }
        public Job Job { get; set; }
        public int MemberUserId { get; set; }
        public MemberUser MemberUser { get; set; }
    }
}
