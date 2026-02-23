using Microsoft.AspNetCore.Http;

namespace CandidatesMS.Models
{
    public class CVHiringDTO
    {
        public int CVId { get; set; }
        public int CandidateId { get; set; }
        public string UploadDate { get; set; }
        public string CvIdentifier { get; set; }
        public string CvIdentifierLink { get; set; }
        public string Name { get; set; }
        public int HiringId { get; set; }

        public bool IsFromCandidate { get; set; }

        public double Weight { get; set; }
        public string Hash { get; set; }

        public IFormFile FormFile { get; set; }
    }
}
