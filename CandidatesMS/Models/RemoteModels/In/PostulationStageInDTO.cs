using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class PostulationStageInDTO
    {
        public int postulationStageId { get; set; }
        public string name { get; set; }

        public int postulationStateId { get; set; }
        public PostulationStateInDTO postulationState { get; set; }
    }
}
