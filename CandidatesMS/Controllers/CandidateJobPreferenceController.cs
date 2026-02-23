using AutoMapper;
using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateJobPreferenceController : ControllerBase
    {
        private ICandidateJobPreferenceRepository _candidateJobPreferenceRepository;
        private ICandidateRepository _candidateRepository;
        private IMapper _mapper;

        public CandidateJobPreferenceController(ICandidateJobPreferenceRepository candidateJobPreferenceRepository,
            ICandidateRepository candidateRepository,
            IMapper mapper)
        {
            _candidateJobPreferenceRepository = candidateJobPreferenceRepository;
            _candidateRepository = candidateRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ObjectResult> GetAllJobPreferences()
        {
            try
            {
                List<Wellness> wellnessList = await _candidateJobPreferenceRepository.GetAllWellness();

                List<TimeAvailability> timeAvailability = await _candidateJobPreferenceRepository.GetAllTimeAvailabilities();

                if (wellnessList.Count > 0 || timeAvailability.Count > 0)
                {
                    List<WellnessDTO> wellnessDTO = _mapper.Map<List<Wellness>, List<WellnessDTO>>(wellnessList);
                    List<TimeAvailabilityDTO> timeAvailabilityDTO = _mapper.Map<List<TimeAvailability>, List<TimeAvailabilityDTO>>(timeAvailability);

                    Candidate_JobPreferenceDto jobPreferences = new Candidate_JobPreferenceDto()
                    {
                        WellnessList = wellnessDTO,
                        TimeAvailabilityList = timeAvailabilityDTO
                    };

                    return Ok(new { message = "Preferencias de empleo consultadas exitosamente.", obj = jobPreferences });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron Preferencias de empleo." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("candidate/{id}")]
        public async Task<ObjectResult> GetCandidateJobPreferencesByCandidateId(int id)
        {
            try
            {
                bool candidateExists = _candidateRepository.CandidateExistById(id);
                if (candidateExists)
                {
                    // Get Wellness
                    List<Candidate_Wellness> candidateWellness = await _candidateJobPreferenceRepository.GetWellnessByCandidateId(id);

                    // Get Time Time Availability
                    List<Candidate_TimeAvailability> candidate_TimeAvailabilities = await _candidateJobPreferenceRepository.GetTimeAvailabilityByCandidateId(id);

                    if (candidateWellness.Count > 0 || candidate_TimeAvailabilities.Count > 0)
                    {
                        List<WellnessDTO> wellnessList = new List<WellnessDTO>();
                        List<TimeAvailabilityDTO> timeAvailabilityList = new List<TimeAvailabilityDTO>();

                        // Save Wellness to Job Preferences List
                        foreach (Candidate_Wellness wellness in candidateWellness)
                        {
                            WellnessDTO wellnessDTO = new WellnessDTO
                            {
                                WellnessId = wellness.WellnessId,
                                WellnessName = wellness.Wellness.WellnessName,
                                WellnessNameEnglish = wellness.Wellness.WellnessNameEnglish
                            };

                            wellnessList.Add(wellnessDTO);
                            //jobPreferences.WellnessList.Add(wellnessDTO);
                        }

                        // Save Time Availability to Job Preferences List
                        foreach (Candidate_TimeAvailability timeAvailability in candidate_TimeAvailabilities)
                        {
                            TimeAvailabilityDTO timeAvailabilityDTO = new TimeAvailabilityDTO
                            {
                                TimeAvailabilityId = timeAvailability.TimeAvailabilityId,
                                TimeAvailabilityName = timeAvailability.TimeAvailability.TimeAvailabilityName,
                                TimeAvailabilityNameEnglish = timeAvailability.TimeAvailability.TimeAvailabilityNameEnglish
                            };

                            timeAvailabilityList.Add(timeAvailabilityDTO);
                            //jobPreferences.TimeAvailabilityList.Add(timeAvailabilityDTO);
                        }

                        // Save Wellness and Time Availability Lists to Job Preferences List
                        Candidate_JobPreferenceDto jobPreferences = new Candidate_JobPreferenceDto()
                        {
                            CandidateId = id,
                            WellnessList = wellnessList,
                            TimeAvailabilityList = timeAvailabilityList
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
        public async Task<IActionResult> AddDeleteCandidateJobPreferences([FromBody] Candidate_JobPreferenceDto jobPreferenceDTO)
        {
            try
            {
                bool candidateExists = _candidateRepository.CandidateExistById(jobPreferenceDTO.CandidateId);

                if (candidateExists)
                {
                    List<Candidate_Wellness> candidateWellnessList = new List<Candidate_Wellness>();
                    List<Candidate_TimeAvailability> candidateTimeAvailabilityList = new List<Candidate_TimeAvailability>();

                    // Creates Candidate Wellness records to add into wellnessList
                    foreach (WellnessDTO item in jobPreferenceDTO.WellnessList)
                    {
                        Candidate_Wellness _candidateWellness = new Candidate_Wellness { 
                            CandidateId = jobPreferenceDTO.CandidateId,
                            WellnessId = item.WellnessId
                        };

                        candidateWellnessList.Add(_candidateWellness);
                    }

                    // Add new Candidate Wellness to Database
                    bool wellnessCreated = await _candidateJobPreferenceRepository.AddWellness(jobPreferenceDTO.CandidateId, candidateWellnessList);

                    // Creates Candidate Time Availability records to add into timeAvailabilityList
                    foreach (TimeAvailabilityDTO item in jobPreferenceDTO.TimeAvailabilityList)
                    {
                        Candidate_TimeAvailability _candidateTimeAvailability = new Candidate_TimeAvailability
                        {
                            CandidateId = jobPreferenceDTO.CandidateId,
                            TimeAvailabilityId = item.TimeAvailabilityId
                        };

                        candidateTimeAvailabilityList.Add(_candidateTimeAvailability);
                    }

                    // Add new Candidate Time Availabilities to Database
                    bool timeAvailabilitiesCreated = await _candidateJobPreferenceRepository.AddTimeAvailabilities(jobPreferenceDTO.CandidateId, candidateTimeAvailabilityList);
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
        public async Task<IActionResult> RemoveWellnessById(int candidateId, int id)
        {
            try
            {
                Candidate_Wellness candidateWellness = await _candidateJobPreferenceRepository.GetCandidateWellnessByIds(candidateId, id);

                if (candidateWellness != null)
                {
                    Candidate_Wellness removed = await _candidateJobPreferenceRepository.RemoveWellness(candidateWellness);
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
        public async Task<IActionResult> RemoveTimeAvailabilityById(int candidateId, int id)
        {
            try
            {
                Candidate_TimeAvailability candidateTimeAvailability = await _candidateJobPreferenceRepository.GetCandidateTimeAvailabilityByIds(candidateId, id);

                if (candidateTimeAvailability != null)
                {
                    Candidate_TimeAvailability removed = await _candidateJobPreferenceRepository.RemoveTimeAvailability(candidateTimeAvailability);
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
