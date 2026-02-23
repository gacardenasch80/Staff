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
    public class MaritalStatusController : ControllerBase
    {
        private IMaritalStatusRepository _maritalStatusRepository;
        //private IMaritalStatusCompanyRepository _martialStatusCompanyRepository;
        private IMapper _mapper;

        public MaritalStatusController(IMaritalStatusRepository maritalStatusRepository, IMapper mapper)
        {
            _maritalStatusRepository = maritalStatusRepository;
            _mapper = mapper;
          //  _martialStatusCompanyRepository = martialStatusCompanyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMaritalStatuses()
        {
            try
            {
                List<MaritalStatus> maritalStatuses = await _maritalStatusRepository.GetAllMaritalStatusesExceptZero();

                if (maritalStatuses != null && maritalStatuses.Count > 0)
                {
                    List<MaritalStatusDTO> maritalStatusesDTO = _mapper.Map<List<MaritalStatus>, List<MaritalStatusDTO>>(maritalStatuses);

                    return Ok(new { message = "Estados civiles consultados exitosamente", obj = maritalStatusesDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron géneros" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{maritalStatusId}")]
        public async Task<ObjectResult> GetMaritalStatusById(int maritalStatusId)
        {
            try
            {
                MaritalStatus maritalStatus = await _maritalStatusRepository.GetByIdWithoutNull(maritalStatusId);

                if (maritalStatus != null)
                {
                    MaritalStatusDTO maritalStatusDTO = _mapper.Map<MaritalStatus, MaritalStatusDTO>(maritalStatus);

                    return Ok(new { message = "Estado civil consultado exitosamente", obj = maritalStatusDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró el género" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("guid/{maritalStatusGuid}")]
        public async Task<ObjectResult> GetMaritalStatusByGuid(string maritalStatusGuid)
        {
            try
            {
                MaritalStatus maritalStatus = await _maritalStatusRepository.GetByGuid(maritalStatusGuid);

                if (maritalStatus != null)
                {
                    MaritalStatusDTO maritalStatusDTO = _mapper.Map<MaritalStatus, MaritalStatusDTO>(maritalStatus);

                    return Ok(new { message = "Estado civil consultado exitosamente", obj = maritalStatusDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró el género" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
