using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure.Mailer
{
    public class MailSettingsDTO
    {
        public string DisplayName { get; set; }

        public string Mail { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }

        public string MailImap { get; set; }
        public string PasswordImap { get; set; }
        public string HostImap { get; set; }
        public int PortImap { get; set; }
    }
}
