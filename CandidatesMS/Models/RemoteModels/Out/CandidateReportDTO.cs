using System;
using System.Collections.Generic;

namespace CandidatesMS.Models.RemoteModels.Out
{
    public class CandidateReportDTO
    {
        public int CandidateId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string Emails { get; set; }
        public string HV { get; set; }
        public string Portal { get; set; }
        public string NameMemberUser { get; set; }
        public string JobNames { get; set; }
        public string TalentGroupName { get; set; }
        public string RouteStates { get; set; }
        public string Stages { get; set; }
        public string Tag { get; set; }
        public string Source { get; set; }
        public string TechnicalAbilities { get; set; }
        public string WorkExperiences { get; set; }
        public string Languages { get; set; }
        public string Countries { get; set; }
        public string Genders { get; set; }
        public string Salaries { get; set; }

        public int Language { get; set; }
    }

    public class CandidateReportResponseDTO
    {
        public List<CandidateReportDTO> search { get; set; }
    }
}
