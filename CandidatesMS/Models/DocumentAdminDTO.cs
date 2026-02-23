using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class DocumentAdminDTO
    {
        public string DocumentAdmin { get; set; }
        public int DocumentTypeIdAdmin { get; set; }
        public string OtherDocument { get; set; }
        public int CandidateId { get; set; }
    }
}
