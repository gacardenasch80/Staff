using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Entities
{
    public class LifePreference
    {
        public int LifePreferenceId { get; set; }
        public string LifePreferenceGuid { get; set; }
        public string LifePreferenceName { get; set; }
        public string LifePreferenceNameEnglish { get; set; }
        public ICollection<Candidate_LifePreference> Candidate_LifePreferenceList { get; set; }
    }
}
