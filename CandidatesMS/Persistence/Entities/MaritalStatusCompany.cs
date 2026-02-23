using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Entities
{
    public class MaritalStatusCompany
    {
        public int MaritalStatusCompanyId { get; set; }
        public string MaritalStatusGuid { get; set; }
        public string Name { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public int MaritalStatusId { get; set; }        

    }
}
