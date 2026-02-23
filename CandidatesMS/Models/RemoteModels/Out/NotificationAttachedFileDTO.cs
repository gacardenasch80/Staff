namespace CandidatesMS.Models.RemoteModels.Out
{
    public class NotificationAttachedFileDTO
    {
        public int candidateId { get; set; }
        public string candidateName { get; set; }
        public string candidateInitials { get; set; }
        public string candidatePhoto { get; set; }
        public string attachedFileName { get; set; }
        public string memberUserInitials { get; set; }
        public string memberUserName { get; set; }
        public string memberUserPhoto { get; set; }
    }
}
