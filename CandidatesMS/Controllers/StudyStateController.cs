using Microsoft.AspNetCore.Mvc;
using CandidatesMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandidatesMS.Persistence.Entities;
using AutoMapper;
using CandidatesMS.Models;

namespace CandidatesMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudyStateController : ControllerBase
    {
        private IStudyStateRepository _studyStateRepository;
        private IMapper _mapper;

        public StudyStateController(IStudyStateRepository studyStateRepository, IMapper mapper)
        {
            _studyStateRepository = studyStateRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudyStates()
        {
            try
            {
                List<StudyState> studyStates = await _studyStateRepository.GetAll();
                List<StudyState> studyStatesAux = new List<StudyState>();

                foreach (StudyState studyState in studyStates)
                {
                    if (studyState.StudyStateId != 4)
                    {
                        studyStatesAux.Add(studyState);
                    }
                }

                List<StudyStateDTO> studyStatesDTO = _mapper.Map<List<StudyState>, List<StudyStateDTO>>(studyStatesAux);

                if (studyStatesDTO != null && studyStatesDTO.Count > 0)
                {
                    return Ok(new { message = "Estados de estudio consultados exitosamente", obj = studyStatesDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron estados de estudio" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{studyStateId}")]
        public async Task<ObjectResult> GetStudyStateById(int studyStateId)
        {
            try
            {
                StudyState studyState = await _studyStateRepository.GetById(studyStateId);
                StudyStateDTO studyStateDTO = _mapper.Map<StudyState, StudyStateDTO>(studyState);

                if (studyState != null)
                {
                    return Ok(new { message = "Estado de estudios consultado exitosamente", obj = studyStateDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró estado de estudio" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
