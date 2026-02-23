using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class UserLinkDTO
    {
        public int UserLinkId { get; set; }
        public string Link { get; set; }
        public int BasicInformationId { get; set; }
        public string Prueba { get; set; }

        public int CompanyUserId { get; set; }
    }
}
