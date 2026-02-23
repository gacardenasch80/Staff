using AutoMapper;
using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Controllers
{
    [ApiController]
    [Route("api/lifepreference")]
    public class LifePreferenceController : ControllerBase
    {
        private ILifePreferenceRepository _lifePreferenceRepository;
        private IMapper _mapper;

        public LifePreferenceController(ILifePreferenceRepository lifePreferenceRepository, IMapper mapper)
        {
            _lifePreferenceRepository = lifePreferenceRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ObjectResult> GetAllLifePreferences()
        {
            try
            {
                List<LifePreference> lifePreferences = await _lifePreferenceRepository.GetAll();


                if (lifePreferences.Count > 0)
                {
                    List<LifePreferenceDTO> lifePreferencesDTO = _mapper.Map<List<LifePreference>, List<LifePreferenceDTO>>(lifePreferences);

                    return Ok(new { message = "Preferencias de vida consultadas exitosamente.", obj = lifePreferencesDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron Preferencias de vida." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
