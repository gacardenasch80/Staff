using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class PostulationState
    {
        public int PostulationStateId { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public ICollection<PostulationStage> PostulationStages { get; set; }
    }
}
