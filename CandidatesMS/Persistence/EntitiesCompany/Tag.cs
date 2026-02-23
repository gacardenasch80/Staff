using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Tag
    {
        public int TagId { get; set; }
        public string Name { get; set; }

        public int CompanyUserId { get; set; }
        public CompanyUser CompanyUser { get; set; }
        public List<Candidate_Tag> Candidate_Tags { get; set; }
    }
}
