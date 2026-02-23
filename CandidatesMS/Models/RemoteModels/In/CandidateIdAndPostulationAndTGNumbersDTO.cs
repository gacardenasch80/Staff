using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class CandidateIdAndPostulationAndTGNumbersDTO
    {
        public int candidateId { get; set; }
        public int postulations { get; set; }
        public int talentGroups { get; set; }
    }

    public class CandidateIdAndPostulationAndTGNumbersResponseDTO
    {
        public int total { get; set; }
        public List<CandidateIdAndPostulationAndTGNumbersDTO> search { get; set; }
    }
}
