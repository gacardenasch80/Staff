namespace CandidatesMS.ModelsCompany
{
    public class Job_JobProfessionDTO
    {
        public int Job_JobProfessionId { get; set; }
        public int JobId { get; set; }
        public int JobProfessionId { get; set; }
        public string Name { get; set; }
        public JobProfessionDTO JobProfession { get; set; }
    }
}
