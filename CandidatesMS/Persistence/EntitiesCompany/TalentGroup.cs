using System.Collections.Generic;

namespace CandidatesMS.Persistence.EntitiesCompany
{
    public class TalentGroup
    {
        public int TalentGroupId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int CompanyUserId { get; set; }
        public string CreationDate { get; set; }
        public string EditedDate { get; set; }
        public bool IsEdit { get; set; }
        public string NameMemberUser { get; set; }
        public string SurnameMemberUser { get; set; }
        public string MemberUserEmail { get; set; }
        public int? InternalCodeId { get; set; }
        public InternalCode InternalCode { get; set; }
        public int? TalentGroupStatusId { get; set; }
        public int? TalentGroupPostingStatusId { get; set; }
        public TalentGroupPostingStatus TalentGroupPostingStatus { get; set; }
        public ICollection<MemberUserTalentGroup> MemberUserTalentGroup { get; set; }
        public ICollection<FollowTalentGroup> FollowTalentGroup { get; set; }
        public ICollection<Candidate_TalentGroup> Candidate_TalentGroup { get; set; }
    }
}
