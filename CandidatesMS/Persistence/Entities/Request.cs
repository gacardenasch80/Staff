using System;

namespace CandidatesMS.Persistence.Entities
{
    public class Request
    {
        public int RequestId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime CreationDate { get; set; }
        public string Message { get; set; }
        

        public int RequestTypeId { get; set; }

        public RequestType RequestType { get; set; }

        public int CandidateId { get; set; }
        public Candidate Candidate { get; set; }
    }
}
