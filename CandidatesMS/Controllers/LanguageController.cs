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
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private ILanguageRepository _languageRepository;
        private IMapper _mapper;

        public LanguageController(ILanguageRepository languageRepository, IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddLanguage([FromBody] LanguageDTO languageDTO)
        {
            try
            {
                Language language = _mapper.Map<LanguageDTO, Language>(languageDTO);
                language.LanguageGuid = Convert.ToString(Guid.NewGuid());

                bool created = await _languageRepository.Add(language);

                if(created)
                {
                    languageDTO = _mapper.Map<Language, LanguageDTO>(language);

                    return Created("", new { message = "Creado exitosamente", obj = languageDTO });
                }
                else
                    return BadRequest(new { message = "El Lenguaje no fue almacenado" });
               
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllLanguages()
        {
            try
            {
                List<Language> language = await _languageRepository.GetAll();

                if (language != null && language.Count > 0)
                {
                    List<LanguageDTO> languageDTO = _mapper.Map<List<Language>, List<LanguageDTO>>(language);

                    return Ok(new { message = "Lenguajes consultados exitosamente.", obj = languageDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron Lenguajes." });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ObjectResult> GetLanguageById(int id)
        {
            try
            {
                Language language = await _languageRepository.GetById(id);

                if (language != null)
                {
                    LanguageDTO languageDTO = _mapper.Map<Language, LanguageDTO>(language);

                    return Ok(new { message = "Lenguaje consultado exitosamente", obj = languageDTO });
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
        public async Task<ObjectResult> GetLanguageByGuid(string guid)
        {
            try
            {
                Language language = await _languageRepository.GetByGuid(guid);

                if (language != null)
                {
                    LanguageDTO languageDTO = _mapper.Map<Language, LanguageDTO>(language);

                    return Ok(new { message = "Lenguaje consultado exitosamente", obj = languageDTO });
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
