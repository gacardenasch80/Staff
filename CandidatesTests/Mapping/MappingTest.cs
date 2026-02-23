using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using AutoMapper;

namespace CandidatesTests.Mapping
{
    public class MappingTest : Profile
    {
        public MappingTest()
        {
            CreateMap<CandidateDTO, Candidate>();
            CreateMap<Candidate, CandidateDTO>();

            CreateMap<AttachedFileDTO, AttachedFile>();
            CreateMap<AttachedFile, AttachedFileDTO>();

            CreateMap<CVDTO, CV>();
            CreateMap<CV, CVDTO>();

            CreateMap<Candidate_LanguageDTO, LanguageOther>();

            CreateMap<TechnicalAbilityLevel, TechnicalAbilityLevelDTO>();
            CreateMap<TechnicalAbilityLevelDTO, TechnicalAbilityLevel>();
            CreateMap<TechnicalAbilityTechnology, TechnicalAbilityTechnologyDTO>();
            CreateMap<TechnicalAbilityTechnologyDTO, TechnicalAbilityTechnology>();
            CreateMap<Candidate_TechnicalAbility, Candidate_TechnicalAbilityDTO>();
            CreateMap<Candidate_TechnicalAbilityDTO, Candidate_TechnicalAbility>();

            CreateMap<PersonalReference, PersonalReferenceDTO>();
            CreateMap<PersonalReferenceDTO, PersonalReference>();

            CreateMap<BasicInformationDTO, BasicInformation>();
            CreateMap<BasicInformation, BasicInformationDTO>();
            CreateMap<DocumentTypeDTO, DocumentType>();
            CreateMap<DocumentType, DocumentTypeDTO>();
            CreateMap<GenderDTO, Gender>();
            CreateMap<Gender, GenderDTO>();

            CreateMap<LifePreference, LifePreferenceDTO>();
            CreateMap<LifePreferenceDTO, LifePreference>();
            CreateMap<Candidate_LifePreference, Candidate_LifePreferenceDTO>();
            CreateMap<Candidate_LifePreferenceDTO, Candidate_LifePreference>();

            CreateMap<Description, DescriptionDTO>();
            CreateMap<DescriptionDTO, Description>();

            CreateMap<SoftSkill, SoftSkillDTO>();
            CreateMap<SoftSkillDTO, SoftSkill>();
            CreateMap<Candidate_SoftSkill, Candidate_SoftSkillDTO>();
            CreateMap<Candidate_SoftSkillDTO, Candidate_SoftSkill>();

            CreateMap<WorkExperience, WorkExperienceDTO>();
            CreateMap<WorkExperienceDTO, WorkExperience>();
            CreateMap<Industry, IndustryDTO>();
            CreateMap<IndustryDTO, Industry>();
            CreateMap<EquivalentPosition, EquivalentPositionDTO>();
            CreateMap<EquivalentPositionDTO, EquivalentPosition>();

            CreateMap<Language, LanguageDTO>();
            CreateMap<LanguageDTO, Language>();
            CreateMap<LanguageLevel, LanguageLevelDTO>();
            CreateMap<LanguageLevelDTO, LanguageLevel>();
            CreateMap<LanguageOther, LanguageOtherDTO>();
            CreateMap<LanguageOtherDTO, LanguageOther>();
            CreateMap<Candidate_Language, Candidate_LanguageDTO>();
            CreateMap<Candidate_LanguageDTO, Candidate_Language>();

            CreateMap<Study, StudyDTO>();
            CreateMap<StudyDTO, Study>();

            CreateMap<Video, VideoDTO>();
            CreateMap<VideoDTO, Video>();

            // File Types
            CreateMap<FileType, FileTypeDTO>();
            CreateMap<FileTypeDTO, FileType>();

            // SocialNetworks
            CreateMap<SocialNetwork, SocialNetworkDTO>();
            CreateMap<SocialNetworkDTO, SocialNetwork>();

            // Phones
            CreateMap<Phone, PhoneDTO>();
            CreateMap<PhoneDTO, Phone>();
        }
    }
}
