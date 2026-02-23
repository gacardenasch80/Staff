using System.Collections.Generic;

namespace CandidatesMS.Models
{
    public class ChangesEmailsDTO
    {
        public string OldEmail { get; set; }
        public string NewEmail { get; set; }
        public List<EmailDTO> Emails { get; set; }
    }
}
