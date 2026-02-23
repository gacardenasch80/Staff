using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class FileTypeDTO
    {
        public int FileTypeId { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public int OrderList { get; set; }
    }
}
