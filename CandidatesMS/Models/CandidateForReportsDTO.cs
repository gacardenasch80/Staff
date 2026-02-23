using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;

namespace CandidatesMS.Models
{
    public class CandidateForReportsDTO
    {
        public int CandidateId { get; set; }
        public int MemberUserId { get; set; }
        public int CompanyUserId { get; set; }

        public BasicInformationDTO BasicInformation { get; set; }
        public CompanyDescription CompanyDescription { get; set; }
        public List<StudyDTO> Studies { get; set; }
        public List<WorkExperienceDTO> WorkExperiences { get; set; }
    }
}
