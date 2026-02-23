namespace CandidatesMS.KeyVault.SecretsModels
{
    public class ServiceConfigurationDTO
    {
        public AWSS3ConfigurationDTO AWSS3 { get; set; }
        public AWSS3ConfigurationDTO AWSS3Textract { get; set; }
    }
}
