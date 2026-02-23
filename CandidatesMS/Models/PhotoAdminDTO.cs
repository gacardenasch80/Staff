using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class PhotoAdminDTO
    {
        public int CandidateId { get; set; }
        public string Photo { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
