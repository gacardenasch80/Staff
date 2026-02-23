using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class JobCurrency
    {
        public int JobCurrencyId { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }
        public string ShortName { get; set; }
        public string ShortNameEnglish { get; set; }

        public List<Job> Jobs { get; set; }
    }
}
