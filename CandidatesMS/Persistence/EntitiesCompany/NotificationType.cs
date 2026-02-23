using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class NotificationType
    {
        public int NotificationTypeId { get; set; }
        public string Message { get; set; }

        public ICollection<Notification> Notification { get; set; }
    }
}
