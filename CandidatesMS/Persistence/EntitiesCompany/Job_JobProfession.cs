using CandidatesMS.Persistence.Entities;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class Job_JobProfession
    {
        public int Job_JobProfessionId { get; set; }

        public int? JobId { get; set; }
        public Job Job { get; set; }

        public int? JobProfessionId { get; set; }
        public JobProfession JobProfession { get; set; }

        public string Name { get; set; }
    }
}
