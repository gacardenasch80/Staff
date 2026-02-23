using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class JobModality
    {
        public int JobModalityId { get; set; }
        public string Modality { get; set; }
        public string ModalityEnglish { get; set; }

        public List<Job> Job { get; set; }
    }
}
