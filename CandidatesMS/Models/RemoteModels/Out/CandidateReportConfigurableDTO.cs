using System.Collections.Generic;

namespace CandidatesMS.Models.RemoteModels.Out
{
    public class CandidateReportConfigurableDTO
    {
        public int CandidateId { get; set; }
        public string Name { get; set; }
        public string Emails { get; set; }
        public string Languages { get; set; }
        public string TechnicalAbilities { get; set; }
        public string Locations { get; set; }
        public string SalaryAspirations { get; set; }
    }

    public class CandidateReportConfigurableResponseDTO
    {
        public List<CandidateReportDTO> search { get; set; }
    }
}
