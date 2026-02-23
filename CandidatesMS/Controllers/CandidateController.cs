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
using CandidatesMS.Services;
using CandidatesMS.ServicesCompany;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CandidatesMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private ICandidateService _candidateService;
        private ICandidateRepository _candidateRepository;
        private IGenderRepository _genderRepository;
        private ICompanyRemoteRepository _companyRemoteRepository;
        private IMapper _mapper;
        private ICvGenerator _cvGenerator;
        private IDataRegisterCountService _dataRegisterCountService;
        private IStringService _stringService;
        private IAuthorizationHelper _authorizationHelper;
        private IMaritalStatusRepository _maritalStatusRepository;
        private IDocumentTypeRepository _documentTypeRepository;
        private ICandidateLanguageRepository _candidateLanguageRepository;
        private IBasicInformationRepository _basicInformationRepository;
        private IUploadTimeService _uploadTimeService;
        private IPhoneRepository _phoneRepository;
        private IEmailRepository _emailRepository;
        private IRandomPasswordService _randomPasswordService;
        private IBasicInformationService _basicInformationService;
        private IAWSCognitoUpdateUserService _AWSCognitoUpdateUserService;
        private ICurrencyRepository _currencyRepository;
        private IMatchServerDate _matchServerDate;
        private INoteRepository _noteRepository;
        private IRequestRepository _requestRepository;
        private ICandidateCompanyRepository _candidateCompanyRepository;
        private IAttachedFileRepository _attachedFileRepository;
        private IAttachedFileHiringRepository _attachedFileHiringRepository;
        private ICVRepository _cvRepository;
        private ICVHiringRepository _cvHiringRepository;
        private IMailRepository _mailRepository;
        private ICompanyDescriptionRepository _companyDescriptionRepository;
        private IStudyRepository _studyRepository;
        private IWorkExperienceRepository _workExperienceRepository;

        private ICompanyUserRepository _companyUserRepository;
        private IMemberUserRepository _memberUserRepository;

        private ICompanyUserService _companyUserService;
        private IMemberUserService _memberUserService;
        private readonly Services.IValidateMethodsService _validateMethodsService;

        private IHttpClientFactory _httpClient;

        private readonly ServiceConfigurationDTO _settings;
        private readonly ServiceConfigurationDTO _s3Settings;
        public CandidateController(
                                    ICandidateService candidateService,
                                    ICandidateRepository candidateRepository, IMapper mapper, ICvGenerator cvGenerator,
                                    IGenderRepository genderRepository, IMaritalStatusRepository maritalStatusRepository,
                                    ICompanyRemoteRepository companyRemoteRepository, IDocumentTypeRepository documentTypeRepository,
                                    IDataRegisterCountService dataRegisterCountService,
                                    IAuthorizationHelper authorizationHelper, ICandidateLanguageRepository candidateLanguageRepository,
                                    IBasicInformationRepository basicInformationRepository,
                                    IUploadTimeService uploadTimeService, IPhoneRepository phoneRepository, IEmailRepository emailRepository,
                                    IBasicInformationService basicInformationService,
                                    IRandomPasswordService randomPasswordService,
                                    IAWSCognitoUpdateUserService AWSCognitoUpdateUserService,
                                    IStringService stringService,
                                    ICurrencyRepository currencyRepository, INoteRepository noteRepository, IMatchServerDate matchServerDate,
                                    IRequestRepository requestRepository, ICandidateCompanyRepository candidateCompanyRepository,
                                    IAttachedFileRepository attachedFileRepository,
                                    IAttachedFileHiringRepository attachedFileHiringRepository,
                                    ICVRepository cvRepository,
                                    ICVHiringRepository cvHiringRepository,
                                    IMailRepository mailRepository,
                                    ICompanyDescriptionRepository companyDescriptionRepository,
                                    IStudyRepository studyRepository,
                                    IWorkExperienceRepository workExperienceRepository,
                                    IHttpClientFactory httpClient,

                                    ICompanyUserRepository companyUserRepository,
                                    IMemberUserRepository memberUserRepository,

                                    ICompanyUserService companyUserService,
                                    IMemberUserService memberUserService,
                                    Services.IValidateMethodsService validateMethodsService,

                                    IOptions<ServiceConfigurationDTO> settings,
                                    IOptions<ServiceConfigurationDTO> s3settings)
        {
            _candidateService = candidateService;
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
            _basicInformationRepository = basicInformationRepository;
            _uploadTimeService = uploadTimeService;
            _stringService = stringService;
            _phoneRepository = phoneRepository;
            _emailRepository = emailRepository;
            _randomPasswordService = randomPasswordService;
            _basicInformationService = basicInformationService;
            _AWSCognitoUpdateUserService = AWSCognitoUpdateUserService;
            _currencyRepository = currencyRepository;
            _matchServerDate = matchServerDate;
            _noteRepository = noteRepository;
            _requestRepository = requestRepository;
            _candidateCompanyRepository = candidateCompanyRepository;
            _attachedFileRepository = attachedFileRepository;
            _attachedFileHiringRepository = attachedFileHiringRepository;
            _cvRepository = cvRepository;
            _cvHiringRepository = cvHiringRepository;
            _mailRepository = mailRepository;
            _companyDescriptionRepository = companyDescriptionRepository;
            _studyRepository = studyRepository;
            _workExperienceRepository = workExperienceRepository;

            _companyUserRepository = companyUserRepository;
            _memberUserRepository = memberUserRepository;

            _companyUserService = companyUserService;
            _memberUserService = memberUserService;
            _validateMethodsService = validateMethodsService;

            _httpClient = httpClient;

            _settings = settings.Value;
            _s3Settings = s3settings.Value;
        }

        #region GET

        [HttpGet]
        public async Task<IActionResult> GetAllCandidates()
        {
            try
            {
                List<Candidate> candidates = await _candidateRepository.GetAll();

                if (candidates != null && candidates.Count > 0)
                {
                    List<CandidateDTO> candidatesDTO = _mapper.Map<List<Candidate>, List<CandidateDTO>>(candidates);

                    return Ok(new { message = "Candidatos consultados exitosamente", obj = candidatesDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron candidatos" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{candidateId}")]
        public async Task<ObjectResult> GetCandidateById(int candidateId)
        {
            try
            {
                Candidate candidate = await _candidateRepository.GetById(candidateId);

                if (candidate != null)
                {
                    CandidateDTO candidateDTO = _mapper.Map<Candidate, CandidateDTO>(candidate);

                    return Ok(new { message = "Candidato consultado exitosamente", obj = candidateDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró el candidato" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("countsHV/{candidateId}")]
        public async Task<ObjectResult> getCountsByCandidateId(int candidateId)
        {

            StringValues values = "";
            Request.Headers.TryGetValue("Authorization", out values);
            countsHVDTO count = await _candidateService.getCountsByCandidateId(candidateId, values.ToString());
            return Ok(new { message = "", obj = count });
        }


        [HttpGet("getCandidateByToken")]
        public async Task<ObjectResult> GetCandidateByToken()
        {
            try
            {
                var email = _authorizationHelper.GetEmailFromToken(Request);

                Candidate candidate = await _candidateRepository.GetByEmail(email);

                if (candidate != null)
                {
                    CandidateDTO candidateDTO = _mapper.Map<Candidate, CandidateDTO>(candidate);

                    return Ok(new { message = "Candidato consultado exitosamente", obj = candidateDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró el candidato" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("email/{email}")]
        public async Task<ObjectResult> GetCandidateByEmail(string email)
        {
            try
            {
                Candidate candidate = await _candidateRepository.GetByEmail(email);

                if (candidate != null)
                {
                    CandidateDTO candidateDTO = _mapper.Map<Candidate, CandidateDTO>(candidate);
                    return Ok(new { message = "Candidato consultado exitosamente", obj = candidateDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró el candidato" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("guid/{candidateGuid}")]
        public async Task<ObjectResult> GetCandidateByGuid(string candidateGuid)
        {
            try
            {
                Candidate candidate = await _candidateRepository.GetByGuid(candidateGuid);

                if (candidate != null)
                {
                    CandidateDTO candidateDTO = _mapper.Map<Candidate, CandidateDTO>(candidate);

                    return Ok(new { message = "Candidato consultado exitosamente", obj = candidateDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró el candidato" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("candidateFullMaster/{candidateId}")]
        public async Task<ObjectResult> CaandidateFullMaster(int candidateId)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                Candidate candidate = await _candidateRepository.GetOnlyCandidateDataByCandidateId(candidateId);

                if (candidate != null)
                {
                    string companyUserName = "";

                    CompanyUser companyUser = await _companyUserRepository.GetById(candidate.CompanyUserId);

                    if (companyUser != null)
                        companyUserName = companyUser.Name;

                    CandidateFullDTO candidateDTO = _mapper.Map<Candidate, CandidateFullDTO>(candidate);

                    var name = "";
                    if (candidateDTO.BasicInformation != null)
                    {
                        if (candidateDTO.BasicInformation.NameMemberUser != null)
                            name = candidateDTO.BasicInformation.NameMemberUser + " " + candidateDTO.SurnameMemberUser;
                    }

                    candidateDTO.CreationInfoPup = _uploadTimeService.GetFormatColombian(candidate.CreationDate);
                    candidateDTO.CreationDate = _uploadTimeService.GetPublicationInfoWithoutPrefix(candidate.CreationDate);
                    candidateDTO.CreationInfo = _uploadTimeService.GetCandidateCreationInfoMaster(candidate.CreationDate, candidate.FirstLoginDate, candidate.IsMigrated, candidate.Source, name, candidate.IsFromCompanyAndLogin, companyUserName);
                    candidateDTO.CreationShortInfo = _uploadTimeService.GetCandidateCreationShortInfo(candidate.CreationDate, candidate.IsMigrated, candidate.Source);
                    candidateDTO.FirstLoginInfoPup = _uploadTimeService.GetFormatColombian(candidate.FirstLoginDate);

                    return Ok(new { message = "Candidato consultado exitosamente", obj = candidateDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró el candidato" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //

        [HttpGet("exists/{candidateEmail}")]
        public async Task<ObjectResult> CandidateExistsByEmail(string candidateEmail)
        {
            try
            {
                bool exists = await _candidateRepository.CandidateExistByEmailAndAlternativeEmails(candidateEmail);

                if (exists)
                    return Ok(new { message = "El candidato existe", obj = exists });

                else
                    return Ok(new { message = "El candidato no existe", obj = exists });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("existsFree/{candidateEmail}")]
        public async Task<ObjectResult> CandidateExistsByEmailWithoutToken(string candidateEmail)
        {
            try
            {
                bool exists = await _candidateRepository.CandidateExistByEmail(candidateEmail);

                if (exists)
                    return Ok(new { message = "El candidato existe", obj = exists });

                else
                    return Ok(new { message = "El candidato no existe", obj = exists });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("search")]
        public async Task<IActionResult> GetCandidatesByString([FromBody] SearchDTO searchDTO)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                List<MemberByToken> remoteMemberUsers = await _companyRemoteRepository.GetAllMemberUserByToken(values);

                MemberByToken remoteMemberUser = new MemberByToken();

                if (remoteMemberUsers != null && remoteMemberUsers.Count > 0)
                    remoteMemberUser = remoteMemberUsers[0];

                int userType = 0;

                int exsisUserId = 0;
                if (_s3Settings.AWSS3.BucketName == "recruitment-bucket-prod")
                    exsisUserId = 3;
                else
                    exsisUserId = 4;

                if (isMaster)
                    userType = 0; // Master
                else
                {
                    if (exsisUserId == remoteMemberUser.companyUserId)
                        userType = 1; // Exsis
                    else
                        userType = 2; // Otra empresa
                }

                List<Candidate> candidates = await _candidateRepository.GetCandidatesByString(searchDTO.Search, searchDTO.PageSize, remoteMemberUser.companyUserId, userType);

                List<CandidateGeneralSearchDTO> listSearchDTO = new List<CandidateGeneralSearchDTO>();

                string[] validformats = new[] { "MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss, fff",
                                            "MM/dd/yyyy hh:mm tt", "M/dd/yyyy h:mm:ss tt", "MM/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm:ss tt",
                                            "dd/MM/yyyy hh:mm:ss tt","dd/MM/yyyy hh:mm:ss","dd/MM/yyyy h:mm:ss","dd/MM/yyyy h:mm:ss ff",
                                            "dd/MM/yyyy h:mm:ss tt","dd/MM/yyyy hh:mm:ss ff","M/dd/yyyy hh:mm:ss tt"};

                if (candidates != null && candidates.Count > 0)
                {
                    foreach (Candidate candidate in candidates)
                    {
                        CandidateGeneralSearchDTO candidateGeneral = new CandidateGeneralSearchDTO
                        {
                            FirstId = candidate.CandidateId,
                            SecondId = 0,
                            FirstString = "Sin datos básicos",
                            SecondString = "",
                            ThirdString = "No basic data",
                            Photo = "https://recursos-correos-lambda.s3.amazonaws.com/usuariopordefecto.png",
                            Initials = ""
                        };

                        DateTime auxDate = DateTime.Now;

                        if (DateTime.TryParseExact(candidate.CreationDate, validformats, CultureInfo.InvariantCulture, DateTimeStyles.None, out auxDate)) { }

                        candidateGeneral.CreationDateNotFormat = auxDate;

                        candidateGeneral.SecondString = !string.IsNullOrEmpty(candidate.Email) ? candidate.Email : "";

                        if (candidate.BasicInformation != null)
                        {
                            candidateGeneral.SecondId = candidate.BasicInformation.BasicInformationId;
                            candidateGeneral.FirstString = !string.IsNullOrEmpty(candidate.BasicInformation.Name) ? candidate.BasicInformation.Name : "";
                            candidateGeneral.Photo = !string.IsNullOrEmpty(candidate.BasicInformation.Photo) ? candidate.BasicInformation.Photo : "";

                            if (!string.IsNullOrEmpty(candidate.BasicInformation.Name) && candidate.BasicInformation.Name.Count() > 0)
                            {
                                if (!string.IsNullOrEmpty(candidate.BasicInformation.Surname) && candidate.BasicInformation.Surname.Count() > 0)
                                {
                                    candidateGeneral.FirstString += !string.IsNullOrEmpty(candidate.BasicInformation.Surname) ? " " : "";
                                    candidateGeneral.FirstString += !string.IsNullOrEmpty(candidate.BasicInformation.Surname) ? candidate.BasicInformation.Surname : "";

                                    candidateGeneral.Initials = candidate.BasicInformation.Name[0].ToString() + candidate.BasicInformation.Surname[0].ToString();
                                }
                                else
                                {
                                    string[] splitName = candidate.BasicInformation.Name.TrimStart().TrimEnd().Split(" ");

                                    if (splitName != null && splitName.Count() > 0 && splitName[0].Count() > 0)
                                    {
                                        if (splitName.Count() > 1 && splitName[1].Count() > 0)
                                            candidateGeneral.Initials = splitName[0][0].ToString() + splitName[1][0].ToString();
                                        else
                                            candidateGeneral.Initials = splitName[0][0].ToString();
                                    }
                                }
                            }

                            candidateGeneral.FirstString.TrimStart();
                            candidateGeneral.FirstString.TrimEnd();
                        }

                        listSearchDTO.Add(candidateGeneral);
                    }

                    listSearchDTO = listSearchDTO.OrderByDescending(x => x.CreationDateNotFormat).ToList();

                    return Ok(new { message = "Candidatos consultados exitosamente", obj = listSearchDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron candidatos" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //

        [HttpGet("count/{candidateId}")]
        public async Task<ObjectResult> ExperienceCounterByCandidateId(int candidateId)
        {
            try
            {
                var candidate = await _candidateRepository.GetById(candidateId);
                if (candidate == null)
                    return NotFound(new { message = "El candidato no existe" });

                ExperienceCount experienceCount = await _candidateRepository.ExperienceCountByCandidateId(candidateId);

                if (experienceCount != null)
                {
                    ExperienceCountDTO experienceCountDTO = _mapper.Map<ExperienceCount, ExperienceCountDTO>(experienceCount);

                    return Ok(new { message = "Contadores de experiencia del Candidato consultado exitosamente.", obj = experienceCountDTO });
                }
                else
                    return Ok(new { message = "No se encontró Contadores de experiencia del Candidato." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("generatecv/{candidateId}/{language}")]
        public async Task<ActionResult> GetGeneratedCvByCandidateId(int candidateId, int language)
        {
            /* language */
            // 1 = Español.
            // 2 = English.

            StringValues values = "";
            string msn = "-";
            Request.Headers.TryGetValue("Authorization", out values);

            List<MemberByToken> memberUsers = await _companyRemoteRepository.GetAllMemberUserByToken(values.ToString());
            MemberByToken memberUser = new MemberByToken();

            if (memberUsers == null || memberUsers.Count == 0)
                return StatusCode(404, "No existe el usuario empresa");

            memberUser = memberUsers[0];

            try
            {
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());
                bool cvGeneratedExists;
                bool cvGeneratedContactExists;
                if (isMaster)
                {
                    cvGeneratedExists = await _cvGenerator.CvGeneratedExistByCandidateIdMaster(candidateId);
                    cvGeneratedContactExists = await _cvGenerator.CvGeneratedContactExistByCandidateIdMaster(candidateId);
                }
                else
                {
                    cvGeneratedExists = await _cvGenerator.CvGeneratedExistByCandidateAndCompanyId(candidateId, memberUser.companyUserId);
                    cvGeneratedContactExists = await _cvGenerator.CvGeneratedContactExistByCandidateAndCompanyId(candidateId, memberUser.companyUserId);
                }


                msn += "-";
                if (cvGeneratedExists && isMaster)
                    await _cvGenerator.RemoveCvGeneratedByCandidateIdMaster(candidateId);
                msn += "-";
                if (cvGeneratedContactExists && isMaster)
                    await _cvGenerator.RemoveCvGeneratedContactByCandidateIdMaster(candidateId);

                msn += "-";
                if (cvGeneratedExists && !isMaster)
                    await _cvGenerator.RemoveCvGeneratedByCandidateAndCompanyId(candidateId, memberUser.companyUserId);
                msn += "-";
                if (cvGeneratedContactExists && !isMaster)
                    await _cvGenerator.RemoveCvGeneratedContactByCandidateAndCompanyId(candidateId, memberUser.companyUserId);
                msn += "-";

                var created = await _cvGenerator.CreateCvByCandidateAndCompanyIdAsync(candidateId, memberUser.companyUserId, language, values.ToString());
                if (!created)
                    return NotFound(new { message = "No se encontró el información de candidato" });
                msn += "-";

                var txtFileByteArray = await _cvGenerator.GetDocFileUrlsByCompany(candidateId, memberUser.companyUserId, isMaster);
                var result = File(txtFileByteArray, "application/txt");
                result.FileDownloadName = await _cvGenerator.GetFileName(candidateId);
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = $"{ex.Message} {msn}" });
            }
        }

        [AllowAnonymous]
        [HttpGet("dataregister/{candidateId}")]
        public async Task<ObjectResult> GetDataRegisterByCandidateId(int candidateId)
        {
            try
            {
                Candidate candidate = await _candidateRepository.GetById(candidateId);
                bool isFull = candidate.FullData;


                int percentage = await _dataRegisterCountService.GetDataPercentage(candidateId);

                // Validates if percentage is 100% and updates the DB
                if (percentage == 100 && !candidate.FullData)
                {
                    candidate.FullData = true;
                    await _candidateRepository.Update(candidate);
                    isFull = false;
                }

                DataRegisterDTO dataRegister = new DataRegisterDTO
                {
                    FullData = isFull,
                    Percentage = percentage
                };

                return Ok(new { message = "Registro de datos del Candidato consultado exitosamente.", obj = dataRegister });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }


        }

        [HttpGet("isDeleteProccess/{candidateId}")]
        public async Task<IActionResult> IsDeleteProccess(int candidateId)
        {
            try
            {
                Candidate candidate = await _candidateRepository.GetById(candidateId);

                if (candidate != null)
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

                        response.Source = requestDeleteProcess.Message;
                        response.NameMemberUser = name;
                        response.CreationDate = _uploadTimeService.GetCreationDate(requestDeleteProcess.CreationDate.ToString());
                        response.CreationInfoPup = _uploadTimeService.GetFormatColombian(requestDeleteProcess.CreationDate.ToString());
                        response.DeleteDate = candidate.DeleteDate;
                        response.FullDeleteDate = candidate.FullDeleteDate;
                        response.IsDeleteProccess = candidate.IsDeleteProccess;
                    }
                    else
                    {
                        response.IsDeleteProccess = candidate.IsDeleteProccess;
                    }

                    return Ok(new { message = "Consulta exitosa.", obj = response });
                }
                else
                {
                    return Ok(new { message = "Candidato no encontrado." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("numberCandidates/{portalId}/{companyUserId}")]
        public async Task<IActionResult> GetCandidateNumber(int portalId, int companyUserId)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);
                int numberCandidate;
                if (portalId == 0)
                    numberCandidate = await _candidateRepository.CountAllCandidatesToExsis(companyUserId);
                else if (portalId == 1)
                    numberCandidate = await _candidateRepository.CountAllCandidateMaster();
                else
                    numberCandidate = await _candidateRepository.CountAllCandidatesFromCompany(companyUserId);

                return Ok(new { message = "Numero de candidatos consultados exitosamente", obj = numberCandidate });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("candidatesTotalMaster/{graphicFilterId}")]
        public async Task<IActionResult> getTotalCandidatesFromMaster(int graphicFilterId)
        {
            try
            {
                DateTime RightDate = _matchServerDate.GetDateTimeByServer();
                List<Candidate> candidatesReport = new List<Candidate>();
                DateTime LeftDate = new DateTime();
                switch (graphicFilterId)
                {
                    case 1:
                        LeftDate = RightDate.AddDays(-7).Date;
                        candidatesReport = _candidateRepository.GetAllCandidateMasterWithDate(LeftDate, RightDate);
                        break;
                    case 2:
                        LeftDate = RightDate.AddDays(-30).Date;
                        candidatesReport = _candidateRepository.GetAllCandidateMasterWithDate(LeftDate, RightDate);
                        break;
                    case 3:
                        int dayWeek = (int)RightDate.DayOfWeek;
                        if (dayWeek == 1)
                        {
                            LeftDate = RightDate.Date;
                            RightDate = RightDate.AddDays(6);
                            candidatesReport = _candidateRepository.GetAllCandidateMasterWithDate(LeftDate, RightDate);
                        }
                        if (dayWeek == 0)
                        {
                            LeftDate = RightDate.AddDays(-6).Date;
                            candidatesReport = _candidateRepository.GetAllCandidateMasterWithDate(LeftDate, RightDate);
                        }
                        else
                        {
                            LeftDate = RightDate.AddDays(1 - dayWeek).Date;
                            RightDate = RightDate.AddDays(7 - dayWeek);
                            candidatesReport = _candidateRepository.GetAllCandidateMasterWithDate(LeftDate, RightDate);
                        }
                        break;
                    case 4:
                        int daysInMonth = DateTime.DaysInMonth(RightDate.Year, RightDate.Month);
                        int dayMonth = (int)RightDate.Day;
                        if (daysInMonth == dayMonth)
                        {
                            LeftDate = RightDate.AddDays(1 - daysInMonth).Date;
                            candidatesReport = _candidateRepository.GetAllCandidateMasterWithDate(LeftDate, RightDate);
                        }
                        if (dayMonth == 1)
                        {
                            LeftDate = RightDate.Date;
                            RightDate = RightDate.AddDays(daysInMonth - 1);
                            candidatesReport = _candidateRepository.GetAllCandidateMasterWithDate(LeftDate, RightDate);
                        }
                        else
                        {
                            LeftDate = RightDate.AddDays(1 - dayMonth).Date;
                            RightDate = RightDate.AddDays(daysInMonth - dayMonth);
                            candidatesReport = _candidateRepository.GetAllCandidateMasterWithDate(LeftDate, RightDate);
                        }
                        break;
                    case 5:
                        LeftDate = RightDate.AddMonths(-11).Date;
                        int auxDayMonth = (int)LeftDate.Day;
                        LeftDate = LeftDate.AddDays(1 - auxDayMonth);
                        candidatesReport = _candidateRepository.GetAllCandidateMasterWithDate(LeftDate, RightDate);
                        break;
                    default:
                        break;
                }
                //Usar este servicio
                List<CandidateDTO> candidateReturn = _mapper.Map<List<Candidate>, List<CandidateDTO>>(candidatesReport);
                return Ok(new { message = "Informaciones básicas consultadas exitosamente", obj = candidateReturn });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("candidatesTotalCompany/{graphicFilterId}/{companyUserId}")]
        public async Task<IActionResult> getTotalCandidatesFromCompany(int graphicFilterId, int companyUserId)
        {
            try
            {
                DateTime RightDate = _matchServerDate.GetDateTimeByServer();
                List<Candidate> candidatesReport = new List<Candidate>();
                DateTime LeftDate = new DateTime();
                switch (graphicFilterId)
                {
                    case 0:
                        candidatesReport = await _candidateRepository.GetAllCandidatesFromCompanyOrMigrated(companyUserId);
                        break;
                    case 1:
                        LeftDate = RightDate.AddDays(-7).Date;
                        candidatesReport = _candidateRepository.GetAllCandidateCompanyWithDate(LeftDate, RightDate, companyUserId);
                        break;
                    case 2:
                        LeftDate = RightDate.AddDays(-30).Date;
                        candidatesReport = _candidateRepository.GetAllCandidateCompanyWithDate(LeftDate, RightDate, companyUserId);
                        break;
                    case 3:
                        int dayWeek = (int)RightDate.DayOfWeek;
                        if (dayWeek == 1)
                        {
                            LeftDate = RightDate.Date;
                            RightDate = RightDate.AddDays(6);
                            candidatesReport = _candidateRepository.GetAllCandidateCompanyWithDate(LeftDate, RightDate, companyUserId);
                        }
                        if (dayWeek == 0)
                        {
                            LeftDate = RightDate.AddDays(-6).Date;
                            candidatesReport = _candidateRepository.GetAllCandidateCompanyWithDate(LeftDate, RightDate, companyUserId);
                        }
                        else
                        {
                            LeftDate = RightDate.AddDays(1 - dayWeek).Date;
                            RightDate = RightDate.AddDays(7 - dayWeek);
                            candidatesReport = _candidateRepository.GetAllCandidateCompanyWithDate(LeftDate, RightDate, companyUserId);
                        }
                        break;
                    case 4:
                        int daysInMonth = DateTime.DaysInMonth(RightDate.Year, RightDate.Month);
                        int dayMonth = (int)RightDate.Day;
                        if (daysInMonth == dayMonth)
                        {
                            LeftDate = RightDate.AddDays(1 - daysInMonth).Date;
                            candidatesReport = _candidateRepository.GetAllCandidateCompanyWithDate(LeftDate, RightDate, companyUserId);
                        }
                        if (dayMonth == 1)
                        {
                            LeftDate = RightDate.Date;
                            RightDate = RightDate.AddDays(daysInMonth - 1);
                            candidatesReport = _candidateRepository.GetAllCandidateCompanyWithDate(LeftDate, RightDate, companyUserId);
                        }
                        else
                        {
                            LeftDate = RightDate.AddDays(1 - dayMonth).Date;
                            RightDate = RightDate.AddDays(daysInMonth - dayMonth);
                            candidatesReport = _candidateRepository.GetAllCandidateCompanyWithDate(LeftDate, RightDate, companyUserId);
                        }
                        break;
                    case 5:
                        LeftDate = RightDate.AddMonths(-11).Date;
                        int auxDayMonth = (int)LeftDate.Day;
                        LeftDate = LeftDate.AddDays(1 - auxDayMonth);
                        candidatesReport = _candidateRepository.GetAllCandidateCompanyWithDate(LeftDate, RightDate, companyUserId);
                        break;
                    default:
                        break;
                }
                //Usar este servicio
                List<CandidateDTO> candidateReturn = _mapper.Map<List<Candidate>, List<CandidateDTO>>(candidatesReport);
                return Ok(new { message = "Informaciones básicas consultadas exitosamente", obj = candidateReturn });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /* New Overview */

        [HttpGet("candidateOverviewWithCompany/{candidateId}")]
        public async Task<IActionResult> GetCandidateOverviewWithCompany(int candidateId)
        {
            try
            {
                StringValues token = "";
                Request.Headers.TryGetValue("Authorization", out token);

                MemberUserDTO memberUser = await _memberUserService.GetMemberUserFromCandidate(token);

                List<MemberUserDTO> memberUserList = await _memberUserService.GetAllMemberUsersFromCompany(memberUser.CompanyUserId);

                CandidateWithCompanyDTO candidateWithCompany = await _candidateService.GetOverviewWithCompany(token.ToString(), candidateId, memberUser.CompanyUserId, memberUser.Name, memberUser.Surname, memberUser, memberUserList);

                return Ok(new { message = "Candidato consultado exitosamente", obj = candidateWithCompany });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /*  */

        [HttpGet("candidateForReports/{candidateId}")]
        public async Task<IActionResult> GetCandidateForReports(int candidateId)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                MemberByToken memberResponse = await _companyRemoteRepository.GetMemberUserFromCandidate(values.ToString());
                List<MemberByToken> memberUserList = await _companyRemoteRepository.GetAllMemberUserByToken(values.ToString());

                Candidate candidate = await _candidateRepository.GetCandidateOverviewWithCompany(candidateId, memberUser.CompanyUserId);

                BasicInformation basicInformation = await _basicInformationRepository.GetByCandidateId(candidateId);
                if (basicInformation.Surname == null)
                {
                    string[] names = basicInformation.Name.Split(" ");
                    if (names.Count() > 1)
                    {
                        var surname = "";
                        basicInformation.Name = names[0];
                        for (int i = 1; i < names.Length; i++)
                            surname += names[i] + " ";
                        basicInformation.Surname = surname;
                    }
                }

                var name = "";
                if (basicInformation.NameMemberUser != null)
                    name = basicInformation.NameMemberUser;

                DateTime creationDate = DateTime.Now;
                DateTime firstLoginDate = DateTime.Now;

                try
                {
                    if (DateTime.TryParseExact(candidate.CreationDate, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out creationDate)) ;
                    else
                        creationDate = Convert.ToDateTime(candidate.CreationDate);

                    if (DateTime.TryParseExact(candidate.FirstLoginDate, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture,
                       DateTimeStyles.None, out firstLoginDate)) ;
                    else
                        firstLoginDate = Convert.ToDateTime(candidate.FirstLoginDate);
                }
                catch (Exception ex)
                {

                }

                //string creationIfo = _uploadTimeService.GetCandidateCreationInfo(creationDate.ToString(), firstLoginDate.ToString(), candidate.IsMigrated, candidate.Source, name, candidate.IsFromCompanyAndLogin);
                string creationShortInfo = _uploadTimeService.GetCandidateCreationShortInfo(creationDate.ToString(), candidate.IsMigrated, candidate.Source);
                string firstLoginInfoPup = _uploadTimeService.GetFormatColombian(candidate.FirstLoginDate);

                BasicInformationDTO basicInformationDTO = new BasicInformationDTO();

                if (basicInformation != null)
                {
                    basicInformationDTO = _mapper.Map<BasicInformation, BasicInformationDTO>(basicInformation);
                    basicInformationDTO.Email = candidate.Email;
                    basicInformationDTO.IsMigrated = candidate.IsMigrated;
                    basicInformationDTO.IsFromCompanyAndLogin = candidate.IsFromCompanyAndLogin;
                    //basicInformationDTO.CreationInfo = creationIfo;
                    basicInformationDTO.CreationShortInfo = creationShortInfo;
                    basicInformationDTO.CreationInfoPup = Convert.ToDateTime(creationDate).ToString("dd MMM yyyy h:mm tt", new CultureInfo("es-CO"));
                    basicInformationDTO.FirstLoginInfoPup = firstLoginInfoPup;


                    if (!string.IsNullOrEmpty(candidate.FirstLoginDate))
                        basicInformationDTO.FirstLoginInfoPup = Convert.ToDateTime(candidate.FirstLoginDate).ToString("dd MMM yyyy h:mm tt", new CultureInfo("es-CO"));

                    if (basicInformation.EmailMemberUser != null)
                    {
                        MemberUser memberUserTemp = await _memberUserRepository.GetByEmail(basicInformation.EmailMemberUser);

                        if (memberUserTemp == null)
                        {
                            basicInformationDTO.DeleteMember = true;
                        }
                    }

                    candidate.StudyList = await _studyRepository.GetToOverview(candidateId, memberUser.CompanyUserId);
                    candidate.WorkExperienceList = await _workExperienceRepository.GetToOverview(candidateId, memberUser.CompanyUserId);
                }

                CandidateForReportsDTO candidateForReports = new CandidateForReportsDTO
                {
                    CandidateId = candidateId,
                    MemberUserId = memberUser.MemberUserId,
                    CompanyUserId = memberUser.CompanyUserId,
                    BasicInformation = basicInformationDTO,
                    CompanyDescription = await _companyDescriptionRepository.GetByCandidateAndCompanyId(candidateId, memberUser.CompanyUserId),
                    Studies = await _candidateService.FullStudiesByOverviewWithCompany(candidate, memberUser.CompanyUserId, values),
                    WorkExperiences = _candidateService.FullWorkExperiencesByOverviewWithCompanyOrderByCurrentWorking(candidate, memberUser.CompanyUserId)
                };

                return Ok(new { message = "Candidato consultado exitosamente", obj = candidateForReports });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("getSimilarUsers/{candidateId}")]
        public async Task<IActionResult> GetSimilarUsers(int candidateId)
        {
            StringValues values = "";
            Request.Headers.TryGetValue("Authorization", out values);

            string memberEmail = _authorizationHelper.GetEmailFromToken(Request);

            MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

            if (memberUser == null)
                return StatusCode(404, new { message = "No existe el usuario empresa" });

            Candidate candidate = await _candidateRepository.GetById(candidateId);

            if (candidate == null)
                return StatusCode(404, new { message = "No existe el candidato" });

            string candidateEmailWithoutDomain = "";

            if (!string.IsNullOrEmpty(candidate.Email))
            {
                string[] candidateSplit = candidate.Email.Split("@");

                if (candidateSplit != null && candidateSplit.Count() > 0)
                {
                    candidateEmailWithoutDomain = candidateSplit[0];
                }
            }

            List<Candidate> allCandidates = await _candidateRepository.GetCandidatesExceptEmail(candidate.Email, memberUser.CompanyUserId);

            List<Candidate> similarCandidates = new List<Candidate>();

            if (!candidate.IsDeleteProccess)
                similarCandidates.Add(candidate);

            if (!candidate.IsDeleteProccess && allCandidates != null && allCandidates.Count > 0)
            {
                foreach (Candidate currentCandidate in allCandidates)
                {
                    string currentCandidateEmailWithoutDomain = "";

                    if (currentCandidate != null && !string.IsNullOrEmpty(currentCandidate.Email))
                    {
                        string[] currentCandidateSplit = currentCandidate.Email.Split("@");

                        if (currentCandidateSplit != null && currentCandidateSplit.Count() > 0)
                        {
                            currentCandidateEmailWithoutDomain = currentCandidateSplit[0];
                        }
                    }

                    if (!currentCandidate.IsDeleteProccess && _stringService.LevenshteinDistance(candidateEmailWithoutDomain, currentCandidateEmailWithoutDomain) > 0.9)
                        similarCandidates.Add(currentCandidate);
                    else
                    {
                        if (currentCandidate.BasicInformation != null && currentCandidate.BasicInformation.Emails != null &&
                            currentCandidate.BasicInformation.Emails.Count > 0)
                        {
                            foreach (Email email in currentCandidate.BasicInformation.Emails)
                            {
                                string secundaryCandidateEmailWithoutDomain = "";

                                if (email != null && !string.IsNullOrEmpty(email.Mail))
                                {
                                    string[] secundaryCandidateSplit = email.Mail.Split("@");

                                    if (secundaryCandidateSplit != null && secundaryCandidateSplit.Count() > 0)
                                    {
                                        secundaryCandidateEmailWithoutDomain = secundaryCandidateSplit[0];
                                    }
                                }

                                if (!string.IsNullOrEmpty(secundaryCandidateEmailWithoutDomain) && _stringService.LevenshteinDistance(candidateEmailWithoutDomain, secundaryCandidateEmailWithoutDomain) > 0.9)
                                {
                                    similarCandidates.Add(currentCandidate);

                                    break;
                                }
                            }
                        }
                    }
                }
            }

            if (similarCandidates != null && similarCandidates.Count <= 1)
                similarCandidates = new List<Candidate>();

            List<CandidateDTO> candidatesDTO = _mapper.Map<List<Candidate>, List<CandidateDTO>>(similarCandidates);

            return Ok(new { message = "Candidatos consultados exitosamente", obj = candidatesDTO });
        }

        [HttpGet("getAffinityUsers/{jobId}")]
        public async Task<IActionResult> GetAffinityUsersToJobId(int jobId)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (memberUser == null)
                    return StatusCode(404, new { message = "No existe el usuario empresa" });

                int companyUserId = memberUser.CompanyUserId;

                JobIdNameDTO job = await _companyRemoteRepository.GetJobMiniById(jobId);

                if (job == null)
                    return StatusCode(404, new { message = "No existe la oferta" });

                if (string.IsNullOrEmpty(job.Description))
                    return StatusCode(400, new { message = "La oferta no tiene descripción" });

                int userType = 0;

                int exsisUserId = 0;
                if (_s3Settings.AWSS3.BucketName == "recruitment-bucket-prod")
                    exsisUserId = 3;
                else
                    exsisUserId = 4;

                if (isMaster)
                    userType = 0; // Master
                else
                {
                    if (exsisUserId == companyUserId)
                        userType = 1; // Exsis
                    else
                        userType = 2; // Otra empresa
                }

                List<Candidate> candidates = await _candidateRepository.GetCandidatesByStringWithoutSearch(companyUserId, userType);

                List<CandidateAffinityDTO> candidatesDTO = new List<CandidateAffinityDTO>();

                if (candidates != null && candidates.Count > 0)
                {
                    foreach (Candidate candidate in candidates)
                    {
                        double distance = 0;

                        if (candidate.Description != null && !string.IsNullOrEmpty(candidate.Description.Text))
                        {
                            distance = _stringService.LevenshteinDistance(job.Description.Replace("<p>", "").Replace("</p>", ""), candidate.Description.Text.Replace("<p>", "").Replace("</p>", ""));
                        }
                        else
                        {
                            CompanyDescription companyDescripption = candidate.CompanyDescriptionList.Where(x => x.CompanyUserId == companyUserId).FirstOrDefault();

                            if (companyDescripption != null && !string.IsNullOrEmpty(companyDescripption.Text))
                            {
                                distance = _stringService.LevenshteinDistance(job.Description.Replace("<p>", "").Replace("</p>", ""), companyDescripption.Text.Replace("<p>", "").Replace("</p>", ""));
                            }
                        }

                        if (distance >= 0.3)
                        {
                            string name = "";

                            if (candidate.BasicInformation != null)
                            {
                                if (!string.IsNullOrEmpty(candidate.BasicInformation.Name))
                                    name = candidate.BasicInformation.Name;

                                if (!string.IsNullOrEmpty(candidate.BasicInformation.Surname))
                                    name += " " + candidate.BasicInformation.Surname;
                            }

                            CandidateAffinityDTO candidateDTO = new CandidateAffinityDTO()
                            {
                                CandidateId = candidate.CandidateId,
                                CompanyUserId = companyUserId,

                                Email = candidate.Email,
                                Name = name,

                                Affinity = Math.Round(distance, 2)
                            };

                            candidatesDTO.Add(candidateDTO);
                        }
                    }

                    candidatesDTO = candidatesDTO.OrderByDescending(x => x.Affinity).Take(10).ToList();
                }

                return Ok(new { message = "", obj = candidatesDTO });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("migrationCandidateCreationDates")]
        public async Task<IActionResult> MigrationCandidateCreationDates()
        {
            try
            {
                List<Candidate> candidates = await _candidateRepository.GetAll();

                if (candidates != null && candidates.Count > 0)
                {
                    string[] validformats = ["MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss, fff",
                                            "MM/dd/yyyy hh:mm tt", "M/dd/yyyy h:mm:ss tt", "MM/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm:ss tt",
                                            "dd/MM/yyyy hh:mm:ss tt","dd/MM/yyyy hh:mm:ss","dd/MM/yyyy h:mm:ss","dd/MM/yyyy h:mm:ss ff",
                                            "dd/MM/yyyy h:mm:ss tt","dd/MM/yyyy hh:mm:ss ff","M/dd/yyyy hh:mm:ss tt",
                                            "M/dd/yyyy HH:mm:ss", "M/d/yyyy HH:mm:ss", "MM/d/yyyy HH:mm:ss"];

                    foreach (Candidate candidate in candidates)
                    {
                        candidate.CreationDateNoText = DateTime.ParseExact(candidate.CreationDate.Replace(".", ""), validformats, CultureInfo.InvariantCulture, DateTimeStyles.None);

                        await _candidateRepository.Update(candidate);
                    }

                    return Ok(new { message = "", obj = true });
                }


                return Ok(new { message = "", obj = false });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        #endregion

        #region POST

        [HttpPost("migrateToDev")]
        public async Task<IActionResult> MigrateToDev([FromBody] CandidateMigrateFromProdToDev tokenCandidateFull)
        {
            try
            {
                StringValues tokenCompany = "";
                Request.Headers.TryGetValue("Authorization", out tokenCompany);

                string tokenCandidate = tokenCandidateFull.CandidateToken;

                List<Candidate> candidates = await _candidateRepository.GetCandidatesByFilter("", 1, 3);

                int candidateId = 11000;
                int basicInformationId = 8000;

                if (candidates != null && candidates.Count > 0)
                {
                    foreach (Candidate candidate in candidates)
                    {
                        try
                        {
                            if (candidate.CompanyUserId == 0 || candidate.CompanyUserId == 3)
                            {
                                candidate.CandidateId = candidateId;
                                candidate.CandidateGuid = "";

                                candidate.AttachedFilesHiring = null;
                                candidate.CVsHiring = null;

                                candidate.Candidate_Postulation = null;

                                candidate.PersonalReferenceList = null;

                                candidate.VideoList = null;

                                candidate.Request = null;

                                candidate.CompanyUserId = 4;

                                if (candidate.BasicInformation != null)
                                {
                                    candidate.BasicInformation.BasicInformationId = basicInformationId;
                                    candidate.BasicInformation.BasicInformationGuid = "";

                                    candidate.BasicInformation.CandidateId = candidateId;
                                    candidate.BasicInformation.Candidate = null;

                                    if (candidate.BasicInformation.DocumentTypeId == null) candidate.BasicInformation.DocumentTypeId = 1;

                                    candidate.BasicInformation.Photo = "";
                                    candidate.BasicInformation.PhotoByAdmin = "";

                                    candidate.BasicInformation.DocumentCheck = null;

                                    if (candidate.BasicInformation.CurrencyIdFromCompany == null) candidate.BasicInformation.CurrencyIdFromCompany = 1;

                                    if (candidate.BasicInformation.GenderCompanyId == null) candidate.BasicInformation.GenderCompanyId = 1;

                                    if (candidate.BasicInformation.MaritalStatusCompanyId == null) candidate.BasicInformation.MaritalStatusCompanyId = 1;

                                    if (candidate.BasicInformation.Phones != null && candidate.BasicInformation.Phones.Count > 0)
                                    {
                                        foreach (Phone phone in candidate.BasicInformation.Phones)
                                        {
                                            phone.PhoneId = 0;

                                            phone.BasicInformationId = basicInformationId;
                                            phone.BasicInformation = null;

                                            phone.CompanyUserId = 4;
                                        }
                                    }

                                    if (candidate.BasicInformation.Emails != null && candidate.BasicInformation.Emails.Count > 0)
                                    {
                                        foreach (Email email in candidate.BasicInformation.Emails)
                                        {
                                            email.EmailId = 0;

                                            email.BasicInformationId = basicInformationId;
                                            email.BasicInformation = null;

                                            email.CompanyUserId = 4;
                                        }
                                    }

                                    if (candidate.BasicInformation.SocialNetworks != null && candidate.BasicInformation.SocialNetworks.Count > 0)
                                    {
                                        foreach (SocialNetwork socialNetwork in candidate.BasicInformation.SocialNetworks)
                                        {
                                            socialNetwork.SocialNetworkId = 0;

                                            socialNetwork.BasicInformationId = basicInformationId;
                                            socialNetwork.BasicInformation = null;

                                            socialNetwork.CompanyUserId = 4;
                                        }
                                    }

                                    if (candidate.BasicInformation.UserLinks != null && candidate.BasicInformation.UserLinks.Count > 0)
                                    {
                                        foreach (UserLink userLink in candidate.BasicInformation.UserLinks)
                                        {
                                            userLink.UserLinkId = 0;

                                            userLink.BasicInformationId = basicInformationId;
                                            userLink.BasicInformation = null;

                                            userLink.CompanyUserId = 4;
                                        }
                                    }
                                }

                                if (candidate.Candidate_TechnicalAbilityList != null && candidate.Candidate_TechnicalAbilityList.Count > 0)
                                {
                                    foreach (Candidate_TechnicalAbility candidate_TechnicalAbility in candidate.Candidate_TechnicalAbilityList)
                                    {
                                        candidate_TechnicalAbility.Candidate_TechnicalAbilityId = 0;
                                        candidate_TechnicalAbility.Candidate_TechnicalAbilityGuid = "";

                                        candidate_TechnicalAbility.CandidateId = candidateId;
                                        candidate_TechnicalAbility.Candidate = null;

                                        candidate_TechnicalAbility.TechnicalAbilityLevel = null;
                                        candidate_TechnicalAbility.TechnicalAbilityTechnology = null;

                                        candidate_TechnicalAbility.CompanyUserId = 4;
                                    }
                                }

                                if (candidate.StudyList != null && candidate.StudyList.Count > 0)
                                {
                                    foreach (Study study in candidate.StudyList)
                                    {
                                        study.StudyId = 0;

                                        study.CertificateIdentifier = "";

                                        study.CandidateId = candidateId;
                                        study.Candidate = null;

                                        study.CertificationState = null;
                                        study.StudyArea = null;
                                        study.StudyState = null;
                                        study.StudyType = null;
                                        study.Title = null;

                                        study.CompanyUserId = 4;
                                    }
                                }
                                else
                                    candidate.StudyList = new List<Study>();

                                if (candidate.Candidate_Language != null && candidate.Candidate_Language.Count > 0)
                                {
                                    foreach (Candidate_Language candidate_Language in candidate.Candidate_Language)
                                    {
                                        candidate_Language.Candidate_LanguageId = 0;
                                        candidate_Language.Candidate_LanguageGuid = "";

                                        candidate_Language.CandidateId = candidateId;

                                        candidate_Language.Language = null;
                                        candidate_Language.LanguageLevel = null;

                                        candidate_Language.CompanyUserId = 4;
                                    }
                                }
                                else
                                    candidate.Candidate_Language = new List<Candidate_Language>();

                                if (candidate.Candidate_LanguageOther != null && candidate.Candidate_LanguageOther.Count > 0)
                                {
                                    foreach (Candidate_LanguageOther candidate_Language in candidate.Candidate_LanguageOther)
                                    {
                                        candidate_Language.Candidate_LanguageOtherId = 0;
                                        candidate_Language.Candidate_LanguageOtherGuid = "";

                                        candidate_Language.CandidateId = candidateId;

                                        candidate_Language.LanguageOther = null;
                                        candidate_Language.LanguageLevel = null;

                                        candidate_Language.CompanyUserId = 4;
                                    }
                                }
                                else
                                    candidate.Candidate_LanguageOther = new List<Candidate_LanguageOther>();

                                if (candidate.CompanyDescriptionList != null && candidate.CompanyDescriptionList.Count > 0)
                                {
                                    foreach (CompanyDescription companyDescription in candidate.CompanyDescriptionList)
                                    {
                                        companyDescription.CompanyDescriptionId = 0;

                                        companyDescription.CandidateId = candidateId;
                                        companyDescription.Candidate = null;

                                        companyDescription.CompanyUserId = 4;
                                    }
                                }
                                else
                                    candidate.CompanyDescriptionList = new List<CompanyDescription>();

                                if (candidate.WorkExperienceList != null && candidate.WorkExperienceList.Count > 0)
                                {
                                    foreach (WorkExperience workExperience in candidate.WorkExperienceList)
                                    {
                                        workExperience.WorkExperienceId = 0;
                                        workExperience.WorkExperienceGuid = "";

                                        workExperience.BossName = "";
                                        workExperience.BossCellphone = "";

                                        workExperience.CandidateId = candidateId;

                                        workExperience.CandidateId = candidateId;
                                        workExperience.Candidate = null;

                                        workExperience.EquivalentPosition = null;
                                        workExperience.Industry = null;

                                        workExperience.CompanyUserId = 4;
                                    }
                                }
                                else
                                    candidate.WorkExperienceList = new List<WorkExperience>();

                                if (candidate.CandidateCompanies != null && candidate.CandidateCompanies.Count > 0)
                                {
                                    foreach (CandidateCompany candidateCompany in candidate.CandidateCompanies)
                                    {
                                        candidateCompany.CandidateCompanyId = 0;

                                        candidateCompany.CandidateId = candidateId;
                                        //candidateCompany.Candidate = null;

                                        candidateCompany.CompanyUserId = 4;
                                    }
                                }
                                else
                                    candidate.CandidateCompanies = new List<CandidateCompany>();


                                string candidateString = JsonConvert.SerializeObject(candidate);

                                bool isCreated = await _companyRemoteRepository.AddToDevDeployed(candidateString, tokenCandidate);

                                if(isCreated)
                                {
                                    candidateId++;
                                    basicInformationId++;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            return StatusCode(500, new { message = ex.Message });
                        }
                    }
                }

                List<CandidateDTO> candidatesDTO = _mapper.Map<List<Candidate>, List<CandidateDTO>>(candidates);

                return Created("", new { message = "Creados exitosamente", obj = candidatesDTO });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddCandidate(CandidateDTO candidateDTO)
        {
            try
            {
                bool emailExists = await _candidateRepository.CandidateExistByEmailAndAlternativeEmails(candidateDTO.Email);

                if (!emailExists)
                {
                    int companyUserId = 0;

                    MemberUser memberUser = new();

                    StringValues values = "";

                    Request.Headers.TryGetValue("Authorization", out values);

                    if (!string.IsNullOrEmpty(candidateDTO.EmailMember))
                    {
                        memberUser = await _memberUserRepository.GetByEmail(candidateDTO.EmailMember);

                        candidateDTO.NameMemberUser = memberUser.Name;
                        candidateDTO.SurnameMemberUser = memberUser.Surname;
                    }

                    /**/

                    if (candidateDTO != null && candidateDTO.BasicInformation != null)
                    {
                        if (!string.IsNullOrEmpty(candidateDTO.BasicInformation.Name))
                        {
                            string[] nameSplit = candidateDTO.BasicInformation.Name.Trim().Split(" ");

                            string nameFull = "";

                            if (nameSplit != null && nameSplit.Count() > 0)
                            {
                                foreach (string name in nameSplit)
                                {
                                    string nameFormat = name.ToLower();

                                    if (nameFormat != null && nameFormat.Count() > 0)
                                    {
                                        string firstLetter = nameFormat.Substring(0, 1).ToUpper();

                                        nameFull += firstLetter;

                                        if (nameFormat.Count() > 1)
                                            nameFull += nameFormat.Substring(1);

                                        nameFull += " ";
                                    }
                                }
                            }

                            nameFull = nameFull.Trim();

                            candidateDTO.BasicInformation.Name = nameFull;
                        }

                        if (!string.IsNullOrEmpty(candidateDTO.BasicInformation.Surname))
                        {
                            string[] nameSplit = candidateDTO.BasicInformation.Surname.Trim().Split(" ");

                            string nameFull = "";

                            if (nameSplit != null && nameSplit.Count() > 0)
                            {
                                foreach (string name in nameSplit)
                                {
                                    string nameFormat = name.ToLower();

                                    if (nameFormat != null && nameFormat.Count() > 0)
                                    {
                                        string firstLetter = nameFormat.Substring(0, 1).ToUpper();

                                        nameFull += firstLetter;

                                        if (nameFormat.Count() > 1)
                                            nameFull += nameFormat.Substring(1);

                                        nameFull += " ";
                                    }
                                }
                            }

                            nameFull = nameFull.Trim();

                            candidateDTO.BasicInformation.Surname = nameFull;
                        }
                    }

                    /**/

                    Candidate candidate = _mapper.Map<CandidateDTO, Candidate>(candidateDTO);
                    candidate.CandidateGuid = Convert.ToString(Guid.NewGuid());

                    // Set creation date
                    string creationDate = DateTime.Now.ToLocalTime().AddHours(-5).ToString();

                    /**/

                    string[] validformats = ["MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss, fff",
                                            "MM/dd/yyyy hh:mm tt", "M/dd/yyyy h:mm:ss tt", "MM/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm:ss tt",
                                            "dd/MM/yyyy hh:mm:ss tt","dd/MM/yyyy hh:mm:ss","dd/MM/yyyy h:mm:ss","dd/MM/yyyy h:mm:ss ff",
                                            "dd/MM/yyyy h:mm:ss tt","dd/MM/yyyy hh:mm:ss ff","M/dd/yyyy hh:mm:ss tt",
                                            "M/dd/yyyy HH:mm:ss", "M/d/yyyy HH:mm:ss", "MM/d/yyyy HH:mm:ss"];

                    candidate.CreationDate = creationDate;

                    candidate.CreationDateNoText = DateTime.ParseExact(candidate.CreationDate.Replace(".", ""), validformats, CultureInfo.InvariantCulture, DateTimeStyles.None);

                    /**/

                    if (candidate.IsMigrated == 0)
                        candidate.isAuthorized = true;
                    else
                        candidate.isAuthorized = false;

                    candidate.Email.Replace(" ", "");

                    candidate.IsNew = true;

                    bool created = await _candidateRepository.Add(candidate);
                    var candidate2 = await _candidateRepository.GetByEmail(candidate.Email);
                    object[] ans = await _candidateRepository.EditEditionDate(candidate2.CandidateId);



                    try
                    {
                        if (memberUser != null)
                        {
                            companyUserId = memberUser.CompanyUserId;

                            CandidateCompany candidateCompany = new CandidateCompany();

                            candidateCompany.CandidateId = candidate2.CandidateId;
                            candidateCompany.CompanyUserId = companyUserId;

                            if (candidateDTO != null && candidateDTO.BasicInformation != null)
                            {
                                candidateCompany.Address = candidateDTO.BasicInformation.AddressAdmin;
                                candidateCompany.BirthDate = candidateDTO.BasicInformation.BirthDateCompany;
                                candidateCompany.CurrencyId = candidateDTO.BasicInformation.CurrencyIdFromCompany;
                                candidateCompany.DescriptionId = candidateDTO.CompanyDescription.CompanyDescriptionId;
                                candidateCompany.Document = candidate.BasicInformation.DocumentAdmin;
                                candidateCompany.DocumentTypeId = candidate.BasicInformation.DocumentTypeIdAdmin;
                                candidateCompany.GenderId = candidate.BasicInformation.GenderCompanyId;
                                candidateCompany.HaveWorkExperience = candidate.BasicInformation.HaveWorkExperienceFromCompany;
                                candidateCompany.MaritalStatusId = candidate.BasicInformation.MaritalStatusCompanyId;
                                candidateCompany.OtherDocument = candidate.BasicInformation.OtherDocument;
                                candidateCompany.Photo = candidate.BasicInformation.PhotoByAdmin;
                                candidateCompany.SalaryAspiration = candidate.BasicInformation.SalaryAspirationFromCompany;
                            }

                            bool candidateCompanyIsCreated = await _candidateCompanyRepository.Add(candidateCompany);
                        }
                    }
                    catch (Exception ex)
                    {

                    }

                    if (created && ans != null && ans.Count() == 2 && (bool)ans[0])
                    {
                        candidateDTO = _mapper.Map<Candidate, CandidateDTO>(candidate);

                        return Created("", new { message = "Creado exitosamente", obj = candidateDTO });
                    }
                    else
                        return BadRequest(new { message = "El candidato no fue almacenado" });
                }
                else
                {
                    return BadRequest(new { message = "Ya existe un candidato asociado al correo electrónico ingresado" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //

        [HttpPost("candidatesFromJobId")]
        public async Task<ObjectResult> GetCandidatesFromJobId([FromBody] SearchByIdAndTextWithPaginationDTO search)
        {
            StringValues token = "";
            Request.Headers.TryGetValue("Authorization", out token);

            try
            {
                CandidateIdAndPostulationAndTGNumbersResponseDTO recieved = await _companyRemoteRepository.GetCandidateIdsFromJobId(token.ToString(), search);
                List<CandidateIdAndPostulationAndTGNumbersDTO> candidatesrecieved = recieved.search;
                CandidateWithPostulationCountResponseDTO response = new CandidateWithPostulationCountResponseDTO();

                if (candidatesrecieved != null && candidatesrecieved.Count > 0)
                {
                    List<CandidateWithPostulationCountDTO> candidates = new List<CandidateWithPostulationCountDTO>();

                    List<PostulationJobNameInDTO> postulations = await _companyRemoteRepository.GetAllPostulationsWithNameAndColourFlag(token.ToString());
                    List<CandidateTalentGroupNameInDTO> talentGroups = await _companyRemoteRepository.GetAllCandidateTalentWithNameAndColourFlag(token.ToString());

                    foreach (CandidateIdAndPostulationAndTGNumbersDTO candidaterecieved in candidatesrecieved)
                    {
                        Candidate candidate = await _candidateRepository.GetById(candidaterecieved.candidateId);

                        if (candidate != null && (string.IsNullOrEmpty(search.Text) || ((!string.IsNullOrEmpty(candidate.Email) && candidate.Email.ToLower().TrimEnd().Contains(search.Text.ToLower().TrimEnd())) ||
                            (candidate.BasicInformation != null && ((!string.IsNullOrEmpty(candidate.BasicInformation.Name) && candidate.BasicInformation.Name.ToLower().TrimEnd().Contains(search.Text.ToLower().TrimEnd()))
                            || (!string.IsNullOrEmpty(candidate.BasicInformation.Surname) && candidate.BasicInformation.Surname.ToLower().TrimEnd().Contains(search.Text.ToLower().TrimEnd())) ||
                            ((!string.IsNullOrEmpty(candidate.BasicInformation.Name) && !string.IsNullOrEmpty(candidate.BasicInformation.Surname)) &&
                            (candidate.BasicInformation.Name.ToLower().TrimEnd() + " " + candidate.BasicInformation.Surname.ToLower().TrimEnd()).Contains(search.Text.ToLower().TrimEnd())))))))
                        {
                            List<string> jobNames = new List<string>();
                            List<string> talentNames = new List<string>();

                            int jobCount = 0;
                            int talentCount = 0;

                            DateTime creationDate = DateTime.Now;

                            string[] validformats = new[] { "MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss, fff",
                                            "MM/dd/yyyy hh:mm tt", "M/dd/yyyy h:mm:ss tt", "MM/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm:ss tt",
                                            "dd/MM/yyyy hh:mm:ss tt","dd/MM/yyyy hh:mm:ss","dd/MM/yyyy h:mm:ss","dd/MM/yyyy h:mm:ss ff",
                                            "dd/MM/yyyy h:mm:ss tt","dd/MM/yyyy hh:mm:ss ff","M/dd/yyyy hh:mm:ss tt"};

                            if (DateTime.TryParseExact(candidate.CreationDate, validformats, CultureInfo.InvariantCulture,
                                DateTimeStyles.None, out creationDate)) ;
                            else
                                creationDate = Convert.ToDateTime(candidate.CreationDate);

                            string name = "";
                            string photo = "";
                            string initials = "";

                            List<PostulationJobNameInDTO> jobs = new List<PostulationJobNameInDTO>();

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

                            List<CandidateTalentGroupNameInDTO> talents = new List<CandidateTalentGroupNameInDTO>();

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

                            if (candidate.BasicInformation != null)
                            {
                                if (!String.IsNullOrEmpty(candidate.BasicInformation.Photo) && candidate.BasicInformation.Photo != null)
                                    photo = candidate.BasicInformation.Photo;

                                initials = _basicInformationService.Initials(candidate.BasicInformation.Name, candidate.BasicInformation.Surname);

                                name = _basicInformationService.Name(candidate.BasicInformation.Name, candidate.BasicInformation.Surname);
                            }

                            CandidateWithPostulationCountDTO candidateFull = new CandidateWithPostulationCountDTO
                            {
                                CandidateId = candidate.CandidateId,
                                Email = candidate.Email,
                                Name = name,
                                Initials = initials,
                                Photo = photo,
                                CreationDate = _uploadTimeService.GetCreationDate(candidate.CreationDate.ToString()),
                                CreationDateEnglish = _uploadTimeService.GetPublicationEnglish(candidate.CreationDate.ToString()),
                                CreationDateToltip = _uploadTimeService.GetFormatColombian(creationDate.ToString()),
                                CreationDatePopUpEnglish = _uploadTimeService.GetFormatUsa(creationDate.ToString()),
                                TotalJobs = jobCount,
                                TotalTalentGroups = talentCount,
                                Jobs = jobNames,
                                TalentGroups = talentNames,
                                IsDeleteProccess = candidate.IsDeleteProccess
                            };

                            if (jobs != null && jobs.Count > 0)
                            {
                                jobs.OrderByDescending(x => x.creationDate).ToList();

                                candidateFull.ColourFlag = jobs[0].colourFlag;

                                candidateFull.ColourFlagToltip = jobs[0].jobName;
                            }

                            if (candidateFull.ColourFlag == 0 && talents != null && talents.Count > 0)
                            {
                                talents.OrderByDescending(x => x.creationDate).ToList();

                                candidateFull.ColourFlag = talents[0].colourFlag;

                                candidateFull.ColourFlagToltip = talents[0].talentGroupName;
                            }

                            candidates.Add(candidateFull);
                        }
                    }


                    for (int i = 0; i < candidates.Count; i++)
                    {
                        if (i == 0)
                            candidates[i].Previous = 0;
                        else
                            candidates[i].Previous = candidates[i - 1].CandidateId;

                        if (i == candidates.Count - 1)
                            candidates[i].Next = 0;
                        else
                            candidates[i].Next = candidates[i + 1].CandidateId;
                    }

                    response.Candidates = candidates;
                    response.Total = recieved.total;

                    return Ok(new { message = "Candidato consultado exitosamente", obj = response });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron candidatos" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("candidatesFromTalentGroupId")]
        public async Task<ObjectResult> GetCandidatesFromTalentGroupId([FromBody] SearchByIdAndTextWithPaginationDTO search)
        {
            StringValues token = "";
            Request.Headers.TryGetValue("Authorization", out token);

            try
            {
                CandidateIdAndPostulationAndTGNumbersResponseDTO recieved = await _companyRemoteRepository.GetCandidateIdsFromTalentGroupId(token.ToString(), search);

                List<CandidateIdAndPostulationAndTGNumbersDTO> candidatesrecieved = recieved.search;

                List<PostulationJobNameInDTO> postulations = await _companyRemoteRepository.GetAllPostulationsWithNameAndColourFlag(token.ToString());
                List<CandidateTalentGroupNameInDTO> talentGroups = await _companyRemoteRepository.GetAllCandidateTalentWithNameAndColourFlag(token.ToString());

                CandidateWithPostulationCountResponseDTO response = new CandidateWithPostulationCountResponseDTO();

                if (candidatesrecieved != null && candidatesrecieved.Count > 0)
                {
                    List<CandidateWithPostulationCountDTO> candidates = new List<CandidateWithPostulationCountDTO>();

                    foreach (CandidateIdAndPostulationAndTGNumbersDTO candidaterecieved in candidatesrecieved)
                    {
                        Candidate candidate = await _candidateRepository.GetById(candidaterecieved.candidateId);

                        if (candidate != null && (string.IsNullOrEmpty(search.Text) || ((!string.IsNullOrEmpty(candidate.Email) && candidate.Email.ToLower().TrimEnd().Contains(search.Text.ToLower().TrimEnd())) ||
                            (candidate.BasicInformation != null && ((!string.IsNullOrEmpty(candidate.BasicInformation.Name) && candidate.BasicInformation.Name.ToLower().TrimEnd().Contains(search.Text.ToLower().TrimEnd()))
                            || (!string.IsNullOrEmpty(candidate.BasicInformation.Surname) && candidate.BasicInformation.Surname.ToLower().TrimEnd().Contains(search.Text.ToLower().TrimEnd())) ||
                            ((!string.IsNullOrEmpty(candidate.BasicInformation.Name) && !string.IsNullOrEmpty(candidate.BasicInformation.Surname)) &&
                            (candidate.BasicInformation.Name.ToLower().TrimEnd() + " " + candidate.BasicInformation.Surname.ToLower().TrimEnd()).Contains(search.Text.ToLower().TrimEnd())))))))
                        {
                            List<string> jobNames = new List<string>();
                            List<string> talentNames = new List<string>();

                            int jobCount = 0;
                            int talentCount = 0;

                            DateTime creationDate = DateTime.Now;

                            string[] validformats = new[] { "MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss, fff",
                                            "MM/dd/yyyy hh:mm tt", "M/dd/yyyy h:mm:ss tt", "MM/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm:ss tt",
                                            "dd/MM/yyyy hh:mm:ss tt","dd/MM/yyyy hh:mm:ss","dd/MM/yyyy h:mm:ss","dd/MM/yyyy h:mm:ss ff",
                                            "dd/MM/yyyy h:mm:ss tt","dd/MM/yyyy hh:mm:ss ff","M/dd/yyyy hh:mm:ss tt"};

                            if (DateTime.TryParseExact(candidate.CreationDate, validformats, CultureInfo.InvariantCulture,
                                DateTimeStyles.None, out creationDate)) ;

                            string name = "";
                            string photo = "";
                            string initials = "";

                            List<PostulationJobNameInDTO> jobs = new List<PostulationJobNameInDTO>();
                            List<CandidateTalentGroupNameInDTO> talents = new List<CandidateTalentGroupNameInDTO>();

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

                            if (candidate.BasicInformation != null)
                            {
                                if (!String.IsNullOrEmpty(candidate.BasicInformation.Photo) && candidate.BasicInformation.Photo != null)
                                    photo = candidate.BasicInformation.Photo;

                                initials = _basicInformationService.Initials(candidate.BasicInformation.Name, candidate.BasicInformation.Surname);

                                name = _basicInformationService.Name(candidate.BasicInformation.Name, candidate.BasicInformation.Surname);
                            }

                            CandidateWithPostulationCountDTO candidateFull = new CandidateWithPostulationCountDTO
                            {
                                CandidateId = candidate.CandidateId,
                                Email = candidate.Email,
                                Name = name,
                                Initials = initials,
                                Photo = photo,
                                CreationDate = _uploadTimeService.GetCreationDate(candidate.CreationDate.ToString()),
                                CreationDateEnglish = _uploadTimeService.GetPublicationEnglish(candidate.CreationDate.ToString()),
                                CreationDateToltip = _uploadTimeService.GetFormatColombian(creationDate.ToString()),
                                CreationDatePopUpEnglish = _uploadTimeService.GetFormatUsa(creationDate.ToString()),
                                TotalJobs = jobCount,
                                TotalTalentGroups = talentCount,
                                Jobs = jobNames,
                                TalentGroups = talentNames,
                                IsDeleteProccess = candidate.IsDeleteProccess
                            };


                            if (jobs != null && jobs.Count > 0)
                            {
                                jobs.OrderByDescending(x => x.creationDate).ToList();

                                candidateFull.ColourFlag = jobs[0].colourFlag;

                                candidateFull.ColourFlagToltip = jobs[0].jobName;
                            }

                            if (candidateFull.ColourFlag == 0 && talents != null && talents.Count > 0)
                            {
                                talents.OrderByDescending(x => x.creationDate).ToList();

                                candidateFull.ColourFlag = talents[0].colourFlag;

                                candidateFull.ColourFlagToltip = talents[0].talentGroupName;
                            }

                            candidates.Add(candidateFull);
                        }
                    }

                    for (int i = 0; i < candidates.Count; i++)
                    {
                        if (i == 0)
                            candidates[i].Previous = 0;
                        else
                            candidates[i].Previous = candidates[i - 1].CandidateId;

                        if (i == candidates.Count - 1)
                            candidates[i].Next = 0;
                        else
                            candidates[i].Next = candidates[i + 1].CandidateId;
                    }

                    response.Candidates = candidates;
                    response.Total = recieved.total;

                    return Ok(new { message = "Candidato consultado exitosamente", obj = response });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron candidatos" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("notesFromTalentGroupId")]
        public async Task<ObjectResult> GetNotesFromTalentGroupId([FromBody] SearchByIdAndTextWithPaginationDTO search)
        {
            try
            {
                StringValues token = "";
                Request.Headers.TryGetValue("Authorization", out token);
                var candidateFilter = await _candidateService.GetNotesFromCandidateInTalentGroup(search, token);
                if (candidateFilter != null)
                    return Ok(new { message = "Candidatos consultados exitosamente", obj = candidateFilter });
                else
                    return NotFound(new { message = "No se encontraron Candidatos" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("notesFromTalentGroupIdAndSearch")]
        public async Task<ObjectResult> GetNotesFromTalentGroupIdAndSearch([FromBody] SearchByIdAndTextWithPaginationDTO search)
        {
            try
            {
                StringValues token = "";
                Request.Headers.TryGetValue("Authorization", out token);
                var notesCandidate = await _candidateService.GetNotesFromCandidateInTalentGroupAndSearch(search, token);
                if (notesCandidate != null)
                    return Ok(new { message = "Notas en grupo de talento consultadas exitosamente", obj = notesCandidate });
                else
                    return NotFound(new { message = "No se encontraron Notas asociadas a los candidatos" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpPost("notesFromJobId")]
        public async Task<ObjectResult> GetNotesFromJobId([FromBody] SearchByIdAndTextWithPaginationDTO search)
        {
            try
            {
                StringValues token = "";
                Request.Headers.TryGetValue("Authorization", out token);
                var notesCandidate = await _candidateService.GetNotesFromCandidateInJob(search, token);
                if (notesCandidate != null)
                    return Ok(new { message = "Notas en vacantes consultadas exitosamente", obj = notesCandidate });
                else
                    return NotFound(new { message = "No se encontraron Notas asociadas a los candidatos" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("notesFromJobIdAndSearch")]
        public async Task<ObjectResult> GetNotesFromJobIdAndSearch([FromBody] SearchByIdAndTextWithPaginationDTO search)
        {
            try
            {
                StringValues token = "";
                Request.Headers.TryGetValue("Authorization", out token);
                var notesCandidate = await _candidateService.GetNotesFromCandidateInJobAndSearch(search, token);
                if (notesCandidate != null)
                    return Ok(new { message = "Notas en vacantes consultadas exitosamente", obj = notesCandidate });
                else
                    return NotFound(new { message = "No se encontraron Notas asociadas a los candidatos" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("searchCandidates")]
        public async Task<IActionResult> GetSearchCandidatesByString([FromBody] SearchByIdAndTextWithPaginationDTO search)
        {
            try
            {
                StringValues token = "";
                Request.Headers.TryGetValue("Authorization", out token);

                MemberByToken memberResponse = await _companyRemoteRepository.GetMemberUserFromCandidate(token.ToString());

                int companyUserId = 0;

                if (memberResponse != null)
                    companyUserId = memberResponse.companyUserId;

                bool isMaster = await _companyRemoteRepository.isMaster(token.ToString());

                int userType = 0;

                int exsisUserId = 0;
                if (_s3Settings.AWSS3.BucketName == "recruitment-bucket-prod")
                    exsisUserId = 3;
                else
                    exsisUserId = 4;

                if (isMaster)
                    userType = 0; // Master
                else
                {
                    if (exsisUserId == companyUserId)
                        userType = 1; // Exsis
                    else
                        userType = 2; // Otra empresa
                }

                candidateSearchTotalDTO candidates = new candidateSearchTotalDTO();
                if (isMaster == true)
                    candidates = await _candidateService.GetAllCandidateSearchMaster(search, token);
                else
                    candidates = await _candidateService.GetAllCandidateSearch(search, companyUserId, userType, token);

                if (candidates != null)
                    return Ok(new { message = "Candidatos Consultados Exitosamente", obj = candidates });
                else
                    return NotFound(new { message = "No se encontraron Candidatos" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //

        [AllowAnonymous]
        [HttpPost("validCode")]
        public async Task<IActionResult> ValidateLoginCode([FromBody] CandidateDTO candidateDTO)
        {
            try
            {
                bool emailExists = await _candidateRepository.CandidateExistByEmail(candidateDTO.Email);

                if (emailExists)
                {
                    Candidate candidate = await _candidateRepository.GetByEmail(candidateDTO.Email);

                    if (candidate != null && candidateDTO != null && !string.IsNullOrEmpty(candidate.LoginCode) && !string.IsNullOrEmpty(candidateDTO.LoginCode) && candidate.LoginCode == candidateDTO.LoginCode)
                    {
                        return Ok(new { message = "Código validado exitosamente", obj = true });
                    }
                    else
                        return BadRequest(new { message = "Código incorrecto", obj = false });
                }
                else
                {
                    return BadRequest(new { message = "No existe un candidato asociado al correo electrónico ingresado" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("generateCode/{language}")]
        public async Task<IActionResult> GenerateLoginCode([FromBody] CandidateDTO candidateDTO, int language = 1)
        {
            try
            {
                Candidate candidate = await _candidateRepository.GetByEmail(candidateDTO.Email);

                if (candidate != null && !string.IsNullOrEmpty(candidate.Source) && candidate.Source == "LinkedIn")
                    return BadRequest(new { message = "El candidato existe desde LinkedIn", obj = candidateDTO.Email });

                if (candidate != null)
                {
                    candidateDTO = _randomPasswordService.GenerateValidationCodeInCandidate(candidateDTO);

                    candidate.LoginCode = candidateDTO.LoginCode;

                    bool isSaved = await _candidateRepository.Update(candidate);

                    if (isSaved)
                    {
                        await _companyRemoteRepository.SendCodeEmailCandidate(candidateDTO, language);

                        return Ok(new { message = "Código generado exitosamente", obj = candidateDTO.Email });
                    }
                    else
                        return BadRequest(new { message = "El código no se generó", obj = "" });
                }
                else
                {
                    return NotFound(new { message = "No existe un candidato asociado al correo electrónico ingresado" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("candidateExists")]
        public async Task<IActionResult> candidateExists([FromBody] CandidateDTO candidateDTO)
        {
            try
            {
                bool candidateExists = await _candidateRepository.CandidateExistByEmail(candidateDTO.Email);

                if(!candidateExists)
                    return NotFound(new { message = "No existe un candidato asociado al correo electrónico ingresado" });

                return Ok(new { message = "El candidato existe", obj = candidateDTO.Email });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("candidateExistsAndLinkedIn")]
        public async Task<IActionResult> candidateExistsAndLinkedIn([FromBody] CandidateDTO candidateDTO)
        {
            try
            {
                Candidate candidate = await _candidateRepository.GetByEmail(candidateDTO.Email);

                if (candidate != null && !string.IsNullOrEmpty(candidate.Source) && candidate.Source == "LinkedIn")
                    return Ok(new { message = "El candidato existe", obj = candidateDTO.Email });

                return NotFound(new { message = "No existe un candidato asociado al correo electrónico ingresado" });                                
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message }); 
            }
        }

        [HttpPost("count")]
        public async Task<IActionResult> AddExperienceCounter([FromBody] ExperienceCountDTO experienceCountDTO)
        {
            try
            {
                Candidate candidate = await _candidateRepository.GetById(experienceCountDTO.CandidateId);

                if (candidate != null)
                {
                    ExperienceCount experienceCount = _mapper.Map<ExperienceCountDTO, ExperienceCount>(experienceCountDTO);

                    // Add or Update Experience Count
                    bool created = await _candidateRepository.AddExperienceCounter(experienceCount);
                    object[] ans = await _candidateRepository.EditEditionDate(experienceCountDTO.CandidateId);

                    if (created && ans != null && ans.Count() == 2 && (bool)ans[0])
                    {
                        experienceCountDTO = _mapper.Map<ExperienceCount, ExperienceCountDTO>(experienceCount);

                        return Created("", new { message = "Contadores de experiencia del Candidato Creado exitosamente.", obj = experienceCountDTO });
                    }
                    else
                        return BadRequest(new { message = "Contadores de experiencia del Candidato no almacenado." });
                }
                else
                {
                    return NotFound(new { message = "No se encontró el candidato." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("candidatesFromTalentGroupIdAndSearch")]
        public async Task<ObjectResult> GetCandidatesFromTalentGroupIdAndSearch([FromBody] SearchByIdAndTextWithPaginationDTO search)
        {
            try
            {
                StringValues token = "";
                Request.Headers.TryGetValue("Authorization", out token);

                MemberByToken memberResponse = await _companyRemoteRepository.GetMemberUserFromCandidate(token.ToString());

                int companyUserId = 0;

                if (memberResponse != null)
                    companyUserId = memberResponse.companyUserId;

                candidateSearchTotalDTO candidate = await _candidateService.GetAllCandidateFromTalentGroupAndSearch(search, companyUserId, token);

                if (candidate != null)
                    return Ok(new { message = "Candidatos consultados exitosamente", obj = candidate });
                else
                    return NotFound(new { message = "No se encontraron Candidatos" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /**/

        [HttpPost("candidatesSearchByTalentGroup")]
        public async Task<ObjectResult> GetCandidatesSearchByTalentGroup([FromBody] SearchByIdAndTextWithPaginationDTO search)
        {
            try
            {
                StringValues token = "";
                Request.Headers.TryGetValue("Authorization", out token);

                MemberByToken memberResponse = await _companyRemoteRepository.GetMemberUserFromCandidate(token.ToString());

                int companyUserId = 0;

                if (memberResponse != null)
                    companyUserId = memberResponse.companyUserId;

                candidateSearchTotalDTO candidate = await _candidateService.SearchCandidatesByTalentGroup(search, companyUserId, token);

                if (candidate != null)
                    return Ok(new { message = "Candidatos consultados exitosamente", obj = candidate });
                else
                    return NotFound(new { message = "No se encontraron Candidatos" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /**/

        [HttpPost("candidatesFromJobIdAndSearch")]
        public async Task<ObjectResult> GetCandidatesFromJobIdAndSearch([FromBody] SearchByIdAndTextWithPaginationDTO search)
        {
            try
            {
                StringValues token = "";
                Request.Headers.TryGetValue("Authorization", out token);

                MemberByToken memberResponse = await _companyRemoteRepository.GetMemberUserFromCandidate(token.ToString());

                int companyUserId = 0;

                if (memberResponse != null)
                    companyUserId = memberResponse.companyUserId;

                candidateSearchTotalDTO candidate = await _candidateService.GetAllCandidateFromJobAndSearch(search, companyUserId, token);

                if (candidate != null)
                    return Ok(new { message = "Candidatos consultados exitosamente", obj = candidate });
                else
                    return NotFound(new { message = "No se encontraron Candidatos" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /**/

        [HttpPost("candidatesSearchByJob")]
        public async Task<ObjectResult> GetCandidatesSearchByJob([FromBody] SearchByIdAndTextWithPaginationDTO search)
        {
            try
            {
                StringValues token = "";
                Request.Headers.TryGetValue("Authorization", out token);

                MemberByToken memberResponse = await _companyRemoteRepository.GetMemberUserFromCandidate(token.ToString());

                int companyUserId = 0;

                if (memberResponse != null)
                    companyUserId = memberResponse.companyUserId;

                candidateSearchTotalDTO candidate = await _candidateService.SearchCandidatesByJob(search, companyUserId, token);

                if (candidate != null)
                    return Ok(new { message = "Candidatos consultados exitosamente", obj = candidate });
                else
                    return NotFound(new { message = "No se encontraron Candidatos" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /**/

        [HttpPost("candidatesSearchGeneral")]
        public async Task<ObjectResult> GetCandidatesSearchGeneral([FromBody] SearchByIdAndTextWithPaginationDTO search)
        {
            try
            {
                StringValues token = "";
                Request.Headers.TryGetValue("Authorization", out token);

                MemberUserDTO memberResponse = await _memberUserService.GetMemberUserFromCandidate(token);

                int companyUserId = 0;

                if (memberResponse != null)
                    companyUserId = memberResponse.CompanyUserId;

                int exsisUserId = 0;

                if (_s3Settings.AWSS3.BucketName == "recruitment-bucket-prod")
                    exsisUserId = 3;
                else
                    exsisUserId = 4;

                bool isMaster = await _companyUserService.IsMaster(token);

                bool isExsis = false;

                if(exsisUserId == companyUserId)
                    isExsis = true;

                candidateSearchTotalDTO candidate = await _candidateService.SearchCandidatesGeneral(search, companyUserId, isExsis, isMaster, token);

                if (candidate != null)
                    return Ok(new { message = "Candidatos consultados exitosamente", obj = candidate });
                else
                    return NotFound(new { message = "No se encontraron Candidatos" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /**/

        [AllowAnonymous]
        [HttpPost("ReportCandidate/{portalId}/{companyUserId}")]
        public async Task<IActionResult> ExportCandidates([FromForm] DatesReportDTO dates, int portalId, int companyUserId)
        {
            try
            {
                /* language */
                // 1 = Español.
                // 2 = English.

                List<CandidateReportDTO> candidates = await _candidateService.GetAllCandidatesWithDate(dates.LeftDate, dates.RightDate,
                        dates.EmailMemberUser, portalId, companyUserId, dates.Language);

                if (candidates != null)
                    return Ok(new { message = "Candidatos consultados exitosamente", obj = candidates });
                else
                    return NotFound(new { message = "No se encontraron Candidatos" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("reportCandidateWithFilter")]
        public async Task<IActionResult> ExportCandidatesWithFilter([FromBody] DatesReportWithFiltersDTO dates)
        {
            try
            {
                /* language */
                // 1 = Español.
                // 2 = English.

                var candidate = await _candidateService.GetAllCandidatesWithDateAndFilter
                (
                    dates.EmailMemberUser,
                    dates.IsLanguagesFilter, dates.IsFullLanguages, dates.LanguagesFilter,
                    dates.IsTechnicalAbilitiesFilter, dates.IsFullTechnicalAbilities, dates.TechnicalAbilitiesFilter,
                    dates.IsLocationFilter, dates.IsFullLocations, dates.Country, dates.State, dates.City,
                    dates.IsSalaryAspirationFilter, dates.IsFullSalaryAspirations, dates.SalaryAspirationFilter,
                    dates.PortalId, dates.CompanyUserId, dates.Language
                );

                if (candidate != null)
                    return Ok(new { message = "Candidatos consultados exitosamente", obj = candidate });
                else
                    return NotFound(new { message = "No se encontraron Candidatos" });
            }
            catch (Exception ex)
            {
               if(ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                    return StatusCode(500, new { message = ex.Message + " - " + ex.InnerException.Message });

                return StatusCode(500, new { message = ex.Message });
            }

        }

        [AllowAnonymous]
        [HttpPost("sendRequest/{language}")]
        public async Task<IActionResult> SendRequest([FromForm] RequestDTO req, int language)
        {
            try
            {
                Candidate candidate = await _candidateService.GetCandidateToRequest(req);
                if (candidate != null)
                {
                    Request request = _mapper.Map<RequestDTO, Request>(req);
                    request.CreationDate = DateTime.Parse(_matchServerDate.CreateServerDate());
                    request.CandidateId = candidate.CandidateId;
                    bool created = await _requestRepository.Add(request);
                    if (created == true)
                    {
                        string initial = "";
                        string photo = "";
                        string name = "";
                        if (candidate.BasicInformation != null)
                        {
                            if (!String.IsNullOrEmpty(candidate.BasicInformation.Photo) && candidate.BasicInformation.Photo != null)
                                photo = candidate.BasicInformation.Photo;
                            else
                                photo = null;
                            if (!String.IsNullOrEmpty(candidate.BasicInformation.Name) && candidate.BasicInformation.Name != null && !String.IsNullOrEmpty(candidate.BasicInformation.Surname) && candidate.BasicInformation.Surname != null)
                            {
                                var initialName = candidate.BasicInformation.Name[0];
                                var initialSurnameName = candidate.BasicInformation.Surname[0];
                                initial = (initialName + "" + initialSurnameName).ToUpper();
                            }
                            else if (!String.IsNullOrEmpty(candidate.BasicInformation.Name) && String.IsNullOrEmpty(candidate.BasicInformation.Surname))
                            {
                                var initialName = candidate.BasicInformation.Name[0];
                                var secondName = candidate.BasicInformation.Name[1];
                                initial = (initialName + "" + secondName).ToUpper();
                            }
                            name = candidate.BasicInformation.Name + " " + candidate.BasicInformation.Surname;
                        }
                        if ((candidate.BasicInformation == null && !string.IsNullOrEmpty(candidate.Email) && candidate.Email != null))
                        {
                            name = candidate.Email;
                            var sub = name.Substring(0, 2);
                            initial = sub.ToUpper();
                        }
                        NotificationDTO notification = new NotificationDTO()
                        {
                            candidate = name,
                            initial = initial,
                            photo = photo,
                            candidateId = candidate.CandidateId,
                            requestTypeId = req.RequestTypeId,
                            candidateFull = _mapper.Map<Candidate, CandidateNotificationDTO>(candidate)
                        };

                        var notificationRequest = await _companyRemoteRepository.AddNotificationFromRequest(notification, language);

                        if (notification.requestTypeId == 2 && !candidate.IsDeleteProccess)
                        {
                            Candidate candidateChangeStatus = await _candidateRepository.ChangeDeleteStateCandidate(candidate.CandidateId);
                            if (candidateChangeStatus != null && candidateChangeStatus.IsDeleteProccess)
                            {
                                Request delete = new Request()
                                {
                                    Message = "el footer",
                                    RequestTypeId = 3,
                                    CandidateId = candidateChangeStatus.CandidateId,
                                    CreationDate = DateTime.Parse(_matchServerDate.CreateServerDate())
                                };

                                bool createdRequest = await _requestRepository.Add(delete);
                            }
                        }


                        return Ok(new { message = "Solicitud guardada exitosamente", obj = request });
                    }

                    else
                        return NotFound(new { message = "No se pudo almacenar la solicitud" });
                }
                else
                    return NotFound(new { message = "No se encontro ningun candidato asociado a ese email" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("CandidateRequest")]
        public async Task<IActionResult> CandidateRequestDelete([FromForm] RequestDTO req)
        {
            try
            {
                Candidate candidate = await _candidateService.GetCandidateToRequest(req);
                if (candidate != null)
                {
                    bool validated;
                    List<Request> requestDelete = await _requestRepository.getDeleteRequest(candidate.CandidateId);
                    if (requestDelete != null && requestDelete.Count > 0 || candidate.IsDeleteProccess == true)
                        validated = true;
                    else
                        validated = false;

                    return Ok(new { message = "Consulta Exitosa", obj = validated });
                }
                return NotFound(new { message = "No se encontro ningun candidato asociado a ese email" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpDelete("deleteReques/{requestId}")]
        public async Task<IActionResult> deleteRequest(int requestId)
        {
            try
            {
                Request deleted = await _requestRepository.Remove(requestId);
                if (deleted != null)
                    return Ok(new { message = "Solicitud borrada exitosamente" });
                else
                    return NotFound(new { message = "No se pudo borrar la solicitud" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("editDeleteStatus/{candidateId}/{language}")]
        public async Task<IActionResult> EditDeleteStatus(int candidateId, int language)
        {
            try
            {
                StringValues token = "";
                Request.Headers.TryGetValue("Authorization", out token);
                string validation = "DeleteCandidateHV";

                var isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, token.ToString());
                if (!isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });


                MemberByToken member = await _companyRemoteRepository.GetMemberUserFromCandidate(token.ToString());

                Candidate candidate = await _candidateRepository.ChangeDeleteState(candidateId, member.email);

                if (candidate != null)
                {
                    if (candidate.IsDeleteProccess == true)
                    {
                        Request delete = new Request()
                        {
                            Name = member.name,
                            Surname = member.surname,
                            Message = "HV",
                            RequestTypeId = 3,
                            CandidateId = candidateId,
                            CreationDate = DateTime.Parse(_matchServerDate.CreateServerDate())
                        };

                        bool created = await _requestRepository.Add(delete);

                        string name = "";
                        if (candidate.BasicInformation != null)
                        {
                            name = candidate.BasicInformation.Name + " " + candidate.BasicInformation.Surname;
                        }
                        if ((candidate.BasicInformation == null && !string.IsNullOrEmpty(candidate.Email) && candidate.Email != null))
                        {
                            name = candidate.Email;
                        }
                        NotificationDTO notification = new NotificationDTO()
                        {
                            candidate = name,
                            candidateId = candidate.CandidateId
                        };

                        bool notificationRequest = false;

                        bool isMaster = await _companyRemoteRepository.isMaster(token.ToString());

                        if (isMaster)
                        {
                            notificationRequest = await _companyRemoteRepository.AddNotificationFromDeleteMemberFromMaster(notification, language, token.ToString());
                        }
                        else
                        {
                            notificationRequest = await _companyRemoteRepository.AddNotificationFromDeleteMember(notification, language, token.ToString());
                        }
                    }

                    return Ok(new { message = "Consulta exitosa.", obj = candidate });
                }
                else
                {
                    return Ok(new { message = "Candidato no encontrado." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("editViewSelectionFiles/{candidateId}")]
        public async Task<IActionResult> EditViewSelectionFiles(int candidateId)
        {
            try
            {

                StringValues token = "";
                Request.Headers.TryGetValue("Authorization", out token);


                Candidate candidate = await _candidateRepository.ChangeViewSelectionFiles(candidateId);

                if (candidate != null)
                    return Ok(new { message = "Consulta exitosa.", obj = candidate });
                else
                    return BadRequest(new { message = "Candidato no encontrado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("editViewHiringFiles/{candidateId}")]
        public async Task<IActionResult> EditViewHiringFiles(int candidateId)
        {
            try
            {

                StringValues token = "";
                Request.Headers.TryGetValue("Authorization", out token);


                Candidate candidate = await _candidateRepository.ChangeViewHiringFiles(candidateId);

                if (candidate != null)
                    return Ok(new { message = "Consulta exitosa.", obj = candidate });
                else
                    return BadRequest(new { message = "Candidato no encontrado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }



        [HttpPost("editDeleteStatusCandidate/{candidateId}/{language}")]
        public async Task<IActionResult> EditDeleteStatusCandidate(int candidateId, int language)
        {
            try
            {
                StringValues token = "";
                Request.Headers.TryGetValue("Authorization", out token);

                Candidate aux = await _candidateRepository.GetByCandidateId(candidateId);
                if (aux != null && !aux.IsDeleteProccess)
                {
                    Candidate candidate = await _candidateRepository.ChangeDeleteStateCandidate(candidateId);
                    if (candidate != null)
                    {
                        Request delete = new Request()
                        {
                            Message = "Portal Candidato",
                            RequestTypeId = 3,
                            CandidateId = candidateId,
                            CreationDate = DateTime.Parse(_matchServerDate.CreateServerDate())
                        };

                        bool created = await _requestRepository.Add(delete);

                        string initial = "";
                        string photo = "";
                        string name = "";
                        if (candidate.BasicInformation != null)
                        {
                            if (!String.IsNullOrEmpty(candidate.BasicInformation.Photo) && candidate.BasicInformation.Photo != null)
                                photo = candidate.BasicInformation.Photo;
                            else
                                photo = null;
                            if (!String.IsNullOrEmpty(candidate.BasicInformation.Name) && candidate.BasicInformation.Name != null && !String.IsNullOrEmpty(candidate.BasicInformation.Surname) && candidate.BasicInformation.Surname != null)
                            {
                                var initialName = candidate.BasicInformation.Name[0];
                                var initialSurnameName = candidate.BasicInformation.Surname[0];
                                initial = (initialName + "" + initialSurnameName).ToUpper();
                            }
                            else if (!String.IsNullOrEmpty(candidate.BasicInformation.Name) && String.IsNullOrEmpty(candidate.BasicInformation.Surname))
                            {
                                var initialName = candidate.BasicInformation.Name[0];
                                var secondName = candidate.BasicInformation.Name[1];
                                initial = (initialName + "" + secondName).ToUpper();
                            }
                            name = candidate.BasicInformation.Name + " " + candidate.BasicInformation.Surname;
                        }
                        if ((candidate.BasicInformation == null && !string.IsNullOrEmpty(candidate.Email) && candidate.Email != null))
                        {
                            name = candidate.Email;
                            var sub = name.Substring(0, 2);
                            initial = sub.ToUpper();
                        }
                        NotificationDTO notification = new NotificationDTO()
                        {
                            candidate = name,
                            candidateId = candidate.CandidateId,
                            initial = initial,
                            photo = photo
                        };

                        var notificationRequest = await _companyRemoteRepository.AddNotificationFromDeleteCandidateFromCandidate(notification, language, token.ToString());


                        return Ok(new { message = "Consulta exitosa.", obj = candidate });
                    }
                    else
                    {
                        return Ok(new { message = "Candidato no encontrado." });
                    }
                }
                else
                    return BadRequest(new { message = "Actualmente esta en un proceso de eliminacion" });


            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        #endregion

        #region PATCH/PUT

        //

        [HttpPatch("editEmail")]
        public async Task<IActionResult> EditEmailCandidate([FromBody] CandidateChangeEmailDTO candidateChangeEmailDTO)
        {
            try
            {
                if (candidateChangeEmailDTO.Email == null || String.IsNullOrEmpty(candidateChangeEmailDTO.Email))
                    return BadRequest(new { message = "No ingreso email valido para editar." });

                var candidate = await _candidateRepository.GetByCandidateId(candidateChangeEmailDTO.CandidateId);
                if (candidate != null)
                {
                    candidate.Email = candidateChangeEmailDTO.Email;

                    var edited = await _candidateRepository.Update(candidate);
                    if (edited)
                    {
                        CandidateDTO candidateDTO = _mapper.Map<Candidate, CandidateDTO>(candidate);
                        return Ok(new { message = "Email candidato editado exitosamente", obj = candidateDTO });
                    }
                    else
                        return BadRequest(new { message = "El email del candidato no fue editado." });
                }
                else
                    return NotFound(new { message = "El candidato no existe." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.InnerException });
            }
        }

        [HttpPatch("old/{candidateId}")]
        public async Task<IActionResult> CandidateOld(int candidateId)
        {
            try
            {
                bool exists = _candidateRepository.CandidateExistById(candidateId);

                if (exists)
                {
                    Candidate candidate = await _candidateRepository.GetById(candidateId);

                    if (candidate.IsNew)
                    {
                        candidate.IsNew = false;

                        bool updated = await _candidateRepository.Update(candidate);

                        if (updated)
                        {
                            CandidateDTO candidateDTO = _mapper.Map<Candidate, CandidateDTO>(candidate);

                            return Ok(new { message = "Candidato actualizado exitosamente", obj = candidateDTO });
                        }
                        else
                            return NotFound(new { message = "No se pudo actualizar el candidato" });
                    }
                    else
                        return StatusCode(400, new { message = "El candidato no era nuevo" });
                }

                else
                    return NotFound(new { message = "El candidato no existe", obj = exists });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /* PATCH method. Upload & analyze files */
        [AllowAnonymous]
        [HttpPatch("uploadCognitoUser")]
        public async Task<IActionResult> UploadCognitoUser([FromBody] ChangeEmailCognitoDTO emails)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                bool oldCandidateExists = await _candidateRepository.CandidateExistByEmail(emails.OldEmail);
                bool newCandidateExists = await _candidateRepository.CandidateExistByEmail(emails.NewEmail);

                if (!oldCandidateExists)
                    return BadRequest(new { message = "Usuario no existe" });

                if (newCandidateExists)
                    return BadRequest(new { message = "Ya existe un usuario con el correo ingresado" });

                Candidate candidate = await _candidateRepository.GetByEmail(emails.OldEmail);

                if (candidate != null)
                    candidate.BasicInformation = await _basicInformationRepository.GetByCandidateId(candidate.CandidateId);

                candidate.Email = emails.NewEmail;

                bool isEditedFromDB = await _candidateRepository.Update(candidate);

                if (isEditedFromDB)
                {
                    bool isEdited = await _AWSCognitoUpdateUserService.CognitoUserEdition(emails.OldEmail, emails.NewEmail);

                    if (isMaster)
                    {
                        string candidateInitials = "";
                        string candidateFullName = "";
                        string candidatePhoto = "";

                        string memberUserInitials = "";
                        string memberUserFullName = "";
                        string memberUserPhoto = "";

                        if (candidate.BasicInformation != null)
                        {
                            candidateInitials = !string.IsNullOrEmpty(candidate.BasicInformation.Name) ? candidate.BasicInformation.Name[0].ToString() : "";
                            candidateInitials += !string.IsNullOrEmpty(candidate.BasicInformation.Surname) ? candidate.BasicInformation.Surname[0].ToString() : "";

                            candidateFullName = !string.IsNullOrEmpty(candidate.BasicInformation.Name) ? candidate.BasicInformation.Name : "";
                            candidateFullName += !string.IsNullOrEmpty(candidate.BasicInformation.Surname) ? " " + candidate.BasicInformation.Surname : "";

                            candidatePhoto = candidate.BasicInformation.Photo;
                        }

                        List<MemberByToken> remoteMemberUsers = await _companyRemoteRepository.GetAllMemberUserByToken(values);
                        MemberByToken memberUser = new MemberByToken();

                        if (remoteMemberUsers != null && remoteMemberUsers.Count > 0)
                            memberUser = remoteMemberUsers[0];

                        if (memberUser != null)
                        {
                            memberUserInitials = !string.IsNullOrEmpty(memberUser.name) ? memberUser.name[0].ToString() : "";
                            memberUserInitials += !string.IsNullOrEmpty(memberUser.surname) ? memberUser.surname[0].ToString() : "";

                            if (string.IsNullOrEmpty(memberUser.surname) && memberUserInitials.Count() == 1)
                                memberUserInitials += !string.IsNullOrEmpty(memberUser.name) ? memberUser.name[0].ToString() : "";

                            memberUserFullName = !string.IsNullOrEmpty(memberUser.name) ? memberUser.name : "";
                            memberUserFullName += !string.IsNullOrEmpty(memberUser.surname) ? " " + memberUser.surname : "";

                            memberUserPhoto = memberUser.photo;
                        }

                        NotificationAttachedFileDTO notificationOutDTO = new NotificationAttachedFileDTO
                        {
                            candidateId = candidate.CandidateId,
                            candidateName = candidateFullName,
                            candidateInitials = candidateInitials,
                            candidatePhoto = candidatePhoto,
                            attachedFileName = "",
                            memberUserName = memberUserFullName,
                            memberUserInitials = memberUserInitials,
                            memberUserPhoto = memberUserPhoto,
                        };

                        bool isNotificationCreated = await _companyRemoteRepository.AddNotificationEditCandidateEmailFromMaster(notificationOutDTO, values);
                    }

                    if (isEdited)
                        return Created("", new { message = "Usuario editado", email = emails.NewEmail });

                    return BadRequest(new { message = "Usuario no editado" });
                }

                return BadRequest(new { message = "Usuario no editado" });
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null || ex.InnerException.ToString() == "")
                    return StatusCode(500, new { message = ex.Message });

                return StatusCode(500, new { message = ex.InnerException });
            }
        }

        [HttpPatch("uploadMainEmail")]
        public async Task<IActionResult> UploadMainEmail([FromBody] ChangeEmailCognitoDTO emails)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "EditBasicInfo";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());

                if (!isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                bool oldCandidateExists = await _candidateRepository.CandidateExistByEmail(emails.OldEmail);
                bool newCandidateExists = await _candidateRepository.CandidateExistByEmail(emails.NewEmail);

                if (!oldCandidateExists)
                    return NotFound(new { message = "Usuario no existe" });

                if (newCandidateExists)
                    return BadRequest(new { message = "Ya existe un usuario con el correo ingresado" });

                Candidate candidate = await _candidateRepository.GetByEmail(emails.OldEmail);

                candidate.Email = emails.NewEmail;

                bool isEditedFromDB = await _candidateRepository.Update(candidate);

                if (isEditedFromDB)
                    return Created("", new { message = "Usuario editado", email = emails.NewEmail });

                return BadRequest(new { message = "Usuario no editado" });
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null || ex.InnerException.ToString() == "")
                    return StatusCode(500, new { message = ex.Message });

                return StatusCode(500, new { message = ex.InnerException });
            }
        }

        [HttpPatch("mergeCandidates/{language}")]
        public async Task<IActionResult> MergeCandidates([FromBody] MergeCandidatesDTO mergeCandidatesDTO, int language)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);

                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                if (memberUser == null)
                    return StatusCode(404, new { message = "No existe el usuario empresa" });

                Candidate mainCandidate = new();

                if (mergeCandidatesDTO != null && !string.IsNullOrEmpty(mergeCandidatesDTO.MainCandidate))
                    mainCandidate = await _candidateRepository.GetByEmail(mergeCandidatesDTO.MainCandidate);

                if (mainCandidate == null)
                    return StatusCode(404, new { message = "No existe el candidato" });

                BasicInformation mainBasicInformation = await _basicInformationRepository.GetByCandidateId(mainCandidate.CandidateId);

                if (mainBasicInformation == null)
                {
                    mainBasicInformation = new BasicInformation
                    {
                        CandidateId = mainCandidate.CandidateId
                    };

                    await _basicInformationRepository.Add(mainBasicInformation);

                    mainBasicInformation = await _basicInformationRepository.GetByCandidateId(mainCandidate.CandidateId);
                }

                if (mergeCandidatesDTO != null && mergeCandidatesDTO.OtherCandidates != null && mergeCandidatesDTO.OtherCandidates.Count > 0)
                {
                    foreach (string otherEmail in mergeCandidatesDTO.OtherCandidates)
                    {
                        if (!string.IsNullOrEmpty(otherEmail))
                        {
                            Candidate otherCandidate = await _candidateRepository.GetByEmail(otherEmail);

                            if (otherCandidate == null)
                                break;

                            if (otherCandidate.IsMigrated != 0 && !otherCandidate.IsFromCompanyAndLogin)
                            {
                                List<AttachedFile> attachedFiles = await _attachedFileRepository.GetByCandidateId(otherCandidate.CandidateId);

                                if (attachedFiles != null && attachedFiles.Count > 0)
                                {
                                    foreach (AttachedFile attachedFile in attachedFiles)
                                    {
                                        attachedFile.CandidateId = mainCandidate.CandidateId;

                                        await _attachedFileRepository.Update(attachedFile);
                                    }
                                }

                                /**/

                                List<AttachedFileHiring> attachedFilesHiring = await _attachedFileHiringRepository.GetByCandidateIdAndCompanyId(otherCandidate.CandidateId, memberUser.CompanyUserId);

                                if (attachedFilesHiring != null && attachedFilesHiring.Count > 0)
                                {
                                    foreach (AttachedFileHiring attachedFile in attachedFilesHiring)
                                    {
                                        attachedFile.CandidateId = mainCandidate.CandidateId;

                                        await _attachedFileHiringRepository.Update(attachedFile);
                                    }
                                }

                                CV cv = await _cvRepository.GetByCandidateId(otherCandidate.CandidateId);

                                if (cv != null)
                                {
                                    cv.CandidateId = mainCandidate.CandidateId;

                                    await _cvRepository.Update(cv);
                                }

                                List<CVHiring> cvsHiring = await _cvHiringRepository.GetAllByCandidateIdAndCompanyUserId(otherCandidate.CandidateId, memberUser.CompanyUserId);

                                if (cvsHiring != null && cvsHiring.Count > 0)
                                {
                                    foreach (CVHiring cvHiring in cvsHiring)
                                    {
                                        cvHiring.CandidateId = mainCandidate.CandidateId;

                                        await _cvHiringRepository.Update(cvHiring);
                                    }
                                }

                                /**/

                                List<Note> notes = await _noteRepository.GetByCandidateId(otherCandidate.CandidateId);

                                if (notes != null && notes.Count > 0)
                                {
                                    foreach (Note note in notes)
                                    {
                                        note.CandidateId = mainCandidate.CandidateId;

                                        await _noteRepository.Update(note);
                                    }
                                }

                                /**/

                                Email mainEmail = new Email
                                {
                                    Mail = otherEmail,
                                    BasicInformationId = mainBasicInformation.BasicInformationId,
                                    CompanyUserId = memberUser.CompanyUserId
                                };

                                await _emailRepository.Add(mainEmail);

                                BasicInformation otherBasicInformation = await _basicInformationRepository.GetByCandidateId(otherCandidate.CandidateId);

                                if (otherBasicInformation != null)
                                {
                                    List<Email> emails = await _emailRepository.GetByBasicInfoIdAsync(otherCandidate.CandidateId);

                                    if (emails != null && emails.Count > 0)
                                    {
                                        foreach (Email email in emails)
                                        {
                                            email.BasicInformationId = mainBasicInformation.BasicInformationId;
                                            email.CompanyUserId = memberUser.CompanyUserId;

                                            await _emailRepository.Update(email);
                                        }
                                    }
                                }

                                /**/

                                List<Mail> mails = await _mailRepository.GetAllMailByCandidateAndCompanyId(otherCandidate.CandidateId, memberUser.CompanyUserId);

                                if (mails != null && mails.Count > 0)
                                {
                                    foreach (Mail mail in mails)
                                    {
                                        mail.CandidateId = mainCandidate.CandidateId;
                                        mail.CompanyUserId = memberUser.CompanyUserId;

                                        bool isUpdated = await _mailRepository.Update(mail);
                                    }
                                }

                                /**/

                                Candidate candidateEdited = await _candidateRepository.ChangeDeleteState(otherCandidate.CandidateId, memberUser.Email);

                                if (candidateEdited != null)
                                {
                                    if (candidateEdited.IsDeleteProccess == true)
                                    {
                                        Request delete = new Request()
                                        {
                                            Name = memberUser.Name,
                                            Surname = memberUser.Surname,
                                            Message = "HV",
                                            RequestTypeId = 3,
                                            CandidateId = otherCandidate.CandidateId,
                                            CreationDate = DateTime.Parse(_matchServerDate.CreateServerDate())
                                        };

                                        bool created = await _requestRepository.Add(delete);

                                        string name = "";
                                        if (candidateEdited.BasicInformation != null)
                                        {
                                            name = candidateEdited.BasicInformation.Name + " " + candidateEdited.BasicInformation.Surname;
                                        }
                                        if ((candidateEdited.BasicInformation == null && !string.IsNullOrEmpty(candidateEdited.Email) && candidateEdited.Email != null))
                                        {
                                            name = candidateEdited.Email;
                                        }
                                        NotificationDTO notification = new NotificationDTO()
                                        {
                                            candidate = name,
                                            candidateId = candidateEdited.CandidateId
                                        };

                                        var notificationRequest = await _companyRemoteRepository.AddNotificationFromDeleteMember(notification, language, values.ToString());
                                    }
                                }
                            }
                        }
                    }
                }

                return StatusCode(200, new { message = "Usuario actualizado", obj = mainCandidate });
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        #endregion

        #region DELETE

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidateById(int id)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                Candidate candidate = await _candidateRepository.Remove(id);
                object[] ans = await _candidateRepository.EditEditionDate(id);

                if (candidate == null && ans != null && ans.Count() == 2 && (bool)ans[0])
                    return NotFound(new { message = "El candidato no fue encontrado." });

                //await _candidateLanguageRepository.Remove(candidateLanguage.Candidate_LanguageId);
                //Candidate_LanguageDTO candidateLanguageDTO = _mapper.Map<Candidate_Language, Candidate_LanguageDTO>(candidateLanguage);
                await _companyRemoteRepository.DeletePostulationsByCandidateId(id, values.ToString());

                return Ok(new { message = "Candidato eliminado exitosamente.", obj = candidate });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        #endregion

        #region TEST

        [AllowAnonymous]
        [HttpGet("test")]
        public IActionResult TestService()
        {
            try
            {
                return StatusCode(200, new { message = "Respuestta exitosa del Sercivio 'Candidate'", obj = true });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        #endregion
    }
}
