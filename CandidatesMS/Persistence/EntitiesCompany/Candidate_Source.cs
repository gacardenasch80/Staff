using System;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Candidate_Source
    {
        public int Candidate_SourceId { get; set; }
        public int CandidateId { get; set; }
        public int SourceId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public Source Source { get; set; }

        public int? CompanyUserId { get; set; }
    }
}
