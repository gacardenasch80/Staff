using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class PhoneDTO
    {
        public int PhoneId { get; set; }
        public string Number { get; set; }
        public int BasicInformationId { get; set; }

        public int CompanyUserId { get; set; }
    }
}
