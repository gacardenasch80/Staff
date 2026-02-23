using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class PersonalReferenceDTO
    {
        public int PersonalReferenceId { get; set; }
        public string ReferenceName { get; set; }
        public string ReferenceSurname { get; set; }
        public int? RelationTypeId { get; set; }
        public string PhoneNumber { get; set; }
        public string AditionalNumber { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public RelationTypeDTO RelationType { get; set; }
        public string OtherRelationtype { get; set; }
        public int CandidateId { get; set; }
        public bool IsAddefromCompany { get; set; }
        //public string Email { get; set; }

        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
    }
}
