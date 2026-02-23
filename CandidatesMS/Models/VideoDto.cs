using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class VideoDTO
    {
        public int VideoId { get; set; }
        public string VideoGuid { get; set; }
        public int CandidateId { get; set; }
        //public string Email { get; set; }   
        public bool IsUrl { get; set; }
        public string URLvideo { get; set; }
        public string VideoName { get; set; }
        public IFormFile FormFile { get; set; }
    }
}
