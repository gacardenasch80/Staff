namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Job_OtherSector
    {
        public int Job_OtherSectorId { get; set; }
        public string Sector { get; set; }
        public int? JobId { get; set; }
        public Job Job { get; set; }
    }
}
