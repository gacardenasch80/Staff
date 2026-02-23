using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class ChangeEmailCognitoDTO
    {
        public string OldEmail { get; set; }
        public string NewEmail { get; set; }
    }
}
