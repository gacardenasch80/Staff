using CandidatesMS.Models.RemoteModels.In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models.RemoteModels.Out
{
    public class PostulationAnalyzeOutDTO
    {
        public List<int> Candidates { get; set; }
        public List<int> Jobs { get; set; }

        public bool acceptResponses { get; set; }

        public List<AnswerInDTO> answers { get; set; }
    }
}
