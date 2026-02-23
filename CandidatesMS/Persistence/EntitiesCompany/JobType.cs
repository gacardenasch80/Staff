using System.Collections.Generic;
using System;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class JobType
    {
        public int JobTypeId { get; set; }

        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public bool IsEditable { get; set; }
        public bool IsDeleteable { get; set; }

        public int CompanyUserId { get; set; }

        public DateTime CreationDate { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}
