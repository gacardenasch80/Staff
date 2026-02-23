using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class PostulationJobNameInDTO
    {
        public int candidateId { get; set; }
        public int jobId { get; set; }
        public string jobName { get; set; }

        public int colourFlag { get; set; }

        public DateTime creationDate { get; set; }

        public bool acceptResponses { get; set; }

        public List<AnswerInDTO> answers { get; set; }
    }

    public class PostulationJobInDTO
    {
        public string message { get; set; }
        public List<PostulationJobNameInDTO> obj { get; set; }
    }
}
