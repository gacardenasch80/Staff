namespace CandidatesMS.Models
{
    public class BasicInformationWithValidationsDTO
    {
        public bool Exists { get; set; }
        public bool IsFull { get; set; }
        public BasicInformationDTO BasicInformation { get; set; }
    }
}
