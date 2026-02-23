using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Entities
{
    public class Email
    {
        public int EmailId { get; set; }
        public string Mail { get; set; }

        /**/
        public int BasicInformationId { get; set; }
        public BasicInformation BasicInformation { get; set; }
        /**/

        public int? CompanyUserId { get; set; }
    }
}
