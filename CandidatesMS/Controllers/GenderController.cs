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
    public class GenderController : ControllerBase
    {
        private IGenderRepository _genderRepository;
        private IMapper _mapper;
        //private IGenderCompanyRepository _genderCompanyRepository;

        public GenderController(IGenderRepository genderRepository, IMapper mapper)
        {
            _genderRepository = genderRepository;
            _mapper = mapper;
           // _genderCompanyRepository = genderCompanyRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenders()
        {
            try
            {
                List<Gender> genders = await _genderRepository.GetAllGendersExceptZero();

                if (genders != null && genders.Count > 0)
                {
                    List<GenderDTO> gendersDTO = _mapper.Map<List<Gender>, List<GenderDTO>>(genders);

                    return Ok(new { message = "Géneros consultados exitosamente", obj = gendersDTO });
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

        [HttpGet("{genderId}")]
        public async Task<ObjectResult> GetGenderById(int genderId)
        {
            try
            {
                Gender gender = await _genderRepository.GetByIdWithoutNull(genderId);

                if (gender != null)
                {
                    GenderDTO genderDTO = _mapper.Map<Gender, GenderDTO>(gender);

                    return Ok(new { message = "Género consultado exitosamente", obj = genderDTO });
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

        [HttpGet("guid/{genderGuid}")]
        public async Task<ObjectResult> GetGenderByGuid(string genderGuid)
        {
            try
            {
                Gender gender = await _genderRepository.GetByGuid(genderGuid);

                if (gender != null)
                {
                    GenderDTO genderDTO = _mapper.Map<Gender, GenderDTO>(gender);

                    return Ok(new { message = "Género consultado exitosamente", obj = genderDTO });
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
