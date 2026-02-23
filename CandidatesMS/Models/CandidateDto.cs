using System.Collections.Generic;

namespace CandidatesMS.Models
{
    public class CandidateDTO
    {
        public int CandidateId { get; set; }
        public string CandidateGuid { get; set; }

        public int CompanyUserId { get; set; }

        public string Email { get; set; }

        public bool FullData { get; set; }

        public string CreationDate { get; set; }
        public string EditionDate { get; set; }
        public string FirstLoginDate { get; set; }
        public string DeleteDate { get; set; }
        public string LoginCode { get; set; }

        public int IsMigrated { get; set; }
        public bool IsFromCompanyAndLogin { get; set; }
        public bool isAuthorized { get; set; }
        public bool IsNew { get; set; }
        public bool IsDeleteProccess { get; set; }
        public bool IsAuthDocuments { get; set; }
        public bool IsAuthDocumentsHiring { get; set; }

        public string Source { get; set; }

        public string NameMemberUser { get; set; }
        public string SurnameMemberUser { get; set; }
        public string EmailMember { get; set; }

        //

        public ICollection<VideoDTO> VideoList { get; set; }
        public ICollection<StudyDTO> StudyList { get; set; }
        public ICollection<PersonalReferenceDTO> PersonalReferenceList { get; set; }
        public ICollection<Candidate_TechnicalAbilityDTO> Candidate_TechnicalAbilityList { get; set; }
        public ICollection<Candidate_LifePreferenceDTO> Candidate_LifePreferenceList { get; set; }
        public ICollection<Candidate_SoftSkillDTO> Candidate_SoftSkillList { get; set; }
        public ICollection<WorkExperienceDTO> WorkExperienceList { get; set; }
        public ICollection<Candidate_LanguageDTO> Candidate_Language { get; set; }
        public ICollection<Candidate_LanguageOtherDTO> Candidate_LanguageOther { get; set; }
        public ICollection<LanguageOtherDTO> LanguageOther { get; set; }
        public ICollection<NoteDTO> Notes { get; set; }
        public ICollection<MailDTO> Mails { get; set; }

        //

        public BasicInformationDTO BasicInformation { get; set; }
        public DescriptionDTO Description { get; set; }
        public CompanyDescriptionDTO CompanyDescription { get; set; }
        public ExperienceCountDTO ExperienceCount { get; set; }

    }
}
