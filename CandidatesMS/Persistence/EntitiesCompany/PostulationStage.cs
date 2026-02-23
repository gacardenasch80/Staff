using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class PostulationStage
    {
        public int PostulationStageId { get; set; }
        public string Name { get; set; }
        public string NameEnglish { get; set; }

        public ICollection<Postulation> Postulations { get; set; }

        public int PostulationStateId { get; set; }
        public PostulationState PostulationState { get; set; }
    }
}
