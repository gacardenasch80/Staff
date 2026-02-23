using CandidatesMS.Models.RemoteModels.In;

namespace CandidatesMS.ModelsCompany
{
    public class FollowJobDTO
    {
        public int FollowJobId { get; set; }
        public int JobId { get; set; }
        public JobDTO Job { get; set; }
        public int MemberUserId { get; set; }
        public MemberUserDTO MemberUser { get; set; }
    }
}
