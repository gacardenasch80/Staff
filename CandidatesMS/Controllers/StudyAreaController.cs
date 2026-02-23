using Microsoft.AspNetCore.Mvc;
using CandidatesMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandidatesMS.Persistence.Entities;
using AutoMapper;

namespace CandidatesMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyAreaController : ControllerBase
    {
        private IStudyAreaRepository _studyAreaRepository;
        private IMapper _mapper;

        public StudyAreaController(IStudyAreaRepository studyAreaRepository, IMapper mapper)
        {
            _studyAreaRepository = studyAreaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudyAreas()
        {
            try
            {
                List<StudyArea> studyArea = await _studyAreaRepository.GetAll();

                if (studyArea != null && studyArea.Count > 0)
                {
                    return Ok(new { message = "Areas de estudio consultadas exitosamente", obj = studyArea });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron areas de estudio" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{studyAreaId}")]
        public async Task<ObjectResult> GetStudyareaById(int studyAreaId)
        {
            try
            {
                StudyArea studyArea = await _studyAreaRepository.GetById(studyAreaId);

                if (studyArea != null)
                {
                    return Ok(new { message = "Area de estudios consultada exitosamente", obj = studyArea });
                }
                else
                {
                    return NotFound(new { message = "No se encontró area de estudios" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
