using AutoMapper;
using CandidatesMS.Helpers;
using CandidatesMS.Models;
using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using CandidatesMS.Repositories.RemoteRepositories;
using CandidatesMS.RepositoriesCompany;
using CandidatesMS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using S3bucketDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Controllers
{
    [ApiController]
    [Route("api/study")]
    public class StudyController : ControllerBase
    {
        private readonly IAWSS3FileService _AWSS3FileService;
        private readonly ICompanyRemoteRepository _companyRemoteRepository;
        private readonly IStudyRepository _studyRepository;
        private readonly ICandidateRepository _candidateRepository;
        private readonly IStudyCertificateRepository _studyCertificateRepository;

        private readonly IMemberUserRepository _memberUserRepository;

        private readonly IStudyService _studyService;
        private readonly Services.IValidateMethodsService _validateMethodsService;

        private readonly IAuthorizationHelper _authorizationHelper;

        private readonly IMapper _mapper;
        private IMatchServerDate _matchServerDate;

        public StudyController(IAWSS3FileService aWSS3FileService, IStudyRepository studyRepository, IMapper mapper, 
                               ICompanyRemoteRepository companyRemoteRepository, ICandidateRepository candidateRepository, 
                               IStudyCertificateRepository studyCertificateRepository, IMemberUserRepository memberUserRepository,
                               IStudyService studyService, IAuthorizationHelper authorizationHelper,

            Services.IValidateMethodsService validateMethodsService,
        IMatchServerDate matchServerDate)
        {
            _AWSS3FileService = aWSS3FileService;
            _companyRemoteRepository = companyRemoteRepository;
            _studyRepository = studyRepository;
            _candidateRepository = candidateRepository;
            _studyCertificateRepository = studyCertificateRepository;
            _memberUserRepository = memberUserRepository;

            _studyService = studyService;
            _mapper = mapper;

            _matchServerDate = matchServerDate;
            _authorizationHelper = authorizationHelper;

            _validateMethodsService = validateMethodsService;
        }

        [HttpGet()]
        public async Task<ObjectResult> GetStudies()
        {
            try
            {
                List<Study> studiesFromRepo = await _studyRepository.GetAll();
                List<StudyDTO> studyDTO = _mapper.Map<List<Study>, List<StudyDTO>>(studiesFromRepo);

                return Ok(new { message = "Estudios consultados exitosamente", obj = studyDTO });
            }
            catch(ArgumentException e )
            {
                return BadRequest(e);
            }
        }

        [HttpGet("{studyId}")]
        public async Task<ObjectResult> GetStudiesById(int studyId)
        {
            StringValues values = "";
            Request.Headers.TryGetValue("Authorization", out values);
            try
            {
                Study studyFromRepo = await _studyRepository.GetById(studyId);
                JobProfessionRemoteDTO jobProfession = await _companyRemoteRepository.GetJobProfessionById(
                                   studyFromRepo.JobProfessionId, values.ToString());
                

                if (studyFromRepo != null)
                {
                    StudyDTO studyDTO = _mapper.Map<Study, StudyDTO>(studyFromRepo);
                    if (jobProfession != null)
                    {
                        studyDTO.JobProfession = jobProfession.Profession;
                        studyDTO.JobProfessionEnglish = jobProfession.ProfessionEnglish;
                    }

                    return Ok(new { message = "Estudios consultados exitosamente", obj = studyDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró el estudio" });
                }
            }
            catch (ArgumentException e)
            {
                return BadRequest(e);
            }            
        }

        [HttpGet("adminView/byCandidateId/{candidateId}")]
        public async Task<ObjectResult> GetStudiesByCandidateIdAdminView(int candidateId)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                bool candidateExists = _candidateRepository.CandidateExistById(candidateId);

                if (!candidateExists)
                    return StatusCode(404, new { message = "El candidato no existe." });

                Candidate candidate = await _candidateRepository.GetByCandidateId(candidateId);

                List<MemberByToken> memberUser = await _companyRemoteRepository.GetAllMemberUserByToken(values);

                if (memberUser == null && memberUser.Count > 0)
                    return StatusCode(404, new { message = "El usuario empresa no existe." });

                List<StudyDTO> studies = await _studyService.GetStudiesCandidateOrderByDate(candidateId, false, values, memberUser[0].companyUserId);

                if (studies.Count == 0)
                    return StatusCode(404, new { message = "El candidato no registra estudios actualmente" });
                else
                    return Ok(new { message = "Estudios consultados exitosamente", obj = studies });
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("byCandidateId/{candidateId}")]
        public async Task<ObjectResult> GetStudiesByCandidateId(int candidateId)
        {
            StringValues values = "";
            Request.Headers.TryGetValue("Authorization", out values);
            bool candidateExists = _candidateRepository.CandidateExistById(candidateId);
            if (!candidateExists)
                return StatusCode(404, new { message = "El candidato no existe." });

            var studies = await _studyService.GetStudiesCandidateOrderByDate(candidateId, true, values);

            if (studies.Count == 0)
                return StatusCode(404, new { message = "El candidato no registra estudios actualmente" });
            else
                return Ok(new { message = "Estudios consultados exitosamente", obj = studies });
        }

        [HttpPatch("{isFromCandidateFlag}")]
        public async Task<IActionResult> EditStudy([FromForm] StudyDTO StudyDTO, int isFromCandidateFlag)
        {
            /* MODIFICAR MÉTODO DESPUÉS DE TERMINAR EL MULTIEMPRESA */

            StringValues values = "";
            Request.Headers.TryGetValue("Authorization", out values);

            string validation = "EditOtherInfo";

            bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
            bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

            bool isFromCandidate = false;

            if (isFromCandidateFlag == 1)
                isFromCandidate = true;

            if (!isMaster && !isAuthorized && !isFromCandidate)
                return StatusCode(403, new { message = "No autorizado" });

            bool candidateExists = _candidateRepository.CandidateExistById(StudyDTO.CandidateId);
            if (!candidateExists)
                return StatusCode(404, new { message = "El candidato no existe." });

            string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
            MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

            try
            {
                Study Study = _mapper.Map<StudyDTO, Study>(StudyDTO);
                Study.IsFromCandidate = isFromCandidate;

                if(!Study.IsFromCandidate)
                {
                    Study.CompanyUserId = memberUser.CompanyUserId;
                }

                var studyCertificate = await _studyCertificateRepository.GetByStudyId(StudyDTO.StudyId);

                if (StudyDTO.CertificateName == null)
                {
                    if (StudyDTO.FormFile == null)
                    {
                        if (studyCertificate != null)
                            await _studyCertificateRepository.Remove(studyCertificate.Id);
                    }
                    else
                    {
                        if (studyCertificate != null)
                        {
                            if (studyCertificate.Name != StudyDTO.FormFile.FileName)
                            {
                                await _studyCertificateRepository.Remove(studyCertificate.Id);
                                var result = await _AWSS3FileService.UploadFile(StudyDTO.FormFile, "StudyCertificates");
                                var dateServer = _matchServerDate.GetDateTimeByServer().ToString();

                                StudyCertificate studyCertNew = new StudyCertificate
                                {
                                    CertificateIdentifier = result,
                                    Name = StudyDTO.FormFile.FileName,
                                    StudyId = Study.StudyId,
                                    UploadDate = dateServer
                                };
                                await _studyCertificateRepository.Add(studyCertNew);
                            }
                        }
                        else
                        {
                            var result = await _AWSS3FileService.UploadFile(StudyDTO.FormFile, "StudyCertificates");
                            var dateServer = _matchServerDate.GetDateTimeByServer().ToString();
                            StudyCertificate studyCertNew = new StudyCertificate
                            {
                                CertificateIdentifier = result,
                                Name = StudyDTO.FormFile.FileName,
                                StudyId = Study.StudyId,
                                UploadDate = dateServer
                            };
                            await _studyCertificateRepository.Add(studyCertNew);
                        }
                    }
                }
             

                bool edited = await _studyRepository.Update(Study);
                object[] ans = await _candidateRepository.EditEditionDate(Study.CandidateId);

                if (edited && ans != null && ans.Count() == 2 && (bool)ans[0])
                {
                    Study StudyFromRepo = await _studyRepository.GetById(StudyDTO.StudyId);
                    StudyDTO = _mapper.Map<Study, StudyDTO>(StudyFromRepo);

                    return Created("", new { message = "Se editó exitosamente", obj = StudyDTO });
                }
                else
                    return BadRequest(new { message = "El estudio no fue editado" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddStudy([FromForm] StudyDTO req)
        {
            /* MODIFICAR MÉTODO DESPUÉS DE TERMINAR EL MULTIEMPRESA */

            StringValues values = "";
            Request.Headers.TryGetValue("Authorization", out values);
            string result;
            
            string validation = "AddOtherInfo";

            bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
            bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

            if (!isMaster && !isAuthorized && !req.IsFromCandidate)
                return StatusCode(403, new { message = "No autorizado" });

            bool candidateExists = _candidateRepository.CandidateExistById(req.CandidateId);

            if (!candidateExists)
                return StatusCode(404, new { message = "El candidato no existe." });

            JobProfessionRemoteDTO jobProfession = await _companyRemoteRepository.GetJobProfessionById(
                                   req.JobProfessionId, values.ToString());

            if (jobProfession == null)
                return StatusCode(404, new { message = "La profesion no existe." });

            try
            {
                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                Study study = _mapper.Map<StudyDTO, Study>(req);

                if(memberUser != null)
                    study.CompanyUserId = memberUser.CompanyUserId;

                Study created = await _studyRepository.Add(study);
                object[] ans = await _candidateRepository.EditEditionDate(req.CandidateId);

                if (req.FormFile != null) { 
                    result = await _AWSS3FileService.UploadFile(req.FormFile, "StudyCertificates");

                    if (result == null)
                        return BadRequest(result);
                    else
                    {
                        var dateServer = _matchServerDate.GetDateTimeByServer().ToString();
                        StudyCertificate studyCertificate = new StudyCertificate
                        {
                            CertificateIdentifier = result,
                            Name = req.FormFile.FileName,
                            StudyId = created.StudyId,
                            UploadDate = dateServer
                        };
                        await _studyCertificateRepository.Add(studyCertificate);
                        created = await _studyRepository.GetById(created.StudyId);
                    }
                }                    

                if (created == null || ans == null || ans.Count() != 2 || !(bool)ans[0])
                    return BadRequest(new { message = "El estudio no fue almacenado" });
                
                return Created("", new { message = "Creado exitosamente", obj = created });                
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{studyId}")]
        public async Task<IActionResult> RemoveStudyAsync(int studyId)
        {
            /* MODIFICAR MÉTODO DESPUÉS DE TERMINAR EL MULTIEMPRESA */

            try
            {
                //Study study = _mapper.Map<StudyDTO, Study>(req);
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                
                var removed = await _studyRepository.Remove(studyId);
                object[] ans = await _candidateRepository.EditEditionDate(removed.CandidateId);

                if (removed != null && ans != null && ans.Count() == 2 && (bool)ans[0])
                {
                    return StatusCode(200, new { message = "Eliminado exitosamente" });
                }
                else
                {
                    return StatusCode(404, new { message = "El estudio no existe" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }                        
        }

        [HttpDelete("company/{studyId}")]
        public async Task<IActionResult> RemoveStudyCompanyAsync(int studyId)
        {
            /* MODIFICAR MÉTODO DESPUÉS DE TERMINAR EL MULTIEMPRESA */

            try
            {
                //Study study = _mapper.Map<StudyDTO, Study>(req);
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "DeleteOtherInfo";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());


                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                var removed = await _studyRepository.Remove(studyId);
                object[] ans = await _candidateRepository.EditEditionDate(removed.CandidateId);

                if (removed != null && ans != null && ans.Count() == 2 && (bool)ans[0])
                {
                    return StatusCode(200, new { message = "Eliminado exitosamente" });
                }
                else
                {
                    return StatusCode(404, new { message = "El estudio no existe" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


    }
}
