using System.Collections.Generic;
using System;

namespace CandidatesMS.ModelsCompany
{
    public class JobTypeReportDTO
    {
        public int JobTypeId { get; set; }

        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public bool IsEditable { get; set; }
        public bool IsDeleteable { get; set; }

        public int CompanyUserId { get; set; }

        public DateTime CreationDate { get; set; }

        public int Total { get; set; }
    }

    public class JobTypesTotalReportDTO
    {
        public List<JobTypeReportDTO> JobTypes { get; set; }
        public int Total { get; set; }
    }
}
