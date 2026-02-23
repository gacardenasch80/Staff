using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.ModelsCompany;
using System.Collections.Generic;

namespace CandidatesMS.Models
{
    public class CandidateWithCompanyDTO
    {
        /* Id */
        public int CandidateId { get; set; }
        public string Email { get; set; }
        public int BasicInformationId { get; set; }

        /* Names */
        public string Name { get; set; }
        public string Surname { get; set; }
        public string FullName { get; set; }
        public string Initials { get; set; }

        /* Flags */
        public int IsMigrated { get; set; }
        public bool IsAuthorized { get; set; }
        public bool IsFromCompanyAndLogin { get; set; }
        public bool IsAuthDocuments { get; set; }
        public bool IsAuthDocumentsHiring { get; set; }
        public bool IsPotential { get; set; }

        /* Dates */
        public string CreationDate { get; set; }
        public string CreationInfo { get; set; }
        public string CreationInfoEnglish { get; set; }
        public string CreationShortInfo { get; set; }
        public string CreationInfoPup { get; set; }
        public string CreationInfoPupEnglish { get; set; }
        public string EditionDate { get; set; }
        public string DeleteDate { get; set; }
        public string FullDeleteDate { get; set; }
        public string FirstLoginDate { get; set; }
        public string FirstLoginInfoPup { get; set; }
        public string ValidityDate { get; set; }
        public bool Validity { get; set; }


        /* Member is deleted? */
        public bool DeleteMember { get; set; }

        /* Multimedia */
        public string Photo { get; set; }
        public VideoDTO Video { get; set; }

        /* Country */
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        /* Phones by candidate */
        public string Phone { get; set; }
        public string Cellphone { get; set; }

        /* Links by candidate */
        public string LinkedInURL { get; set; }
        public string FacebookURL { get; set; }
        public string TwitterURL { get; set; }
        public string GitHubURL { get; set; }
        public string BitBucketURL { get; set; }

        /* Counts */
        public string Years { get; set; }
        public int CompaniesNumber { get; set; }

        /* Basic Data From Candidate */
        public int HaveWorkExperience { get; set; }
        public string Address { get; set; }
        public string BirthDate { get; set; }
        public string Document { get; set; }

        public DocumentTypeDTO DocumentType { get; set; }
        public MaritalStatusDTO MaritalStatus { get; set; }
        public GenderDTO Gender { get; set; }

        public string SalaryAspiration { get; set; }
        public CurrencyDTO Currency { get; set; }

        /* Company */
        public int CompanyUserId { get; set; }
        public CandidateCompanyDTO CompanyData { get; set; }

        /* Document Check fields */
        public DocumentCheckStructureDTO DocumentCheckStructure { get; set; }

        /* Description fields */
        public DescriptionDTO Description { get; set; }
        public CompanyDescriptionDTO CompanyDescription { get; set; }

        /* Studies Lists */
        public List<StudyDTO> StudyFullList { get; set; }
        public List<StudyDTO> StudyFromCandidateList { get; set; }
        public List<StudyDTO> StudyFromCompanyList { get; set; }

        /* Languages Lists */
        public List<Candidate_LanguageDTO> LanguagesFromCandidateList { get; set; }
        public List<Candidate_LanguageDTO> LanguagesOtherFromCandidateList { get; set; }
        public List<Candidate_LanguageDTO> LanguagesFromCompanyList { get; set; }
        public List<Candidate_LanguageDTO> LanguagesOtherFromCompanyList { get; set; }

        /* Soft Skills Lists */
        public List<Candidate_SoftSkillDTO> SoftSkillsFullList { get; set; }
        public List<Candidate_SoftSkillDTO> SoftSkillsFromCandidateList { get; set; }
        public List<Candidate_SoftSkillDTO> SoftSkillsFromCompanyList { get; set; }

        /* Technical abilities Lists */
        public List<Candidate_TechnicalAbilityDTO> TechnicalAbilitiesFullList { get; set; }
        public List<Candidate_TechnicalAbilityDTO> TechnicalAbilitiesFromCandidateList { get; set; }
        public List<Candidate_TechnicalAbilityDTO> TechnicalAbilitiesFromCompanyList { get; set; }

        /* Work Experiences Lists */
        public List<WorkExperienceDTO> WorkExperienceFullList{ get; set; }
        public List<WorkExperienceDTO> WorkExperienceFromCandidateList { get; set; }
        public List<WorkExperienceDTO> WorkExperienceFromCompanyList { get; set; }
        
        /* Personal References Lists */
        public List<PersonalReferenceDTO> PersonalReferenceFromCandidateList { get; set; }
        public List<PersonalReferenceDTO> PersonalReferenceFromCompanyList { get; set; }

        /* Life Preferences Lists */
        public List<Candidate_LifePreferenceDTO> LifePreferenceFromCandidateList { get; set; }
        public List<Candidate_LifePreferenceDTO> LifePreferenceFromCompanyList { get; set; }

        /* Job Preferences fields */
        public Candidate_JobPreferenceDto JobPreferencesFromCandidate { get; set; }
        public Company_Candidate_JobPreferenceDto JobPreferencesFromCompany { get; set; }

        /* Notes List */
        public List<NoteDTO> Notes { get; set; }

        /* Postulations List */
        public List<ModelsCompany.PostulationDTO> Postulations { get; set; }

        /* Postulations with Q&A List */
        public List<PostulationQuestionsAnswersDTO> PostulationsWithQuestionsAndAnswers { get; set; }

        /* TalentGroups List */
        public List<TalentGroupDTO> TalentGroups { get; set; }

        /* Tags List */
        public List<ModelsCompany.Candidate_TagDTO> Tags { get; set; }

        /* Sources List */
        public List<ModelsCompany.Candidate_SourceDTO> Sources { get; set; }

        /* Emails List */
        public List<EmailDTO> Emails { get; set; }

        /* Phones List */
        public List<PhoneDTO> Phones { get; set; }

        /* Social Networks List */
        public List<SocialNetworkDTO> SocialNetworks { get; set; }

        /* User Links List */
        public List<UserLinkDTO> UserLinks { get; set; }

        /* Requests */
        public RequestOverViewDTO RequestUpdate { get; set; }
        public RequestDeleteDTO RequestDelete { get; set; }
        public RequestOverViewDTO RequestDeleteOverview { get; set; }
        public ModelsCompany.Candidate_BlockReasonDTO CandidateBlockReason { get; set; }

        /* Events */
        public List<EventOutDTO> Events { get; set; }

        /* CV */
        public CVDTO CV { get; set; }
    }
}
