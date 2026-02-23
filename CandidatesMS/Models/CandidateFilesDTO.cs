using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class CandidateFilesDTO
    {
        public List<FilesDTO> CompanyFiles { get; set; }
        public List<FilesDTO> PortalFiles { get; set; }
    }
}
