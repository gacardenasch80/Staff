using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Entities
{
    public class StudyCertificate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CertificateIdentifier { get; set; }
        public int StudyId { get; set; }
        public string UploadDate { get; set; }
        public Study Study { get; set; }
    }
}
