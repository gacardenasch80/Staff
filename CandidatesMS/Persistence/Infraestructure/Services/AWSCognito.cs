namespace CandidatesMS.Persistence.Infraestructure.Services
{
    public class CognitoConfiguration
    {
        public string Region { get; set; }
        public string CandidatePoolId { get; set; }
        public string CandidateAppClientId { get; set; }
        public string CompanyPoolId { get; set; }
        public string CompanyAppClientId { get; set; }
    }
}
