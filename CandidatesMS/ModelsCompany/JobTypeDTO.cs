using System;

namespace CandidatesMS.ModelsCompany
{
    public class JobTypeDTO
    {
        public int JobTypeId { get; set; }

        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public bool IsEditable { get; set; }
        public bool IsDeleteable { get; set; }

        public int CompanyUserId { get; set; }

        public DateTime CreationDate { get; set; }

        public int JobsCount { get; set; }
    }
}
