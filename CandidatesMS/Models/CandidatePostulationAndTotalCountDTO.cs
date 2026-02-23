using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class CandidatePostulationAndTotalCountDTO
    {
        public int Total { get; set; }
        public List<CandidateWithPostulationCountDTO> Candidates { get; set; }
    }
}
