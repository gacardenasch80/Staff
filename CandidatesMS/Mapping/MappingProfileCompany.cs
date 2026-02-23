using AutoMapper;
using CandidatesMS.ModelsCompany;
using CandidatesMS.Persistence.EntitiesCompany;
using System;
using System.Globalization;

namespace CandidatesMS.Mapping
{
    public class MappingProfileCompany : Profile
    {

        public MappingProfileCompany()
        {
            CreateMap<CompanyUserDTO, CompanyUser>();
            CreateMap<CompanyUser, CompanyUserDTO>();

            CreateMap<CompanyUser, CompanyUserJobsDTO>();
            CreateMap<CompanyUserJobsDTO, CompanyUser>();

            CreateMap<CompanyUserListFormatDTO, CompanyUser>();
            CreateMap<CompanyUser, CompanyUserListFormatDTO>();

            CreateMap<RoleDTO, Role>();
            CreateMap<Role, RoleDTO>();

            CreateMap<PermissionDTO, Permission>();
            CreateMap<Permission, PermissionDTO>();

            CreateMap<Job_JobSoftSkillDTO, Job_JobSoftSkill>();
            CreateMap<Job_JobSoftSkill, Job_JobSoftSkillDTO>();

            CreateMap<Job_JobTechnicalAbilityDTO, Job_JobTechnicalAbility>();
            CreateMap<Job_JobTechnicalAbility, Job_JobTechnicalAbilityDTO>();

            CreateMap<JobDTO, Job>()
                .ForMember(x => x.PublicationDate, opt => opt.MapFrom(src => (new DateTime(1970, 1, 1)).AddMilliseconds(double.Parse(src.PublicationDate))))
                .ForMember(x => x.CreationDate, opt => opt.MapFrom(z => DateTime.ParseExact(z.CreationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)));


            CreateMap<Job, JobDTO>().ForMember(x => x.CreationDate, opt => opt.MapFrom(src => ((DateTime)src.CreationDate).ToString("dd MMMM yyyy", new CultureInfo("es-ES"))))
                                         .ForMember(x => x.PublicationDate, opt => opt.MapFrom(src => ((DateTime)src.PublicationDate).ToString("dd MMMM yyyy", new CultureInfo("es-ES"))))
                                         .ForMember(x => x.EditedDate, opt => opt.MapFrom(src => ((DateTime)src.EditedDate).ToString("dd MMMM yyyy", new CultureInfo("es-ES"))))
                                         .ForMember(x => x.FilingDate, opt => opt.MapFrom(src => ((DateTime)src.FilingDate).ToString("dd MMMM yyyy", new CultureInfo("es-ES"))))
                                         .ForMember(x => x.DeletionDate, opt => opt.MapFrom(src => ((DateTime)src.DeletionDate).ToString("dd MMMM yyyy", new CultureInfo("es-ES"))))
                                         .ForMember(x => x.ClosingDate, opt => opt.MapFrom(src => ((DateTime)src.ClosingDate).ToString("dd MMMM yyyy", new CultureInfo("es-ES"))));
            CreateMap<Job, JobCandidateListDTO>().ForMember(x => x.CreationDate, opt => opt.MapFrom(src => ((DateTime)src.CreationDate).ToString("dd MMMM yyyy", new CultureInfo("es-ES"))))
                                         .ForMember(x => x.PublicationDate, opt => opt.MapFrom(src => ((DateTime)src.PublicationDate).ToString("dd MMMM yyyy", new CultureInfo("es-ES"))))
                                         .ForMember(x => x.EditedDate, opt => opt.MapFrom(src => ((DateTime)src.EditedDate).ToString("dd MMMM yyyy", new CultureInfo("es-ES"))))
                                         .ForMember(x => x.FilingDate, opt => opt.MapFrom(src => ((DateTime)src.FilingDate).ToString("dd MMMM yyyy", new CultureInfo("es-ES"))))
                                         .ForMember(x => x.DeletionDate, opt => opt.MapFrom(src => ((DateTime)src.DeletionDate).ToString("dd MMMM yyyy", new CultureInfo("es-ES"))))
                                         .ForMember(x => x.ClosingDate, opt => opt.MapFrom(src => ((DateTime)src.ClosingDate).ToString("dd MMMM yyyy", new CultureInfo("es-ES"))));
            CreateMap<JobListsDTO, Job>();
            CreateMap<Job, JobListsDTO>();

            CreateMap<JobLevelDTO, JobLevel>();
            CreateMap<JobLevel, JobLevelDTO>();
            CreateMap<JobSubLevelDTO, JobSubLevel>();
            CreateMap<JobSubLevel, JobSubLevelDTO>();
            CreateMap<WorkAreaDTO, WorkArea>();
            CreateMap<WorkArea, WorkAreaDTO>();
            CreateMap<JobOutDTO, Job>();
            CreateMap<Job, JobOutDTO>().ForMember(x => x.CreationDate, opt => opt.MapFrom(src => ((DateTime)src.CreationDate).ToString("dd MMMM yyyy", new CultureInfo("es-ES"))))
                                         .ForMember(x => x.PublicationDate, opt => opt.MapFrom(src => ((DateTime)src.PublicationDate).ToString("dd MMMM yyyy", new CultureInfo("es-ES"))))
                                         .ForMember(x => x.EditedDate, opt => opt.MapFrom(src => ((DateTime)src.EditedDate).ToString("dd MMMM yyyy", new CultureInfo("es-ES"))))
                                         .ForMember(x => x.FilingDate, opt => opt.MapFrom(src => ((DateTime)src.FilingDate).ToString("dd MMMM yyyy", new CultureInfo("es-ES"))))
                                         .ForMember(x => x.DeletionDate, opt => opt.MapFrom(src => ((DateTime)src.DeletionDate).ToString("dd MMMM yyyy", new CultureInfo("es-ES"))))
                                         .ForMember(x => x.ClosingDate, opt => opt.MapFrom(src => ((DateTime)src.ClosingDate).ToString("dd MMMM yyyy", new CultureInfo("es-ES"))));

            CreateMap<JobLocationDTO, JobLocation>();
            CreateMap<JobLocation, JobLocationDTO>();
            CreateMap<JobSoftSkillDTO, JobSoftSkill>();
            CreateMap<JobSoftSkill, JobSoftSkillDTO>();
            CreateMap<JobTechnicalAbilityDTO, JobTechnicalAbility>();
            CreateMap<JobTechnicalAbility, JobTechnicalAbilityDTO>();

            CreateMap<JobPostingStatusDTO, JobPostingStatus>();
            CreateMap<JobPostingStatus, JobPostingStatusDTO>();
            CreateMap<FollowJobDTO, FollowJob>();
            CreateMap<FollowJob, FollowJobDTO>();

            CreateMap<JobContractDTO, JobContract>();
            CreateMap<JobContract, JobContractDTO>();
            CreateMap<JobEducationLevelDTO, JobEducationLevel>();
            CreateMap<JobEducationLevel, JobEducationLevelDTO>();
            CreateMap<JobExperienceDTO, JobExperience>();
            CreateMap<JobExperience, JobExperienceDTO>();
            CreateMap<JobLanguageDTO, JobLanguage>();
            CreateMap<JobLanguage, JobLanguageDTO>();
            CreateMap<JobLanguageLevelDTO, JobLanguageLevel>();
            CreateMap<JobLanguageLevel, JobLanguageLevelDTO>();
            CreateMap<JobModalityDTO, JobModality>();
            CreateMap<JobModality, JobModalityDTO>();
            CreateMap<JobProfessionDTO, JobProfession>();
            CreateMap<JobProfession, JobProfessionDTO>();
            CreateMap<JobSectorDTO, JobSector>();
            CreateMap<JobSector, JobSectorDTO>();
            CreateMap<Job_OtherSector, Job_OtherSectorDTO>();
            CreateMap<Job_OtherSectorDTO, Job_OtherSector>();

            CreateMap<PostulationDTO, Postulation>();
            CreateMap<Postulation, PostulationDTO>();
            CreateMap<Postulation, PostulationQuestionsAnswersDTO>();
            CreateMap<PostulationQuestionsAnswersDTO, Postulation>();
            CreateMap<PostulationDTO, PostulationQuestionsAnswersDTO>();
            CreateMap<PostulationQuestionsAnswersDTO, PostulationDTO>();

            CreateMap<PostulationStageDTO, PostulationStage>();
            CreateMap<PostulationStage, PostulationStageDTO>();
            CreateMap<PostulationStageListDTO, PostulationStage>();
            CreateMap<PostulationStage, PostulationStageListDTO>();

            CreateMap<PostulationStateDTO, PostulationState>();
            CreateMap<PostulationState, PostulationStateDTO>();

            CreateMap<DisqualificationReasonDTO, DisqualificationReason>();
            CreateMap<DisqualificationReason, DisqualificationReasonDTO>();

            CreateMap<DefaultBlockReasonDTO, DefaultBlockReason>();
            CreateMap<DefaultBlockReason, DefaultBlockReasonDTO>();

            CreateMap<BlockReasonDTO, BlockReason>();
            CreateMap<BlockReason, BlockReasonDTO>();

            CreateMap<Candidate_BlockReasonDTO, Candidate_BlockReason>();
            CreateMap<Candidate_BlockReason, Candidate_BlockReasonDTO>();

            CreateMap<InternalCodeDTO, InternalCode>();
            CreateMap<InternalCode, InternalCodeDTO>();

            CreateMap<GuestUser, GuestUserDTO>();
            CreateMap<GuestUserDTO, GuestUser>();

            CreateMap<MemberUser, MemberUserDTO>();
            CreateMap<MemberUserDTO, MemberUser>();

            CreateMap<MemberUser, Models.RemoteModels.In.MemberByToken>();
            CreateMap<Models.RemoteModels.In.MemberByToken, MemberUser>();

            CreateMap<MemberUser, MemberUserByEvaluationReportDTO>();
            CreateMap<MemberUserByEvaluationReportDTO, MemberUser>();

            CreateMap<MemberUserByEvaluationReportDTO, MemberUserDTO>();
            CreateMap<MemberUserDTO, MemberUserByEvaluationReportDTO>();

            CreateMap<ActionUser, ActionUserDTO>();
            CreateMap<ActionUserDTO, ActionUser>();

            CreateMap<TalentGroupDTO, TalentGroup>();
            CreateMap<TalentGroup, TalentGroupDTO>();

            CreateMap<FollowTalentGroupDTO, FollowTalentGroup>();
            CreateMap<FollowTalentGroup, FollowTalentGroupDTO>();

            CreateMap<Candidate_TalentGroupDTO, Candidate_TalentGroup>();
            CreateMap<Candidate_TalentGroup, Candidate_TalentGroupDTO>();

            CreateMap<JobCurrencyDTO, JobCurrency>();
            CreateMap<JobCurrency, JobCurrencyDTO>();

            CreateMap<JobLocationModalityDTO, JobLocationModality>();
            CreateMap<JobLocationModality, JobLocationModalityDTO>();

            CreateMap<JobTechnicalAbilityLevelDTO, JobTechnicalAbilityLevel>();
            CreateMap<JobTechnicalAbilityLevel, JobTechnicalAbilityLevelDTO>();

            CreateMap<Job_JobSoftSkillDTO, Job_JobSoftSkill>();
            CreateMap<Job_JobSoftSkill, Job_JobSoftSkillDTO>();

            CreateMap<Job_JobTechnicalAbilityDTO, Job_JobTechnicalAbility>();
            CreateMap<Job_JobTechnicalAbility, Job_JobTechnicalAbilityDTO>();

            CreateMap<Job_OtherTechnicalAbilityDTO, Job_OtherTechnicalAbility>();
            CreateMap<Job_OtherTechnicalAbility, Job_OtherTechnicalAbilityDTO>();

            CreateMap<Job_JobProfessionDTO, Job_JobProfession>();
            CreateMap<Job_JobProfession, Job_JobProfessionDTO>();

            CreateMap<Job_OtherProfessionDTO, Job_OtherProfession>();
            CreateMap<Job_OtherProfession, Job_OtherProfessionDTO>();

            CreateMap<Job_JobLanguageDTO, Job_JobLanguage>();
            CreateMap<Job_JobLanguage, Job_JobLanguageDTO>();

            CreateMap<Job_OtherLenguageDTO, Job_OtherLanguage>();
            CreateMap<Job_OtherLanguage, Job_OtherLenguageDTO>();

            CreateMap<Job_MemberUser, Job_MemberUserDTO>();
            CreateMap<Job_MemberUserDTO, Job_MemberUser>();

            CreateMap<Job, JobMemberDTO>();
            CreateMap<JobMemberDTO, Job>();

            CreateMap<MemberUser_TGComercial, MemberUser_TGComercialDTO>();

            CreateMap<EventType, EventTypeDTO>();
            CreateMap<EventTypeDTO, EventType>();

            CreateMap<Duration, DurationDTO>();
            CreateMap<DurationDTO, Duration>();

            CreateMap<SearchHistory, SearchHistoryDTO>();
            CreateMap<SearchHistoryDTO, SearchHistory>();

            CreateMap<TimeZoneEvent, TimeZoneEventDTO>();
            CreateMap<TimeZoneEventDTO, TimeZoneEvent>();

            CreateMap<Event, EventDTO>();
            CreateMap<EventDTO, Event>();

            CreateMap<Event, EventOutDTO>();
            CreateMap<Event, EventOverViewDTO>();
            CreateMap<Event_MemberUser, Event_MemberUserDTO>();
            CreateMap<MemberUser, MemberUserOutDTO>().ForMember(x => x.Initials, opt => opt.MapFrom(src => (src.Name[0] + "" + src.Surname[0]).ToUpper()));

            CreateMap<Event, EventCalendarDTO>();
            CreateMap<EventCalendarDTO, Event>();

            CreateMap<CalendarEvent, CalendarEventDTO>();
            CreateMap<CalendarEventDTO, CalendarEvent>();

            CreateMap<Candidate_TalentGroup, Candidate_TGDTO>();
            CreateMap<Candidate_TGDTO, Candidate_TalentGroup>();

            CreateMap<EvaluationCriteriaType, EvaluationCriteriaTypeDTO>();
            CreateMap<EvaluationCriteriaTypeDTO, EvaluationCriteriaType>();

            CreateMap<DefaultEvaluationCriteria, DefaultEvaluationCriteriaDTO>();
            CreateMap<DefaultEvaluationCriteriaDTO, DefaultEvaluationCriteria>();

            CreateMap<EvaluationCriteria, EvaluationCriteriaDTO>();
            CreateMap<EvaluationCriteriaDTO, EvaluationCriteria>();

            CreateMap<EvaluationCriteria, EvaluationCriteriaByReportDTO>();
            CreateMap<EvaluationCriteriaByReportDTO, EvaluationCriteria>();

            CreateMap<EvaluationCriteriaByReportDTO, EvaluationCriteriaDTO>();
            CreateMap<EvaluationCriteriaDTO, EvaluationCriteriaByReportDTO>();

            CreateMap<Evaluation, EvaluationDTO>();
            CreateMap<EvaluationDTO, Evaluation>();

            CreateMap<Evaluation, EvaluationByReportDTO>();
            CreateMap<EvaluationByReportDTO, Evaluation>();

            CreateMap<EvaluationDTO, EvaluationByReportDTO>();
            CreateMap<EvaluationByReportDTO, EvaluationDTO>();

            CreateMap<PercentCriteria, PercentCriteriaDTO>();
            CreateMap<PercentCriteriaDTO, PercentCriteria>();

            CreateMap<EvaluationCriteriaByReportDTO, PercentCriteriaDTO>();
            CreateMap<PercentCriteriaDTO, EvaluationCriteriaByReportDTO>();

            CreateMap<EvaluationCriteriaByReportDTO, PercentCriteria>();
            CreateMap<PercentCriteria, EvaluationCriteriaByReportDTO>();

            CreateMap<DefaultPercentCriteria, DefaultPercentCriteriaDTO>();
            CreateMap<DefaultPercentCriteriaDTO, DefaultPercentCriteria>();

            CreateMap<Answer, AnswerDTO>();
            CreateMap<AnswerDTO, Answer>();

            CreateMap<Question, QuestionDTO>();
            CreateMap<QuestionDTO, Question>();

            CreateMap<QuestionType, QuestionTypeDTO>();
            CreateMap<QuestionTypeDTO, QuestionType>();

            CreateMap<JobType, JobTypeDTO>();
            CreateMap<JobTypeDTO, JobType>();

            CreateMap<JobType, JobTypeReportDTO>();
            CreateMap<JobTypeReportDTO, JobType>();

            CreateMap<Candidate_Tag, Candidate_TagDTO>();
            CreateMap<Candidate_TagDTO, Candidate_Tag>();

            CreateMap<Candidate_Source, Candidate_SourceDTO>();
            CreateMap<Candidate_SourceDTO, Candidate_Source>();

            CreateMap<MemberUser, Models.RemoteModels.In.MemberUserByToken>();
            CreateMap<Models.RemoteModels.In.MemberUserByToken, MemberUser>();
        }
    }
}
