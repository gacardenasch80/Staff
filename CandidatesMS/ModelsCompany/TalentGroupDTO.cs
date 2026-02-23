using CandidatesMS.Persistence.EntitiesCompany;
using System.Collections.Generic;
using System;

namespace CandidatesMS.ModelsCompany
{
    public class TalentGroupDTO
    {
        public int TalentGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyUserId { get; set; }
        public int? InternalCodeId { get; set; }
        public string CreationDate { get; set; }
        public string CreationDateEnglish { get; set; }
        public string EditedDate { get; set; }
        public string CreationInfo { get; set; }
        public string CreationInfoEnglish { get; set; }
        public string CreationShortInfo { get; set; }
        public string CreationInfoPup { get; set; }
        public string InternalCodeName { get; set; }
        public bool? Following { get; set; }
        public bool IsEdit { get; set; }
        public int[] MemberUserIds { get; set; }

        public int ColourFlag { get; set; }
        public DateTime CreationDateLastEvaluation { get; set; }
        public string PercentResumeFormat { get; set; }

        public int? TalentGroupPostingStatusId { get; set; }

        public List<MemberUser> MembersUsers { get; set; }
        public MembersUsersRoleDTO MembersUsersRoleDTO { get; set; }
        public int CountCandidates { get; set; }
    }
}
