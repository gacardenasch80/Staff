using CandidatesMS.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Entities
{
    public class Study
    {
        public int StudyId { get; set; }
        public int? TitleId { get; set; }
        public string Institution { get; set; }
        public int? StudyTypeId { get; set; }
        public int? CertificationStateId { get; set; }
        public int? StudyAreaId { get; set; }
        public string OtherJobProfession { get; set; }
        public string CompletionStudies { get; set; }
        public bool IsStudying { get; set; }
        public bool IsPostponed { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        /* One Candidate, Many Study experiences */
        public Candidate Candidate { get; set; }
        public StudyArea StudyArea { get; set; }
        public int CandidateId { get; set; }
        public string CertificateIdentifier { get; set; }
        public StudyType StudyType { get; set; }
        public Title Title { get; set; }
        public CertificationState CertificationState { get; set; }
        public StudyCertificate StudyCertificate { get; set; }

        public StudyState StudyState { get; set; }
        public int StudyStateId { get; set; }

        public JobProfession JobProfession { get; set; }
        public int JobProfessionId { get; set; }


        public bool IsFromCandidate { get; set; }
        public int CompanyUserId { get; set; }

        public Study()
        {
            OtherJobProfession = "";
        }
    }
}
