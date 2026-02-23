using System.Collections.Generic;

namespace CandidatesMS.Models
{
    public class DataMentionEmailDTO
    {
        public string CreatorName { get; set; }
        public string CreatorInitials { get; set; }
        public string CandidateName { get; set; }
        public string VacancyName { get; set; }
        public List<string> MembersNames { get; set; }
        public List<string> MembersEmails { get; set; }
        public string Description { get; set; }
        public string NoteLink { get; set; }  
        public int CandidateId { get; set; }
        public int Language { get; set; }
    }
}
