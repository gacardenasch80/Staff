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
    [Route("api/[controller]")]
    public class TechnicalAbilityLevelController : ControllerBase
    {
        private ITechnicalAbilityLevelRepository _technicalAbilityLevelRepository;
        private IMapper _mapper;

        public TechnicalAbilityLevelController(ITechnicalAbilityLevelRepository technicalAbilityLevelRepository, IMapper mapper)
        {
            _technicalAbilityLevelRepository = technicalAbilityLevelRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLevels()
        {
            try
            {
                List<TechnicalAbilityLevel> levels = await _technicalAbilityLevelRepository.GetAll();

                if (levels.Count > 0)
                {
                    List<TechnicalAbilityLevelDTO> levelsDTO = _mapper.Map<List<TechnicalAbilityLevel>, List<TechnicalAbilityLevelDTO>>(levels);

                    return Ok(new { message = "Niveles de conocimiento consultados exitosamente", obj = levelsDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron Niveles de conocimiento" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLevelById(int id)
        {
            try
            {
                TechnicalAbilityLevel level = await _technicalAbilityLevelRepository.GetById(id);

                if (level != null)
                {
                    TechnicalAbilityLevelDTO levelDTO = _mapper.Map<TechnicalAbilityLevel, TechnicalAbilityLevelDTO>(level);

                    return Ok(new { message = "Sector consultada exitosamente", obj = levelDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró Sector" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        } 
    }
}
