using System.Collections.Generic;

namespace CandidatesMS.Persistence.Entities
{
    public class DocumentType
    {
        public int DocumentTypeId { get; set; }
        public string DocumentTypeGuid { get; set; }
        public string Initials { get; set; }
        public string InitialsEnglish { get; set; }
        /* One Document Type -  Many Basic Information */
        public ICollection<BasicInformation> BasicInformationList { get; set; }
    }
}
