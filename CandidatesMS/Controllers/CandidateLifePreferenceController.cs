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
    [Route("api/candidatelifepreference")]
    public class CandidateLifePreferenceController : ControllerBase
    {
        private ICandidateLifePreferenceRepository _candidateLifePreferenceRepository;
        private ICandidateRepository _candidateRepository;
        private IMemberUserRepository _memberUserRepository;

        private ICompanyRemoteRepository _companyRemoteRepository;

        private readonly Services.IValidateMethodsService _validateMethodsService;

        private IAuthorizationHelper _authorizationHelper;
        private IMapper _mapper;

        public CandidateLifePreferenceController
        (
            ICandidateLifePreferenceRepository candidateLifePreferenceRepository,
            ICandidateRepository candidateRepository,
            IMemberUserRepository memberUserRepository,

            ICompanyRemoteRepository companyRemoteRepository,
            
            IAuthorizationHelper authorizationHelper,

            Services.IValidateMethodsService validateMethodsService,

            IMapper mapper
        )
        {
            _candidateLifePreferenceRepository = candidateLifePreferenceRepository;
            _candidateRepository = candidateRepository;
            _memberUserRepository = memberUserRepository;

            _companyRemoteRepository = companyRemoteRepository;

            _authorizationHelper = authorizationHelper;

            _validateMethodsService = validateMethodsService;

            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ObjectResult> GetAllCandidateLifePreferences()
        {
            try
            {
                List<Candidate_LifePreference> candidatesLifePreferences = await _candidateLifePreferenceRepository.GetAll();

                if (candidatesLifePreferences.Count > 0)
                {
                    List<Candidate_LifePreferenceDTO> candidateLifePreferencesDTO = _mapper.Map<List<Candidate_LifePreference>, List<Candidate_LifePreferenceDTO>>(candidatesLifePreferences);

                    return Ok(new { message = "Preferencias de vida de candidatos consultadas exitosamente", obj = candidateLifePreferencesDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron Preferencias de vida de candidatos" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ObjectResult> GetCandidateLifePreferenceById(int id)
        {
            try
            {
                Candidate_LifePreference candidateLifePreference = await _candidateLifePreferenceRepository.GetById(id);

                if (candidateLifePreference != null)
                {
                    Candidate_LifePreferenceDTO candidateLifePreferenceDTO = _mapper.Map<Candidate_LifePreference, Candidate_LifePreferenceDTO>(candidateLifePreference);

                    return Ok(new { message = "Preferencia de vida de candidato consultada exitosamente", obj = candidateLifePreferenceDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró Preferencia de vida de candidato" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("guid/{guid}")]
        public async Task<ObjectResult> GetCandidateLifePreferenceByGuid(string guid)
        {
            try
            {
                Candidate_LifePreference candidateLifePreference = await _candidateLifePreferenceRepository.GetByGuid(guid);

                if (candidateLifePreference != null)
                {
                    Candidate_LifePreferenceDTO candidateLifePreferenceDTO = _mapper.Map<Candidate_LifePreference, Candidate_LifePreferenceDTO>(candidateLifePreference);

                    return Ok(new { message = "Preferencia de vida de candidato consultada exitosamente", obj = candidateLifePreferenceDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró Preferencia de vida de candidato" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("candidate/{id}")]
        public async Task<ObjectResult> GetCandidateLifePreferencesByCandidateId(int id)
        {
            try
            {
                bool candidateExists = _candidateRepository.CandidateExistById(id);
                if (candidateExists)
                {
                    List<Candidate_LifePreference> candidateLifePreferences = await _candidateLifePreferenceRepository.GetByCandidateId(id, true);

                    if (candidateLifePreferences.Count > 0)
                    {
                        List<Candidate_LifePreferenceDTO> candidateLifePreferencesDTO = _mapper.Map<List<Candidate_LifePreference>, List<Candidate_LifePreferenceDTO>>(candidateLifePreferences);
                        foreach(var lp in candidateLifePreferencesDTO)
                        {
                            if (lp.LifePreferenceId == 332)
                                lp.LifePreference.LifePreferenceName = lp.OtherLifePreference;
                        }
                        
                        return Ok(new { message = "Preferencias de Vida de candidato consultadas exitosamente", obj = candidateLifePreferencesDTO });
                    }
                    else                    
                        return NotFound(new { message = "No se encontraron Preferencias de Vida de candidato" });                    
                }
                else
                    return StatusCode(404, new { message = "El candidato no existe." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("company/candidate/{id}")]
        public async Task<ObjectResult> GetCompanyCandidateLifePreferencesByCandidateId(int id)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                bool candidateExists = _candidateRepository.CandidateExistById(id);
                if (candidateExists)
                {
                    Candidate candidate = await _candidateRepository.GetByCandidateId(id);

                    List<MemberByToken> memberUser = await _companyRemoteRepository.GetAllMemberUserByToken(values);

                    if (memberUser == null && memberUser.Count > 0)
                        return StatusCode(404, new { message = "El usuario empresa no existe." });

                    List<Candidate_LifePreference> candidateLifePreferences = await _candidateLifePreferenceRepository.GetToOverview(id, memberUser[0].companyUserId);

                    if (candidateLifePreferences.Count > 0)
                    {
                        List<Candidate_LifePreferenceDTO> candidateLifePreferencesDTO = _mapper.Map<List<Candidate_LifePreference>, List<Candidate_LifePreferenceDTO>>(candidateLifePreferences);
                        foreach (var lp in candidateLifePreferencesDTO)
                        {
                            if (lp.LifePreferenceId == 332)
                                lp.LifePreference.LifePreferenceName = lp.OtherLifePreference;
                        }

                        return Ok(new { message = "Preferencias de Vida de candidato consultadas exitosamente", obj = candidateLifePreferencesDTO });
                    }
                    else
                        return NotFound(new { message = "No se encontraron Preferencias de Vida de candidato" });
                }
                else
                    return StatusCode(404, new { message = "El candidato no existe." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("{isFromCandidateFlag}")]
        public async Task<IActionResult> AddCandidateLifePreference([FromBody] List<Candidate_LifePreferenceDTO> candidateLifePreferencesDTO, int isFromCandidateFlag)
        {
            try
            {

                bool isFromCandidate = false;

                if (isFromCandidateFlag == 1)
                    isFromCandidate = true;

                StringValues values = "";

                string memberEmail = "";
                MemberUser memberUser = new();

                if (!isFromCandidate)
                {
                    Request.Headers.TryGetValue("Authorization", out values);

                    string validation = "AddOtherInfo";

                    bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                    bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                    if (!isMaster && !isAuthorized)
                        return StatusCode(403, new { message = "No autorizado" });

                    memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                    memberUser = await _memberUserRepository.GetByEmail(memberEmail);
                }

                bool candidateExists = _candidateRepository.CandidateExistById(candidateLifePreferencesDTO[0].CandidateId);
                if (!candidateExists)
                    return StatusCode(404, new { message = "El candidato no existe." });

                List<Candidate_LifePreference> _candidateLifePreferences = _mapper.Map<List<Candidate_LifePreferenceDTO>, List<Candidate_LifePreference>>(candidateLifePreferencesDTO);
                List<Candidate_LifePreference> candidateLifePreferences = new List<Candidate_LifePreference>();

                foreach (Candidate_LifePreference item in _candidateLifePreferences)
                {
                    item.IsFromCandidate = isFromCandidate;

                    bool exists = await _candidateLifePreferenceRepository.ExistsByCandidateAndLifePreferenceId(item.CandidateId, item.LifePreferenceId, isFromCandidate);


                    if (!isFromCandidate)
                        item.CompanyUserId = memberUser.CompanyUserId;

                    if (!exists || item.LifePreferenceId == 332)
                    {
                        item.Candidate_LifePreferenceGuid = Convert.ToString(Guid.NewGuid());
                        candidateLifePreferences.Add(item);
                    }
                }

                bool created = await _candidateLifePreferenceRepository.AddRange(candidateLifePreferences);
                object[] ans = await _candidateRepository.EditEditionDate(candidateLifePreferencesDTO[0].CandidateId);

                if (created && ans != null && ans.Count() == 2 && (bool)ans[0])
                {
                    candidateLifePreferencesDTO = _mapper.Map<List<Candidate_LifePreference>, List<Candidate_LifePreferenceDTO>>(candidateLifePreferences);

                    return Created("", new { message = "Preferencia(s) de vida de Candidato creada(s) exitosamente.", obj = candidateLifePreferencesDTO });
                }
                else
                    return BadRequest(new { message = "Preferencia(s) de vida de Candidato no almacenada(s)." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveCandidateLifePreferenceById(int id)
        {
            try
            {
                // Search record in DB
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "DeleteOtherInfo";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());


                

                Candidate_LifePreference candidateLifePreference = await _candidateLifePreferenceRepository.GetById(id);

                if (candidateLifePreference != null)
                {
                    if (!isMaster && !isAuthorized && !candidateLifePreference.IsFromCandidate)
                        return StatusCode(403, new { message = "No autorizado" });

                    var removed = await _candidateLifePreferenceRepository.Remove(id);
                    object[] ans = await _candidateRepository.EditEditionDate(removed.CandidateId);

                    if (removed != null && ans != null && ans.Count() == 2 && (bool)ans[0])
                        return StatusCode(200, new { message = "Preferencia de Vida eliminada exitosamente." });
                    else
                        return StatusCode(404, new { message = "La Preferencia de Vida no existe." });
                }
                else
                    return StatusCode(404, new { message = "La Preferencia de Vida de Candidato no existe." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
