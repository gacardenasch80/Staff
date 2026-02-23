namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Job_OtherProfession
    {
        public int Job_OtherProfessionId { get; set; }
        public int? JobId { get; set; }
        public Job Job { get; set; }

        public string Profession { get; set; }
    }
}
