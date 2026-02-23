namespace CandidatesMS.ModelsCompany
{
    public class CompanyUserJobsDTO
    {
        public string Name { get; set; }
        public string LogoIdentifier { get; set; }

        public int JobTypeId { get; set; }
        public JobTypeDTO JobType { get; set; }
    }
}
