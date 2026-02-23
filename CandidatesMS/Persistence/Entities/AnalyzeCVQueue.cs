using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandidatesMS.Persistence.Entities
{
    [Table("AnalyzeCVQueue")]
    public class AnalyzeCVQueue
    {
        public int analyzefileid { get; set; }
        public bool isprocessed { get; set; }
        public bool issuccess { get; set; }
        public string parameters { get; set; }
        public DateTime creationdate { get; set; }
        public DateTime editiondate { get; set; }
        public string filegroupguid { get; set; }
        public string filetokendalitica { get; set; }
    }
}
