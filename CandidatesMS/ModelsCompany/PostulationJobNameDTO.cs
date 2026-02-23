using CandidatesMS.Models.RemoteModels.In;
using System.Collections.Generic;
using System;

namespace CandidatesMS.ModelsCompany
{
    public class PostulationJobNameDTO
    {
        public int CandidateId { get; set; }
        public int JobId { get; set; }
        public string JobName { get; set; }

        public int ColourFlag { get; set; }

        public DateTime CreationDate { get; set; }

        public bool AcceptResponses { get; set; }

        public List<AnswerDTO> Answers { get; set; }
    }
}
