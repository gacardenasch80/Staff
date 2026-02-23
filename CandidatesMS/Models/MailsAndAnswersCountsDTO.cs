
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class MailsAndAnswersCountsDTO
    {
        public int CountOut { get; set; }
        public int CountIn { get; set; }

        public List<MailDTO> Mails { get; set; }
    }
}
