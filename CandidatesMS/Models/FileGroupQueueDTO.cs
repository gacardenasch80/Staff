using System;

namespace CandidatesMS.Models
{
    public class FileGroupQueueDTO
    {
        public int filegroupid { get; set; }
        public string filegroupguid { get; set; }
        public bool isprocessed { get; set; }
        public int issuccess { get; set; }
        public string emailmemberuser { get; set; }
        public string namememberuser { get; set; }
        public string surnnamememberuser { get; set; }
        public string creationdate { get; set; }
        public string editiondate { get; set; }
    }
}
