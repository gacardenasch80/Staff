using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Entities
{
    public class FileGroupQueue
    {
        public int filegroupid { get; set; }
        public string filegroupguid { get; set; }
        public bool isprocessed { get; set; }
        public bool issuccess { get; set; }
        public string emailmemberuser { get; set; }
        public DateTime creationdate { get; set; }
        public DateTime editiondate { get; set; }
    }
}
