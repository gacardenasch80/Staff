using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;

namespace CandidatesMS.Models
{
    public class NoteGroupDTO
    {
        public List<Note> notesCandidates { get; set; }
        public int TotalNotes { get; set; }

    }
}
