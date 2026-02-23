namespace CandidatesMS.Models.RemoteModels.Out
{
    public class NotificationDTO
    {
        public string candidate { get; set; }
        public string initial { get; set; }
        public string photo { get; set; }
        public int candidateId { get; set; }
        public int requestTypeId { get; set; }

        public CandidateNotificationDTO candidateFull { get; set; }
}
}
