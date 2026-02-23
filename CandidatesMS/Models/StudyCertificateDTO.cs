using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class StudyCertificateDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CertificateIdentifier { get; set; }
        public int StudyId { get; set; }
    }
}
