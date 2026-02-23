using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class CompanyUser
    {
        public int CompanyUserId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string CountryName { get; set; }
        public string RegionName { get; set; }
        public string CityName { get; set; }
        public string Prefix { get; set; }
        public string Domain { get; set; }
        public string LogoIdentifier { get; set; }
        public ICollection<BlockReason> BlockReasons { get; set; }
        public ICollection<MemberUser> MemberUsers { get; set; }
    }
}
