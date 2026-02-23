using System;

namespace CandidatesMS.Models
{
    public class RequestDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public DateTime CreationDate { get; set; }
        public string Message { get; set; }
        public string Mail { get; set; }
        public int RequestTypeId { get; set; }
        public int CandidateId { get; set; }
    }
}
