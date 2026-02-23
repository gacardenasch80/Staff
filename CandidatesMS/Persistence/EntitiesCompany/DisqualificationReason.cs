namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class DisqualificationReason
    {
        public int DisqualificationReasonId { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public int CompanyUserId { get; set; }
        public CompanyUser CompanyUser { get; set; }
    }
}
