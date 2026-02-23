using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class ListIntCandidateWithPostulationCountDTO
    {
        public int statusCode { get; set; }
        public string message { get; set; }
        public CandidateIdAndPostulationAndTGNumbersResponseDTO obj { get; set; }
    }
}
