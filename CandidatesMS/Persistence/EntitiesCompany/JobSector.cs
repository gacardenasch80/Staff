using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class JobSector
    {
        public int JobSectorId { get; set; }
        public string Sector { get; set; }
        public string SectorEnglish { get; set; }

        public List<Job> Job { get; set; }
    }
}
