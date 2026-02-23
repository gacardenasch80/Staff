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
    [Route("api/softskill")]
    public class SoftSkillController : ControllerBase
    {
        private ISoftSkillRepository _softSkillRepository;
        private IMapper _mapper;

        public SoftSkillController(ISoftSkillRepository softSkillRepository, IMapper mapper)
        {
            _softSkillRepository = softSkillRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ObjectResult> GetAllSoftSkills()
        {
            try
            {
                List<SoftSkill> softSkill = await _softSkillRepository.GetAllWithOtherEnd();

                if (softSkill.Count > 0)
                {
                    List<SoftSkillDTO> softSkillDTO = _mapper.Map<List<SoftSkill>, List<SoftSkillDTO>>(softSkill);

                    return Ok(new { message = "Habilidades blandas consultadas exitosamente", obj = softSkillDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron Habilidades blandas" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{softskillId}")]
        public async Task<ObjectResult> GetSoftSkillById(int softskillId)
        {
            try
            {
                SoftSkill softSkill = await _softSkillRepository.GetById(softskillId);

                if (softSkill != null)
                {
                    SoftSkillDTO softSkillDTO = _mapper.Map<SoftSkill, SoftSkillDTO>(softSkill);

                    return Ok(new { message = "Habilidad blanda consultada exitosamente", obj = softSkillDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron Habilidades blandas" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSoftSkill([FromBody] SoftSkillDTO softSkillDTO)
        {
            try
            {
                SoftSkill softSkill = _mapper.Map<SoftSkillDTO, SoftSkill>(softSkillDTO);

                bool created = await _softSkillRepository.Add(softSkill);

                if (created)
                {
                    softSkillDTO = _mapper.Map<SoftSkill, SoftSkillDTO>(softSkill);

                    return Created("", new { message = "Habilidad blanda creada exitosamente", obj = softSkillDTO });
                }
                else
                    return BadRequest(new { message = "Habilidad blanda no almacenada" });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }

        }
    }
}
