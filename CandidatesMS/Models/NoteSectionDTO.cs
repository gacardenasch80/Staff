namespace CandidatesMS.Models
{
    public class NoteSectionDTO
    {
        public string NoteDescription { get; set; }
        public string CreationDate { get; set; }
        public string CreationDateEnglish { get; set; }
        public string CreationDatePopUp { get; set; }
        public string CreationDatePopUpEnglish { get; set; }
        public string Name { get; set; }
        public int CandidateId { get; set; }
        public CandidateSectionDTO CandidateSection { get; set; }
        public int id { get; set; }
        public int Previous { get; set; }
        public int Next { get; set; }
    }
}
