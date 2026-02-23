using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Source
    {
        public int SourceId { get; set; }
        public string Name { get; set; }

        public int CompanyUserId { get; set; }
        public CompanyUser CompanyUser { get; set; }

        public List<Candidate_Source> Candidate_Sources { get; set; }
    }
}
