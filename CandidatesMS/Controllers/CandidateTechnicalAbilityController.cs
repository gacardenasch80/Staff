using AutoMapper;
using CandidatesMS.Helpers;
using CandidatesMS.Models;
using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using CandidatesMS.Repositories.RemoteRepositories;
using CandidatesMS.RepositoriesCompany;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Controllers
{
    [ApiController]
    [Route("api/candidatetechnicalability")]
    public class CandidateTechnicalAbilityController : ControllerBase
    {
        private ICandidateTechnicalAbilityRepository _candidateTechnicalAbilityRepository;
        private ICandidateRepository _candidateRepository;
        private IMemberUserRepository _memberUserRepository;

        private ICompanyRemoteRepository _companyRemoteRepository;

        private IAuthorizationHelper _authorizationHelper;

        private readonly Services.IValidateMethodsService _validateMethodsService;

        private IMapper _mapper;

        public CandidateTechnicalAbilityController
        (
            ICandidateTechnicalAbilityRepository candidateTechnicalAbilityRepository, 
            ICandidateRepository candidateRepository,
            IMemberUserRepository memberUserRepository,


            ICompanyRemoteRepository companyRemoteRepository,
            IAuthorizationHelper authorizationHelper,

            Services.IValidateMethodsService validateMethodsService,

            IMapper mapper
        )
        {
            _candidateRepository = candidateRepository;
            _candidateTechnicalAbilityRepository = candidateTechnicalAbilityRepository;
            _memberUserRepository = memberUserRepository;

            _companyRemoteRepository = companyRemoteRepository;

            _authorizationHelper = authorizationHelper;

            _validateMethodsService = validateMethodsService;

            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddCandidateTechnicalAbilities([FromBody] List<Candidate_TechnicalAbilityDTO> candidateTechnicalAbilitiesDTO)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                bool candidateExists = _candidateRepository.CandidateExistById(candidateTechnicalAbilitiesDTO[0].CandidateId);
                if (candidateExists)
                {
                    List<Candidate_TechnicalAbility> _candidateTechnicalAbilities =
                        _mapper.Map<List<Candidate_TechnicalAbilityDTO>, List<Candidate_TechnicalAbility>>(candidateTechnicalAbilitiesDTO);
                    List<Candidate_TechnicalAbility> candidateTechnicalAbilities = new List<Candidate_TechnicalAbility>();
                    //List<Candidate_TechnicalAbility> candidateTechnicalAbilitiesOthers = new List<Candidate_TechnicalAbility>();
                    foreach (Candidate_TechnicalAbility item in _candidateTechnicalAbilities)
                    {
                        var technicalAbility = await _companyRemoteRepository.GetTechnicalAbilityById(
                                item.TechnicalAbilityTechnologyId, values.ToString());

                        if(technicalAbility != null && technicalAbility.JobTechnicalAbilityId == item.TechnicalAbilityTechnologyId)
                        {
                            item.Discipline = technicalAbility.Discipline;

                            if (item.TechnicalAbilityTechnologyId == 54) // 54 -> Otras
                            {
                                bool exists = await _candidateTechnicalAbilityRepository.ExistByIdAndName(item.Other.ToString(), item.CandidateId);

                                if (!exists)
                                {
                                    item.Candidate_TechnicalAbilityGuid = Convert.ToString(Guid.NewGuid());
                                    item.Candidate_TechnicalAbilityId = 0;

                                    candidateTechnicalAbilities.Add(item);
                                }
                            }
                            else
                            {
                                bool exists = await _candidateTechnicalAbilityRepository.ExistByIds(item.TechnicalAbilityTechnologyId, item.CandidateId);

                                if (!exists)
                                {
                                    item.Candidate_TechnicalAbilityGuid = Convert.ToString(Guid.NewGuid());
                                    item.Candidate_TechnicalAbilityId = 0;

                                    candidateTechnicalAbilities.Add(item);
                                }
                            }
                        }
                    }

                    bool created = await _candidateTechnicalAbilityRepository.AddRange(candidateTechnicalAbilities);
                    object[] ans = await _candidateRepository.EditEditionDate(candidateTechnicalAbilitiesDTO[0].CandidateId);

                    if (created && ans != null && ans.Count() == 2 && (bool)ans[0])
                    {
                        candidateTechnicalAbilitiesDTO = _mapper.Map<List<Candidate_TechnicalAbility>, List<Candidate_TechnicalAbilityDTO>>(candidateTechnicalAbilities);

                        return Created("", new { message = "Habilidad(es) técnica(s) de Candidato creada(s) exitosamente.", obj = candidateTechnicalAbilitiesDTO });
                    }
                    else
                        return BadRequest(new { message = "Habilidad(es) técnica(s) de Candidato no almacenada(s)." });
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

        [HttpPost("other")]
        public async Task<string> AddCandidateTechnicalAbilityOther([FromBody] List<Candidate_TechnicalAbility> candidateTechnicalAbilities)
        {
            try
            {
                bool candidateExists = _candidateRepository.CandidateExistById(candidateTechnicalAbilities[0].CandidateId);
                if (candidateExists)
                {
                    List<Candidate_TechnicalAbilityDTO> candidateTechnicalAbilitiesDTO = new List<Candidate_TechnicalAbilityDTO>();

                    bool created = await _candidateTechnicalAbilityRepository.AddRange(candidateTechnicalAbilities);
                    object[] ans = await _candidateRepository.EditEditionDate(candidateTechnicalAbilities[0].CandidateId);

                    if (created && ans != null && ans.Count() == 2 && (bool)ans[0])
                    {
                        candidateTechnicalAbilitiesDTO = _mapper.Map<List<Candidate_TechnicalAbility>,
                            List<Candidate_TechnicalAbilityDTO>>(candidateTechnicalAbilities);

                        return "1";
                    }
                    else
                        return "2";
                }
                else
                {
                    return "3";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<ObjectResult> GetAllCandidatesTechnicalAbilities()
        {
            try
            {
                List<Candidate_TechnicalAbility> candidatesTechnicalAbilities = await _candidateTechnicalAbilityRepository.GetAll();

                if (candidatesTechnicalAbilities.Count > 0)
                {
                    List<Candidate_TechnicalAbilityDTO> candidatesTechnicalAbilityDTO = _mapper.Map<List<Candidate_TechnicalAbility>, List<Candidate_TechnicalAbilityDTO>>(candidatesTechnicalAbilities);

                    return Ok(new { message = "Habilidades técnicas consultadas exitosamente.", obj = candidatesTechnicalAbilityDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron Habilidades técnicas." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ObjectResult> GetCandidateTechnicalAbilityById(int id)
        {
            try
            {
                Candidate_TechnicalAbility candidateTechnicalAbility = await _candidateTechnicalAbilityRepository.GetById(id);

                if (candidateTechnicalAbility != null)
                {
                    Candidate_TechnicalAbilityDTO candidateTechnicalAbilityDTO = _mapper.Map<Candidate_TechnicalAbility, Candidate_TechnicalAbilityDTO>(candidateTechnicalAbility);

                    return Ok(new { message = "Habilidad técnica consultada exitosamente.", obj = candidateTechnicalAbilityDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró Habilidad técnica." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("guid/{guid}")]
        public async Task<ObjectResult> GetCandidateTechnicalAbilityByGuid(string guid)
        {
            try
            {
                Candidate_TechnicalAbility candidateTechnicalAbility = await _candidateTechnicalAbilityRepository.GetByGuid(guid);

                if (candidateTechnicalAbility != null)
                {
                    Candidate_TechnicalAbilityDTO candidateTechnicalAbilityDTO = _mapper.Map<Candidate_TechnicalAbility, Candidate_TechnicalAbilityDTO>(candidateTechnicalAbility);

                    return Ok(new { message = "Habilidad técnica consultada exitosamente.", obj = candidateTechnicalAbilityDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró Habilidad técnica." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("candidate/{candidateId}")]
        public async Task<ObjectResult> GetTechnicalAbilityByCandidateId(int candidateId)
        {
            try
            {
                bool candidateExists = _candidateRepository.CandidateExistById(candidateId);
                if (candidateExists)
                {
                    List<Candidate_TechnicalAbility> candidatesTechnicalAbilities = await _candidateTechnicalAbilityRepository.GetByCandidateId(candidateId);
                    candidatesTechnicalAbilities = candidatesTechnicalAbilities.Where(p => p.IsFromEmpresaAdded != true).ToList();
                    if (candidatesTechnicalAbilities.Count > 0)
                    {
                        List<Candidate_TechnicalAbilityDTO> candidatesTechnicalAbilityDTO = _mapper.Map<List<Candidate_TechnicalAbility>, List<Candidate_TechnicalAbilityDTO>>(candidatesTechnicalAbilities);

                        foreach (var item in candidatesTechnicalAbilityDTO)
                        {
                            if (item.TechnicalAbilityTechnologyId == 54)
                            {
                                item.TechnicalAbilityTechnologyName = item.Other;
                            }
                            else
                            {
                                item.TechnicalAbilityTechnologyName = item.Discipline;
                            }
                        }

                        return Ok(new { message = "Habilidades Técnicas del candidato consultadas exitosamente", obj = candidatesTechnicalAbilityDTO });                        
                    }
                    else
                        return Ok(new { message = "No se encontraron habilidades técnicas asociadas al candidato" });

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

        [HttpGet("candidatefromcompany/{candidateId}")]
        public async Task<ObjectResult> GetTechnicalAbilityByCandidateIdfromcompany(int candidateId)
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

                bool candidateExists = _candidateRepository.CandidateExistById(candidateId);
                if (candidateExists)
                {
                    List<Candidate_TechnicalAbility> candidatesTechnicalAbilities = await _candidateTechnicalAbilityRepository.GetByCandidateId(candidateId);
                    //candidatesTechnicalAbilities = candidatesTechnicalAbilities.Where(p => p.IsFromEmpresaAdded != true).ToList();
                    if (candidatesTechnicalAbilities.Count > 0)
                    {
                        List<Candidate_TechnicalAbilityDTO> candidatesTechnicalAbilityDTO = _mapper.Map<List<Candidate_TechnicalAbility>, List<Candidate_TechnicalAbilityDTO>>(candidatesTechnicalAbilities);

                        foreach (var item in candidatesTechnicalAbilityDTO)
                        {
                            if (item.IsFromEmpresaAdded !=true )
                            {
                                item.IsFromEmpresaAdded = false;
                            }
                            else
                            {
                                item.IsFromEmpresaAdded = true;
                            }
                            if (item.TechnicalAbilityTechnologyId == 54)
                            {
                                item.TechnicalAbilityTechnologyName = item.Other;
                            }
                            else
                            {
                                item.TechnicalAbilityTechnologyName = item.Discipline;
                            }
                        }

                        return Ok(new { message = "Habilidades Técnicas del candidato consultadas exitosamente", obj = candidatesTechnicalAbilityDTO });
                    }
                    else
                        return Ok(new { message = "No se encontraron habilidades técnicas asociadas al candidato" });

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

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveTechnicalAbilityById(int id)
        {
            try
            {
                var removed = await _candidateTechnicalAbilityRepository.Remove(id);
                object[] ans = await _candidateRepository.EditEditionDate(removed.CandidateId);

                if (removed != null && ans != null && ans.Count() == 2 && (bool)ans[0])
                {
                    return StatusCode(200, new { message = "Eliminado exitosamente" });
                }
                else
                {
                    return StatusCode(404, new { message = "La habilidad técnica no existe" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("Removefromcompany/{candidate_TechnicalAbilityId}")]
        public async Task<IActionResult> RemovefromcompanyTechnicalAbilityById(int candidate_TechnicalAbilityId)
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

                var tecSkill= await _candidateTechnicalAbilityRepository.GetSkillcanditateByid(candidate_TechnicalAbilityId);
                if(tecSkill!=null  && tecSkill.IsFromEmpresaAdded!=null)
                {
                    if (  tecSkill.IsFromEmpresaAdded == true)
                    {
                       
                        var removed = await _candidateTechnicalAbilityRepository.Remove(candidate_TechnicalAbilityId);
                        object[] ans = await _candidateRepository.EditEditionDate(tecSkill.CandidateId);

                        if (removed != null && ans != null && ans.Count() == 2 && (bool)ans[0])
                        {
                            return StatusCode(200, new { message = "Eliminado exitosamente" });
                        }
                        else
                        {
                            return StatusCode(404, new { message = "La habilidad técnica no existe" });
                        }
                    }
                    else
                    {
                        return StatusCode(404, new { message = "La habilidad técnica no se puede eliminar" });
                    }
                    
                  
                }else
                {
                    return StatusCode(404, new { message = "La habilidad técnica no se puede eliminar."  });
                }
                
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch]
        public async Task<IActionResult> EditCandidateTechnicalAbility([FromBody] Candidate_TechnicalAbilityDTO candidateTechnicalAbilityDTO)
        {
            try
            {
                Candidate_TechnicalAbility technicalAbility = _mapper.Map<Candidate_TechnicalAbilityDTO, Candidate_TechnicalAbility>(candidateTechnicalAbilityDTO);
                technicalAbility.IsFromEmpresaAdded = false;
                bool edited = await _candidateTechnicalAbilityRepository.Update(technicalAbility);
                object[] ans = await _candidateRepository.EditEditionDate(candidateTechnicalAbilityDTO.CandidateId);

                if (edited && ans != null && ans.Count() == 2 && (bool)ans[0])
                {
                    //candidateTechnicalAbilityDTO = _mapper.Map<BasicInformation, BasicInformationDTO>(basicInfo);

                    return Created("", new { message = "Se editó exitosamente.", obj = candidateTechnicalAbilityDTO });
                }
                else
                    return BadRequest(new { message = "La Habilidad Técnica del Candidato no fue editada." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch ("Editfromcompany")]
        public async Task<IActionResult> EditfromcompanyCandidateTechnicalAbility([FromBody] Candidate_TechnicalAbilityDTO candidateTechnicalAbilityDTO)
        {
            /* MODIFICAR MÉTODO DESPUÉS DE TERMINAR EL MULTIEMPRESA */

            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                Candidate_TechnicalAbility technicalAbility = _mapper.Map<Candidate_TechnicalAbilityDTO, Candidate_TechnicalAbility>(candidateTechnicalAbilityDTO);

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                technicalAbility.IsFromEmpresaAdded = true;
                technicalAbility.CompanyUserId = memberUser.CompanyUserId;

                bool edited = await _candidateTechnicalAbilityRepository.Update(technicalAbility);
                object[] ans = await _candidateRepository.EditEditionDate(candidateTechnicalAbilityDTO.CandidateId);

                if (edited && ans != null && ans.Count() == 2 && (bool)ans[0])
                {
                    //candidateTechnicalAbilityDTO = _mapper.Map<BasicInformation, BasicInformationDTO>(basicInfo);

                    return Created("", new { message = "Se editó exitosamente.", obj = candidateTechnicalAbilityDTO });
                }
                else
                    return BadRequest(new { message = "La Habilidad Técnica del Candidato no fue editada." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("Addfromcompany")]
        public async Task<IActionResult> AddfromcompanyCandidateTechnicalAbilities([FromBody] List<Candidate_TechnicalAbilityDTO> candidateTechnicalAbilitiesDTO)
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

                bool candidateExists = _candidateRepository.CandidateExistById(candidateTechnicalAbilitiesDTO[0].CandidateId);
                if (candidateExists)
                {
                    List<Candidate_TechnicalAbility> _candidateTechnicalAbilities =
                        _mapper.Map<List<Candidate_TechnicalAbilityDTO>, List<Candidate_TechnicalAbility>>(candidateTechnicalAbilitiesDTO);
                    List<Candidate_TechnicalAbility> candidateTechnicalAbilities = new List<Candidate_TechnicalAbility>();
                    //List<Candidate_TechnicalAbility> candidateTechnicalAbilitiesOthers = new List<Candidate_TechnicalAbility>();
                    foreach (Candidate_TechnicalAbility item in _candidateTechnicalAbilities)
                    {
                        item.IsFromEmpresaAdded = true;

                        item.CompanyUserId = memberUser.CompanyUserId;

                        var technicalAbility = await _companyRemoteRepository.GetTechnicalAbilityById(
                                item.TechnicalAbilityTechnologyId, values.ToString());
                        if (technicalAbility != null && technicalAbility.JobTechnicalAbilityId == item.TechnicalAbilityTechnologyId)
                        {
                            item.Discipline = technicalAbility.Discipline;

                            if (item.TechnicalAbilityTechnologyId == 54) // 54 -> Otras
                            {
                                bool exists = await _candidateTechnicalAbilityRepository.ExistByIdAndNameOnCompany(item.Other.ToString(), item.CandidateId);
                                if (!exists)
                                {
                                    item.Candidate_TechnicalAbilityGuid = "";
                                    item.Candidate_TechnicalAbilityId = 0;

                                    candidateTechnicalAbilities.Add(item);
                                }
                            }
                            else
                            {
                                bool exists = await _candidateTechnicalAbilityRepository.ExistByIdsOnCompany(item.TechnicalAbilityTechnologyId, item.CandidateId);
                                if (!exists)
                                {
                                    item.Candidate_TechnicalAbilityGuid = "";
                                    item.Candidate_TechnicalAbilityId = 0;

                                    candidateTechnicalAbilities.Add(item);
                                }
                            }
                        }
                    }

                    bool created = await _candidateTechnicalAbilityRepository.AddRange(candidateTechnicalAbilities);
                    object[] ans = await _candidateRepository.EditEditionDate(candidateTechnicalAbilitiesDTO[0].CandidateId);
                    if (created && ans != null && ans.Count() == 2 && (bool)ans[0])
                    {
                        candidateTechnicalAbilitiesDTO = _mapper.Map<List<Candidate_TechnicalAbility>, List<Candidate_TechnicalAbilityDTO>>(candidateTechnicalAbilities);

                        return Created("", new { message = "Habilidad(es) técnica(s) de Candidato creada(s) exitosamente.", obj = candidateTechnicalAbilitiesDTO });
                    }
                    else
                        return BadRequest(new { message = "Habilidad(es) técnica(s) de Candidato no almacenada(s)." });
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

    }
}
