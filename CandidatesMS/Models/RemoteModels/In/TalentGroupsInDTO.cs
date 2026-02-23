using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models.RemoteModels.In
{
    public class TalentGroupsInDTO
    {
        public int talentGroupId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int companyUserId { get; set; }
        public int? internalCodeId { get; set; }
        public string creationDate { get; set; }
        public string editedDate { get; set; }
        public string creationInfo { get; set; }
        public string creationShortInfo { get; set; }
        public string creationInfoPup { get; set; }
        public string internalCodeName { get; set; }
        public bool? following { get; set; }
        public bool isEdit { get; set; }
        public int[] memberUserIds { get; set; }
        public int countCandidates { get; set; }

        public int colourFlag { get; set; }
        public DateTime creationDateLastEvaluation { get; set; }
        public string percentResumeFormat { get; set; }
    }



    public class TalentgroupsInStructureDTO
    {
        public string message { get; set; }
        public List<TalentGroupsInDTO> obj { get; set; }
    }
}
