using AutoMapper;
using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TechnicalAbilityTechnologyController : ControllerBase
    {
        private ITechnicalAbilityTechnologyRepository _technicalAbilityTechnologyRepository;
        private IMapper _mapper;

        public TechnicalAbilityTechnologyController(ITechnicalAbilityTechnologyRepository technicalAbilityTechnologyRepository, IMapper mapper)
        {
            _technicalAbilityTechnologyRepository = technicalAbilityTechnologyRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllTechnologies()
        {
            try
            {
                List<TechnicalAbilityTechnology> technologies = await _technicalAbilityTechnologyRepository.GetAll();

                if (technologies.Count > 0)
                {
                    List<TechnicalAbilityTechnologyDTO> technologiesDTO = _mapper.Map<List<TechnicalAbilityTechnology>, List<TechnicalAbilityTechnologyDTO>>(technologies);

                    return Ok(new { message = "Tecnologías consultadas exitosamente", obj = technologiesDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron Tecnologías" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTechnologyById(int id)
        {
            try
            {
                TechnicalAbilityTechnology technology = await _technicalAbilityTechnologyRepository.GetById(id);

                if (technology != null)
                {
                    TechnicalAbilityTechnologyDTO technologyDTO = _mapper.Map<TechnicalAbilityTechnology, TechnicalAbilityTechnologyDTO>(technology);

                    return Ok(new { message = "Tecnología consultada exitosamente", obj = technologyDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró Tecnología" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }      
    }
}
