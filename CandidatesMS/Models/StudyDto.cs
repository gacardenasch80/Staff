using CandidatesMS.Persistence.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class StudyDTO
    {
        public int StudyId { get; set; }
        public string Institution { get; set; }
        public int? TitleId { get; set; }
        public int? StudyTypeId { get; set; }
        public int? CertificationStateId { get; set; }
        public int? StudyAreaId { get; set; }
        public int JobProfessionId { get; set; }
        public string OtherJobProfession { get; set; }
        public string JobProfession { get; set; }
        public string JobProfessionEnglish { get; set; }
        public bool IsStudying { get; set; }
        public bool IsPostponed { get; set; }
        public string CompletionStudies { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public double CompareDate { get; set; }
        //public  StudyFile { get; set; }
        public StudyAreaDTO StudyArea { get; set; }
        public StudyTypeDTO StudyType { get; set; }
        public TitleDTO Title { get; set; }
        public CertificationStateDTO CertificationState { get; set; }
        public StudyStateDTO StudyState { get; set; }
        public StudyCertificateDTO StudyCertificate { get; set; }
        public string CertificateName { get; set; }
        public IFormFile FormFile { get; set; }
        public int CandidateId { get; set; }

        public int StudyStateId { get; set; }

        //public string Email { get; set; }

        public bool IsFromCandidate { get; set; }
    }
}
