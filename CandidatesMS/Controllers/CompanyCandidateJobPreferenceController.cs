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
    [Route("api/[controller]")]
    public class CompanyCandidateJobPreferenceController : ControllerBase
    {
        private ICompanyCandidateJobPreferenceRepository _companyCandidateJobPreferenceRepository;
        private ICandidateRepository _candidateRepository;
        private IMemberUserRepository _memberUserRepository;

        private ICompanyRemoteRepository _companyRemoteRepository;

        private IAuthorizationHelper _authorizationHelper;

        private readonly Services.IValidateMethodsService _validateMethodsService;

        private IMapper _mapper;

        public CompanyCandidateJobPreferenceController
        (
            ICompanyCandidateJobPreferenceRepository companyCandidateJobPreferenceRepository,
            ICandidateRepository candidateRepository,
            IMemberUserRepository memberUserRepository, 

            ICompanyRemoteRepository companyRemoteRepository,
            
            IAuthorizationHelper authorizationHelper,

            Services.IValidateMethodsService validateMethodsService,

            IMapper mapper
        )
        {
            _companyCandidateJobPreferenceRepository = companyCandidateJobPreferenceRepository;
            _candidateRepository = candidateRepository;
            _memberUserRepository = memberUserRepository;

            _companyRemoteRepository = companyRemoteRepository;

            _authorizationHelper = authorizationHelper;

            _validateMethodsService = validateMethodsService;

            _mapper = mapper;
        }

        [HttpGet("candidate/{id}")]
        public async Task<ObjectResult> GetCompanyCandidateJobPreferencesByCandidateId(int id)
        {
            try
            {
                bool candidateExists = _candidateRepository.CandidateExistById(id);
                if (candidateExists)
                {
                    StringValues values = "";
                    Request.Headers.TryGetValue("Authorization", out values);

                    if (!candidateExists)
                        return StatusCode(404, new { message = "El candidato no existe." });

                    Candidate candidate = await _candidateRepository.GetByCandidateId(id);

                    List<MemberByToken> memberUser = await _companyRemoteRepository.GetAllMemberUserByToken(values);

                    if (memberUser == null && memberUser.Count > 0)
                        return StatusCode(404, new { message = "El usuario empresa no existe." });

                    List<Company_Candidate_Wellness> companyCandidateWellness = await _companyCandidateJobPreferenceRepository.GetCompanyCandidateWellnessByCandidateAndCompanyId(id, memberUser[0].companyUserId);

                    List<Company_Candidate_TimeAvailability> companyCandidateTimeAvailabilities = await _companyCandidateJobPreferenceRepository.GetCompanyCandidateTimeAvailabilityByCandidateAndCompanyId(id, memberUser[0].companyUserId);

                    int companyUserId = 0;

                    if (companyCandidateWellness.Count > 0 || companyCandidateTimeAvailabilities.Count > 0)
                    {
                        List<WellnessDTO> wellnessList = new List<WellnessDTO>();
                        List<TimeAvailabilityDTO> timeAvailabilityList = new List<TimeAvailabilityDTO>();

                        foreach (Company_Candidate_Wellness wellness in companyCandidateWellness)
                        {
                            WellnessDTO wellnessDTO = new WellnessDTO
                            {
                                WellnessId = wellness.WellnessId,
                                WellnessName = wellness.Wellness.WellnessName,
                                WellnessNameEnglish = wellness.Wellness.WellnessNameEnglish
                            };

                            companyUserId = (int)wellness.CompanyUserId;

                            wellnessList.Add(wellnessDTO);
                        }

                        foreach (Company_Candidate_TimeAvailability timeAvailability in companyCandidateTimeAvailabilities)
                        {
                            TimeAvailabilityDTO timeAvailabilityDTO = new TimeAvailabilityDTO
                            {
                                TimeAvailabilityId = timeAvailability.TimeAvailabilityId,
                                TimeAvailabilityName = timeAvailability.TimeAvailability.TimeAvailabilityName,
                                TimeAvailabilityNameEnglish = timeAvailability.TimeAvailability.TimeAvailabilityNameEnglish
                            };

                            companyUserId = (int)timeAvailability.CompanyUserId;

                            timeAvailabilityList.Add(timeAvailabilityDTO);
                        }

                        Company_Candidate_JobPreferenceDto jobPreferences = new Company_Candidate_JobPreferenceDto()
                        {
                            CandidateId = id,
                            WellnessList = wellnessList,
                            TimeAvailabilityList = timeAvailabilityList,
                            CompanyUserId = companyUserId
                        };

                        return Ok(new { message = "Preferencias de Empleo de candidato consultadas exitosamente.", obj = jobPreferences });
                    }
                    else
                        return NotFound(new { message = "No se encontraron Preferencias de Empleo de candidato." });
                }
                else
                    return StatusCode(404, new { message = "El candidato no existe." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddDeleteCompanyCandidateJobPreferences([FromBody] Company_Candidate_JobPreferenceDto jobPreferenceDTO)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "AddOtherInfo";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                bool candidateExists = _candidateRepository.CandidateExistById(jobPreferenceDTO.CandidateId);

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                if (candidateExists)
                {
                    List<Company_Candidate_Wellness> candidateWellnessList = new();
                    List<Company_Candidate_TimeAvailability> candidateTimeAvailabilityList = [];

                    foreach (WellnessDTO item in jobPreferenceDTO.WellnessList)
                    {
                        Company_Candidate_Wellness _candidateWellness = new Company_Candidate_Wellness
                        {
                            CandidateId = jobPreferenceDTO.CandidateId,
                            WellnessId = item.WellnessId,
                            CompanyUserId = memberUser.CompanyUserId
                    };

                        candidateWellnessList.Add(_candidateWellness);
                    }

                    bool wellnessCreated = await _companyCandidateJobPreferenceRepository.AddCompanyCandidateWellness(jobPreferenceDTO.CandidateId, candidateWellnessList);

                    foreach (TimeAvailabilityDTO item in jobPreferenceDTO.TimeAvailabilityList)
                    {
                        Company_Candidate_TimeAvailability _candidateTimeAvailability = new Company_Candidate_TimeAvailability
                        {
                            CandidateId = jobPreferenceDTO.CandidateId,
                            TimeAvailabilityId = item.TimeAvailabilityId,
                            CompanyUserId = memberUser.CompanyUserId
                        };

                        candidateTimeAvailabilityList.Add(_candidateTimeAvailability);
                    }

                    bool timeAvailabilitiesCreated = await _companyCandidateJobPreferenceRepository.AddCompanyCandidateTimeAvailabilities(jobPreferenceDTO.CandidateId, candidateTimeAvailabilityList);
                    object[] ans = await _candidateRepository.EditEditionDate(jobPreferenceDTO.CandidateId);

                    if ((wellnessCreated || timeAvailabilitiesCreated) && ans != null && ans.Count() == 2 && (bool)ans[0])
                        return Created("", new { message = "Preferencia(s) de vida de Candidato creada(s) exitosamente.", obj = jobPreferenceDTO });
                    else
                        return BadRequest(new { message = "Preferencia(s) de vida de Candidato no almacenada(s)." });
                }
                else
                    return StatusCode(404, new { message = "El candidato no existe." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("candidate/{candidateId}/wellness/{id}")]
        public async Task<IActionResult> RemoveCompanyCandidateWellnessById(int candidateId, int id)
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

                Company_Candidate_Wellness candidateWellness = await _companyCandidateJobPreferenceRepository.GetCompanyCandidateWellnessByIds(candidateId, id);

                if (candidateWellness != null)
                {
                    Company_Candidate_Wellness removed = await _companyCandidateJobPreferenceRepository.RemoveCompanyCandidateWellness(candidateWellness);
                    
                    object[] ans = await _candidateRepository.EditEditionDate(candidateId);

                    if (removed != null && ans != null && ans.Count() == 2 && (bool)ans[0])
                        return StatusCode(200, new { message = "Eliminado exitosamente." });
                    else
                        return StatusCode(404, new { message = "El registro de Preferencia de vida - Bienestar no existe." });
                }
                return StatusCode(404, new { message = "El registro de Preferencia de vida - Bienestar no existe." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("candidate/{candidateId}/time/{id}")]
        public async Task<IActionResult> RemoveCompanyCandidateTimeAvailabilityById(int candidateId, int id)
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

                Company_Candidate_TimeAvailability candidateTimeAvailability = await _companyCandidateJobPreferenceRepository.GetCompanyCandidateTimeAvailabilityByIds(candidateId, id);

                if (candidateTimeAvailability != null)
                {
                    Company_Candidate_TimeAvailability removed = await _companyCandidateJobPreferenceRepository.RemoveCompanyCandidateTimeAvailability(candidateTimeAvailability);
                    
                    object[] ans = await _candidateRepository.EditEditionDate(candidateId);

                    if (removed != null && ans != null && ans.Count() == 2 && (bool)ans[0])
                        return StatusCode(200, new { message = "Eliminado exitosamente." });
                    else
                        return StatusCode(404, new { message = "El registro de Preferencia de vida - Disponibilidad de Tiempo no existe." });
                }
                return StatusCode(404, new { message = "El registro de Preferencia de vida - Disponibilidad de Tiempo no existe." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
