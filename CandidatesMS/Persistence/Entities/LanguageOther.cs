using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Entities
{
    public class LanguageOther
    {
        public int LanguageOtherId { get; set; }
        public string LanguageOtherGuid { get; set; }
        public string LanguageOtherName { get; set; }
        public int CandidateId { get; set; }

        public int CompanyUserId { get; set; }
        public bool AdminView { get; set; }
        public Candidate Candidate { get; set; }
        //public ICollection<Candidate_LanguageOther> Candidate_LanguageOther { get; set; }
    }
}
