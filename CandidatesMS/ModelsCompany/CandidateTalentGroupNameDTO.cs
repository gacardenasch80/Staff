using System;

namespace CandidatesMS.ModelsCompany
{
    public class CandidateTalentGroupNameDTO
    {
        public int CandidateId { get; set; }
        public int TalentGroupId { get; set; }
        public string TalentGroupName { get; set; }

        public int ColourFlag { get; set; }

        public DateTime CreationDate { get; set; }
    }
}
