using System.Collections.Generic;

namespace CandidatesMS.Persistence.Entities
{
    public class RequestType
    {
        public int RequestTypeId { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public ICollection<Request> Request { get; set; }
    }
}
