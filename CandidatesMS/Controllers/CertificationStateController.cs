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
    public class CertificationStateController : ControllerBase
    {
        private ICertificationStateRepository _certificationStateRepository;
        private IMapper _mapper;

        public CertificationStateController(ICertificationStateRepository certificationStateRepository, IMapper mapper)
        {
            _certificationStateRepository = certificationStateRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCertificationStates()
        {
            try
            {
                List<CertificationState> certificationStates = await _certificationStateRepository.GetAll();

                if (certificationStates != null && certificationStates.Count > 0)
                {
                    return Ok(new { message = "estados de certificados consultados exitosamente", obj = certificationStates });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron estados de certificados" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{certificationStatesId}")]
        public async Task<ObjectResult> GetCertificationStateById(int certificationStatesId)
        {
            try
            {
                CertificationState certificationStates = await _certificationStateRepository.GetById(certificationStatesId);

                if (certificationStates != null)
                {
                    return Ok(new { message = "Estado de certificado consultado exitosamente", obj = certificationStates });
                }
                else
                {
                    return NotFound(new { message = "No se encontró el estado de certificao" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
