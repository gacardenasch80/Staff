using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class JobInDTO
    {
        public int jobId { get; set; }

        public string? publicationDate { get; set; }
        public string creationDate { get; set; }
        public string? closingDate { get; set; }
        public string? filingDate { get; set; }
        public string? deletionDate { get; set; }
        public string? editedDate { get; set; }
        public DateTime sortedDate { get; set; }
        public string previousInfo { get; set; }
        public string previousToltip { get; set; }

        public string creationDateToltip { get; set; }
        public string publicationDateToltip { get; set; }
        public string closingDateToltip { get; set; }
        public string filingDateToltip { get; set; }
        public string deletionDateToltip { get; set; }
        public string editedDateToltip { get; set; }

        public string name { get; set; }
        public string? description { get; set; }
        public bool showSalary { get; set; }
        public bool isRemote { get; set; }
        public bool? following { get; set; }
        public bool isEdit { get; set; }

        public string nameMemberUser { get; set; }
        public string surnameMemberUser { get; set; }
        public string memberEmail { get; set; }
        public string jobSalary { get; set; }
        public string jobSectorName { get; set; }

        public bool isCreationAndPublication { get; set; }

        /**/
        public int countQualified { get; set; }
        public int countDisqualified { get; set; }
        /**/

        public int companyUserId { get; set; }

        public JobPostingStatusInDTO jobPostingStatus { get; set; }
    }
}
