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
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageLevelController : ControllerBase
    {
        private ILanguageLevelRepository _languageLevelRepository;
        private IMapper _mapper;

        public LanguageLevelController(ILanguageLevelRepository languageLevelRepository, IMapper mapper)
        {
            _languageLevelRepository = languageLevelRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddLanguageLevel([FromBody] LanguageLevelDTO languageLevelDTO)
        {
            try
            {
                LanguageLevel languageLevel = _mapper.Map<LanguageLevelDTO, LanguageLevel>(languageLevelDTO);
                languageLevel.LanguageLevelGuid = Convert.ToString(Guid.NewGuid());

                bool created = await _languageLevelRepository.Add(languageLevel);

                if(created)
                {
                    languageLevelDTO = _mapper.Map<LanguageLevel, LanguageLevelDTO>(languageLevel);

                    return Created("", new { message = "Creado exitosamente", obj = languageLevelDTO });
                }
                else
                    return BadRequest(new { message = "El Lenguaje no fue almacenado" });
               
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLanguagesLevel()
        {
            try
            {
                List<LanguageLevel> languageLevels = await _languageLevelRepository.GetAllTidy();

                if (languageLevels != null && languageLevels.Count > 0)
                {
                    List<LanguageLevelDTO> languageLevelDTO = _mapper.Map<List<LanguageLevel>, List<LanguageLevelDTO>>(languageLevels);

                    return Ok(new { message = "Lenguajes consultados exitosamente", obj = languageLevelDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron Lenguajes" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ObjectResult> GetLanguageLevelById(int id)
        {
            try
            {
                LanguageLevel languageLevel = await _languageLevelRepository.GetById(id);

                if (languageLevel != null)
                {
                    LanguageLevelDTO candidateLanguageDTO = _mapper.Map<LanguageLevel, LanguageLevelDTO>(languageLevel);

                    return Ok(new { message = "Lenguaje consultado exitosamente", obj = candidateLanguageDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró el Lenguaje" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }        

        [HttpGet("guid/{guid}")]
        public async Task<ObjectResult> GetLanguageLevelByGuid(string guid)
        {
            try
            {
                LanguageLevel languageLevel = await _languageLevelRepository.GetByGuid(guid);

                if (languageLevel != null)
                {
                    LanguageLevelDTO candidateLanguageDTO = _mapper.Map<LanguageLevel, LanguageLevelDTO>(languageLevel);

                    return Ok(new { message = "Lenguaje consultado exitosamente", obj = candidateLanguageDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró el Lenguaje" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
