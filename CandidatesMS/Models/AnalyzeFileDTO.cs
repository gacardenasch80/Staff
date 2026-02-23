using System.Collections.Generic;

namespace CandidatesMS.Models
{
    public class AnalyzeFileDTO
    {
        public int AnalyzeFileId { get; set; }
        public string FileIdentifier { get; set; }
        public List<int> Jobs { get; set; }
        public List<int> TalentGroups { get; set; }
        public int NumberPages { get; set; }
        public string JobsFull { get; set; }
        public string TalentGroupsFull { get; set; }
        public string EmailMemberUser { get; set; }
        public string FilegroupGuid { get; set; }
        public int CompanyUserId { get; set; }
    }
}
