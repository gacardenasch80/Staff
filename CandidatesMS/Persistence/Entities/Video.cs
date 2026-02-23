using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandidatesMS.Persistence.Entities
{
    public class Video
    {
        public int VideoId { get; set; }
        public string VideoGuid { get; set; }
        public Candidate Candidate { get; set; }
        //[ForeignKey("Candidate")]
        //public string Email { get; set; }
        public int CandidateId { get; set; }
        public bool IsUrl { get; set; }
        public string URLvideo { get; set; }
        public string VideoName { get; set; }
    }
}

