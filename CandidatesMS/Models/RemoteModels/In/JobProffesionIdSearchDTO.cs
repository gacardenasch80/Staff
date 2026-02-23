using System.Collections.Generic;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class JobProffesionIdSearchDTO
    {
        public int jobProffesionId { get; set; }
    }
    public class JobProffesionIdSearchResponseDTO
    {
        public List<JobProffesionIdSearchDTO> search { get; set; }
    }
}
