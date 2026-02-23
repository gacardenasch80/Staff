using Amazon.S3;
using AutoMapper;
using CandidatesMS.KeyVault.SecretsModels;
using CandidatesMS.Models;
using CandidatesMS.Models.RemoteModels.In;
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
    public class AttachedFileController : ControllerBase
    {
        private IAWSS3FileService _AWSS3FileService; 
        private IAttachedFileRepository _attachedFileRepository;
        private ICVRepository _cVRepository;
        private ICandidateRepository _candidateRepository;
        private IMapper _mapper;
        private IUploadTimeService _uploadTimeService;
        private IStudyCertificateRepository _studyCertificateRepository;
        private IStudyRepository _studyRepository;
        private IMatchServerDate _matchServerDate;
        private ICompanyRemoteRepository _companyRemoteRepository;
        private ICVRepository _cvRepository;

        private IMemberUserRepository _memberUserRepository;

        private readonly IValidateMethodsService _validateMethodsService;

        private readonly IAmazonS3 _amazonS3;
        private readonly ServiceConfigurationDTO _settings;

        public AttachedFileController
            (
                                      IAWSS3FileService aWSS3FileService, 
                                      ICVRepository cVRepository,
                                      IAttachedFileRepository attachedFileRepository, 
                                      ICandidateRepository candidateRepository, 
                                      IMapper mapper,
                                      IUploadTimeService uploadTimeService,
                                      IStudyCertificateRepository studyCertificateRepository,
                                      IStudyRepository studyRepository,
                                      IMatchServerDate matchServerDate,
                                      ICompanyRemoteRepository companyRemoteRepository,
                                      ICVRepository basicInformationRepository,

                                      IMemberUserRepository memberUserRepository,

                                      IValidateMethodsService validateMethodsService,

                                      IAmazonS3 s3Client,
                                      IOptions<ServiceConfigurationDTO> settings
            )
        {
            _AWSS3FileService = aWSS3FileService;
            _cVRepository = cVRepository;
            _attachedFileRepository = attachedFileRepository;
            _candidateRepository = candidateRepository;
            _mapper = mapper;
            _uploadTimeService = uploadTimeService;
            _studyCertificateRepository = studyCertificateRepository;
            _studyRepository = studyRepository;
            _matchServerDate = matchServerDate;
            _companyRemoteRepository = companyRemoteRepository;
            _cvRepository = basicInformationRepository;

            _memberUserRepository = memberUserRepository;

            _validateMethodsService = validateMethodsService;

            _amazonS3 = s3Client;
            _settings = settings.Value;
        }

        [HttpGet]
        public async Task<ObjectResult> GetAllAttachedFiles()
        {
            List<AttachedFile> attachedFile = await _attachedFileRepository.GetAllUploadByCandidate();
            List<AttachedFileDTO> attachedFilesDto = _mapper.Map<List<AttachedFile>, List<AttachedFileDTO>>(attachedFile);

            return StatusCode(200, attachedFilesDto);
        }

        [HttpPost]
        public async Task<IActionResult> UploadAttachedFile([FromForm] AttachedFileDTO req)
        {
        
                bool candidateExists = _candidateRepository.CandidateExistById(req.CandidateId);
                if (candidateExists)
                {
                    var result = await _AWSS3FileService.UploadFile(req.FormFile, "AttachedFiles");
                    if (result == null)
                        return BadRequest(result);
                    else
                    {
                        try
                        {
                            AttachedFile attachedFile = _mapper.Map<AttachedFileDTO, AttachedFile>(req);
                            attachedFile.FileIdentifier = result;
                            attachedFile.Name = req.FormFile.FileName;
                            //attachedFile.UploadDate = DateTime.Now.ToString();
                            attachedFile.UploadDate = _matchServerDate.CreateServerDate();

                            /**/
                            attachedFile.FileTypeId = 7;
                            /**/

                            bool created = await _attachedFileRepository.AddByCandidate(attachedFile);

                            if (created)
                                return Created("", new { message = "Almacenado exitosamente", filename = attachedFile.Name });
                            else
                                return BadRequest(new { message = "El documento no fue almacenado" });
                        }
                        catch (Exception ex)
                        {
                            return StatusCode(500, new { message = ex.Message });
                        }
                    }
                }
                else
                {
                    return StatusCode(404, new { message = "El candidato no existe." });
                }            
        }

        [HttpPost("withType")]
        public async Task<IActionResult> UploadAttachedFileWithType([FromForm] AttachedFileDTO req)
        {
            StringValues values = "";
            Request.Headers.TryGetValue("Authorization", out values);

            string validation = "AddBasicInfo";

            bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
            bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

            if (!isMaster && !isAuthorized)
                return StatusCode(403, new { message = "No autorizado" });

            var member = await _validateMethodsService.GetResponseValidateActionByPermission(validation, values.ToString());

            bool candidateExists = _candidateRepository.CandidateExistById(req.CandidateId);
                if (candidateExists)
                {
                    var result = await _AWSS3FileService.UploadFile(req.FormFile, "AttachedFiles");
                    if (result == null)
                        return BadRequest(result);
                    else
                    {
                        try
                        {
                            AttachedFile attachedFile = _mapper.Map<AttachedFileDTO, AttachedFile>(req);
                            attachedFile.FileIdentifier = result;
                            attachedFile.Name = req.FormFile.FileName;                            
                            attachedFile.UploadDate = _matchServerDate.CreateServerDate();
                            attachedFile.NameMemberUser = member.Name;
                            attachedFile.SurnameMemberUser = member.Surname;
                            attachedFile.EmailMemberUser = member.Email;
                            attachedFile.CompanyUserId = member.CompanyUserId;

                            bool created = await _attachedFileRepository.AddByCandidate(attachedFile);

                            if (created)
                            {
                                if (req.FileTypeId == 9)
                                {
                                    Candidate authorized = await _candidateRepository.GetByCandidateId(req.CandidateId);
                                    authorized.isAuthorized = true;
                                    var update = await _candidateRepository.Update(authorized);
                                }
                                return Created("", new { message = "Almacenado exitosamente", filename = attachedFile.Name });
                            }
                            else
                                return BadRequest(new { message = "El documento no fue almacenado" });
                        }
                        catch (Exception ex)
                        {
                            return StatusCode(500, new { message = ex.Message });
                        }
                    }
                }
                else
                {
                    return StatusCode(404, new { message = "El candidato no existe." });
                }
        }

        [HttpPost("listWithType")]
        public async Task<IActionResult> UploadListAttachedFileWithType([FromForm] AttachedFileHiringFormDTO form)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "AddBasicInfo";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                var member = await _validateMethodsService.GetResponseValidateActionByPermission(validation, values.ToString());

                bool candidateExists = false;

                if (form != null)
                    candidateExists = _candidateRepository.CandidateExistById(form.CandidateId);

                if (candidateExists)
                {
                    for (int i = 0; i < form.Files.Count; i++)
                    {
                        string result = "";

                        if (form.Types[i] != 8)
                            result = await _AWSS3FileService.UploadFile(form.Files[i], "AttachedFiles");

                        if (result == null)
                            return BadRequest(new { message = "El documento no fue almacenado" });
                        else
                        {
                            try
                            {
                                if (form.Types[i] == 8)
                                {
                                    var email = "";
                                    var name = "";
                                    var surname = "";

                                    if (member != null)
                                    {
                                        email = member.Email;
                                        name = member.Name;
                                        surname = member.Surname;
                                    }

                                    var resultCV = await _AWSS3FileService.UploadCVFile(form.Files[i], "CV");

                                    CVDTO cvDTO = new CVDTO
                                    {
                                        CandidateId = form.CandidateId,
                                        CvIdentifier = resultCV[0],
                                        FormFile = form.Files[i],
                                        Name = form.Files[i].FileName,
                                        CvIdentifierLink = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + resultCV[0]
                                    };

                                    CV cvUser = _mapper.Map<CVDTO, CV>(cvDTO);

                                    cvUser.CVGuid = Convert.ToString(Guid.NewGuid());

                                    await _cvRepository.DeleteOverViewCv(cvDTO.CandidateId);
                                    cvUser.OverViewCv = true;

                                    cvUser.Name = cvDTO.FormFile.FileName;
                                    cvUser.FileTypeId = 8;
                                    cvUser.EmailMemberUser = member.Email;
                                    cvUser.NameMemberUser = member.Name;
                                    cvUser.SurnameMemberUser = member.Surname;
                                    cvUser.UploadDate = _matchServerDate.GetDateTimeByServer().ToString();
                                    cvUser.IsFromCandidate = false;
                                    cvUser.CompanyUserId = member.CompanyUserId;

                                    bool created = await _cvRepository.Add(cvUser);
                                }
                                else
                                {
                                    AttachedFile attachedFile = new AttachedFile();
                                    attachedFile.FileIdentifier = result;
                                    attachedFile.Name = form.Files[i].FileName;
                                    attachedFile.UploadDate = _matchServerDate.CreateServerDate();
                                    attachedFile.NameMemberUser = member.Name;
                                    attachedFile.SurnameMemberUser = member.Surname;
                                    attachedFile.EmailMemberUser = member.Email;
                                    attachedFile.CompanyUserId = member.CompanyUserId;
                                    attachedFile.FileTypeId = form.Types[i];
                                    attachedFile.CandidateId = form.CandidateId;
                                    attachedFile.OtherName = form.Others[i];
                                    if (attachedFile.FileTypeId == 9)
                                    {
                                        List<AttachedFile> filesDataTreatment = await _attachedFileRepository.GetAllFileDataTreatmentForCandidateId(form.CandidateId);
                                        if (filesDataTreatment != null && filesDataTreatment.Count > 0)
                                        {
                                            foreach (AttachedFile file in filesDataTreatment)
                                            {
                                                file.FileTypeId = 4;
                                                bool fileUpdate = await _attachedFileRepository.Update(file);
                                            }

                                        }
                                    }

                                    bool created = await _attachedFileRepository.AddByCandidate(attachedFile);

                                    if (created && attachedFile.FileTypeId == 9)
                                    {
                                        Candidate authorized = await _candidateRepository.GetByCandidateId(form.CandidateId);
                                        if (!authorized.isAuthorized)
                                        {
                                            authorized.isAuthorized = true;
                                            bool update = await _candidateRepository.Update(authorized);
                                        }

                                    }
                                }
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
            catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.InnerException });
            }
        }

        [HttpGet("candidateId/{candidateId}")]
        public async Task<IActionResult> GetAttachedFileByCandidateId(int candidateId)
        {
            bool candidateExists = _candidateRepository.CandidateExistById(candidateId);
            if (candidateExists)
            {
                List<AttachedFile> attachedFile = await _attachedFileRepository.GetUploadByCandidateByCandidateId(candidateId);

                if (attachedFile != null && attachedFile.Count() != 0)
                {
                    List<AttachedFileDTO> attachedFileDTO = _mapper.Map<List<AttachedFile>, List<AttachedFileDTO>>(attachedFile);
                    
                    return Ok(new { message = "Archivo consultado exitosamente", obj = attachedFileDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron archivos relacionados." });
                }
            }
            else
            {
                return StatusCode(404, new { message = "El candidato no existe." });
            }
        }
                      
        [HttpGet("{attachedFileId}")]
        public async Task<IActionResult> GetAttachedFileById(int attachedFileId)
        {
            try
            {
                AttachedFile attachedFile = await _attachedFileRepository.GetById(attachedFileId);

                if (attachedFile != null)
                {
                    AttachedFileDTO attachedFileDTO = _mapper.Map<AttachedFile, AttachedFileDTO>(attachedFile);

                    return Ok(new { message = "Archivo consultado exitosamente", obj = attachedFileDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró el archivo" });
                }
            }
            catch (ArgumentException e)
            {
                return BadRequest(e);
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
                List<AttachedFile> attachedFiles = new List<AttachedFile>();
                List<CV> CVs = new List<CV>();

                Candidate candidate = await _candidateRepository.GetById(candidateId);
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());
                if(isMaster)
                {
                    if (candidate != null && candidate.IsAuthDocuments)
                    {
                        attachedFiles = await _attachedFileRepository.GetByCandidateIdMaster(candidateId);
                        CVs = await _cVRepository.GetAllByCandidateIdMaster(candidateId);
                    }
                    else
                    {
                        attachedFiles = new List<AttachedFile>();
                        CVs = new List<CV>();
                    }
                }
                else
                {
                    string validation = "ViewSelectionFiles";

                    bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());

                    if (!isAuthorized)
                        return StatusCode(403, new { message = "No autorizado" });

                    
                    if(candidate != null && candidate.IsAuthDocuments)
                    {
                        attachedFiles = await _attachedFileRepository.GetByCandidateIdAndCompanyId(candidateId, companyUserId);
                        CVs = await _cVRepository.GetAllByCandidateIdAndCompanyUserId(candidateId, companyUserId);
                    }
                    else
                    {
                        attachedFiles = await _attachedFileRepository.GetByCandidateIdAndOnlyCompanyFiles(candidateId, companyUserId);
                        CVs = await _cVRepository.GetByCandidateIdAndOnlyCompanyFiles(candidateId, companyUserId);
                    }
                    
                }
                    

                
                List<Study> studyList = new List<Study>();
                if(candidate.IsAuthDocuments)
                    studyList = await _studyRepository.GetByCandidateId(candidateId);

                List<StudyCertificate> studyCertificates = new List<StudyCertificate>();
                if (studyList != null && studyList.Count > 0)
                {
                    foreach (Study study in studyList)
                    {
                        StudyCertificate certificate = await _studyCertificateRepository.GetByStudyId(study.StudyId);

                        if (certificate != null)
                        {
                            studyCertificates.Add(certificate);
                        }
                    }
                }

                if (attachedFiles.Count() == 0 && CVs.Count() == 0 && studyList.Count() == 0)
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
                        if (!string.IsNullOrEmpty(attachFile.NameMemberUser) && !string.IsNullOrEmpty(attachFile.SurnameMemberUser     ))
                        {
                            name = attachFile.NameMemberUser + " " + attachFile.SurnameMemberUser;
                            initials = attachFile.NameMemberUser[0].ToString().ToUpper() + attachFile.SurnameMemberUser[0].ToString().ToUpper();
                        }

                        memberDeleted = true;
                    }

                    string NameFile = "";
                    if (attachFile.FileTypeId == 4 && !string.IsNullOrEmpty(attachFile.OtherName))
                        NameFile = attachFile.OtherName;
                    else
                        NameFile = attachFile.FileType.Name;

                    FilesDTO file = new FilesDTO()
                    {
                        Id = attachFile.AttachedFileId,
                        CandidateId = attachFile.CandidateId,
                        Identifier = attachFile.FileIdentifier,
                        Name = attachFile.Name,
                        IdentifierLink = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + attachFile.FileIdentifier,
                        FileTypeId = attachFile.FileTypeId,
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
                        MemberDeleted = memberDeleted
                    };

                    if (file.FileTypeId == 6)
                    {
                        file.Initials = "MI";
                        file.NameMember = "Migrado";
                    }

                    if (file.FileTypeId == 7)
                        filesPortal.Add(file);
                    else
                        filesCompany.Add(file);
                }

                foreach (CV cv in CVs)
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
                        Id = cv.CVId,
                        CandidateId = cv.CandidateId,
                        Identifier = cv.CvIdentifier,
                        IdentifierLink = cv.CvIdentifierLink,
                        Name = cv.Name,
                        FileTypeId = cv.FileTypeId,
                        FileType = cv.FileType.Name,
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

                    if (file.FileTypeId == 6)
                    {
                        file.Initials = "MI";
                        file.NameMember = "Migrado";
                    }

                    if (file.FileTypeId == 5)
                        filesPortal.Add(file);
                    else
                        filesCompany.Add(file);
                }               

                studyCertificates.ForEach(x => {

                    FilesDTO file = new FilesDTO()
                    {
                        Id = x.Id,
                        CandidateId = candidateId,
                        Identifier = x.CertificateIdentifier,
                        IdentifierLink = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + x.CertificateIdentifier,
                        Name = x.Name,
                        FileTypeId = 7,
                        FileType = "Archivo subido por candidato",
                        uploadDate = _uploadTimeService.GetPublicationInfo(x.UploadDate),
                        uploadDateEnglish = _uploadTimeService.GetPublicationInfoEnglish(x.UploadDate),
                        uploaderName = "",
                        CreationInfoPup = _uploadTimeService.GetFileTypeCreationInfoPup(x.UploadDate),
                        CreationInfoPupEnglish = _uploadTimeService.GetFileTypeCreationInfoPupEnglish(x.UploadDate),
                        CreationShortInfo = _uploadTimeService.GetFileTypeCreationShortInfo(x.UploadDate)
                    };

                    if (file.FileTypeId == 6)
                    {
                        file.Initials = "MI";
                        file.NameMember = "Migrado";
                    }

                    filesPortal.Add(file);
                });

                CandidateFilesDTO returnLists = new CandidateFilesDTO()
                {
                    PortalFiles = filesPortal,
                    CompanyFiles = filesCompany
                };

                return Ok(new { message = "Archivos consultados exitosamente", obj = returnLists });
            }
            catch(Exception ex)
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
                List<AttachedFile> attachedFiles = await _attachedFileRepository.GetUploadByCandidateByCandidateId(candidateId);
                List<CV> CVs = await _cVRepository.GetUploadByCandidateByCandidateId(candidateId);

                List<Study> studyList = new List<Study>();
                studyList = await _studyRepository.GetByCandidateId(candidateId);

                List<StudyCertificate> studyCertificates = new List<StudyCertificate>();
                if (studyList != null && studyList.Count > 0)
                {
                    foreach (Study study in studyList)
                    {
                        StudyCertificate certificate = await _studyCertificateRepository.GetByStudyId(study.StudyId);

                        if (certificate != null)
                        {
                            studyCertificates.Add(certificate);
                        }
                    }
                }

                if (attachedFiles.Count() == 0 && CVs.Count() == 0 && studyList.Count() == 0)
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

                    string NameFile = "";
                    if (attachFile.FileTypeId == 4 && !string.IsNullOrEmpty(attachFile.OtherName))
                        NameFile = attachFile.OtherName;
                    else
                        NameFile = attachFile.FileType.Name;

                    FilesDTO file = new FilesDTO()
                    {
                        Id = attachFile.AttachedFileId,
                        CandidateId = attachFile.CandidateId,
                        Identifier = attachFile.FileIdentifier,
                        Name = attachFile.Name,
                        IdentifierLink = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + attachFile.FileIdentifier,
                        FileTypeId = attachFile.FileTypeId,
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
                        Id = cv.CVId,
                        CandidateId = cv.CandidateId,
                        Identifier = cv.CvIdentifier,
                        IdentifierLink = cv.CvIdentifierLink,
                        Name = cv.Name,
                        FileTypeId = cv.FileTypeId,
                        FileType = cv.FileType.Name,
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

                studyCertificates.ForEach(x => {

                    FilesDTO file = new FilesDTO()
                    {
                        Id = x.Id,
                        CandidateId = candidateId,
                        Identifier = x.CertificateIdentifier,
                        IdentifierLink = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + x.CertificateIdentifier,
                        Name = x.Name,
                        FileTypeId = 7,
                        FileType = "Archivo subido por candidato",
                        uploadDate = _uploadTimeService.GetPublicationInfo(x.UploadDate),
                        uploadDateEnglish = _uploadTimeService.GetPublicationInfoEnglish(x.UploadDate),
                        uploaderName = "",
                        CreationInfoPup = _uploadTimeService.GetFileTypeCreationInfoPup(x.UploadDate),
                        CreationInfoPupEnglish = _uploadTimeService.GetFileTypeCreationInfoPupEnglish(x.UploadDate),
                        CreationShortInfo = _uploadTimeService.GetFileTypeCreationShortInfo(x.UploadDate)
                    };

                    if (file.FileTypeId == 6)
                    {
                        file.Initials = "MI";
                        file.NameMember = "Migrado";
                    }

                    filesPortal.Add(file);
                });

               
                return Ok(new { message = "Archivos consultados exitosamente", obj = filesPortal });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
            //catch (ArgumentException e) { return BadRequest(e); }
        }

        [HttpGet("getIsAuthDocuments/{candidateId}")]
        public async Task<IActionResult> GetIsAuthDocuments(int candidateId)
        {
            Candidate candidate = await _candidateRepository.GetById(candidateId);

            if(candidate == null)
                return NotFound(new { message = "El candidato no existe" });

            return StatusCode(200, new { message = "Consultado exitosamente", obj = candidate.IsAuthDocuments });
        }

        [HttpGet("editIsAuthDocuments/{candidateId}")]
        public async Task<IActionResult> EditIsAuthDocuments(int candidateId)
        {
            Candidate candidate = await _candidateRepository.GetById(candidateId);

            if (candidate == null)
                return NotFound(new { message = "El candidato no existe" });

            candidate.IsAuthDocuments = !candidate.IsAuthDocuments;

            bool isEdited = await _candidateRepository.Update(candidate);

            if(!isEdited)
                return StatusCode(400, new { message = "No se pudo editar el candidato" });

            return StatusCode(200, new { message = "Editado exitosamente", obj = candidate });
        }

        [HttpGet("getDocumentsUploadedByCandidate/{candidateId}")]
        public async Task<IActionResult> GetOwnDocuments(int candidateId)
        {
            Candidate candidate = await _candidateRepository.GetById(candidateId);

            if (candidate == null)
                return NotFound(new { message = "El candidato no existe" });

            List<AttachedFile> files = await _attachedFileRepository.GetByFileTypeAndCandidateId(candidateId, 7);

            if(files == null || files.Count == 0)
                files = new List<AttachedFile>();

            return StatusCode(200, new { message = "Archivos consultados exitosamente", obj = files });
        }

        [HttpGet("download/{attachedFileId}")]
        public async Task<FileResult> GetFileDownloadByCandidateId(int attachedFileId)
        {
            byte[] byteArr;
            AttachedFile file = await _attachedFileRepository.GetById(attachedFileId);
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

        [HttpGet("FileType/{fileTypeId}")]
        public async Task<IActionResult> GetAttachedFilesByFileTypeId(int fileTypeId)
        {
            try
            {
                List<AttachedFile> attachedFiles = await _attachedFileRepository.GetByFileTypeId(fileTypeId);

                if (attachedFiles != null && attachedFiles.Count() != 0)
                {
                    List<AttachedFileDTO> attachedFilesDTO = _mapper.Map<List<AttachedFile>, List<AttachedFileDTO>>(attachedFiles);

                    return Ok(new { message = "Archivos consultados exitosamente", obj = attachedFilesDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron archivos relacionados." });
                }
            }
            catch (ArgumentException e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("FileTypeAndCandidateId/{candidateId}/{fileTypeId}")]
        public async Task<IActionResult> GetAttachedFilesByFileTypeAndCandidateId(int fileTypeId, int candidateId)
        {
            try
            {
                bool candidateExists = _candidateRepository.CandidateExistById(candidateId);
                if (candidateExists)
                {
                    List<AttachedFile> attachedFiles = await _attachedFileRepository.GetByFileTypeAndCandidateId(candidateId, fileTypeId);

                    if (attachedFiles != null && attachedFiles.Count() != 0)
                    {
                        List<AttachedFileDTO> attachedFilesDTO = _mapper.Map<List<AttachedFile>, List<AttachedFileDTO>>(attachedFiles);

                        return Ok(new { message = "Archivos consultados exitosamente", obj = attachedFilesDTO });
                    }
                    else
                    {
                        return NotFound(new { message = "No se encontraron archivos relacionados." });
                    }
                }
                else
                {
                    return NotFound(new { message = "El candidato no existe." });
                }
            }
            catch (ArgumentException e)
            {
                return BadRequest(e);
            }
        }

        [HttpDelete("{attachedFileId}")]
        public async Task<IActionResult> RemoveAttachedFileById(int attachedFileId)
        {
            try
            {
                var removed = await _attachedFileRepository.Remove(attachedFileId);

                if (removed != null)
                {
                    return StatusCode(200, new { message = "Eliminado exitosamente" });
                }
                else
                {
                    return StatusCode(404, new { message = "El documento no existe" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("deletefile/{fileId}/{fileType}")]
        public async Task<IActionResult> RemoveFilesById(int fileId, int fileType)
        {
            try
            {
                if (fileType == 5 || fileType == 6 || fileType == 8)
                {
                    var removed = await _cVRepository.Remove(fileId);
                    if (removed != null)
                    {
                        return StatusCode(200, new { message = "Eliminado exitosamente" });
                    }
                    else
                    {
                        return StatusCode(404, new { message = "El documento no existe" });
                    }
                }
                else
                {
                    AttachedFile removed = await _attachedFileRepository.Remove(fileId);
                    if (removed.FileTypeId == 9)
                    {
                        Candidate authorized = await _candidateRepository.GetByCandidateId(removed.CandidateId);
                        
                        if (authorized.IsMigrated != 0 && !authorized.IsFromCompanyAndLogin)
                        {
                            authorized.isAuthorized = false;
                            bool update = await _candidateRepository.Update(authorized);
                        }

                    }
                    if (removed != null)
                    {
                        return StatusCode(200, new { message = "Eliminado exitosamente" });
                    }
                    else
                    {
                        return StatusCode(404, new { message = "El documento no existe" });
                    }
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("GetFile/downloadbyFileId/{fileId}/{fileTypeId}")]
        public async Task<ActionResult> GetFileDownloadByCvId(int fileId, int fileTypeId)
        {
            try
            {
                string identifier;
                string name;
                byte[] byteArr;
                CV cvFile = new CV() { };
                AttachedFile attachedFile = new AttachedFile() { };
                StudyCertificate studyCertificate = new StudyCertificate() { };

                cvFile = await _cVRepository.GetById(fileId);
                studyCertificate = await _studyCertificateRepository.GetById(fileId);
                attachedFile = await _attachedFileRepository.GetById(fileId);

                if (cvFile == null && attachedFile == null && studyCertificate == null)
                    return StatusCode(404, new { message = "El documento no existe" });
                else
                {
                    if (cvFile != null && cvFile.CvIdentifier != null && (fileTypeId == 5 || fileTypeId == 6 || fileTypeId == 8))
                    {
                        identifier = cvFile.CvIdentifier;
                        name = cvFile.Name;
                    }
                    else if (attachedFile != null && attachedFile.FileIdentifier != null)
                    {
                        identifier = attachedFile.FileIdentifier;
                        name = attachedFile.Name;
                    }
                    else if (studyCertificate != null && studyCertificate.CertificateIdentifier != null)
                    {
                        identifier = studyCertificate.CertificateIdentifier;
                        name = studyCertificate.Name;
                    }
                    else
                    {
                        identifier = "";
                        name = "";
                    }
                }

                WebClient client = new WebClient();
                System.Uri uri = new System.Uri("https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + identifier);
                //Stream stream = await client.OpenReadTaskAsync(uri);
                Stream stream = await _AWSS3FileService.GetFile(identifier);

                using (var memoryStream = new MemoryStream())
                {
                    stream.Position = 0;
                    stream.CopyTo(memoryStream);
                    byteArr = memoryStream.ToArray();
                }
               
                var newCVName = name.Trim();
                newCVName = newCVName.Replace("\"", "");
                newCVName = newCVName.Replace(" ", "-");
                newCVName = newCVName.Replace("(", "");
                newCVName = newCVName.Replace(")", "");

                newCVName = Regex.Replace(newCVName, @"[^\u0000-\u007F]+", string.Empty);

                var result = File(byteArr, "application/octet-stream", newCVName);
                Response.Headers["Content-Disposition"] = newCVName;

                //AddHeader("Content-Disposition",string.Format("inline; filename={0}", cv.Name));

                //object p = Response.Headers("Content-Disposition", string.Format("inline; filename={0}", cv.Name));
                return result;
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("migrateStudyCertificatesToAttachedFiles")]
        public async Task<ActionResult> MigrateStudyCertificatesToAttachedFiles()
        {
            List<StudyCertificate> studyCertificates = await _studyCertificateRepository.GetAll();

            if(studyCertificates != null && studyCertificates.Count > 0)
            {
                foreach(StudyCertificate studyCertificate in studyCertificates)
                {
                    string studyCertificateIdentifier = studyCertificate.CertificateIdentifier.Replace("StudyCertificates/", "");

                    await _AWSS3FileService.CopyToOtherFolderS3(_settings.AWSS3.BucketName, _settings.AWSS3.BucketName,
                        "StudyCertificates", "AttachedFiles", studyCertificateIdentifier);

                    Study study = await _studyRepository.GetById(studyCertificate.StudyId);

                    if (study == null)
                        study = new Study();

                    Candidate candidate = await _candidateRepository.GetByCandidateId(study.CandidateId);

                    if (candidate == null)
                        candidate = new Candidate();

                    string fileIdentifier = studyCertificate.CertificateIdentifier.Replace("StudyCertificates", "AttachedFiles");

                    AttachedFile attachedFile = new AttachedFile
                    {
                        CandidateId = study.CandidateId,
                        Name = studyCertificate.Name,
                        FileIdentifier = fileIdentifier,
                        FileTypeId = 7,
                        UploadDate = studyCertificate.UploadDate,
                        EmailMemberUser = null,
                        NameMemberUser = null,
                        SurnameMemberUser = null,
                        CompanyUserId = candidate.CompanyUserId,
                        OtherName = null
                    };

                    await _attachedFileRepository.Add(attachedFile);
                }
            }

            return StatusCode(200, new { message = "Migrados exitosamente" });
        }

        [HttpPatch("migrateattachedFilesToCVs")]
        public async Task<ActionResult> MigrateattachedFilesToCVs()
        {
            try
            {
                List<AttachedFile> attachedFiles = await _attachedFileRepository.GetByFileTypeId(8);

                if (attachedFiles != null && attachedFiles.Count > 0)
                {
                    foreach (AttachedFile attachedFile in attachedFiles)
                    {
                        string fileName = attachedFile.FileIdentifier.Replace("AttachedFiles/", "");

                        await _AWSS3FileService.CopyToOtherFolderS3(_settings.AWSS3.BucketName, _settings.AWSS3.BucketName,
                        "AttachedFiles", "CV", fileName);

                        CV cv = new CV
                        {
                            CandidateId = attachedFile.CandidateId,
                            CompanyUserId = attachedFile.CompanyUserId,

                            EmailMemberUser = attachedFile.EmailMemberUser,
                            NameMemberUser = attachedFile.NameMemberUser,
                            SurnameMemberUser = attachedFile.SurnameMemberUser,

                            CvIdentifier = "CV/" + fileName,
                            CvIdentifierLink = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/CV/" + fileName,

                            FileTypeId = attachedFile.FileTypeId,

                            CVGuid = Convert.ToString(Guid.NewGuid()),

                            UploadDate = attachedFile.UploadDate,

                            OverViewCv = false,

                            Name = fileName
                        };

                        await _attachedFileRepository.Remove(attachedFile.AttachedFileId);

                        bool isCreated = await _cvRepository.Add(cv);
                    }
                }

                return StatusCode(200, new { message = "Migrados exitosamente" });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
