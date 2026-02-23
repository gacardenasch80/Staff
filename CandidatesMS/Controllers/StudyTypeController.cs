using System;
using CandidatesMS.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using CandidatesMS.Persistence.Entities;

namespace CandidatesMS.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class StudyTypeController : ControllerBase
    {
        private IStudyTypeRepository _studyTypeRepository;
        private IMapper _mapper;

        public StudyTypeController(IStudyTypeRepository studyTypeRepository, IMapper mapper)
        {
            _studyTypeRepository = studyTypeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudyTypes()
        {
            try
            {
                List<StudyType> studyTypes = await _studyTypeRepository.GetAll();

                if (studyTypes != null && studyTypes.Count > 0)
                {
                    return Ok(new { message = "Tipos de estudio consultados exitosamente", obj = studyTypes });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron tipos de estudio" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{studyTypeId}")]
        public async Task<ObjectResult> GetTitleById(int studyTypeId)
        {
            try
            {
                StudyType studyType = await _studyTypeRepository.GetById(studyTypeId);

                if (studyType != null)
                {
                    return Ok(new { message = "Tipo de estudio consultado exitosamente", obj = studyType });
                }
                else
                {
                    return NotFound(new { message = "No se encontró tipo de estudio" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
