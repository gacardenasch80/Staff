using AutoMapper;
using CandidatesMS.Helpers;
using CandidatesMS.KeyVault.SecretsModels;
using CandidatesMS.Models;
using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.Models.RemoteModels.Out;
using CandidatesMS.ModelsCompany;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Persistence.Infraestructure.Services;
using CandidatesMS.Repositories;
using CandidatesMS.Repositories.RemoteRepositories;
using CandidatesMS.RepositoriesCompany;
using CandidatesMS.KeyVault.SecretsModels;
using CandidatesMS.ServicesCompany;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CandidatesMS.Services
{
    public interface ICandidateService
    {
        Task<List<CandidateDTO>> CreateCandidates(List<AnalyzeDTO> candidatesToCreate, string memberEmail, string memberName, string membersurName);
        Task<BasicInformation> CreateBasicInformation(Candidate candidate, AnalyzeDTO analyze, string memberEmail, string memberName, int currencyId);
        Task<bool> CreatedJobs(List<int> candidates, List<int> jobs, string token);
        Task<bool> CreatedTalentGroups(List<int> candidates, List<int> talentGroups, string token);
        Task<List<CVDTO>> CreateCandidateCV(List<IFormFile> files, List<AnalyzeDTO> analizeList, string token);
        Task<List<StudyDTO>> FullStudiesByOverviewWithCompany(Candidate candidate, int companyUserId, string token);
        List<WorkExperienceDTO> FullWorkExperiencesByOverviewWithCompany(Candidate candidate, int companyUserId);
        List<WorkExperienceDTO> FullWorkExperiencesByOverviewWithCompanyOrderByCurrentWorking(Candidate candidate, int companyUserId);
        Task<NoteCandidateSectionTotalDTO> GetNotesFromCandidateInTalentGroup(SearchByIdAndTextWithPaginationDTO search, string token);
        Task<NoteCandidateSectionTotalDTO> GetNotesFromCandidateInTalentGroupAndSearch(SearchByIdAndTextWithPaginationDTO search, string token);
        Task<NoteCandidateSectionTotalDTO> GetNotesFromCandidateInJob(SearchByIdAndTextWithPaginationDTO search, string token);
        Task<NoteCandidateSectionTotalDTO> GetNotesFromCandidateInJobAndSearch(SearchByIdAndTextWithPaginationDTO search, string token);
        Task<candidateSearchTotalDTO> GetAllCandidateSearch(SearchByIdAndTextWithPaginationDTO search, int companyUserId, int userType, string token);
        Task<candidateSearchTotalDTO> GetAllCandidateSearchMaster(SearchByIdAndTextWithPaginationDTO search, string token);
        Task<candidateSearchTotalDTO> GetAllCandidateFromTalentGroupAndSearch(SearchByIdAndTextWithPaginationDTO search, int companyUserId, string token);
        Task<candidateSearchTotalDTO> SearchCandidatesByTalentGroup(SearchByIdAndTextWithPaginationDTO search, int companyUserId, string token);
        Task<candidateSearchTotalDTO> GetAllCandidateFromJobAndSearch(SearchByIdAndTextWithPaginationDTO search, int companyUserId, string token);
        Task<candidateSearchTotalDTO> SearchCandidatesByJob(SearchByIdAndTextWithPaginationDTO search, int companyUserId, string token);
        Task<candidateSearchTotalDTO> SearchCandidatesGeneral(SearchByIdAndTextWithPaginationDTO search, int companyUserId, bool isExsis, bool isMaster, string token);
        Task<List<CandidateReportDTO>> GetAllCandidatesWithDate(string leftDate, string rightDate, string emailMemberUser, int portalId, int companyUserId, int languagePlatform);
        Task<List<CandidateReportConfigurableDTO>> GetAllCandidatesWithDateAndFilter
        (
            string emailMemberUser,
            bool isLanguagesFilter, bool IsFullLanguages, List<Candidate_LanguageDTO> languagesFilter,
            bool isTechnicalAbilitiesFilter, bool isFullTechnicalAbilities, List<Candidate_TechnicalAbilityDTO> technicalAbilitiesFilter,
            bool isLocationFilter, bool isFullLocations, string country, string state, string city,
            bool isSalaryAspirationFilter, bool isFullSalaryAspirations, List<SalaryAspirationFromSearchDTO> salaryAspirationFilter,
            int portalId, int companyUserId, int languagePlatform
        );
        Task<Candidate> GetCandidateToRequest(RequestDTO request);
        Task<countsHVDTO> getCountsByCandidateId(int candidateId, string token);

        Task<CandidateWithCompanyDTO> GetOverviewWithCompany(string token, int candidateId, int companyUserId, string memberUserName, string memberUserSurname, MemberUserDTO memberUser, List<MemberUserDTO> memberUserList);

    }
    public class CandidateService : ICandidateService
    {
        private ICandidateRepository _candidateRepository;
        private IGenderRepository _genderRepository;
        private ICompanyRemoteRepository _companyRemoteRepository;
        private IMapper _mapper;
        private ICvGenerator _cvGenerator;
        private IDataRegisterCountService _dataRegisterCountService;
        private IAuthorizationHelper _authorizationHelper;
        private IMaritalStatusRepository _maritalStatusRepository;
        private IDocumentTypeRepository _documentTypeRepository;
        private ICandidateLanguageRepository _candidateLanguageRepository;
        private ILanguageOtherRepository _languageOtherRepository;
        private IBasicInformationRepository _basicInformationRepository;
        private IUploadTimeService _uploadTimeService;
        private IPhoneRepository _phoneRepository;
        private IEmailRepository _emailRepository;
        private ICVRepository _cvRepository;
        private ICvService _cvService;
        private IMatchServerDate _matchServerDate;
        private IUserLinkRepository _userLinkRepository;
        private ISocialNetworkRepository _socialNetworkRepository;
        private readonly INoteRepository _noteRepository;
        private IBasicInformationService _basicInformationService;
        private ICurrencyRepository _currencyRepository;
        private IRequestRepository _requestRepository;
        private IMailRepository _mailRepository;
        private IRemoteMailRepository _remoteMailRepository;
        private IAttachedFileRepository _attachedFileRepository;
        private ICVRepository _cVRepository;
        private IDocumentCheckRepository _documentCheckRepository;
        private IDocumentCheckGroupRepository _documentCheckGroupRepository;
        private ICandidateCompanyRepository _candidateCompanyRepository;
        private readonly IStudyRepository _studyRepository;
        private readonly IStudyAreaRepository _studyArearepository;
        private readonly IStudyCertificateRepository _studyCertificateRepository;
        private readonly IStudyStateRepository _studyStateRepository;
        private readonly ICertificationStateRepository _certificationStateRepository;
        private readonly IStudyTypeRepository _studyTypeRepository;
        private readonly ITitleRepository _titleRepository;
        private readonly IVideoRepository _videoRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly ILanguageLevelRepository _languageLevelRepository;
        private readonly ICompanyDescriptionRepository _companyDescriptionRepository;
        private readonly ICandidateSoftSkillRepository _candidateSoftSkillRepository;
        private readonly ISoftSkillRepository _softSkillRepository;
        private readonly ICandidateLifePreferenceRepository _candidateLifePreferenceRepository;
        private readonly ICandidateTechnicalAbilityRepository _candidateTechnicalAbilityRepository;
        private readonly ITechnicalAbilityLevelRepository _technicalAbilityLevelRepository;
        private readonly ITechnicalAbilityTechnologyRepository _technicalAbilityTechnologyRepository;
        private readonly ILifePreferenceRepository _lifePreferenceRepository;
        private readonly IPersonalReferenceRepository _personalReferenceRepository;
        private readonly IWorkExperienceRepository _workExperienceRepository;
        private readonly IIndustryRepository _industryRepository;
        private readonly IEquivalentPositionRepository _equivalentPositionRepository;
        private readonly IRelationTypeRepository _relationTypeRepository;

        private readonly ITimeAvailabilityRepository _timeAvailabilityRepository;
        private readonly ICandidate_TimeAvailabilityRepository _candidateTimeAvailabilityRepository;
        private readonly ICompany_Candidate_TimeAvailabilityRepository _companyCandidateTimeAvailabilityRepository;
        private readonly IWellnessRepository _wellnessRepository;
        private readonly ICandidate_WellnessRepository _candidateWellnessRepository;
        private readonly ICompany_Candidate_WellnessRepository _companyCandidateWellnessRepository;

        private readonly IDescriptionRepository _descriptionRepository;
        private IAttachedFileHiringRepository _attachedFileHiringRepository;
        private ICVHiringRepository _cvHiringRepository;

        private readonly ICompanyUserRepository _companyUserRepository;
        private readonly IMemberUserRepository _memberUserRepository;

        private readonly IAnswerService _answerService;
        private readonly ICandidate_SourceService _candidate_SourceService;
        private readonly ICandidate_TagService _candidate_TagService;
        private readonly ICandidate_TalentGroupService _candidate_TalentGroupService;
        private readonly ICandidate_BlockReasonService _candidate_BlockReasonService;
        private readonly ICompanyUserService _companyUserService;
        private readonly IEventService _eventService;
        private readonly IJobProfessionService _jobProfessionService;
        private readonly IPostulationService _postulationService;
        private readonly IPercentCriteriaRepository _percentCriteriaRepository;
        private readonly IValidateMethodsService _validateMethodsService;

        private readonly ServiceConfigurationDTO _settings;
        private readonly ServiceConfigurationDTO _s3Settings;


        public CandidateService
            (
                                ICandidateRepository candidateRepository, IMapper mapper, ICvGenerator cvGenerator,
                                IGenderRepository genderRepository, IMaritalStatusRepository maritalStatusRepository,
                                ICompanyRemoteRepository companyRemoteRepository, IDocumentTypeRepository documentTypeRepository,
                                IDataRegisterCountService dataRegisterCountService,
                                IAuthorizationHelper authorizationHelper, ICandidateLanguageRepository candidateLanguageRepository, ILanguageOtherRepository languageOtherRepository,
                                IBasicInformationRepository basicInformationRepository,
                                IUploadTimeService uploadTimeService, IPhoneRepository phoneRepository, IEmailRepository emailRepository,
                                ICVRepository cvRepository, ICvService cvService,
                                IUserLinkRepository userLinkRepository, ISocialNetworkRepository socialNetworkRepository,
                                IMatchServerDate matchServerDate, INoteRepository noteRepository, IBasicInformationService basicInformationService,
                                ICurrencyRepository currencyRepository, IRequestRepository requestRepository,
                                IMailRepository mailRepository, IRemoteMailRepository remoteMailRepository,
                                ICVRepository cVRepository, IAttachedFileRepository attachedFileRepository, IStudyRepository studyRepository,
                                IDocumentCheckRepository documentCheckRepository,
                                IDocumentCheckGroupRepository documentCheckGroupRepository,

                                IStudyAreaRepository studyAreaRepository,
                                IStudyCertificateRepository studyCertificateRepository,
                                IStudyStateRepository studyStateRepository,
                                ICertificationStateRepository certificationStateRepository,
                                IStudyTypeRepository studyTypeRepository,
                                ITitleRepository titleRepository,

                                ICandidateCompanyRepository candidateCompanyRepository,
                                IVideoRepository videoRepository,

                                ILanguageRepository languageRepository,
                                ILanguageLevelRepository languageLevelRepository,

                                ICompanyDescriptionRepository companyDescriptionRepository,

                                ICandidateSoftSkillRepository candidateSoftSkillRepository,
                                ICandidateTechnicalAbilityRepository candidateTechnicalAbilityRepository,

                                ISoftSkillRepository softSkillRepository,
                                ITechnicalAbilityLevelRepository technicalAbilityLevelRepository,
                                ITechnicalAbilityTechnologyRepository technicalAbilityTechnologyRepository,

                                ICandidateLifePreferenceRepository candidateLifePreferenceRepository,
                                ILifePreferenceRepository lifePreferenceRepository,
                                IPersonalReferenceRepository personalReferenceRepository,
                                IWorkExperienceRepository workExperienceRepository,

                                IIndustryRepository industryRepository,
                                IEquivalentPositionRepository equivalentPositionRepository,
                                IRelationTypeRepository relationTypeRepository,

                                ITimeAvailabilityRepository timeAvailabilityRepository,
                                ICandidate_TimeAvailabilityRepository candidateTimeAvailabilityRepository,
                                ICompany_Candidate_TimeAvailabilityRepository companyCandidateTimeAvailabilityRepository,
                                IWellnessRepository wellnessRepository,
                                ICandidate_WellnessRepository candidateWellnessRepository,
                                ICompany_Candidate_WellnessRepository companyCandidateWellnessRepository,

                                IDescriptionRepository descriptionRepository,
                                IAttachedFileHiringRepository attachedFileHiringRepository,
                                ICVHiringRepository cVHiringRepository,
                                IPercentCriteriaRepository percentCriteriaRepository,

                                ICompanyUserRepository companyUserRepository,
                                IMemberUserRepository memberUserRepository,

                                IAnswerService answerService,
                                ICandidate_SourceService candidate_SourceService,
                                ICandidate_TagService candidate_TagService,
                                ICandidate_TalentGroupService candidate_TalentGroupService,
                                ICandidate_BlockReasonService candidate_BlockReasonService,
                                ICompanyUserService companyUserService,
                                IEventService eventService,
                                IJobProfessionService jobProfessionService,
                                IPostulationService postulationService,
                                IValidateMethodsService validateMethodsService,

                                IOptions<ServiceConfigurationDTO> settings,
                                IOptions<ServiceConfigurationDTO> s3settings)
        {
            _candidateRepository = candidateRepository;
            _genderRepository = genderRepository;
            _companyRemoteRepository = companyRemoteRepository;
            _mapper = mapper;
            _cvGenerator = cvGenerator;
            _dataRegisterCountService = dataRegisterCountService;
            _authorizationHelper = authorizationHelper;
            _maritalStatusRepository = maritalStatusRepository;
            _documentTypeRepository = documentTypeRepository;
            _candidateLanguageRepository = candidateLanguageRepository;
            _languageOtherRepository = languageOtherRepository;
            _basicInformationRepository = basicInformationRepository;
            _uploadTimeService = uploadTimeService;
            _phoneRepository = phoneRepository;
            _emailRepository = emailRepository;
            _cvRepository = cvRepository;
            _cvService = cvService;
            _matchServerDate = matchServerDate;
            _userLinkRepository = userLinkRepository;
            _socialNetworkRepository = socialNetworkRepository;
            _noteRepository = noteRepository;
            _basicInformationService = basicInformationService;
            _currencyRepository = currencyRepository;
            _requestRepository = requestRepository;
            _mailRepository = mailRepository;
            _remoteMailRepository = remoteMailRepository;
            _cVRepository = cVRepository;
            _attachedFileRepository = attachedFileRepository;
            _studyRepository = studyRepository;
            _documentCheckRepository = documentCheckRepository;
            _documentCheckGroupRepository = documentCheckGroupRepository;

            _studyArearepository = studyAreaRepository;
            _studyCertificateRepository = studyCertificateRepository;
            _studyStateRepository = studyStateRepository;
            _certificationStateRepository = certificationStateRepository;
            _studyTypeRepository = studyTypeRepository;
            _titleRepository = titleRepository;

            _candidateCompanyRepository = candidateCompanyRepository;
            _videoRepository = videoRepository;

            _languageRepository = languageRepository;
            _languageLevelRepository = languageLevelRepository;

            _companyDescriptionRepository = companyDescriptionRepository;

            _candidateSoftSkillRepository = candidateSoftSkillRepository;
            _candidateTechnicalAbilityRepository = candidateTechnicalAbilityRepository;

            _softSkillRepository = softSkillRepository;
            _technicalAbilityLevelRepository = technicalAbilityLevelRepository;
            _technicalAbilityTechnologyRepository = technicalAbilityTechnologyRepository;

            _candidateLifePreferenceRepository = candidateLifePreferenceRepository;
            _lifePreferenceRepository = lifePreferenceRepository;
            _personalReferenceRepository = personalReferenceRepository;
            _workExperienceRepository = workExperienceRepository;

            _industryRepository = industryRepository;
            _equivalentPositionRepository = equivalentPositionRepository;
            _relationTypeRepository = relationTypeRepository;

            _wellnessRepository = wellnessRepository;
            _timeAvailabilityRepository = timeAvailabilityRepository;
            _candidateWellnessRepository = candidateWellnessRepository;
            _candidateTimeAvailabilityRepository = candidateTimeAvailabilityRepository;
            _companyCandidateWellnessRepository = companyCandidateWellnessRepository;
            _companyCandidateTimeAvailabilityRepository = companyCandidateTimeAvailabilityRepository;

            _descriptionRepository = descriptionRepository;
            _attachedFileHiringRepository = attachedFileHiringRepository;
            _cvHiringRepository = cVHiringRepository;

            _percentCriteriaRepository = percentCriteriaRepository;

            _companyUserRepository = companyUserRepository;
            _memberUserRepository = memberUserRepository;

            _answerService = answerService;
            _candidate_SourceService = candidate_SourceService;
            _candidate_TagService = candidate_TagService;
            _candidate_TalentGroupService = candidate_TalentGroupService;
            _candidate_BlockReasonService = candidate_BlockReasonService;
            _companyUserService = companyUserService;
            _eventService = eventService;
            _jobProfessionService = jobProfessionService;
            _postulationService = postulationService;
            _validateMethodsService = validateMethodsService;

            _settings = settings.Value;
            _s3Settings = s3settings.Value;
        }

        private async Task<BasicInformationOverViewDTO> GetBasicInfoOverView(Candidate candidate, string token)
        {
            BasicInformationOverViewDTO basicInformationOverView = new BasicInformationOverViewDTO();
            var candidateId = candidate.CandidateId;
            BasicInformation basicInformation = await _basicInformationRepository.GetByCandidateId(candidateId);

            if (basicInformation == null)
                return null;

            basicInformationOverView = _mapper.Map<BasicInformation, BasicInformationOverViewDTO>(basicInformation);
            if (basicInformation.GenderId != 0 && basicInformation.GenderId != null)
            {
                var gender = await _genderRepository.GetByIdWithoutNull((int)basicInformation.GenderId);
                basicInformationOverView.Gender = gender.Name;
            }
            if (basicInformation.DocumentTypeId != 0 && basicInformation.DocumentTypeId != null)
            {
                var documentType = await _documentTypeRepository.GetById((int)basicInformation.DocumentTypeId);
                basicInformationOverView.DocumentType = documentType.Initials;
            }
            if (basicInformation.MaritalStatusId != 0 && basicInformation.MaritalStatusId != null)
            {
                var maritalStatus = await _maritalStatusRepository.GetByIdWithoutNull((int)basicInformation.MaritalStatusId);
                basicInformationOverView.MaritalStatus = maritalStatus.Name;
            }
            if (!string.IsNullOrEmpty(basicInformation.SalaryAspiration))
            {
                basicInformationOverView.SalaryAspiration = basicInformation.SalaryAspiration;
            }
            if (basicInformation.BirthDate != null && basicInformation.BirthDate != "")
            {
                var date = new DateTime(1970, 1, 1).AddMilliseconds(Convert.ToInt64(basicInformation.BirthDate)).ToString("dd/MM/yyyy");
                basicInformationOverView.BirthDate = date.ToString();
            }
            if (!string.IsNullOrEmpty(basicInformation.Photo) && basicInformation.Photo != null)
                basicInformationOverView.Photo = basicInformation.Photo;
            if (basicInformation.EmailMemberUser != null)
            {
                MemberUser memberUserTemp = await _memberUserRepository.GetByEmail(basicInformation.EmailMemberUser);

                if (memberUserTemp == null)
                {
                    basicInformationOverView.DeleteMember = true;
                }

            }

            if (candidate.IsMigrated != 0)
            {
                string[] names = candidate.BasicInformation.Name.Split(" ");
                if (names.Count() > 1)
                {
                    var surname = "";
                    basicInformationOverView.Name = names[0];
                    for (int i = 1; i < names.Length; i++)
                        surname += names[i] + " ";
                    basicInformationOverView.Surname = surname;

                    if (!string.IsNullOrEmpty(candidate.BasicInformation.Surname))
                        basicInformationOverView.Surname += candidate.BasicInformation.Surname;
                }
            }
            foreach (PropertyInfo propertyInfo in basicInformationOverView.GetType().GetProperties())
            {
                if (propertyInfo.PropertyType == typeof(string) && propertyInfo.GetValue(basicInformationOverView) == null)
                {
                    propertyInfo.SetValue(basicInformationOverView, "");
                }
            }

            return basicInformationOverView;
        }

        public async Task<List<CandidateDTO>> CreateCandidates(List<AnalyzeDTO> candidatesToCreate, string memberEmail, string memberName, string memberSurName)
        {
            List<Candidate> candidateList = new List<Candidate>();
            var date = _matchServerDate.CreateServerDate();

            foreach (var candidateAux in candidatesToCreate)
            {
                Candidate candidateNew = new Candidate()
                {
                    Email = candidateAux.Email,
                    IsMigrated = 4,
                    IsNew = true,
                    CreationDate = date,
                    EditionDate = date,
                    EmailMember = memberEmail,
                    NameMemberUser = memberName,
                    SurnameMemberUser = memberSurName
                };

                /**/

                string[] validformats = ["MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss, fff",
                                            "MM/dd/yyyy hh:mm tt", "M/dd/yyyy h:mm:ss tt", "MM/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm:ss tt",
                                            "dd/MM/yyyy hh:mm:ss tt","dd/MM/yyyy hh:mm:ss","dd/MM/yyyy h:mm:ss","dd/MM/yyyy h:mm:ss ff",
                                            "dd/MM/yyyy h:mm:ss tt","dd/MM/yyyy hh:mm:ss ff","M/dd/yyyy hh:mm:ss tt",
                                            "M/dd/yyyy HH:mm:ss", "M/d/yyyy HH:mm:ss", "MM/d/yyyy HH:mm:ss"];

                candidateNew.CreationDateNoText = DateTime.ParseExact(candidateNew.CreationDate.Replace(".", ""), validformats, CultureInfo.InvariantCulture, DateTimeStyles.None);

                /**/

                if (candidateNew != null)
                    candidateList.Add(candidateNew);
            }

            if (candidateList != null && candidateList.Count > 0)
            {
                await _candidateRepository.AddRange(candidateList);

                foreach (var candidateCreated in candidateList)
                {
                    foreach (var candidateAux in candidatesToCreate)
                    {
                        if (candidateCreated.Email == candidateAux.Email)
                        {
                            var basicInfo = await CreateBasicInformation(candidateCreated, candidateAux, memberEmail, memberName, 2);
                            if (basicInfo != null)
                            {
                                candidateCreated.BasicInformation = basicInfo;

                                Phone phone = new Phone
                                {
                                    Number = candidateAux.Phone,
                                    BasicInformationId = basicInfo.BasicInformationId
                                };
                                await _phoneRepository.Add(phone);

                                SocialNetwork link1 = new SocialNetwork
                                {
                                    Link = candidateAux.Facebook,
                                    BasicInformationId = basicInfo.BasicInformationId
                                };
                                SocialNetwork link2 = new SocialNetwork
                                {
                                    Link = candidateAux.Twitter,
                                    BasicInformationId = basicInfo.BasicInformationId
                                };
                                SocialNetwork link3 = new SocialNetwork
                                {
                                    Link = candidateAux.LinkedIn,
                                    BasicInformationId = basicInfo.BasicInformationId
                                };
                                UserLink link4 = new UserLink
                                {
                                    Link = candidateAux.GitHub,
                                    BasicInformationId = basicInfo.BasicInformationId
                                };
                                UserLink link5 = new UserLink
                                {
                                    Link = candidateAux.BitBucket,
                                    BasicInformationId = basicInfo.BasicInformationId
                                };

                                if (!string.IsNullOrEmpty(candidateAux.Facebook))
                                    await _socialNetworkRepository.Add(link1);
                                if (!string.IsNullOrEmpty(candidateAux.Twitter))
                                    await _socialNetworkRepository.Add(link2);
                                if (!string.IsNullOrEmpty(candidateAux.LinkedIn))
                                    await _socialNetworkRepository.Add(link3);
                                if (!string.IsNullOrEmpty(candidateAux.GitHub))
                                    await _userLinkRepository.Add(link4);
                                if (!string.IsNullOrEmpty(candidateAux.BitBucket))
                                    await _userLinkRepository.Add(link5);
                            }
                        }
                    }
                }

                List<CandidateDTO> candidateListDTO = _mapper.Map<List<Candidate>, List<CandidateDTO>>(candidateList);

                return candidateListDTO;
            }
            else
                return null;
        }

        public async Task<BasicInformation> CreateBasicInformation(Candidate candidate, AnalyzeDTO analyze, string memberEmail, string memberName, int currencyId)
        {
            BasicInformation basicInfo = new BasicInformation()
            {
                CandidateId = candidate.CandidateId,
                Name = analyze.Name,
                HaveWorkExperience = 3,
                HaveWorkExperienceFromCompany = 3,
                CurrencyId = currencyId,
                Phone = "",
                EmailMemberUser = memberEmail,
                NameMemberUser = memberName,
                FacebookURL = "",
                TwitterURL = "",
                LinkedInURL = "",
                GitHubURL = "",
                BitBucketURL = ""
            };

            basicInfo.GenderId = 4;
            basicInfo.MaritalStatusId = 6;

            var created = await _basicInformationRepository.Add(basicInfo);

            if (created)
                return basicInfo;
            else
                return null;
        }

        public async Task<bool> CreatedJobs(List<int> candidates, List<int> jobs, string token)
        {
            PostulationAnalyzeOutDTO postulationAnalyzeOutDTO = new PostulationAnalyzeOutDTO()
            {
                Candidates = candidates,
                Jobs = jobs
            };

            var response = await _companyRemoteRepository.AddPostulationFromAnalyze(postulationAnalyzeOutDTO, token);

            return response;
        }

        public async Task<bool> CreatedTalentGroups(List<int> candidates, List<int> talentGroups, string token)
        {
            TalentGroupAnalyzeOutDTO talentGroupAnalyzeOutDTO = new TalentGroupAnalyzeOutDTO()
            {
                Candidates = candidates,
                TalentGroups = talentGroups
            };

            var response = await _companyRemoteRepository.AddTalentGroupFromAnalyze(talentGroupAnalyzeOutDTO, token);

            return response;
        }

        public async Task<List<CVDTO>> CreateCandidateCV(List<IFormFile> files, List<AnalyzeDTO> analizeList, string token)
        {
            try
            {
                var memberName = "";
                var memberEmail = "";
                var memberUser = await _companyRemoteRepository.GetMemberUserFromCandidate(token);
                if (memberUser != null)
                {
                    memberEmail = memberUser.email;
                    if (memberUser.surname != null)
                        memberName = memberUser.name + " " + memberUser.surname;
                    else
                        memberName = memberUser.name;
                }

                var candidateCreated = analizeList.Where(x => x.Exists == false);

                if (candidateCreated != null)
                {
                    foreach (var candidate in candidateCreated)
                    {
                        var fileCandidate = candidate.FileName;
                        foreach (var file in files)
                        {
                            var fileForm = file.FileName.Replace(".pdf", string.Empty);
                            if (fileCandidate.Contains(fileForm))
                            {
                                await _cvService.UploadCvFromAnalyze(file, candidate.CandidateId, memberEmail);
                            }
                        }
                    }

                    return null;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<NoteCandidateSectionTotalDTO> GetNotesFromCandidateInTalentGroup(SearchByIdAndTextWithPaginationDTO search, string token)
        {
            CandidateIdAndPostulationAndTGNumbersResponseDTO recieved = await _companyRemoteRepository.GetAllCandidateIdsFromTalentGroupId(token.ToString(), search);
            List<CandidateIdAndPostulationAndTGNumbersDTO> candidatesrecieved = recieved.search;

            List<PostulationJobNameInDTO> postulations = await _companyRemoteRepository.GetAllPostulationsWithName(token.ToString());
            List<CandidateTalentGroupNameInDTO> talentGroups = await _companyRemoteRepository.GetAllCandidateTalentWithName(token.ToString());

            NoteCandidateSectionTotalDTO response = new NoteCandidateSectionTotalDTO();

            if (candidatesrecieved != null && candidatesrecieved.Count > 0)
            {
                List<NoteSectionDTO> notes = new List<NoteSectionDTO>();
                List<int> CandidatesIds = new List<int>();
                foreach (CandidateIdAndPostulationAndTGNumbersDTO candidaterecieved in candidatesrecieved)
                {
                    CandidatesIds.Add(candidaterecieved.candidateId);
                }
                NoteGroupDTO notesCandidate = await _noteRepository.GetNoteWithCandidateAndBasicInformation(CandidatesIds, search.Page, search.PageSize);
                if (notesCandidate != null && notesCandidate.notesCandidates.Count > 0)
                {
                    foreach (Note note in notesCandidate.notesCandidates)
                    {
                        string photo = "";
                        string init = "";
                        string name = "";
                        List<string> jobNames = new List<string>();
                        List<string> talentNames = new List<string>();
                        int jobCount = 0;
                        int talentCount = 0;
                        if (postulations != null && postulations.Count > 0)
                        {
                            var jobs = postulations.Where(x => x.candidateId == note.CandidateId).ToList();
                            if (jobs != null && jobs.Count > 0)
                            {
                                foreach (var job in jobs)
                                {
                                    if (job != null)
                                        jobNames.Add(job.jobName);
                                }
                                jobCount = jobNames.Count();
                            }
                        }

                        if (talentGroups != null && talentGroups.Count > 0)
                        {
                            var talents = talentGroups.Where(x => x.candidateId == note.CandidateId).ToList();
                            if (talents != null && talents.Count > 0)
                            {
                                foreach (var talent in talents)
                                {
                                    if (talent != null)
                                        talentNames.Add(talent.talentGroupName);
                                }
                                talentCount = talentNames.Count();
                            }
                        }
                        var CreationDateNote = await _noteRepository.CreationDate(note.NoteId);
                        var CreationDateNotePopUp = await _noteRepository.CreationDatePopUp(note.NoteId);
                        var CreationDateCandidate = await _basicInformationService.CreationDate(note.CandidateId);
                        var CreationDateCandidatePopUp = await _basicInformationService.CreationDatePopUp(note.CandidateId);

                        var CreationDateNoteEnglish = await _noteRepository.CreationDateEnglish(note.NoteId);
                        var CreationDateNoteEnglishPopUp = await _noteRepository.CreationDatePopUpEnglish(note.NoteId);
                        var CreationDateCandidateEnglish = await _basicInformationService.CreationDateEnglish(note.CandidateId);
                        var CreationDateCandidateEnglishPopUp = await _basicInformationService.CreationDatePopUpEnglish(note.CandidateId);

                        if (note.Candidate.BasicInformation != null)
                        {
                            if (!String.IsNullOrEmpty(note.Candidate.BasicInformation.Photo) && note.Candidate.BasicInformation.Photo != null)
                                photo = note.Candidate.BasicInformation.Photo;
                            else
                                init = _basicInformationService.Initials(note.Candidate.BasicInformation.Name, note.Candidate.BasicInformation.Surname);

                            name = _basicInformationService.Name(note.Candidate.BasicInformation.Name, note.Candidate.BasicInformation.Surname);
                        }
                        if (note.Candidate.BasicInformation == null && !string.IsNullOrEmpty(note.Candidate.Email) && note.Candidate.Email != null)
                        {
                            name = note.Candidate.Email;
                            var sub = name.Substring(0, 2);
                            init = sub.ToUpper();
                        }
                        CandidateSectionDTO candidateSectionDTO = new CandidateSectionDTO()
                        {
                            CandidateId = note.Candidate.CandidateId,
                            Photo = photo,
                            Initials = init,
                            Name = name,
                            CreationDate = CreationDateCandidate,
                            CreationDateEnglish = CreationDateCandidateEnglish,
                            CreationDatePopUp = CreationDateCandidatePopUp,
                            CreationDatePopUpEnglish = CreationDateCandidateEnglishPopUp,
                            Jobs = jobNames,
                            TotalJobs = jobCount,
                            TalentGroups = talentNames,
                            TotalTalentGroups = talentCount,
                            IsDeleteProccess = note.Candidate.IsDeleteProccess
                        };
                        NoteSectionDTO noteSectionDTO = new NoteSectionDTO()
                        {
                            NoteDescription = note.NoteDescription,
                            CreationDate = CreationDateNote,
                            CreationDateEnglish = CreationDateNoteEnglish,
                            CreationDatePopUp = CreationDateNotePopUp,
                            CreationDatePopUpEnglish = CreationDateNoteEnglishPopUp,
                            Name = _basicInformationService.Name(note.NameMemberUser, note.SurnameMemberUser),
                            CandidateId = note.Candidate.CandidateId,
                            CandidateSection = candidateSectionDTO,
                            id = note.NoteId
                        };
                        if (noteSectionDTO != null)
                            notes.Add(noteSectionDTO);
                    }
                    if (notes != null && notes.Count > 0)
                    {
                        List<NoteSectionDTO> notesSorted = notes.OrderByDescending(x => x.id).ToList();

                        for (int i = 0; i < notesSorted.Count; i++)
                        {
                            if (i == 0)
                                notesSorted[i].Previous = 0;
                            else
                                notesSorted[i].Previous = notesSorted[i - 1].CandidateId;

                            if (i == notesSorted.Count - 1)
                                notesSorted[i].Next = 0;
                            else
                                notesSorted[i].Next = notesSorted[i + 1].CandidateId;
                        }

                        response.TotalNotes = notesCandidate.TotalNotes;
                        response.CandidateSectionList = notesSorted;

                        return response;
                    }
                    else
                        return null;
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public async Task<NoteCandidateSectionTotalDTO> GetNotesFromCandidateInTalentGroupAndSearch(SearchByIdAndTextWithPaginationDTO search, string token)
        {
            CandidateIdAndPostulationAndTGNumbersResponseDTO recieved = await _companyRemoteRepository.GetAllCandidateIdsFromTalentGroupId(token.ToString(), search);
            List<CandidateIdAndPostulationAndTGNumbersDTO> candidatesrecieved = recieved.search;

            List<PostulationJobNameInDTO> postulations = await _companyRemoteRepository.GetAllPostulationsWithName(token.ToString());
            List<CandidateTalentGroupNameInDTO> talentGroups = await _companyRemoteRepository.GetAllCandidateTalentWithName(token.ToString());

            NoteCandidateSectionTotalDTO response = new NoteCandidateSectionTotalDTO();

            if (candidatesrecieved != null && candidatesrecieved.Count > 0)
            {
                List<NoteSectionDTO> notes = new List<NoteSectionDTO>();
                List<int> CandidatesIds = new List<int>();
                foreach (CandidateIdAndPostulationAndTGNumbersDTO candidaterecieved in candidatesrecieved)
                {
                    CandidatesIds.Add(candidaterecieved.candidateId);
                }
                NoteGroupDTO notesCandidate = await _noteRepository.GetNoteWithCandidateAndBasicInformationSearch(CandidatesIds, search.Page, search.PageSize, search.Text);
                if (notesCandidate != null && notesCandidate.notesCandidates.Count > 0)
                {
                    foreach (Note note in notesCandidate.notesCandidates)
                    {
                        string photo = "";
                        string init = "";
                        string name = "";
                        List<string> jobNames = new List<string>();
                        List<string> talentNames = new List<string>();
                        int jobCount = 0;
                        int talentCount = 0;
                        if (postulations != null && postulations.Count > 0)
                        {
                            var jobs = postulations.Where(x => x.candidateId == note.CandidateId).ToList();
                            if (jobs != null && jobs.Count > 0)
                            {
                                foreach (var job in jobs)
                                {
                                    if (job != null)
                                        jobNames.Add(job.jobName);
                                }
                                jobCount = jobNames.Count();
                            }
                        }

                        if (talentGroups != null && talentGroups.Count > 0)
                        {
                            var talents = talentGroups.Where(x => x.candidateId == note.CandidateId).ToList();
                            if (talents != null && talents.Count > 0)
                            {
                                foreach (var talent in talents)
                                {
                                    if (talent != null)
                                        talentNames.Add(talent.talentGroupName);
                                }
                                talentCount = talentNames.Count();
                            }
                        }
                        var CreationDateNote = await _noteRepository.CreationDate(note.NoteId);
                        var CreationDateNotePopUp = await _noteRepository.CreationDatePopUp(note.NoteId);
                        var CreationDateCandidate = await _basicInformationService.CreationDate(note.CandidateId);
                        var CreationDateCandidatePopUp = await _basicInformationService.CreationDatePopUp(note.CandidateId);

                        var CreationDateNoteEnglish = await _noteRepository.CreationDateEnglish(note.NoteId);
                        var CreationDateNoteEnglishPopUp = await _noteRepository.CreationDatePopUpEnglish(note.NoteId);
                        var CreationDateCandidateEnglish = await _basicInformationService.CreationDateEnglish(note.CandidateId);
                        var CreationDateCandidateEnglishPopUp = await _basicInformationService.CreationDatePopUpEnglish(note.CandidateId);

                        if (note.Candidate.BasicInformation != null)
                        {
                            if (!String.IsNullOrEmpty(note.Candidate.BasicInformation.Photo) && note.Candidate.BasicInformation.Photo != null)
                                photo = note.Candidate.BasicInformation.Photo;
                            else
                                init = _basicInformationService.Initials(note.Candidate.BasicInformation.Name, note.Candidate.BasicInformation.Surname);

                            name = _basicInformationService.Name(note.Candidate.BasicInformation.Name, note.Candidate.BasicInformation.Surname);
                        }
                        if (note.Candidate.BasicInformation == null && !string.IsNullOrEmpty(note.Candidate.Email) && note.Candidate.Email != null)
                        {
                            name = note.Candidate.Email;
                            var sub = name.Substring(0, 2);
                            init = sub.ToUpper();
                        }
                        CandidateSectionDTO candidateSectionDTO = new CandidateSectionDTO()
                        {
                            CandidateId = note.Candidate.CandidateId,
                            Photo = photo,
                            Initials = init,
                            Name = name,
                            CreationDate = CreationDateCandidate,
                            CreationDateEnglish = CreationDateCandidateEnglish,
                            CreationDatePopUp = CreationDateCandidatePopUp,
                            CreationDatePopUpEnglish = CreationDateCandidateEnglishPopUp,
                            Jobs = jobNames,
                            TotalJobs = jobCount,
                            TalentGroups = talentNames,
                            TotalTalentGroups = talentCount,
                            IsDeleteProccess = note.Candidate.IsDeleteProccess
                        };
                        NoteSectionDTO noteSectionDTO = new NoteSectionDTO()
                        {
                            NoteDescription = note.NoteDescription.ToLower().Replace(search.Text.ToLower(), "<em>" + search.Text.ToLower() + "</em>"),
                            CreationDate = CreationDateNote,
                            CreationDateEnglish = CreationDateNoteEnglish,
                            CreationDatePopUp = CreationDateNotePopUp,
                            CreationDatePopUpEnglish = CreationDateNoteEnglishPopUp,
                            Name = _basicInformationService.Name(note.NameMemberUser, note.SurnameMemberUser),
                            CandidateId = note.Candidate.CandidateId,
                            CandidateSection = candidateSectionDTO,
                            id = note.NoteId
                        };
                        if (noteSectionDTO != null)
                            notes.Add(noteSectionDTO);
                    }
                    if (notes != null && notes.Count > 0)
                    {
                        List<NoteSectionDTO> notesSorted = notes.OrderByDescending(x => x.id).ToList();

                        for (int i = 0; i < notesSorted.Count; i++)
                        {
                            if (i == 0)
                                notesSorted[i].Previous = 0;
                            else
                                notesSorted[i].Previous = notesSorted[i - 1].CandidateId;

                            if (i == notesSorted.Count - 1)
                                notesSorted[i].Next = 0;
                            else
                                notesSorted[i].Next = notesSorted[i + 1].CandidateId;
                        }

                        response.TotalNotes = notesCandidate.TotalNotes;
                        response.CandidateSectionList = notesSorted;

                        return response;
                    }
                    else
                        return null;
                }
                return null;
            }
            else
            {
                return null;
            }
        }


        public async Task<NoteCandidateSectionTotalDTO> GetNotesFromCandidateInJob(SearchByIdAndTextWithPaginationDTO search, string token)
        {
            CandidateIdAndPostulationAndTGNumbersResponseDTO recieved = await _companyRemoteRepository.GetAllCandidateIdsFromJobId(token.ToString(), search);
            List<CandidateIdAndPostulationAndTGNumbersDTO> candidatesrecieved = recieved.search;

            List<PostulationJobNameInDTO> postulations = await _companyRemoteRepository.GetAllPostulationsWithName(token.ToString());
            List<CandidateTalentGroupNameInDTO> talentGroups = await _companyRemoteRepository.GetAllCandidateTalentWithName(token.ToString());

            NoteCandidateSectionTotalDTO response = new NoteCandidateSectionTotalDTO();

            if (candidatesrecieved != null && candidatesrecieved.Count > 0)
            {
                List<NoteSectionDTO> notes = new List<NoteSectionDTO>();
                List<int> CandidatesIds = new List<int>();
                foreach (CandidateIdAndPostulationAndTGNumbersDTO candidaterecieved in candidatesrecieved)
                {
                    CandidatesIds.Add(candidaterecieved.candidateId);
                }
                NoteGroupDTO notesCandidate = await _noteRepository.GetNoteWithCandidateAndBasicInformation(CandidatesIds, search.Page, search.PageSize);
                if (notesCandidate != null && notesCandidate.notesCandidates.Count > 0)
                {
                    foreach (Note note in notesCandidate.notesCandidates)
                    {
                        string photo = "";
                        string init = "";
                        string name = "";
                        List<string> jobNames = new List<string>();
                        List<string> talentNames = new List<string>();
                        int jobCount = 0;
                        int talentCount = 0;
                        if (postulations != null && postulations.Count > 0)
                        {
                            var jobs = postulations.Where(x => x.candidateId == note.CandidateId).ToList();
                            if (jobs != null && jobs.Count > 0)
                            {
                                foreach (var job in jobs)
                                {
                                    if (job != null)
                                        jobNames.Add(job.jobName);
                                }
                                jobCount = jobNames.Count();
                            }
                        }

                        if (talentGroups != null && talentGroups.Count > 0)
                        {
                            var talents = talentGroups.Where(x => x.candidateId == note.CandidateId).ToList();
                            if (talents != null && talents.Count > 0)
                            {
                                foreach (var talent in talents)
                                {
                                    if (talent != null)
                                        talentNames.Add(talent.talentGroupName);
                                }
                                talentCount = talentNames.Count();
                            }
                        }
                        var CreationDateNote = await _noteRepository.CreationDate(note.NoteId);
                        var CreationDateNotePopUp = await _noteRepository.CreationDatePopUp(note.NoteId);
                        var CreationDateCandidate = await _basicInformationService.CreationDate(note.CandidateId);
                        var CreationDateCandidatePopUp = await _basicInformationService.CreationDatePopUp(note.CandidateId);

                        var CreationDateNoteEnglish = await _noteRepository.CreationDateEnglish(note.NoteId);
                        var CreationDateNoteEnglishPopUp = await _noteRepository.CreationDatePopUpEnglish(note.NoteId);
                        var CreationDateCandidateEnglish = await _basicInformationService.CreationDateEnglish(note.CandidateId);
                        var CreationDateCandidateEnglishPopUp = await _basicInformationService.CreationDatePopUpEnglish(note.CandidateId);

                        if (note.Candidate.BasicInformation != null)
                        {
                            if (!String.IsNullOrEmpty(note.Candidate.BasicInformation.Photo) && note.Candidate.BasicInformation.Photo != null)
                                photo = note.Candidate.BasicInformation.Photo;
                            else
                                init = _basicInformationService.Initials(note.Candidate.BasicInformation.Name, note.Candidate.BasicInformation.Surname);

                            name = _basicInformationService.Name(note.Candidate.BasicInformation.Name, note.Candidate.BasicInformation.Surname);
                        }
                        if (note.Candidate.BasicInformation == null && !string.IsNullOrEmpty(note.Candidate.Email) && note.Candidate.Email != null)
                        {
                            name = note.Candidate.Email;
                            var sub = name.Substring(0, 2);
                            init = sub.ToUpper();
                        }
                        CandidateSectionDTO candidateSectionDTO = new CandidateSectionDTO()
                        {
                            CandidateId = note.Candidate.CandidateId,
                            Photo = photo,
                            Initials = init,
                            Name = name,
                            CreationDate = CreationDateCandidate,
                            CreationDateEnglish = CreationDateCandidateEnglish,
                            CreationDatePopUp = CreationDateCandidatePopUp,
                            CreationDatePopUpEnglish = CreationDateCandidateEnglishPopUp,
                            Jobs = jobNames,
                            TotalJobs = jobCount,
                            TalentGroups = talentNames,
                            TotalTalentGroups = talentCount,
                            IsDeleteProccess = note.Candidate.IsDeleteProccess
                        };
                        NoteSectionDTO noteSectionDTO = new NoteSectionDTO()
                        {
                            NoteDescription = note.NoteDescription,
                            CreationDate = CreationDateNote,
                            CreationDateEnglish = CreationDateNoteEnglish,
                            CreationDatePopUp = CreationDateNotePopUp,
                            CreationDatePopUpEnglish = CreationDateNoteEnglishPopUp,
                            Name = _basicInformationService.Name(note.NameMemberUser, note.SurnameMemberUser),
                            CandidateId = note.Candidate.CandidateId,
                            CandidateSection = candidateSectionDTO,
                            id = note.NoteId
                        };
                        if (noteSectionDTO != null)
                            notes.Add(noteSectionDTO);
                    }
                    if (notes != null && notes.Count > 0)
                    {
                        List<NoteSectionDTO> notesSorted = notes.OrderByDescending(x => x.id).ToList();

                        for (int i = 0; i < notesSorted.Count; i++)
                        {
                            if (i == 0)
                                notesSorted[i].Previous = 0;
                            else
                                notesSorted[i].Previous = notesSorted[i - 1].CandidateId;

                            if (i == notesSorted.Count - 1)
                                notesSorted[i].Next = 0;
                            else
                                notesSorted[i].Next = notesSorted[i + 1].CandidateId;
                        }

                        response.TotalNotes = notesCandidate.TotalNotes;
                        response.CandidateSectionList = notesSorted;

                        return response;
                    }
                    else
                        return null;
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public async Task<NoteCandidateSectionTotalDTO> GetNotesFromCandidateInJobAndSearch(SearchByIdAndTextWithPaginationDTO search, string token)
        {
            CandidateIdAndPostulationAndTGNumbersResponseDTO recieved = await _companyRemoteRepository.GetAllCandidateIdsFromJobId(token.ToString(), search);
            List<CandidateIdAndPostulationAndTGNumbersDTO> candidatesrecieved = recieved.search;

            List<PostulationJobNameInDTO> postulations = await _companyRemoteRepository.GetAllPostulationsWithName(token.ToString());
            List<CandidateTalentGroupNameInDTO> talentGroups = await _companyRemoteRepository.GetAllCandidateTalentWithName(token.ToString());

            NoteCandidateSectionTotalDTO response = new NoteCandidateSectionTotalDTO();

            if (candidatesrecieved != null && candidatesrecieved.Count > 0)
            {
                List<NoteSectionDTO> notes = new List<NoteSectionDTO>();
                List<int> CandidatesIds = new List<int>();
                foreach (CandidateIdAndPostulationAndTGNumbersDTO candidaterecieved in candidatesrecieved)
                {
                    CandidatesIds.Add(candidaterecieved.candidateId);
                }
                NoteGroupDTO notesCandidate = await _noteRepository.GetNoteWithCandidateAndBasicInformationSearch(CandidatesIds, search.Page, search.PageSize, search.Text);
                if (notesCandidate != null && notesCandidate.notesCandidates.Count > 0)
                {
                    foreach (Note note in notesCandidate.notesCandidates)
                    {
                        string photo = "";
                        string init = "";
                        string name = "";
                        List<string> jobNames = new List<string>();
                        List<string> talentNames = new List<string>();
                        int jobCount = 0;
                        int talentCount = 0;
                        if (postulations != null && postulations.Count > 0)
                        {
                            var jobs = postulations.Where(x => x.candidateId == note.CandidateId).ToList();
                            if (jobs != null && jobs.Count > 0)
                            {
                                foreach (var job in jobs)
                                {
                                    if (job != null)
                                        jobNames.Add(job.jobName);
                                }
                                jobCount = jobNames.Count();
                            }
                        }

                        if (talentGroups != null && talentGroups.Count > 0)
                        {
                            var talents = talentGroups.Where(x => x.candidateId == note.CandidateId).ToList();
                            if (talents != null && talents.Count > 0)
                            {
                                foreach (var talent in talents)
                                {
                                    if (talent != null)
                                        talentNames.Add(talent.talentGroupName);
                                }
                                talentCount = talentNames.Count();
                            }
                        }
                        var CreationDateNote = await _noteRepository.CreationDate(note.NoteId);
                        var CreationDateNotePopUp = await _noteRepository.CreationDatePopUp(note.NoteId);
                        var CreationDateCandidate = await _basicInformationService.CreationDate(note.CandidateId);
                        var CreationDateCandidatePopUp = await _basicInformationService.CreationDatePopUp(note.CandidateId);

                        var CreationDateNoteEnglish = await _noteRepository.CreationDateEnglish(note.NoteId);
                        var CreationDateNoteEnglishPopUp = await _noteRepository.CreationDatePopUpEnglish(note.NoteId);
                        var CreationDateCandidateEnglish = await _basicInformationService.CreationDateEnglish(note.CandidateId);
                        var CreationDateCandidateEnglishPopUp = await _basicInformationService.CreationDatePopUpEnglish(note.CandidateId);

                        if (note.Candidate.BasicInformation != null)
                        {
                            if (!String.IsNullOrEmpty(note.Candidate.BasicInformation.Photo) && note.Candidate.BasicInformation.Photo != null)
                                photo = note.Candidate.BasicInformation.Photo;
                            else
                                init = _basicInformationService.Initials(note.Candidate.BasicInformation.Name, note.Candidate.BasicInformation.Surname);

                            name = _basicInformationService.Name(note.Candidate.BasicInformation.Name, note.Candidate.BasicInformation.Surname);
                        }
                        if (note.Candidate.BasicInformation == null && !string.IsNullOrEmpty(note.Candidate.Email) && note.Candidate.Email != null)
                        {
                            name = note.Candidate.Email;
                            var sub = name.Substring(0, 2);
                            init = sub.ToUpper();
                        }
                        CandidateSectionDTO candidateSectionDTO = new CandidateSectionDTO()
                        {
                            CandidateId = note.Candidate.CandidateId,
                            Photo = photo,
                            Initials = init,
                            Name = name,
                            CreationDate = CreationDateCandidate,
                            CreationDateEnglish = CreationDateCandidateEnglish,
                            CreationDatePopUp = CreationDateCandidatePopUp,
                            CreationDatePopUpEnglish = CreationDateCandidateEnglishPopUp,
                            Jobs = jobNames,
                            TotalJobs = jobCount,
                            TalentGroups = talentNames,
                            TotalTalentGroups = talentCount,
                            IsDeleteProccess = note.Candidate.IsDeleteProccess
                        };
                        NoteSectionDTO noteSectionDTO = new NoteSectionDTO()
                        {
                            NoteDescription = note.NoteDescription.ToLower().Replace(search.Text.ToLower(), "<em>" + search.Text.ToLower() + "</em>"),
                            CreationDate = CreationDateNote,
                            CreationDateEnglish = CreationDateNoteEnglish,
                            CreationDatePopUp = CreationDateNotePopUp,
                            CreationDatePopUpEnglish = CreationDateNoteEnglishPopUp,
                            Name = _basicInformationService.Name(note.NameMemberUser, note.SurnameMemberUser),
                            CandidateId = note.Candidate.CandidateId,
                            CandidateSection = candidateSectionDTO,
                            id = note.NoteId
                        };
                        if (noteSectionDTO != null)
                            notes.Add(noteSectionDTO);
                    }
                    if (notes != null && notes.Count > 0)
                    {
                        List<NoteSectionDTO> notesSorted = notes.OrderByDescending(x => x.id).ToList();

                        for (int i = 0; i < notesSorted.Count; i++)
                        {
                            if (i == 0)
                                notesSorted[i].Previous = 0;
                            else
                                notesSorted[i].Previous = notesSorted[i - 1].CandidateId;

                            if (i == notesSorted.Count - 1)
                                notesSorted[i].Next = 0;
                            else
                                notesSorted[i].Next = notesSorted[i + 1].CandidateId;
                        }

                        response.TotalNotes = notesCandidate.TotalNotes;
                        response.CandidateSectionList = notesSorted;

                        return response;
                    }
                    else
                        return null;
                }
                return null;
            }
            else
            {
                return null;
            }
        }


        public async Task<candidateSearchTotalDTO> GetAllCandidateSearch(SearchByIdAndTextWithPaginationDTO search, int companyUserId, int userType, string token)
        {
            try
            {
                CultureInfo culture = CultureInfo.CurrentCulture;

                /* Get words filters, Postulations and TGs */

                MemberByToken memberResponse = await _companyRemoteRepository.GetMemberUserFromCandidate(token.ToString());

                List<Candidate> candidatesFilters = await _candidateRepository.GetCandidatesByFilter(search.Text, userType, companyUserId);

                List<candidateSearchDTO> candidateSectionListDTO = new List<candidateSearchDTO>();

                List<PostulationJobNameInDTO> postulations = await _companyRemoteRepository.GetAllPostulationsWithNameAndColourFlag(token);
                List<CandidateTalentGroupNameInDTO> talentGroups = await _companyRemoteRepository.GetAllCandidateTalentWithNameAndColourFlag(token);
                List<TagListInDTO> tags = await _companyRemoteRepository.GetTagsByCompanyUser(companyUserId, token);
                List<SourceListInDTO> sources = await _companyRemoteRepository.GetSourcesByCompanyUser(companyUserId, token);

                candidateSearchTotalDTO response = new candidateSearchTotalDTO();

                /* Years experience */

                double experienceLowerLimit = 0;
                double experienceUpperLimit = 0;

                if (search.JobExperienceId != 0)
                {
                    switch (search.JobExperienceId)
                    {
                        case 1:
                            experienceLowerLimit = 0;
                            experienceUpperLimit = 0;
                            break;
                        case 2:
                            experienceLowerLimit = 1;
                            experienceUpperLimit = 3;
                            break;
                        case 3:
                            experienceLowerLimit = 3;
                            experienceUpperLimit = 5;
                            break;
                        case 4:
                            experienceLowerLimit = 5;
                            experienceUpperLimit = 7;
                            break;
                        case 5:
                            experienceLowerLimit = 7;
                            experienceUpperLimit = 9;
                            break;
                        case 6:
                            experienceLowerLimit = 9;
                            experienceUpperLimit = double.MaxValue;
                            break;
                        default:
                            break;
                    }
                }

                if (search != null && search.JobExperienceId != 0)
                {
                    List<Candidate> candidateSectionListExperience = new List<Candidate>();

                    if (candidatesFilters != null && candidatesFilters.Count > 0 && search != null && search.JobExperienceId > 0)
                    {
                        foreach (Candidate candidate in candidatesFilters)
                        {
                            double yearsExperience = 0;

                            CompanyDescription companyDescription = new CompanyDescription();

                            if (candidate.ExperienceCount != null && !string.IsNullOrEmpty(candidate.ExperienceCount.Years))
                            {
                                if (candidate.ExperienceCount != null && !string.IsNullOrEmpty(candidate.ExperienceCount.Years))
                                {
                                    if (culture != null && !string.IsNullOrEmpty(culture.Name) && culture.Name.Contains("es-"))
                                        double.TryParse(candidate.ExperienceCount.Years.Replace(".", ","), out yearsExperience);
                                    else
                                        double.TryParse(candidate.ExperienceCount.Years, out yearsExperience);
                                }

                                if (yearsExperience != 0 && yearsExperience >= experienceLowerLimit && yearsExperience <= experienceUpperLimit)
                                    candidateSectionListExperience.Add(candidate);
                            }
                            else if (candidate.CompanyDescriptionList != null && candidate.CompanyDescriptionList.Count > 0)
                            {
                                companyDescription = candidate.CompanyDescriptionList.Where(x => x.CompanyUserId == companyUserId).FirstOrDefault();

                                if (companyDescription != null && !string.IsNullOrEmpty(companyDescription.YearsExperience))
                                {
                                    if (culture != null && !string.IsNullOrEmpty(culture.Name) && culture.Name.Contains("es-"))
                                        double.TryParse(companyDescription.YearsExperience.Replace(".", ","), out yearsExperience);
                                    else
                                        double.TryParse(companyDescription.YearsExperience, out yearsExperience);
                                }

                                if (yearsExperience != 0 && yearsExperience >= experienceLowerLimit && yearsExperience <= experienceUpperLimit)
                                    candidateSectionListExperience.Add(candidate);

                                if (yearsExperience == 0 && search.JobExperienceId == 1 && companyDescription == null)
                                    candidateSectionListExperience.Add(candidate);

                                if (companyDescription == null)
                                    companyDescription = new CompanyDescription();
                            }

                            if (yearsExperience == 0 && search.JobExperienceId == 1 &&
                                (candidate.ExperienceCount == null || string.IsNullOrEmpty(candidate.ExperienceCount.Years)) &&
                                (string.IsNullOrEmpty(companyDescription.YearsExperience)))
                                candidateSectionListExperience.Add(candidate);
                        }

                        candidatesFilters = candidateSectionListExperience;
                    }
                }

                /* Currency */

                List<Candidate> candidateSectionListCurrencyExperience = new List<Candidate>();

                if (search != null && search.SalaryAspirations != null && search.SalaryAspirations.Count > 0)
                {
                    foreach (SalaryAspirationFromSearchDTO salaryAspiration in search.SalaryAspirations)
                    {
                        if (candidatesFilters != null && candidatesFilters.Count > 0 &&
                            int.Parse(salaryAspiration.CurrencyLowerValue.Replace(".", "").Replace(",", ""))
                            < int.Parse(salaryAspiration.CurrencyUpperValue.Replace(".", "").Replace(",", "")) &&
                            int.Parse(salaryAspiration.CurrencyLowerValue.Replace(".", "").Replace(",", "")) >= 0)
                        {
                            foreach (Candidate candidate in candidatesFilters)
                            {
                                if (candidate != null && candidate.BasicInformation != null && !string.IsNullOrEmpty(candidate.BasicInformation.SalaryAspiration))
                                {
                                    int salary = 0;

                                    string salaryAspirationString = candidate.BasicInformation.SalaryAspiration.Replace(".", "").Replace(",", "");

                                    if (candidateSectionListCurrencyExperience.Any(x => x.CandidateId == candidate.CandidateId))
                                        continue;

                                    if (int.TryParse(salaryAspirationString, out salary)) { }

                                    if (int.Parse(salaryAspiration.CurrencyLowerValue.Replace(".", "").Replace(",", "")) == 0 &&
                                            salary == 0 && salaryAspiration.CurrencyId == candidate.BasicInformation.CurrencyId)
                                    {
                                        candidateSectionListCurrencyExperience.Add(candidate);
                                    }
                                    else if (int.Parse(salaryAspiration.CurrencyLowerValue.Replace(".", "").Replace(",", "")) <= salary &&
                                        int.Parse(salaryAspiration.CurrencyUpperValue.Replace(".", "").Replace(",", "")) >= salary
                                        && salaryAspiration.CurrencyId == candidate.BasicInformation.CurrencyId)
                                    {
                                        candidateSectionListCurrencyExperience.Add(candidate);
                                    }
                                }
                                else if (candidate != null && candidate.CandidateCompanies != null)
                                {
                                    CandidateCompany candidateCompany = candidate.CandidateCompanies.Where(x => x.CompanyUserId == companyUserId).FirstOrDefault();

                                    if (candidateCompany != null && !string.IsNullOrEmpty(candidateCompany.SalaryAspiration))
                                    {
                                        int salary = 0;

                                        string salaryAspirationString = candidateCompany.SalaryAspiration.Replace(".", "").Replace(",", "");

                                        if (candidateSectionListCurrencyExperience.Any(x => x.CandidateId == candidate.CandidateId))
                                            continue;

                                        if (int.TryParse(salaryAspirationString, out salary)) { }

                                        if (int.Parse(salaryAspiration.CurrencyLowerValue.Replace(".", "").Replace(",", "")) == 0
                                            && salary == 0 && salaryAspiration.CurrencyId == candidateCompany.CurrencyId)
                                        {
                                            candidateSectionListCurrencyExperience.Add(candidate);
                                        }
                                        else if (int.Parse(salaryAspiration.CurrencyLowerValue.Replace(".", "").Replace(",", "")) <= salary
                                            && int.Parse(salaryAspiration.CurrencyUpperValue.Replace(".", "").Replace(",", "")) >= salary
                                            && salaryAspiration.CurrencyId == candidateCompany.CurrencyId)
                                        {
                                            candidateSectionListCurrencyExperience.Add(candidate);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    candidatesFilters = candidateSectionListCurrencyExperience;
                }

                /* Countries list */

                //List<Candidate> candidateSectionListCountriesDTO = new List<Candidate>();

                //if (search != null && search.Countries != null && search.Countries.Count > 0)
                //{
                //    foreach (CountriesFromSearchDTO country in search.Countries)
                //    {
                //        if (candidatesFilters != null && candidatesFilters.Count > 0 && country.CountryId != 0)
                //        {
                //            foreach (Candidate candidate in candidatesFilters)
                //            {
                //                if (candidate != null && candidate.BasicInformation != null && !string.IsNullOrEmpty(candidate.BasicInformation.Country))
                //                {
                //                    int countryId = 0;

                //                    string countryIdString = candidate.BasicInformation.Country.Replace(".", "").Replace(",", "");

                //                    if (candidateSectionListCountriesDTO.Any(x => x.CandidateId == candidate.CandidateId))
                //                        continue;

                //                    if (int.TryParse(countryIdString, out countryId)) { }

                //                    if (countryId == country.CountryId)
                //                    {
                //                        int stateId = 0;

                //                        string stateIdString = candidate.BasicInformation.State.Replace(".", "").Replace(",", "");

                //                        if (int.TryParse(stateIdString, out stateId)) { }

                //                        if (stateId != 0 && stateId == country.StateId)
                //                        {
                //                            int cityId = 0;

                //                            string cityIdString = candidate.BasicInformation.City.Replace(".", "").Replace(",", "");

                //                            if (int.TryParse(cityIdString, out cityId)) { }

                //                            if (cityId != 0 && cityId == country.CityId)
                //                            {
                //                                candidateSectionListCountriesDTO.Add(candidate);
                //                            }
                //                            else if (country.CityId == 0)
                //                            {
                //                                candidateSectionListCountriesDTO.Add(candidate);
                //                            }
                //                        }
                //                        else if (country.StateId == 0)
                //                        {
                //                            candidateSectionListCountriesDTO.Add(candidate);
                //                        }
                //                    }
                //                }
                //                else if (candidate != null && candidate.CandidateCompanies != null)
                //                {
                //                    CandidateCompany candidateCompany = candidate.CandidateCompanies.Where(x => x.CompanyUserId == companyUserId).FirstOrDefault();

                //                    if (candidate != null && candidateCompany != null && !string.IsNullOrEmpty(candidateCompany.Country))
                //                    {
                //                        int countryId = 0;

                //                        string countryIdString = candidateCompany.Country.Replace(".", "").Replace(",", "");

                //                        if (candidateSectionListCountriesDTO.Any(x => x.CandidateId == candidate.CandidateId))
                //                            continue;

                //                        if (int.TryParse(countryIdString, out countryId)) { }

                //                        if (countryId == country.CountryId)
                //                        {
                //                            int stateId = 0;

                //                            string stateIdString = candidateCompany.State.Replace(".", "").Replace(",", "");

                //                            if (int.TryParse(stateIdString, out stateId)) { }

                //                            if (stateId != 0 && stateId == country.StateId)
                //                            {
                //                                int cityId = 0;

                //                                string cityIdString = candidateCompany.City.Replace(".", "").Replace(",", "");

                //                                if (int.TryParse(cityIdString, out cityId)) { }

                //                                if (cityId != 0 && cityId == country.CityId)
                //                                {
                //                                    candidateSectionListCountriesDTO.Add(candidate);
                //                                }
                //                                else if (country.CityId == 0)
                //                                {
                //                                    candidateSectionListCountriesDTO.Add(candidate);
                //                                }
                //                            }
                //                            else if (country.StateId == 0)
                //                            {
                //                                candidateSectionListCountriesDTO.Add(candidate);
                //                            }
                //                        }
                //                    }
                //                }
                //            }
                //        }
                //    }

                //    candidatesFilters = candidateSectionListCountriesDTO;
                //}

                /* Jobs, TGs and format */

                if (candidatesFilters != null && candidatesFilters.Count > 0)
                {
                    foreach (Candidate candidate in candidatesFilters)
                    {
                        List<PostulationJobNameInDTO> jobs = new List<PostulationJobNameInDTO>();
                        List<CandidateTalentGroupNameInDTO> talents = new List<CandidateTalentGroupNameInDTO>();

                        var photo = "";
                        var init = "";
                        var name = "";

                        List<string> jobNames = new List<string>();
                        List<string> talentNames = new List<string>();

                        var jobCount = 0;
                        var talentCount = 0;

                        if (postulations != null && postulations.Count > 0)
                        {
                            jobs = postulations.Where(x => x.candidateId == candidate.CandidateId).ToList();

                            if (jobs != null && jobs.Count > 0)
                            {
                                foreach (var job in jobs)
                                {
                                    if (job != null)
                                        jobNames.Add(job.jobName);
                                }

                                jobCount = jobNames.Count();
                            }
                        }

                        if (talentGroups != null && talentGroups.Count > 0)
                        {
                            talents = talentGroups.Where(x => x.candidateId == candidate.CandidateId).ToList();
                            if (talents != null && talents.Count > 0)
                            {
                                foreach (var talent in talents)
                                {
                                    if (talent != null)
                                        talentNames.Add(talent.talentGroupName);
                                }

                                talentCount = talentNames.Count();
                            }
                        }

                        string CreationDateCandidate = "";
                        string CreationDateCandidatePopUp = "";
                        string CreationDateEnglishCandidate = "";
                        string CreationDateCandidatePopUpEnglish = "";

                        try
                        {
                            CreationDateCandidate = _basicInformationService.GetCreationDateFromString(candidate.CreationDate);
                            CreationDateCandidatePopUp = _basicInformationService.GetCreationDatePopUpByDate(candidate.CreationDate);
                            CreationDateEnglishCandidate = _basicInformationService.GetCreationDateFromStringEnglish(candidate.CreationDate);
                            CreationDateCandidatePopUpEnglish = _basicInformationService.GetCreationDatePopUpByDateEnglish(candidate.CreationDate);
                        }
                        catch (Exception ex)
                        {

                        }

                        if (candidate.BasicInformation != null)
                        {
                            if (!String.IsNullOrEmpty(candidate.BasicInformation.Photo) && candidate.BasicInformation.Photo != null)
                                photo = candidate.BasicInformation.Photo;
                            else
                                init = _basicInformationService.Initials(candidate.BasicInformation.Name, candidate.BasicInformation.Surname);

                            name = _basicInformationService.Name(candidate.BasicInformation.Name, candidate.BasicInformation.Surname);
                        }
                        if (candidate.BasicInformation == null && !string.IsNullOrEmpty(candidate.Email) && candidate.Email != null)
                        {
                            name = candidate.Email;
                            var sub = name.Substring(0, 2);
                            init = sub.ToUpper();
                        }

                        candidateSearchDTO candidateSearchDTO = new candidateSearchDTO()
                        {
                            CandidateId = candidate.CandidateId,
                            Photo = photo,
                            Initials = init,
                            Name = name,
                            CreationDateString = candidate.CreationDate,
                            CreationDate = CreationDateCandidate,
                            CreationDateEnglish = CreationDateEnglishCandidate,
                            CreationDatePopUp = CreationDateCandidatePopUp,
                            CreationDatePopUpEnglish = CreationDateCandidatePopUpEnglish,
                            Jobs = jobNames,
                            TotalJobs = jobCount,
                            TalentGroups = talentNames,
                            TotalTalentGroups = talentCount,
                            IsDeleteProccess = candidate.IsDeleteProccess,
                            Candidate_TechnicalAbilityList =
                                _mapper.Map<List<Candidate_TechnicalAbility>, List<Candidate_TechnicalAbilityDTO>>(candidate.Candidate_TechnicalAbilityList.ToList()),
                            Candidate_LanguageList =
                                _mapper.Map<List<Candidate_Language>, List<Candidate_LanguageDTO>>(candidate.Candidate_Language.ToList()),
                            StudyList =
                                _mapper.Map<List<Study>, List<StudyDTO>>(candidate.StudyList.ToList()),
                            WorkExperienceList =
                            _mapper.Map<List<WorkExperience>, List<WorkExperienceDTO>>(candidate.WorkExperienceList.ToList()),
                        };

                        if (jobs != null && jobs.Count > 0)
                        {
                            jobs.OrderByDescending(x => x.creationDate).ToList();

                            candidateSearchDTO.ColourFlag = jobs[0].colourFlag;

                            candidateSearchDTO.ColourFlagToltip = jobs[0].jobName;
                        }

                        if (candidateSearchDTO.ColourFlag == 0 && talents != null && talents.Count > 0)
                        {
                            talents.OrderByDescending(x => x.creationDate).ToList();

                            candidateSearchDTO.ColourFlag = talents[0].colourFlag;

                            candidateSearchDTO.ColourFlagToltip = talents[0].talentGroupName;
                        }

                        if (candidateSearchDTO != null)
                            candidateSectionListDTO.Add(candidateSearchDTO);
                    }
                }

                /* Technology */

                List<candidateSearchDTO> candidateSectionListTechnologyDTO = new List<candidateSearchDTO>();

                if (search.TechnicalAbilities != null && search.TechnicalAbilities.Count > 0)
                {
                    if (candidateSectionListDTO != null && candidateSectionListDTO.Count > 0)
                    {
                        foreach (candidateSearchDTO candidate in candidateSectionListDTO)
                        {
                            int technicalAbilitiesCount = 0;

                            if (candidateSectionListTechnologyDTO.Any(x => x.CandidateId == candidate.CandidateId))
                                continue;

                            foreach (TechnicalAbilitiesFromSearch technicalAbility in search.TechnicalAbilities)
                            {
                                if (candidate.Candidate_TechnicalAbilityList.Any(x => x.TechnicalAbilityTechnologyId == technicalAbility.TechnicalAbilityTechnologyId &&
                                x.TechnicalAbilityLevelId == technicalAbility.TechnicalAbilityLevelId))
                                    technicalAbilitiesCount++;
                            }

                            if (technicalAbilitiesCount == search.TechnicalAbilities.Count)
                                candidateSectionListTechnologyDTO.Add(candidate);
                        }
                    }

                    candidateSectionListDTO = candidateSectionListTechnologyDTO;
                }

                /* Languages */

                List<candidateSearchDTO> candidateSectionListLanguageDTO = new List<candidateSearchDTO>();

                if (search.Languages != null && search.Languages.Count > 0)
                {
                    if (candidateSectionListDTO != null && candidateSectionListDTO.Count > 0)
                    {
                        foreach (candidateSearchDTO candidate in candidateSectionListDTO)
                        {
                            int langaugesCount = 0;

                            if (candidateSectionListLanguageDTO.Any(x => x.CandidateId == candidate.CandidateId))
                                continue;

                            foreach (LanguagesFromSearch language in search.Languages)
                            {
                                if (candidate.Candidate_LanguageList.Any(x => x.LanguageId == language.LanguageId && x.LanguageLevelId == language.LanguageLevelId))
                                    langaugesCount++;
                            }

                            if (langaugesCount == search.Languages.Count)
                                candidateSectionListLanguageDTO.Add(candidate);
                        }
                    }

                    candidateSectionListDTO = candidateSectionListLanguageDTO;
                }

                /* Academic filter */

                List<candidateSearchDTO> candidateSectionListStudyDTO = new List<candidateSearchDTO>();

                if (search.JobProfessionId != 0 && candidateSectionListDTO != null && candidateSectionListDTO.Count > 0)
                {
                    foreach (candidateSearchDTO candidate in candidateSectionListDTO)
                    {
                        if (candidate != null && candidateSectionListStudyDTO.Any(x => x.CandidateId == candidate.CandidateId))
                            continue;

                        if (candidate != null && candidate.StudyList != null && candidate.StudyList.Count > 0 && candidate.StudyList.Any(x => x.JobProfessionId == search.JobProfessionId))
                            candidateSectionListStudyDTO.Add(candidate);
                    }

                    candidateSectionListDTO = candidateSectionListStudyDTO;
                }

                /* Companies filter */

                List<candidateSearchDTO> candidateSectionListCompanyDTO = new List<candidateSearchDTO>();

                if (search.Companies != null && search.Companies.Count > 0)
                {
                    foreach (string company in search.Companies)
                    {
                        if (candidateSectionListDTO != null && candidateSectionListDTO.Count > 0)
                        {
                            foreach (candidateSearchDTO candidate in candidateSectionListDTO)
                            {
                                if (candidate != null && candidateSectionListCompanyDTO.Any(x => x.CandidateId == candidate.CandidateId))
                                    continue;

                                if (candidate != null && candidate.WorkExperienceList != null && candidate.WorkExperienceList.Count > 0 && candidate.WorkExperienceList
                                    .Any(x => x.Company.ToLower().Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ü", "u")
                                    == company.ToLower().Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ü", "u")))
                                    candidateSectionListCompanyDTO.Add(candidate);
                            }
                        }
                    }

                    candidateSectionListDTO = candidateSectionListCompanyDTO;
                }

                /* Tags */

                List<TagListInDTO> tagsFilter = new List<TagListInDTO>();
                List<candidateSearchDTO> candidateSectionListTagsDTO = new List<candidateSearchDTO>();

                if (search != null && search.Tags != null && search.Tags.Count > 0 && tags != null && tags.Count > 0)
                {
                    foreach (TagListInDTO tag in tags)
                    {
                        if (search.Tags.Any(x => x == tag.tagId))
                            tagsFilter.Add(tag);
                    }
                }

                if (tagsFilter != null && tagsFilter.Count > 0)
                {
                    if (candidateSectionListDTO != null && candidateSectionListDTO.Count > 0)
                    {
                        foreach (candidateSearchDTO candidate in candidateSectionListDTO)
                        {
                            int tagsCount = 0;

                            if (candidateSectionListTagsDTO.Any(x => x.CandidateId == candidate.CandidateId))
                                continue;

                            foreach (TagListInDTO tag in tagsFilter)
                            {
                                if (tag.candidate_Tags.Any(x => x.candidateId == candidate.CandidateId))
                                    tagsCount++;
                            }

                            if (tagsCount == tagsFilter.Count)
                                candidateSectionListTagsDTO.Add(candidate);
                        }
                    }

                    candidateSectionListDTO = candidateSectionListTagsDTO;
                }

                /* Sources */

                List<SourceListInDTO> sourcesFilter = new List<SourceListInDTO>();
                List<candidateSearchDTO> candidateSectionListSourcesDTO = new List<candidateSearchDTO>();

                if (search != null && search.Sources != null && search.Sources.Count > 0 && sources != null && sources.Count > 0)
                {
                    foreach (SourceListInDTO source in sources)
                    {
                        if (search.Sources.Any(x => x == source.sourceId))
                            sourcesFilter.Add(source);
                    }
                }

                if (sourcesFilter != null && sourcesFilter.Count > 0)
                {
                    if (candidateSectionListDTO != null && candidateSectionListDTO.Count > 0)
                    {
                        foreach (candidateSearchDTO candidate in candidateSectionListDTO)
                        {
                            int sourcesCount = 0;

                            if (candidateSectionListSourcesDTO.Any(x => x.CandidateId == candidate.CandidateId))
                                continue;

                            foreach (SourceListInDTO source in sourcesFilter)
                            {
                                if (source.candidate_Sources.Any(x => x.candidateId == candidate.CandidateId))
                                    sourcesCount++;
                            }

                            if (sourcesCount == sourcesFilter.Count)
                                candidateSectionListSourcesDTO.Add(candidate);
                        }
                    }

                    candidateSectionListDTO = candidateSectionListSourcesDTO;
                }

                /* Order and previous - next */

                if (candidateSectionListDTO != null && candidateSectionListDTO.Count > 0)
                {
                    List<candidateSearchDTO> sorted = new List<candidateSearchDTO>();


                    string[] validformats = new[] { "MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss, fff",
                                            "MM/dd/yyyy hh:mm tt", "M/dd/yyyy h:mm:ss tt", "MM/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm:ss tt",
                                            "dd/MM/yyyy hh:mm:ss tt","dd/MM/yyyy hh:mm:ss","dd/MM/yyyy h:mm:ss","dd/MM/yyyy h:mm:ss ff",
                                            "dd/MM/yyyy h:mm:ss tt","dd/MM/yyyy hh:mm:ss ff","M/dd/yyyy hh:mm:ss tt"};

                    foreach (candidateSearchDTO candidate in candidateSectionListDTO)
                    {
                        DateTime auxDate = DateTime.Now;

                        if (DateTime.TryParseExact(candidate.CreationDateString.Replace(".", ""), validformats, CultureInfo.InvariantCulture, DateTimeStyles.None, out auxDate)) { }

                        candidate.CreationDateNotFormat = auxDate;
                    }

                    if (!search.Ascending)
                        sorted = candidateSectionListDTO.OrderByDescending(x => x.CreationDateNotFormat).ToList();
                    else
                        sorted = candidateSectionListDTO.OrderBy(x => x.CreationDateNotFormat).ToList();

                    List<candidateSearchDTO> pageSources = sorted.Skip((search.Page) * search.PageSize).Take(search.PageSize).ToList();

                    for (int i = 0; i < pageSources.Count; i++)
                    {
                        if (i == 0)
                            pageSources[i].Previous = 0;
                        else
                            pageSources[i].Previous = pageSources[i - 1].CandidateId;

                        if (i == pageSources.Count - 1)
                            pageSources[i].Next = 0;
                        else
                            pageSources[i].Next = pageSources[i + 1].CandidateId;
                    }

                    response.candidates = pageSources;
                    response.total = candidateSectionListDTO.Count;

                    return response;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<candidateSearchTotalDTO> GetAllCandidateSearchMaster(SearchByIdAndTextWithPaginationDTO search, string token)
        {

            List<Candidate> candidatesFilters = await _candidateRepository.GetCandidatesByFilterMaster(search.Text);
            JobProffesionIdSearchResponseDTO JobProfessions = await _companyRemoteRepository.GetAllJobProfessionsIdFromSearch(token.ToString(), search);
            List<int> CandidatesIds = new List<int>();
            foreach (JobProffesionIdSearchDTO professions in JobProfessions.search)
            {
                CandidatesIds.Add(professions.jobProffesionId);
            }

            List<Candidate> candidatesFromProfessionSearch = await _candidateRepository.GetCandidateWithJobProfessionsMaster(CandidatesIds);

            List<candidateSearchDTO> candidateSectionListDTO = new List<candidateSearchDTO>();

            candidateSearchTotalDTO response = new candidateSearchTotalDTO();
            if (candidatesFilters != null && candidatesFilters.Count > 0)
            {
                foreach (Candidate cand in candidatesFilters)
                {
                    var photo = "";
                    var init = "";
                    var name = "";
                    List<string> findNames = new List<string>();
                    string CreationDateCandidate = await _basicInformationService.CreationDate(cand.CandidateId);
                    string CreationDateCandidatePopUp = await _basicInformationService.CreationDatePopUp(cand.CandidateId);
                    string CreationDateCandidateEnglish = await _basicInformationService.CreationDateEnglish(cand.CandidateId);
                    string CreationDateCandidatePopUpEnglish = await _basicInformationService.CreationDatePopUpEnglish(cand.CandidateId);

                    if (cand.BasicInformation != null)
                    {
                        if (!String.IsNullOrEmpty(cand.BasicInformation.Photo) && cand.BasicInformation.Photo != null)
                            photo = cand.BasicInformation.Photo;
                        else
                            init = _basicInformationService.Initials(cand.BasicInformation.Name, cand.BasicInformation.Surname);

                        name = _basicInformationService.Name(cand.BasicInformation.Name, cand.BasicInformation.Surname);
                    }
                    if (cand.BasicInformation == null && !string.IsNullOrEmpty(cand.Email) && cand.Email != null)
                    {
                        name = cand.Email;
                        var sub = name.Substring(0, 2);
                        init = sub.ToUpper();
                    }
                    findNames.Add("Filtro Nombre,Correo,Telefono,Idioma,Habilidad Tecnica,Aspiracion Salarial,Experienca Laboral, Otros Estudios");
                    candidateSearchDTO candidateSearchDTO = new candidateSearchDTO()
                    {
                        CandidateId = cand.CandidateId,
                        Photo = photo,
                        Initials = init,
                        Name = name,
                        CreationDateString = cand.CreationDate,
                        CreationDate = CreationDateCandidate,
                        CreationDateEnglish = CreationDateCandidateEnglish,
                        CreationDatePopUp = CreationDateCandidatePopUp,
                        CreationDatePopUpEnglish = CreationDateCandidatePopUpEnglish,
                        Find = findNames,
                        IsDeleteProccess = cand.IsDeleteProccess
                    };

                    if (candidateSearchDTO != null)
                        candidateSectionListDTO.Add(candidateSearchDTO);
                }
            }

            if (candidatesFromProfessionSearch != null && candidatesFromProfessionSearch.Count > 0)
            {
                foreach (Candidate candidate in candidatesFromProfessionSearch)
                {
                    var buscar = candidateSectionListDTO.Any(x => x.CandidateId == candidate.CandidateId);
                    if (buscar)
                    {
                        candidateSearchDTO find = candidateSectionListDTO.FirstOrDefault(x => x.CandidateId == candidate.CandidateId);
                        find.Find.Add("Filtro Profesion");
                    }
                    else
                    {
                        if (candidate != null)
                        {
                            var photo = "";
                            var init = "";
                            var name = "";
                            List<string> findNames = new List<string>();

                            var CreationDateCandidate = await _basicInformationService.CreationDate(candidate.CandidateId);
                            var CreationDateCandidatePopUp = await _basicInformationService.CreationDatePopUp(candidate.CandidateId);
                            if (candidate.BasicInformation != null)
                            {
                                if (!String.IsNullOrEmpty(candidate.BasicInformation.Photo) && candidate.BasicInformation.Photo != null)
                                    photo = candidate.BasicInformation.Photo;
                                else
                                    init = _basicInformationService.Initials(candidate.BasicInformation.Name, candidate.BasicInformation.Surname);

                                name = _basicInformationService.Name(candidate.BasicInformation.Name, candidate.BasicInformation.Surname);
                            }
                            if (candidate.BasicInformation == null && !string.IsNullOrEmpty(candidate.Email) && candidate.Email != null)
                            {
                                name = candidate.Email;
                                var sub = name.Substring(0, 2);
                                init = sub.ToUpper();
                            }
                            findNames.Add("Filtro Profesion");
                            candidateSearchDTO candidateSearchDTO = new candidateSearchDTO()
                            {
                                CandidateId = candidate.CandidateId,
                                Photo = photo,
                                Initials = init,
                                Name = name,
                                CreationDate = CreationDateCandidate,
                                CreationDatePopUp = CreationDateCandidatePopUp,
                                Find = findNames,
                                IsDeleteProccess = candidate.IsDeleteProccess
                            };
                            candidateSectionListDTO.Add(candidateSearchDTO);
                        }
                    }
                }
            }

            if (candidateSectionListDTO != null && candidateSectionListDTO.Count > 0)
            {
                List<candidateSearchDTO> sorted = new List<candidateSearchDTO>();

                string[] validformats = new[] { "MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss, fff",
                                            "MM/dd/yyyy hh:mm tt", "M/dd/yyyy h:mm:ss tt", "MM/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm:ss tt",
                                            "dd/MM/yyyy hh:mm:ss tt","dd/MM/yyyy hh:mm:ss","dd/MM/yyyy h:mm:ss","dd/MM/yyyy h:mm:ss ff",
                                            "dd/MM/yyyy h:mm:ss tt","dd/MM/yyyy hh:mm:ss ff","M/dd/yyyy hh:mm:ss tt"};

                foreach (candidateSearchDTO candidate in candidateSectionListDTO)
                {
                    DateTime auxDate = DateTime.Now;

                    if (DateTime.TryParseExact(candidate.CreationDateString, validformats, CultureInfo.InvariantCulture, DateTimeStyles.None, out auxDate)) { }

                    candidate.CreationDateNotFormat = auxDate;
                }

                if (!search.Ascending)
                    sorted = candidateSectionListDTO.OrderByDescending(x => x.CreationDateNotFormat).ToList();
                else
                    sorted = candidateSectionListDTO.OrderBy(x => x.CreationDateNotFormat).ToList();

                List<candidateSearchDTO> pageSources = sorted.Skip((search.Page) * search.PageSize).Take(search.PageSize).ToList();

                for (int i = 0; i < pageSources.Count; i++)
                {
                    if (i == 0)
                        pageSources[i].Previous = 0;
                    else
                        pageSources[i].Previous = pageSources[i - 1].CandidateId;

                    if (i == pageSources.Count - 1)
                        pageSources[i].Next = 0;
                    else
                        pageSources[i].Next = pageSources[i + 1].CandidateId;
                }

                response.candidates = pageSources;
                response.total = candidateSectionListDTO.Count;
                return response;
            }

            return null;
        }

        public async Task<candidateSearchTotalDTO> GetAllCandidateFromTalentGroupAndSearch(SearchByIdAndTextWithPaginationDTO search, int companyUserId, string token)
        {
            try
            {
                CultureInfo culture = CultureInfo.CurrentCulture;

                /* Get candidates ids from Job */

                CandidateIdAndPostulationAndTGNumbersResponseDTO candidatesFromTalentGroupResponse = await _companyRemoteRepository.GetAllCandidateIdsFromTalentGroupId(token.ToString(), search);

                List<CandidateIdAndPostulationAndTGNumbersDTO> candidatesFromTalentGroup = candidatesFromTalentGroupResponse.search;

                List<int> candidatesIds = new List<int>();

                if (candidatesFromTalentGroup != null && candidatesFromTalentGroup.Count > 0)
                {
                    foreach (CandidateIdAndPostulationAndTGNumbersDTO candidateFromTalentGroup in candidatesFromTalentGroup)
                    {
                        candidatesIds.Add(candidateFromTalentGroup.candidateId);
                    }
                }

                /* Get words filters, Postulations and TGs */

                MemberByToken memberResponse = await _companyRemoteRepository.GetMemberUserFromCandidate(token.ToString());

                List<Candidate> candidatesFilters = await _candidateRepository.GetCandidatesByFilterAndJobOrTalentGroupFullList(search, companyUserId, candidatesIds);

                List<candidateSearchDTO> candidateSectionListDTO = new List<candidateSearchDTO>();

                List<PostulationJobNameInDTO> postulations = await _companyRemoteRepository.GetAllPostulationsWithNameAndColourFlag(token);
                List<CandidateTalentGroupNameInDTO> talentGroups = await _companyRemoteRepository.GetAllCandidateTalentWithNameAndColourFlag(token);
                List<TagListInDTO> tags = await _companyRemoteRepository.GetTagsByCompanyUser(companyUserId, token);
                List<SourceListInDTO> sources = await _companyRemoteRepository.GetSourcesByCompanyUser(companyUserId, token);

                candidateSearchTotalDTO response = new candidateSearchTotalDTO();

                /* Years experience */

                double experienceLowerLimit = 0;
                double experienceUpperLimit = 0;

                if (search.JobExperienceId != 0)
                {
                    switch (search.JobExperienceId)
                    {
                        case 1:
                            experienceLowerLimit = 0;
                            experienceUpperLimit = 0;
                            break;
                        case 2:
                            experienceLowerLimit = 1;
                            experienceUpperLimit = 3;
                            break;
                        case 3:
                            experienceLowerLimit = 3;
                            experienceUpperLimit = 5;
                            break;
                        case 4:
                            experienceLowerLimit = 5;
                            experienceUpperLimit = 7;
                            break;
                        case 5:
                            experienceLowerLimit = 7;
                            experienceUpperLimit = 9;
                            break;
                        case 6:
                            experienceLowerLimit = 9;
                            experienceUpperLimit = double.MaxValue;
                            break;
                        default:
                            break;
                    }
                }

                if (search != null && search.JobExperienceId != 0)
                {
                    List<Candidate> candidateSectionListExperience = new List<Candidate>();

                    if (candidatesFilters != null && candidatesFilters.Count > 0 && search != null && search.JobExperienceId > 0)
                    {
                        foreach (Candidate candidate in candidatesFilters)
                        {
                            double yearsExperience = 0;

                            CompanyDescription companyDescription = new CompanyDescription();

                            if (candidate.ExperienceCount != null && !string.IsNullOrEmpty(candidate.ExperienceCount.Years))
                            {
                                if (candidate.ExperienceCount != null && !string.IsNullOrEmpty(candidate.ExperienceCount.Years))
                                {
                                    if (culture != null && !string.IsNullOrEmpty(culture.Name) && culture.Name.Contains("es-"))
                                        double.TryParse(candidate.ExperienceCount.Years.Replace(".", ","), out yearsExperience);
                                    else
                                        double.TryParse(candidate.ExperienceCount.Years, out yearsExperience);
                                }

                                if (yearsExperience != 0 && yearsExperience >= experienceLowerLimit && yearsExperience <= experienceUpperLimit)
                                    candidateSectionListExperience.Add(candidate);
                            }
                            else if (candidate.CompanyDescriptionList != null && candidate.CompanyDescriptionList.Count > 0)
                            {
                                companyDescription = candidate.CompanyDescriptionList.Where(x => x.CompanyUserId == companyUserId).FirstOrDefault();

                                if (companyDescription != null && !string.IsNullOrEmpty(companyDescription.YearsExperience))
                                {
                                    if (culture != null && !string.IsNullOrEmpty(culture.Name) && culture.Name.Contains("es-"))
                                        double.TryParse(companyDescription.YearsExperience.Replace(".", ","), out yearsExperience);
                                    else
                                        double.TryParse(companyDescription.YearsExperience, out yearsExperience);
                                }

                                if (yearsExperience != 0 && yearsExperience >= experienceLowerLimit && yearsExperience <= experienceUpperLimit)
                                    candidateSectionListExperience.Add(candidate);

                                if (yearsExperience == 0 && search.JobExperienceId == 1 && companyDescription == null)
                                    candidateSectionListExperience.Add(candidate);

                                if (companyDescription == null)
                                    companyDescription = new CompanyDescription();
                            }

                            if (yearsExperience == 0 && search.JobExperienceId == 1 &&
                                (candidate.ExperienceCount == null || string.IsNullOrEmpty(candidate.ExperienceCount.Years)) &&
                                (string.IsNullOrEmpty(companyDescription.YearsExperience)))
                                candidateSectionListExperience.Add(candidate);
                        }

                        candidatesFilters = candidateSectionListExperience;
                    }
                }

                /* Currency */

                List<Candidate> candidateSectionListCurrencyExperience = new List<Candidate>();

                if (search != null && search.SalaryAspirations != null && search.SalaryAspirations.Count > 0)
                {
                    foreach (SalaryAspirationFromSearchDTO salaryAspiration in search.SalaryAspirations)
                    {
                        if (candidatesFilters != null && candidatesFilters.Count > 0 &&
                            int.Parse(salaryAspiration.CurrencyLowerValue.Replace(".", "").Replace(",", ""))
                            < int.Parse(salaryAspiration.CurrencyUpperValue.Replace(".", "").Replace(",", "")) &&
                            int.Parse(salaryAspiration.CurrencyLowerValue.Replace(".", "").Replace(",", "")) >= 0)
                        {
                            foreach (Candidate candidate in candidatesFilters)
                            {
                                if (candidate != null && candidate.BasicInformation != null && !string.IsNullOrEmpty(candidate.BasicInformation.SalaryAspiration))
                                {
                                    int salary = 0;

                                    string salaryAspirationString = candidate.BasicInformation.SalaryAspiration.Replace(".", "").Replace(",", "");

                                    if (candidateSectionListCurrencyExperience.Any(x => x.CandidateId == candidate.CandidateId))
                                        continue;

                                    if (int.TryParse(salaryAspirationString, out salary)) { }

                                    if (int.Parse(salaryAspiration.CurrencyLowerValue.Replace(".", "").Replace(",", "")) == 0 &&
                                        salary == 0 && salaryAspiration.CurrencyId == candidate.BasicInformation.CurrencyId)
                                    {
                                        candidateSectionListCurrencyExperience.Add(candidate);
                                    }
                                    else if (int.Parse(salaryAspiration.CurrencyLowerValue.Replace(".", "").Replace(",", ""))
                                            <= salary &&
                                            int.Parse(salaryAspiration.CurrencyUpperValue.Replace(".", "").Replace(",", ""))
                                            >= salary &&
                                            salaryAspiration.CurrencyId == candidate.BasicInformation.CurrencyId)
                                    {
                                        candidateSectionListCurrencyExperience.Add(candidate);
                                    }
                                }
                                else if (candidate != null && candidate.CandidateCompanies != null)
                                {
                                    CandidateCompany candidateCompany = candidate.CandidateCompanies.Where(x => x.CompanyUserId == companyUserId).FirstOrDefault();

                                    if (candidateCompany != null && !string.IsNullOrEmpty(candidateCompany.SalaryAspiration))
                                    {
                                        int salary = 0;

                                        string salaryAspirationString = candidateCompany.SalaryAspiration.Replace(".", "").Replace(",", "");

                                        if (candidateSectionListCurrencyExperience.Any(x => x.CandidateId == candidate.CandidateId))
                                            continue;

                                        if (int.TryParse(salaryAspirationString, out salary)) { }

                                        if (int.Parse(salaryAspiration.CurrencyLowerValue.Replace(".", "").Replace(",", "")) == 0 &&
                                            salary == 0 && salaryAspiration.CurrencyId == candidateCompany.CurrencyId)
                                        {
                                            candidateSectionListCurrencyExperience.Add(candidate);
                                        }
                                        else if (int.Parse(salaryAspiration.CurrencyLowerValue.Replace(".", "").Replace(",", "")) <= salary &&
                                            int.Parse(salaryAspiration.CurrencyUpperValue.Replace(".", "").Replace(",", "")) >= salary &&
                                            salaryAspiration.CurrencyId == candidateCompany.CurrencyId)
                                        {
                                            candidateSectionListCurrencyExperience.Add(candidate);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    candidatesFilters = candidateSectionListCurrencyExperience;
                }

                /* Countries list */

                //List<Candidate> candidateSectionListCountriesDTO = new List<Candidate>();

                //if (search != null && search.Countries != null && search.Countries.Count > 0)
                //{
                //    foreach (CountriesFromSearchDTO country in search.Countries)
                //    {
                //        if (candidatesFilters != null && candidatesFilters.Count > 0 && country.CountryId != 0)
                //        {
                //            foreach (Candidate candidate in candidatesFilters)
                //            {
                //                if (candidate != null && candidate.BasicInformation != null && !string.IsNullOrEmpty(candidate.BasicInformation.Country))
                //                {
                //                    int countryId = 0;

                //                    string countryIdString = candidate.BasicInformation.Country.Replace(".", "").Replace(",", "");

                //                    if (candidateSectionListCountriesDTO.Any(x => x.CandidateId == candidate.CandidateId))
                //                        continue;

                //                    if (int.TryParse(countryIdString, out countryId)) { }

                //                    if (countryId == country.CountryId)
                //                    {
                //                        int stateId = 0;

                //                        string stateIdString = candidate.BasicInformation.State.Replace(".", "").Replace(",", "");

                //                        if (int.TryParse(stateIdString, out stateId)) { }

                //                        if (stateId != 0 && stateId == country.StateId)
                //                        {
                //                            int cityId = 0;

                //                            string cityIdString = candidate.BasicInformation.City.Replace(".", "").Replace(",", "");

                //                            if (int.TryParse(cityIdString, out cityId)) { }

                //                            if (cityId != 0 && cityId == country.CityId)
                //                            {
                //                                candidateSectionListCountriesDTO.Add(candidate);
                //                            }
                //                            else if (country.CityId == 0)
                //                            {
                //                                candidateSectionListCountriesDTO.Add(candidate);
                //                            }
                //                        }
                //                        else if (country.StateId == 0)
                //                        {
                //                            candidateSectionListCountriesDTO.Add(candidate);
                //                        }
                //                    }
                //                }
                //                else if (candidate != null && candidate.CandidateCompanies != null)
                //                {
                //                    CandidateCompany candidateCompany = candidate.CandidateCompanies.Where(x => x.CompanyUserId == companyUserId).FirstOrDefault();

                //                    if (candidate != null && candidateCompany != null && !string.IsNullOrEmpty(candidateCompany.Country))
                //                    {
                //                        int countryId = 0;

                //                        string countryIdString = candidateCompany.Country.Replace(".", "").Replace(",", "");

                //                        if (candidateSectionListCountriesDTO.Any(x => x.CandidateId == candidate.CandidateId))
                //                            continue;

                //                        if (int.TryParse(countryIdString, out countryId)) { }

                //                        if (countryId == country.CountryId)
                //                        {
                //                            int stateId = 0;

                //                            string stateIdString = candidateCompany.State.Replace(".", "").Replace(",", "");

                //                            if (int.TryParse(stateIdString, out stateId)) { }

                //                            if (stateId != 0 && stateId == country.StateId)
                //                            {
                //                                int cityId = 0;

                //                                string cityIdString = candidateCompany.City.Replace(".", "").Replace(",", "");

                //                                if (int.TryParse(cityIdString, out cityId)) { }

                //                                if (cityId != 0 && cityId == country.CityId)
                //                                {
                //                                    candidateSectionListCountriesDTO.Add(candidate);
                //                                }
                //                                else if (country.CityId == 0)
                //                                {
                //                                    candidateSectionListCountriesDTO.Add(candidate);
                //                                }
                //                            }
                //                            else if (country.StateId == 0)
                //                            {
                //                                candidateSectionListCountriesDTO.Add(candidate);
                //                            }
                //                        }
                //                    }
                //                }
                //            }
                //        }
                //    }

                //    candidatesFilters = candidateSectionListCountriesDTO;
                //}

                ///* Jobs, TGs and format */

                //if (candidatesFilters != null && candidatesFilters.Count > 0)
                //{
                //    foreach (Candidate candidate in candidatesFilters)
                //    {
                //        List<PostulationJobNameInDTO> jobs = new List<PostulationJobNameInDTO>();
                //        List<CandidateTalentGroupNameInDTO> talents = new List<CandidateTalentGroupNameInDTO>();

                //        var photo = "";
                //        var init = "";
                //        var name = "";

                //        List<string> jobNames = new List<string>();
                //        List<string> talentNames = new List<string>();

                //        var jobCount = 0;
                //        var talentCount = 0;

                //        if (postulations != null && postulations.Count > 0)
                //        {
                //            jobs = postulations.Where(x => x.candidateId == candidate.CandidateId).ToList();

                //            if (jobs != null && jobs.Count > 0)
                //            {
                //                foreach (var job in jobs)
                //                {
                //                    if (job != null)
                //                        jobNames.Add(job.jobName);
                //                }

                //                jobCount = jobNames.Count();
                //            }
                //        }

                //        if (talentGroups != null && talentGroups.Count > 0)
                //        {
                //            talents = talentGroups.Where(x => x.candidateId == candidate.CandidateId).ToList();
                //            if (talents != null && talents.Count > 0)
                //            {
                //                foreach (var talent in talents)
                //                {
                //                    if (talent != null)
                //                        talentNames.Add(talent.talentGroupName);
                //                }

                //                talentCount = talentNames.Count();
                //            }
                //        }

                //        string CreationDateCandidate = "";
                //        string CreationDateCandidatePopUp = "";
                //        string CreationDateEnglishCandidate = "";
                //        string CreationDateCandidatePopUpEnglish = "";

                //        try
                //        {
                //            CreationDateCandidate = _basicInformationService.GetCreationDateFromString(candidate.CreationDate);
                //            CreationDateCandidatePopUp = _basicInformationService.GetCreationDatePopUpByDate(candidate.CreationDate);
                //            CreationDateEnglishCandidate = _basicInformationService.GetCreationDateFromStringEnglish(candidate.CreationDate);
                //            CreationDateCandidatePopUpEnglish = _basicInformationService.GetCreationDatePopUpByDateEnglish(candidate.CreationDate);
                //        }
                //        catch (Exception ex)
                //        {

                //        }

                //        if (candidate.BasicInformation != null)
                //        {
                //            if (!String.IsNullOrEmpty(candidate.BasicInformation.Photo) && candidate.BasicInformation.Photo != null)
                //                photo = candidate.BasicInformation.Photo;
                //            else
                //                init = _basicInformationService.Initials(candidate.BasicInformation.Name, candidate.BasicInformation.Surname);

                //            name = _basicInformationService.Name(candidate.BasicInformation.Name, candidate.BasicInformation.Surname);
                //        }
                //        if (candidate.BasicInformation == null && !string.IsNullOrEmpty(candidate.Email) && candidate.Email != null)
                //        {
                //            name = candidate.Email;
                //            var sub = name.Substring(0, 2);
                //            init = sub.ToUpper();
                //        }

                //        candidateSearchDTO candidateSearchDTO = new candidateSearchDTO()
                //        {
                //            CandidateId = candidate.CandidateId,
                //            Photo = photo,
                //            Initials = init,
                //            Name = name,
                //            CreationDateString = candidate.CreationDate,
                //            CreationDate = CreationDateCandidate,
                //            CreationDateEnglish = CreationDateEnglishCandidate,
                //            CreationDatePopUp = CreationDateCandidatePopUp,
                //            CreationDatePopUpEnglish = CreationDateCandidatePopUpEnglish,
                //            Jobs = jobNames,
                //            TotalJobs = jobCount,
                //            TalentGroups = talentNames,
                //            TotalTalentGroups = talentCount,
                //            IsDeleteProccess = candidate.IsDeleteProccess,
                //            Candidate_TechnicalAbilityList =
                //                _mapper.Map<List<Candidate_TechnicalAbility>, List<Candidate_TechnicalAbilityDTO>>(candidate.Candidate_TechnicalAbilityList.ToList()),
                //            Candidate_LanguageList =
                //                _mapper.Map<List<Candidate_Language>, List<Candidate_LanguageDTO>>(candidate.Candidate_Language.ToList()),
                //            StudyList =
                //                _mapper.Map<List<Study>, List<StudyDTO>>(candidate.StudyList.ToList()),
                //            WorkExperienceList =
                //                _mapper.Map<List<WorkExperience>, List<WorkExperienceDTO>>(candidate.WorkExperienceList.ToList()),
                //        };

                //        if (jobs != null && jobs.Count > 0)
                //        {
                //            jobs.OrderByDescending(x => x.creationDate).ToList();

                //            candidateSearchDTO.ColourFlag = jobs[0].colourFlag;

                //            candidateSearchDTO.ColourFlagToltip = jobs[0].jobName;
                //        }

                //        if (candidateSearchDTO.ColourFlag == 0 && talents != null && talents.Count > 0)
                //        {
                //            talents.OrderByDescending(x => x.creationDate).ToList();

                //            candidateSearchDTO.ColourFlag = talents[0].colourFlag;

                //            candidateSearchDTO.ColourFlagToltip = talents[0].talentGroupName;
                //        }

                //        if (candidateSearchDTO != null)
                //            candidateSectionListDTO.Add(candidateSearchDTO);
                //    }
                //}

                /* Languages */

                List<candidateSearchDTO> candidateSectionListLanguageDTO = new List<candidateSearchDTO>();

                if (search.Languages != null && search.Languages.Count > 0)
                {
                    if (candidateSectionListDTO != null && candidateSectionListDTO.Count > 0)
                    {
                        foreach (candidateSearchDTO candidate in candidateSectionListDTO)
                        {
                            int langaugesCount = 0;

                            if (candidateSectionListLanguageDTO.Any(x => x.CandidateId == candidate.CandidateId))
                                continue;

                            foreach (LanguagesFromSearch language in search.Languages)
                            {
                                if (candidate.Candidate_LanguageList.Any(x => x.LanguageId == language.LanguageId && x.LanguageLevelId == language.LanguageLevelId))
                                    langaugesCount++;
                            }

                            if (langaugesCount == search.Languages.Count)
                                candidateSectionListLanguageDTO.Add(candidate);
                        }
                    }

                    candidateSectionListDTO = candidateSectionListLanguageDTO;
                }

                /* Academic filter */

                List<candidateSearchDTO> candidateSectionListStudyDTO = new List<candidateSearchDTO>();

                if (search.JobProfessionId != 0 && candidateSectionListDTO != null && candidateSectionListDTO.Count > 0)
                {
                    foreach (candidateSearchDTO candidate in candidateSectionListDTO)
                    {
                        if (candidate != null && candidateSectionListStudyDTO.Any(x => x.CandidateId == candidate.CandidateId))
                            continue;

                        if (candidate != null && candidate.StudyList != null && candidate.StudyList.Count > 0 && candidate.StudyList.Any(x => x.JobProfessionId == search.JobProfessionId))
                            candidateSectionListStudyDTO.Add(candidate);
                    }

                    candidateSectionListDTO = candidateSectionListStudyDTO;
                }

                /* Companies filter */

                List<candidateSearchDTO> candidateSectionListCompanyDTO = new List<candidateSearchDTO>();

                if (search.Companies != null && search.Companies.Count > 0)
                {
                    foreach (string company in search.Companies)
                    {
                        if (candidateSectionListDTO != null && candidateSectionListDTO.Count > 0)
                        {
                            foreach (candidateSearchDTO candidate in candidateSectionListDTO)
                            {
                                if (candidate != null && candidateSectionListCompanyDTO.Any(x => x.CandidateId == candidate.CandidateId))
                                    continue;

                                if (candidate != null && candidate.WorkExperienceList != null && candidate.WorkExperienceList.Count > 0 && candidate.WorkExperienceList
                                    .Any(x => x.Company.ToLower().Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ü", "u")
                                    == company.ToLower().Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ü", "u")))
                                    candidateSectionListCompanyDTO.Add(candidate);
                            }
                        }
                    }

                    candidateSectionListDTO = candidateSectionListCompanyDTO;
                }

                /* Tags */

                List<TagListInDTO> tagsFilter = new List<TagListInDTO>();
                List<candidateSearchDTO> candidateSectionListTagsDTO = new List<candidateSearchDTO>();

                if (search != null && search.Tags != null && search.Tags.Count > 0 && tags != null && tags.Count > 0)
                {
                    foreach (TagListInDTO tag in tags)
                    {
                        if (search.Tags.Any(x => x == tag.tagId))
                            tagsFilter.Add(tag);
                    }
                }

                if (tagsFilter != null && tagsFilter.Count > 0)
                {
                    if (candidateSectionListDTO != null && candidateSectionListDTO.Count > 0)
                    {
                        foreach (candidateSearchDTO candidate in candidateSectionListDTO)
                        {
                            int tagsCount = 0;

                            if (candidateSectionListTagsDTO.Any(x => x.CandidateId == candidate.CandidateId))
                                continue;

                            foreach (TagListInDTO tag in tagsFilter)
                            {
                                if (tag.candidate_Tags.Any(x => x.candidateId == candidate.CandidateId))
                                    tagsCount++;
                            }

                            if (tagsCount == tagsFilter.Count)
                                candidateSectionListTagsDTO.Add(candidate);
                        }
                    }

                    candidateSectionListDTO = candidateSectionListTagsDTO;
                }

                /* Sources */

                List<SourceListInDTO> sourcesFilter = new List<SourceListInDTO>();
                List<candidateSearchDTO> candidateSectionListSourcesDTO = new List<candidateSearchDTO>();

                if (search != null && search.Sources != null && search.Sources.Count > 0 && sources != null && sources.Count > 0)
                {
                    foreach (SourceListInDTO source in sources)
                    {
                        if (search.Sources.Any(x => x == source.sourceId))
                            sourcesFilter.Add(source);
                    }
                }

                if (sourcesFilter != null && sourcesFilter.Count > 0)
                {
                    if (candidateSectionListDTO != null && candidateSectionListDTO.Count > 0)
                    {
                        foreach (candidateSearchDTO candidate in candidateSectionListDTO)
                        {
                            int sourcesCount = 0;

                            if (candidateSectionListSourcesDTO.Any(x => x.CandidateId == candidate.CandidateId))
                                continue;

                            foreach (SourceListInDTO source in sourcesFilter)
                            {
                                if (source.candidate_Sources.Any(x => x.candidateId == candidate.CandidateId))
                                    sourcesCount++;
                            }

                            if (sourcesCount == sourcesFilter.Count)
                                candidateSectionListSourcesDTO.Add(candidate);
                        }
                    }

                    candidateSectionListDTO = candidateSectionListSourcesDTO;
                }

                /* Order and previous - next */

                if (candidateSectionListDTO != null && candidateSectionListDTO.Count > 0)
                {

                    for (int i = 0; i < candidateSectionListDTO.Count; i++)
                    {
                        if (i == 0)
                            candidateSectionListDTO[i].Previous = 0;
                        else
                            candidateSectionListDTO[i].Previous = candidateSectionListDTO[i - 1].CandidateId;

                        if (i == candidateSectionListDTO.Count - 1)
                            candidateSectionListDTO[i].Next = 0;
                        else
                            candidateSectionListDTO[i].Next = candidateSectionListDTO[i + 1].CandidateId;
                    }

                    response.candidates = candidateSectionListDTO;
                    response.total = candidateSectionListDTO.Count;

                    return response;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /**/

        public async Task<candidateSearchTotalDTO> SearchCandidatesByTalentGroup(SearchByIdAndTextWithPaginationDTO search, int companyUserId, string token)
        {
            try
            {
                CultureInfo culture = CultureInfo.CurrentCulture;

                /* Get words filters, Postulations and TGs */

                List<Candidate> candidatesFilters = new List<Candidate>();
                int totalCount = 0;

                Dictionary<string, dynamic> resultObject =  
                    await _candidateRepository.GetCandidatesByFilterAndTalentGroup(search, companyUserId, culture, token);

                totalCount = resultObject["totalCount"];
                candidatesFilters = resultObject["candidatesList"];

                List<candidateSearchDTO> candidateSectionListDTO = [];

                /* Postulations & Talent Groups from new Methods */

                List<int> candidateIds = candidatesFilters.Select(candidate => candidate.CandidateId).ToList();

                PercentCriteria percentCriteria = await _percentCriteriaRepository.GetByCompanyUserId(companyUserId);

                List<PostulationJobNameDTO> postulations = await _postulationService.GetAllPostulationsWithJobNameAndEvaluations(candidateIds, percentCriteria, token);
                List<CandidateTalentGroupNameDTO> talentGroups = await _candidate_TalentGroupService.GetAllCandidateTalentGroupsWithNameAndEvaluations(candidateIds, percentCriteria, token);

                candidateSearchTotalDTO response = new();

                /* Jobs, TGs and format */

                if (candidatesFilters != null && candidatesFilters.Count > 0)
                {
                    foreach (Candidate candidate in candidatesFilters)
                    {
                        List<PostulationJobNameDTO> jobs = [];
                        List<CandidateTalentGroupNameDTO> talents = [];

                        string photo = string.Empty;
                        string init = string.Empty;
                        string name = string.Empty;

                        List<string> jobNames = [];
                        List<string> talentNames = [];

                        int jobCount = 0;
                        int talentCount = 0;

                        if (postulations != null && postulations.Count > 0)
                        {
                            jobs = postulations
                                .Where
                                (
                                    postulationJobName => postulationJobName.CandidateId == candidate.CandidateId
                                )
                                .ToList();

                            if (jobs != null && jobs.Count > 0)
                            {
                                foreach (PostulationJobNameDTO job in jobs)
                                {
                                    if (job != null)
                                        jobNames.Add(job.JobName);
                                }

                                jobCount = jobNames.Count();
                            }
                        }

                        if (talentGroups != null && talentGroups.Count > 0)
                        {
                            talents = talentGroups.Where(candidateTalentGroupName => candidateTalentGroupName.CandidateId == candidate.CandidateId).ToList();

                            if (talents != null && talents.Count > 0)
                            {
                                foreach (var talent in talents)
                                {
                                    if (talent != null)
                                        talentNames.Add(talent.TalentGroupName);
                                }

                                talentCount = talentNames.Count();
                            }
                        }

                        string CreationDateCandidate = "";
                        string CreationDateCandidatePopUp = "";
                        string CreationDateEnglishCandidate = "";
                        string CreationDateCandidatePopUpEnglish = "";

                        try
                        {
                            CreationDateCandidate = _basicInformationService.GetCreationDateFromString(candidate.CreationDate);
                            CreationDateCandidatePopUp = _basicInformationService.GetCreationDatePopUpByDate(candidate.CreationDate);
                            CreationDateEnglishCandidate = _basicInformationService.GetCreationDateFromStringEnglish(candidate.CreationDate);
                            CreationDateCandidatePopUpEnglish = _basicInformationService.GetCreationDatePopUpByDateEnglish(candidate.CreationDate);
                        }
                        catch (Exception ex)
                        {

                        }

                        if (candidate.BasicInformation != null)
                        {
                            if (!string.IsNullOrEmpty(candidate.BasicInformation.Photo) && candidate.BasicInformation.Photo != null)
                                photo = candidate.BasicInformation.Photo;
                            else
                                init = _basicInformationService.Initials(candidate.BasicInformation.Name, candidate.BasicInformation.Surname);

                            name = _basicInformationService.Name(candidate.BasicInformation.Name, candidate.BasicInformation.Surname);
                        }
                        if (candidate.BasicInformation == null && !string.IsNullOrEmpty(candidate.Email) && candidate.Email != null)
                        {
                            name = candidate.Email;
                            var sub = name.Substring(0, 2);
                            init = sub.ToUpper();
                        }

                        candidateSearchDTO candidateSearchDTO = new candidateSearchDTO()
                        {
                            CandidateId = candidate.CandidateId,
                            Photo = photo,
                            Initials = init,
                            Name = name,
                            CreationDateString = candidate.CreationDate,
                            CreationDate = CreationDateCandidate,
                            CreationDateEnglish = CreationDateEnglishCandidate,
                            CreationDatePopUp = CreationDateCandidatePopUp,
                            CreationDatePopUpEnglish = CreationDateCandidatePopUpEnglish,
                            Jobs = jobNames,
                            TotalJobs = jobCount,
                            TalentGroups = talentNames,
                            TotalTalentGroups = talentCount,
                            IsDeleteProccess = candidate.IsDeleteProccess,
                            Candidate_TechnicalAbilityList =
                                _mapper.Map<List<Candidate_TechnicalAbility>, List<Candidate_TechnicalAbilityDTO>>(candidate.Candidate_TechnicalAbilityList.ToList()),
                            Candidate_LanguageList =
                                _mapper.Map<List<Candidate_Language>, List<Candidate_LanguageDTO>>(candidate.Candidate_Language.ToList()),
                            StudyList =
                                _mapper.Map<List<Study>, List<StudyDTO>>(candidate.StudyList.ToList()),
                            WorkExperienceList =
                                _mapper.Map<List<WorkExperience>, List<WorkExperienceDTO>>(candidate.WorkExperienceList.ToList()),
                        };

                        if (jobs != null && jobs.Count > 0)
                        {
                            jobs.OrderByDescending(postulationJobName => postulationJobName.CreationDate).ToList();

                            candidateSearchDTO.ColourFlag = jobs[0].ColourFlag;

                            candidateSearchDTO.ColourFlagToltip = jobs[0].JobName;
                        }

                        if (candidateSearchDTO.ColourFlag == 0 && talents != null && talents.Count > 0)
                        {
                            talents.OrderByDescending(x => x.CreationDate).ToList();

                            candidateSearchDTO.ColourFlag = talents[0].ColourFlag;

                            candidateSearchDTO.ColourFlagToltip = talents[0].TalentGroupName;
                        }

                        if (candidateSearchDTO != null)
                            candidateSectionListDTO.Add(candidateSearchDTO);
                    }
                }

                /* Return */

                if (candidateSectionListDTO != null && candidateSectionListDTO.Count > 0)
                {
                    response.candidates = candidateSectionListDTO;
                    response.total = totalCount;

                    return response;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /**/

        public async Task<candidateSearchTotalDTO> SearchCandidatesByJob(SearchByIdAndTextWithPaginationDTO search, int companyUserId, string token)
        {
            try
            {
                CultureInfo culture = CultureInfo.CurrentCulture;

                /* Get words filters, Postulations and TGs */

                List<Candidate> candidatesFilters = new List<Candidate>();
                int totalCount = 0;

                Dictionary<string, dynamic> resultObject =
                    await _candidateRepository.GetCandidatesByFilterAndJob(search, companyUserId, culture, token);

                totalCount = resultObject["totalCount"];
                candidatesFilters = resultObject["candidatesList"];

                List<candidateSearchDTO> candidateSectionListDTO = [];

                /* Postulations & Talent Groups from new Methods */

                List<int> candidateIds = candidatesFilters.Select(candidate => candidate.CandidateId).ToList();

                PercentCriteria percentCriteria = await _percentCriteriaRepository.GetByCompanyUserId(companyUserId);

                List<PostulationJobNameDTO> postulations = await _postulationService.GetAllPostulationsWithJobNameAndEvaluations(candidateIds, percentCriteria, token);
                List<CandidateTalentGroupNameDTO> talentGroups = await _candidate_TalentGroupService.GetAllCandidateTalentGroupsWithNameAndEvaluations(candidateIds, percentCriteria, token);

                candidateSearchTotalDTO response = new();

                /* Jobs, TGs and format */

                if (candidatesFilters != null && candidatesFilters.Count > 0)
                {
                    foreach (Candidate candidate in candidatesFilters)
                    {
                        List<PostulationJobNameDTO> jobs = [];
                        List<CandidateTalentGroupNameDTO> talents = [];

                        string photo = string.Empty;
                        string init = string.Empty;
                        string name = string.Empty;

                        List<string> jobNames = [];
                        List<string> talentNames = [];

                        int jobCount = 0;
                        int talentCount = 0;

                        if (postulations != null && postulations.Count > 0)
                        {
                            jobs = postulations
                                .Where
                                (
                                    postulationJobName => postulationJobName.CandidateId == candidate.CandidateId
                                )
                                .ToList();

                            if (jobs != null && jobs.Count > 0)
                            {
                                foreach (PostulationJobNameDTO job in jobs)
                                {
                                    if (job != null)
                                        jobNames.Add(job.JobName);
                                }

                                jobCount = jobNames.Count();
                            }
                        }

                        if (talentGroups != null && talentGroups.Count > 0)
                        {
                            talents = talentGroups.Where(candidateTalentGroupName => candidateTalentGroupName.CandidateId == candidate.CandidateId).ToList();

                            if (talents != null && talents.Count > 0)
                            {
                                foreach (var talent in talents)
                                {
                                    if (talent != null)
                                        talentNames.Add(talent.TalentGroupName);
                                }

                                talentCount = talentNames.Count();
                            }
                        }

                        string CreationDateCandidate = "";
                        string CreationDateCandidatePopUp = "";
                        string CreationDateEnglishCandidate = "";
                        string CreationDateCandidatePopUpEnglish = "";

                        try
                        {
                            CreationDateCandidate = _basicInformationService.GetCreationDateFromString(candidate.CreationDate);
                            CreationDateCandidatePopUp = _basicInformationService.GetCreationDatePopUpByDate(candidate.CreationDate);
                            CreationDateEnglishCandidate = _basicInformationService.GetCreationDateFromStringEnglish(candidate.CreationDate);
                            CreationDateCandidatePopUpEnglish = _basicInformationService.GetCreationDatePopUpByDateEnglish(candidate.CreationDate);
                        }
                        catch (Exception ex)
                        {

                        }

                        if (candidate.BasicInformation != null)
                        {
                            if (!string.IsNullOrEmpty(candidate.BasicInformation.Photo) && candidate.BasicInformation.Photo != null)
                                photo = candidate.BasicInformation.Photo;
                            else
                                init = _basicInformationService.Initials(candidate.BasicInformation.Name, candidate.BasicInformation.Surname);

                            name = _basicInformationService.Name(candidate.BasicInformation.Name, candidate.BasicInformation.Surname);
                        }
                        if (candidate.BasicInformation == null && !string.IsNullOrEmpty(candidate.Email) && candidate.Email != null)
                        {
                            name = candidate.Email;
                            var sub = name.Substring(0, 2);
                            init = sub.ToUpper();
                        }

                        candidateSearchDTO candidateSearchDTO = new candidateSearchDTO()
                        {
                            CandidateId = candidate.CandidateId,
                            Photo = photo,
                            Initials = init,
                            Name = name,
                            CreationDateString = candidate.CreationDate,
                            CreationDate = CreationDateCandidate,
                            CreationDateEnglish = CreationDateEnglishCandidate,
                            CreationDatePopUp = CreationDateCandidatePopUp,
                            CreationDatePopUpEnglish = CreationDateCandidatePopUpEnglish,
                            Jobs = jobNames,
                            TotalJobs = jobCount,
                            TalentGroups = talentNames,
                            TotalTalentGroups = talentCount,
                            IsDeleteProccess = candidate.IsDeleteProccess,
                            Candidate_TechnicalAbilityList =
                                _mapper.Map<List<Candidate_TechnicalAbility>, List<Candidate_TechnicalAbilityDTO>>(candidate.Candidate_TechnicalAbilityList.ToList()),
                            Candidate_LanguageList =
                                _mapper.Map<List<Candidate_Language>, List<Candidate_LanguageDTO>>(candidate.Candidate_Language.ToList()),
                            StudyList =
                                _mapper.Map<List<Study>, List<StudyDTO>>(candidate.StudyList.ToList()),
                            WorkExperienceList =
                                _mapper.Map<List<WorkExperience>, List<WorkExperienceDTO>>(candidate.WorkExperienceList.ToList()),
                        };

                        if (jobs != null && jobs.Count > 0)
                        {
                            jobs.OrderByDescending(postulationJobName => postulationJobName.CreationDate).ToList();

                            candidateSearchDTO.ColourFlag = jobs[0].ColourFlag;

                            candidateSearchDTO.ColourFlagToltip = jobs[0].JobName;
                        }

                        if (candidateSearchDTO.ColourFlag == 0 && talents != null && talents.Count > 0)
                        {
                            talents.OrderByDescending(x => x.CreationDate).ToList();

                            candidateSearchDTO.ColourFlag = talents[0].ColourFlag;

                            candidateSearchDTO.ColourFlagToltip = talents[0].TalentGroupName;
                        }

                        if (candidateSearchDTO != null)
                            candidateSectionListDTO.Add(candidateSearchDTO);
                    }
                }

                /* Return */

                if (candidateSectionListDTO != null && candidateSectionListDTO.Count > 0)
                {
                    response.candidates = candidateSectionListDTO;
                    response.total = totalCount;

                    return response;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /**/

        public async Task<candidateSearchTotalDTO> SearchCandidatesGeneral(SearchByIdAndTextWithPaginationDTO search, int companyUserId, bool isExsis, bool isMaster, string token)
        {
            try
            {
                CultureInfo culture = CultureInfo.CurrentCulture;

                /* Get words filters, Postulations and TGs */

                List<Candidate> candidatesFilters = [];
                int totalCount = 0;

                Dictionary<string, dynamic> resultObject =
                    await _candidateRepository.GetCandidatesByFilterGeneral(search, companyUserId, isExsis, isMaster, culture, token);

                totalCount = resultObject["totalCount"];
                candidatesFilters = resultObject["candidatesList"];

                List<candidateSearchDTO> candidateSectionListDTO = [];

                /* Postulations & Talent Groups from new Methods */

                List<int> candidateIds = candidatesFilters.Select(candidate => candidate.CandidateId).ToList();

                PercentCriteria percentCriteria = await _percentCriteriaRepository.GetByCompanyUserId(companyUserId);

                List<PostulationJobNameDTO> postulations = await _postulationService.GetAllPostulationsWithJobNameAndEvaluations(candidateIds, percentCriteria, token);
                List<CandidateTalentGroupNameDTO> talentGroups = await _candidate_TalentGroupService.GetAllCandidateTalentGroupsWithNameAndEvaluations(candidateIds, percentCriteria, token);

                candidateSearchTotalDTO response = new();

                /* Jobs, TGs and format */

                if (candidatesFilters != null && candidatesFilters.Count > 0)
                {
                    //Parallel.ForEach
                    //(
                    //    candidatesFilters, 
                    //    candidate =>
                    foreach(Candidate candidate in candidatesFilters)
                        {
                            List<PostulationJobNameDTO> jobs = [];
                            List<CandidateTalentGroupNameDTO> talents = [];

                            string photo = string.Empty;
                            string init = string.Empty;
                            string name = string.Empty;

                            List<string> jobNames = [];
                            List<string> talentNames = [];

                            int jobCount = 0;
                            int talentCount = 0;

                            if (postulations != null && postulations.Count > 0)
                            {
                                jobs = postulations
                                    .AsParallel()
                                    .Where
                                    (
                                        postulationJobName => postulationJobName.CandidateId == candidate.CandidateId
                                    )
                                    .ToList();

                                if (jobs != null && jobs.Count > 0)
                                {
                                    foreach (PostulationJobNameDTO job in jobs)
                                    {
                                        if (job != null)
                                            jobNames.Add(job.JobName);
                                    }

                                    jobCount = jobNames.Count();
                                }
                            }

                            if (talentGroups != null && talentGroups.Count > 0)
                            {
                                talents = talentGroups.Where(candidateTalentGroupName => candidateTalentGroupName.CandidateId == candidate.CandidateId).ToList();

                                if (talents != null && talents.Count > 0)
                                {
                                    foreach (var talent in talents)
                                    {
                                        if (talent != null)
                                            talentNames.Add(talent.TalentGroupName);
                                    }

                                    talentCount = talentNames.Count();
                                }
                            }

                            string CreationDateCandidate = "";
                            string CreationDateCandidatePopUp = "";
                            string CreationDateEnglishCandidate = "";
                            string CreationDateCandidatePopUpEnglish = "";

                            try
                            {
                                CreationDateCandidate = _basicInformationService.GetCreationDateFromString(candidate.CreationDate);
                                CreationDateCandidatePopUp = _basicInformationService.GetCreationDatePopUpByDate(candidate.CreationDate);
                                CreationDateEnglishCandidate = _basicInformationService.GetCreationDateFromStringEnglish(candidate.CreationDate);
                                CreationDateCandidatePopUpEnglish = _basicInformationService.GetCreationDatePopUpByDateEnglish(candidate.CreationDate);
                            }
                            catch (Exception ex)
                            {

                            }

                            if (candidate.BasicInformation != null)
                            {
                                if (!string.IsNullOrEmpty(candidate.BasicInformation.Photo) && candidate.BasicInformation.Photo != null)
                                    photo = candidate.BasicInformation.Photo;
                                else
                                    init = _basicInformationService.Initials(candidate.BasicInformation.Name, candidate.BasicInformation.Surname);

                                name = _basicInformationService.Name(candidate.BasicInformation.Name, candidate.BasicInformation.Surname);
                            }
                            if (candidate.BasicInformation == null && !string.IsNullOrEmpty(candidate.Email) && candidate.Email != null)
                            {
                                name = candidate.Email;
                                var sub = name.Substring(0, 2);
                                init = sub.ToUpper();
                            }

                            candidateSearchDTO candidateSearchDTO = new candidateSearchDTO()
                            {
                                CandidateId = candidate.CandidateId,
                                Photo = photo,
                                Initials = init,
                                Name = name,
                                CreationDateString = candidate.CreationDate,
                                CreationDate = CreationDateCandidate,
                                CreationDateEnglish = CreationDateEnglishCandidate,
                                CreationDatePopUp = CreationDateCandidatePopUp,
                                CreationDatePopUpEnglish = CreationDateCandidatePopUpEnglish,
                                CreationDateNotFormat = candidate.CreationDateNoText,
                                Jobs = jobNames,
                                TotalJobs = jobCount,
                                TalentGroups = talentNames,
                                TotalTalentGroups = talentCount,
                                IsDeleteProccess = candidate.IsDeleteProccess,
                                Candidate_TechnicalAbilityList =
                                    _mapper.Map<List<Candidate_TechnicalAbility>, List<Candidate_TechnicalAbilityDTO>>(candidate.Candidate_TechnicalAbilityList.ToList()),
                                Candidate_LanguageList =
                                    _mapper.Map<List<Candidate_Language>, List<Candidate_LanguageDTO>>(candidate.Candidate_Language.ToList()),
                                StudyList =
                                    _mapper.Map<List<Study>, List<StudyDTO>>(candidate.StudyList.ToList()),
                                WorkExperienceList =
                                    _mapper.Map<List<WorkExperience>, List<WorkExperienceDTO>>(candidate.WorkExperienceList.ToList()),
                            };

                            if (jobs != null && jobs.Count > 0)
                            {
                                jobs.OrderByDescending(postulationJobName => postulationJobName.CreationDate).ToList();

                                candidateSearchDTO.ColourFlag = jobs[0].ColourFlag;

                                candidateSearchDTO.ColourFlagToltip = jobs[0].JobName;
                            }

                            if (candidateSearchDTO.ColourFlag == 0 && talents != null && talents.Count > 0)
                            {
                                talents.OrderByDescending(x => x.CreationDate).ToList();

                                candidateSearchDTO.ColourFlag = talents[0].ColourFlag;

                                candidateSearchDTO.ColourFlagToltip = talents[0].TalentGroupName;
                            }

                            candidateSearchDTO.IsPotential =
                            candidate.CandidateCompanies != null && candidate.CandidateCompanies.Where(cc => cc.CompanyUserId == companyUserId).FirstOrDefault() != null
                            ? candidate.CandidateCompanies.Where(cc => cc.CompanyUserId == companyUserId).FirstOrDefault().IsPotential
                            : false;

                            if (candidateSearchDTO != null)
                                candidateSectionListDTO.Add(candidateSearchDTO);
                        }
                    //);
                }

                /* Return */

                if (candidateSectionListDTO != null && candidateSectionListDTO.Count > 0)
                {
                    response.candidates = candidateSectionListDTO;

                    //if(!search.Ascending)
                    //    response.candidates = candidateSectionListDTO.OrderByDescending(candidate => candidate.CreationDateNotFormat).ToList();
                    //else
                    //    response.candidates = candidateSectionListDTO.OrderBy(candidate => candidate.CreationDateNotFormat).ToList();

                    response.total = totalCount;

                    return response;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /**/

        public async Task<candidateSearchTotalDTO> GetAllCandidateFromJobAndSearch(SearchByIdAndTextWithPaginationDTO search, int companyUserId, string token)
        {
            try
            {
                CultureInfo culture = CultureInfo.CurrentCulture;

                /* Get candidates ids from Job */

                CandidateIdAndPostulationAndTGNumbersResponseDTO candidatesFromJobResponse = await _companyRemoteRepository.GetAllCandidateIdsFromJobId(token.ToString(), search);

                List<CandidateIdAndPostulationAndTGNumbersDTO> candidatesFromJob = candidatesFromJobResponse.search;

                List<int> candidatesIds = new List<int>();

                if (candidatesFromJob != null && candidatesFromJob.Count > 0)
                {
                    foreach (CandidateIdAndPostulationAndTGNumbersDTO candidateFromJob in candidatesFromJob)
                    {
                        candidatesIds.Add(candidateFromJob.candidateId);
                    }
                }

                /* Get words filters, Postulations and TGs */

                MemberByToken memberResponse = await _companyRemoteRepository.GetMemberUserFromCandidate(token.ToString());

                List<Candidate> candidatesFilters = await _candidateRepository.GetCandidatesByFilterAndJobOrTalentGroupList(search.Text, companyUserId, candidatesIds);

                List<candidateSearchDTO> candidateSectionListDTO = new List<candidateSearchDTO>();

                List<PostulationJobNameInDTO> postulations = await _companyRemoteRepository.GetAllPostulationsWithNameAndColourFlag(token);
                List<CandidateTalentGroupNameInDTO> talentGroups = await _companyRemoteRepository.GetAllCandidateTalentWithNameAndColourFlag(token);
                List<TagListInDTO> tags = await _companyRemoteRepository.GetTagsByCompanyUser(companyUserId, token);
                List<SourceListInDTO> sources = await _companyRemoteRepository.GetSourcesByCompanyUser(companyUserId, token);

                candidateSearchTotalDTO response = new candidateSearchTotalDTO();

                /* Years experience */

                double experienceLowerLimit = 0;
                double experienceUpperLimit = 0;

                if (search.JobExperienceId != 0)
                {
                    switch (search.JobExperienceId)
                    {
                        case 1:
                            experienceLowerLimit = 0;
                            experienceUpperLimit = 0;
                            break;
                        case 2:
                            experienceLowerLimit = 1;
                            experienceUpperLimit = 3;
                            break;
                        case 3:
                            experienceLowerLimit = 3;
                            experienceUpperLimit = 5;
                            break;
                        case 4:
                            experienceLowerLimit = 5;
                            experienceUpperLimit = 7;
                            break;
                        case 5:
                            experienceLowerLimit = 7;
                            experienceUpperLimit = 9;
                            break;
                        case 6:
                            experienceLowerLimit = 9;
                            experienceUpperLimit = double.MaxValue;
                            break;
                        default:
                            break;
                    }
                }

                if (search != null && search.JobExperienceId != 0)
                {
                    List<Candidate> candidateSectionListExperience = new List<Candidate>();

                    if (candidatesFilters != null && candidatesFilters.Count > 0 && search != null && search.JobExperienceId > 0)
                    {
                        foreach (Candidate candidate in candidatesFilters)
                        {
                            double yearsExperience = 0;

                            CompanyDescription companyDescription = new CompanyDescription();

                            if (candidate.ExperienceCount != null && !string.IsNullOrEmpty(candidate.ExperienceCount.Years))
                            {
                                if (candidate.ExperienceCount != null && !string.IsNullOrEmpty(candidate.ExperienceCount.Years))
                                {
                                    if (culture != null && !string.IsNullOrEmpty(culture.Name) && culture.Name.Contains("es-"))
                                        double.TryParse(candidate.ExperienceCount.Years.Replace(".", ","), out yearsExperience);
                                    else
                                        double.TryParse(candidate.ExperienceCount.Years, out yearsExperience);
                                }

                                if (yearsExperience != 0 && yearsExperience >= experienceLowerLimit && yearsExperience <= experienceUpperLimit)
                                    candidateSectionListExperience.Add(candidate);
                            }
                            else if (candidate.CompanyDescriptionList != null && candidate.CompanyDescriptionList.Count > 0)
                            {
                                companyDescription = candidate.CompanyDescriptionList.Where(x => x.CompanyUserId == companyUserId).FirstOrDefault();

                                if (companyDescription != null && !string.IsNullOrEmpty(companyDescription.YearsExperience))
                                {
                                    if (culture != null && !string.IsNullOrEmpty(culture.Name) && culture.Name.Contains("es-"))
                                        double.TryParse(companyDescription.YearsExperience.Replace(".", ","), out yearsExperience);
                                    else
                                        double.TryParse(companyDescription.YearsExperience, out yearsExperience);
                                }

                                if (yearsExperience != 0 && yearsExperience >= experienceLowerLimit && yearsExperience <= experienceUpperLimit)
                                    candidateSectionListExperience.Add(candidate);

                                if (yearsExperience == 0 && search.JobExperienceId == 1 && companyDescription == null)
                                    candidateSectionListExperience.Add(candidate);

                                if (companyDescription == null)
                                    companyDescription = new CompanyDescription();
                            }

                            if (yearsExperience == 0 && search.JobExperienceId == 1 &&
                                (candidate.ExperienceCount == null || string.IsNullOrEmpty(candidate.ExperienceCount.Years)) &&
                                (string.IsNullOrEmpty(companyDescription.YearsExperience)))
                                candidateSectionListExperience.Add(candidate);
                        }

                        candidatesFilters = candidateSectionListExperience;
                    }
                }

                /* Currency */

                List<Candidate> candidateSectionListCurrencyExperience = new List<Candidate>();

                if (search != null && search.SalaryAspirations != null && search.SalaryAspirations.Count > 0)
                {
                    foreach (SalaryAspirationFromSearchDTO salaryAspiration in search.SalaryAspirations)
                    {
                        if (candidatesFilters != null && candidatesFilters.Count > 0
                            && int.Parse(salaryAspiration.CurrencyLowerValue.Replace(".", "").Replace(",", ""))
                            < int.Parse(salaryAspiration.CurrencyUpperValue.Replace(".", "").Replace(",", ""))
                            && int.Parse(salaryAspiration.CurrencyLowerValue.Replace(".", "").Replace(",", "")) >= 0)
                        {
                            foreach (Candidate candidate in candidatesFilters)
                            {
                                if (candidate != null && candidate.BasicInformation != null && !string.IsNullOrEmpty(candidate.BasicInformation.SalaryAspiration))
                                {
                                    int salary = 0;

                                    string salaryAspirationString = candidate.BasicInformation.SalaryAspiration.Replace(".", "").Replace(",", "");

                                    if (candidateSectionListCurrencyExperience.Any(x => x.CandidateId == candidate.CandidateId))
                                        continue;

                                    if (int.TryParse(salaryAspirationString, out salary)) { }

                                    if (int.Parse(salaryAspiration.CurrencyLowerValue.Replace(".", "").Replace(",", "")) == 0
                                        && salary == 0 && salaryAspiration.CurrencyId == candidate.BasicInformation.CurrencyId)
                                    {
                                        candidateSectionListCurrencyExperience.Add(candidate);
                                    }
                                    else if (int.Parse(salaryAspiration.CurrencyLowerValue.Replace(".", "").Replace(",", "")) <= salary
                                        && int.Parse(salaryAspiration.CurrencyUpperValue.Replace(".", "").Replace(",", "")) >= salary
                                        && salaryAspiration.CurrencyId == candidate.BasicInformation.CurrencyId)
                                    {
                                        candidateSectionListCurrencyExperience.Add(candidate);
                                    }
                                }
                                else if (candidate != null && candidate.CandidateCompanies != null)
                                {
                                    CandidateCompany candidateCompany = candidate.CandidateCompanies.Where(x => x.CompanyUserId == companyUserId).FirstOrDefault();

                                    if (candidateCompany != null && !string.IsNullOrEmpty(candidateCompany.SalaryAspiration))
                                    {
                                        int salary = 0;

                                        string salaryAspirationString = candidateCompany.SalaryAspiration.Replace(".", "").Replace(",", "");

                                        if (candidateSectionListCurrencyExperience.Any(x => x.CandidateId == candidate.CandidateId))
                                            continue;

                                        if (int.TryParse(salaryAspirationString, out salary)) { }

                                        if (int.Parse(salaryAspiration.CurrencyLowerValue.Replace(".", "").Replace(",", "")) == 0
                                            && salary == 0
                                            && salaryAspiration.CurrencyId == candidateCompany.CurrencyId)
                                        {
                                            candidateSectionListCurrencyExperience.Add(candidate);
                                        }
                                        else if (int.Parse(salaryAspiration.CurrencyLowerValue.Replace(".", "").Replace(",", "")) <= salary
                                            && int.Parse(salaryAspiration.CurrencyUpperValue.Replace(".", "").Replace(",", "")) >= salary
                                            && salaryAspiration.CurrencyId == candidateCompany.CurrencyId)
                                        {
                                            candidateSectionListCurrencyExperience.Add(candidate);
                                        }
                                    }
                                }
                            }
                        }
                    }

                    candidatesFilters = candidateSectionListCurrencyExperience;
                }

                /* Countries list */

                //List<Candidate> candidateSectionListCountriesDTO = new List<Candidate>();

                //if (search != null && search.Countries != null && search.Countries.Count > 0)
                //{
                //    foreach (CountriesFromSearchDTO country in search.Countries)
                //    {
                //        if (candidatesFilters != null && candidatesFilters.Count > 0 && country.CountryId != 0)
                //        {
                //            foreach (Candidate candidate in candidatesFilters)
                //            {
                //                if (candidate != null && candidate.BasicInformation != null && !string.IsNullOrEmpty(candidate.BasicInformation.Country))
                //                {
                //                    int countryId = 0;

                //                    string countryIdString = candidate.BasicInformation.Country.Replace(".", "").Replace(",", "");

                //                    if (candidateSectionListCountriesDTO.Any(x => x.CandidateId == candidate.CandidateId))
                //                        continue;

                //                    if (int.TryParse(countryIdString, out countryId)) { }

                //                    if (countryId == country.CountryId)
                //                    {
                //                        int stateId = 0;

                //                        string stateIdString = candidate.BasicInformation.State.Replace(".", "").Replace(",", "");

                //                        if (int.TryParse(stateIdString, out stateId)) { }

                //                        if (stateId != 0 && stateId == country.StateId)
                //                        {
                //                            int cityId = 0;

                //                            string cityIdString = candidate.BasicInformation.City.Replace(".", "").Replace(",", "");

                //                            if (int.TryParse(cityIdString, out cityId)) { }

                //                            if (cityId != 0 && cityId == country.CityId)
                //                            {
                //                                candidateSectionListCountriesDTO.Add(candidate);
                //                            }
                //                            else if (country.CityId == 0)
                //                            {
                //                                candidateSectionListCountriesDTO.Add(candidate);
                //                            }
                //                        }
                //                        else if (country.StateId == 0)
                //                        {
                //                            candidateSectionListCountriesDTO.Add(candidate);
                //                        }
                //                    }
                //                }
                //                else if (candidate != null && candidate.CandidateCompanies != null)
                //                {
                //                    CandidateCompany candidateCompany = candidate.CandidateCompanies.Where(x => x.CompanyUserId == companyUserId).FirstOrDefault();

                //                    if (candidate != null && candidateCompany != null && !string.IsNullOrEmpty(candidateCompany.Country))
                //                    {
                //                        int countryId = 0;

                //                        string countryIdString = candidateCompany.Country.Replace(".", "").Replace(",", "");

                //                        if (candidateSectionListCountriesDTO.Any(x => x.CandidateId == candidate.CandidateId))
                //                            continue;

                //                        if (int.TryParse(countryIdString, out countryId)) { }

                //                        if (countryId == country.CountryId)
                //                        {
                //                            int stateId = 0;

                //                            string stateIdString = candidateCompany.State.Replace(".", "").Replace(",", "");

                //                            if (int.TryParse(stateIdString, out stateId)) { }

                //                            if (stateId != 0 && stateId == country.StateId)
                //                            {
                //                                int cityId = 0;

                //                                string cityIdString = candidateCompany.City.Replace(".", "").Replace(",", "");

                //                                if (int.TryParse(cityIdString, out cityId)) { }

                //                                if (cityId != 0 && cityId == country.CityId)
                //                                {
                //                                    candidateSectionListCountriesDTO.Add(candidate);
                //                                }
                //                                else if (country.CityId == 0)
                //                                {
                //                                    candidateSectionListCountriesDTO.Add(candidate);
                //                                }
                //                            }
                //                            else if (country.StateId == 0)
                //                            {
                //                                candidateSectionListCountriesDTO.Add(candidate);
                //                            }
                //                        }
                //                    }
                //                }
                //            }
                //        }
                //    }

                //    candidatesFilters = candidateSectionListCountriesDTO;
                //}

                /* Jobs, TGs and format */

                if (candidatesFilters != null && candidatesFilters.Count > 0)
                {
                    foreach (Candidate candidate in candidatesFilters)
                    {
                        List<PostulationJobNameInDTO> jobs = new List<PostulationJobNameInDTO>();
                        List<CandidateTalentGroupNameInDTO> talents = new List<CandidateTalentGroupNameInDTO>();

                        var photo = "";
                        var init = "";
                        var name = "";

                        List<string> jobNames = new List<string>();
                        List<string> talentNames = new List<string>();

                        var jobCount = 0;
                        var talentCount = 0;

                        if (postulations != null && postulations.Count > 0)
                        {
                            jobs = postulations.Where(x => x.candidateId == candidate.CandidateId).ToList();

                            if (jobs != null && jobs.Count > 0)
                            {
                                foreach (var job in jobs)
                                {
                                    if (job != null)
                                        jobNames.Add(job.jobName);
                                }

                                jobCount = jobNames.Count();
                            }
                        }

                        if (talentGroups != null && talentGroups.Count > 0)
                        {
                            talents = talentGroups.Where(x => x.candidateId == candidate.CandidateId).ToList();
                            if (talents != null && talents.Count > 0)
                            {
                                foreach (var talent in talents)
                                {
                                    if (talent != null)
                                        talentNames.Add(talent.talentGroupName);
                                }

                                talentCount = talentNames.Count();
                            }
                        }

                        string CreationDateCandidate = "";
                        string CreationDateCandidatePopUp = "";
                        string CreationDateEnglishCandidate = "";
                        string CreationDateCandidatePopUpEnglish = "";

                        try
                        {
                            CreationDateCandidate = _basicInformationService.GetCreationDateFromString(candidate.CreationDate);
                            CreationDateCandidatePopUp = _basicInformationService.GetCreationDatePopUpByDate(candidate.CreationDate);
                            CreationDateEnglishCandidate = _basicInformationService.GetCreationDateFromStringEnglish(candidate.CreationDate);
                            CreationDateCandidatePopUpEnglish = _basicInformationService.GetCreationDatePopUpByDateEnglish(candidate.CreationDate);
                        }
                        catch (Exception ex)
                        {

                        }

                        if (candidate.BasicInformation != null)
                        {
                            if (!String.IsNullOrEmpty(candidate.BasicInformation.Photo) && candidate.BasicInformation.Photo != null)
                                photo = candidate.BasicInformation.Photo;
                            else
                                init = _basicInformationService.Initials(candidate.BasicInformation.Name, candidate.BasicInformation.Surname);

                            name = _basicInformationService.Name(candidate.BasicInformation.Name, candidate.BasicInformation.Surname);
                        }
                        if (candidate.BasicInformation == null && !string.IsNullOrEmpty(candidate.Email) && candidate.Email != null)
                        {
                            name = candidate.Email;
                            var sub = name.Substring(0, 2);
                            init = sub.ToUpper();
                        }

                        candidateSearchDTO candidateSearchDTO = new candidateSearchDTO()
                        {
                            CandidateId = candidate.CandidateId,
                            Photo = photo,
                            Initials = init,
                            Name = name,
                            CreationDateString = candidate.CreationDate,
                            CreationDate = CreationDateCandidate,
                            CreationDateEnglish = CreationDateEnglishCandidate,
                            CreationDatePopUp = CreationDateCandidatePopUp,
                            CreationDatePopUpEnglish = CreationDateCandidatePopUpEnglish,
                            Jobs = jobNames,
                            TotalJobs = jobCount,
                            TalentGroups = talentNames,
                            TotalTalentGroups = talentCount,
                            IsDeleteProccess = candidate.IsDeleteProccess,
                            Candidate_TechnicalAbilityList =
                                _mapper.Map<List<Candidate_TechnicalAbility>, List<Candidate_TechnicalAbilityDTO>>(candidate.Candidate_TechnicalAbilityList.ToList()),
                            Candidate_LanguageList =
                                _mapper.Map<List<Candidate_Language>, List<Candidate_LanguageDTO>>(candidate.Candidate_Language.ToList()),
                            StudyList =
                                _mapper.Map<List<Study>, List<StudyDTO>>(candidate.StudyList.ToList()),
                            WorkExperienceList =
                                _mapper.Map<List<WorkExperience>, List<WorkExperienceDTO>>(candidate.WorkExperienceList.ToList()),
                        };

                        if (jobs != null && jobs.Count > 0)
                        {
                            jobs.OrderByDescending(x => x.creationDate).ToList();

                            candidateSearchDTO.ColourFlag = jobs[0].colourFlag;

                            candidateSearchDTO.ColourFlagToltip = jobs[0].jobName;
                        }

                        if (candidateSearchDTO.ColourFlag == 0 && talents != null && talents.Count > 0)
                        {
                            talents.OrderByDescending(x => x.creationDate).ToList();

                            candidateSearchDTO.ColourFlag = talents[0].colourFlag;

                            candidateSearchDTO.ColourFlagToltip = talents[0].talentGroupName;
                        }

                        if (candidateSearchDTO != null)
                            candidateSectionListDTO.Add(candidateSearchDTO);
                    }
                }

                /* Technology */

                List<candidateSearchDTO> candidateSectionListTechnologyDTO = new List<candidateSearchDTO>();

                if (search.TechnicalAbilities != null && search.TechnicalAbilities.Count > 0)
                {
                    if (candidateSectionListDTO != null && candidateSectionListDTO.Count > 0)
                    {
                        foreach (candidateSearchDTO candidate in candidateSectionListDTO)
                        {
                            int technicalAbilitiesCount = 0;

                            if (candidateSectionListTechnologyDTO.Any(x => x.CandidateId == candidate.CandidateId))
                                continue;

                            foreach (TechnicalAbilitiesFromSearch technicalAbility in search.TechnicalAbilities)
                            {
                                if (candidate.Candidate_TechnicalAbilityList.Any(x => x.TechnicalAbilityTechnologyId == technicalAbility.TechnicalAbilityTechnologyId &&
                                x.TechnicalAbilityLevelId == technicalAbility.TechnicalAbilityLevelId))
                                    technicalAbilitiesCount++;
                            }

                            if (technicalAbilitiesCount == search.TechnicalAbilities.Count)
                                candidateSectionListTechnologyDTO.Add(candidate);
                        }
                    }

                    candidateSectionListDTO = candidateSectionListTechnologyDTO;
                }

                /* Languages */

                List<candidateSearchDTO> candidateSectionListLanguageDTO = new List<candidateSearchDTO>();

                if (search.Languages != null && search.Languages.Count > 0)
                {
                    if (candidateSectionListDTO != null && candidateSectionListDTO.Count > 0)
                    {
                        foreach (candidateSearchDTO candidate in candidateSectionListDTO)
                        {
                            int langaugesCount = 0;

                            if (candidateSectionListLanguageDTO.Any(x => x.CandidateId == candidate.CandidateId))
                                continue;

                            foreach (LanguagesFromSearch language in search.Languages)
                            {
                                if (candidate.Candidate_LanguageList.Any(x => x.LanguageId == language.LanguageId && x.LanguageLevelId == language.LanguageLevelId))
                                    langaugesCount++;
                            }

                            if (langaugesCount == search.Languages.Count)
                                candidateSectionListLanguageDTO.Add(candidate);
                        }
                    }

                    candidateSectionListDTO = candidateSectionListLanguageDTO;
                }

                /* Academic filter */

                List<candidateSearchDTO> candidateSectionListStudyDTO = new List<candidateSearchDTO>();

                if (search.JobProfessionId != 0 && candidateSectionListDTO != null && candidateSectionListDTO.Count > 0)
                {
                    foreach (candidateSearchDTO candidate in candidateSectionListDTO)
                    {
                        if (candidate != null && candidateSectionListStudyDTO.Any(x => x.CandidateId == candidate.CandidateId))
                            continue;

                        if (candidate != null && candidate.StudyList != null && candidate.StudyList.Count > 0 && candidate.StudyList.Any(x => x.JobProfessionId == search.JobProfessionId))
                            candidateSectionListStudyDTO.Add(candidate);
                    }

                    candidateSectionListDTO = candidateSectionListStudyDTO;
                }

                /* Companies filter */

                List<candidateSearchDTO> candidateSectionListCompanyDTO = new List<candidateSearchDTO>();

                if (search.Companies != null && search.Companies.Count > 0)
                {
                    foreach (string company in search.Companies)
                    {
                        if (candidateSectionListDTO != null && candidateSectionListDTO.Count > 0)
                        {
                            foreach (candidateSearchDTO candidate in candidateSectionListDTO)
                            {
                                if (candidate != null && candidateSectionListCompanyDTO.Any(x => x.CandidateId == candidate.CandidateId))
                                    continue;

                                if (candidate != null && candidate.WorkExperienceList != null && candidate.WorkExperienceList.Count > 0 && candidate.WorkExperienceList
                                    .Any(x => x.Company.ToLower().Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ü", "u")
                                    == company.ToLower().Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ü", "u")))
                                    candidateSectionListCompanyDTO.Add(candidate);
                            }
                        }
                    }

                    candidateSectionListDTO = candidateSectionListCompanyDTO;
                }

                /* Tags */

                List<TagListInDTO> tagsFilter = new List<TagListInDTO>();
                List<candidateSearchDTO> candidateSectionListTagsDTO = new List<candidateSearchDTO>();

                if (search != null && search.Tags != null && search.Tags.Count > 0 && tags != null && tags.Count > 0)
                {
                    foreach (TagListInDTO tag in tags)
                    {
                        if (search.Tags.Any(x => x == tag.tagId))
                            tagsFilter.Add(tag);
                    }
                }

                if (tagsFilter != null && tagsFilter.Count > 0)
                {
                    if (candidateSectionListDTO != null && candidateSectionListDTO.Count > 0)
                    {
                        foreach (candidateSearchDTO candidate in candidateSectionListDTO)
                        {
                            int tagsCount = 0;

                            if (candidateSectionListTagsDTO.Any(x => x.CandidateId == candidate.CandidateId))
                                continue;

                            foreach (TagListInDTO tag in tagsFilter)
                            {
                                if (tag.candidate_Tags.Any(x => x.candidateId == candidate.CandidateId))
                                    tagsCount++;
                            }

                            if (tagsCount == tagsFilter.Count)
                                candidateSectionListTagsDTO.Add(candidate);
                        }
                    }

                    candidateSectionListDTO = candidateSectionListTagsDTO;
                }

                /* Sources */

                List<SourceListInDTO> sourcesFilter = new List<SourceListInDTO>();
                List<candidateSearchDTO> candidateSectionListSourcesDTO = new List<candidateSearchDTO>();

                if (search != null && search.Sources != null && search.Sources.Count > 0 && sources != null && sources.Count > 0)
                {
                    foreach (SourceListInDTO source in sources)
                    {
                        if (search.Sources.Any(x => x == source.sourceId))
                            sourcesFilter.Add(source);
                    }
                }

                if (sourcesFilter != null && sourcesFilter.Count > 0)
                {
                    if (candidateSectionListDTO != null && candidateSectionListDTO.Count > 0)
                    {
                        foreach (candidateSearchDTO candidate in candidateSectionListDTO)
                        {
                            int sourcesCount = 0;

                            if (candidateSectionListSourcesDTO.Any(x => x.CandidateId == candidate.CandidateId))
                                continue;

                            foreach (SourceListInDTO source in sourcesFilter)
                            {
                                if (source.candidate_Sources.Any(x => x.candidateId == candidate.CandidateId))
                                    sourcesCount++;
                            }

                            if (sourcesCount == sourcesFilter.Count)
                                candidateSectionListSourcesDTO.Add(candidate);
                        }
                    }

                    candidateSectionListDTO = candidateSectionListSourcesDTO;
                }

                /* Order and previous - next */

                if (candidateSectionListDTO != null && candidateSectionListDTO.Count > 0)
                {
                    List<candidateSearchDTO> sorted = new List<candidateSearchDTO>();


                    string[] validformats = new[] { "MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss, fff",
                                            "MM/dd/yyyy hh:mm tt", "M/dd/yyyy h:mm:ss tt", "MM/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm:ss tt",
                                            "dd/MM/yyyy hh:mm:ss tt","dd/MM/yyyy hh:mm:ss","dd/MM/yyyy h:mm:ss","dd/MM/yyyy h:mm:ss ff",
                                            "dd/MM/yyyy h:mm:ss tt","dd/MM/yyyy hh:mm:ss ff","M/dd/yyyy hh:mm:ss tt"};

                    foreach (candidateSearchDTO candidate in candidateSectionListDTO)
                    {
                        DateTime auxDate = DateTime.Now;

                        if (DateTime.TryParseExact(candidate.CreationDateString, validformats, CultureInfo.InvariantCulture, DateTimeStyles.None, out auxDate)) { }

                        candidate.CreationDateNotFormat = auxDate;
                    }

                    if (!search.Ascending)
                        sorted = candidateSectionListDTO.OrderByDescending(x => x.CreationDateNotFormat).ToList();
                    else
                        sorted = candidateSectionListDTO.OrderBy(x => x.CreationDateNotFormat).ToList();

                    List<candidateSearchDTO> pageSources = sorted.Skip((search.Page) * search.PageSize).Take(search.PageSize).ToList();

                    for (int i = 0; i < pageSources.Count; i++)
                    {
                        if (i == 0)
                            pageSources[i].Previous = 0;
                        else
                            pageSources[i].Previous = pageSources[i - 1].CandidateId;

                        if (i == pageSources.Count - 1)
                            pageSources[i].Next = 0;
                        else
                            pageSources[i].Next = pageSources[i + 1].CandidateId;
                    }

                    response.candidates = pageSources;
                    response.total = candidateSectionListDTO.Count;

                    return response;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<List<CandidateReportDTO>> GetAllCandidatesWithDate(string leftDate, string rightDate, string emailMemberUser, int portalId, int companyUserId, int languagePlatform)
        {
            try
            {
                DateTime LeftDate = DateTime.ParseExact(leftDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                DateTime RightDate = DateTime.ParseExact(rightDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                List<Candidate> candidatesReport = new List<Candidate>();

                bool isMaster = false;

                int exsisUserId = 0;

                if (_s3Settings.AWSS3.BucketName == "recruitment-bucket-prod")
                    exsisUserId = 3;
                else
                    exsisUserId = 4;

                if (portalId == 1)
                {
                    candidatesReport = _candidateRepository.GetAllCandidateMasterWithDate(LeftDate, RightDate.AddDays(1));
                    isMaster = true;
                }
                else if (companyUserId == exsisUserId)
                {
                    /* Cambio realizado por petición explícita de Mayra Arévalo e Isabella Mogollón - Febrero 11 de 2025 */

                    //candidatesReport = _candidateRepository.GetAllCandidateWithDate(LeftDate, RightDate.AddDays(1));
                    candidatesReport = _candidateRepository.GetAllCandidateWithDateAndCompanyUserId(LeftDate, RightDate.AddDays(1), companyUserId);
                }
                else
                {
                    candidatesReport = _candidateRepository.GetAllCandidateWithDateAndCompanyUserId(LeftDate, RightDate.AddDays(1), companyUserId);
                }

                List<CandidateReportDTO> Report = new List<CandidateReportDTO>();

                /* Countries */

                List<APICountryDTO> countriesList = new List<APICountryDTO>();

                using (StreamReader r = new StreamReader("CountriesStatesCities.json"))
                {
                    string jsonCountries = r.ReadToEnd();

                    countriesList = JsonConvert.DeserializeObject<List<APICountryDTO>>(jsonCountries);
                }

                //Parallel.ForEach(candidatesReport, async candidate =>
                foreach (Candidate candidate in candidatesReport)
                {
                    string name = string.Empty;
                    string emails = string.Empty;
                    string abilities = string.Empty;
                    string languages = string.Empty;
                    string technicalAbilities = string.Empty;
                    string workExperiences = string.Empty;
                    string countries = string.Empty;
                    string salaries = string.Empty;
                    string genders = string.Empty;

                    APICountryDTO apiCountry = new APICountryDTO();
                    APIStateDTO apiState = new APIStateDTO();
                    APICityDTO apiCity = new APICityDTO();

                    /* Name & Emails */

                    if (candidate.BasicInformation != null)
                    {
                        name = candidate.BasicInformation.Name + " " + candidate.BasicInformation.Surname;

                        emails = emails + candidate.Email + ", ";

                        if (candidate.BasicInformation.Emails != null && !isMaster)
                        {
                            foreach (Email mail in candidate.BasicInformation.Emails)
                            {
                                emails = emails + mail.Mail + ", ";
                            }
                        }
                    }
                    else
                    {
                        name = candidate.Email;
                        emails = candidate.Email;
                    }

                    /* Technical abilities */

                    if (candidate.Candidate_TechnicalAbilityList != null && candidate.Candidate_TechnicalAbilityList.Count > 0)
                    {
                        foreach (Candidate_TechnicalAbility ability in candidate.Candidate_TechnicalAbilityList)
                        {
                            if (ability.TechnicalAbilityTechnologyId == 54)
                            {
                                if (languagePlatform == 1)
                                    abilities = abilities + ability.Other + ":" + ability.TechnicalAbilityLevel.Level + ", ";
                                else
                                    abilities = abilities + ability.Other + ":" + ability.TechnicalAbilityLevel.LevelEnglish + ", ";
                            }
                            else
                            {
                                if (languagePlatform == 1)
                                    abilities = abilities + ability.Discipline + ":" + ability.TechnicalAbilityLevel.Level + ", ";
                                else
                                    abilities = abilities + ability.Discipline + ":" + ability.TechnicalAbilityLevel.LevelEnglish + ", ";
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(abilities))
                        abilities = languagePlatform == 1 ? "Sin asociación" : "No association";

                    /* Languages */

                    if (candidate.Candidate_Language != null && candidate.Candidate_Language.Count > 0)
                    {
                        foreach (Candidate_Language language in candidate.Candidate_Language)
                        {
                            if (languagePlatform == 1)
                                languages = languages + language.Language.LanguageName + ":" + language.LanguageLevel.LanguageLevelName + ", ";
                            else
                                languages = languages + language.Language.LanguageNameEnglish + ":" + language.LanguageLevel.LanguageLevelNameEnglish + ", ";
                        }
                    }

                    if (candidate.Candidate_LanguageOther != null && candidate.Candidate_LanguageOther.Count > 0)
                    {
                        foreach (Candidate_LanguageOther language in candidate.Candidate_LanguageOther)
                        {
                            if (languagePlatform == 1)
                                languages = languages + language.LanguageOther.LanguageOtherName + ":" + language.LanguageLevel.LanguageLevelName + ", ";
                            else
                                languages = languages + language.LanguageOther.LanguageOtherName + ":" + language.LanguageLevel.LanguageLevelNameEnglish + ", ";
                        }
                    }

                    if (string.IsNullOrEmpty(languages))
                        languages = languagePlatform == 1 ? "Sin asociación" : "No association";

                    /* Work experience */

                    if (candidate.BasicInformation != null)
                    {
                        if (languagePlatform == 1)
                            workExperiences = candidate.BasicInformation.HaveWorkExperience == 0 ? "Sí" : "No";
                        else
                            workExperiences = candidate.BasicInformation.HaveWorkExperience == 0 ? "Yes" : "No";

                        if (!string.IsNullOrEmpty(workExperiences))
                            workExperiences += ", ";

                        if (languagePlatform == 1)
                            workExperiences = candidate.BasicInformation.HaveWorkExperienceFromCompany == 0 ? "Sí" : "No";
                        else
                            workExperiences = candidate.BasicInformation.HaveWorkExperienceFromCompany == 0 ? "Yes" : "No";
                    }

                    if (string.IsNullOrEmpty(workExperiences))
                        workExperiences = languagePlatform == 1 ? "Sin asociación" : "No association";

                    /* Countries */

                    if (candidate.BasicInformation != null)
                    {
                        if (countriesList != null && !string.IsNullOrEmpty(candidate.BasicInformation.Country))
                        {
                            apiCountry = countriesList.Where(x => x.Id == candidate.BasicInformation.Country).FirstOrDefault();

                            if (apiCountry != null && !string.IsNullOrEmpty(apiCountry.Name))
                                countries += apiCountry.Name;
                        }

                        if (apiCountry != null && apiCountry.States != null && apiCountry.States.Count > 0)
                        {
                            apiState = apiCountry.States.Where(x => x.Id == candidate.BasicInformation.State).FirstOrDefault();

                            if (apiState != null && !string.IsNullOrEmpty(apiState.Name))
                                countries += " - " + apiState.Name;
                        }

                        if (apiState != null && apiState.Cities != null && apiState.Cities.Count > 0)
                        {
                            apiCity = apiState.Cities.Where(x => x.Id == candidate.BasicInformation.City).FirstOrDefault();

                            if (apiCity != null && !string.IsNullOrEmpty(apiCity.Name))
                                countries += " - " + apiCity.Name;
                        }
                    }

                    if (candidate.CandidateCompanies != null && candidate.CandidateCompanies.Count > 0)
                    {
                        foreach (CandidateCompany candidateCompany in candidate.CandidateCompanies)
                        {
                            if (candidateCompany != null && candidateCompany.CompanyUserId == companyUserId)
                            {
                                if (!string.IsNullOrEmpty(countries))
                                    countries += ", ";

                                if (countriesList != null && !string.IsNullOrEmpty(candidateCompany.Country))
                                {
                                    apiCountry = countriesList.Where(x => x.Id == candidateCompany.Country).FirstOrDefault();

                                    if (apiCountry != null && !string.IsNullOrEmpty(apiCountry.Name))
                                        countries += apiCountry.Name;
                                }

                                if (apiCountry != null && apiCountry.States != null && !string.IsNullOrEmpty(candidateCompany.State))
                                {
                                    apiState = apiCountry.States.Where(x => x.Id == candidateCompany.State).FirstOrDefault();

                                    if (apiState != null && !string.IsNullOrEmpty(apiState.Name))
                                        countries += " - " + apiState.Name;
                                }

                                if (apiState != null && apiState.Cities != null && !string.IsNullOrEmpty(candidateCompany.City))
                                {
                                    apiCity = apiState.Cities.Where(x => x.Id == candidateCompany.City).FirstOrDefault();

                                    if (apiCity != null && !string.IsNullOrEmpty(apiCity.Name))
                                        countries += " - " + apiCity.Name;
                                }

                                break;
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(countries))
                        countries = languagePlatform == 1 ? "Sin asociación" : "No association";

                    /* Salary aspiration */

                    if (candidate.BasicInformation != null && candidate.BasicInformation.CurrencyId != 0 && !string.IsNullOrEmpty(candidate.BasicInformation.SalaryAspiration))
                    {
                        Currency currency = await _currencyRepository.GetById(candidate.BasicInformation.CurrencyId);

                        if (languagePlatform == 1)
                            salaries += currency.ShortName + " " + candidate.BasicInformation.SalaryAspiration;
                        else
                            salaries += currency.ShortNameEnglish + " " + candidate.BasicInformation.SalaryAspiration;
                    }

                    if (!string.IsNullOrEmpty(salaries))
                        salaries += ", ";

                    if (candidate.CandidateCompanies != null && candidate.CandidateCompanies.Count > 0)
                    {
                        foreach (CandidateCompany candidateCompany in candidate.CandidateCompanies)
                        {
                            if (candidateCompany != null && candidateCompany.CompanyUserId == companyUserId && candidateCompany.CurrencyId != null)
                            {
                                Currency currency = await _currencyRepository.GetById((int)candidateCompany.CurrencyId);

                                if (currency != null)
                                {
                                    if (languagePlatform == 1)
                                        salaries += currency.ShortName + " " + candidateCompany.SalaryAspiration;
                                    else
                                        salaries += currency.ShortNameEnglish + " " + candidateCompany.SalaryAspiration;
                                }

                                break;
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(salaries))
                        salaries = languagePlatform == 1 ? "Sin asociación" : "No association";

                    /* Gender */

                    if (candidate.BasicInformation != null && candidate.BasicInformation.Gender != null)
                    {
                        if (candidate.BasicInformation.GenderId != 4 && !string.IsNullOrEmpty(candidate.BasicInformation.Gender.Name))
                        {
                            if (languagePlatform == 1)
                                genders += candidate.BasicInformation.Gender.Name;
                            else
                                genders += candidate.BasicInformation.Gender.NameEnglish;
                        }
                    }

                    if (candidate.CandidateCompanies != null && candidate.CandidateCompanies.Count > 0)
                    {
                        foreach (CandidateCompany candidateCompany in candidate.CandidateCompanies)
                        {
                            if (candidateCompany.CompanyUserId == companyUserId)
                            {
                                int genderId = candidateCompany.GenderId != null && (int)candidateCompany.GenderId != 4 ? (int)candidateCompany.GenderId : 0;

                                Gender gender = await _genderRepository.GetById(genderId);

                                if (gender != null && !string.IsNullOrEmpty(gender.Name))
                                {
                                    if (!string.IsNullOrEmpty(genders))
                                        genders += ", ";

                                    if (languagePlatform == 1)
                                        genders += gender.Name;
                                    else
                                        genders += gender.NameEnglish;
                                }

                                break;
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(genders))
                        genders = languagePlatform == 1 ? "Sin asociación" : "No association";

                    /**/

                    string creationInfo = string.Empty;
                    string portal = string.Empty;
                    string Member = string.Empty;

                    if (candidate.NameMemberUser != null)
                        Member = candidate.NameMemberUser + " " + candidate.SurnameMemberUser;


                    if (candidate.IsMigrated == 0)
                    {
                        creationInfo = languagePlatform == 1 ? "Agregado de portal" : "Added from portal";
                        Member = languagePlatform == 1 ? "Portal" : "Portal";
                        portal = languagePlatform == 1 ? "Si" : "Yes";

                        if (candidate.Source != "" && candidate.Source != null)
                        {
                            creationInfo = languagePlatform == 1 ? "Agregado de portal via " + candidate.Source : "Added from portal via " + candidate.Source;
                            portal = languagePlatform == 1 ? "Si" : "Yes";
                            Member = languagePlatform == 1 ? "Portal" : "Portal";
                        }
                    }
                    else if (candidate.IsMigrated == 1)
                    {
                        creationInfo = languagePlatform == 1 ? "Agregado manualmente via migración" : "Manually added via migration";
                        portal = languagePlatform == 1 ? "No" : "No";
                        Member = languagePlatform == 1 ? "Migración" : "Migration";
                    }
                    else if (candidate.IsMigrated == 3)
                    {
                        creationInfo = languagePlatform == 1 ? "Agregado por Bot Comercial" : "Added by Commercial Bot";
                        portal = languagePlatform == 1 ? "No" : "No";
                        Member = languagePlatform == 1 ? "Bot Comercial" : "Commercial Bot";
                    }
                    else if (candidate.IsMigrated == 4)
                    {
                        portal = languagePlatform == 1 ? "No" : "No";

                        creationInfo = languagePlatform == 1 ? "Agregado manualmente vía análisis" : "Manually added via analysis";
                    }
                    else
                    {
                        portal = languagePlatform == 1 ? "No" : "No";

                        creationInfo = languagePlatform == 1 ? "Agregado manualmente" : "Manually added";
                    }

                    if (candidate.IsMigrated != 0 && candidate.IsFromCompanyAndLogin)
                    {
                        creationInfo += languagePlatform == 1 ? "Registrado Portal" : "Registered portal";
                        portal = languagePlatform == 1 ? "Si" : "Yes";
                        Member = languagePlatform == 1 ? "Portal" : "Portal";
                    }

                    string[] validformats = new[] { "MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss, fff",
                                            "MM/dd/yyyy hh:mm tt", "M/dd/yyyy h:mm:ss tt", "MM/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm:ss tt",
                                            "dd/MM/yyyy h:mm:ss tt"};

                    CandidateReportDTO candidateReportDTO = new CandidateReportDTO
                    {
                        CandidateId = candidate.CandidateId,
                        Name = name,

                        CreationDate = DateTime.ParseExact(candidate.CreationDate, validformats, CultureInfo.InvariantCulture),

                        Emails = emails.TrimEnd(' ').TrimEnd(','),

                        HV = creationInfo,

                        Portal = portal,

                        NameMemberUser = Member,

                        TechnicalAbilities = abilities.TrimEnd(' ').TrimEnd(','),
                        WorkExperiences = workExperiences.TrimEnd(' ').TrimEnd(','),
                        Languages = languages.TrimEnd(' ').TrimEnd(','),
                        Countries = countries.TrimEnd(' ').TrimEnd(','),
                        Genders = genders.TrimEnd(' ').TrimEnd(','),
                        Salaries = salaries.TrimEnd(' ').TrimEnd(','),

                        Language = languagePlatform
                    };

                    Report.Add(candidateReportDTO);
                }
                //);

                return Report.OrderByDescending(x => x.CreationDate).ToList();
            }
            catch (Exception ex)
            {
                return new List<CandidateReportDTO>();
            }
        }

        public async Task<List<CandidateReportConfigurableDTO>> GetAllCandidatesWithDateAndFilter
        (
            string emailMemberUser,
            bool isLanguagesFilter, bool isFullLanguages, List<Candidate_LanguageDTO> languagesFilter,
            bool isTechnicalAbilitiesFilter, bool isFullTechnicalAbilities, List<Candidate_TechnicalAbilityDTO> technicalAbilitiesFilter,
            bool isLocationFilter, bool isFullLocations, string country, string state, string city,
            bool isSalaryAspirationFilter, bool isFullSalaryAspirations, List<SalaryAspirationFromSearchDTO> salaryAspirationFilter,
            int portalId, int companyUserId, int languagePlatform
        )
        {
            List<Candidate> candidatesReport = new List<Candidate>();

            bool isMaster = false;

            int exsisUserId = 0;

            if (_s3Settings.AWSS3.BucketName == "recruitment-bucket-prod")
                exsisUserId = 3;
            else
                exsisUserId = 4;

            if (portalId == 1)
            {
                candidatesReport = _candidateRepository.GetAllCandidateMasterWithDateAndFilter
                (
                    isLanguagesFilter, isFullLanguages, languagesFilter,
                    isTechnicalAbilitiesFilter, isFullTechnicalAbilities, technicalAbilitiesFilter,
                    isLocationFilter, isFullLocations, country, state, city,
                    isSalaryAspirationFilter, isFullSalaryAspirations, salaryAspirationFilter
                );

                isMaster = true;
            }
            else if (companyUserId == exsisUserId)
            {
                /* Cambio realizado por petición explícita de Mayra Arévalo e Isabella Mogollón - Febrero 11 de 2025 */

                //candidatesReport = _candidateRepository.GetAllCandidateWithDateAndFilter
                //(
                //    isLanguagesFilter, isFullLanguages, languagesFilter,
                //    isTechnicalAbilitiesFilter, isFullTechnicalAbilities, technicalAbilitiesFilter,
                //    isLocationFilter, isFullLocations, country, state, city,
                //    isSalaryAspirationFilter, isFullSalaryAspirations, salaryAspirationFilter
                //);

                candidatesReport = _candidateRepository.GetAllCandidateWithDateAndCompanyUserIdAndFilter
                (
                    companyUserId,
                    isLanguagesFilter, isFullLanguages, languagesFilter,
                    isTechnicalAbilitiesFilter, isFullTechnicalAbilities, technicalAbilitiesFilter,
                    isLocationFilter, isFullLocations, country, state, city,
                    isSalaryAspirationFilter, isFullSalaryAspirations, salaryAspirationFilter
                );
            }
            else
            {
                candidatesReport = _candidateRepository.GetAllCandidateWithDateAndCompanyUserIdAndFilter
                (
                    companyUserId,
                    isLanguagesFilter, isFullLanguages, languagesFilter,
                    isTechnicalAbilitiesFilter, isFullTechnicalAbilities, technicalAbilitiesFilter,
                    isLocationFilter, isFullLocations, country, state, city,
                    isSalaryAspirationFilter, isFullSalaryAspirations, salaryAspirationFilter
                );
            }

            List<CandidateReportConfigurableDTO> report = new List<CandidateReportConfigurableDTO>();

            /* Locations */

            List<APICountryDTO> countriesList = new List<APICountryDTO>();

            using (StreamReader r = new StreamReader("CountriesStatesCities.json"))
            {
                string jsonCountries = r.ReadToEnd();

                countriesList = JsonConvert.DeserializeObject<List<APICountryDTO>>(jsonCountries);
            }

            /* Currencies */

            List<Currency> currencies = await _currencyRepository.GetAll();

            foreach (Candidate candidate in candidatesReport)
            {
                APICountryDTO apiCountry = new APICountryDTO();
                APIStateDTO apiState = new APIStateDTO();
                APICityDTO apiCity = new APICityDTO();

                string name = string.Empty;
                string emails = string.Empty;
                string languages = string.Empty;
                string technicalAbilities = string.Empty;
                string locations = string.Empty;
                string salaryAspirations = string.Empty;

                /* Name & Emails */

                if (candidate.BasicInformation != null)
                {
                    name = candidate.BasicInformation.Name + " " + candidate.BasicInformation.Surname;

                    emails = emails + candidate.Email + ", ";

                    if (candidate.BasicInformation.Emails != null && !isMaster)
                    {
                        foreach (Email mail in candidate.BasicInformation.Emails)
                        {
                            emails = emails + mail.Mail + ", ";
                        }
                    }
                }
                else
                {
                    name = candidate.Email;
                    emails = candidate.Email;
                }

                /* Languages */

                if (isLanguagesFilter && candidate.Candidate_Language != null && candidate.Candidate_Language.Count > 0)
                {
                    foreach (Candidate_Language language in candidate.Candidate_Language)
                    {
                        if (languagePlatform == 1)
                            languages = languages + language.Language.LanguageName + ":" + language.LanguageLevel.LanguageLevelName + ", ";
                        else
                            languages = languages + language.Language.LanguageNameEnglish + ":" + language.LanguageLevel.LanguageLevelNameEnglish + ", ";
                    }
                }

                if (isLanguagesFilter && candidate.Candidate_LanguageOther != null && candidate.Candidate_LanguageOther.Count > 0)
                {
                    foreach (Candidate_LanguageOther language in candidate.Candidate_LanguageOther)
                    {
                        if (languagePlatform == 1)
                            languages = languages + language.LanguageOther.LanguageOtherName + ":" + language.LanguageLevel.LanguageLevelName + ", ";
                        else
                            languages = languages + language.LanguageOther.LanguageOtherName + ":" + language.LanguageLevel.LanguageLevelNameEnglish + ", ";
                    }
                }

                if (string.IsNullOrEmpty(languages))
                    languages = languagePlatform == 1 ? "Sin asociación" : "No association";

                /* Technical abilities */

                if (isTechnicalAbilitiesFilter && candidate.Candidate_TechnicalAbilityList != null && candidate.Candidate_TechnicalAbilityList.Count > 0)
                {
                    foreach (Candidate_TechnicalAbility ability in candidate.Candidate_TechnicalAbilityList)
                    {
                        if (ability.TechnicalAbilityTechnologyId == 54)
                        {
                            if (languagePlatform == 1)
                                technicalAbilities = technicalAbilities + ability.Other + ":" + ability.TechnicalAbilityLevel.Level + ", ";
                            else
                                technicalAbilities = technicalAbilities + ability.Other + ":" + ability.TechnicalAbilityLevel.LevelEnglish + ", ";
                        }
                        else
                        {
                            if (languagePlatform == 1)
                                technicalAbilities = technicalAbilities + ability.Discipline + ":" + ability.TechnicalAbilityLevel.Level + ", ";
                            else
                                technicalAbilities = technicalAbilities + ability.Discipline + ":" + ability.TechnicalAbilityLevel.LevelEnglish + ", ";
                        }
                    }
                }

                if (string.IsNullOrEmpty(technicalAbilities))
                    technicalAbilities = languagePlatform == 1 ? "Sin asociación" : "No association";

                /* Locations */

                if (isLocationFilter && candidate.BasicInformation != null)
                {
                    if (countriesList != null && !string.IsNullOrEmpty(candidate.BasicInformation.Country))
                    {
                        apiCountry = countriesList.Where(x => x.Id == candidate.BasicInformation.Country).FirstOrDefault();

                        if (apiCountry != null && !string.IsNullOrEmpty(apiCountry.Name))
                            locations += apiCountry.Name;
                    }

                    if (apiCountry != null && apiCountry.States != null && apiCountry.States.Count > 0)
                    {
                        apiState = apiCountry.States.Where(x => x.Id == candidate.BasicInformation.State).FirstOrDefault();

                        if (apiState != null && !string.IsNullOrEmpty(apiState.Name))
                            locations += " - " + apiState.Name;
                    }

                    if (apiState != null && apiState.Cities != null && apiState.Cities.Count > 0)
                    {
                        apiCity = apiState.Cities.Where(x => x.Id == candidate.BasicInformation.City).FirstOrDefault();

                        if (apiCity != null && !string.IsNullOrEmpty(apiCity.Name))
                            locations += " - " + apiCity.Name;
                    }
                }

                if (candidate.CandidateCompanies != null && candidate.CandidateCompanies.Count > 0)
                {
                    foreach (CandidateCompany candidateCompany in candidate.CandidateCompanies)
                    {
                        if (candidateCompany.CompanyUserId == companyUserId)
                        {
                            if (!string.IsNullOrEmpty(locations))
                                locations += ", ";

                            if (countriesList != null && !string.IsNullOrEmpty(candidateCompany.Country))
                            {
                                apiCountry = countriesList.Where(x => x.Id == candidateCompany.Country).FirstOrDefault();

                                if (apiCountry != null && !string.IsNullOrEmpty(apiCountry.Name))
                                    locations += apiCountry.Name;

                                apiState = new APIStateDTO();
                            }

                            if (apiCountry != null && apiCountry.States != null && !string.IsNullOrEmpty(candidateCompany.State))
                            {
                                apiState = apiCountry.States.Where(x => x.Id == candidateCompany.State).FirstOrDefault();

                                if (apiState != null && !string.IsNullOrEmpty(apiState.Name))
                                    locations += " - " + apiState.Name;

                                apiCountry = new APICountryDTO();
                            }

                            if (apiState != null && apiState.Cities != null && !string.IsNullOrEmpty(candidateCompany.City))
                            {
                                apiCity = apiState.Cities.Where(x => x.Id == candidateCompany.City).FirstOrDefault();

                                if (apiCity != null && !string.IsNullOrEmpty(apiCity.Name))
                                    locations += " - " + apiCity.Name;

                                apiCity = new APICityDTO();
                            }

                            break;
                        }
                    }
                }

                if (string.IsNullOrEmpty(locations))
                    locations = languagePlatform == 1 ? "Sin asociación" : "No association";

                /* Salary aspirations */

                if (isSalaryAspirationFilter && candidate.BasicInformation != null && !string.IsNullOrEmpty(candidate.BasicInformation.SalaryAspiration) &&
                    int.Parse(candidate.BasicInformation.SalaryAspiration.Replace(".", "").Replace(",", "")) > 0
                    && candidate.BasicInformation.Currency != null)
                {
                    if (languagePlatform == 1)
                        salaryAspirations = salaryAspirations + candidate.BasicInformation.Currency.ShortName + " " + candidate.BasicInformation.SalaryAspiration;
                    else
                        salaryAspirations = salaryAspirations + candidate.BasicInformation.Currency.ShortNameEnglish + " " + candidate.BasicInformation.SalaryAspiration;
                }

                if (candidate.CandidateCompanies != null && candidate.CandidateCompanies.Count > 0)
                {
                    foreach (CandidateCompany candidateCompany in candidate.CandidateCompanies)
                    {
                        if (candidateCompany != null && !string.IsNullOrEmpty(candidateCompany.SalaryAspiration) &&
                            int.Parse(candidateCompany.SalaryAspiration.Replace(".", "").Replace(",", "")) > 0 &&
                            candidateCompany.CurrencyId != null && (int)candidateCompany.CurrencyId > 0 && candidateCompany.CompanyUserId == companyUserId)
                        {
                            if (!string.IsNullOrEmpty(salaryAspirations))
                                salaryAspirations += ", ";

                            Currency currency = new Currency();
                            string currencyId = string.Empty;

                            if (candidateCompany.CurrencyId != null)
                                currency = currencies.Where(x => x.CurrencyId == candidateCompany.CurrencyId).FirstOrDefault();

                            if (currency != null)
                            {
                                if (languagePlatform == 1)
                                    currencyId = currency.ShortName;
                                else
                                    currencyId = currency.ShortNameEnglish;
                            }

                            salaryAspirations = salaryAspirations + currencyId + " " + candidateCompany.SalaryAspiration;
                        }
                    }
                }

                if (string.IsNullOrEmpty(salaryAspirations))
                    salaryAspirations = languagePlatform == 1 ? "Sin asociación" : "No association";

                /**/

                CandidateReportConfigurableDTO candidateReportDTO = new CandidateReportConfigurableDTO
                {
                    CandidateId = candidate.CandidateId,
                    Name = name,

                    Emails = emails.TrimEnd(' ').TrimEnd(','),

                    Languages = languages.TrimEnd(' ').TrimEnd(','),

                    TechnicalAbilities = technicalAbilities.TrimEnd(' ').TrimEnd(','),

                    Locations = locations.TrimEnd(' ').TrimEnd(','),

                    SalaryAspirations = salaryAspirations.TrimEnd(' ').TrimEnd(',')
                };

                report.Add(candidateReportDTO);
            }

            return report;
        }

        public async Task<Candidate> GetCandidateToRequest(RequestDTO request)
        {
            Candidate candidate = await _candidateRepository.GetCandidateToRequest(request.Mail);
            if (candidate != null)
                return candidate;
            else
                return null;
        }

        public async Task<countsHVDTO> getCountsByCandidateId(int candidateId, string token)
        {

            MemberByToken memberUserTemp = await _companyRemoteRepository.GetMemberUserFromCandidate(token);
            List<Mail> mails = await _mailRepository.GetAllMailByCandidateId(candidateId, memberUserTemp.companyUserId);
            int countMail = 0;
            if (mails != null && mails.Count > 0)
            {
                List<MailDTO> mailsDTO = _mapper.Map<List<Mail>, List<MailDTO>>(mails);
                countMail = mailsDTO.Count;
                List<RemoteMail> recoveredMails = await _remoteMailRepository.GetAllMails();
                foreach (MailDTO mail in mailsDTO)
                {
                    int answer = await _remoteMailRepository.GetAllAnswerFromMailOwnerId(mail.MessageId);
                    countMail = countMail + answer;
                }

            }

            //Contador de archivos
            Candidate candidate = await _candidateRepository.GetById(candidateId);

            int countFiles = 0;
            List<AttachedFile> attachedFiles = new List<AttachedFile>();
            List<CV> CVs = new List<CV>();
            List<Study> studyList = new List<Study>();
            if (candidate != null && candidate.IsAuthDocuments)
            {
                attachedFiles = await _attachedFileRepository.GetByCandidateIdAndCompanyId(candidateId, memberUserTemp.companyUserId);
                CVs = await _cVRepository.GetAllByCandidateId(candidateId);
                studyList = await _studyRepository.GetByCandidateId(candidateId);
            }
            else
            {
                attachedFiles = await _attachedFileRepository.GetByCandidateIdAndOnlyCompanyFiles(candidateId, memberUserTemp.companyUserId);
                CVs = await _cVRepository.GetByCandidateIdAndOnlyCompanyFiles(candidateId, memberUserTemp.companyUserId);
            }

            List<StudyCertificate> studyCertificates = new List<StudyCertificate>();
            if (studyList != null && studyList.Count > 0)
            {
                foreach (Study study in studyList)
                {
                    StudyCertificate certificate = await _studyCertificateRepository.GetByStudyId(study.StudyId);

                    if (certificate != null)
                        studyCertificates.Add(certificate);
                }
            }
            countFiles = attachedFiles.Count + CVs.Count + studyCertificates.Count;

            int countFilesHiring = 0;

            List<AttachedFileHiring> attachedFileHirings = new List<AttachedFileHiring>();
            List<CVHiring> cVHirings = new List<CVHiring>();
            if (candidate != null && candidate.IsAuthDocumentsHiring)
            {
                attachedFileHirings = await _attachedFileHiringRepository.GetByCandidateIdAndCompanyId(candidateId, memberUserTemp.companyUserId);
                cVHirings = await _cvHiringRepository.GetAllByCandidateIdAndCompanyUserId(candidateId, memberUserTemp.companyUserId);
            }
            else
            {
                attachedFileHirings = await _attachedFileHiringRepository.GetByCandidateIdAndOnlyCompanyId(candidateId, memberUserTemp.companyUserId);
                cVHirings = await _cvHiringRepository.GetAllByCandidateIdAndOnlyCompanyUserId(candidateId, memberUserTemp.companyUserId);
            }

            countFilesHiring = attachedFileHirings.Count + cVHirings.Count;

            countsHVDTO counts = new countsHVDTO()
            {
                countMails = countMail,
                countFiles = countFiles,
                countFilesHiring = countFilesHiring
            };
            return counts;
        }

        /* Methods for Overview Candidate Information */

        /* Main method. All info */
        public async Task<CandidateWithCompanyDTO> GetOverviewWithCompany
            (
                string token, 
                int candidateId, 
                int companyUserId, 
                string memberUserName, 
                string memberUserSurname, 
                MemberUserDTO memberUserDTO, 
                List<MemberUserDTO> memberUserList
            )
        {
            try
            {
                /* Get Basic Information */
                
                Candidate candidate = await _candidateRepository.GetCandidateOverviewWithCompany(candidateId, companyUserId);

                /* Mapping memberUser */

                MemberUser memberUser = _mapper.Map<MemberUserDTO, MemberUser>(memberUserDTO);

                /**/

                if (candidate != null)
                {
                    Parallel.Invoke
                    (
                        /* Mapping Candidate Basic Information Sublevels */
                        () => candidate.BasicInformation = BasicInformationSubLevelsByOverviewWithCompany(candidate, companyUserId),

                        /* Mapping Languages Sublevels */
                        () => candidate.Candidate_Language = LanguagesSubLevelsByOverviewWithCompany(candidate, companyUserId),

                        /* Mapping Soft Skills Sublevels */
                        () => candidate.Candidate_SoftSkillList = SoftSkillsSubLevelsByOverviewWithCompany(candidate, companyUserId),

                        /* Mapping Technical Abilities Sublevels */
                        () => candidate.Candidate_TechnicalAbilityList = TechnicalAbilitiesSubLevelsByOverviewWithCompany(candidate, companyUserId),

                        /* Mapping Study Sublevels */
                        () => candidate.StudyList = StudiesSubLevelsByOverviewWithCompany(candidate, companyUserId),

                        /* Mapping Work Experience Sublevels */
                        () => candidate.WorkExperienceList = WorkExperiencesSubLevelsByOverviewWithCompany(candidate, companyUserId),

                        /* Mapping Personal References Sublevels */
                        () => candidate.PersonalReferenceList = PersonalReferencesSubLevelsByOverviewWithCompany(candidate, companyUserId),

                        /* Mapping Life Preferences Sublevels */
                        () => candidate.Candidate_LifePreferenceList = LifePreferencesSubLevelsByOverviewWithCompany(candidate, companyUserId),

                        /* Mapping Company Time Availabilities Sublevels */
                        () => candidate.Company_Candidate_TimeAvailability = CompanyTimeAvailabilitySubLevelsByOverviewWithCompany(candidate, companyUserId),

                        /* Mapping Company Wellnesses Sublevels */
                        () => candidate.Company_Candidate_Wellness = CompanyWellnessesSubLevelsByOverviewWithCompany(candidate, companyUserId),

                        /* Mapping Languages Others Sublevels */
                        () => candidate.Candidate_LanguageOther = CandidateLanguagesOthersByOverviewWithCompany(candidate, companyUserId),

                        /* Mapping Company Descriptions Sublevels */
                        () => candidate.CompanyDescriptionList = CompanyDescriptionsByOverviewWithCompany(candidate, companyUserId),

                        /* Mapping Candidate Company Sublevels */
                        () => candidate.CandidateCompanies = CandidateCompaniesByOverviewWithCompany(candidate, companyUserId)
                    );
                }

                /**/

                /* Map Candidate to the new format */
                CandidateWithCompanyDTO candidateWithCompany = new();
                candidateWithCompany = _mapper.Map<Candidate, CandidateWithCompanyDTO>(candidate);

                /* Candidate Company Info by this Company */
                CandidateCompany candidateCompany = candidate.CandidateCompanies.Where(c => c.CompanyUserId == companyUserId).FirstOrDefault();

                /**/

                Parallel.Invoke
                (
                    /* Mapping Candidate Basic Information Sublevels */
                    () => candidateWithCompany = CandidateDataByOverviewWithCompany(candidate, candidateWithCompany, companyUserId)
                );

                /**/

                /* Dates */
                candidateWithCompany = await DatesByOverviewWithCompany(candidate, candidateWithCompany, memberUserName, memberUserSurname, companyUserId, token); 

                /* Block Reasons */
                candidateWithCompany.CandidateBlockReason = await _candidate_BlockReasonService.GetCandidateBlockReasonByCandidateAndCompanyId(candidateId, companyUserId);

                /* Company Data */
                candidateWithCompany.CompanyData = await CompanyDataByOverviewWithCompany(candidate, candidateCompany, companyUserId);

                candidateWithCompany.IsPotential =
                            candidate.CandidateCompanies != null && candidate.CandidateCompanies.Where(cc => cc.CompanyUserId == companyUserId).FirstOrDefault() != null
                            ? candidate.CandidateCompanies.Where(cc => cc.CompanyUserId == companyUserId).FirstOrDefault().IsPotential
                            : false;

                /* CVs */
                candidateWithCompany.CV = await CandidateCVByOverviewWithCompany(candidate); 
                candidateWithCompany.CompanyData.CV = await CompanyCVByOverviewWithCompany(candidate, companyUserId);

                Parallel.Invoke
                (
                    /* Emails List */
                    () => candidateWithCompany.Emails = EmailsByOverviewWithCompany(candidate, companyUserId),

                    /* Phones List */
                    () => candidateWithCompany.Phones = PhonesByOverviewWithCompany(candidate, companyUserId),

                    /* Social Networks List */
                    () => candidateWithCompany.SocialNetworks = SocialNetworksByOverviewWithCompany(candidate, companyUserId),

                    /* User Links List */
                    () => candidateWithCompany.UserLinks = UserLinksByOverviewWithCompany(candidate, companyUserId),

                    /* Description Assignation */
                    () => candidateWithCompany.CompanyDescription = CompanyDescriptionByOverviewWithCompany(candidate, companyUserId),

                    /* Languages Lists */
                    () => candidateWithCompany.LanguagesFromCandidateList = CandidateLanguagesByOverviewWithCompany(candidate),
                    () => candidateWithCompany.LanguagesFromCompanyList = CompanyLanguagesByOverviewWithCompany(candidate, companyUserId),
                    () => candidateWithCompany.LanguagesOtherFromCandidateList = CandidateLanguagesOtherByOverviewWithCompany(candidate),
                    () => candidateWithCompany.LanguagesOtherFromCompanyList = CompanyLanguagesOtherByOverviewWithCompany(candidate, companyUserId),

                    /* Soft Skills Lists */
                    () => candidateWithCompany.SoftSkillsFullList = FullSoftSkillsByOverviewWithCompany(candidate),
                    () => candidateWithCompany.SoftSkillsFromCandidateList = CandidateSoftSkillsByOverviewWithCompany(candidate),
                    () => candidateWithCompany.SoftSkillsFromCompanyList = CompanySoftSkillsByOverviewWithCompany(candidate, companyUserId),

                    /* Technical Abilities Lists */
                    () => candidateWithCompany.TechnicalAbilitiesFullList = FullTechnicalAbilitiesByOverviewWithCompany(candidate, companyUserId),
                    () => candidateWithCompany.TechnicalAbilitiesFromCandidateList = CandidateTechnicalAbilitiesByOverviewWithCompany(candidate),
                    () => candidateWithCompany.TechnicalAbilitiesFromCompanyList = CompanyTechnicalAbilitiesByOverviewWithCompany(candidate, companyUserId),

                    /* Studies Lists */
                    () => candidateWithCompany.StudyFromCandidateList = CandidateStudiesByOverviewWithCompany(candidate),
                    () => candidateWithCompany.StudyFromCompanyList = CompanyStudiesByOverviewWithCompany(candidate, companyUserId),

                    /* Work Experiences Lists */
                    () => candidateWithCompany.WorkExperienceFullList = FullWorkExperiencesByOverviewWithCompany(candidate, companyUserId),
                    () => candidateWithCompany.WorkExperienceFromCandidateList = CandidateWorkExperiencesByOverviewWithCompany(candidate),
                    () => candidateWithCompany.WorkExperienceFromCompanyList = CompanyWorkExperiencesByOverviewWithCompany(candidate, companyUserId),

                    /* Personal References Lists */
                    () => candidateWithCompany.PersonalReferenceFromCandidateList = CandidatePersonalReferencesByOverviewWithCompany(candidate),
                    () => candidateWithCompany.PersonalReferenceFromCompanyList = CompanyPersonalReferencesByOverviewWithCompany(candidate, companyUserId),

                    /* Life Preferences Lists */
                    () => candidateWithCompany.LifePreferenceFromCandidateList = CandidateLifePreferencesByOverviewWithCompany(candidate),
                    () => candidateWithCompany.LifePreferenceFromCompanyList = CompanyLifePreferencesByOverviewWithCompany(candidate, companyUserId),

                    /* Job Preferences Lists */
                    () => candidateWithCompany.JobPreferencesFromCandidate = CandidateJobPreferencesByOverviewWithCompany(candidate),
                    () => candidateWithCompany.JobPreferencesFromCompany = CompanyJobPreferencesByOverviewWithCompany(candidate, companyUserId)
                );

                /* Studies */
                candidateWithCompany.StudyFullList = await FullStudiesByOverviewWithCompany(candidate, companyUserId, token);

                /* Video */
                candidateWithCompany.Video = await VideoByOverviewWithCompany(candidateId);

                /**/

                /* Postulations List */
                candidateWithCompany.Postulations = await _postulationService.GetAllPostulationsByCandidateIdWithoutFiled(candidate, candidateId, memberUser, companyUserId);

                /* Postulations with Q&A List */
                candidateWithCompany.PostulationsWithQuestionsAndAnswers = await _answerService.GetAnswersByCandidateIdOrderByPostulation(candidate, candidateId, companyUserId);

                /* Talent Groups List */
                candidateWithCompany.TalentGroups = await _candidate_TalentGroupService.GetAllCandidate_TalentGroupsById(candidateId, memberUser, companyUserId);

                /* Tags List */
                candidateWithCompany.Tags = await _candidate_TagService.GetCandidate_TagsByCandidateId(candidateId, memberUser, companyUserId);

                /* Sources List */
                candidateWithCompany.Sources = await _candidate_SourceService.GetCandidate_SourcesByCandidateId(candidateId, memberUser, companyUserId);

                /* Event List */
                candidateWithCompany.Events = await _eventService.GetEventsByCandidateAndCompanyd(candidateId, companyUserId);

                /* Notes List */
                candidateWithCompany.Notes = await NotesByOverviewWithCompany(candidate, memberUserDTO, memberUserList);

                /* Counts */
                ExperienceCount experienceCount = await _candidateRepository.ExperienceCountByCandidateId(candidateId);

                /* Mapping years and companies number by the experience count */
                if (experienceCount != null)
                {
                    candidateWithCompany.Years = experienceCount.Years;
                    candidateWithCompany.CompaniesNumber = experienceCount.CompaniesNumber;
                }

                /* Delete Proccess */
                candidateWithCompany.RequestDelete = await GetRequestDelete(candidate, companyUserId);

                /* Mapping request delete's date */
                if (candidateWithCompany != null && candidateWithCompany.Description != null && candidate != null && candidate.Description != null)
                {
                    try
                    {
                        candidateWithCompany.Description.CreationInfo = _uploadTimeService.GetEditInfo(candidate.Description.EditionDate);
                        candidateWithCompany.Description.CreationShortInfo = _uploadTimeService.GetFileTypeCreationShortInfo(candidate.Description.EditionDate);
                        candidateWithCompany.Description.CandidateEditionDate = _uploadTimeService.GetFileTypeCreationInfoPup(candidate.Description.EditionDate);
                    }
                    catch (Exception ex)
                    {

                    }
                }

                candidateWithCompany.DeleteMember = false;

                if (candidate.EmailMember != null)
                {
                    MemberUser memberUserTemp = await _memberUserRepository.GetByEmail(candidate.EmailMember);

                    if (memberUserTemp == null)
                    {
                        candidateWithCompany.DeleteMember = true;
                    }
                }

                return candidateWithCompany;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ICollection<Candidate_Language>> GetLanguagesSubLevels(Candidate candidate, int companyUserId)
        {
            if (candidate != null && candidate.Candidate_Language != null && candidate.Candidate_Language.Count > 0)
            {
                foreach (Candidate_Language language in candidate.Candidate_Language)
                {
                    language.Language =
                        await _languageRepository.GetById(language.LanguageId);
                    language.LanguageLevel =
                        await _languageLevelRepository.GetById(language.LanguageLevelId);
                }
            }

            if (candidate == null)
                return null;

            return candidate.Candidate_Language;
        }

        public async Task<ICollection<Candidate_SoftSkill>> GetSoftSkillsSubLevels(Candidate candidate, int companyUserId)
        {
            if (candidate != null && candidate.Candidate_SoftSkillList != null && candidate.Candidate_SoftSkillList.Count > 0)
            {
                foreach (Candidate_SoftSkill softSkill in candidate.Candidate_SoftSkillList)
                {
                    softSkill.SoftSkill =
                        await _softSkillRepository.GetById(softSkill.SoftSkillId);
                }
            }

            if (candidate == null)
                return null;

            return candidate.Candidate_SoftSkillList;
        }

        public async Task<ICollection<Candidate_TechnicalAbility>> GetTechnnicalAbiltiesSubLevels(Candidate candidate, int companyUserId)
        {
            if (candidate != null && candidate.Candidate_TechnicalAbilityList != null && candidate.Candidate_TechnicalAbilityList.Count > 0)
            {
                foreach (Candidate_TechnicalAbility technicalAbility in candidate.Candidate_TechnicalAbilityList)
                {
                    technicalAbility.TechnicalAbilityLevel =
                        technicalAbility.TechnicalAbilityLevelId != null ? await _technicalAbilityLevelRepository.GetById((int)technicalAbility.TechnicalAbilityLevelId) : null;
                    technicalAbility.TechnicalAbilityTechnology =
                        await _technicalAbilityTechnologyRepository.GetById(technicalAbility.TechnicalAbilityTechnologyId);
                }
            }

            if (candidate == null)
                return null;

            return candidate.Candidate_TechnicalAbilityList;
        }

        public async Task<ICollection<Study>> GetStudySubLevels(Candidate candidate, int companyUserId)
        {
            if (candidate != null && candidate.StudyList != null && candidate.StudyList.Count > 0)
            {
                foreach (Study study in candidate.StudyList)
                {
                    study.StudyArea =
                        study.StudyAreaId != null ? await _studyArearepository.GetByStudyAreaId((int)study.StudyAreaId) : null;
                    study.StudyCertificate =
                        await _studyCertificateRepository.GetByStudyId(study.StudyId);
                    study.StudyState =
                        await _studyStateRepository.GetByStudyStateId(study.StudyStateId);
                    study.CertificationState =
                        study.CertificationStateId != null ? await _certificationStateRepository.GetByCertificationStateId((int)study.CertificationStateId) : null;
                    study.StudyType =
                        study.StudyTypeId != null ? await _studyTypeRepository.GetByStudyTypeId((int)study.StudyTypeId) : null;
                    study.Title =
                        study.TitleId != null ? await _titleRepository.GetByTitleId((int)study.TitleId) : null;
                }
            }

            if (candidate == null)
                return null;

            return candidate.StudyList;
        }

        public async Task<ICollection<WorkExperience>> GetWorkExperienceSubLevels(Candidate candidate, int companyUserId)
        {
            if (candidate != null && candidate.WorkExperienceList != null && candidate.WorkExperienceList.Count > 0)
            {
                foreach (WorkExperience workExperience in candidate.WorkExperienceList)
                {
                    workExperience.Industry =
                        workExperience.IndustryId != null ? await _industryRepository.GetById((int)workExperience.IndustryId) : null;
                    workExperience.EquivalentPosition =
                        workExperience.EquivalentPositionId != null ? await _equivalentPositionRepository.GetById((int)workExperience.EquivalentPositionId) : null;
                }
            }

            if (candidate == null)
                return null;

            return candidate.WorkExperienceList;
        }

        public async Task<ICollection<PersonalReference>> GetPersonalReferencesSubLevels(Candidate candidate, int companyUserId)
        {
            if (candidate != null && candidate.PersonalReferenceList != null && candidate.PersonalReferenceList.Count > 0)
            {
                foreach (PersonalReference personalReference in candidate.PersonalReferenceList)
                {
                    personalReference.RelationType =
                        personalReference.RelationTypeId != null ? await _relationTypeRepository.GetById((int)personalReference.RelationTypeId) : null;
                }
            }

            if (candidate == null)
                return null;

            return candidate.PersonalReferenceList;
        }

        public async Task<ICollection<Candidate_LifePreference>> GetLifePreferencesSubLevels(Candidate candidate, int companyUserId)
        {
            if (candidate != null && candidate.Candidate_LifePreferenceList != null && candidate.Candidate_LifePreferenceList.Count > 0)
            {
                foreach (Candidate_LifePreference lifePreferences in candidate.Candidate_LifePreferenceList)
                {
                    lifePreferences.LifePreference =
                        await _lifePreferenceRepository.GetById(lifePreferences.LifePreferenceId);
                }
            }

            if (candidate == null)
                return null;

            return candidate.Candidate_LifePreferenceList;
        }

        public async Task<ICollection<Candidate_TimeAvailability>> GetCandidateTimeAvailabilitiesSubLevels(Candidate candidate, int companyUserId)
        {
            if (candidate != null && candidate.Candidate_TimeAvailability != null && candidate.Candidate_TimeAvailability.Count > 0)
            {
                foreach (Candidate_TimeAvailability timeAvailability in candidate.Candidate_TimeAvailability)
                {
                    timeAvailability.TimeAvailability =
                        await _timeAvailabilityRepository.GetById(timeAvailability.TimeAvailabilityId);
                }
            }

            if (candidate == null)
                return null;

            return candidate.Candidate_TimeAvailability;
        }

        public async Task<ICollection<Company_Candidate_TimeAvailability>> GetCompanyTimeAvailabilitiesSubLevels(Candidate candidate, int companyUserId)
        {
            if (candidate != null && candidate.Company_Candidate_TimeAvailability != null && candidate.Company_Candidate_TimeAvailability.Count > 0)
            {
                foreach (Company_Candidate_TimeAvailability timeAvailability in candidate.Company_Candidate_TimeAvailability)
                {
                    timeAvailability.TimeAvailability =
                        await _timeAvailabilityRepository.GetById(timeAvailability.TimeAvailabilityId);
                }
            }

            if (candidate == null)
                return null;

            return candidate.Company_Candidate_TimeAvailability;
        }

        public async Task<ICollection<Candidate_Wellness>> GetCandidateWellnessSubLevels(Candidate candidate, int companyUserId)
        {
            if (candidate != null && candidate.Candidate_Wellness != null && candidate.Candidate_Wellness.Count > 0)
            {
                foreach (Candidate_Wellness wellness in candidate.Candidate_Wellness)
                {
                    wellness.Wellness =
                        await _wellnessRepository.GetById(wellness.WellnessId);
                }
            }

            if (candidate == null)
                return null;

            return candidate.Candidate_Wellness;
        }

        public async Task<ICollection<Company_Candidate_Wellness>> GetCompanyWellnessSubLevels(Candidate candidate, int companyUserId)
        {
            if (candidate != null && candidate.Company_Candidate_Wellness != null && candidate.Company_Candidate_Wellness.Count > 0)
            {
                foreach (Company_Candidate_Wellness wellness in candidate.Company_Candidate_Wellness)
                {
                    wellness.Wellness =
                        await _wellnessRepository.GetById(wellness.WellnessId);
                }
            }

            if (candidate == null)
                return null;

            return candidate.Company_Candidate_Wellness;
        }

        public async Task<CandidateWithCompanyDTO> DatesByOverviewWithCompany(Candidate candidate, CandidateWithCompanyDTO candidateWithCompany, string memberUserName, string memberUserSurname, int companyUserId, string token)
        {
            candidateWithCompany.CreationInfoPup = _uploadTimeService.GetFormatColombian(candidate.CreationDate);
            candidateWithCompany.CreationInfoPupEnglish = _uploadTimeService.GetFormatUsa(candidate.CreationDate);
            candidateWithCompany.CreationDate = _uploadTimeService.GetPublicationInfoWithoutPrefix(candidate.CreationDate);

            string name = "";

            if (candidate != null && !string.IsNullOrEmpty(candidate.NameMemberUser))
            {
                name = candidate.NameMemberUser;

                if (!string.IsNullOrEmpty(candidate.SurnameMemberUser))
                    name += " " + candidate.SurnameMemberUser;
            }

            candidateWithCompany.CreationInfo = _uploadTimeService.GetCandidateCreationInfo(candidate.CreationDate, candidate.FirstLoginDate, candidate.IsMigrated, candidate.Source, name, candidate.IsFromCompanyAndLogin, candidate.CompanyUserId, companyUserId);
            candidateWithCompany.CreationInfoEnglish = _uploadTimeService.GetCandidateCreationInfoEnglish(candidate.CreationDate, candidate.FirstLoginDate, candidate.IsMigrated, candidate.Source, name, candidate.IsFromCompanyAndLogin, candidate.CompanyUserId, companyUserId);

            candidateWithCompany.CreationShortInfo = _uploadTimeService.GetCandidateCreationShortInfo(candidate.CreationDate, candidate.IsMigrated, candidate.Source);
            candidateWithCompany.FirstLoginInfoPup = _uploadTimeService.GetFormatColombian(candidate.FirstLoginDate);

            try
            {
                string companyUserName = "";

                CompanyUser companyUser = await _companyUserRepository.GetById(candidate.CompanyUserId);

                DateTime creationDate = DateTime.Now;
                DateTime firstLoginDate = DateTime.Now;

                if (DateTime.TryParseExact(candidate.CreationDate, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out creationDate)) ;
                else
                    creationDate = Convert.ToDateTime(candidate.CreationDate);

                if (DateTime.TryParseExact(candidate.FirstLoginDate, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture,
                   DateTimeStyles.None, out firstLoginDate)) ;
                else
                    firstLoginDate = Convert.ToDateTime(candidate.FirstLoginDate);

                string creationInfo = _uploadTimeService.GetCandidateCreationInfo(creationDate.ToString(), firstLoginDate.ToString(), candidate.IsMigrated, candidate.Source, name, candidate.IsFromCompanyAndLogin, candidate.CompanyUserId, companyUserId);
                string creationInfoEnhlish = candidateWithCompany.CreationInfoEnglish = _uploadTimeService.GetCandidateCreationInfoEnglish(candidate.CreationDate, candidate.FirstLoginDate, candidate.IsMigrated, candidate.Source, name, candidate.IsFromCompanyAndLogin, candidate.CompanyUserId, companyUserId);
                string creationShortInfo = _uploadTimeService.GetCandidateCreationShortInfo(creationDate.ToString(), candidate.IsMigrated, candidate.Source);
                string firstLoginInfoPup = _uploadTimeService.GetFormatColombian(candidate.FirstLoginDate);

                candidateWithCompany.Email = candidate.Email;
                candidateWithCompany.IsMigrated = candidate.IsMigrated;
                candidateWithCompany.IsFromCompanyAndLogin = candidate.IsFromCompanyAndLogin;
                candidateWithCompany.CreationInfo = creationInfo;
                candidateWithCompany.CreationInfoEnglish = creationInfoEnhlish;
                candidateWithCompany.CreationShortInfo = creationShortInfo;
                candidateWithCompany.CreationInfoPup = Convert.ToDateTime(creationDate).ToString("dd MMM yyyy h:mm tt", new CultureInfo("es-CO"));
                candidateWithCompany.FirstLoginInfoPup = firstLoginInfoPup;

                if (!string.IsNullOrEmpty(candidate.FirstLoginDate))
                    candidateWithCompany.FirstLoginInfoPup = Convert.ToDateTime(candidate.FirstLoginDate).ToString("dd MMM yyyy h:mm tt", new CultureInfo("es-CO"));

                if (candidate.IsMigrated != 0 && candidate.isAuthorized == false)
                {
                    var publicationDate = Convert.ToDateTime(candidate.CreationDate).ToLocalTime();
                    var publicationTime = publicationDate - DateTime.Now.ToLocalTime().AddHours(-5);

                    if (Convert.ToInt32((publicationTime.TotalDays * -1)) > 180)
                    {
                        candidateWithCompany.Validity = true;
                    }
                    candidateWithCompany.ValidityDate = Convert.ToInt32((publicationTime.TotalDays * -1)) + " días.";
                }

                bool isMaster = await _companyUserService.IsMaster(token);

                if (companyUser != null)
                    companyUserName = companyUser.Name;

                candidateWithCompany.CreationInfoPup = _uploadTimeService.GetFormatColombian(candidate.CreationDate);
                candidateWithCompany.CreationDate = _uploadTimeService.GetPublicationInfoWithoutPrefix(candidate.CreationDate);
                
                if (isMaster == true)
                {
                    candidateWithCompany.CreationInfo = _uploadTimeService.GetCandidateCreationInfoMaster(candidate.CreationDate, candidate.FirstLoginDate, candidate.IsMigrated, candidate.Source, name, candidate.IsFromCompanyAndLogin, companyUserName);
                    candidateWithCompany.CreationInfoEnglish = _uploadTimeService.GetCandidateCreationInfoMasterEnglish(candidate.CreationDate, candidate.FirstLoginDate, candidate.IsMigrated, candidate.Source, name, candidate.IsFromCompanyAndLogin, companyUserName);
                }
                else
                {
                    candidateWithCompany.CreationInfo = _uploadTimeService.GetCandidateCreationInfo(candidate.CreationDate, candidate.FirstLoginDate, candidate.IsMigrated, candidate.Source, name, candidate.IsFromCompanyAndLogin, candidate.CompanyUserId, companyUserId);
                    candidateWithCompany.CreationInfoEnglish = _uploadTimeService.GetCandidateCreationInfoEnglish(candidate.CreationDate, candidate.FirstLoginDate, candidate.IsMigrated, candidate.Source, name, candidate.IsFromCompanyAndLogin, candidate.CompanyUserId, companyUserId);
                }

                candidateWithCompany.CreationShortInfo = _uploadTimeService.GetCandidateCreationShortInfo(candidate.CreationDate, candidate.IsMigrated, candidate.Source);
                candidateWithCompany.FirstLoginInfoPup = _uploadTimeService.GetFormatColombian(candidate.FirstLoginDate);


                if (candidateWithCompany.IsMigrated != 0 && candidateWithCompany.IsAuthorized == false)
                {

                    var publicationDate = Convert.ToDateTime(candidate.CreationDate).ToLocalTime();
                    var publicationTime = publicationDate - DateTime.Now.ToLocalTime().AddHours(-5);


                    if (Convert.ToInt32((publicationTime.TotalDays * -1)) > 180)
                    {
                        candidateWithCompany.Validity = true;
                    }
                    candidateWithCompany.ValidityDate = Convert.ToInt32((publicationTime.TotalDays * -1)) + " días.";

                }

                Request reqUpdate = await _requestRepository.GetLastRequest(candidateWithCompany.CandidateId, 1); //
                Request reqDelete = await _requestRepository.GetLastRequest(candidateWithCompany.CandidateId, 2); //

                if (reqUpdate != null)
                {
                    RequestOverViewDTO requestUpdate = new RequestOverViewDTO()
                    {
                        RequestId = reqUpdate.RequestId,
                        Message = reqUpdate.Message,
                        CreationDate = _uploadTimeService.GetCreationDate(reqUpdate.CreationDate.ToString()),
                        CreationInfoPup = _uploadTimeService.GetFormatColombian(reqUpdate.CreationDate.ToString())
                    };
                    candidateWithCompany.RequestUpdate = requestUpdate;
                }
                if (reqDelete != null)
                {
                    RequestOverViewDTO requestDelete = new RequestOverViewDTO()
                    {
                        RequestId = reqDelete.RequestId,
                        Message = reqDelete.Message,
                        CreationDate = _uploadTimeService.GetCreationDate(reqDelete.CreationDate.ToString()),
                        CreationInfoPup = _uploadTimeService.GetFormatColombian(reqDelete.CreationDate.ToString())
                    };
                    candidateWithCompany.RequestDeleteOverview = requestDelete;
                }
            }
            catch (Exception ex)
            {

            }

            return candidateWithCompany;
        }

        public async Task<VideoDTO> VideoByOverviewWithCompany(int candidateId)
        {
            Video video = await _videoRepository.GetByCandidateId(candidateId);

            VideoDTO videoDTO = new VideoDTO();

            videoDTO = _mapper.Map<Video, VideoDTO>(video);

            return videoDTO;
        }

        public CandidateWithCompanyDTO CandidateDataByOverviewWithCompany(Candidate candidate, CandidateWithCompanyDTO candidateWithCompany, int companyUserId)
        {
            string initials = "";

            if (candidate != null && candidate.BasicInformation != null)
            {
                if (!string.IsNullOrEmpty(candidate.BasicInformation.Name))
                {
                    candidateWithCompany.Name = candidate.BasicInformation.Name.TrimStart().TrimEnd();

                    candidateWithCompany.FullName = candidate.BasicInformation.Name.TrimStart().TrimEnd();

                    initials += candidateWithCompany.Name[0];
                }

                if (!string.IsNullOrEmpty(candidate.BasicInformation.Surname))
                {
                    candidateWithCompany.Surname = candidate.BasicInformation.Surname.TrimStart().TrimEnd();

                    candidateWithCompany.FullName += " " + candidate.BasicInformation.Surname.TrimStart().TrimEnd();

                    initials += candidateWithCompany.Surname[0];
                }
                else
                {
                    initials += candidateWithCompany.Name[1];
                }

                candidateWithCompany.Initials = initials.ToUpper();

                candidateWithCompany.Photo = candidate.BasicInformation.Photo;

                MaritalStatusDTO auxMaritalStatus = _mapper.Map<MaritalStatus, MaritalStatusDTO>(candidate.BasicInformation.MaritalStatus);
                GenderDTO auxGender = _mapper.Map<Gender, GenderDTO>(candidate.BasicInformation.Gender);

                candidateWithCompany.DocumentType = _mapper.Map<DocumentType, DocumentTypeDTO>(candidate.BasicInformation.DocumentType);
                candidateWithCompany.MaritalStatus =
                    auxMaritalStatus != null && !string.IsNullOrEmpty(auxMaritalStatus.Name) && auxMaritalStatus.Name.ToLower().Trim() != "vacío" ? auxMaritalStatus : null;
                candidateWithCompany.Currency = _mapper.Map<Currency, CurrencyDTO>(candidate.BasicInformation.Currency);
                candidateWithCompany.Gender =
                    auxGender != null && !string.IsNullOrEmpty(auxGender.Name) && auxGender.Name.ToLower().Trim() != "vacío" ? auxGender : null;

                candidateWithCompany.HaveWorkExperience = candidate.BasicInformation.HaveWorkExperience;
                candidateWithCompany.SalaryAspiration = candidate.BasicInformation.SalaryAspiration;
                candidateWithCompany.Address =
                    !string.IsNullOrEmpty(candidate.BasicInformation.Address) && candidate.BasicInformation.Address.ToLower().Trim() != "[su dirección]" ? candidate.BasicInformation.Address : string.Empty;
                candidateWithCompany.BirthDate = candidate.BasicInformation.BirthDate;
                candidateWithCompany.Document = candidate.BasicInformation.Document;

                candidateWithCompany.Country = candidate.BasicInformation.Country;
                candidateWithCompany.State = candidate.BasicInformation.State;
                candidateWithCompany.City = candidate.BasicInformation.City;

                candidateWithCompany.BasicInformationId = candidate.BasicInformation.BasicInformationId;

                candidateWithCompany.Phone = candidate.BasicInformation.Phone;
                candidateWithCompany.Cellphone = candidate.BasicInformation.Cellphone;

                candidateWithCompany.LinkedInURL = candidate.BasicInformation.LinkedInURL;
                candidateWithCompany.FacebookURL = candidate.BasicInformation.FacebookURL;
                candidateWithCompany.TwitterURL = candidate.BasicInformation.TwitterURL;
                candidateWithCompany.GitHubURL = candidate.BasicInformation.GitHubURL;
                candidateWithCompany.BitBucketURL = candidate.BasicInformation.BitBucketURL;

                if (candidateWithCompany.DocumentType != null)
                {
                    candidateWithCompany.DocumentType.OtherName = candidate.BasicInformation.OtherDocument;

                    if (candidateWithCompany.DocumentType.DocumentTypeId == 4)
                        candidateWithCompany.DocumentType.Initials = candidateWithCompany.DocumentType.OtherName;
                }
            }

            return candidateWithCompany;
        }

        public async Task<CandidateCompanyDTO> CompanyDataByOverviewWithCompany(Candidate candidate, CandidateCompany candidateCompany, int companyUserId)
        {
            if (candidateCompany == null)
            {
                candidateCompany = new CandidateCompany
                {
                    CandidateCompanyId = 0,

                    CandidateId = candidate.CandidateId,
                    Candidate = null,

                    CompanyUserId = companyUserId
                };

                List<CandidateCompany> oldCandidateCompanies = await _candidateCompanyRepository.GetByCandidateId(candidate.CandidateId);

                bool created = await _candidateCompanyRepository.AddCandidateCompany(candidateCompany);

                if (oldCandidateCompanies != null && oldCandidateCompanies.Count > 0)
                {
                    foreach (CandidateCompany candidateComp in oldCandidateCompanies)
                    {
                        try
                        {
                            bool isAdded = await _candidateCompanyRepository.Add(candidateComp);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }

            if (candidate != null && candidate.BasicInformation != null)
            {
                candidateCompany.Photo = candidate.BasicInformation.PhotoByAdmin;
            }

            DocumentType documentType = new DocumentType();
            MaritalStatus maritalStatus = new MaritalStatus();
            Currency currency = new Currency();
            Gender gender = new Gender();

            try
            {
                if (candidateCompany.DocumentTypeId != null)
                    documentType = await _documentTypeRepository.GetById((int)candidateCompany.DocumentTypeId);
                if (candidateCompany.MaritalStatusId != null)
                    maritalStatus = await _maritalStatusRepository.GetByIdWithoutNull((int)candidateCompany.MaritalStatusId);
                if (candidateCompany.CurrencyId != null)
                    currency = await _currencyRepository.GetById((int)candidateCompany.CurrencyId);
                if (candidateCompany.GenderId != null)
                    gender = await _genderRepository.GetByIdWithoutNull((int)candidateCompany.GenderId);
            }
            catch (Exception ex)
            {

            }

            CandidateCompanyDTO candidateCompanyDTO = _mapper.Map<CandidateCompany, CandidateCompanyDTO>(candidateCompany);

            MaritalStatusDTO auxMaritalStatus = _mapper.Map<MaritalStatus, MaritalStatusDTO>(maritalStatus);
            GenderDTO auxGender = _mapper.Map<Gender, GenderDTO>(gender);

            candidateCompanyDTO.DocumentType = _mapper.Map<DocumentType, DocumentTypeDTO>(documentType);
            candidateCompanyDTO.MaritalStatus =
                    auxMaritalStatus != null && !string.IsNullOrEmpty(auxMaritalStatus.Name) && auxMaritalStatus.Name.ToLower().Trim() != "vacío" ? auxMaritalStatus : null;
            candidateCompanyDTO.Currency = _mapper.Map<Currency, CurrencyDTO>(currency);
            candidateCompanyDTO.Gender =
                    auxGender != null && !string.IsNullOrEmpty(auxGender.Name) && auxGender.Name.ToLower().Trim() != "vacío" ? auxGender : null;

            candidateCompanyDTO.HaveWorkExperience = candidateCompany.HaveWorkExperience;
            candidateCompanyDTO.SalaryAspiration = candidateCompany.SalaryAspiration;
            candidateCompanyDTO.Address =
                !string.IsNullOrEmpty(candidateCompany.Address) && candidateCompany.Address.ToLower().Trim() != "[su dirección]" ? candidateCompany.Address : string.Empty;
            candidateCompanyDTO.BirthDate = candidateCompany.BirthDate;

            if (candidateCompanyDTO.DocumentType != null)
            {
                candidateCompanyDTO.DocumentType.OtherName = candidateCompany.OtherDocument;

                if (candidateCompanyDTO.DocumentType.DocumentTypeId == 4)
                    candidateCompanyDTO.DocumentType.Initials = candidateCompanyDTO.DocumentType.OtherName;
            }

            return candidateCompanyDTO;
        }

        public BasicInformation BasicInformationSubLevelsByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            if (candidate != null && candidate.BasicInformation != null)
            {
                if (candidate.BasicInformation.Emails != null && candidate.BasicInformation.Emails.Count > 0)
                    candidate.BasicInformation.Emails = candidate.BasicInformation.Emails.Where(e => e.CompanyUserId == companyUserId).ToList();

                if (candidate.BasicInformation.Phones != null && candidate.BasicInformation.Phones.Count > 0)
                    candidate.BasicInformation.Phones = candidate.BasicInformation.Phones.Where(p => p.CompanyUserId == companyUserId).ToList();

                if (candidate.BasicInformation.SocialNetworks != null && candidate.BasicInformation.SocialNetworks.Count > 0)
                    candidate.BasicInformation.SocialNetworks = candidate.BasicInformation.SocialNetworks.Where(s => s.CompanyUserId == companyUserId).ToList();

                if (candidate.BasicInformation.UserLinks != null && candidate.BasicInformation.UserLinks.Count > 0)
                    candidate.BasicInformation.UserLinks = candidate.BasicInformation.UserLinks.Where(u => u.CompanyUserId == companyUserId).ToList();
            }

            return candidate.BasicInformation;
        }

        public List<Candidate_Language> LanguagesSubLevelsByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            if (candidate.Candidate_Language != null)
            {
                candidate.Candidate_Language = candidate.Candidate_Language
                .Where(l => l.AdminView == false || (l.AdminView == true && l.CompanyUserId == companyUserId)).ToList();

                return candidate.Candidate_Language.ToList();
            }

            return null;
        }

        public List<Candidate_SoftSkill> SoftSkillsSubLevelsByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            if (candidate.Candidate_SoftSkillList != null)
            {
                candidate.Candidate_SoftSkillList = candidate.Candidate_SoftSkillList
                .Where(s => s.IsFromEmpresaAdded == false || (s.IsFromEmpresaAdded == true && s.CompanyUserId == companyUserId)).ToList();

                return candidate.Candidate_SoftSkillList.ToList();
            }

            return null;
        }

        public List<Candidate_TechnicalAbility> TechnicalAbilitiesSubLevelsByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            if (candidate.Candidate_TechnicalAbilityList != null)
            {
                candidate.Candidate_TechnicalAbilityList = candidate.Candidate_TechnicalAbilityList
                .Where(t => t.IsFromEmpresaAdded == false || (t.IsFromEmpresaAdded == true && t.CompanyUserId == companyUserId)).ToList();

                return candidate.Candidate_TechnicalAbilityList.ToList();
            }

            return null;
        }

        public List<Study> StudiesSubLevelsByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            if (candidate.StudyList != null)
            {
                candidate.StudyList = candidate.StudyList
                .Where(s => s.IsFromCandidate == true || (s.IsFromCandidate == false && s.CompanyUserId == companyUserId)).ToList();

                return candidate.StudyList.ToList();
            }

            return null;
        }

        public List<WorkExperience> WorkExperiencesSubLevelsByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            if (candidate.WorkExperienceList != null)
            {
                candidate.WorkExperienceList = candidate.WorkExperienceList
                .Where(w => w.AdminView == false || (w.AdminView == true && w.CompanyUserId == companyUserId)).ToList();

                return candidate.WorkExperienceList.ToList();
            }

            return null;
        }

        public List<PersonalReference> PersonalReferencesSubLevelsByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            if (candidate.PersonalReferenceList != null)
            {
                candidate.PersonalReferenceList = candidate.PersonalReferenceList
                .Where(x => x.IsAddefromCompany == false || (x.IsAddefromCompany == true && x.CompanyUserId == companyUserId)).ToList();

                return candidate.PersonalReferenceList.ToList();
            }

            return null;
        }

        public List<Candidate_LifePreference> LifePreferencesSubLevelsByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            if (candidate.Candidate_LifePreferenceList != null)
            {
                candidate.Candidate_LifePreferenceList = candidate.Candidate_LifePreferenceList
                .Where(l => l.IsFromCandidate == true || (l.IsFromCandidate == false && l.CompanyUserId == companyUserId)).ToList();

                return candidate.Candidate_LifePreferenceList.ToList();
            }

            return null;
        }

        public List<Company_Candidate_TimeAvailability> CompanyTimeAvailabilitySubLevelsByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            if (candidate.Company_Candidate_TimeAvailability != null)
            {
                candidate.Company_Candidate_TimeAvailability = candidate.Company_Candidate_TimeAvailability
                .Where(t => t.CompanyUserId == companyUserId).ToList();

                return candidate.Company_Candidate_TimeAvailability.ToList();
            }

            return null;
        }

        public List<Company_Candidate_Wellness> CompanyWellnessesSubLevelsByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            if (candidate.Company_Candidate_Wellness != null)
            {
                candidate.Company_Candidate_Wellness = candidate.Company_Candidate_Wellness
                .Where(w => w.CompanyUserId == companyUserId).ToList();

                return candidate.Company_Candidate_Wellness.ToList();
            }

            return null;
        }

        public List<Candidate_LanguageOther> CandidateLanguagesOthersByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            if (candidate.Candidate_LanguageOther != null)
            {
                candidate.LanguageOther = candidate.LanguageOther
                .Where(l => l.AdminView == false || (l.AdminView == true && l.CompanyUserId == companyUserId)).ToList();

                return candidate.Candidate_LanguageOther.ToList();
            }

            return null;
        }

        public List<CompanyDescription> CompanyDescriptionsByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            if (candidate.CompanyDescriptionList != null)
            {
                candidate.CompanyDescriptionList = candidate.CompanyDescriptionList
                .Where(c => c.CompanyUserId == companyUserId).ToList();

                return candidate.CompanyDescriptionList.ToList();
            }

            return null;
        }

        public List<CandidateCompany> CandidateCompaniesByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            if (candidate.CandidateCompanies != null)
            {
                candidate.CandidateCompanies = candidate.CandidateCompanies
                .Where(c => c.CompanyUserId == companyUserId).ToList();

                return candidate.CandidateCompanies.ToList();
            }

            return null;
        }

        public List<EmailDTO> EmailsByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            List<EmailDTO> emails = new List<EmailDTO>();

            if (candidate != null && candidate.BasicInformation != null && candidate.BasicInformation.Emails != null && candidate.BasicInformation.Emails.Count > 0)
            {
                foreach (Email email in candidate.BasicInformation.Emails)
                {
                    if (email.CompanyUserId == companyUserId)
                    {
                        EmailDTO emailDTO = _mapper.Map<Email, EmailDTO>(email);

                        emails.Add(emailDTO);
                    }
                }
            }

            return emails;
        }

        public List<PhoneDTO> PhonesByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            List<PhoneDTO> phones = new List<PhoneDTO>();

            if (candidate != null && candidate.BasicInformation != null && candidate.BasicInformation.Phones != null && candidate.BasicInformation.Phones.Count > 0)
            {
                foreach (Phone phone in candidate.BasicInformation.Phones)
                {
                    if (phone.CompanyUserId == companyUserId)
                    {
                        PhoneDTO phoneDTO = _mapper.Map<Phone, PhoneDTO>(phone);

                        phones.Add(phoneDTO);
                    }
                }
            }

            return phones;
        }

        public List<SocialNetworkDTO> SocialNetworksByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            List<SocialNetworkDTO> socialNetworks = new List<SocialNetworkDTO>();

            if (candidate != null && candidate.BasicInformation != null && candidate.BasicInformation.SocialNetworks != null && candidate.BasicInformation.SocialNetworks.Count > 0)
            {
                foreach (SocialNetwork socialNetwork in candidate.BasicInformation.SocialNetworks)
                {
                    if (socialNetwork.CompanyUserId == companyUserId)
                    {
                        SocialNetworkDTO socialNetworkDTO = _mapper.Map<SocialNetwork, SocialNetworkDTO>(socialNetwork);

                        socialNetworks.Add(socialNetworkDTO);
                    }
                }
            }

            return socialNetworks;
        }

        public List<UserLinkDTO> UserLinksByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            List<UserLinkDTO> userLinks = new List<UserLinkDTO>();

            if (candidate != null && candidate.BasicInformation != null && candidate.BasicInformation.UserLinks != null && candidate.BasicInformation.UserLinks.Count > 0)
            {
                foreach (UserLink userLink in candidate.BasicInformation.UserLinks)
                {
                    if (userLink.CompanyUserId == companyUserId)
                    {
                        UserLinkDTO userLinkDTO = _mapper.Map<UserLink, UserLinkDTO>(userLink);

                        userLinks.Add(userLinkDTO);
                    }
                }
            }

            return userLinks;
        }

        public CompanyDescriptionDTO CompanyDescriptionByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            CompanyDescriptionDTO companyDescription = new CompanyDescriptionDTO();

            if (candidate != null && candidate.CompanyDescriptionList != null && candidate.CompanyDescriptionList.Count > 0)
            {
                foreach (CompanyDescription description in candidate.CompanyDescriptionList)
                {
                    if (description.CompanyUserId == companyUserId)
                    {
                        companyDescription = _mapper.Map<CompanyDescription, CompanyDescriptionDTO>(description);

                        break;
                    }
                }
            }

            return companyDescription;
        }

        public List<Candidate_LanguageDTO> CandidateLanguagesByOverviewWithCompany(Candidate candidate)
        {
            List<Candidate_LanguageDTO> languages = new List<Candidate_LanguageDTO>();

            if (candidate != null && candidate.Candidate_Language != null && candidate.Candidate_Language.Count > 0)
            {
                foreach (Candidate_Language language in candidate.Candidate_Language)
                {
                    if (!language.AdminView)
                    {
                        Candidate_LanguageDTO newLanguage = _mapper.Map<Candidate_Language, Candidate_LanguageDTO>(language);

                        if (language.Language != null)
                            newLanguage.Language = _mapper.Map<Language, LanguageDTO>(language.Language);

                        if (language.LanguageLevel != null)
                            newLanguage.LanguageLevel = _mapper.Map<LanguageLevel, LanguageLevelDTO>(language.LanguageLevel);

                        languages.Add(newLanguage);
                    }
                }
            }

            return languages;
        }

        public List<Candidate_LanguageDTO> CompanyLanguagesByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            List<Candidate_LanguageDTO> languages = new List<Candidate_LanguageDTO>();

            if (candidate != null && candidate.Candidate_Language != null && candidate.Candidate_Language.Count > 0)
            {
                foreach (Candidate_Language language in candidate.Candidate_Language)
                {
                    if (language.AdminView && language.CompanyUserId == companyUserId)
                    {
                        Candidate_LanguageDTO newLanguage = _mapper.Map<Candidate_Language, Candidate_LanguageDTO>(language);

                        if (language.Language != null)
                            newLanguage.Language = _mapper.Map<Language, LanguageDTO>(language.Language);

                        if (language.LanguageLevel != null)
                            newLanguage.LanguageLevel = _mapper.Map<LanguageLevel, LanguageLevelDTO>(language.LanguageLevel);

                        languages.Add(newLanguage);
                    }
                }
            }

            return languages;
        }

        public List<Candidate_LanguageDTO> CandidateLanguagesOtherByOverviewWithCompany(Candidate candidate)
        {
            List<Candidate_LanguageDTO> languages = new List<Candidate_LanguageDTO>();

            if (candidate != null && candidate.LanguageOther != null && candidate.LanguageOther.Count > 0)
            {
                foreach (LanguageOther language in candidate.LanguageOther)
                {
                    if (!language.AdminView)
                    {
                        Candidate_LanguageDTO newLanguageDTO = new Candidate_LanguageDTO()
                        {
                            Candidate_LanguageId = language.LanguageOtherId,
                            CandidateId = language.CandidateId,
                            AdminView = language.AdminView,
                            LanguageOtherName = language.LanguageOtherName
                        };

                        languages.Add(newLanguageDTO);
                    }
                }
            }

            return languages;
        }

        public List<Candidate_LanguageDTO> CompanyLanguagesOtherByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            List<Candidate_LanguageDTO> languages = new List<Candidate_LanguageDTO>();

            if (candidate != null && candidate.LanguageOther != null && candidate.LanguageOther.Count > 0)
            {
                foreach (LanguageOther language in candidate.LanguageOther)
                {
                    if (language.AdminView && language.CompanyUserId == companyUserId)
                    {
                        Candidate_LanguageDTO newLanguageDTO = new Candidate_LanguageDTO()
                        {
                            Candidate_LanguageId = language.LanguageOtherId,
                            CandidateId = language.CandidateId,
                            AdminView = language.AdminView,
                            LanguageOtherName = language.LanguageOtherName
                        };

                        languages.Add(newLanguageDTO);
                    }
                }
            }

            return languages;
        }

        public List<Candidate_SoftSkillDTO> FullSoftSkillsByOverviewWithCompany(Candidate candidate)
        {
            List<Candidate_SoftSkillDTO> softSkills = new List<Candidate_SoftSkillDTO>();

            if (candidate != null && candidate.Candidate_SoftSkillList != null && candidate.Candidate_SoftSkillList.Count > 0)
            {
                foreach (Candidate_SoftSkill softSkill in candidate.Candidate_SoftSkillList)
                {
                    Candidate_SoftSkillDTO newsoftSkill = _mapper.Map<Candidate_SoftSkill, Candidate_SoftSkillDTO>(softSkill);

                    if (softSkill.SoftSkill != null)
                        newsoftSkill.SoftSkill = _mapper.Map<SoftSkill, SoftSkillDTO>(softSkill.SoftSkill);

                    if (newsoftSkill.SoftSkillId != 30)
                    {
                        newsoftSkill.SoftSkillName = newsoftSkill.SoftSkill.SoftSkillName;
                        newsoftSkill.SoftSkillNameEnglish = newsoftSkill.SoftSkill.SoftSkillNameEnglish;
                    }
                    else
                    {
                        newsoftSkill.SoftSkillName = newsoftSkill.Description;
                        newsoftSkill.SoftSkillNameEnglish = newsoftSkill.Description;
                    }

                    softSkills.Add(newsoftSkill);
                }
            }

            return softSkills;
        }

        public List<Candidate_SoftSkillDTO> CandidateSoftSkillsByOverviewWithCompany(Candidate candidate)
        {
            List<Candidate_SoftSkillDTO> softSkills = new List<Candidate_SoftSkillDTO>();

            if (candidate != null && candidate.Candidate_SoftSkillList != null && candidate.Candidate_SoftSkillList.Count > 0)
            {
                foreach (Candidate_SoftSkill softSkill in candidate.Candidate_SoftSkillList)
                {
                    if (!((bool)softSkill.IsFromEmpresaAdded))
                    {
                        Candidate_SoftSkillDTO newsoftSkill = _mapper.Map<Candidate_SoftSkill, Candidate_SoftSkillDTO>(softSkill);

                        if (softSkill.SoftSkill != null)
                            newsoftSkill.SoftSkill = _mapper.Map<SoftSkill, SoftSkillDTO>(softSkill.SoftSkill);

                        if (newsoftSkill.SoftSkillId != 30)
                        {
                            newsoftSkill.SoftSkillName = newsoftSkill.SoftSkill.SoftSkillName;
                            newsoftSkill.SoftSkillNameEnglish = newsoftSkill.SoftSkill.SoftSkillNameEnglish;
                        }
                        else
                        {
                            newsoftSkill.SoftSkillName = newsoftSkill.Description;
                            newsoftSkill.SoftSkillNameEnglish = newsoftSkill.Description;
                        }

                        softSkills.Add(newsoftSkill);
                    }
                }
            }

            return softSkills;
        }

        public List<Candidate_SoftSkillDTO> CompanySoftSkillsByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            List<Candidate_SoftSkillDTO> softSkills = new List<Candidate_SoftSkillDTO>();

            if (candidate != null && candidate.Candidate_SoftSkillList != null && candidate.Candidate_SoftSkillList.Count > 0)
            {
                foreach (Candidate_SoftSkill softSkill in candidate.Candidate_SoftSkillList)
                {
                    if (((bool)softSkill.IsFromEmpresaAdded) && softSkill.CompanyUserId == companyUserId)
                    {
                        Candidate_SoftSkillDTO newsoftSkill = _mapper.Map<Candidate_SoftSkill, Candidate_SoftSkillDTO>(softSkill);

                        if (softSkill.SoftSkill != null)
                            newsoftSkill.SoftSkill = _mapper.Map<SoftSkill, SoftSkillDTO>(softSkill.SoftSkill);

                        if (newsoftSkill.SoftSkillId != 30)
                        {
                            newsoftSkill.SoftSkillName = newsoftSkill.SoftSkill.SoftSkillName;
                            newsoftSkill.SoftSkillNameEnglish = newsoftSkill.SoftSkill.SoftSkillNameEnglish;
                        }
                        else
                        {
                            newsoftSkill.SoftSkillName = newsoftSkill.Description;
                            newsoftSkill.SoftSkillNameEnglish = newsoftSkill.Description;
                        }

                        softSkills.Add(newsoftSkill);
                    }
                }
            }

            return softSkills;
        }

        public List<Candidate_TechnicalAbilityDTO> FullTechnicalAbilitiesByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            List<Candidate_TechnicalAbilityDTO> technicalAbilities = new List<Candidate_TechnicalAbilityDTO>();

            if (candidate != null && candidate.Candidate_TechnicalAbilityList != null && candidate.Candidate_TechnicalAbilityList.Count > 0)
            {
                foreach (Candidate_TechnicalAbility technicalAbility in candidate.Candidate_TechnicalAbilityList)
                {
                    if (!((bool)technicalAbility.IsFromEmpresaAdded) || (((bool)technicalAbility.IsFromEmpresaAdded) && technicalAbility.CompanyUserId == companyUserId))
                    {
                        Candidate_TechnicalAbilityDTO technicalAbilityDTO = _mapper.Map<Candidate_TechnicalAbility, Candidate_TechnicalAbilityDTO>(technicalAbility);

                        if (technicalAbility.TechnicalAbilityTechnologyId == 54)
                            technicalAbilityDTO.TechnicalAbilityTechnologyName = technicalAbility.Other;
                        else
                            technicalAbilityDTO.TechnicalAbilityTechnologyName = technicalAbility.Discipline;

                        if (technicalAbility.TechnicalAbilityTechnology != null)
                            technicalAbilityDTO.TechnicalAbilityTechnology = _mapper.Map<TechnicalAbilityTechnology, TechnicalAbilityTechnologyDTO>(technicalAbility.TechnicalAbilityTechnology);

                        if (technicalAbility.TechnicalAbilityLevel != null)
                            technicalAbilityDTO.TechnicalAbilityLevel = _mapper.Map<TechnicalAbilityLevel, TechnicalAbilityLevelDTO>(technicalAbility.TechnicalAbilityLevel);

                        technicalAbilities.Add(technicalAbilityDTO);
                    }
                }
            }

            return technicalAbilities;
        }

        public List<Candidate_TechnicalAbilityDTO> CandidateTechnicalAbilitiesByOverviewWithCompany(Candidate candidate)
        {
            List<Candidate_TechnicalAbilityDTO> technicalAbilities = new List<Candidate_TechnicalAbilityDTO>();

            if (candidate != null && candidate.Candidate_TechnicalAbilityList != null && candidate.Candidate_TechnicalAbilityList.Count > 0)
            {
                foreach (Candidate_TechnicalAbility technicalAbility in candidate.Candidate_TechnicalAbilityList)
                {
                    if (!((bool)technicalAbility.IsFromEmpresaAdded))
                    {
                        Candidate_TechnicalAbilityDTO technicalAbilityDTO = _mapper.Map<Candidate_TechnicalAbility, Candidate_TechnicalAbilityDTO>(technicalAbility);

                        if (technicalAbility.TechnicalAbilityTechnologyId == 54)
                            technicalAbilityDTO.TechnicalAbilityTechnologyName = technicalAbility.Other;
                        else
                            technicalAbilityDTO.TechnicalAbilityTechnologyName = technicalAbility.Discipline;

                        if (technicalAbility.TechnicalAbilityTechnology != null)
                            technicalAbilityDTO.TechnicalAbilityTechnology = _mapper.Map<TechnicalAbilityTechnology, TechnicalAbilityTechnologyDTO>(technicalAbility.TechnicalAbilityTechnology);

                        if (technicalAbility.TechnicalAbilityLevel != null)
                            technicalAbilityDTO.TechnicalAbilityLevel = _mapper.Map<TechnicalAbilityLevel, TechnicalAbilityLevelDTO>(technicalAbility.TechnicalAbilityLevel);

                        technicalAbilities.Add(technicalAbilityDTO);
                    }
                }
            }

            return technicalAbilities;
        }

        public List<Candidate_TechnicalAbilityDTO> CompanyTechnicalAbilitiesByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            List<Candidate_TechnicalAbilityDTO> technicalAbilities = new List<Candidate_TechnicalAbilityDTO>();

            if (candidate != null && candidate.Candidate_TechnicalAbilityList != null && candidate.Candidate_TechnicalAbilityList.Count > 0)
            {
                foreach (Candidate_TechnicalAbility technicalAbility in candidate.Candidate_TechnicalAbilityList)
                {
                    if (((bool)technicalAbility.IsFromEmpresaAdded) && technicalAbility.CompanyUserId == companyUserId)
                    {
                        Candidate_TechnicalAbilityDTO technicalAbilityDTO = _mapper.Map<Candidate_TechnicalAbility, Candidate_TechnicalAbilityDTO>(technicalAbility);

                        if (technicalAbility.TechnicalAbilityTechnologyId == 54)
                            technicalAbilityDTO.TechnicalAbilityTechnologyName = technicalAbility.Other;
                        else
                            technicalAbilityDTO.TechnicalAbilityTechnologyName = technicalAbility.Discipline;

                        if (technicalAbility.TechnicalAbilityTechnology != null)
                            technicalAbilityDTO.TechnicalAbilityTechnology = _mapper.Map<TechnicalAbilityTechnology, TechnicalAbilityTechnologyDTO>(technicalAbility.TechnicalAbilityTechnology);

                        if (technicalAbility.TechnicalAbilityLevel != null)
                            technicalAbilityDTO.TechnicalAbilityLevel = _mapper.Map<TechnicalAbilityLevel, TechnicalAbilityLevelDTO>(technicalAbility.TechnicalAbilityLevel);

                        technicalAbilities.Add(technicalAbilityDTO);
                    }
                }
            }

            return technicalAbilities;
        }

        public async Task<List<StudyDTO>> FullStudiesByOverviewWithCompany(Candidate candidate, int companyUserId, string token)
        {
            List<StudyDTO> studies = new List<StudyDTO>();

            if (candidate != null && candidate.StudyList != null && candidate.StudyList.Count > 0)
            {
                foreach (Study study in candidate.StudyList)
                {
                    if ((study.IsFromCandidate) || ((!study.IsFromCandidate) && study.CompanyUserId == companyUserId))
                    {
                        StudyDTO newStudy = _mapper.Map<Study, StudyDTO>(study);

                        /**/

                        var jobProfession = await _jobProfessionService.GetJobProfessionById(newStudy.JobProfessionId);

                        if (jobProfession != null)
                        {
                            newStudy.JobProfession = jobProfession.Profession;
                            newStudy.JobProfessionEnglish = jobProfession.ProfessionEnglish;
                        }

                        /**/

                        if (study.StudyArea != null)
                            newStudy.StudyArea = _mapper.Map<StudyArea, StudyAreaDTO>(study.StudyArea);

                        if (study.StudyCertificate != null)
                            newStudy.StudyCertificate = _mapper.Map<StudyCertificate, StudyCertificateDTO>(study.StudyCertificate);

                        if (study.StudyState != null)
                            newStudy.StudyState = _mapper.Map<StudyState, StudyStateDTO>(study.StudyState);

                        if (study.CertificationState != null)
                            newStudy.CertificationState = _mapper.Map<CertificationState, CertificationStateDTO>(study.CertificationState);

                        if (study.StudyType != null)
                            newStudy.StudyType = _mapper.Map<StudyType, StudyTypeDTO>(study.StudyType);

                        if (study.Title != null)
                            newStudy.Title = _mapper.Map<Title, TitleDTO>(study.Title);

                        if (!string.IsNullOrEmpty(newStudy.StartDate))
                            newStudy.CompareDate = double.Parse(newStudy.StartDate);
                        else if (!string.IsNullOrEmpty(newStudy.EndDate))
                            newStudy.CompareDate = double.Parse(newStudy.EndDate);

                        studies.Add(newStudy);
                    }
                }
            }

            return studies;
        }

        public List<StudyDTO> CandidateStudiesByOverviewWithCompany(Candidate candidate)
        {
            List<StudyDTO> studies = new List<StudyDTO>();

            if (candidate != null && candidate.StudyList != null && candidate.StudyList.Count > 0)
            {
                foreach (Study study in candidate.StudyList)
                {
                    if (study.IsFromCandidate)
                    {
                        StudyDTO newStudy = _mapper.Map<Study, StudyDTO>(study);

                        if (study.StudyArea != null)
                            newStudy.StudyArea = _mapper.Map<StudyArea, StudyAreaDTO>(study.StudyArea);

                        if (study.StudyCertificate != null)
                            newStudy.StudyCertificate = _mapper.Map<StudyCertificate, StudyCertificateDTO>(study.StudyCertificate);

                        if (study.StudyState != null)
                            newStudy.StudyState = _mapper.Map<StudyState, StudyStateDTO>(study.StudyState);

                        if (study.CertificationState != null)
                            newStudy.CertificationState = _mapper.Map<CertificationState, CertificationStateDTO>(study.CertificationState);

                        if (study.StudyType != null)
                            newStudy.StudyType = _mapper.Map<StudyType, StudyTypeDTO>(study.StudyType);

                        if (study.Title != null)
                            newStudy.Title = _mapper.Map<Title, TitleDTO>(study.Title);

                        if (newStudy.StartDate != null)
                            newStudy.CompareDate = double.Parse(newStudy.StartDate);
                        else if (newStudy.EndDate != null)
                            newStudy.CompareDate = double.Parse(newStudy.EndDate);

                        studies.Add(newStudy);
                    }
                }
            }

            return studies;
        }

        public List<StudyDTO> CompanyStudiesByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            List<StudyDTO> studies = new List<StudyDTO>();

            if (candidate != null && candidate.StudyList != null && candidate.StudyList.Count > 0)
            {
                foreach (Study study in candidate.StudyList)
                {
                    if (!study.IsFromCandidate && study.CompanyUserId == companyUserId)
                    {
                        StudyDTO newStudy = _mapper.Map<Study, StudyDTO>(study);

                        if (study.StudyArea != null)
                            newStudy.StudyArea = _mapper.Map<StudyArea, StudyAreaDTO>(study.StudyArea);

                        if (study.StudyCertificate != null)
                            newStudy.StudyCertificate = _mapper.Map<StudyCertificate, StudyCertificateDTO>(study.StudyCertificate);

                        if (study.StudyState != null)
                            newStudy.StudyState = _mapper.Map<StudyState, StudyStateDTO>(study.StudyState);

                        if (study.CertificationState != null)
                            newStudy.CertificationState = _mapper.Map<CertificationState, CertificationStateDTO>(study.CertificationState);

                        if (study.StudyType != null)
                            newStudy.StudyType = _mapper.Map<StudyType, StudyTypeDTO>(study.StudyType);

                        if (study.Title != null)
                            newStudy.Title = _mapper.Map<Title, TitleDTO>(study.Title);

                        if (!string.IsNullOrEmpty(newStudy.StartDate))
                            newStudy.CompareDate = double.Parse(newStudy.StartDate);
                        else if (!string.IsNullOrEmpty(newStudy.EndDate))
                            newStudy.CompareDate = double.Parse(newStudy.EndDate);

                        studies.Add(newStudy);
                    }
                }
            }

            return studies;
        }

        public List<WorkExperienceDTO> FullWorkExperiencesByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            List<WorkExperienceDTO> workExperiences = new List<WorkExperienceDTO>();

            if (candidate != null && candidate.WorkExperienceList != null && candidate.WorkExperienceList.Count > 0)
            {
                foreach (WorkExperience workExperience in candidate.WorkExperienceList)
                {
                    if (!((bool)workExperience.AdminView) || (((bool)workExperience.AdminView) && workExperience.CompanyUserId == companyUserId))
                    {
                        WorkExperienceDTO newWorkExperience = _mapper.Map<WorkExperience, WorkExperienceDTO>(workExperience);

                        if (workExperience.Industry != null)
                            newWorkExperience.industry = _mapper.Map<Industry, IndustryDTO>(workExperience.Industry);

                        if (workExperience.EquivalentPosition != null)
                            newWorkExperience.EquivalentPositionGroup = _mapper.Map<EquivalentPosition, EquivalentPositionDTO>(workExperience.EquivalentPosition);

                        workExperiences.Add(newWorkExperience);
                    }
                }
            }

            return workExperiences;
        }

        public List<WorkExperienceDTO> FullWorkExperiencesByOverviewWithCompanyOrderByCurrentWorking(Candidate candidate, int companyUserId)
        {
            List<WorkExperienceDTO> workExperiences = new List<WorkExperienceDTO>();

            if (candidate != null && candidate.WorkExperienceList != null && candidate.WorkExperienceList.Count > 0)
            {
                foreach (WorkExperience workExperience in candidate.WorkExperienceList)
                {
                    if (!((bool)workExperience.AdminView) || (((bool)workExperience.AdminView) && workExperience.CompanyUserId == companyUserId))
                    {
                        WorkExperienceDTO newWorkExperience = _mapper.Map<WorkExperience, WorkExperienceDTO>(workExperience);

                        if (workExperience.Industry != null)
                            newWorkExperience.industry = _mapper.Map<Industry, IndustryDTO>(workExperience.Industry);

                        if (workExperience.EquivalentPosition != null)
                            newWorkExperience.EquivalentPositionGroup = _mapper.Map<EquivalentPosition, EquivalentPositionDTO>(workExperience.EquivalentPosition);

                        workExperiences.Add(newWorkExperience);
                    }
                }

                workExperiences = workExperiences.OrderByDescending(x => !string.IsNullOrEmpty(x.EndDate) ? new DateTime(long.Parse(x.EndDate)) : DateTime.Now)
                    /*.ThenBy(x => !string.IsNullOrEmpty(x.StartDate) ? new DateTime(long.Parse(x.StartDate)) : DateTime.Now)*/.ToList();
            }

            return workExperiences;
        }

        public List<WorkExperienceDTO> CandidateWorkExperiencesByOverviewWithCompany(Candidate candidate)
        {
            List<WorkExperienceDTO> workExperiences = new List<WorkExperienceDTO>();

            if (candidate != null && candidate.WorkExperienceList != null && candidate.WorkExperienceList.Count > 0)
            {
                foreach (WorkExperience workExperience in candidate.WorkExperienceList)
                {
                    if (!workExperience.AdminView)
                    {
                        WorkExperienceDTO newWorkExperience = _mapper.Map<WorkExperience, WorkExperienceDTO>(workExperience);

                        if (workExperience.Industry != null)
                            newWorkExperience.industry = _mapper.Map<Industry, IndustryDTO>(workExperience.Industry);

                        if (workExperience.EquivalentPosition != null)
                            newWorkExperience.EquivalentPositionGroup = _mapper.Map<EquivalentPosition, EquivalentPositionDTO>(workExperience.EquivalentPosition);

                        workExperiences.Add(newWorkExperience);
                    }
                }
            }

            return workExperiences;
        }

        public List<WorkExperienceDTO> CompanyWorkExperiencesByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            List<WorkExperienceDTO> workExperiences = new List<WorkExperienceDTO>();

            if (candidate != null && candidate.WorkExperienceList != null && candidate.WorkExperienceList.Count > 0)
            {
                foreach (WorkExperience workExperience in candidate.WorkExperienceList)
                {
                    if (workExperience.AdminView && workExperience.CompanyUserId == companyUserId)
                    {
                        WorkExperienceDTO newWorkExperience = _mapper.Map<WorkExperience, WorkExperienceDTO>(workExperience);

                        if (workExperience.Industry != null)
                            newWorkExperience.industry = _mapper.Map<Industry, IndustryDTO>(workExperience.Industry);

                        if (workExperience.EquivalentPosition != null)
                            newWorkExperience.EquivalentPositionGroup = _mapper.Map<EquivalentPosition, EquivalentPositionDTO>(workExperience.EquivalentPosition);

                        workExperiences.Add(newWorkExperience);
                    }
                }
            }

            return workExperiences;
        }

        public List<PersonalReferenceDTO> CandidatePersonalReferencesByOverviewWithCompany(Candidate candidate)
        {
            List<PersonalReferenceDTO> personalReferences = [];

            if (candidate != null && candidate.PersonalReferenceList != null && candidate.PersonalReferenceList.Count > 0)
            {
                foreach (PersonalReference personalReference in candidate.PersonalReferenceList)
                {
                    if (!((bool)personalReference.IsAddefromCompany))
                    {
                        PersonalReferenceDTO newPersonalReference = _mapper.Map<PersonalReference, PersonalReferenceDTO>(personalReference);

                        if (personalReference.RelationType != null)
                        {
                            if(personalReference.RelationType.RelationTypeId == 4)
                            {
                                personalReference.RelationType.Name = personalReference.OtherRelationtype;
                                personalReference.RelationType.NameEnglish = personalReference.OtherRelationtype;
                            }

                            newPersonalReference.RelationType = _mapper.Map<RelationType, RelationTypeDTO>(personalReference.RelationType);
                        }

                        personalReferences.Add(newPersonalReference);
                    }
                }
            }

            return personalReferences;
        }

        public List<PersonalReferenceDTO> CompanyPersonalReferencesByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            List<PersonalReferenceDTO> personalReferences = new List<PersonalReferenceDTO>();

            if (candidate != null && candidate.PersonalReferenceList != null && candidate.PersonalReferenceList.Count > 0)
            {
                foreach (PersonalReference personalReference in candidate.PersonalReferenceList)
                {
                    if (((bool)personalReference.IsAddefromCompany) && personalReference.CompanyUserId == companyUserId)
                    {
                        PersonalReferenceDTO newPersonalReference = _mapper.Map<PersonalReference, PersonalReferenceDTO>(personalReference);

                        if (personalReference.RelationType != null)
                        {

                            if (personalReference.RelationType.RelationTypeId == 4)
                            {
                                personalReference.RelationType.Name = personalReference.OtherRelationtype;
                                personalReference.RelationType.NameEnglish = personalReference.OtherRelationtype;
                            }

                            newPersonalReference.RelationType = _mapper.Map<RelationType, RelationTypeDTO>(personalReference.RelationType);
                        }

                        personalReferences.Add(newPersonalReference);
                    }
                }
            }

            return personalReferences;
        }

        public List<Candidate_LifePreferenceDTO> CandidateLifePreferencesByOverviewWithCompany(Candidate candidate)
        {
            List<Candidate_LifePreferenceDTO> lifePreferences = new List<Candidate_LifePreferenceDTO>();

            if (candidate != null && candidate.Candidate_LifePreferenceList != null && candidate.Candidate_LifePreferenceList.Count > 0)
            {
                foreach (Candidate_LifePreference lifePreference in candidate.Candidate_LifePreferenceList)
                {
                    if (lifePreference.IsFromCandidate)
                    {
                        Candidate_LifePreferenceDTO newLifePreference = _mapper.Map<Candidate_LifePreference, Candidate_LifePreferenceDTO>(lifePreference);

                        if (lifePreference.LifePreference != null)
                            newLifePreference.LifePreference = _mapper.Map<LifePreference, LifePreferenceDTO>(lifePreference.LifePreference);

                        lifePreferences.Add(newLifePreference);
                    }
                }
            }

            return lifePreferences;
        }

        public List<Candidate_LifePreferenceDTO> CompanyLifePreferencesByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            List<Candidate_LifePreferenceDTO> lifePreferences = new List<Candidate_LifePreferenceDTO>();

            if (candidate != null && candidate.Candidate_LifePreferenceList != null && candidate.Candidate_LifePreferenceList.Count > 0)
            {
                foreach (Candidate_LifePreference lifePreference in candidate.Candidate_LifePreferenceList)
                {
                    if (!lifePreference.IsFromCandidate && lifePreference.CompanyUserId == companyUserId)
                    {
                        Candidate_LifePreferenceDTO newLifePreference = _mapper.Map<Candidate_LifePreference, Candidate_LifePreferenceDTO>(lifePreference);

                        if (lifePreference.LifePreference != null)
                            newLifePreference.LifePreference = _mapper.Map<LifePreference, LifePreferenceDTO>(lifePreference.LifePreference);

                        lifePreferences.Add(newLifePreference);
                    }
                }
            }

            return lifePreferences;
        }

        public Candidate_JobPreferenceDto CandidateJobPreferencesByOverviewWithCompany(Candidate candidate)
        {
            Candidate_JobPreferenceDto jobPreferences = new Candidate_JobPreferenceDto();

            List<Candidate_Wellness> candidateWellness = candidate.Candidate_Wellness.ToList();
            List<Candidate_TimeAvailability> candidate_TimeAvailabilities = candidate.Candidate_TimeAvailability.ToList();

            if (candidateWellness.Count > 0 || candidate_TimeAvailabilities.Count > 0)
            {
                List<WellnessDTO> wellnessList = new List<WellnessDTO>();
                List<TimeAvailabilityDTO> timeAvailabilityList = new List<TimeAvailabilityDTO>();

                foreach (Candidate_Wellness wellness in candidateWellness)
                {
                    WellnessDTO wellnessDTO = new WellnessDTO
                    {
                        WellnessId = wellness.WellnessId,
                        WellnessName = wellness.Wellness.WellnessName,
                        WellnessNameEnglish = wellness.Wellness.WellnessNameEnglish
                    };

                    wellnessList.Add(wellnessDTO);
                }

                foreach (Candidate_TimeAvailability timeAvailability in candidate_TimeAvailabilities)
                {
                    TimeAvailabilityDTO timeAvailabilityDTO = new TimeAvailabilityDTO
                    {
                        TimeAvailabilityId = timeAvailability.TimeAvailabilityId,
                        TimeAvailabilityName = timeAvailability.TimeAvailability.TimeAvailabilityName,
                        TimeAvailabilityNameEnglish = timeAvailability.TimeAvailability.TimeAvailabilityNameEnglish
                    };

                    timeAvailabilityList.Add(timeAvailabilityDTO);
                }

                jobPreferences = new Candidate_JobPreferenceDto()
                {
                    CandidateId = candidate.CandidateId,
                    WellnessList = wellnessList,
                    TimeAvailabilityList = timeAvailabilityList
                };
            }

            return jobPreferences;
        }

        public Company_Candidate_JobPreferenceDto CompanyJobPreferencesByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            Company_Candidate_JobPreferenceDto jobPreferences = new Company_Candidate_JobPreferenceDto();

            List<Company_Candidate_Wellness> candidateWellness = candidate.Company_Candidate_Wellness.ToList();
            List<Company_Candidate_TimeAvailability> candidate_TimeAvailabilities = candidate.Company_Candidate_TimeAvailability.ToList();

            if (candidateWellness.Count > 0 || candidate_TimeAvailabilities.Count > 0)
            {
                List<WellnessDTO> wellnessList = new List<WellnessDTO>();
                List<TimeAvailabilityDTO> timeAvailabilityList = new List<TimeAvailabilityDTO>();

                foreach (Company_Candidate_Wellness wellness in candidateWellness)
                {
                    WellnessDTO wellnessDTO = new WellnessDTO
                    {
                        WellnessId = wellness.WellnessId,
                        WellnessName = wellness.Wellness.WellnessName,
                        WellnessNameEnglish = wellness.Wellness.WellnessNameEnglish
                    };

                    wellnessList.Add(wellnessDTO);
                }

                foreach (Company_Candidate_TimeAvailability timeAvailability in candidate_TimeAvailabilities)
                {
                    TimeAvailabilityDTO timeAvailabilityDTO = new TimeAvailabilityDTO
                    {
                        TimeAvailabilityId = timeAvailability.TimeAvailabilityId,
                        TimeAvailabilityName = timeAvailability.TimeAvailability.TimeAvailabilityName,
                        TimeAvailabilityNameEnglish = timeAvailability.TimeAvailability.TimeAvailabilityNameEnglish
                    };

                    timeAvailabilityList.Add(timeAvailabilityDTO);
                }

                jobPreferences = new Company_Candidate_JobPreferenceDto()
                {
                    CandidateId = candidate.CandidateId,
                    WellnessList = wellnessList,
                    TimeAvailabilityList = timeAvailabilityList
                };
            }

            return jobPreferences;
        }

        public async Task<List<NoteDTO>> NotesByOverviewWithCompany(Candidate candidate, MemberUserDTO memberUser, List<MemberUserDTO> memberList)
        {
            var memberResponse = memberUser;
            var memberUserList = memberList;

            //The owner notes are obtained by pin up date and by creation date in ascending order,
            //at the end of the iteration the list is reversed to deliver the notes in order.
            List<Note> notesOwners = await _noteRepository.GetAllNoteOwners(candidate.CandidateId, memberResponse.CompanyUserId);
            List<Note> notesAnswers = await _noteRepository.GetAllNoteAnswers(candidate.CandidateId, memberResponse.CompanyUserId);
            List<NoteDTO> notesOwnersDTO = _mapper.Map<List<Note>, List<NoteDTO>>(notesOwners);
            List<NoteDTO> notesAnswersDTO = _mapper.Map<List<Note>, List<NoteDTO>>(notesAnswers);

            List<NoteDTO> notesListDTO = new List<NoteDTO>();

            foreach (var noteOwnerDTO in notesOwnersDTO)
            {
                var initialsOwner = "";
                var photoOwner = "";
                noteOwnerDTO.CreationInfo = _uploadTimeService.GetNoteCreationInfo(noteOwnerDTO.CreationDate);
                noteOwnerDTO.CreationShortInfo = _uploadTimeService.GetNoteCreationShortInfo(noteOwnerDTO.CreationDate);
                noteOwnerDTO.CreationInfoPup = _uploadTimeService.GetFileTypeCreationInfoPup(noteOwnerDTO.CreationDate);
                noteOwnerDTO.SortedDate = _uploadTimeService.GetDateWithString(noteOwnerDTO.CreationDate);
                if (noteOwnerDTO.FileIdentifier != null)
                    noteOwnerDTO.IdentifierLink = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + noteOwnerDTO.FileIdentifier;

                var memberAvailableOwner = memberUserList.Where(x => x.Email == noteOwnerDTO.EmailMember).FirstOrDefault();

                if (memberAvailableOwner != null)
                {
                    noteOwnerDTO.Available = true;
                    if (memberAvailableOwner.Name != null && !string.IsNullOrEmpty(memberAvailableOwner.Name)
                        && memberAvailableOwner.Surname != null && !string.IsNullOrEmpty(memberAvailableOwner.Surname))
                    {
                        var first = memberAvailableOwner.Name[0].ToString();
                        var second = memberAvailableOwner.Surname[0].ToString();

                        if (memberAvailableOwner.Photo != null)
                            photoOwner = memberAvailableOwner.Photo;

                        initialsOwner = (first + second).ToUpper();
                        noteOwnerDTO.InitialsMember = initialsOwner;
                        noteOwnerDTO.NameMemberUser = memberAvailableOwner.Name;
                        noteOwnerDTO.SurnameMemberUser = memberAvailableOwner.Surname;
                        noteOwnerDTO.PhotoMember = photoOwner;
                    }
                }
                else
                    noteOwnerDTO.Available = false;

                List<NoteDTO> notesAnswersListDTO = new List<NoteDTO>();
                foreach (var noteAnswerDTO in notesAnswersDTO)
                {
                    var initialsAnswer = "";
                    var photoAnswer = "";
                    if (noteAnswerDTO.NoteOwnerId == noteOwnerDTO.NoteId)
                    {
                        noteAnswerDTO.CreationInfo = _uploadTimeService.GetNoteCreationInfo(noteAnswerDTO.CreationDate);
                        noteAnswerDTO.CreationShortInfo = _uploadTimeService.GetNoteCreationShortInfo(noteAnswerDTO.CreationDate);
                        noteAnswerDTO.CreationInfoPup = _uploadTimeService.GetFileTypeCreationInfoPup(noteAnswerDTO.CreationDate);

                        var memberAvailableAnswer = memberUserList.Where(x => x.Email == noteAnswerDTO.EmailMember).FirstOrDefault();
                        if (noteAnswerDTO.FileIdentifier != null)
                            noteAnswerDTO.IdentifierLink = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + noteAnswerDTO.FileIdentifier;

                        if (memberAvailableAnswer != null)
                        {
                            noteAnswerDTO.Available = true;
                            if (memberAvailableAnswer.Name != null && !string.IsNullOrEmpty(memberAvailableAnswer.Name)
                                && memberAvailableAnswer.Surname != null && !string.IsNullOrEmpty(memberAvailableAnswer.Surname))
                            {
                                var first = memberAvailableAnswer.Name[0].ToString();
                                var second = memberAvailableAnswer.Surname[0].ToString();

                                if (memberAvailableAnswer.Photo != null)
                                    photoAnswer = memberAvailableAnswer.Photo;

                                initialsAnswer = (first + second).ToUpper();
                                noteAnswerDTO.InitialsMember = initialsAnswer;
                                noteAnswerDTO.NameMemberUser = memberAvailableAnswer.Name;
                                noteAnswerDTO.SurnameMemberUser = memberAvailableAnswer.Surname;
                                noteAnswerDTO.PhotoMember = photoAnswer;
                            }
                        }
                        else
                            noteAnswerDTO.Available = false;

                        notesAnswersListDTO.Add(noteAnswerDTO);
                    }
                }

                noteOwnerDTO.notesAnswers = notesAnswersListDTO;
                notesListDTO.Add(noteOwnerDTO);
            }

            notesListDTO = notesListDTO.OrderByDescending(x => x.DatePinUp).ThenByDescending(x => x.SortedDate).ToList();

            return notesListDTO;
        }

        public async Task<DocumentCheckStructureDTO> DocumentChecksByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            try
            {
                DocumentCheckStructureDTO currentCheckStructure = new DocumentCheckStructureDTO();

                List<DocumentCheck> currentDocumentChecks = await _documentCheckRepository.GetAllByCandidateId(candidate.CandidateId, companyUserId);

                DocumentCheckStructureDTO documentCheckStructureDTO = new DocumentCheckStructureDTO();
                List<DocumentCheckGroupDTO> documentCheckGroupsDTO = new List<DocumentCheckGroupDTO>();

                List<DocumentCheckGroup> documentCheckGroups = await _documentCheckGroupRepository.GetAll();

                foreach (DocumentCheckGroup documentCheckGroup in documentCheckGroups)
                {
                    DocumentCheckGroupDTO documentCheckGroupDTO = new DocumentCheckGroupDTO
                    {
                        DocumentCheckGroupId = documentCheckGroup.DocumentCheckGroupId,
                        Name = documentCheckGroup.Name,
                        NameEnglish = documentCheckGroup.NameEnglish
                    };

                    documentCheckGroupsDTO.Add(documentCheckGroupDTO);
                }

                if (currentDocumentChecks == null || currentDocumentChecks.Count == 0)
                {
                    /* HOJA DE VIDA */

                    /* Hoja de vida */
                    CV cvDB = await _cvRepository.GetByCandidateIdToCandidate(candidate.CandidateId);
                    CV cvOverViewDB = await _cvRepository.ExsistOverViewCvByCandidateId(candidate.CandidateId);

                    DocumentCheck cv = new DocumentCheck
                    {
                        OrderId = 1,
                        CandidateId = candidate.CandidateId,
                        DocumentCheckGroupId = 1,
                        DocumentCheckStateId = 1,
                        IsCheck = false,
                        IsEnabled = false,
                        CompanyUserId = companyUserId,
                        Name = "Hoja de vida",
                        NameEnglish = "Resume"
                    };

                    if (cvDB != null || cvOverViewDB != null)
                        cv.IsCheck = true;

                    /* SOPORTES */

                    /* Académicos */
                    List<Study> studies = await _studyRepository.GetByCandidateId(candidate.CandidateId);
                    bool existStudy = false;

                    if (studies != null && studies.Count > 0)
                        foreach (Study study in studies)
                        {
                            StudyCertificate certificate = await _studyCertificateRepository.GetByStudyId(study.StudyId);

                            if (certificate != null)
                            {
                                existStudy = true;

                                break;
                            }
                        }

                    DocumentCheck academics = new DocumentCheck
                    {
                        OrderId = 2,
                        CandidateId = candidate.CandidateId,
                        DocumentCheckGroupId = 2,
                        DocumentCheckStateId = 3,
                        IsCheck = existStudy,
                        IsEnabled = true,
                        CompanyUserId = companyUserId,
                        Name = "Académicos",
                        NameEnglish = "Academics"
                    };

                    if (await _documentCheckRepository.ExistByOrderId(2, companyUserId))
                    {
                        List<DocumentCheck> oldDocChecks = await _documentCheckRepository.GetAllByCandidateIdAndOrderId(candidate.CandidateId, 2, companyUserId);

                        if (currentCheckStructure != null && currentCheckStructure.DocumentCheckGroups != null && currentCheckStructure.DocumentCheckGroups.Count > 0)
                        {
                            foreach (DocumentCheckGroupDTO group in currentCheckStructure.DocumentCheckGroups)
                                if (group.DocumentCheckGroupId == 2 && group.DocumentCheckItems != null && group.DocumentCheckItems.Count > 0)
                                    foreach (DocumentCheckDTO item in group.DocumentCheckItems)
                                        if (item.OrderId == 2)
                                            academics.IsCheck = item.IsCheck;
                        }
                        else if (oldDocChecks != null && oldDocChecks.Count > 0)
                            foreach (var oldCheck in oldDocChecks)
                                academics.IsCheck = oldCheck.IsCheck;
                    }

                    /* Referencias laborales */
                    DocumentCheck workReferences = new DocumentCheck
                    {
                        OrderId = 3,
                        CandidateId = candidate.CandidateId,
                        DocumentCheckGroupId = 2,
                        DocumentCheckStateId = 2,
                        IsCheck = false,
                        IsEnabled = true,
                        CompanyUserId = companyUserId,
                        Name = "Referencias laborales",
                        NameEnglish = "Work references"
                    };

                    if (await _documentCheckRepository.ExistByOrderId(3, companyUserId))
                    {
                        List<DocumentCheck> oldDocChecks = await _documentCheckRepository.GetAllByCandidateIdAndOrderId(candidate.CandidateId, 3, companyUserId);

                        if (currentCheckStructure != null && currentCheckStructure.DocumentCheckGroups != null && currentCheckStructure.DocumentCheckGroups.Count > 0)
                        {
                            foreach (DocumentCheckGroupDTO group in currentCheckStructure.DocumentCheckGroups)
                                if (group.DocumentCheckGroupId == 2 && group.DocumentCheckItems != null && group.DocumentCheckItems.Count > 0)
                                    foreach (DocumentCheckDTO item in group.DocumentCheckItems)
                                        if (item.OrderId == 3)
                                            workReferences.IsCheck = item.IsCheck;
                        }
                        else if (oldDocChecks != null && oldDocChecks.Count > 0)
                            foreach (var oldCheck in oldDocChecks)
                                workReferences.IsCheck = oldCheck.IsCheck;
                    }

                    /* Pruebas psicotécnicas */
                    List<AttachedFile> psicotechnicalTestsFiles = await _attachedFileRepository.GetByFileTypeAndCandidateId(candidate.CandidateId, 2);

                    DocumentCheck psicotechnicalTests = new DocumentCheck
                    {
                        OrderId = 4,
                        CandidateId = candidate.CandidateId,
                        DocumentCheckGroupId = 2,
                        DocumentCheckStateId = 1,
                        IsCheck = false,
                        IsEnabled = false,
                        CompanyUserId = companyUserId,
                        Name = "Pruebas psicotécnicas",
                        NameEnglish = "Psychotechnical tests"
                    };

                    if (psicotechnicalTestsFiles != null && psicotechnicalTestsFiles.Count > 0)
                        psicotechnicalTests.IsCheck = true;

                    /* Pruebas técnicas */
                    List<AttachedFile> technicalTestsFiles = await _attachedFileRepository.GetByFileTypeAndCandidateId(candidate.CandidateId, 1);

                    DocumentCheck technicalTests = new DocumentCheck
                    {
                        OrderId = 5,
                        CandidateId = candidate.CandidateId,
                        DocumentCheckGroupId = 2,
                        DocumentCheckStateId = 1,
                        IsCheck = false,
                        IsEnabled = false,
                        CompanyUserId = companyUserId,
                        Name = "Pruebas técnicas",
                        NameEnglish = "Technical tests"
                    };

                    if (technicalTestsFiles != null && technicalTestsFiles.Count > 0)
                        technicalTests.IsCheck = true;

                    /* Pruebas idioma */
                    DocumentCheck languageTests = new DocumentCheck
                    {
                        OrderId = 6,
                        CandidateId = candidate.CandidateId,
                        DocumentCheckGroupId = 2,
                        DocumentCheckStateId = 2,
                        IsCheck = false,
                        IsEnabled = true,
                        CompanyUserId = companyUserId,
                        Name = "Pruebas idioma",
                        NameEnglish = "Language tests"
                    };

                    if (await _documentCheckRepository.ExistByOrderId(6, companyUserId))
                    {
                        List<DocumentCheck> oldDocChecks = await _documentCheckRepository.GetAllByCandidateIdAndOrderId(candidate.CandidateId, 6, companyUserId);

                        if (currentCheckStructure != null && currentCheckStructure.DocumentCheckGroups != null && currentCheckStructure.DocumentCheckGroups.Count > 0)
                        {
                            foreach (DocumentCheckGroupDTO group in currentCheckStructure.DocumentCheckGroups)
                                if (group.DocumentCheckGroupId == 2 && group.DocumentCheckItems != null && group.DocumentCheckItems.Count > 0)
                                    foreach (DocumentCheckDTO item in group.DocumentCheckItems)
                                        if (item.OrderId == 6)
                                            languageTests.IsCheck = item.IsCheck;
                        }
                        else if (oldDocChecks != null && oldDocChecks.Count > 0)
                            foreach (var oldCheck in oldDocChecks)
                                languageTests.IsCheck = oldCheck.IsCheck;
                    }

                    /* DOCUMENTACIÓN ADICIONAL */

                    /* Tarjeta profesional */
                    DocumentCheck professionalCard = new DocumentCheck
                    {
                        OrderId = 7,
                        CandidateId = candidate.CandidateId,
                        DocumentCheckGroupId = 3,
                        DocumentCheckStateId = 2,
                        IsCheck = false,
                        IsEnabled = true,
                        CompanyUserId = companyUserId,
                        Name = "Tarjeta profesional",
                        NameEnglish = "Professional card"
                    };

                    if (await _documentCheckRepository.ExistByOrderId(7, companyUserId))
                    {
                        List<DocumentCheck> oldDocChecks = await _documentCheckRepository.GetAllByCandidateIdAndOrderId(candidate.CandidateId, 7, companyUserId);

                        if (currentCheckStructure != null && currentCheckStructure.DocumentCheckGroups != null && currentCheckStructure.DocumentCheckGroups.Count > 0)
                        {
                            foreach (DocumentCheckGroupDTO group in currentCheckStructure.DocumentCheckGroups)
                                if (group.DocumentCheckGroupId == 3 && group.DocumentCheckItems != null && group.DocumentCheckItems.Count > 0)
                                    foreach (DocumentCheckDTO item in group.DocumentCheckItems)
                                        if (item.OrderId == 7)
                                            professionalCard.IsCheck = item.IsCheck;
                        }
                        else if (oldDocChecks != null && oldDocChecks.Count > 0)
                            foreach (var oldCheck in oldDocChecks)
                                professionalCard.IsCheck = oldCheck.IsCheck;
                    }

                    /* Documento de identidad */
                    DocumentCheck identityDocument = new DocumentCheck
                    {
                        OrderId = 8,
                        CandidateId = candidate.CandidateId,
                        DocumentCheckGroupId = 3,
                        DocumentCheckStateId = 2,
                        IsCheck = false,
                        IsEnabled = true,
                        CompanyUserId = companyUserId,
                        Name = "Documento de identidad",
                        NameEnglish = "Identity card"
                    };

                    if (await _documentCheckRepository.ExistByOrderId(8, companyUserId))
                    {
                        List<DocumentCheck> oldDocChecks = await _documentCheckRepository.GetAllByCandidateIdAndOrderId(candidate.CandidateId, 8, companyUserId);

                        if (currentCheckStructure != null && currentCheckStructure.DocumentCheckGroups != null && currentCheckStructure.DocumentCheckGroups.Count > 0)
                        {
                            foreach (DocumentCheckGroupDTO group in currentCheckStructure.DocumentCheckGroups)
                                if (group.DocumentCheckGroupId == 3 && group.DocumentCheckItems != null && group.DocumentCheckItems.Count > 0)
                                    foreach (DocumentCheckDTO item in group.DocumentCheckItems)
                                        if (item.OrderId == 8)
                                            identityDocument.IsCheck = item.IsCheck;
                        }
                        else if (oldDocChecks != null && oldDocChecks.Count > 0)
                            foreach (var oldCheck in oldDocChecks)
                                identityDocument.IsCheck = oldCheck.IsCheck;
                    }

                    /* Adicionales */
                    DocumentCheck additionals = new DocumentCheck
                    {
                        OrderId = 9,
                        CandidateId = candidate.CandidateId,
                        DocumentCheckGroupId = 3,
                        DocumentCheckStateId = 2,
                        IsCheck = false,
                        IsEnabled = true,
                        CompanyUserId = companyUserId,
                        Name = "Adicionales",
                        NameEnglish = "Additional documents"
                    };

                    if (await _documentCheckRepository.ExistByOrderId(9, companyUserId))
                    {
                        List<DocumentCheck> oldDocChecks = await _documentCheckRepository.GetAllByCandidateIdAndOrderId(candidate.CandidateId, 9, companyUserId);

                        if (currentCheckStructure != null && currentCheckStructure.DocumentCheckGroups != null && currentCheckStructure.DocumentCheckGroups.Count > 0)
                        {
                            foreach (DocumentCheckGroupDTO group in currentCheckStructure.DocumentCheckGroups)
                                if (group.DocumentCheckGroupId == 3 && group.DocumentCheckItems != null && group.DocumentCheckItems.Count > 0)
                                    foreach (DocumentCheckDTO item in group.DocumentCheckItems)
                                        if (item.OrderId == 9)
                                            additionals.IsCheck = item.IsCheck;
                        }
                        else if (oldDocChecks != null && oldDocChecks.Count > 0)
                            foreach (var oldCheck in oldDocChecks)
                                additionals.IsCheck = oldCheck.IsCheck;
                    }

                    currentDocumentChecks.Add(cv);
                    currentDocumentChecks.Add(academics);
                    currentDocumentChecks.Add(workReferences);
                    currentDocumentChecks.Add(psicotechnicalTests);
                    currentDocumentChecks.Add(technicalTests);
                    currentDocumentChecks.Add(languageTests);
                    currentDocumentChecks.Add(professionalCard);
                    currentDocumentChecks.Add(identityDocument);
                    currentDocumentChecks.Add(additionals);
                }

                documentCheckStructureDTO.DocumentCheckGroups = documentCheckGroupsDTO;

                if (documentCheckStructureDTO.DocumentCheckGroups != null && documentCheckStructureDTO.DocumentCheckGroups.Count > 0)
                {
                    foreach (DocumentCheckGroupDTO group in documentCheckStructureDTO.DocumentCheckGroups)
                    {
                        List<DocumentCheckDTO> listItems = new List<DocumentCheckDTO>();

                        if (group.DocumentCheckGroupId == 1)
                        {
                            /* Hoja de vida */
                            CV cvDB = await _cvRepository.GetByCandidateIdToCandidate(candidate.CandidateId);
                            CV cvOverViewDB = await _cvRepository.ExsistOverViewCvByCandidateId(candidate.CandidateId);

                            DocumentCheck cv = new DocumentCheck
                            {
                                OrderId = 1,
                                CandidateId = candidate.CandidateId,
                                DocumentCheckGroupId = 1,
                                DocumentCheckStateId = 1,
                                IsCheck = false,
                                IsEnabled = false,
                                CompanyUserId = companyUserId,
                                Name = "Hoja de vida",
                                NameEnglish = "Resume"
                            };

                            if (cvDB != null || cvOverViewDB != null)
                                cv.IsCheck = true;

                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(cv));
                        }

                        if (group.DocumentCheckGroupId == 2)
                        {
                            /* Académicos */
                            List<Study> studies = await _studyRepository.GetByCandidateId(candidate.CandidateId);
                            bool existStudy = false;

                            if (studies != null && studies.Count > 0)
                                foreach (Study study in studies)
                                {
                                    StudyCertificate certificate = await _studyCertificateRepository.GetByStudyId(study.StudyId);

                                    if (certificate != null)
                                    {
                                        existStudy = true;

                                        break;
                                    }
                                }

                            DocumentCheck academics = new DocumentCheck
                            {
                                OrderId = 2,
                                CandidateId = candidate.CandidateId,
                                DocumentCheckGroupId = 2,
                                DocumentCheckStateId = 3,
                                IsCheck = existStudy,
                                IsEnabled = true,
                                CompanyUserId = companyUserId,
                                Name = "Académicos",
                                NameEnglish = "Academics"
                            };

                            if (await _documentCheckRepository.ExistByOrderId(2, companyUserId))
                            {
                                List<DocumentCheck> oldDocChecks = await _documentCheckRepository.GetAllByCandidateIdAndOrderId(candidate.CandidateId, 2, companyUserId);
                                if (oldDocChecks != null && oldDocChecks.Count > 0)
                                    foreach (var oldCheck in oldDocChecks)
                                        academics.IsCheck = oldCheck.IsCheck;
                            }

                            /* Pruebas psicotécnicas */
                            List<AttachedFile> psicotechnicalTestsFiles = await _attachedFileRepository.GetByFileTypeAndCandidateId(candidate.CandidateId, 2);

                            DocumentCheck psicotechnicalTests = new DocumentCheck
                            {
                                OrderId = 4,
                                CandidateId = candidate.CandidateId,
                                DocumentCheckGroupId = 2,
                                DocumentCheckStateId = 1,
                                IsCheck = false,
                                IsEnabled = false,
                                CompanyUserId = companyUserId,
                                Name = "Pruebas psicotécnicas",
                                NameEnglish = "Psychotechnical tests"
                            };

                            if (psicotechnicalTestsFiles != null && psicotechnicalTestsFiles.Count > 0)
                                psicotechnicalTests.IsCheck = true;

                            /* Pruebas técnicas */
                            List<AttachedFile> technicalTestsFiles = await _attachedFileRepository.GetByFileTypeAndCandidateId(candidate.CandidateId, 1);

                            DocumentCheck technicalTests = new DocumentCheck
                            {
                                OrderId = 5,
                                CandidateId = candidate.CandidateId,
                                DocumentCheckGroupId = 2,
                                DocumentCheckStateId = 1,
                                IsCheck = false,
                                IsEnabled = false,
                                CompanyUserId = companyUserId,
                                Name = "Pruebas técnicas",
                                NameEnglish = "Technical tests"
                            };

                            if (technicalTestsFiles != null && technicalTestsFiles.Count > 0)
                                technicalTests.IsCheck = true;

                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(academics));
                            //listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(currentDocumentChecks.Where(x => x.Name == "Académicos").FirstOrDefault()));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(currentDocumentChecks.Where(x => x.Name == "Referencias laborales").FirstOrDefault()));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(psicotechnicalTests));
                            //listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(currentDocumentChecks.Where(x => x.Name == "Pruebas psicotécnicas").FirstOrDefault()));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(technicalTests));
                            //listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(currentDocumentChecks.Where(x => x.Name == "Pruebas técnicas").FirstOrDefault()));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(currentDocumentChecks.Where(x => x.Name == "Pruebas idioma").FirstOrDefault()));
                        }

                        if (group.DocumentCheckGroupId == 3)
                        {
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(currentDocumentChecks.Where(x => x.Name == "Tarjeta profesional").FirstOrDefault()));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(currentDocumentChecks.Where(x => x.Name == "Documento de identidad").FirstOrDefault()));
                            listItems.Add(_mapper.Map<DocumentCheck, DocumentCheckDTO>(currentDocumentChecks.Where(x => x.Name == "Adicionales").FirstOrDefault()));
                        }

                        group.DocumentCheckItems = listItems;
                    }
                }

                return documentCheckStructureDTO;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<CVDTO> CandidateCVByOverviewWithCompany(Candidate candidate)
        {
            bool candidateExists = _candidateRepository.CandidateExistById(candidate.CandidateId);

            if (!candidateExists)
                return new CVDTO();

            CV cv = await _cvRepository.ExsistOverViewCvByCandidateId(candidate.CandidateId);

            CVDTO CVDTO = _mapper.Map<CV, CVDTO>(cv);

            return CVDTO;
        }

        public async Task<CVDTO> CompanyCVByOverviewWithCompany(Candidate candidate, int companyUserId)
        {
            bool candidateExists = _candidateRepository.CandidateExistById(candidate.CandidateId);

            if (!candidateExists)
                return new CVDTO();

            CV cv = await _cvRepository.ExsistOverViewCvByCandidateAndCompanyId(candidate.CandidateId, companyUserId);

            CVDTO CVDTO = _mapper.Map<CV, CVDTO>(cv);

            return CVDTO;
        }

        public async Task<RequestDeleteDTO> GetRequestDelete(Candidate candidate, int companyUserId)
        {
            Request requestDeleteProcess = await _requestRepository.GetLastRequest(candidate.CandidateId, 3);

            RequestDeleteDTO response = new RequestDeleteDTO();

            if (requestDeleteProcess != null)
            {
                string name;

                if (requestDeleteProcess.Name != null && requestDeleteProcess.Surname != null)
                    name = requestDeleteProcess.Name + " " + requestDeleteProcess.Surname;
                else
                    name = null;

                try
                {
                    response.Source = requestDeleteProcess.Message;
                    response.NameMemberUser = name;
                    response.CreationDate = _uploadTimeService.GetCreationDate(requestDeleteProcess.CreationDate.ToString());
                    response.CreationInfoPup = _uploadTimeService.GetFormatColombian(requestDeleteProcess.CreationDate.ToString());
                    response.DeleteDate = candidate.DeleteDate;
                    response.FullDeleteDate = candidate.FullDeleteDate;
                    response.IsDeleteProccess = candidate.IsDeleteProccess;
                }
                catch (Exception ex)
                {

                }
            }
            else
            {
                response.IsDeleteProccess = candidate.IsDeleteProccess;
            }

            return response;
        }
    }
}
