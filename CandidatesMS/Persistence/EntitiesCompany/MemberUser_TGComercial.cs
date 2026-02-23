namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class MemberUser_TGComercial
    {
        public int MemberUser_TGComercialId { get; set; }
        public int MemberUserId { get; set; }
        public MemberUser MemberUser { get; set; }
        public int TalentGroupId { get; set; }
    }
}
