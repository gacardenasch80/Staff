using System;

namespace CandidatesMS.Persistence.Entities
{
    public class Candidate_Tag
    {
        public int Candidate_TagId { get; set; }

        public int? CompanyUserId { get; set; }

        public int TagId { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }
    }
}
