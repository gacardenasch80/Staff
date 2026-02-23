using System;

namespace CandidatesMS.Models
{
    public class CandidateGeneralSearchDTO
    {
        public int FirstId { get; set; } // CandidateId
        public int SecondId { get; set; } // BasicInformationId
        public string FirstString { get; set; } // Name
        public string SecondString { get; set; } // Surname
        public string Initials { get; set; } //Initials
        public string Photo { get; set; } //Photo
        public string ThirdString { get; set; } // Origin

        public DateTime CreationDateNotFormat { get; set; }
    }
}
