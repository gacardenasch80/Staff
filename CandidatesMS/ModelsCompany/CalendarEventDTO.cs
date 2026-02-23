using System;

namespace CandidatesMS.ModelsCompany
{
    public class CalendarEventDTO
    {
        public int CalendarEventId { get; set; }
        public string Name { get; set; }
        public string NameEnlgish { get; set; }
        public string UID { get; set; }
        public string Parameters { get; set; }
        public DateTime SyncDate { get; set; }
        public string SyncDateFormat { get; set; }
        public string SyncDateFormatEnglish { get; set; }
        public string Icon { get; set; }

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public int MemberUserId { get; set; }
        public MemberUserDTO MemberUser { get; set; }
    }
}
