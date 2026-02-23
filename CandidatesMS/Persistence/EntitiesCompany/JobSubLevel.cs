namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class JobSubLevel
    {
        public int JobSubLevelId { get; set; }
        public int JobLevelId { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public JobLevel JobLevel { get; set; }
    }
}
