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
    public class LanguageOtherController : ControllerBase
    {
        private ILanguageOtherRepository _languageOtherRepository;
        private IMapper _mapper;

        public LanguageOtherController(ILanguageOtherRepository languageOtherRepository, IMapper mapper)
        {
            _languageOtherRepository = languageOtherRepository;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddLanguageOther([FromBody] LanguageOtherDTO languageOtherDTO)
        {
            try
            {
                LanguageOther languageOther = _mapper.Map<LanguageOtherDTO, LanguageOther>(languageOtherDTO);
                languageOther.LanguageOtherGuid = Convert.ToString(Guid.NewGuid());

                bool created = await _languageOtherRepository.Add(languageOther);

                if(created)
                {
                    languageOtherDTO = _mapper.Map<LanguageOther, LanguageOtherDTO>(languageOther);

                    return Created("", new { message = "Creado exitosamente", obj = languageOtherDTO });
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
        public async Task<IActionResult> GetAllLanguagesOther()
        {
            try
            {
                List<LanguageOther> languageOther = await _languageOtherRepository.GetAll();

                if (languageOther != null && languageOther.Count > 0)
                {
                    List<LanguageOtherDTO> languageOtherDTO = _mapper.Map<List<LanguageOther>, List<LanguageOtherDTO>>(languageOther);

                    return Ok(new { message = "Lenguajes consultados exitosamente", obj = languageOtherDTO });
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
        public async Task<ObjectResult> GetLanguageOtherById(int id)
        {
            try
            {
                LanguageOther languageOther = await _languageOtherRepository.GetById(id);

                if (languageOther != null)
                {
                    LanguageOtherDTO languageDTO = _mapper.Map<LanguageOther, LanguageOtherDTO>(languageOther);

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
        public async Task<ObjectResult> GetLanguageOtherByGuid(string guid)
        {
            try
            {
                LanguageOther languageOther = await _languageOtherRepository.GetByGuid(guid);

                if (languageOther != null)
                {
                    LanguageOtherDTO languageDTO = _mapper.Map<LanguageOther, LanguageOtherDTO>(languageOther);

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
