using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CandidatesMS.Repositories;
using CandidatesMS.Persistence.Entities;
using AutoMapper;

namespace CandidatesMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RelationTypeController : ControllerBase
    {
        private IRelationTypeRepository _relationTypeRepository;
        private IMapper _mapper;

        public RelationTypeController(IRelationTypeRepository relationTypeRepository, IMapper mapper)
        {
            _relationTypeRepository = relationTypeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRelationTypes()
        {
            try
            {
                List<RelationType> relationTypes = await _relationTypeRepository.GetAll();

                if (relationTypes != null && relationTypes.Count > 0)
                {
                    return Ok(new { message = "Tipos de relaciones consultados exitosamente", obj = relationTypes });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron tipos de relaciones" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{relationTypeId}")]
        public async Task<ObjectResult> GetRelationTypeById(int relationTypeId)
        {
            try
            {
                RelationType relationType = await _relationTypeRepository.GetById(relationTypeId);

                if (relationType != null)
                {
                    return Ok(new { message = "Tipo de relacion consultado exitosamente", obj = relationType });
                }
                else
                {
                    return NotFound(new { message = "No se encontró tipo de relacion" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
