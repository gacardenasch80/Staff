namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class GuestUser_TG
    {
        public int GuestUser_TGId { get; set; }
        public int GuestUserId { get; set; }
        public GuestUser GuestUser { get; set; }
        public int TalentGroupId { get; set; }
    }
}
