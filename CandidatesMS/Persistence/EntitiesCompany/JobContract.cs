using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class JobContract
    {
        public int JobContractId { get; set; }
        public string Contract { get; set; }
        public string ContractEnglish { get; set; }

        public List<Job> Job { get; set; }
    }
}
