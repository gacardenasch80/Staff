using System.Collections.Generic;

namespace CandidatesMS.Persistence.Entities
{
    public class Currency
    {
        public int CurrencyId { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }
        public string ShortName { get; set; }
        public string ShortNameEnglish { get; set; }

        public List<BasicInformation> BasicInformations { get; set; }
    }
}
