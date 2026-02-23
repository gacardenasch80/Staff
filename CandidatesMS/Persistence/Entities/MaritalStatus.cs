using System.Collections.Generic;

namespace CandidatesMS.Persistence.Entities
{
    public class MaritalStatus
    {
        public int MaritalStatusId { get; set; }
        public string MaritalStatusGuid { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public ICollection<BasicInformation> BasicInformationList { get; set; }
    }
}
