using AutoMapper;
using CandidatesMS.Helpers;
using CandidatesMS.Models;
using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using CandidatesMS.Repositories.RemoteRepositories;
using CandidatesMS.RepositoriesCompany;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkExperienceController : ControllerBase
    {
        private ICandidateRepository _candidateRepository;
        private IEquivalentPositionRepository _equivalentPositionRepository;
        private IMemberUserRepository _memberUserRepository;
        private IWorkExperienceRepository _workExperienceRepository;

        private ICompanyRemoteRepository _companyRemoteRepository;

        private IAuthorizationHelper _authorizationHelper;

        private readonly Services.IValidateMethodsService _validateMethodsService;

        private IMapper _mapper;

        public WorkExperienceController
        (   
            ICandidateRepository candidateRepository,
            IEquivalentPositionRepository equivalentPositionRepository, 
            IMemberUserRepository memberUserRepository,
            IWorkExperienceRepository workExperienceRepository,
            
            ICompanyRemoteRepository companyRemoteRepository,
            
            IAuthorizationHelper authorizationHelper,

            Services.IValidateMethodsService validateMethodsService,

            IMapper mapper
        )
        {
            _candidateRepository = candidateRepository;
            _equivalentPositionRepository = equivalentPositionRepository;
            _memberUserRepository = memberUserRepository;
            _workExperienceRepository = workExperienceRepository;

            _companyRemoteRepository = companyRemoteRepository;

            _authorizationHelper = authorizationHelper;

            _validateMethodsService = validateMethodsService;

            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkExperience([FromBody] WorkExperienceDTO workExperienceDTO)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "AddOtherInfo";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized && workExperienceDTO.AdminView)
                    return StatusCode(403, new { message = "No autorizado" });

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                WorkExperience workExperience = _mapper.Map<WorkExperienceDTO, WorkExperience>(workExperienceDTO);
                workExperience.WorkExperienceGuid = Convert.ToString(Guid.NewGuid());

                if (memberUser != null)
                    workExperience.CompanyUserId = memberUser.CompanyUserId;

                bool created = await _workExperienceRepository.Add(workExperience);
                object[] ans = await _candidateRepository.EditEditionDate(workExperience.CandidateId);

                if (created && ans != null && ans.Count() == 2 && (bool)ans[0])
                {
                    workExperienceDTO = _mapper.Map<WorkExperience, WorkExperienceDTO>(workExperience);

                    return Created("", new { message = "Experiencia laboral almacenada exitosamente", obj = workExperienceDTO });
                }
                else
                    return BadRequest(new { message = "La experiencia laboral no fue almacenadoa" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.InnerException });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkExperiences()
        {
            try
            {
                List<WorkExperience> workExperiences = await _workExperienceRepository.GetAll();

                if (workExperiences != null && workExperiences.Count > 0)
                {
                    List<WorkExperienceDTO> workExperiencesDTO = _mapper.Map<List<WorkExperience>, List<WorkExperienceDTO>>(workExperiences);

                    return Ok(new { message = "Experiencias laborales consultadas exitosamente", obj = workExperiencesDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron experiencias laborales" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{workExperienceId}")]
        public async Task<ObjectResult> GetWorkExperienceById(int workExperienceId)
        {
            try
            {
                WorkExperience workExperience = await _workExperienceRepository.GetById(workExperienceId);

                if (workExperience != null)
                {
                    WorkExperienceDTO workExperienceDTO = _mapper.Map<WorkExperience, WorkExperienceDTO>(workExperience);

                    if(workExperienceDTO.industry != null) {
                        if (workExperienceDTO.industry.Name == "Otro")
                            workExperienceDTO.industry.Name = workExperienceDTO.OtherIndustry;
                    }                    

                    return Ok(new { message = "Experiencia laboral consultada exitosamente", obj = workExperienceDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró la experiencia laboral" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("guid/{workExperienceGuid}")]
        public async Task<ObjectResult> GetWorkExperienceByGuid(string workExperienceGuid)
        {
            try
            {
                WorkExperience workExperience = await _workExperienceRepository.GetByGuid(workExperienceGuid);

                if (workExperience != null)
                {
                    WorkExperienceDTO workExperienceDTO = _mapper.Map<WorkExperience, WorkExperienceDTO>(workExperience);

                    return Ok(new { message = "Experiencia laboral consultada exitosamente", obj = workExperienceDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró la experiencia laboral" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpGet("candidate/{candidateId}")]
        public async Task<ObjectResult> GetGetWorkExperienceByIdByCandidateId(int candidateId)
        {
            try
            {
                List<WorkExperience> workExperiences = await _workExperienceRepository.GetByCandidateId(candidateId);

                if (workExperiences != null && workExperiences.Count > 0)
                {
                    List<WorkExperienceDTO> workExperiencesDTO = _mapper.Map<List<WorkExperience>, List<WorkExperienceDTO>>(workExperiences);
                    
                    foreach(WorkExperienceDTO we in workExperiencesDTO)
                    {
                        if (we.EquivalentPositionId != null)
                        {
                            EquivalentPosition ep = await _equivalentPositionRepository.GetById((int)we.EquivalentPositionId);
                            we.EquivalentPosition = ep.Name;
                            we.EquivalentPositionEnglish = ep.NameEnglish;
                        }
                        if (we.industry != null)
                        {
                            if (we.industry.Name == "Otro")
                                we.industry.Name = we.OtherIndustry;
                        }
                    }

                    return Ok(new { message = "Experiencias laborales consultadas exitosamente", obj = workExperiencesDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron experiencias laborales" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("adminview/candidate/{candidateId}")]
        public async Task<ObjectResult> GetGetWorkExperienceAdminViewByCandidateId(int candidateId)
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

                List<WorkExperience> workExperiences = await _workExperienceRepository.GetToOverview(candidateId, memberUser[0].companyUserId);

                if (workExperiences != null && workExperiences.Count > 0)
                {
                    List<WorkExperienceDTO> workExperiencesDTO = _mapper.Map<List<WorkExperience>, List<WorkExperienceDTO>>(workExperiences);

                    foreach (var we in workExperiencesDTO)
                    {
                        if (we.EquivalentPositionId != null)
                        {
                            var ep = await _equivalentPositionRepository.GetById((int)we.EquivalentPositionId);
                            we.EquivalentPosition = ep.Name;
                        }
                        if (we.industry != null)
                        {
                            if (we.industry.Name == "Otro")
                                we.industry.Name = we.OtherIndustry;
                        }
                    }

                    return Ok(new { message = "Experiencias laborales consultadas exitosamente", obj = workExperiencesDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron experiencias laborales" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch]
        public async Task<IActionResult> EditworkExperince([FromBody] WorkExperienceDTO req)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                WorkExperience workExperince = _mapper.Map<WorkExperienceDTO, WorkExperience>(req);
                if (req.OtherIndustry == null)
                    workExperince.OtherIndustry = null;

                bool edited = await _workExperienceRepository.Update(workExperince);
                object[] ans = await _candidateRepository.EditEditionDate(req.CandidateId);

                if (edited && ans != null && ans.Count() == 2 && (bool)ans[0])
                {
                    WorkExperience workExperinceFR = await _workExperienceRepository.GetById(req.WorkExperienceId);
                    WorkExperienceDTO res = _mapper.Map<WorkExperience, WorkExperienceDTO>(workExperinceFR);

                    return Created("", new { message = "Se editó exitosamente", obj = res });
                }
                else
                    return BadRequest(new { message = "La experiencia laboral no fue editada" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("company")]
        public async Task<IActionResult> EditworkExperinceCompany([FromBody] WorkExperienceDTO req)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "EditOtherInfo";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                WorkExperience workExperince = _mapper.Map<WorkExperienceDTO, WorkExperience>(req);
                if (req.OtherIndustry == null)
                    workExperince.OtherIndustry = null;

                workExperince.CompanyUserId = memberUser.CompanyUserId;

                bool edited = await _workExperienceRepository.Update(workExperince);
                object[] ans = await _candidateRepository.EditEditionDate(req.CandidateId);

                if (edited && ans != null && ans.Count() == 2 && (bool)ans[0])
                {
                    WorkExperience workExperinceFR = await _workExperienceRepository.GetById(req.WorkExperienceId);
                    WorkExperienceDTO res = _mapper.Map<WorkExperience, WorkExperienceDTO>(workExperinceFR);

                    return Created("", new { message = "Se editó exitosamente", obj = res });
                }
                else
                    return BadRequest(new { message = "La experiencia laboral no fue editada" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{workExperienceId}")]
        public async Task<IActionResult> RemoveworkExperinceAsync(int workExperienceId)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

            
                var removed = await _workExperienceRepository.Remove(workExperienceId);
                object[] ans = await _candidateRepository.EditEditionDate(removed.CandidateId);

                if (removed != null && ans != null && ans.Count() == 2 && (bool)ans[0])
                {
                    return StatusCode(200, new { message = "Eliminado exitosamente" });
                }
                else
                {
                    return StatusCode(404, new { message = "La experiencia laboral no existe" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("company/{workExperienceId}")]
        public async Task<IActionResult> RemoveworkExperinceCompanyAsync(int workExperienceId)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "DeleteOtherInfo";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                var removed = await _workExperienceRepository.Remove(workExperienceId);
                object[] ans = await _candidateRepository.EditEditionDate(removed.CandidateId);

                if (removed != null && ans != null && ans.Count() == 2 && (bool)ans[0])
                {
                    return StatusCode(200, new { message = "Eliminado exitosamente" });
                }
                else
                {
                    return StatusCode(404, new { message = "La experiencia laboral no existe" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


    }
}
