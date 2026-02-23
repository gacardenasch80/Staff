using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CandidatesMS.Persistence.Entities
{
    public class Candidate_LifePreference
    {
        public int Candidate_LifePreferenceId { get; set; }
        public string Candidate_LifePreferenceGuid { get; set; }
        public string OtherLifePreference { get; set; }
        public Candidate Candidate { get; set; }
        public int CandidateId { get; set; }
        public LifePreference LifePreference { get; set; }        
        public int LifePreferenceId { get; set; }

        public bool IsFromCandidate { get; set; }
        public int CompanyUserId { get; set; }
    }
}
