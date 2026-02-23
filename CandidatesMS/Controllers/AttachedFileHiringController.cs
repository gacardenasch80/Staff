using AutoMapper;
using CandidatesMS.Helpers;
using CandidatesMS.KeyVault.SecretsModels;
using CandidatesMS.Models;
using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.Models.RemoteModels.Out;
using CandidatesMS.ModelsCompany;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using CandidatesMS.Repositories.RemoteRepositories;
using CandidatesMS.RepositoriesCompany;
using CandidatesMS.KeyVault.SecretsModels;
using CandidatesMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using S3bucketDemo.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CandidatesMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttachedFileHiringController : ControllerBase
    {
        private IAttachedFileHiringRepository _attachedFileHiringRepository;
        private IBasicInformationRepository _basicInformationRepository;
        private ICandidateRepository _candidateRepository;
        private ICompanyRemoteRepository _companyRemoteRepository;
        private ICVHiringRepository _cvHiringRepository;
        private IMemberUserRepository _memberUserRepository;

        private IUploadTimeService _uploadTimeService;
        private IAWSS3FileService _AWSS3FileService;
        private IBlockchainService _blockchainService;
        private readonly IValidateMethodsService _validateMethodsService;

        private  IAuthorizationHelper _authorizationHelper;
        private  ICryptoHelper _cryptoHelper;

        private IMapper _mapper;
        private IMatchServerDate _matchServerDate;

        private ServiceConfigurationDTO _settings;

        public AttachedFileHiringController(ICompanyRemoteRepository companyRemoteRepository,
                                            ICandidateRepository candidateRepository,
                                            IBasicInformationRepository basicInformationRepository,
                                            IAWSS3FileService aWSS3FileService,
                                            IMatchServerDate matchServerDate,
                                            IAttachedFileHiringRepository attachedFileHiringRepository,
                                            ICVHiringRepository cvHiringRepository,
                                            IMemberUserRepository memberUserRepository,

                                            IValidateMethodsService validateMethodsService,
                                            IUploadTimeService uploadTimeService,
                                            IBlockchainService blockchainService,
                                            IAuthorizationHelper authorizationHelper,
                                            ICryptoHelper cryptoHelper,
                                            IMapper mapper,
                                            IOptions<ServiceConfigurationDTO> settings)
        {
            _companyRemoteRepository = companyRemoteRepository;
            _candidateRepository = candidateRepository;
            _basicInformationRepository = basicInformationRepository;
            _AWSS3FileService = aWSS3FileService;
            _mapper = mapper;
            _matchServerDate = matchServerDate;
            _attachedFileHiringRepository = attachedFileHiringRepository;
            _memberUserRepository = memberUserRepository;
            _cvHiringRepository = cvHiringRepository;

            _validateMethodsService = validateMethodsService;
            _uploadTimeService = uploadTimeService;
            _authorizationHelper = authorizationHelper;
            _blockchainService = blockchainService;
            _cryptoHelper = cryptoHelper;

            _settings = settings.Value;
        }

        [HttpPost("listWithType")]
        public async Task<IActionResult> UploadListAttachedFileWithType([FromForm] AttachedFileHiringFormDTO form)
        {
            try
            {

                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                
                string validation = "UploadHiringFiles";

                
                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                var member = await _validateMethodsService.GetResponseValidateActionByPermission(validation, values.ToString());

                bool candidateExists = false;

                if (form != null)
                {
                    candidateExists = _candidateRepository.CandidateExistById(form.CandidateId);
                }

                if (candidateExists)
                {
                    for (int i = 0; i < form.Files.Count; i++)
                    {
                        decimal lengthFile = (decimal)(form.Files[i].Length) / 1024;

                        double lengthFileDouble = (double)(decimal.Round(lengthFile, 2, MidpointRounding.AwayFromZero));

                        string token =
                            _cryptoHelper.EncodeSHA256(form.Files[i].FileName.Trim(), form.Files[i].ContentType.Trim(),
                            lengthFileDouble);

                        bool isStoredInBlockChain = false;

                        Task<bool> task = Task.Run(() => _blockchainService.SaveFile(form.Files[i].FileName.Trim(), form.Files[i].ContentType.Trim(),
                            lengthFileDouble, token));
                        if (task.Wait(TimeSpan.FromSeconds(10)))
                            isStoredInBlockChain = await task;
                        else
                            return StatusCode(400, new { message = "Blockchain no habilitada" });

                        /**/

                        //AttachedFileHiring file = await _attachedFileHiringRepository.GetByHash(token);

                        //if (file != null)
                        //    isStoredInBlockChain = true;

                        /**/

                        if (!isStoredInBlockChain)
                            return StatusCode(400, new { message = "El documento ya existe" });

                        var result = await _AWSS3FileService.UploadFile(form.Files[i], "AttachedFiles");
                        if (result == null)
                            return BadRequest(result);
                        else
                        {
                            try
                            {
                                AttachedFileHiring attachedFile = new AttachedFileHiring();
                                attachedFile.FileIdentifier = result;
                                attachedFile.Name = form.Files[i].FileName;
                                attachedFile.UploadDate = _matchServerDate.CreateServerDate();
                                attachedFile.NameMemberUser = member.Name;
                                attachedFile.SurnameMemberUser = member.Surname;
                                attachedFile.EmailMemberUser = member.Email;
                                attachedFile.CompanyUserId = member.CompanyUserId;
                                attachedFile.FileTypeHiringId = form.Types[i];
                                attachedFile.CandidateId = form.CandidateId;
                                attachedFile.OtherName = form.Others != null && form.Others.Count > 0 ? form.Others[i] : "";
                                attachedFile.HiringId = form.HiringId;
                                attachedFile.Weight = lengthFileDouble;
                                attachedFile.Hash = token;
                                bool created = await _attachedFileHiringRepository.AddByCandidate(attachedFile);

 
                            }
                            catch (Exception ex)
                            {
                                return StatusCode(500, new { message = ex.Message });
                            }
                        }
                    }

                    return Created("", new { message = "Almacenados exitosamente" });
                }
                else
                {
                    return StatusCode(404, new { message = "El candidato no existe." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.InnerException });
            }
        }

        [HttpPost("createAttachedFilesiringCandidate")]
        public async Task<IActionResult> UploadListAttachedFileWithTypeCandidate([FromForm] AttachedFileHiringFormDTO form)
        {
            try
            {
                string email = _authorizationHelper.GetEmailFromToken(Request);

                Candidate candidate = await _candidateRepository.GetByEmail(email);

                bool candidateExists = false;

                if (form != null && candidate != null)
                    candidateExists = _candidateRepository.CandidateExistById(candidate.CandidateId);

                if (candidateExists)
                {
                    form.CandidateId = candidate.CandidateId;

                    for (int i = 0; i < form.Files.Count; i++)
                    {
                        decimal lengthFile = (decimal)(form.Files[i].Length) / 1024;

                        double lengthFileDouble = (double)(decimal.Round(lengthFile, 2, MidpointRounding.AwayFromZero));

                        string token =
                            _cryptoHelper.EncodeSHA256(form.Files[i].FileName.Trim(), form.Files[i].ContentType.Trim(),
                        lengthFileDouble);

                        bool isStoredInBlockChain = false;

                        Task<bool> task = Task.Run(() => _blockchainService.SaveFile(form.Files[i].FileName.Trim(), form.Files[i].ContentType.Trim(),
                            lengthFileDouble, token));
                        if (task.Wait(TimeSpan.FromSeconds(10)))
                            isStoredInBlockChain = await task;
                        else
                            return StatusCode(400, new { message = "Blockchain no habilitada" });

                        /**/

                        //AttachedFileHiring file = await _attachedFileHiringRepository.GetByHash(token);

                        //if (file != null)
                        //    isStoredInBlockChain = true;

                        /**/

                        if (!isStoredInBlockChain)
                            return StatusCode(400, new { message = "El documento ya existe" });

                        var result = await _AWSS3FileService.UploadFile(form.Files[i], "AttachedFiles");
                        if (result == null)
                            return BadRequest(result);
                        else
                        {
                            try
                            {
                                AttachedFileHiring attachedFile = new AttachedFileHiring();
                                attachedFile.FileIdentifier = result;
                                attachedFile.Name = form.Files[i].FileName;
                                attachedFile.UploadDate = _matchServerDate.CreateServerDate();
                                attachedFile.NameMemberUser = "";
                                attachedFile.SurnameMemberUser = "";
                                attachedFile.EmailMemberUser = "";
                                attachedFile.CompanyUserId = 0;
                                attachedFile.FileTypeHiringId = form.Types[i];
                                attachedFile.CandidateId = form.CandidateId;
                                attachedFile.OtherName = form.Others != null && form.Others.Count > 0 ? form.Others[i] : "";
                                attachedFile.HiringId = form.HiringId;
                                attachedFile.Weight = lengthFileDouble;
                                attachedFile.Hash = token;
                                attachedFile.IsUploadedByCandidate = true;

                                bool created = await _attachedFileHiringRepository.AddByCandidate(attachedFile);

                            }
                            catch (Exception ex)
                            {
                                return StatusCode(500, new { message = ex.Message });
                            }
                        }
                    }

                    return Created("", new { message = "Almacenados exitosamente" });
                }
                else
                {
                    return StatusCode(404, new { message = "El candidato no existe." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.InnerException });
            }
        }

        [HttpPost("validateFile")]
        public async Task<IActionResult> ValidateAttachedHiringFile([FromForm] AttachedFileHiringFormDTO form)
        {
            try
            {

                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "ViewHASHSection";

                MemberUserDTO member = await _validateMethodsService.GetResponseValidateActionByPermission(validation, values.ToString());

                bool candidateExists = false;

                if (form != null)
                {
                    candidateExists = _candidateRepository.CandidateExistById(form.CandidateId);
                }

                if (candidateExists)
                {
                    AttachedFileHiringValidatedDTO fileInfo = new AttachedFileHiringValidatedDTO();

                    int i = 0;

                    decimal lengthFile = (decimal)(form.Files[i].Length) / 1024;

                    double lengthFileDouble = (double)(decimal.Round(lengthFile, 2, MidpointRounding.AwayFromZero));

                    string token =
                        _cryptoHelper.EncodeSHA256(form.Files[i].FileName, form.Files[i].ContentType, lengthFileDouble);

                    bool isStoredInBlockChain = false;

                    Task<bool> task = Task.Run(() => _blockchainService.ValidateHash(form.Files[i].FileName.Trim(), form.Files[i].ContentType.Trim(),
                        lengthFileDouble, token));
                    if (task.Wait(TimeSpan.FromSeconds(10)))
                        isStoredInBlockChain = await task;
                    else
                        return StatusCode(400, new { message = "Blockchain no habilitada" });

                    /**/

                    //AttachedFileHiring file = await _attachedFileHiringRepository.GetByHash(token);

                    //if (file != null)
                    //    isStoredInBlockChain = true;

                    /**/

                    if (!isStoredInBlockChain)
                        return StatusCode(400, new { message = "El documento no existe" });

                    try
                    {
                        AttachedFileHiring attachedFile = await _attachedFileHiringRepository.GetByHash(token);

                        BasicInformation basicInformation = new();

                        MemberUser memberFile = new();

                        if(attachedFile != null)
                        {
                            basicInformation = await _basicInformationRepository.GetByCandidateId(attachedFile.CandidateId);

                            memberFile = await _memberUserRepository.GetByEmail(attachedFile.EmailMemberUser);
                        }

                        string candidateName = "";
                        string memberName = "";

                        if (basicInformation != null)
                        {
                            if (!string.IsNullOrEmpty(basicInformation.Name))
                                candidateName = basicInformation.Name;

                            if (!string.IsNullOrEmpty(basicInformation.Surname))
                                candidateName += " " + basicInformation.Surname;
                        }

                        if (memberFile != null)
                        {
                            if (!string.IsNullOrEmpty(memberFile.Name))
                                memberName = memberFile.Name;

                            if (!string.IsNullOrEmpty(memberFile.Surname))
                                memberName += " " + memberFile.Surname;
                        }

                        string date = "";
                        string fileType = "";
                        string fileTypeEnglish = "";

                        if(attachedFile != null)
                        {
                            if(!string.IsNullOrEmpty(attachedFile.UploadDate))
                                date = attachedFile.UploadDate;

                            fileType = attachedFile.FileTypeHiring.Name;
                            fileTypeEnglish = attachedFile.FileTypeHiring.NameEnglish;
                        }

                        fileInfo = new AttachedFileHiringValidatedDTO
                        {
                            FileName = form.Files[i].FileName,
                            FileType = fileType,
                            FileTypeEnglish = fileTypeEnglish,
                            MmberUserName = memberName,
                            Size = lengthFileDouble + " KB",
                            Date = date,
                            Hash = token,
                            CandidateName = candidateName
                        };

                        if(string.IsNullOrEmpty(fileInfo.MmberUserName))
                        {
                            string candidateCreatorName = "";

                            if (basicInformation != null)
                            {
                                if (!string.IsNullOrEmpty(basicInformation.Name))
                                    candidateCreatorName = basicInformation.Name;

                                if (!string.IsNullOrEmpty(basicInformation.Surname))
                                    candidateCreatorName += " " + basicInformation.Surname;
                            }

                            fileInfo.MmberUserName = candidateCreatorName;
                        }
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(500, new { message = ex.Message });
                    }

                    return StatusCode(200, new { message = "Consultado exitosamente", obj = fileInfo });
                }
                else
                {
                    return StatusCode(404, new { message = "El candidato no existe." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("allFilesByCandidate/{candidateId}")]
        public async Task<IActionResult> GetAllFilesByCandidateId(int candidateId)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                int companyUserId = 0;

                List<MemberByToken> remoteMemberUsers = await _companyRemoteRepository.GetAllMemberUserByToken(values);

                if (remoteMemberUsers != null && remoteMemberUsers.Count > 0)
                    companyUserId = remoteMemberUsers[0].companyUserId;

                List<FilesDTO> filesCompany = new List<FilesDTO>();
                List<FilesDTO> filesPortal = new List<FilesDTO>();
                List<AttachedFileHiring> attachedFiles = new List<AttachedFileHiring>();
                List<CVHiring> CVs = new List<CVHiring>();

                Candidate candidate = await _candidateRepository.GetById(candidateId);
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());
                if (isMaster)
                {
                    attachedFiles = await _attachedFileHiringRepository.GetOwnUploadedCandidateId(candidateId);
                    CVs = await _cvHiringRepository.GetUploadByCandidateByCandidateId(candidateId);
                }
                else
                {
                    string validation = "ViewHiringFiles";

                    bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());

                    if (!isAuthorized)
                        return StatusCode(403, new { message = "No autorizado" });

                    if (candidate != null && candidate.IsAuthDocumentsHiring)
                    {
                        attachedFiles = await _attachedFileHiringRepository.GetByCandidateIdAndCompanyId(candidateId, companyUserId);
                        CVs = await _cvHiringRepository.GetAllByCandidateIdAndCompanyUserId(candidateId, companyUserId);
                    }
                    else
                    {
                        attachedFiles = await _attachedFileHiringRepository.GetByCandidateIdAndOnlyCompanyId(candidateId, companyUserId);
                        CVs = await _cvHiringRepository.GetAllByCandidateIdAndOnlyCompanyUserId(candidateId, companyUserId);
                    }
                }

                if (attachedFiles.Count() == 0 && CVs.Count() == 0)
                    return NotFound(new { message = "No se encontraron archivos relacionados." });

                foreach (AttachedFileHiring attachFile in attachedFiles)
                {
                    string initials = string.Empty;
                    string name = string.Empty;
                    string photo = string.Empty;

                    MemberUser memberUserTemp = await _memberUserRepository.GetByEmail(attachFile.EmailMemberUser);

                    if (memberUserTemp != null)
                    {
                        if (memberUserTemp.Photo != null)
                            photo = memberUserTemp.Photo;

                        initials = memberUserTemp.Name[0].ToString().ToUpper() + memberUserTemp.Surname[0].ToString().ToUpper();
                        name = memberUserTemp.Name + " " + memberUserTemp.Surname;
                    }

                    bool memberDeleted = false;

                    if (memberUserTemp == null)
                    {
                        if (!string.IsNullOrEmpty(attachFile.NameMemberUser) && !string.IsNullOrEmpty(attachFile.SurnameMemberUser))
                        {
                            name = attachFile.NameMemberUser + " " + attachFile.SurnameMemberUser;
                            initials = attachFile.NameMemberUser[0].ToString().ToUpper() + attachFile.SurnameMemberUser[0].ToString().ToUpper();
                        }

                        memberDeleted = true;
                    }

                    string NameFile = "";
                    if (attachFile.FileTypeHiringId == 19 && !string.IsNullOrEmpty(attachFile.OtherName))
                        NameFile = attachFile.OtherName;
                    else
                        NameFile = attachFile.FileTypeHiring.Name;

                    FilesDTO file = new FilesDTO()
                    {
                        Id = attachFile.AttachedFileHiringId,
                        CandidateId = attachFile.CandidateId,
                        Identifier = attachFile.FileIdentifier,
                        Name = attachFile.Name,
                        IdentifierLink = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + attachFile.FileIdentifier,
                        FileTypeId = attachFile.FileTypeHiringId,
                        FileType = NameFile,
                        uploadDate = _uploadTimeService.GetPublicationInfo(attachFile.UploadDate),
                        uploadDateEnglish = _uploadTimeService.GetPublicationInfoEnglish(attachFile.UploadDate),
                        uploaderName = "",
                        CreationInfoPup = _uploadTimeService.GetFileTypeCreationInfoPup(attachFile.UploadDate),
                        CreationInfoPupEnglish = _uploadTimeService.GetFileTypeCreationInfoPupEnglish(attachFile.UploadDate),
                        CreationShortInfo = _uploadTimeService.GetFileTypeCreationShortInfo(attachFile.UploadDate),
                        Initials = initials,
                        Photo = photo,
                        NameMember = name,
                        NameMemberUser = attachFile.NameMemberUser,
                        SurnameMemberUser = attachFile.SurnameMemberUser,
                        EmailMemberUser = attachFile.EmailMemberUser,
                        MemberDeleted = memberDeleted,
                        Hash = !string.IsNullOrEmpty(attachFile.Hash) ? attachFile.Hash : "",
                        SizeKb = attachFile.Weight.ToString() + " KB"
                    };

                    if (attachFile.CompanyUserId != 0)
                        filesCompany.Add(file);
                    else
                        filesPortal.Add(file);
                }

                foreach (CVHiring cv in CVs)
                {
                    string initials = string.Empty;
                    string name = string.Empty;
                    string photo = string.Empty;

                    MemberUser memberUserTemp = await _memberUserRepository.GetByEmail(cv.EmailMemberUser);

                    if (memberUserTemp != null)
                    {
                        if (memberUserTemp.Photo != null)
                            photo = memberUserTemp.Photo;

                        initials = memberUserTemp.Name[0].ToString().ToUpper() + memberUserTemp.Surname[0].ToString().ToUpper();
                        name = memberUserTemp.Name + " " + memberUserTemp.Surname;
                    }

                    bool memberDeleted = false;

                    if (memberUserTemp == null && cv.EmailMemberUser != null)
                    {
                        if (!string.IsNullOrEmpty(cv.NameMemberUser) && !string.IsNullOrEmpty(cv.SurnameMemberUser))
                        {
                            name = cv.NameMemberUser + " " + cv.SurnameMemberUser;
                            initials = cv.NameMemberUser[0].ToString().ToUpper() + cv.SurnameMemberUser[0].ToString().ToUpper();
                        }

                        memberDeleted = true;
                    }

                    FilesDTO file = new FilesDTO()
                    {
                        Id = cv.CVHiringId,
                        CandidateId = cv.CandidateId,
                        Identifier = cv.CvIdentifier,
                        IdentifierLink = cv.CvIdentifierLink,
                        Name = cv.Name,
                        FileTypeId = cv.FileTypeHiringId,
                        FileType = cv.FileTypeHiring.Name,
                        uploadDate = _uploadTimeService.GetPublicationInfo(cv.UploadDate),
                        uploadDateEnglish = _uploadTimeService.GetPublicationInfoEnglish(cv.UploadDate),
                        uploaderName = "",
                        CreationInfoPup = _uploadTimeService.GetFileTypeCreationInfoPup(cv.UploadDate),
                        CreationInfoPupEnglish = _uploadTimeService.GetFileTypeCreationInfoPupEnglish(cv.UploadDate),
                        CreationShortInfo = _uploadTimeService.GetFileTypeCreationShortInfo(cv.UploadDate),
                        Initials = initials,
                        Photo = photo,
                        NameMember = name,
                        MemberDeleted = memberDeleted,
                        Hash = !string.IsNullOrEmpty(cv.Hash) ? cv.Hash : "",
                        SizeKb = cv.Weight.ToString() + " KB"
                    };

                    if (cv.CompanyUserId != 0)
                        filesCompany.Add(file);
                    else
                        filesPortal.Add(file);

                }

                

                CandidateFilesDTO returnLists = new CandidateFilesDTO()
                {
                    PortalFiles = filesPortal,
                    CompanyFiles = filesCompany
                };

                return Ok(new { message = "Archivos consultados exitosamente", obj = returnLists });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
            //catch (ArgumentException e) { return BadRequest(e); }
        }


        [HttpGet("allFilesUploadByCandidate/{candidateId}")]
        public async Task<IActionResult> GetAllFilesUploadByCandidateId(int candidateId)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);


                List<FilesDTO> filesPortal = new List<FilesDTO>();
                List<AttachedFileHiring> attachedFiles = await _attachedFileHiringRepository.GetUploadByCandidateByCandidateId(candidateId);
                List<CVHiring> CVs = await _cvHiringRepository.GetUploadByCandidateByCandidateId(candidateId);


                if (attachedFiles.Count() == 0 && CVs.Count() == 0)
                    return NotFound(new { message = "No se encontraron archivos relacionados." });



                foreach (var attachFile in attachedFiles)
                {
                    string initials = string.Empty;
                    string name = string.Empty;
                    string photo = string.Empty;

                    MemberUser memberUserTemp = await _memberUserRepository.GetByEmail(attachFile.EmailMemberUser);

                    if (memberUserTemp != null)
                    {
                        if (memberUserTemp.Photo != null)
                            photo = memberUserTemp.Photo;

                        initials = memberUserTemp.Name[0].ToString().ToUpper() + memberUserTemp.Surname[0].ToString().ToUpper();
                        name = memberUserTemp.Name + " " + memberUserTemp.Surname;
                    }

                    bool memberDeleted = false;

                    if (memberUserTemp == null)
                    {
                        if (!string.IsNullOrEmpty(attachFile.NameMemberUser) && !string.IsNullOrEmpty(attachFile.SurnameMemberUser))
                        {
                            name = attachFile.NameMemberUser + " " + attachFile.SurnameMemberUser;
                            initials = attachFile.NameMemberUser[0].ToString().ToUpper() + attachFile.SurnameMemberUser[0].ToString().ToUpper();
                        }

                        memberDeleted = true;
                    }

             
                    FilesDTO file = new FilesDTO()
                    {
                        Id = attachFile.AttachedFileHiringId,
                        CandidateId = attachFile.CandidateId,
                        Identifier = attachFile.FileIdentifier,
                        Name = attachFile.Name,
                        IdentifierLink = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + attachFile.FileIdentifier,
                        FileTypeId = attachFile.FileTypeHiringId,
                        FileType = attachFile.FileTypeHiring.Name,
                        uploadDate = _uploadTimeService.GetPublicationInfo(attachFile.UploadDate),
                        uploadDateEnglish = _uploadTimeService.GetPublicationInfoEnglish(attachFile.UploadDate),
                        uploaderName = "",
                        CreationInfoPup = _uploadTimeService.GetFileTypeCreationInfoPup(attachFile.UploadDate),
                        CreationInfoPupEnglish = _uploadTimeService.GetFileTypeCreationInfoPupEnglish(attachFile.UploadDate),
                        CreationShortInfo = _uploadTimeService.GetFileTypeCreationShortInfo(attachFile.UploadDate),
                        Initials = initials,
                        Photo = photo,
                        NameMember = name,
                        NameMemberUser = attachFile.NameMemberUser,
                        SurnameMemberUser = attachFile.SurnameMemberUser,
                        EmailMemberUser = attachFile.EmailMemberUser,
                        MemberDeleted = memberDeleted
                    };

                    filesPortal.Add(file);
                }

                foreach (var cv in CVs)
                {
                    string initials = string.Empty;
                    string name = string.Empty;
                    string photo = string.Empty;

                    MemberUser memberUserTemp = await _memberUserRepository.GetByEmail(cv.EmailMemberUser);

                    if (memberUserTemp != null)
                    {
                        if (memberUserTemp.Photo != null)
                            photo = memberUserTemp.Photo;

                        initials = memberUserTemp.Name[0].ToString().ToUpper() + memberUserTemp.Surname[0].ToString().ToUpper();
                        name = memberUserTemp.Name + " " + memberUserTemp.Surname;
                    }

                    bool memberDeleted = false;

                    if (memberUserTemp == null && cv.EmailMemberUser != null)
                    {
                        if (!string.IsNullOrEmpty(cv.NameMemberUser) && !string.IsNullOrEmpty(cv.SurnameMemberUser))
                        {
                            name = cv.NameMemberUser + " " + cv.SurnameMemberUser;
                            initials = cv.NameMemberUser[0].ToString().ToUpper() + cv.SurnameMemberUser[0].ToString().ToUpper();
                        }

                        memberDeleted = true;
                    }

                    FilesDTO file = new FilesDTO()
                    {
                        Id = cv.CVHiringId,
                        CandidateId = cv.CandidateId,
                        Identifier = cv.CvIdentifier,
                        IdentifierLink = cv.CvIdentifierLink,
                        Name = cv.Name,
                        FileTypeId = cv.FileTypeHiringId,
                        FileType = cv.FileTypeHiring.Name,
                        uploadDate = _uploadTimeService.GetPublicationInfo(cv.UploadDate),
                        uploadDateEnglish = _uploadTimeService.GetPublicationInfoEnglish(cv.UploadDate),
                        uploaderName = "",
                        CreationInfoPup = _uploadTimeService.GetFileTypeCreationInfoPup(cv.UploadDate),
                        CreationInfoPupEnglish = _uploadTimeService.GetFileTypeCreationInfoPupEnglish(cv.UploadDate),
                        CreationShortInfo = _uploadTimeService.GetFileTypeCreationShortInfo(cv.UploadDate),
                        Initials = initials,
                        Photo = photo,
                        NameMember = name,
                        MemberDeleted = memberDeleted
                    };

                    filesPortal.Add(file);
                }

                
                return Ok(new { message = "Archivos consultados exitosamente", obj = filesPortal });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
            //catch (ArgumentException e) { return BadRequest(e); }
        }


        [HttpDelete("deletefile/{fileId}/{fileType}")]
        public async Task<IActionResult> RemoveFilesById(int fileId, int fileType)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "DeleteHiringFiles";
                
                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                AttachedFileHiring attachedFile = await _attachedFileHiringRepository.GetById(fileId);

                string token = "";

                if(attachedFile != null && !string.IsNullOrEmpty(attachedFile.Hash))
                    token = attachedFile.Hash;
                /**/

                bool isDeletedInBlockChain = false;

                Task<bool> task = Task.Run(() => _blockchainService.DeleteFile(token));
                if (task.Wait(TimeSpan.FromSeconds(10)))
                    isDeletedInBlockChain = await task;
                else
                    return StatusCode(400, new { message = "Blockchain no habilitada" });

                /**/
                if(isDeletedInBlockChain)
                    attachedFile = await _attachedFileHiringRepository.Remove(fileId);

                if (attachedFile != null)
                {
                    Candidate candidate = await _candidateRepository.GetByCandidateId(attachedFile.CandidateId);

                    if(candidate == null)
                        return StatusCode(404, new { message = "El candidato no existe" });

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

                    if(remoteMemberUsers != null && remoteMemberUsers.Count > 0)
                        memberUser = remoteMemberUsers[0];

                    if(memberUser != null)
                    {
                        memberUserInitials = !string.IsNullOrEmpty(memberUser.name) ? memberUser.name.ToString() : "";
                        memberUserInitials += !string.IsNullOrEmpty(memberUser.surname) ? memberUser.surname[0].ToString() : "";

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
                        attachedFileName = attachedFile.Name,
                        memberUserName = memberUserFullName,
                        memberUserInitials = memberUserInitials,
                        memberUserPhoto = memberUserPhoto,
                    };

                    bool notificationCreated = await _companyRemoteRepository.AddNotificationFromDeleteHiringFileFromCandidate(notificationOutDTO, values);

                    return StatusCode(200, new { message = "Eliminado exitosamente" });
                }
                
                return StatusCode(404, new { message = "El documento no existe" });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("deletefileOnlyBlockchain/{token}")]
        public async Task<IActionResult> RemoveFileOnlyBlockchainByHash(string token)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "DeleteHiringFiles";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                /**/

                bool isDeletedInBlockChain = false;

                Task<bool> task = Task.Run(() => _blockchainService.DeleteFile(token));
                if (task.Wait(TimeSpan.FromSeconds(10)))
                    isDeletedInBlockChain = await task;
                else
                    return StatusCode(400, new { message = "Blockchain no habilitada" });

                /**/

                return StatusCode(200, new { message = "Eliminado exitosamente" });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("deletefileByHash/{token}")]
        public async Task<IActionResult> RemoveFileByHash(string token)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "DeleteHiringFiles";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                /**/

                AttachedFileHiring attachedFileHiring = await _attachedFileHiringRepository.GetByHash(token);

                AttachedFileHiring attachedFileHiringDeleted = new AttachedFileHiring();

                if (attachedFileHiring != null)
                {
                    attachedFileHiringDeleted = await _attachedFileHiringRepository.Remove(attachedFileHiring.AttachedFileHiringId);
                }

                /**/

                bool isDeletedInBlockChain = false;

                Task<bool> task = Task.Run(() => _blockchainService.DeleteFile(token));
                if (task.Wait(TimeSpan.FromSeconds(10)))
                    isDeletedInBlockChain = await task;
                else
                    return StatusCode(400, new { message = "Blockchain no habilitada" });

                /**/

                if(attachedFileHiringDeleted == null && !isDeletedInBlockChain)
                    return StatusCode(400, new { message = "No se pudo eliminar el archivo" });

                if (attachedFileHiringDeleted != null)
                {
                    Candidate candidate = await _candidateRepository.GetByCandidateId(attachedFileHiringDeleted.CandidateId);

                    if (candidate == null)
                        return StatusCode(404, new { message = "El candidato no existe" });

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
                        attachedFileName = attachedFileHiringDeleted.Name,
                        memberUserName = memberUserFullName,
                        memberUserInitials = memberUserInitials,
                        memberUserPhoto = memberUserPhoto,
                    };

                    bool notificationCreated = await _companyRemoteRepository.AddNotificationFromDeleteHiringFileByHASHFromCandidate(notificationOutDTO, values);
                }

                return StatusCode(200, new { message = "Eliminado exitosamente" });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("getIsAuthDocuments/{candidateId}")]
        public async Task<IActionResult> GetIsAuthDocuments(int candidateId)
        {
            Candidate candidate = await _candidateRepository.GetById(candidateId);

            if (candidate == null)
                return NotFound(new { message = "El candidato no existe" });

            return StatusCode(200, new { message = "Consultado exitosamente", obj = candidate.IsAuthDocumentsHiring });
        }

        [HttpGet("editIsAuthDocuments/{candidateId}")]
        public async Task<IActionResult> EditIsAuthDocuments(int candidateId)
        {
            Candidate candidate = await _candidateRepository.GetById(candidateId);

            if (candidate == null)
                return NotFound(new { message = "El candidato no existe" });

            candidate.IsAuthDocumentsHiring = !candidate.IsAuthDocumentsHiring;

            bool isEdited = await _candidateRepository.Update(candidate);

            if (!isEdited)
                return StatusCode(400, new { message = "No se pudo editar el candidato" });

            return StatusCode(200, new { message = "Editado exitosamente", obj = candidate });
        }

        [HttpGet("getDocumentsUploadedByCandidate/{candidateId}")]
        public async Task<IActionResult> GetOwnDocuments(int candidateId)
        {
            Candidate candidate = await _candidateRepository.GetById(candidateId);

            if (candidate == null)
                return NotFound(new { message = "El candidato no existe" });

            List<AttachedFileHiring> files = await _attachedFileHiringRepository.GetOwnUploadedCandidateId(candidateId);

            if (files == null || files.Count == 0)
                files = new List<AttachedFileHiring>();

            List<AttachedFileHiringDTO> filesDTO = _mapper.Map<List<AttachedFileHiring>, List<AttachedFileHiringDTO>>(files);

            if (filesDTO != null && filesDTO.Count > 0)
                foreach (AttachedFileHiringDTO file in filesDTO)
                    file.IdentifierLink = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + file.FileIdentifier;

            return StatusCode(200, new { message = "Archivos consultados exitosamente", obj = filesDTO });
        }

        [HttpGet("download/{attachedFileHiringId}")]
        public async Task<FileResult> GetFileDownloadByCandidateId(int attachedFileHiringId)
        {
            byte[] byteArr;
            
            AttachedFileHiring file = await _attachedFileHiringRepository.GetById(attachedFileHiringId);

            if (file == null)
                return null;

            try
            {
                WebClient client = new WebClient();
                System.Uri uri = new System.Uri("https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + file.FileIdentifier);
                //Stream stream = await client.OpenReadTaskAsync(uri);
                Stream stream = await _AWSS3FileService.GetFile(file.FileIdentifier);

                using (var memoryStream = new MemoryStream())
                {
                    stream.Position = 0;
                    stream.CopyTo(memoryStream);
                    byteArr = memoryStream.ToArray();
                }

                var result = File(byteArr, "application/octet-stream");
                result.FileDownloadName = Regex.Replace(file.Name, @"[^0-9a-zA-Z.]+", "");

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
