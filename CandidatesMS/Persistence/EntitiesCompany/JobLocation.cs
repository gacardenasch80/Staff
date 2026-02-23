namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class JobLocation
    {
        public int JobLocationId { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string CountryName { get; set; }
        public string RegionName { get; set; }
        public string CityName { get; set; }
        public Job Job { get; set; }
    }
}
