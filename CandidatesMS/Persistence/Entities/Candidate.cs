using System;
using System.Collections.Generic;

namespace CandidatesMS.Persistence.Entities
{
    public class Candidate
    {
        public int CandidateId { get; set; }
        public string CandidateGuid { get; set; }

        public string Email { get; set; }
        public bool FullData { get; set; }

        public int CompanyUserId { get; set; }

        public string CreationDate { get; set; }
        public DateTime CreationDateNoText { get; set; }

        public string EditionDate { get; set; }
        public string DeleteDate { get; set; }
        public string FullDeleteDate { get; set; }
        public string FirstLoginDate { get; set; }
        public string LoginCode { get; set; }

        public int IsMigrated { get; set; }
        public bool IsFromCompanyAndLogin { get; set; }
        public bool IsAuthDocuments { get; set; }
        public bool IsAuthDocumentsHiring { get; set; }
        public string Source { get; set; }
        public bool IsNew { get; set; }
        public bool isAuthorized { get; set; }
        public bool IsDeleteProccess { get; set; }
        public bool ViewHiringFiles { get; set; }
        public bool ViewSelectionFiles { get; set; }
        public string NameMemberUser { get; set; }
        public string SurnameMemberUser { get; set; }
        public string EmailMember { get; set; }
        public string? EmailMemberDeleteProcess { get; set; }

        public ICollection<CompanyDescription> CompanyDescriptionList { get; set; }
        public ICollection<Video> VideoList { get; set; }
        public ICollection<Study> StudyList { get; set; }
        public ICollection<PersonalReference> PersonalReferenceList { get; set; }
        public ICollection<Candidate_TechnicalAbility> Candidate_TechnicalAbilityList { get; set; }
        public ICollection<Candidate_LifePreference> Candidate_LifePreferenceList { get; set; }
        public ICollection<Candidate_SoftSkill> Candidate_SoftSkillList { get; set; }
        public ICollection<Candidate_Wellness> Candidate_Wellness { get; set; }
        public ICollection<Candidate_TimeAvailability> Candidate_TimeAvailability { get; set; }
        public ICollection<Company_Candidate_Wellness> Company_Candidate_Wellness { get; set; }
        public ICollection<Company_Candidate_TimeAvailability> Company_Candidate_TimeAvailability { get; set; }
        public ICollection<WorkExperience> WorkExperienceList { get; set; }
        public ICollection<Candidate_Language> Candidate_Language { get; set; }
        public ICollection<Candidate_LanguageOther> Candidate_LanguageOther { get; set; }
        public ICollection<LanguageOther> LanguageOther { get; set; }
        public ICollection<Note> Notes { get; set; }
        public ICollection<Mail> Mails { get; set; }

        //public ICollection<AttachedFile> AttachedFiles { get; set; }
        //public ICollection<CV> CVS { get; set; }

        public ICollection<AttachedFileHiring> AttachedFilesHiring { get; set; }
        public ICollection<CVHiring> CVsHiring { get; set; }

        public ICollection<CandidateCompany> CandidateCompanies { get; set; }

        public ICollection<Candidate_Postulation> Candidate_Postulation { get; set; }
        public ICollection<Candidate_TalentGroupAux> Candidate_TalentGroup { get; set; }

        public ICollection<Candidate_Tag> Candidate_Tag { get; set; }
        public ICollection<Candidate_Source> Candidate_Source { get; set; }

        //

        public BasicInformation BasicInformation { get; set; }
        public Description Description { get; set; }
        public ExperienceCount ExperienceCount { get; set; }
        public ICollection<Request> Request { get; set; }
    }
}
