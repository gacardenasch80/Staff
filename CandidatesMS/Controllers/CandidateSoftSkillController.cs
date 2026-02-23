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
    [ApiController]
    [Route("api/candidatesoftskill")]
    public class CandidateSoftSkillController : ControllerBase
    {
        private ICandidateSoftSkillRepository _candidateSoftSkillRepository;
        private ICandidateRepository _candidateRepository;
        private IMemberUserRepository _memberUserRepository;

        private ICompanyRemoteRepository _companyRemoteRepository;
        private IAuthorizationHelper _authorizationHelper;

        private readonly Services.IValidateMethodsService _validateMethodsService;

        private IMapper _mapper;

        public CandidateSoftSkillController
            (
                ICandidateSoftSkillRepository candidateSoftSkillRepository,
                ICandidateRepository candidateRepository,
                IMemberUserRepository memberUserRepository,

                ICompanyRemoteRepository companyRemoteRepository,
                
                IAuthorizationHelper authorizationHelper,

                Services.IValidateMethodsService validateMethodsService,

                IMapper mapper
            )
        {
            _candidateSoftSkillRepository = candidateSoftSkillRepository;
            _candidateRepository = candidateRepository;
            _memberUserRepository = memberUserRepository;

            _companyRemoteRepository = companyRemoteRepository;

            _authorizationHelper = authorizationHelper;

            _validateMethodsService = validateMethodsService;

            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ObjectResult> GetAllCandidateSoftSkills()
        {
            try
            {
                List<Candidate_SoftSkill> candidatesSoftSkill = await _candidateSoftSkillRepository.GetAll();

                if (candidatesSoftSkill.Count > 0)
                {
                    List<Candidate_SoftSkillDTO> candidateSoftSkillDTO = _mapper.Map<List<Candidate_SoftSkill>, List<Candidate_SoftSkillDTO>>(candidatesSoftSkill);

                    return Ok(new { message = "Habilidades blandas de candidatos consultadas exitosamente", obj = candidateSoftSkillDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron Habilidades blandas de candidatos" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{candidatesoftskillId}")]
        public async Task<ObjectResult> GetCandidateSoftSkillById(int candidatesoftskillId)
        {
            try
            {
                Candidate_SoftSkill candidatesSoftSkill = await _candidateSoftSkillRepository.GetById(candidatesoftskillId);

                if (candidatesSoftSkill != null)
                {
                    Candidate_SoftSkillDTO candidateSoftSkillDTO = _mapper.Map<Candidate_SoftSkill, Candidate_SoftSkillDTO>(candidatesSoftSkill);

                    return Ok(new { message = "Habilidade blanda de candidato consultada exitosamente", obj = candidateSoftSkillDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron Habilidades blandas de candidatos" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("guid/{candidatesoftskillGuid}")]
        public async Task<ObjectResult> GetCandidateSoftSkillByGuid(string candidatesoftskillGuid)
        {
            try
            {
                Candidate_SoftSkill candidatesSoftSkill = await _candidateSoftSkillRepository.GetByGuid(candidatesoftskillGuid);

                if (candidatesSoftSkill != null)
                {
                    Candidate_SoftSkillDTO candidateSoftSkillDTO = _mapper.Map<Candidate_SoftSkill, Candidate_SoftSkillDTO>(candidatesSoftSkill);

                    return Ok(new { message = "Habilidade blanda de candidato consultada exitosamente", obj = candidateSoftSkillDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron Habilidades blandas de candidatos" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("candidate/{candidateId}")]
        public async Task<ObjectResult> GetCandidateSoftSkillsByCandidateId(int candidateId)
        {
            try
            {
                List<Candidate_SoftSkill> candidatesSoftSkills = await _candidateSoftSkillRepository.GetByCandidateIdAndNoCompany(candidateId);

                if (candidatesSoftSkills == null || candidatesSoftSkills.Count == 0)
                    return NotFound(new { message = "No se encontraron Habilidades blandas de candidato" });

                List<Candidate_SoftSkillDTO> candidatesSoftSkillsDTO = _mapper.Map<List<Candidate_SoftSkill>, List<Candidate_SoftSkillDTO>>(candidatesSoftSkills);

                if (candidatesSoftSkills != null && candidatesSoftSkills.Count > 0)
                {
                    foreach (Candidate_SoftSkillDTO candidate_SoftSkill in candidatesSoftSkillsDTO)
                    {
                        if (candidate_SoftSkill.SoftSkillId != 30)
                        {
                            candidate_SoftSkill.SoftSkillName = candidate_SoftSkill.SoftSkill.SoftSkillName;
                            candidate_SoftSkill.SoftSkillNameEnglish = candidate_SoftSkill.SoftSkill.SoftSkillNameEnglish;
                        }
                        else
                        {
                            candidate_SoftSkill.SoftSkillName = candidate_SoftSkill.Description;
                            candidate_SoftSkill.SoftSkillNameEnglish = candidate_SoftSkill.Description;
                        }
                    }
                }

                return Ok(new { message = "Habilidades blandas de candidato consultadas exitosamente", obj = candidatesSoftSkillsDTO });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("candidatefromcompany/{candidateId}")]
        public async Task<ObjectResult> GetCandidateSoftSkillsByCandidateIdfromcompany(int candidateId)
        {
            try
            {
                List<Candidate_SoftSkill> candidatesSoftSkills = await _candidateSoftSkillRepository.GetByCandidateId(candidateId);
                candidatesSoftSkills = candidatesSoftSkills.Where(p => p.IsFromEmpresaAdded == true).ToList();

                if (candidatesSoftSkills.Count > 0)
                {
                    foreach (var item in candidatesSoftSkills)
                    {
                        if (item.IsFromEmpresaAdded != true)
                        {
                            item.IsFromEmpresaAdded = false;
                        }
                        else
                        {
                            item.IsFromEmpresaAdded = true;
                        }
                    }
                    List<Candidate_SoftSkillDTO> candidatesSoftSkillsDTO = _mapper.Map<List<Candidate_SoftSkill>, List<Candidate_SoftSkillDTO>>(candidatesSoftSkills);

                    return Ok(new { message = "Habilidades blandas de candidato consultadas exitosamente", obj = candidatesSoftSkillsDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron Habilidades blandas de candidato" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCandidateSoftSkills([FromBody] List<Candidate_SoftSkillDTO> candidateSoftSkillsDTO)
        {
            try
            {
                int candidateId = 0;

                if (candidateSoftSkillsDTO != null && candidateSoftSkillsDTO.Count > 0)
                    candidateId = candidateSoftSkillsDTO[0].CandidateId;

                bool candidateExists = _candidateRepository.CandidateExistById(candidateSoftSkillsDTO[0].CandidateId);

                if (!candidateExists)
                    return StatusCode(404, new { message = "El candidato no existe." });

                List<Candidate_SoftSkill> softSkillsFromDB = await _candidateSoftSkillRepository.GetByCandidateId(candidateId);

                List<Candidate_SoftSkill> softSkillsToAdd = new List<Candidate_SoftSkill>();
                List<Candidate_SoftSkill> softSkillsToDelete = new List<Candidate_SoftSkill>();

                List<Candidate_SoftSkill> softSkillsFromService = _mapper.Map<List<Candidate_SoftSkillDTO>, List<Candidate_SoftSkill>>(candidateSoftSkillsDTO);

                if (softSkillsFromService != null && softSkillsFromService.Count > 0)
                {
                    foreach (Candidate_SoftSkill softSkill in softSkillsFromService)
                    {
                        if (softSkillsFromDB != null)
                        {
                            bool softSkillExists = false;

                            foreach (Candidate_SoftSkill auxsoftSkill in softSkillsFromDB)
                            {
                                if (softSkill.Candidate_SoftSkillId == auxsoftSkill.Candidate_SoftSkillId)
                                {
                                    softSkillExists = true;

                                    break;
                                }
                            }

                            if (!softSkillExists)
                            {
                                softSkill.CandidateId = candidateId;
                                softSkill.IsFromEmpresaAdded = false;
                                softSkill.CompanyUserId = 0;

                                softSkillsToAdd.Add(softSkill);
                            }
                        }
                    }
                }

                if (softSkillsFromDB != null && softSkillsFromDB.Count > 0)
                {
                    foreach (Candidate_SoftSkill softSkill in softSkillsFromDB)
                    {
                        if (softSkillsFromService != null)
                        {
                            bool softSkillExists = false;

                            foreach (Candidate_SoftSkill auxsoftSkill in softSkillsFromService)
                            {
                                if (softSkill.Candidate_SoftSkillId == auxsoftSkill.Candidate_SoftSkillId)
                                {
                                    softSkillExists = true;

                                    break;
                                }
                            }

                            if (!softSkillExists)
                            {
                                softSkill.CandidateId = candidateId;

                                softSkillsToDelete.Add(softSkill);
                            }
                        }
                    }
                }

                if (softSkillsToDelete != null && softSkillsToDelete.Count > 0)
                {
                    foreach (Candidate_SoftSkill softSkill in softSkillsToDelete)
                    {
                        if (!(bool)softSkill.IsFromEmpresaAdded)
                            await _candidateSoftSkillRepository.Remove(softSkill.Candidate_SoftSkillId);
                    }
                }

                bool created = await _candidateSoftSkillRepository.AddRange(softSkillsToAdd);

                object[] ans = await _candidateRepository.EditEditionDate(candidateId);

                if (created && ans != null && ans.Count() == 2 && (bool)ans[0])
                {
                    candidateSoftSkillsDTO = _mapper.Map<List<Candidate_SoftSkill>, List<Candidate_SoftSkillDTO>>(softSkillsToAdd);

                    return Created("", new { message = "Habilidad(es) blanda(s) de Candidato creada(s) exitosamente.", obj = candidateSoftSkillsDTO });
                }

                return BadRequest(new { message = "Habilidad(es) blanda(s) de Candidato no almacenada(s)." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCandidateSoftSkillById(int id)
        {
            try
            {
                // Search record in DB
                Candidate_SoftSkill candidateSoftSkill = await _candidateSoftSkillRepository.GetById(id);

                if (candidateSoftSkill != null)
                {
                    if (candidateSoftSkill.IsFromEmpresaAdded == true)
                    {
                        return StatusCode(404, new { message = "La habilidad blanda no puede ser eliminada." });
                    }
                    else
                    {
                        var removed = await _candidateSoftSkillRepository.Remove(id);
                        object[] ans = await _candidateRepository.EditEditionDate(removed.CandidateId);

                        if (removed != null && ans != null && ans.Count() == 2 && (bool)ans[0])
                            return StatusCode(200, new { message = "Habilidad Blanda eliminada exitosamente." });
                        else
                            return StatusCode(404, new { message = "La habilidad blanda no existe." });
                    }

                }
                else
                    return StatusCode(404, new { message = "La Habilidad Blanda de Candidato no existe." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("removeFromCompany/{id}")]
        public async Task<IActionResult> RemoveCandidateSoftSkillfromcompanyById(int id)
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

                // Search record in DB
                Candidate_SoftSkill candidateSoftSkill = await _candidateSoftSkillRepository.GetById(id);

                if (candidateSoftSkill != null)
                {
                    if (candidateSoftSkill.IsFromEmpresaAdded == true)
                    {
                        var removed = await _candidateSoftSkillRepository.Remove(id);
                        object[] ans = await _candidateRepository.EditEditionDate(candidateSoftSkill.CandidateId);

                        if (removed != null && ans != null && ans.Count() == 2 && (bool)ans[0])
                            return StatusCode(200, new { message = "Habilidad Blanda eliminada exitosamente." });
                        else
                            return StatusCode(404, new { message = "La habilidad blanda no existe." });
                    }
                    else
                    {
                        return StatusCode(404, new { message = "La habilidad blanda no puede ser eliminada." });
                    }


                }
                else
                    return StatusCode(404, new { message = "La Habilidad Blanda de Candidato no existe." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpPost("Addfromcompany/{candidateId}")]
        public async Task<IActionResult> AddfromcompanyCandidateSoftSkills([FromBody] List<Candidate_SoftSkillDTO> candidateSoftSkillsDTO, int candidateId)
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

                int companyUserId = 0;

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);

                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                if (memberUser == null)
                    return StatusCode(403, new { message = "No autorizado" });

                companyUserId = memberUser.CompanyUserId;

                bool candidateExists = false;

                candidateExists = _candidateRepository.CandidateExistById(candidateId);

                if (!candidateExists)
                    return StatusCode(404, new { message = "El candidato no existe." });

                List<Candidate_SoftSkill> softSkillsFromDB = await _candidateSoftSkillRepository.GetByCandidateAndCompanyId(candidateId, companyUserId);

                List<Candidate_SoftSkill> softSkillsToAdd = new List<Candidate_SoftSkill>();
                List<Candidate_SoftSkill> softSkillsToDelete = new List<Candidate_SoftSkill>();

                List<Candidate_SoftSkill> softSkillsFromService = _mapper.Map<List<Candidate_SoftSkillDTO>, List<Candidate_SoftSkill>>(candidateSoftSkillsDTO);

                if (softSkillsFromService != null && softSkillsFromService.Count > 0)
                {
                    foreach (Candidate_SoftSkill softSkill in softSkillsFromService)
                    {
                        if (softSkillsFromDB != null)
                        {
                            bool softSkillExists = false;

                            foreach (Candidate_SoftSkill auxsoftSkill in softSkillsFromDB)
                            {
                                if (softSkill.Candidate_SoftSkillId == auxsoftSkill.Candidate_SoftSkillId)
                                {
                                    softSkillExists = true;

                                    break;
                                }
                            }

                            if (!softSkillExists)
                            {
                                softSkill.CandidateId = candidateId;
                                softSkill.IsFromEmpresaAdded = true;

                                if (memberUser != null)
                                    softSkill.CompanyUserId = memberUser.CompanyUserId;

                                softSkillsToAdd.Add(softSkill);
                            }
                        }
                    }
                }

                if (softSkillsFromDB != null && softSkillsFromDB.Count > 0)
                {
                    foreach (Candidate_SoftSkill softSkill in softSkillsFromDB)
                    {
                        if (softSkillsFromService != null)
                        {
                            bool softSkillExists = false;

                            foreach (Candidate_SoftSkill auxsoftSkill in softSkillsFromService)
                            {
                                if (softSkill.Candidate_SoftSkillId == auxsoftSkill.Candidate_SoftSkillId)
                                {
                                    softSkillExists = true;

                                    break;
                                }
                            }

                            if (!softSkillExists)
                            {
                                softSkill.CandidateId = candidateId;

                                softSkillsToDelete.Add(softSkill);
                            }
                        }
                    }
                }

                if (softSkillsToDelete != null && softSkillsToDelete.Count > 0)
                {
                    foreach (Candidate_SoftSkill softSkill in softSkillsToDelete)
                    {
                        if ((bool)softSkill.IsFromEmpresaAdded)
                            await _candidateSoftSkillRepository.Remove(softSkill.Candidate_SoftSkillId);
                    }
                }

                await _candidateSoftSkillRepository.AddRange(softSkillsToAdd);

                object[] ans = await _candidateRepository.EditEditionDate(candidateId);

                candidateSoftSkillsDTO = _mapper.Map<List<Candidate_SoftSkill>, List<Candidate_SoftSkillDTO>>(softSkillsToAdd);

                return Created("", new { message = "Habilidad(es) blanda(s) de Candidato cambiadas(s) exitosamente.", obj = candidateSoftSkillsDTO });
            }
            catch (Exception ex)
            {
                if (ex != null && ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message))
                    return StatusCode(500, new { message = ex.InnerException });

                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpPatch]
        public async Task<IActionResult> EditCandidatesoftskill([FromBody] Candidate_SoftSkillDTO candidatesoftskilldto)
        {
            /* MODIFICAR MÉTODO DESPUÉS DE TERMINAR EL MULTIEMPRESA */

            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                Candidate_SoftSkill softAbility = _mapper.Map<Candidate_SoftSkillDTO, Candidate_SoftSkill>(candidatesoftskilldto);
                softAbility.IsFromEmpresaAdded = false;

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                if (memberUser != null)
                    softAbility.CompanyUserId = memberUser.CompanyUserId;

                bool edited = await _candidateSoftSkillRepository.Update(softAbility);
                object[] ans = await _candidateRepository.EditEditionDate(softAbility.CandidateId);

                if (edited && ans != null && (bool)ans[0])
                {
                    //candidateTechnicalAbilityDTO = _mapper.Map<BasicInformation, BasicInformationDTO>(basicInfo);

                    return Created("", new { message = "Se editó exitosamente.", obj = candidatesoftskilldto });
                }
                else
                    return BadRequest(new { message = "La Habilidad blanda del Candidato no fue editada." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
