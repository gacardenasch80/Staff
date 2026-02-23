using AutoMapper;
using CandidatesMS.Helpers;
using CandidatesMS.KeyVault.SecretsModels;
using CandidatesMS.Models;
using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.Models.RemoteModels.Out;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using CandidatesMS.Repositories.RemoteRepositories;
using CandidatesMS.RepositoriesCompany;
using CandidatesMS.KeyVault.SecretsModels;
using CandidatesMS.Services;
using CandidatesMS.ServicesCompany;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using S3bucketDemo.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasicInformationController : ControllerBase
    {
        private readonly IAWSS3FileService _AWSS3FileService;
        private IEmailRepository _emailRepository;
        private IUserLinkRepository _userLinkRepository;
        private IPhoneRepository _phoneRepository;
        private ISocialNetworkRepository _socialNetworkRepository;
        private IBasicInformationRepository _basicInformationRepository;
        private ICandidateRepository _candidateRepository;
        private IUploadTimeService _uploadTimeService;
        private IDocumentTypeRepository _documentTypeRepository;
        private IMaritalStatusRepository _maritalStatusRepository;
        private IMemberUserRepository _memberUserRepository;
        private IGenderRepository _genderRepository;
        private ICompanyRemoteRepository _companyRemoteRepository;
        private ICandidateCompanyRepository _candidateCompanyRepository;
        private INoteRepository _noteRepository;

        private IBasicInformationService _basicInformationService;
        private IAuthorizationHelper _authorizationHelper;
        private readonly Services.IValidateMethodsService _validateMethodsService;

        private IMapper _mapper;

        private readonly ServiceConfigurationDTO _settings;
        private readonly ServiceConfigurationDTO _s3Settings;

        public BasicInformationController(IBasicInformationRepository basicInformationRepository, IMapper mapper, IUploadTimeService uploadTimeService,
            IUserLinkRepository userLinkRepository, IPhoneRepository phoneRepository, ISocialNetworkRepository socialNetworkRepository,
            IAWSS3FileService AWSS3FileService, ICandidateRepository candidateRepository, IEmailRepository emailRepository,
            IDocumentTypeRepository documentTypeRepository, IGenderRepository genderRepository, IMaritalStatusRepository maritalStatusRepository,
            IMemberUserRepository memberUserRepository, IAuthorizationHelper authorizationHelper, ICandidateCompanyRepository candidateCompanyRepository,
            IBasicInformationService basicInformationService, ICompanyRemoteRepository companyRemoteRepository, INoteRepository noteRepository,

            Services.IValidateMethodsService validateMethodsService,

                                    IOptions<ServiceConfigurationDTO> settings,
                                    IOptions<ServiceConfigurationDTO> s3settings)
        {
            _basicInformationRepository = basicInformationRepository;
            _emailRepository = emailRepository;
            _uploadTimeService = uploadTimeService;
            _userLinkRepository = userLinkRepository;
            _phoneRepository = phoneRepository;
            _socialNetworkRepository = socialNetworkRepository;
            _candidateRepository = candidateRepository;
            _mapper = mapper;
            _AWSS3FileService = AWSS3FileService;
            _documentTypeRepository = documentTypeRepository;
            _maritalStatusRepository = maritalStatusRepository;
            _memberUserRepository = memberUserRepository;
            _genderRepository = genderRepository;
            _companyRemoteRepository = companyRemoteRepository;
            _candidateCompanyRepository = candidateCompanyRepository;
            _noteRepository = noteRepository;

            _basicInformationService = basicInformationService;
            _authorizationHelper = authorizationHelper;
            _validateMethodsService = validateMethodsService;

            _settings = settings.Value;
            _s3Settings = s3settings.Value;
        }

        #region GET

        [HttpGet]
        public async Task<IActionResult> GetAllBasicInformations()
        {
            try
            {
                List<BasicInformation> basicInformations = await _basicInformationRepository.GetAll();

                if (basicInformations != null && basicInformations.Count > 0)
                {
                    List<BasicInformationsDTO> basicInformationsDTO = _mapper.Map<List<BasicInformation>, List<BasicInformationsDTO>>(basicInformations);

                    foreach (BasicInformationsDTO basicInformation in basicInformationsDTO)
                    {
                        if (string.IsNullOrEmpty(basicInformation.Surname))
                        {
                            basicInformation.Surname = "";
                        }
                    }

                    return Ok(new { message = "Informaciones básicas consultadas exitosamente", obj = basicInformationsDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron informaciones básicas" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{basicInformationId}")]
        public async Task<IActionResult> GetBasicInformationById(int basicInformationId)
        {
            try
            {
                BasicInformation basicInformation = await _basicInformationRepository.GetById(basicInformationId);

                if (basicInformation != null)
                {
                    BasicInformationDTO basicInformationDTO = _mapper.Map<BasicInformation, BasicInformationDTO>(basicInformation);

                    return Ok(new { message = "Información básica consultada exitosamente", obj = basicInformationDTO });
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

        [HttpGet("guid/{basicInformationGuid}")]
        public async Task<IActionResult> GetBasicInformationByGuid(string basicInformationGuid)
        {
            try
            {
                BasicInformation basicInformation = await _basicInformationRepository.GetByGuid(basicInformationGuid);

                if (basicInformation == null)
                    return NotFound(new { message = "No se encontró el candidato" });

                BasicInformationDTO basicInformationDTO = _mapper.Map<BasicInformation, BasicInformationDTO>(basicInformation);
                return Ok(new { message = "Información básica consultada exitosamente", obj = basicInformationDTO });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("candidate/{candidateId}")]
        public async Task<IActionResult> GetBasicInformationsByCandidateId(int candidateId)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                Candidate candidate = await _candidateRepository.GetById(candidateId);
                if (candidate == null)
                    return NotFound(new { message = "No se encontró el candidato" });

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

                if (DateTime.TryParseExact(candidate.CreationDate, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out creationDate)) ;
                else
                    creationDate = Convert.ToDateTime(candidate.CreationDate);

                if (DateTime.TryParseExact(candidate.FirstLoginDate, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture,
                   DateTimeStyles.None, out firstLoginDate)) ;
                else
                    firstLoginDate = Convert.ToDateTime(candidate.FirstLoginDate);

                //string creationIfo = _uploadTimeService.GetCandidateCreationInfo(creationDate.ToString(), firstLoginDate.ToString(), candidate.IsMigrated, candidate.Source, name, candidate.IsFromCompanyAndLogin);
                string creationShortInfo = _uploadTimeService.GetCandidateCreationShortInfo(creationDate.ToString(), candidate.IsMigrated, candidate.Source);
                string firstLoginInfoPup = _uploadTimeService.GetFormatColombian(candidate.FirstLoginDate);

                if (basicInformation != null)
                {
                    BasicInformationDTO basicInformationDTO = _mapper.Map<BasicInformation, BasicInformationDTO>(basicInformation);
                    basicInformationDTO.Email = candidate.Email;
                    basicInformationDTO.IsMigrated = candidate.IsMigrated;
                    basicInformationDTO.IsFromCompanyAndLogin = candidate.IsFromCompanyAndLogin;
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


                    return Ok(new { message = "Información básica consultada exitosamente", obj = basicInformationDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró información básica asociada a el candidato" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /**/

        [HttpPost("candidates/{companyUserId}")]
        public async Task<IActionResult> GetBasicInformationsByCandidateIds(int companyUserId, [FromBody] List<int> candidatesIds)
        {
            try
            {
                List<BasicInformationDTO> basicInformations = new List<BasicInformationDTO>();

                if (candidatesIds != null && candidatesIds.Count > 0)
                {
                    foreach (int candidateId in candidatesIds)
                    {
                        bool candidateExists = _candidateRepository.CandidateExistById(candidateId);

                        if (candidateExists)
                        {
                            StringValues values = "";
                            Request.Headers.TryGetValue("Authorization", out values);

                            Candidate candidate = await _candidateRepository.GetById(candidateId);
                            if (candidate == null)
                                return NotFound(new { message = "No se encontró el candidato" });

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

                            if (DateTime.TryParseExact(candidate.CreationDate, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture,
                                DateTimeStyles.None, out creationDate)) ;
                            else
                                creationDate = Convert.ToDateTime(candidate.CreationDate);

                            if (DateTime.TryParseExact(candidate.FirstLoginDate, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture,
                               DateTimeStyles.None, out firstLoginDate)) ;
                            else
                                firstLoginDate = Convert.ToDateTime(candidate.FirstLoginDate);

                            string creationShortInfo = _uploadTimeService.GetCandidateCreationShortInfo(creationDate.ToString(), candidate.IsMigrated, candidate.Source);
                            string firstLoginInfoPup = _uploadTimeService.GetFormatColombian(candidate.FirstLoginDate);

                            if (basicInformation != null)
                            {
                                BasicInformationDTO basicInformationDTO = _mapper.Map<BasicInformation, BasicInformationDTO>(basicInformation);
                                basicInformationDTO.Email = candidate.Email;
                                basicInformationDTO.IsMigrated = candidate.IsMigrated;
                                basicInformationDTO.IsFromCompanyAndLogin = candidate.IsFromCompanyAndLogin;
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

                                basicInformationDTO.NumberNotes = await _noteRepository.NumberNotesByCandidateAndCompanyId(candidateId, companyUserId);

                                basicInformationDTO.Candidate.BasicInformation = null;

                                basicInformations.Add(basicInformationDTO);                                
                            }
                        }
                    }

                    return Ok(new { message = "Información básica consultada exitosamente", obj = basicInformations });
                }

                return NotFound(new { message = "No se encontró información básica asociada a el candidato" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /**/

        [HttpPost("sectionCandidate")]
        public async Task<IActionResult> GetAllBasicInformationSectionCandidate([FromBody] SearchByIdAndTextWithPaginationDTO search)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                MemberByToken memberResponse = await _companyRemoteRepository.GetMemberUserFromCandidate(values.ToString());

                int companyUserId = 0;

                if (memberResponse != null)
                    companyUserId = memberResponse.companyUserId;

                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

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

                var candidateSectionListDTO = await _basicInformationService.GetCandidateSection(search, companyUserId, userType, values.ToString());
                if (candidateSectionListDTO != null)
                {
                    return Ok(new { message = "Informaciones básicas consultadas exitosamente", obj = candidateSectionListDTO });
                }
                else
                    return NotFound(new { message = "No se encontro informacion de candidatos." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("DocumentType/{CandidateId}")]
        public async Task<IActionResult> GetDocumentType(int CandidateId)
        {
            try
            {
                var basicInfo = await _basicInformationRepository.GetByCandidateId(CandidateId);

                if (basicInfo == null)
                    return NotFound(new { message = "No existe el usuario" });
                else
                {

                    return Ok(new { message = "La información básica asociada al candidato existe", obj = basicInfo });
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("getgendercandidatecompay/{candidateid}")]
        public async Task<IActionResult> getgendercandidatecompay(int candidateid)
        {
            try
            {
                //StringValues values = "";
                //Request.Headers.TryGetValue("Authorization", out values);

                //string validation = "AddProfileInfo";

                //bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                //bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                //if (!isMaster && !isAuthorized)
                //    return StatusCode(403, new { message = "No autorizado" });


                BasicInformation basicinfo = await _basicInformationRepository.GetByCandidateId(candidateid);
                if (basicinfo != null)
                {
                    if (basicinfo.GenderCompanyId != null)
                    {
                        Gender auxgender = await _genderRepository.GetByIdWithoutNull(Convert.ToInt32(basicinfo.GenderCompanyId));
                        if (auxgender != null)
                        {
                            GenderCompanyDTO gender = new GenderCompanyDTO()
                            {
                                GenderId = Convert.ToInt32(auxgender.GenderId),
                                GenderCompanyId = Convert.ToInt32(auxgender.GenderId),
                                GenderGuid = auxgender.GenderGuid,
                                Name = auxgender.Name,
                                CandidateId = candidateid
                            };
                            return Ok(new { message = "Género consultado exitosamente", obj = gender });
                        }
                        else
                        {
                            return StatusCode(404, new { message = "No fue posible consultar género" });
                        }

                    }
                    else
                    {
                        return StatusCode(404, new { message = "No fue posible consultar género asociado candidato", obj = basicinfo });
                    }

                }
                return StatusCode(500, new { message = "No fue posible consultar información del candidato" });
                ///List<GenderCompanyDTO> internalcodeDTOs = _mapper.Map<List<InternalCode>, List<InternalCodeDTO>>(list);

            }
            catch (ArgumentException e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("getmaritalstatuscandidatecompay/{candidateid}")]
        public async Task<IActionResult> GetMaritalStatusCandidateCompany(int candidateid)
        {
            try
            {
                BasicInformation basicinfo = await _basicInformationRepository.GetByCandidateId(candidateid);
                if (basicinfo != null)
                {
                    if (basicinfo.MaritalStatusCompanyId != null)
                    {
                        MaritalStatus auxmarital = await _maritalStatusRepository.GetByIdWithoutNull(Convert.ToInt32(basicinfo.MaritalStatusCompanyId));
                        if (auxmarital != null)
                        {
                            MaritalStatusCompanyDTO marital = new MaritalStatusCompanyDTO()
                            {
                                MaritalStatusGuid = auxmarital.MaritalStatusGuid,
                                MaritalStatusId = Convert.ToInt32(auxmarital.MaritalStatusId),
                                MaritalStatusCompanyId = Convert.ToInt32(auxmarital.MaritalStatusId),
                                Name = auxmarital.Name,
                                CandidateId = candidateid
                            };
                            return Ok(new { message = "Género consultado exitosamente", obj = marital });
                        }
                        else
                        {
                            return StatusCode(404, new { message = "No fue posible consultar estado civil" });
                        }
                    }
                    else
                    {
                        return StatusCode(404, new { message = "No fue posible consultar estado civil asociado candidato", obj = basicinfo });
                    }
                }
                return StatusCode(500, new { message = "No fue posible consultar información del candidato" });
                ///List<GenderCompanyDTO> internalcodeDTOs = _mapper.Map<List<InternalCode>, List<InternalCodeDTO>>(list);

            }
            catch (ArgumentException e)
            {
                return BadRequest(e);
            }
        }

        //

        [HttpGet("exists/{candidateId}")]
        public async Task<IActionResult> BasicInformationExistsByCandidateId(int candidateId)
        {
            try
            {
                bool exists = await _basicInformationRepository.BasicInformationExists(candidateId);

                if (exists)
                    return Ok(new { message = "La información básica asociada al candidato existe", obj = exists, isTrue = exists });

                else
                    return StatusCode(404, new { message = "La información básica asociada al candidato no existe", obj = exists, isTrue = exists });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("existsWithVavlidations/{candidateId}")]
        public async Task<IActionResult> BasicInformationExistsWithValidationsByCandidateId(int candidateId)
        {
            try
            {
                BasicInformationWithValidationsDTO basicInformationWithValidationsDTO = new BasicInformationWithValidationsDTO();
                BasicInformationDTO basicInformationDTO = new BasicInformationDTO();

                bool exists = await _basicInformationRepository.BasicInformationExists(candidateId);

                if (exists)
                {
                    basicInformationWithValidationsDTO.Exists = true;

                    BasicInformation basicInformation = await _basicInformationRepository.GetByCandidateId(candidateId);

                    if (!string.IsNullOrEmpty(basicInformation.Surname)
                        && !string.IsNullOrEmpty(basicInformation.Country) && !string.IsNullOrEmpty(basicInformation.State) && !string.IsNullOrEmpty(basicInformation.City))
                        basicInformationWithValidationsDTO.IsFull = true;
                    else
                        basicInformationWithValidationsDTO.IsFull = false;

                    basicInformationDTO = _mapper.Map<BasicInformation, BasicInformationDTO>(basicInformation);

                    basicInformationWithValidationsDTO.BasicInformation = basicInformationDTO;

                    return Ok(new { message = "La información básica asociada al candidato existe", obj = basicInformationWithValidationsDTO });
                }
                else
                {
                    basicInformationWithValidationsDTO.Exists = false;
                    basicInformationWithValidationsDTO.IsFull = false;
                    basicInformationWithValidationsDTO.BasicInformation = null;

                    return StatusCode(404, new { message = "La información básica asociada al candidato no existe", obj = basicInformationWithValidationsDTO });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.InnerException });
            }
        }

        //

        [HttpGet("photo/{candidateId}")]
        public async Task<IActionResult> GetProfilePhotoById(int candidateId)
        {
            try
            {
                BasicInformation basicInformation = await _basicInformationRepository.GetByCandidateId(candidateId);

                if (basicInformation == null)
                {
                    return NotFound(new { message = "No se encontró el candidato" });
                }
                else if (basicInformation.Phone == null || basicInformation.Photo == "")
                {
                    return Ok(new { message = "Iniciales consultadas exitosamente", obj = basicInformation.Name[0].ToString() + basicInformation.Surname[0].ToString() });
                }
                else
                {
                    return Ok(new { message = "Foto consultada exitosamente", obj = basicInformation.Photo });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("emailsByCandidateId/{candidateId}")]
        public async Task<IActionResult> GetEmailsByCandidateId(int candidateId)
        {
            try
            {
                List<string> emails = new List<string>();

                Candidate candidate = await _candidateRepository.GetByCandidateId(candidateId);

                if(candidate == null)
                    return NotFound(new { message = "No se encontró el candidato" });

                emails.Add(candidate.Email);

                BasicInformation basicInformation = await _basicInformationRepository.GetByCandidateId(candidateId);

                if (basicInformation != null && basicInformation.Emails != null && basicInformation.Emails.Count > 0)
                {
                    foreach(Email email in basicInformation.Emails)
                    {
                        emails.Add(email.Mail);
                    }
                }

                return Ok(new { message = "Emails consultados exitosamente", obj = emails });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        #endregion

        #region POST

        [HttpPost]
        public async Task<IActionResult> AddBasicInformation([FromForm] BasicInformationDTO basicInformationDTO)
        {
            try
            {
                /**/

                if (basicInformationDTO != null)
                {
                    if (!string.IsNullOrEmpty(basicInformationDTO.Name))
                    {
                        string[] nameSplit = basicInformationDTO.Name.Trim().Split(" ");

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

                        basicInformationDTO.Name = nameFull;
                    }

                    if (!string.IsNullOrEmpty(basicInformationDTO.Surname))
                    {
                        string[] nameSplit = basicInformationDTO.Surname.Trim().Split(" ");

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

                        basicInformationDTO.Surname = nameFull;
                    }
                }

                /**/

                BasicInformation basicInformation = _mapper.Map<BasicInformationDTO, BasicInformation>(basicInformationDTO);
                basicInformation.BasicInformationGuid = Convert.ToString(Guid.NewGuid());
                basicInformation.HaveWorkExperienceFromCompany = 3;
                // Save image to AWS S3
                if (basicInformationDTO.FormFile != null)
                    basicInformation.Photo = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + await _AWSS3FileService.UploadFile(basicInformationDTO.FormFile, "Photo");
                if (basicInformation.DocumentTypeId == 0)
                    basicInformation.DocumentTypeId = null;

                Candidate candidate = await _candidateRepository.GetByCandidateId(basicInformationDTO.CandidateId);
                if (candidate.IsMigrated != 0 && !string.IsNullOrEmpty(basicInformationDTO.Surname) && !candidate.IsFromCompanyAndLogin)
                {
                    candidate.IsFromCompanyAndLogin = true;
                    candidate.isAuthorized = true;
                    candidate.FirstLoginDate = DateTime.Now.ToLocalTime().AddHours(-5).ToString();
                    await _candidateRepository.Update(candidate);
                }

                if (basicInformationDTO.GenderId == 0)
                    basicInformation.GenderId = 4;

                if (basicInformationDTO.MaritalStatusId == 0)
                    basicInformation.MaritalStatusId = 6;

                bool created = await _basicInformationRepository.Add(basicInformation);
                object[] ans = await _candidateRepository.EditEditionDate(basicInformationDTO.CandidateId);

                if (created && ans != null && ans.Count() == 2 && (bool)ans[0])
                {
                    basicInformationDTO = _mapper.Map<BasicInformation, BasicInformationDTO>(basicInformation);

                    return Created("", new { message = "Información básica almacenada exitosamente", obj = basicInformationDTO });
                }
                else
                    return BadRequest(new { message = "La información básica no fue almacenadoa" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.InnerException });
            }
        }

        [HttpPost("fromMobile")]
        public async Task<IActionResult> AddBasicInformationFromMobile([FromBody] BasicInformationDTO basicInformationDTO)
        {
            try
            {
                /**/

                if (basicInformationDTO != null)
                {
                    if (!string.IsNullOrEmpty(basicInformationDTO.Name))
                    {
                        string[] nameSplit = basicInformationDTO.Name.Trim().Split(" ");

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

                        basicInformationDTO.Name = nameFull;
                    }

                    if (!string.IsNullOrEmpty(basicInformationDTO.Surname))
                    {
                        string[] nameSplit = basicInformationDTO.Surname.Trim().Split(" ");

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

                        basicInformationDTO.Surname = nameFull;
                    }
                }

                /**/

                BasicInformation basicInformation = _mapper.Map<BasicInformationDTO, BasicInformation>(basicInformationDTO);
                basicInformation.BasicInformationGuid = Convert.ToString(Guid.NewGuid());
                basicInformation.HaveWorkExperienceFromCompany = 3;

                // Save image to AWS S3
                if (basicInformationDTO.FormFile != null)
                    basicInformation.Photo = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + await _AWSS3FileService.UploadFile(basicInformationDTO.FormFile, "Photo");
                if (basicInformation.DocumentTypeId == 0)
                    basicInformation.DocumentTypeId = null;

                if (basicInformationDTO.GenderId == 0)
                    basicInformation.GenderId = 4;

                if (basicInformationDTO.MaritalStatusId == 0)
                    basicInformation.MaritalStatusId = 6;

                bool created = await _basicInformationRepository.Add(basicInformation);
                object[] ans = await _candidateRepository.EditEditionDate(basicInformationDTO.CandidateId);


                Candidate candidate = await _candidateRepository.GetByCandidateId(basicInformationDTO.CandidateId);
                if (candidate.IsMigrated != 0 && !string.IsNullOrEmpty(basicInformationDTO.Surname) && !candidate.IsFromCompanyAndLogin)
                {
                    candidate.IsFromCompanyAndLogin = true;
                    candidate.isAuthorized = true;
                    candidate.FirstLoginDate = DateTime.Now.ToLocalTime().AddHours(-5).ToString();
                    await _candidateRepository.Update(candidate);
                }

                if (created && ans != null && ans.Count() == 2 && (bool)ans[0])
                {
                    basicInformationDTO = _mapper.Map<BasicInformation, BasicInformationDTO>(basicInformation);

                    return Created("", new { message = "Información básica almacenada exitosamente", obj = basicInformationDTO });
                }
                else
                    return BadRequest(new { message = "La información básica no fue almacenadoa" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.InnerException });
            }
        }

        [HttpPatch("editDocumentAdmin")]
        public async Task<IActionResult> AddDocumentTypeIdAdmin([FromBody] DocumentAdminDTO documentAdminDTO)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "EditProfileInfo";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                Candidate candidate = await _candidateRepository.GetById((int)documentAdminDTO.CandidateId);

                if (candidate == null)
                    return NotFound(new { message = "No existe el usuario" });

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                if (memberUser == null)
                    return StatusCode(403, new { message = "No autorizado" });

                CandidateCompany candidateCompany = await _candidateCompanyRepository.GetByCandidateAndCompanyId((int)documentAdminDTO.CandidateId, memberUser.CompanyUserId);

                if (candidateCompany == null)
                    return NotFound(new { message = "No se puede editar el usuario" });

                candidateCompany.DocumentTypeId = documentAdminDTO.DocumentTypeIdAdmin;
                candidateCompany.Document = documentAdminDTO.DocumentAdmin;
                candidateCompany.OtherDocument = documentAdminDTO.OtherDocument;

                bool isUpdated = await _candidateCompanyRepository.Update(candidateCompany);

                if (isUpdated)
                    return StatusCode(200, new { message = "Tipo de documento editado correctamente" });

                return StatusCode(500, new { message = "No se pudo editar el tipo de documento, intente mas tarde" });
            }
            catch (ArgumentException e)
            {
                return BadRequest(e);
            }
        }

        [HttpPatch("AddAddressAdmin/{CandidateId}")]
        public async Task<IActionResult> AddAddressAdmin([FromBody] BasicInformationDTO basicInfoDTO, int CandidateId)
        {
            /* MODIFICAR MÉTODO DESPUÉS DE TERMINAR EL MULTIEMPRESA */

            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "AddProfileInfo";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                var addressAdmin = basicInfoDTO.AddressAdmin;
                if (addressAdmin == null)
                    return NotFound(new { message = "No se anexo una direccion" });

                var basicInfo = await _basicInformationRepository.GetByCandidateId(CandidateId);
                BasicInformationDTO basicInformationDTO = _mapper.Map<BasicInformation, BasicInformationDTO>(basicInfo);

                if (basicInfo == null)
                    return NotFound(new { message = "No existe el usuario" });

                else
                {
                    basicInformationDTO.AddressAdmin = addressAdmin;
                    basicInfo.AddressAdmin = addressAdmin;

                    string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                    MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                    CandidateCompany candidateCompany = new CandidateCompany();

                    if (memberUser != null)
                    {
                        candidateCompany = await _candidateCompanyRepository.GetByCandidateAndCompanyId(basicInfo.CandidateId, memberUser.CompanyUserId);

                        candidateCompany.Address = addressAdmin;
                    }

                    bool isUpdated = await _candidateCompanyRepository.Update(candidateCompany);

                    if (basicInformationDTO.GenderId == 0)
                        basicInfo.GenderId = 4;

                    if (basicInformationDTO.MaritalStatusId == 0)
                        basicInfo.MaritalStatusId = 6;

                    var isCreated = await _basicInformationRepository.Update(basicInfo);

                    if (isCreated)
                    {
                        return StatusCode(201, new { message = "Dirección añadida correctamente", obj = basicInformationDTO });
                    }
                    else
                    {
                        return StatusCode(500, new { message = "No se pudo agregar la dirección, intente mas tarde", obj = basicInformationDTO });
                    }
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        #endregion

        #region PATCH/PUT

        [HttpPatch]
        public async Task<IActionResult> EditBasicInformation([FromForm] BasicInformationDTO basicInformationDTO)
        {
            try
            {
                var auxbasicinfo = await _basicInformationRepository.GetById(basicInformationDTO.BasicInformationId);
                basicInformationDTO.GenderCompanyId = auxbasicinfo.GenderCompanyId;
                basicInformationDTO.MaritalStatusCompanyId = auxbasicinfo.MaritalStatusCompanyId;
                basicInformationDTO.DocumentTypeIdAdmin = auxbasicinfo.DocumentTypeIdAdmin;
                basicInformationDTO.AddressAdmin = auxbasicinfo.AddressAdmin;
                basicInformationDTO.EmailMemberUser = auxbasicinfo.EmailMemberUser;
                basicInformationDTO.DocumentAdmin = auxbasicinfo.DocumentAdmin;

                /**/

                if (basicInformationDTO != null)
                {
                    if (!string.IsNullOrEmpty(basicInformationDTO.Name))
                    {
                        string[] nameSplit = basicInformationDTO.Name.Trim().Split(" ");

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

                        basicInformationDTO.Name = nameFull;
                    }

                    if (!string.IsNullOrEmpty(basicInformationDTO.Surname))
                    {
                        string[] nameSplit = basicInformationDTO.Surname.Trim().Split(" ");

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

                        basicInformationDTO.Surname = nameFull;
                    }
                }

                /**/

                BasicInformation basicInfo = _mapper.Map<BasicInformationDTO, BasicInformation>(basicInformationDTO);

                if (basicInformationDTO.FormFile != null)
                {
                    var urlPhoto = await _AWSS3FileService.UploadFile(basicInformationDTO.FormFile, "Photo");
                    basicInfo.Photo = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + urlPhoto;
                }

                Candidate candidate = await _candidateRepository.GetByCandidateId(basicInformationDTO.CandidateId);
                if (candidate.IsMigrated != 0 && !string.IsNullOrEmpty(basicInformationDTO.Surname) && !candidate.IsFromCompanyAndLogin)
                {
                    candidate.IsFromCompanyAndLogin = true;
                    candidate.isAuthorized = true;
                    candidate.FirstLoginDate = DateTime.Now.ToLocalTime().AddHours(-5).ToString();
                    await _candidateRepository.Update(candidate);

                    StringValues token = "";
                    Request.Headers.TryGetValue("Authorization", out token);

                    await _companyRemoteRepository.DeleteFiledAndDeletedPostulationsByCandidateId(candidate.CandidateId, token);
                }

                if (basicInformationDTO.GenderId == 0)
                    basicInfo.GenderId = 4;

                if (basicInformationDTO.MaritalStatusId == 0)
                    basicInfo.MaritalStatusId = 6;

                bool edited = await _basicInformationRepository.Update(basicInfo);
                object[] ans = await _candidateRepository.EditEditionDate(basicInformationDTO.CandidateId);

                if (edited && ans != null && ans.Count() == 2 && (bool)ans[0])
                {
                    basicInformationDTO = _mapper.Map<BasicInformation, BasicInformationDTO>(basicInfo);

                    return Created("", new { message = "Se editó exitosamente.", obj = basicInformationDTO });
                }
                else
                    return BadRequest(new { message = "La Información Básica no fue editada." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.InnerException });
            }
        }

        [HttpPut("fromMobile")]
        public async Task<IActionResult> EditBasicInformationFromMobile([FromForm] BasicInformationDTO basicInformationDTO)
        {
            try
            {
                /**/

                if (basicInformationDTO != null)
                {
                    if (!string.IsNullOrEmpty(basicInformationDTO.Name))
                    {
                        string[] nameSplit = basicInformationDTO.Name.Trim().Split(" ");

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

                        basicInformationDTO.Name = nameFull;
                    }

                    if (!string.IsNullOrEmpty(basicInformationDTO.Surname))
                    {
                        string[] nameSplit = basicInformationDTO.Surname.Trim().Split(" ");

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

                        basicInformationDTO.Surname = nameFull;
                    }
                }

                /**/

                var auxbasicinfo = await _basicInformationRepository.GetByGuid(basicInformationDTO.BasicInformationGuid);

                basicInformationDTO.GenderCompanyId = auxbasicinfo.GenderCompanyId;
                basicInformationDTO.MaritalStatusCompanyId = auxbasicinfo.MaritalStatusCompanyId;
                basicInformationDTO.DocumentTypeIdAdmin = auxbasicinfo.DocumentTypeIdAdmin;
                basicInformationDTO.AddressAdmin = auxbasicinfo.AddressAdmin;

                BasicInformation basicInfo = _mapper.Map<BasicInformationDTO, BasicInformation>(basicInformationDTO);

                if (basicInformationDTO.FormFile != null && basicInformationDTO.Photo != auxbasicinfo.Photo)
                {
                    var urlPhoto = await _AWSS3FileService.UploadFile(basicInformationDTO.FormFile, "Photo");
                    basicInfo.Photo = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + urlPhoto;
                }

                Candidate candidate = await _candidateRepository.GetByCandidateId(basicInformationDTO.CandidateId);
                if (candidate.IsMigrated != 0 && !string.IsNullOrEmpty(basicInformationDTO.Surname) && !candidate.IsFromCompanyAndLogin)
                {
                    candidate.IsFromCompanyAndLogin = true;
                    candidate.isAuthorized = true;
                    candidate.FirstLoginDate = DateTime.Now.ToLocalTime().AddHours(-5).ToString();
                    await _candidateRepository.Update(candidate);
                }

                if (basicInformationDTO.GenderId == 0)
                    basicInfo.GenderId = 4;

                if (basicInformationDTO.MaritalStatusId == 0)
                    basicInfo.MaritalStatusId = 6;

                bool edited = await _basicInformationRepository.Update(basicInfo);
                object[] ans = await _candidateRepository.EditEditionDate(basicInformationDTO.CandidateId);

                if (edited && ans != null && ans.Count() == 2 && (bool)ans[0])
                {
                    basicInformationDTO = _mapper.Map<BasicInformation, BasicInformationDTO>(basicInfo);

                    return Created("", new { message = "Se editó exitosamente.", obj = basicInformationDTO });
                }
                else
                    return BadRequest(new { message = "La Información Básica no fue editada." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.InnerException });
            }
        }

        //

        [HttpPatch("candidateEmail/{basicInformationId}")]
        public async Task<IActionResult> AddBasicInformationEmails(int basicInformationId, [FromBody] ChangesEmailsDTO emailsFull)
        {
            /* Get Auth Token */
            StringValues values = "";
            Request.Headers.TryGetValue("Authorization", out values);

            /* Permission name */
            string validation = "EditBasicInfo";

            /* Validation - Is Auth or is Master User */
            bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
            bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

            /* Deny access */
            if (!isMaster && !isAuthorized)
                return StatusCode(403, new { message = "No autorizado" });

            string oldMainEmail = "";
            string newMainEmail = "";

            if (emailsFull != null)
            {
                if (!string.IsNullOrEmpty(emailsFull.OldEmail))
                    oldMainEmail = emailsFull.OldEmail;

                if (!string.IsNullOrEmpty(emailsFull.NewEmail))
                    newMainEmail = emailsFull.NewEmail;
            }

            /**/

            bool oldCandidateExists = false;
            bool newCandidateExists = false;

            if (!string.IsNullOrEmpty(oldMainEmail) && !string.IsNullOrEmpty(newMainEmail))
            {
                if (oldMainEmail != newMainEmail)
                {
                    oldCandidateExists = await _candidateRepository.CandidateExistByEmail(oldMainEmail);
                    newCandidateExists = await _candidateRepository.CandidateExistByEmailAndAlternativeEmails(newMainEmail);

                    if (!oldCandidateExists)
                        return NotFound(new { message = "Usuario no existe" });

                    if (newCandidateExists)
                        return BadRequest(new { message = "Ya existe un usuario con el correo ingresado" });
                }
            }

            List<EmailDTO> emails = new List<EmailDTO>();

            if (emailsFull != null && emailsFull.Emails != null && emailsFull.Emails.Count > 0)
                emails = emailsFull.Emails;

            /* Lists of new Emails and old Emails */
            List<Email> newEmails = _mapper.Map<List<EmailDTO>, List<Email>>(emails);
            List<Email> oldEmails = new List<Email>();
            List<Email> mailsToAdd = new List<Email>();
            List<Email> mailsToDelete = new List<Email>();

            try
            {
                /* Get the companyUser */
                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                int companyUserId = 0;
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                /* If is an companyUser, accosiate the new mails wiith the company */
                if (memberUser != null)
                    companyUserId = memberUser.CompanyUserId;

                oldEmails = await _emailRepository.GetByBasicInformationAndCompanyUserId(basicInformationId, companyUserId);

                if(oldEmails != null && oldEmails.Count > 0)
                {
                    bool isInNewMails = false;

                    foreach (Email oldEmail in oldEmails)
                    {
                        if (newEmails != null && newEmails.Count > 0)
                            foreach (Email newEmail in newEmails)
                                if (oldEmail.EmailId == newEmail.EmailId)
                                {
                                    isInNewMails = true;

                                    break;
                                }

                        if (!isInNewMails)
                            mailsToDelete.Add(oldEmail);
                    }
                }

                if (newEmails != null && newEmails.Count > 0)
                {
                    bool isInOldMails = false;

                    foreach (Email newEmail in newEmails)
                    {
                        if (oldEmails != null && oldEmails.Count > 0)
                            foreach (Email oldEmail in oldEmails)
                                if (newEmail.EmailId == oldEmail.EmailId)
                                {
                                    isInOldMails = true;

                                    break;
                                }

                        if (!isInOldMails)
                            mailsToAdd.Add(newEmail);
                    }
                }

                /* Get the current Basic Information */
                var basicInfo = await _basicInformationRepository.GetById(basicInformationId);

                /* Delete the old Emails */
                if (mailsToDelete != null && mailsToDelete.Count > 0)
                    foreach (Email mailToDelete in mailsToDelete)
                        await _emailRepository.Remove(mailToDelete.EmailId);

                /* Add the new Emails */
                if (mailsToAdd != null && mailsToAdd.Count > 0)
                    foreach (Email mailToAdd in mailsToAdd)
                    {
                        mailToAdd.CompanyUserId = companyUserId;

                        await _emailRepository.Add(mailToAdd);
                    }

                /**/

                if (!string.IsNullOrEmpty(oldMainEmail) && !string.IsNullOrEmpty(newMainEmail))
                {
                    if (oldMainEmail != newMainEmail)
                    {
                        if (oldCandidateExists && !newCandidateExists)
                        {
                            Candidate candidate = await _candidateRepository.GetByEmail(oldMainEmail);

                            candidate.Email = newMainEmail;

                            bool isEditedMainEmail = await _candidateRepository.Update(candidate);
                        }
                    }
                }

                /**/

                /* Change the last edicion date */
                await _candidateRepository.EditEditionDate(basicInfo.CandidateId);

                return StatusCode(201, "Emails editados exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("candidateSocialNetworks/{basicInformationId}")]
        public async Task<IActionResult> AddBasicInformationSocialNetworks(int basicInformationId, [FromBody] List<SocialNetworkDTO> socialNetworks)
        {
            StringValues values = "";
            Request.Headers.TryGetValue("Authorization", out values);

            string validation = "EditBasicInfo";

            bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
            bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

            if (!isMaster && !isAuthorized)
                return StatusCode(403, new { message = "No autorizado" });

            string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
            MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

            List<SocialNetwork> socialNetworksToDelete = new List<SocialNetwork>();
            List<SocialNetworkDTO> socialNetworksToAdd = new List<SocialNetworkDTO>();

            List<SocialNetwork> oldSocialNetworks = await _socialNetworkRepository.GetByBasicInfoIdAsync(basicInformationId);

            if (oldSocialNetworks != null && oldSocialNetworks.Count > 0)
            {
                foreach (SocialNetwork oldSocialNetwork in oldSocialNetworks)
                {
                    bool deleteOldSocialNetwork = true;

                    if (socialNetworks != null && socialNetworks.Count > 0)
                    {
                        foreach (SocialNetworkDTO socialNetwork in socialNetworks)
                        {
                            if (oldSocialNetwork.SocialNetworkId == socialNetwork.SocialNetworkId)
                            {
                                deleteOldSocialNetwork = false;

                                break;
                            }
                        }
                    }

                    if (deleteOldSocialNetwork && oldSocialNetwork.CompanyUserId == memberUser.CompanyUserId)
                    {
                        socialNetworksToDelete.Add(oldSocialNetwork);
                    }
                }
            }

            if (socialNetworks != null && socialNetworks.Count > 0)
            {
                foreach (SocialNetworkDTO socialNetwork in socialNetworks)
                {
                    bool addNewSocialNetwork = true;

                    if (oldSocialNetworks != null && oldSocialNetworks.Count > 0)
                    {
                        foreach (SocialNetwork oldSocialNetwork in oldSocialNetworks)
                        {
                            if (oldSocialNetwork.SocialNetworkId == socialNetwork.SocialNetworkId)
                            {
                                addNewSocialNetwork = false;

                                break;
                            }
                        }
                    }

                    if (addNewSocialNetwork)
                    {
                        socialNetwork.CompanyUserId = memberUser.CompanyUserId;
                        socialNetwork.BasicInformationId = basicInformationId;

                        socialNetworksToAdd.Add(socialNetwork);
                    }
                }
            }

            try
            {
                if (socialNetworksToDelete != null && socialNetworksToDelete.Count > 0)
                {
                    foreach (SocialNetwork socialNetwork in socialNetworksToDelete)
                    {
                        await _socialNetworkRepository.Remove(socialNetwork.SocialNetworkId);
                    }
                }

                if (socialNetworksToAdd != null && socialNetworksToAdd.Count > 0)
                {
                    List<SocialNetwork> socialNetworksToAddDB = _mapper.Map<List<SocialNetworkDTO>, List<SocialNetwork>>(socialNetworksToAdd);

                    await _socialNetworkRepository.AddRange(socialNetworksToAddDB);
                }

                return StatusCode(201, "Redes sociales editadas exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("candidateUserLinks/{basicInformationId}")]
        public async Task<IActionResult> AddBasicInformationUserLinks(int basicInformationId, [FromBody] List<UserLinkDTO> userLinks)
        {
            StringValues values = "";
            string msn = "-";
            Request.Headers.TryGetValue("Authorization", out values);
           
            bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

            string validation = "DeleteBasicInfo";

            var isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
            if (!isMaster && !isAuthorized)
                return StatusCode(403, new { message = "No autorizado" });

            string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
            MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

            List<UserLink> userLinksToDelete = new List<UserLink>();
            List<UserLinkDTO> userLinksToAdd = new List<UserLinkDTO>();

            List<UserLink> oldUserLinks = await _userLinkRepository.GetByBasicInfoIdAsync(basicInformationId);

            if (oldUserLinks != null && oldUserLinks.Count > 0)
            {
                foreach (UserLink oldUserLink in oldUserLinks)
                {
                    bool deleteOldUserLink = true;

                    if (userLinks != null && userLinks.Count > 0)
                    {
                        foreach (UserLinkDTO userLink in userLinks)
                        {
                            if (oldUserLink.UserLinkId == userLink.UserLinkId)
                            {
                                deleteOldUserLink = false;

                                break;
                            }
                        }
                    }

                    if (deleteOldUserLink && oldUserLink.CompanyUserId == memberUser.CompanyUserId)
                    {
                        userLinksToDelete.Add(oldUserLink);
                    }
                }
            }

            if (userLinks != null && userLinks.Count > 0)
            {
                foreach (UserLinkDTO userLink in userLinks)
                {
                    bool addNewUserLink = true;

                    if (oldUserLinks != null && oldUserLinks.Count > 0)
                    {
                        foreach (UserLink oldUserLink in oldUserLinks)
                        {
                            if (oldUserLink.UserLinkId == userLink.UserLinkId)
                            {
                                addNewUserLink = false;

                                break;
                            }
                        }
                    }

                    if (addNewUserLink)
                    {
                        userLink.CompanyUserId = memberUser.CompanyUserId;
                        userLink.BasicInformationId = basicInformationId;

                        userLinksToAdd.Add(userLink);
                    }
                }
            }

            try
            {
                if (userLinksToDelete != null && userLinksToDelete.Count > 0)
                {
                    foreach (UserLink userLink in userLinksToDelete)
                    {
                        await _userLinkRepository.Remove(userLink.UserLinkId);
                    }
                }

                if (userLinksToAdd != null && userLinksToAdd.Count > 0)
                {
                    List<UserLink> userLinksToAddDB = _mapper.Map<List<UserLinkDTO>, List<UserLink>>(userLinksToAdd);

                    await _userLinkRepository.AddRange(userLinksToAddDB);
                }

                return StatusCode(201, "UserLinks editados exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("candidatePhones/{basicInformationId}")]
        public async Task<IActionResult> AddBasicInformationPhones(int basicInformationId, [FromBody] List<PhoneDTO> phones)
        {
            StringValues values = "";
            Request.Headers.TryGetValue("Authorization", out values);

            string validation = "DeleteBasicInfo";

            bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
            bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

            if (!isMaster && !isAuthorized)
                return StatusCode(403, new { message = "No autorizado" });

            string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
            MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

            List<Phone> phonesToDelete = new List<Phone>();
            List<PhoneDTO> phonesToAdd = new List<PhoneDTO>();

            List<Phone> oldPhones = await _phoneRepository.GetByBasicInformationId(basicInformationId);

            if(oldPhones != null && oldPhones.Count > 0)
            {
                foreach(Phone oldPhone in oldPhones)
                {
                    bool deleteOldPhone = true;

                    if(phones != null && phones.Count > 0)
                    {
                        foreach(PhoneDTO phone in phones)
                        {
                            if(oldPhone.PhoneId == phone.PhoneId)
                            {
                                deleteOldPhone = false;

                                break;
                            }
                        }
                    }

                    if(deleteOldPhone && oldPhone.CompanyUserId == memberUser.CompanyUserId)
                    {
                        phonesToDelete.Add(oldPhone);
                    }
                }
            }

            if (phones != null && phones.Count > 0)
            {
                foreach (PhoneDTO phone in phones)
                {
                    bool addNewPhone = true;

                    if (oldPhones != null && oldPhones.Count > 0)
                    {
                        foreach (Phone oldPhone in oldPhones)
                        {
                            if (oldPhone.PhoneId == phone.PhoneId)
                            {
                                addNewPhone = false;

                                break;
                            }
                        }
                    }

                    if (addNewPhone)
                    {
                        phone.CompanyUserId = memberUser.CompanyUserId;
                        phone.BasicInformationId = basicInformationId;

                        phonesToAdd.Add(phone);
                    }
                }
            }
            

            try
            {
                if(phonesToDelete != null && phonesToDelete.Count > 0)
                {
                    foreach(Phone phone in phonesToDelete)
                    {
                        await _phoneRepository.Remove(phone.PhoneId);
                    }
                }

                if(phonesToAdd != null && phonesToAdd.Count > 0)
                {
                    List<Phone> phonesToAddDB = _mapper.Map<List<PhoneDTO>, List<Phone>>(phonesToAdd);

                    await _phoneRepository.AddRange(phonesToAddDB);
                }
                
                return StatusCode(201, "Telefonos editados exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("addPhotoAdmin")]
        public async Task<IActionResult> AddPhotoAdmin([FromForm] PhotoAdminDTO photoAdminDTO)
        {
            /* MODIFICAR MÉTODO DESPUÉS DE TERMINAR EL MULTIEMPRESA */

            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "AddProfileInfo";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                BasicInformation basicinfo = await _basicInformationRepository.GetByCandidateId(photoAdminDTO.CandidateId);
                CandidateCompany candidateCompany = await _candidateCompanyRepository.GetByCandidateAndCompanyId(photoAdminDTO.CandidateId, memberUser.CompanyUserId);

                Candidate candidate = await _candidateRepository.GetById(basicinfo.CandidateId);

                if (candidate.IsMigrated == 0)
                    return BadRequest(new { message = "No tiene permiso para añadir foto al candidato." });

                if (basicinfo != null)
                {
                    if (photoAdminDTO.FormFile != null)
                    {
                        var urlPhoto = await _AWSS3FileService.UploadFile(photoAdminDTO.FormFile, "Photo");

                        basicinfo.Photo = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + urlPhoto;
                        basicinfo.PhotoByAdmin = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + urlPhoto;

                        if(candidateCompany != null)
                        {
                            candidateCompany.Photo = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + urlPhoto;
                        }
                    }

                    bool edited = await _basicInformationRepository.Update(basicinfo);

                    if (edited)
                    {
                        BasicInformationDTO basicInformationDTO = _mapper.Map<BasicInformation, BasicInformationDTO>(basicinfo);

                        return StatusCode(200, new { message = "Se añadio foto exitosamente", obj = basicInformationDTO });
                    }

                    return BadRequest(new { message = "No fue posible añadir foto al candidato." });
                }

                return StatusCode(500, new { message = "No existe el candidato" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.InnerException.Message });
            }
        }

        //

        [HttpPatch("editSocialNetwork")]
        public async Task<IActionResult> EditSocialNetworkCandidate([FromBody] ChangeSocialNetworkDTO changeSocialNetworkDTO)
        {
            try
            {
                var candidate = await _candidateRepository.GetByCandidateId(changeSocialNetworkDTO.CandidateId);
                if (candidate != null)
                {
                    if (changeSocialNetworkDTO.FacebookURL != null)
                        candidate.BasicInformation.FacebookURL = changeSocialNetworkDTO.FacebookURL;
                    if (changeSocialNetworkDTO.TwitterURL != null)
                        candidate.BasicInformation.TwitterURL = changeSocialNetworkDTO.TwitterURL;
                    if (changeSocialNetworkDTO.LinkedInURL != null)
                        candidate.BasicInformation.LinkedInURL = changeSocialNetworkDTO.LinkedInURL;

                    var edited = await _candidateRepository.Update(candidate);
                    if (edited)
                    {
                        CandidateDTO candidateDTO = _mapper.Map<Candidate, CandidateDTO>(candidate);
                        return Ok(new { message = "Redes sociales de candidato editadas exitosamente", obj = candidateDTO });
                    }
                    else
                        return BadRequest(new { message = "Las redes sociales del candidato no fueron editadas." });
                }
                else
                    return NotFound(new { message = "El candidato no existe." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.InnerException });
            }
        }

        [HttpPatch("editLink")]
        public async Task<IActionResult> EditLinkCandidate([FromBody] ChangeLinkDTO changeLinkDTO)
        {
            try
            {
                var candidate = await _candidateRepository.GetByCandidateId(changeLinkDTO.CandidateId);
                if (candidate != null)
                {
                    if (changeLinkDTO.GitHubURL != null)
                        candidate.BasicInformation.GitHubURL = changeLinkDTO.GitHubURL;
                    if (changeLinkDTO.BitBucketURL != null)
                        candidate.BasicInformation.BitBucketURL = changeLinkDTO.BitBucketURL;

                    var edited = await _candidateRepository.Update(candidate);
                    if (edited)
                    {
                        CandidateDTO candidateDTO = _mapper.Map<Candidate, CandidateDTO>(candidate);
                        return Ok(new { message = "Links de candidato editadas exitosamente", obj = candidateDTO });
                    }
                    else
                        return BadRequest(new { message = "Los links del candidato no fueron editadas." });
                }
                else
                    return NotFound(new { message = "El candidato no existe." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.InnerException });
            }
        }

        [HttpPatch("editPhone")]
        public async Task<IActionResult> EditPhoneCandidate([FromBody] ChangePhoneDTO changePhoneDTO)
        {
            try
            {
                var candidate = await _candidateRepository.GetByCandidateId(changePhoneDTO.CandidateId);
                if (candidate != null)
                {
                    if (changePhoneDTO.Phone != null)
                        candidate.BasicInformation.Phone = changePhoneDTO.Phone;

                    var edited = await _candidateRepository.Update(candidate);
                    if (edited)
                    {
                        CandidateDTO candidateDTO = _mapper.Map<Candidate, CandidateDTO>(candidate);
                        return Ok(new { message = "Teléfono de candidato editado exitosamente", obj = candidateDTO });
                    }
                    else
                        return BadRequest(new { message = "El teléfono del candidato no fue editado." });
                }
                else
                    return NotFound(new { message = "El candidato no existe." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.InnerException });
            }
        }

        [HttpPatch("editBirthDateCompany/{candidateId}")]
        public async Task<IActionResult> EditBirthDateCompany(int candidateId, [FromBody] BasicInformationOverViewDTO basicInformationOverViweDTO)
        {
            /* MODIFICAR MÉTODO DESPUÉS DE TERMINAR EL MULTIEMPRESA */

            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "EditProfileInfo";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                BasicInformation basicinfo = await _basicInformationRepository.GetByCandidateId(candidateId);
                var birthdayCompany = basicInformationOverViweDTO.BirthDateCompany;
                string auxDate = basicinfo.BirthDateCompany;

                if (basicinfo != null)
                {
                    string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                    MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                    CandidateCompany candidateCompany = new CandidateCompany();

                    if (memberUser != null)
                    {
                        candidateCompany = await _candidateCompanyRepository.GetByCandidateAndCompanyId(basicinfo.CandidateId, memberUser.CompanyUserId);

                        candidateCompany.BirthDate = basicInformationOverViweDTO.BirthDateCompany;
                    }

                    bool isUpdated = await _candidateCompanyRepository.Update(candidateCompany);

                    bool edited = await _basicInformationRepository.EditCompanyBirthDate(candidateId, birthdayCompany);

                    if (edited)
                    {
                        if (string.IsNullOrEmpty(auxDate))
                            return Created("", new { message = "Se creó exitosamente" });

                        else if (string.IsNullOrEmpty(birthdayCompany))
                            return StatusCode(204, new { message = "Se eliminó exitosamente" });

                        else
                            return StatusCode(200, new { message = "Se editó exitosamente" });
                    }
                    else
                    {
                        return BadRequest(new { message = "No fue posible editar/eliminar información del candidato" });
                    }
                }

                return StatusCode(500, new { message = "No fue posible editar/eliminar información del candidato" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("editHaveWorkExperienceCompany/{candidateId}")]
        public async Task<IActionResult> EditHaveWorkExperienceCompany(int candidateId, [FromBody] BasicInformationOverViewDTO basicInformationOverViweDTO)
        {
            /* MODIFICAR MÉTODO DESPUÉS DE TERMINAR EL MULTIEMPRESA */

            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "EditProfileInfo";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                int haveWorkExperienceFromCompany = basicInformationOverViweDTO.HaveWorkExperienceFromCompany;

                BasicInformation basicinfo = await _basicInformationRepository.GetByCandidateId(candidateId);

                if (basicinfo != null)
                {
                    string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                    MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                    CandidateCompany candidateCompany = new CandidateCompany();

                    if (memberUser != null)
                    {
                        candidateCompany = await _candidateCompanyRepository.GetByCandidateAndCompanyId(basicinfo.CandidateId, memberUser.CompanyUserId);

                        candidateCompany.HaveWorkExperience = basicInformationOverViweDTO.HaveWorkExperienceFromCompany;
                    }

                    bool isUpdated = await _candidateCompanyRepository.Update(candidateCompany);

                    bool edited = await _basicInformationRepository.EditCompanyHaveWorkExperience(candidateId, haveWorkExperienceFromCompany);
                    if (edited)
                        return StatusCode(200, new { message = "Se editó exitosamente" });
                    return BadRequest(new { message = "No fue posible editar/eliminar información del candidato" });
                }
                return StatusCode(500, new { message = "No fue posible editar/eliminar información del candidato" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.InnerException.Message });
            }
        }

        [HttpPatch("editAspirationAndCurrencyCompany/{candidateId}")]
        public async Task<IActionResult> EditAspirationAndCurrencyCompany(int candidateId, [FromBody] EditSalaryAspirationDTO salary)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "EditProfileInfo";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                Candidate candidate = await _candidateRepository.GetById(candidateId);

                if (candidate == null)
                    return NotFound(new { message = "No existe el usuario" });

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                if (memberUser == null)
                    return StatusCode(403, new { message = "No autorizado" });

                CandidateCompany candidateCompany = await _candidateCompanyRepository.GetByCandidateAndCompanyId(candidateId, memberUser.CompanyUserId);

                if (candidateCompany == null)
                    return NotFound(new { message = "No se puede eliminar el usuario" });

                candidateCompany.CurrencyId = salary.CurrencyId;
                candidateCompany.SalaryAspiration = salary.SalaryAspiration;

                bool isUpdated = await _candidateCompanyRepository.Update(candidateCompany);

                if (isUpdated)
                    return StatusCode(200, new { message = "Aspiración salarial editada correctamente" });

                return StatusCode(500, new { message = "No se pudo editar la aspiración salarial, intente mas tarde" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("editDocument/{candidateId}")]
        public async Task<IActionResult> EditDocument(int candidateId, [FromBody] BasicInformationOverViewDTO basicInformationOverViweDTO)
        {
            /* MODIFICAR MÉTODO DESPUÉS DE TERMINAR EL MULTIEMPRESA */

            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "EditProfileInfo";

                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                string Document = basicInformationOverViweDTO.Document;
                string OtherDocument = basicInformationOverViweDTO.OtherDocument;
                int? DocumentTypeId = basicInformationOverViweDTO.DocumentTypeId;
                BasicInformation basicinfo = await _basicInformationRepository.GetByCandidateId(candidateId);
                if (basicinfo != null)
                {
                    bool edited = await _basicInformationRepository.EditDocument(candidateId, DocumentTypeId.Value, Document,OtherDocument);

                    string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                    MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                    CandidateCompany candidateCompany = new CandidateCompany();

                    if (memberUser != null)
                    {
                        candidateCompany = await _candidateCompanyRepository.GetByCandidateAndCompanyId(basicinfo.CandidateId, memberUser.CompanyUserId);

                        candidateCompany.Document = basicInformationOverViweDTO.Document;
                        candidateCompany.DocumentTypeId = basicInformationOverViweDTO.DocumentTypeId;
                        candidateCompany.OtherDocument = basicInformationOverViweDTO.OtherDocument;
                    }

                    var isUpdated =await  _candidateCompanyRepository.Update(candidateCompany);

                    if (isUpdated)
                    {
                        if (isMaster)
                        {
                            string candidateInitials = "";
                            string candidateFullName = "";
                            string candidatePhoto = "";

                            string memberUserInitials = "";
                            string memberUserFullName = "";
                            string memberUserPhoto = "";

                            if (basicinfo != null)
                            {
                                candidateInitials = !string.IsNullOrEmpty(basicinfo.Name) ? basicinfo.Name[0].ToString() : "";
                                candidateInitials += !string.IsNullOrEmpty(basicinfo.Surname) ? basicinfo.Surname[0].ToString() : "";

                                candidateFullName = !string.IsNullOrEmpty(basicinfo.Name) ? basicinfo.Name : "";
                                candidateFullName += !string.IsNullOrEmpty(basicinfo.Surname) ? " " + basicinfo.Surname : "";

                                candidatePhoto = basicinfo.Photo;
                            }

                            if (memberUser != null)
                            {
                                memberUserInitials = !string.IsNullOrEmpty(memberUser.Name) ? memberUser.Name[0].ToString() : "";
                                memberUserInitials += !string.IsNullOrEmpty(memberUser.Surname) ? memberUser.Surname[0].ToString() : "";

                                if (string.IsNullOrEmpty(memberUser.Surname) && memberUserInitials.Count() == 1)
                                    memberUserInitials += !string.IsNullOrEmpty(memberUser.Name) ? memberUser.Name[0].ToString() : "";

                                memberUserFullName = !string.IsNullOrEmpty(memberUser.Name) ? memberUser.Name : "";
                                memberUserFullName += !string.IsNullOrEmpty(memberUser.Surname) ? " " + memberUser.Surname : "";

                                memberUserPhoto = memberUser.Photo;
                            }

                            NotificationAttachedFileDTO notificationOutDTO = new NotificationAttachedFileDTO
                            {
                                candidateId = basicinfo.CandidateId,
                                candidateName = candidateFullName,
                                candidateInitials = candidateInitials,
                                candidatePhoto = candidatePhoto,
                                attachedFileName = "",
                                memberUserName = memberUserFullName,
                                memberUserInitials = memberUserInitials,
                                memberUserPhoto = memberUserPhoto,
                            };

                            bool isNotificationCreated = await _companyRemoteRepository.AddNotificationEditCandidateDocumentFromMaster(notificationOutDTO, values);
                        }
                    }

                    if (edited)
                        return StatusCode(200, new { message = "Se editó exitosamente" });
                    return BadRequest(new { message = "No fue posible editar/eliminar información del candidato" });
                }
                return StatusCode(500, new { message = "No fue posible editar/eliminar información del candidato" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.InnerException.Message });
            }
        }

        [HttpPatch("editNameAdmin")]
        public async Task<IActionResult> EditNameAdmin([FromBody] NameAdminDTO nameAdminDTO)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "EditBasicInfo";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                BasicInformation basicinfo = await _basicInformationRepository.GetByCandidateId(nameAdminDTO.CandidateId);

                if (basicinfo != null)
                {
                    basicinfo.Name = nameAdminDTO.Name;
                    basicinfo.Surname = nameAdminDTO.Surname;

                    bool edited = await _basicInformationRepository.Update(basicinfo);

                    if (edited)
                        return StatusCode(200, new { message = "Se editó exitosamente" });
                    return BadRequest(new { message = "No fue posible editar información del candidato" });
                }
                return StatusCode(500, new { message = "No existe el candidato" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.InnerException.Message });
            }
        }

        [HttpPatch("editmaritalcandidatecompay")]
        public async Task<IActionResult> editmaritalcandidatecompay([FromBody] MaritalStatusCompanyDTO maritalstatus)
        {
            /* MODIFICAR MÉTODO DESPUÉS DE TERMINAR EL MULTIEMPRESA */

            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "EditProfileInfo";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                BasicInformation basicinfo = await _basicInformationRepository.GetByCandidateId(Convert.ToInt32(maritalstatus.CandidateId));
                if (basicinfo != null)
                {
                    basicinfo.MaritalStatusCompanyId = maritalstatus.MaritalStatusCompanyId;

                    string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                    MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                    CandidateCompany candidateCompany = new CandidateCompany();

                    if (memberUser != null)
                    {
                        candidateCompany = await _candidateCompanyRepository.GetByCandidateAndCompanyId(basicinfo.CandidateId, memberUser.CompanyUserId);

                        candidateCompany.MaritalStatusId = maritalstatus.MaritalStatusCompanyId;
                    }

                    bool isUpdated = await _candidateCompanyRepository.Update(candidateCompany);

                    bool edited = await _basicInformationRepository.Update(basicinfo);

                    if (edited)
                    {
                        return Created("", new { message = "Se editó exitosamente", obj = maritalstatus });
                    }
                    else
                    {
                        return BadRequest(new { message = "El estado civil no fue editado" });
                    }
                }
                return StatusCode(500, new { message = "No fue posible consultar información del candidato" });
            }
            catch (ArgumentException e)
            {
                return BadRequest(e);
            }
        }

        [HttpPatch("editGenderCompany")]
        public async Task<IActionResult> EditGenderCompany([FromBody] GenderCompanyDTO genderCompany)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "EditProfileInfo";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                Candidate candidate = await _candidateRepository.GetById((int)genderCompany.CandidateId);

                if (candidate == null)
                    return NotFound(new { message = "No existe el usuario" });

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                if (memberUser == null)
                    return StatusCode(403, new { message = "No autorizado" });

                CandidateCompany candidateCompany = await _candidateCompanyRepository.GetByCandidateAndCompanyId((int)genderCompany.CandidateId, memberUser.CompanyUserId);

                if (candidateCompany == null)
                    return NotFound(new { message = "No se puede eliminar el usuario" });

                candidateCompany.GenderId = genderCompany.GenderId;

                bool isUpdated = await _candidateCompanyRepository.Update(candidateCompany);

                if (isUpdated)
                    return StatusCode(200, new { message = "Género editado correctamente" });

                return StatusCode(500, new { message = "No se pudo editar el género, intente mas tarde" });
            }
            catch (ArgumentException e)
            {
                return BadRequest(e);
            }
        }

        [HttpPatch("editAllNames")]
        public async Task<IActionResult> EditAllNames()
        {
            try
            {
                List<BasicInformation> basicInformations = await _basicInformationRepository.GetAll();

                if (basicInformations == null)
                    return StatusCode(404, new { message = "No existen informaciones básicas" });

                if (basicInformations.Count > 0)
                {
                    foreach (BasicInformation basicInformation in basicInformations)
                    {
                        if (!string.IsNullOrEmpty(basicInformation.Name))
                        {
                            string[] nameSplit = basicInformation.Name.Trim().Split(" ");

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

                            basicInformation.Name = nameFull;
                        }

                        if (!string.IsNullOrEmpty(basicInformation.Surname))
                        {
                            string[] nameSplit = basicInformation.Surname.Trim().Split(" ");

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

                            basicInformation.Surname = nameFull;
                        }

                        if (basicInformation.GenderId == 0)
                            basicInformation.GenderId = 4;

                        if (basicInformation.MaritalStatusId == 0)
                            basicInformation.MaritalStatusId = 6;

                        bool isUpdated = await _basicInformationRepository.Update(basicInformation);
                    }
                }

                return StatusCode(200, new { message = "Informaciones básicas actualizadas exitosamente" });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        #endregion

        #region DELETE

        [HttpDelete("deleteCurrencyCompany/{candidateId}")]
        public async Task<IActionResult> DeleteSalaryAspirationFromCompany(int candidateId)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "AddProfileInfo";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                Candidate candidate = await _candidateRepository.GetById(candidateId);

                if (candidate == null)
                    return NotFound(new { message = "No existe el usuario" });

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                if (memberUser == null)
                    return StatusCode(403, new { message = "No autorizado" });

                CandidateCompany candidateCompany = await _candidateCompanyRepository.GetByCandidateAndCompanyId(candidateId, memberUser.CompanyUserId);

                if (candidateCompany == null)
                    return NotFound(new { message = "No se puede eliminar el usuario" });

                candidateCompany.CurrencyId = 0;
                candidateCompany.SalaryAspiration = null;

                bool isDelete = await _candidateCompanyRepository.Update(candidateCompany);

                if (isDelete)
                    return StatusCode(200, new { message = "Aspiración salarial eliminada correctamente" });

                return StatusCode(500, new { message = "No se pudo eliminar la aspiración salarial, intente mas tarde" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("deleteDocumentType/{candidateId}")]
        public async Task<IActionResult> DeleteDocumentTypeFromCompany(int candidateId)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "AddProfileInfo";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                Candidate candidate = await _candidateRepository.GetById(candidateId);

                if (candidate == null)
                    return NotFound(new { message = "No existe el usuario" });

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                if (memberUser == null)
                    return StatusCode(403, new { message = "No autorizado" });

                CandidateCompany candidateCompany = await _candidateCompanyRepository.GetByCandidateAndCompanyId(candidateId, memberUser.CompanyUserId);

                if (candidateCompany == null)
                    return NotFound(new { message = "No se puede eliminar el usuario" });

                candidateCompany.Document = null;
                candidateCompany.OtherDocument = null;
                candidateCompany.DocumentTypeId = 0;

                bool isDelete = await _candidateCompanyRepository.Update(candidateCompany);

                if (isDelete)
                    return StatusCode(200, new { message = "Documento eliminado correctamente" });

                return StatusCode(500, new { message = "No se pudo eliminar el documento, intente mas tarde" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("deleteAddressCompany/{CandidateId}")]
        public async Task<IActionResult> DeleteAddressFromCompany(int candidateId)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "AddProfileInfo";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                Candidate candidate = await _candidateRepository.GetById(candidateId);

                if (candidate == null)
                    return NotFound(new { message = "No existe el usuario" });

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                if (memberUser == null)
                    return StatusCode(403, new { message = "No autorizado" });

                CandidateCompany candidateCompany = await _candidateCompanyRepository.GetByCandidateAndCompanyId(candidateId, memberUser.CompanyUserId);

                if (candidateCompany == null)
                    return NotFound(new { message = "No se puede eliminar el usuario" });

                candidateCompany.Address = null;

                bool isDelete = await _candidateCompanyRepository.Update(candidateCompany);

                if (isDelete)
                    return StatusCode(200, new { message = "Dirección eliminada correctamente" });

                return StatusCode(500, new { message = "No se pudo eliminar la dirección, intente mas tarde" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
               
        [HttpPatch("deletePhotoAdmin/{CandidateId}")]
        public async Task<IActionResult> DeletePhotoAdmin(int candidateId)
        {
            /* MODIFICAR MÉTODO DESPUÉS DE TERMINAR EL MULTIEMPRESA */

            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "DeleteBasicInfo";

                var isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                BasicInformation basicinfo = await _basicInformationRepository.GetByCandidateId(candidateId);
                CandidateCompany candidateCompany = await _candidateCompanyRepository.GetByCandidateAndCompanyId(candidateId, memberUser.CompanyUserId);

                Candidate candidate = await _candidateRepository.GetById(basicinfo.CandidateId);

                if (candidate.IsMigrated == 0)
                    return BadRequest(new { message = "No tiene permiso para eliminar foto al candidato." });

                if (basicinfo != null)
                {
                    basicinfo.Photo = null;
                    candidateCompany.Photo = null;

                    bool edited = await _basicInformationRepository.Update(basicinfo);
                    bool edited2 = await _candidateCompanyRepository.Update(candidateCompany);

                    if (edited)
                        return StatusCode(200, new { message = "Se elimino foto exitosamente" });
                    return BadRequest(new { message = "No fue posible eliminar foto al candidato." });
                }
                return StatusCode(500, new { message = "No existe el candidato" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.InnerException.Message });
            }
        }

        [HttpDelete("deleteBirthDateCompany/{CandidateId}")]
        public async Task<IActionResult> DeleteBirthDateFromCompany(int candidateId)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "AddProfileInfo";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                Candidate candidate = await _candidateRepository.GetById(candidateId);

                if (candidate == null)
                    return NotFound(new { message = "No existe el usuario" });

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                if (memberUser == null)
                    return StatusCode(403, new { message = "No autorizado" });

                CandidateCompany candidateCompany = await _candidateCompanyRepository.GetByCandidateAndCompanyId(candidateId, memberUser.CompanyUserId);

                if (candidateCompany == null || string.IsNullOrEmpty(candidateCompany.BirthDate))
                    return NotFound(new { message = "No se puede eliminar la fecha de nacimiento" });

                candidateCompany.BirthDate = null;

                bool isDelete = await _candidateCompanyRepository.Update(candidateCompany);

                if (isDelete)
                    return StatusCode(200, new { message = "Fecha de nacimiento eliminada correctamente" });

                return StatusCode(500, new { message = "No se pudo eliminar la fecha de naicmiento, intente mas tarde" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        #endregion

        #region TEST

        [HttpGet("test")]
        public ObjectResult BasicInformationTest()
        {
            return Ok(new { message = "La prueba que no le pega a DB funcionó.", obj = 1 });
        }

        #endregion
    }
}

