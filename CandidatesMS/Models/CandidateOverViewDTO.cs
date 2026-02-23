using CandidatesMS.Models.RemoteModels.In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Models
{
    public class CandidateOverViewDTO
    {
        public int CandidateId { get; set; }
        public string Email { get; set; }
        public string CandidateGuid { get; set; }
        public int CompanyUserId { get; set; }
        public string CreationDate { get; set; }
        public string CreationInfo { get; set; }
        public string CreationShortInfo { get; set; }
        public string CreationInfoPup { get; set; }
        public string EditionDate { get; set; }
        public string DeleteDate { get; set; }
        public string FullDeleteDate { get; set; }
        public string FirstLoginDate { get; set; }
        public string FirstLoginInfoPup { get; set; }
        public string LoginCode { get; set; }
        public string Photo { get; set; }
        public string PhotoByAdmin { get; set; }
        public int IsMigrated { get; set; }
        public bool IsFromCompanyAndLogin { get; set; }
        public bool IsAuthDocuments { get; set; }
        public bool IsAuthDocumentsHiring { get; set; }
        public bool IsNew { get; set; }
        public bool isAuthorized { get; set; }
        public string NameMemberUser { get; set; }
        public string SurnameMemberUser { get; set; }
        public string EmailMember { get; set; }
        public bool DeleteMember { get; set; }
        public string Initials { get; set; }
        public string ValidityDate { get; set; }
        public bool Validity { get; set; }
        public ICollection<Candidate_SoftSkillDTO> Candidate_SoftSkillList { get; set; }
        public ICollection<Candidate_TechnicalAbilityDTO> Candidate_TechnicalAbilityList { get; set; }
        public BasicInformationOverViewDTO BasicInformation { get; set; }
        public ICollection<Candidate_LanguageDTO> Candidate_Language { get; set; }
        public ICollection<LanguageOtherDTO> LanguageOther { get; set; }
        //public BasicInformationDTO BasicInformation { get; set; }
        public DescriptionDTO Description { get; set; }
        public ExperienceCountDTO ExperienceCount { get; set; }
        public CandidateBlockReasonInDTO CandidateBlockReason { get; set; }
        public RequestOverViewDTO requestUpdate { get; set; }
        public RequestOverViewDTO requestDelete { get; set; }

        public List<EventInDTO> Events { get; set; }
    }
}
