namespace CandidatesMS.ModelsCompany
{
    public class DisqualificationReasonDTO
    {
        public int DisqualificationReasonId { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public int CompanyUserId { get; set; }
    }
}
