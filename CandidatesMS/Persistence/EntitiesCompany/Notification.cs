using System;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string message { get; set; }

        public DateTime CreationDate { get; set; }
        public bool IsRead { get; set; }
        public string Initials { get; set; }
        public string? photo { get; set; }
        public int NotificationTypeId { get; set; }

        public NotificationType NotificationType { get; set; }

        public int MemberUserId { get; set; }
        public MemberUser MemberUser { get; set; }

        public int? CandidateId { get; set; }
    }
}
