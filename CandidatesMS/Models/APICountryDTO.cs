using DocumentFormat.OpenXml.Office2010.ExcelAc;
using System.Collections.Generic;

namespace CandidatesMS.Models
{
    public class APICountryDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<APIStateDTO> States { get; set; }
    }

    public class APIStateDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<APICityDTO> Cities { get; set; }
    }

    public class APICityDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
