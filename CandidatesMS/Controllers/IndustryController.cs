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
    public class IndustryController : ControllerBase
    {
        private IIndustryRepository _industryRepository;
        private IMapper _mapper;

        public IndustryController(IIndustryRepository industryRepository, IMapper mapper)
        {
            _industryRepository = industryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllIndustries()
        {
            try
            {
                List<Industry> industries = await _industryRepository.GetAll();

                if (industries != null && industries.Count > 0)
                {
                    List<IndustryDTO> industriesDTO = _mapper.Map<List<Industry>, List<IndustryDTO>>(industries);

                    return Ok(new { message = "Industrias consultadas exitosamente", obj = industriesDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron industrias" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{industryId}")]
        public async Task<ObjectResult> GetIndustryById(int industryId)
        {
            try
            {
                Industry industry = await _industryRepository.GetById(industryId);

                if (industry != null)
                {
                    IndustryDTO industryDTO = _mapper.Map<Industry, IndustryDTO>(industry);

                    return Ok(new { message = "Industria consultada exitosamente", obj = industryDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró la industria" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("guid/{industryGuid}")]
        public async Task<ObjectResult> GetIndustryByGuid(string industryGuid)
        {
            try
            {
                Industry industry = await _industryRepository.GetByGuid(industryGuid);

                if (industry != null)
                {
                    IndustryDTO industryDTO = _mapper.Map<Industry, IndustryDTO>(industry);

                    return Ok(new { message = "Industria consultada exitosamente", obj = industryDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró la industria" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
