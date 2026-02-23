using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class BasicInformationsDTO
    {
        public int BasicInformationId { get; set; }
        public string BasicInformationGuid { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Document { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string Cellphone { get; set; }
        public int HaveWorkExperience { get; set; }
        public int HaveWorkExperienceFromCompany { get; set; }                
        public string BirthDateCompany { get; set; }
        public int CandidateId { get; set; }
    }
}
