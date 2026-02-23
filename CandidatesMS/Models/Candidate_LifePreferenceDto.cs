namespace CandidatesMS.Models
{
    public class Candidate_LifePreferenceDTO
    {
        public int Candidate_LifePreferenceId { get; set; }
        public string Candidate_LifePreferenceGuid { get; set; }
        public string OtherLifePreference { get; set; }

        public CandidateDTO Candidate { get; set; }
        public int CandidateId { get; set; }
        public LifePreferenceDTO LifePreference { get; set; }        
        public int LifePreferenceId { get; set; }
    }
}
