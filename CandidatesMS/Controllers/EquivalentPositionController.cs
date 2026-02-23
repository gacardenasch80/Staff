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
    public class EquivalentPositionController : ControllerBase
    {
        private IEquivalentPositionRepository _equivalentPositionRepository;
        private IMapper _mapper;

        public EquivalentPositionController(IEquivalentPositionRepository equivalentPositionRepository, IMapper mapper)
        {
            _equivalentPositionRepository = equivalentPositionRepository;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllEquivalentPositions()
        {
            try
            {
                List<EquivalentPosition> equivalentPositions = await _equivalentPositionRepository.GetAll();

                if (equivalentPositions != null && equivalentPositions.Count > 0)
                {
                    List<EquivalentPosition> equivalentPositionsDTO = _mapper.Map<List<EquivalentPosition>, List<EquivalentPosition>>(equivalentPositions);

                    return Ok(new { message = "Posiciones equivalentes consultadas exitosamente", obj = equivalentPositionsDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron posiciones equivalentes" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{equivalentPositionId}")]
        public async Task<ObjectResult> GetEquivalentPositionById(int equivalentPositionId)
        {
            try
            {
                EquivalentPosition equivalentPosition = await _equivalentPositionRepository.GetById(equivalentPositionId);

                if (equivalentPosition != null)
                {
                    EquivalentPositionDTO equivalentPositionDTO = _mapper.Map<EquivalentPosition, EquivalentPositionDTO>(equivalentPosition);

                    return Ok(new { message = "Posición equivalente encontrada exitosamente", obj = equivalentPositionDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró la posición equvalente" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("guid/{equivalentPositionGuid}")]
        public async Task<ObjectResult> GetEquivalentPositionByGuid(string equivalentPositionGuid)
        {
            try
            {
                EquivalentPosition equivalentPosition = await _equivalentPositionRepository.GetByGuid(equivalentPositionGuid);

                if (equivalentPosition != null)
                {
                    EquivalentPositionDTO equivalentPositionDTO = _mapper.Map<EquivalentPosition, EquivalentPositionDTO>(equivalentPosition);

                    return Ok(new { message = "Posición equivalente encontrada exitosamente", obj = equivalentPositionDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró la posición equvalente" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
