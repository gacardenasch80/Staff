using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Entities
{
    public class GenderCompany
    {
        public int GenderCompanyId { get; set; }
        public string GenderGuid { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public int GenderId { get; set; }

    }
}
