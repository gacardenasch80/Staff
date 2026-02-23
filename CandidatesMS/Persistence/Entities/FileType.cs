using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Entities
{
    public class FileType
    {
        public int FileTypeId { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public int OrderList { get; set; }


        /* One FileType, Many Attached Files */
        public ICollection<AttachedFile> AttachedFiles { get; set; }
        public ICollection<CV> CVs { get; set; }
    }
}
