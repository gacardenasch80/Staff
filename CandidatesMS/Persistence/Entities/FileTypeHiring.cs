using System.Collections.Generic;

namespace CandidatesMS.Persistence.Entities
{
    public class FileTypeHiring
    {
        public int FileTypeHiringId { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }
        public int OrderId { get; set; }

        /* One FileType, Many Attached Files */
        public ICollection<AttachedFileHiring> AttachedFiles { get; set; }
        public ICollection<CVHiring> CVs { get; set; }
    }
}
