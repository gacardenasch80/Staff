using System;
using System.Collections.Generic;

namespace CandidatesMS.Persistence.Entities
{
    public class Gender
    {
        public int GenderId { get; set; }
        public string GenderGuid { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public ICollection<BasicInformation> BasicInformationList { get; set; }
    }
}
