using AutoMapper;
using CandidatesMS.Models;
using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.Models.RemoteModels.Out;
using CandidatesMS.Persistence.Entities;

namespace CandidatesMS.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CandidateDTO, Candidate>();
            CreateMap<Candidate, CandidateDTO>();
            CreateMap<Candidate, CandidateOverViewDTO>();

            CreateMap<Candidate, CandidateNotificationDTO>();
            CreateMap<CandidateNotificationDTO, Candidate>();

            CreateMap<Candidate, CandidateFullDTO>();
            CreateMap<CandidateFullDTO, Candidate>();

            CreateMap<Candidate, CandidateWithCompanyDTO>();
            CreateMap<CandidateWithCompanyDTO, Candidate>();

            CreateMap<CandidateCompany, CandidateCompanyDTO>();
            CreateMap<CandidateCompanyDTO, CandidateCompany>();

            CreateMap<StudyCertificateDTO, StudyCertificate>();
            CreateMap<StudyCertificate, StudyCertificateDTO>();

            CreateMap<AttachedFileDTO, AttachedFile>();
            CreateMap<AttachedFile, AttachedFileDTO>();

            CreateMap<AttachedFileHiringDTO, AttachedFileHiring>();
            CreateMap<AttachedFileHiring, AttachedFileHiringDTO>();

            CreateMap<CVDTO, CV>();
            CreateMap<CV, CVDTO>();

            //CV Hiring
            CreateMap<CVHiring, CVHiringDTO>();
            CreateMap<CVHiringDTO, CVHiring>();

            CreateMap<EmailDTO, Email>().ForMember(x => x.EmailId, opt => opt.Ignore());
            CreateMap<Email, EmailDTO>();

            CreateMap<UserLinkDTO, UserLink>().ForMember(x => x.UserLinkId, opt => opt.Ignore());
            CreateMap<UserLink, UserLinkDTO>();

            CreateMap<StudyDTO, Study>();
            CreateMap<Study, StudyDTO>();

            CreateMap<StudyAreaDTO, StudyArea>();
            CreateMap<StudyArea, StudyAreaDTO>();

            CreateMap<StudyTypeDTO, StudyType>();
            CreateMap<StudyType, StudyTypeDTO>();

            CreateMap<TitleDTO, Title>();
            CreateMap<Title, TitleDTO>();

            CreateMap<CertificationStateDTO, CertificationState>();
            CreateMap<CertificationState, CertificationStateDTO>();

            CreateMap<RelationTypeDTO, RelationType>();
            CreateMap<RelationType, RelationTypeDTO>();

            CreateMap<TechnicalAbilityLevel, TechnicalAbilityLevelDTO>();
            CreateMap<TechnicalAbilityLevelDTO, TechnicalAbilityLevel>();
            CreateMap<TechnicalAbilityTechnology, TechnicalAbilityTechnologyDTO>();
            CreateMap<TechnicalAbilityTechnologyDTO, TechnicalAbilityTechnology>();
            CreateMap<Candidate_TechnicalAbility, Candidate_TechnicalAbilityDTO>();
            CreateMap<Candidate_TechnicalAbilityDTO, Candidate_TechnicalAbility>();
            
            CreateMap<Candidate_TechnicalAbilityDTO, Candidate_TechnicalAbility>();

            CreateMap<PersonalReference, PersonalReferenceDTO>();
            CreateMap<PersonalReferenceDTO, PersonalReference>();

            CreateMap<BasicInformationDTO, BasicInformation>();
            CreateMap<BasicInformation, BasicInformationDTO>();
            CreateMap<BasicInformation, BasicInformationOverViewDTO>();
            CreateMap<BasicInformationsDTO, BasicInformation>();
            CreateMap<BasicInformation, BasicInformationsDTO>();
            CreateMap<BasicInformationCandidateSectionDTO, BasicInformation>();
            CreateMap<BasicInformation, BasicInformationCandidateSectionDTO>();
            CreateMap<DocumentTypeDTO, DocumentType>();
            CreateMap<DocumentType, DocumentTypeDTO>();
            CreateMap<GenderDTO, Gender>();
            CreateMap<Gender, GenderDTO>();
            CreateMap<MaritalStatusDTO, MaritalStatus>();
            CreateMap<MaritalStatus, MaritalStatusDTO>();

            CreateMap<BasicInformationFullDTO, BasicInformation>();
            CreateMap<BasicInformation, BasicInformationFullDTO>();

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

            CreateMap<Candidate_Language, Candidate_LanguageFullDTO>();
            CreateMap<Candidate_LanguageFullDTO, Candidate_Language>();

            CreateMap<Video, VideoDTO>();
            CreateMap<VideoDTO, Video>();

            CreateMap<ExperienceCount, ExperienceCountDTO>();
            CreateMap<ExperienceCountDTO, ExperienceCount>();

            CreateMap<Wellness, WellnessDTO>();
            CreateMap<WellnessDTO, Wellness>();
            CreateMap<TimeAvailability, TimeAvailabilityDTO>();
            CreateMap<TimeAvailabilityDTO, TimeAvailability>();

            // CandidatesRecruitee
            CreateMap<RecruiteeCandidateInDTO, RecruiteeCandidateOutDTO>();
            CreateMap<RecruiteeCandidateOutDTO, RecruiteeCandidateInDTO>();
            CreateMap<CandidateInDTO, CandidateOutDTO>();
            CreateMap<CandidateOutDTO, CandidateInDTO>();
            CreateMap<ReferenceIn, ReferenceOut>();
            CreateMap<ReferenceOut, ReferenceIn>();

            // File Types
            CreateMap<FileType, FileTypeDTO>();
            CreateMap<FileTypeDTO, FileType>();

            //File Types Hiring
            CreateMap<FileTypeHiring, FileTypeHiringDTO>();
            CreateMap<FileTypeHiringDTO, FileTypeHiring>();

            // SocialNetworks
            CreateMap<SocialNetwork, SocialNetworkDTO>();
            CreateMap<SocialNetworkDTO, SocialNetwork>();

            // Phones
            CreateMap<Phone, PhoneDTO>();
            CreateMap<PhoneDTO, Phone>();

            // Study States
            CreateMap<StudyState, StudyStateDTO>();
            CreateMap<StudyStateDTO, StudyState>();

            // CompanyDescription
            CreateMap<CompanyDescription, CompanyDescriptionDTO>();
            CreateMap<CompanyDescriptionDTO, CompanyDescription>();

            // Notes
            CreateMap<Note, NoteDTO>();
            CreateMap<NoteDTO, Note>();

            //MentionMemberUser

            CreateMap<MentionMemberUser, MentionMemberUserDTO>();
            CreateMap<MentionMemberUserDTO, MentionMemberUser>();

            // DocumentCheck
            CreateMap<DocumentCheck, DocumentCheckDTO>();
            CreateMap<DocumentCheckDTO, DocumentCheck>();

            // Mail
            CreateMap<Mail, MailDTO>();
            CreateMap<MailDTO, Mail>();

            // Currency
            CreateMap<Currency, CurrencyDTO>();
            CreateMap<CurrencyDTO, Currency>();

            // AttachedFileMail
            CreateMap<AttachedFileMail, AttachedFileMailDTO>();
            CreateMap<AttachedFileMailDTO, AttachedFileMail>();

            // CC
            CreateMap<CC, CCDTO>();
            CreateMap<CCDTO, CC>();

            // CCO
            CreateMap<CCO, CCODTO>();
            CreateMap<CCODTO, CCO>();

            // CC
            CreateMap<CCRemote, CCDTO>();
            CreateMap<CCDTO, CCRemote>();

            // CCO
            CreateMap<CCORemote, CCODTO>();
            CreateMap<CCODTO, CCORemote>();

            // Request
            CreateMap<Request, RequestDTO>();
            CreateMap<RequestDTO, Request>();

            CreateMap<MemberUserRemoteDTO, MemberByToken>();

            CreateMap<Candidate_Postulation, Candidate_PostulationDTO>();
            CreateMap<Candidate_PostulationDTO, Candidate_Postulation>();

            CreateMap<Candidate_TalentGroupAux, Candidate_TalentGroupDTO>();
            CreateMap<Candidate_TalentGroupDTO, Candidate_TalentGroupAux>();

            CreateMap<Candidate_Tag, Candidate_TagDTO>();
            CreateMap<Candidate_TagDTO, Candidate_Tag>();

            CreateMap<Candidate_Source, Candidate_SourceDTO>();
            CreateMap<Candidate_SourceDTO, Candidate_Source>();

            CreateMap<AnalyzeCVDataDTO, AnalyzeCVData>();
            CreateMap<AnalyzeCVData, AnalyzeCVDataDTO>();

            CreateMap<CandidateOriginDTO, CandidateOrigin>();
            CreateMap<CandidateOrigin, CandidateOriginDTO>();
        }
    }
}