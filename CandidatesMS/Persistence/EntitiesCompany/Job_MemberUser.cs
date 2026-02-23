namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Job_MemberUser
    {
        public int Job_MemberUserId { get; set; }

        public int JobId { get; set; }
        public Job Job { get; set; }
        public int MemberUserId { get; set; }
        public MemberUser MemberUser { get; set; }
    }
}
