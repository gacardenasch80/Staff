using AutoMapper;
using CandidatesMS.Helpers;
using CandidatesMS.KeyVault.SecretsModels;
using CandidatesMS.Models;
using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.ModelsCompany;
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
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CandidatesMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CVController : ControllerBase
    {
        private IAWSS3FileService _AWSS3FileService;
        private IMemberUserService _memberUserService;
        private readonly Services.IValidateMethodsService _validateMethodsService;

        private ICVRepository _cvRepository;
        private ICandidateRepository _candidateRepository;
        private IMemberUserRepository _memberUserRepository;

        private ICompanyRemoteRepository _companyRemoteRepository;

        private IAuthorizationHelper _authorizationHelper;

        private IMatchServerDate _matchServerDate;
        private ICvGenerator _cvGenerator;

        private IMapper _mapper;

        private ServiceConfigurationDTO _settings;

        public CVController
        (
                            ICVRepository cvRepository,
                            ICandidateRepository candidateRepository,
                            IMemberUserRepository memberUserRepository,

                            IAuthorizationHelper authorizationHelper,

                            ICompanyRemoteRepository companyRemoteRepository,

                            IAWSS3FileService AWSS3FileService,
                            IMatchServerDate matchServerDate,
                            ICvGenerator cvGenerator,
                            IMemberUserService memberUserService,
                            Services.IValidateMethodsService validateMethodsService,

                            IMapper mapper,

                            IOptions<ServiceConfigurationDTO> settings
        )
        {
            _cvRepository = cvRepository;
            _candidateRepository = candidateRepository;
            _memberUserRepository = memberUserRepository;

            _companyRemoteRepository = companyRemoteRepository;

            _mapper = mapper;

            _AWSS3FileService = AWSS3FileService;
            _memberUserService = memberUserService;
            _validateMethodsService = validateMethodsService;

            _authorizationHelper = authorizationHelper;
            _matchServerDate = matchServerDate;
            _cvGenerator = cvGenerator;

            _settings = settings.Value;
        }

        [HttpPost("uploadFile")]
        public async Task<IActionResult> UploadFileAsync([FromForm] CVDTO req)
        {
            bool candidateExists = _candidateRepository.CandidateExistById(req.CandidateId);
            
            if (candidateExists)
            {
                var result = await _AWSS3FileService.UploadCVFile(req.FormFile, "CV");
                if (result == null)
                    return BadRequest(result);

                var cvExist = await _cvRepository.ExsistOverViewCvByCandidateId(req.CandidateId); 
                
                CV cvUser = _mapper.Map<CVDTO, CV>(req);
                cvUser.CVGuid = Convert.ToString(Guid.NewGuid());
                cvUser.CvIdentifier = result[0];
                cvUser.CvIdentifierLink = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + result[0];
                if (result.Count == 2)
                    cvUser.CvIdentifierLink = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + result[1];
                if (cvExist == null)
                    cvUser.OverViewCv = true;
                else
                    cvUser.OverViewCv = false;
                cvUser.Name = req.FormFile.FileName;
                cvUser.FileTypeId = 5;
                cvUser.UploadDate = _matchServerDate.GetDateTimeByServer().ToString();
                cvUser.IsFromCandidate = true;

                try
                {
                    bool created = await _cvRepository.Add(cvUser);

                    if (created)
                        return Created("", new { message = "Almacenado exitosamente", filename = cvUser.Name });
                    else
                        return BadRequest(new { message = "El documento no fue almacenado" });
                }
                catch (Exception ex)
                {
                    return StatusCode(500, new { message = ex.Message });
                }
            }
            else
            {
                return StatusCode(404, new { message = "El candidato no existe." });
            }
        }

        [HttpPost("uploadFileByCompany")]
        public async Task<IActionResult> UploadFileByCompanyAsync([FromForm] CVDTO cvDTO)
        {
            StringValues values = "";
            Request.Headers.TryGetValue("Authorization", out values);

            string validation = "UploadCVFile";

            bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
            bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

            if (!isMaster && !isAuthorized)
                return StatusCode(403, new { message = "No autorizado" });

            var email = "";
            var name = "";
            var surname = "";

            var member = await _companyRemoteRepository.GetMemberUserFromCandidate(values.ToString());

            if (member != null)
            {
                email = member.email;
                name = member.name;
                surname = member.surname;
            }

            bool candidateExists = _candidateRepository.CandidateExistById(cvDTO.CandidateId);

            if (!candidateExists)
                return StatusCode(404, new { message = "El candidato no existe." });

            var result = await _AWSS3FileService.UploadCVFile(cvDTO.FormFile, "CV");

            if (result == null)
                BadRequest(new { message = "El documento no fue almacenado" });

            CV cvUser = _mapper.Map<CVDTO, CV>(cvDTO);

            cvUser.CVGuid = Convert.ToString(Guid.NewGuid());
            cvUser.CvIdentifier = result[0];
            cvUser.CvIdentifierLink = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + result[0];
            cvUser.IsFromCandidate = false;

            if (result.Count == 2)
                cvUser.CvIdentifierLink = "https://recruitment-bucket.s3.amazonaws.com/" + result[1];

            await _cvRepository.DeleteOverViewCv(cvDTO.CandidateId);
            cvUser.OverViewCv = true;

            string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
            MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

            cvUser.Name = cvDTO.FormFile.FileName;
            cvUser.FileTypeId = 8;
            cvUser.EmailMemberUser = email;
            cvUser.NameMemberUser = name;
            cvUser.SurnameMemberUser = surname;
            cvUser.IsFromCandidate = false;
            cvUser.UploadDate = _matchServerDate.GetDateTimeByServer().ToString();

            if (memberUser != null)
                cvUser.CompanyUserId = memberUser.CompanyUserId;

            try
            {
                bool isDeleted = await _cvRepository.DeleteAllOverViewCvByCvId(cvDTO.CandidateId, cvUser.CompanyUserId);

                bool created = await _cvRepository.Add(cvUser);

                if (created)
                    return Created("", new { message = "Almacenado exitosamente", filename = cvUser.Name });
                else
                    return BadRequest(new { message = "El documento no fue almacenado" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("deleteOverViewCv/{cvId}")]
        public async Task<IActionResult> DeleteOverViewCv(int cvId)
        {
            StringValues token = "";
            Request.Headers.TryGetValue("Authorization", out token);

            MemberUserDTO memberResponse = await _memberUserService.GetMemberUserFromCandidate(token);

            int companyUserId = 0;

            if (memberResponse != null)
                companyUserId = memberResponse.CompanyUserId;

            /**/

            string validation = "DeleteCVFile";

            bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, token.ToString());
            bool isMaster = await _companyRemoteRepository.isMaster(token.ToString());

            if (!isMaster && !isAuthorized)
                return StatusCode(403, new { message = "No autorizado" });


            var cv = await _cvRepository.DeleteOverViewCvByCvId(companyUserId, cvId);

            if (cv != null)
                return Created("", new { message = "Eliminado exitosamente" });
            else
                return BadRequest(new { message = "El documento no fue eliminado" });
        }

        [HttpGet]
        public async Task<ObjectResult> GetAllPersonalReferences()
        {
            List<CV> cv = await _cvRepository.GetAll();
            List<CVDTO> cvDto = _mapper.Map<List<CV>, List<CVDTO>>(cv);

            return StatusCode(200, cvDto);
        }

        [HttpGet("GetFile/{candidateId}")]
        public async Task<IActionResult> GetFileByCandidateId(int candidateId)
        {
            bool candidateExists = _candidateRepository.CandidateExistById(candidateId);
            if (candidateExists)
            {
                CV cv = await _cvRepository.GetByCandidateIdToCandidate(candidateId);

                if (cv != null)
                {
                    CVDTO CVDTO = _mapper.Map<CV, CVDTO>(cv);
                    return Ok(new { message = "Archivo consultado exitosamente", obj = CVDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró el archivo." });
                }
            }
            else
            {
                return StatusCode(404, new { message = "El candidato no existe." });
            }
        }

        [HttpGet("GetOverViewCv/{candidateId}")]
        public async Task<IActionResult> GetOverViewCvByCandidateId(int candidateId)
        {
            StringValues token = "";
            Request.Headers.TryGetValue("Authorization", out token);

            MemberUserDTO memberResponse = await _memberUserService.GetMemberUserFromCandidate(token);

            int companyUserId = 0;

            if (memberResponse != null)
                companyUserId = memberResponse.CompanyUserId;

            /**/

            bool candidateExists = _candidateRepository.CandidateExistById(candidateId);

            if (!candidateExists)
                return StatusCode(404, new { message = "El candidato no existe." });

            CV cv = await _cvRepository.ExsistOverViewCvByCandidateAndCompanyId(candidateId, companyUserId);

            if(cv == null || string.IsNullOrEmpty(cv.CvIdentifierLink))
                cv = await _cvRepository.ExsistOverViewCvByCandidateId(candidateId);

            if (cv == null)
                return NotFound(new { message = "No se encontró el archivo." });
            
            CVDTO CVDTO = _mapper.Map<CV, CVDTO>(cv);

            return Ok(new { message = "Archivo consultado exitosamente", obj = CVDTO });                        
        }

        [HttpGet("GetFile/download/{candidateId}")]
        public async Task<FileResult> GetFileDownloadByCandidateId(int candidateId)
        {
            StringValues token = "";
            Request.Headers.TryGetValue("Authorization", out token);

            MemberUserDTO memberResponse = await _memberUserService.GetMemberUserFromCandidate(token);

            int companyUserId = 0;

            if (memberResponse != null)
                companyUserId = memberResponse.CompanyUserId;

            /**/

            byte[] byteArr;

            bool candidateExists = _candidateRepository.CandidateExistById(candidateId);

            if (!candidateExists)
                return null;
            
            CV cv = await _cvRepository.ExsistOverViewCvByCandidateId(candidateId);

            if (cv == null)
                cv = await _cvRepository.ExsistOverViewCvByCandidateAndCompanyId(candidateId, companyUserId);

            if (cv == null)
                return null;

            try
            {
                WebClient client = new();

                Uri uri = new("https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + cv.CvIdentifier);
                //Stream stream = await client.OpenReadTaskAsync(uri);

                Stream stream = await _AWSS3FileService.GetFile(cv.CvIdentifier);

                using (MemoryStream memoryStream = new())
                {
                    stream.Position = 0;
                    stream.CopyTo(memoryStream);
                    byteArr = memoryStream.ToArray();
                }

                FileContentResult result = File(byteArr, "application/octet-stream");

                result.FileDownloadName = Regex.Replace(cv.Name, @"[^0-9a-zA-Z.]+", "");

                if (result.FileDownloadName.Count() >= 5 && (result.FileDownloadName[result.FileDownloadName.Count() - 5] != '.' && result.FileDownloadName[result.FileDownloadName.Count() - 4] != '.' ))
                {
                    result.FileDownloadName += ".pdf";
                }

                return result;
            }
            catch(Exception)
            {
                return null;
            }
        }

        [HttpGet("GetFile/downloadbyCvId/{cvId}")]
        public async Task<ActionResult> GetFileDownloadByCvId(int cvId)
        {
            byte[] byteArr;

            CV cv = await _cvRepository.GetById(cvId);
            if (cv == null)
                return null;

            WebClient client = new WebClient();
            
            System.Uri uri = new System.Uri("https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + cv.CvIdentifier);
            //Stream stream = await client.OpenReadTaskAsync(uri);
            Stream stream = await _AWSS3FileService.GetFile(cv.CvIdentifier);

            using (var memoryStream = new MemoryStream())
            {
                stream.Position = 0;
                stream.CopyTo(memoryStream);
                byteArr = memoryStream.ToArray();
            }
            var result = File(byteArr, "application/octet-stream");
            result.FileDownloadName = Regex.Replace(cv.Name, @"[^0-9a-zA-Z.]+", "");
            return result;
        }

        [HttpDelete("{cvId}")]
        public async Task<IActionResult> RemoveCvById(int cvId)
        {
            try
            {
                var removed = await _cvRepository.Remove(cvId);
                var del = _AWSS3FileService.DeleteFile(removed.CvIdentifier);

                if (removed != null)
                {
                    return StatusCode(200, new { message = "Eliminado exitosamente" });
                }
                else
                {
                    return StatusCode(404, new { message = "La hoja de vida no existe" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("ChangeUploadDate")]
        public async Task<ActionResult> ChangeUploadDate()
        {
            List<CV> cvs = await _cvRepository.GetAll();
            if (cvs == null || cvs.Count == 0)
                return StatusCode(500, new { message = "Error" }); ;

            foreach(CV cv in cvs)
            {
                //DateTime dateTime;

                ////if (DateTime.TryParseExact(cv.UploadDate, "dd/MM/yyyy hh:mm:ss tt", new CultureInfo("es-ES"), DateTimeStyles.None, out dateTime))
                ////if (DateTime.TryParse(cv.UploadDate, out dateTime))
                ////if(DateTime.TryParse(cv.UploadDate, new CultureInfo("es-CO"), DateTimeStyles.None, out dateTime))
                //{


                //    cv.UploadDate = dateTime.ToString("MM/dd/yyyy hh:mm:ss");
                //}

                await _cvRepository.Update(cv);
            }

            return StatusCode(200, new { message = "Cambiados exitosamente", obj = cvs });
        }

        [HttpGet("downloadCVWithTemplate/{candidateId}/{cvType}/{fileType}/{language}")]
        public async Task<ActionResult> DownloadCvWithTemplateByCandidateId(int candidateId, int cvType, int fileType, int language)
        {
            /* cvType */
            // 1 = Without contact.
            // 2 = With contact.

            /* fileType */
            // 1 = PDF.
            // 2 = HTML.

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

                Dictionary<string, dynamic> resultObject = await _cvGenerator.GetDocFileDownloadByCompany(candidateId, memberUser.companyUserId, cvType, fileType, isMaster);

                FileContentResult result = null;

                if (fileType == 1)
                {
                    MemoryStream ms = resultObject["memoryStream"];

                    result = new FileContentResult(ms.ToArray(), "application/pdf")
                    {
                        FileDownloadName = Regex.Replace(resultObject["name"], @"[^0-9a-zA-Z.]+", "")
                    };
                }
                else if(fileType == 2)
                {
                    MemoryStream ms = resultObject["memoryStream"];

                    result = new FileContentResult(ms.ToArray(), "text/html")
                    {
                        FileDownloadName = Regex.Replace(resultObject["name"], @"[^0-9a-zA-Z.]+", "")
                    };
                }

                return result;
            }
            catch (Exception ex)
            {
                string innerException = string.Empty;

                if (ex != null && ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                {
                    innerException = ex.InnerException.Message;
                }

                return StatusCode(500, new { message = $"{ex.Message}, {innerException}, {ex.StackTrace}" });
            }
        }
    }
}
