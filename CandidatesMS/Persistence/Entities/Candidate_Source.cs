using System;

namespace CandidatesMS.Persistence.Entities
{
    public class Candidate_Source
    {
        public int Candidate_SourceId { get; set; }

        public int? CompanyUserId { get; set; }

        public int SourceId { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }
    }
}
