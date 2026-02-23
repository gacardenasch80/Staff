using System;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Candidate_Tag
    {
        public int Candidate_TagId { get; set; }
        public int CandidateId { get; set; }
        public int TagId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public Tag Tag { get; set; }

        public int? CompanyUserId { get; set; }
    }
}
