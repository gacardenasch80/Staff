using AutoMapper;
using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.AspNetCore.Mvc;
using S3bucketDemo.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private IPhoneRepository _phoneRepository;
        private IMapper _mapper;

        public PhoneController(IPhoneRepository phoneRepository, IMapper mapper)
        {
            _phoneRepository = phoneRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPhones()
        {
            try
            {
                List<Phone> phones = await _phoneRepository.GetAll();

                if (phones != null && phones.Count > 0)
                {
                    List<PhoneDTO> phonesDTO = _mapper.Map<List<Phone>, List<PhoneDTO>>(phones);

                    return Ok(new { message = "Teléfonos consultados exitosamente", obj = phonesDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron teléfonos" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("basicInformation/{basicInformationId}")]
        public async Task<IActionResult> GetAllPhonesByBasicInformationId(int basicInformationId)
        {
            try
            {
                List<Phone> phones = await _phoneRepository.GetByBasicInformationId(basicInformationId);

                if (phones != null && phones.Count > 0)
                {
                    List<PhoneDTO> phonesDTO = _mapper.Map<List<Phone>, List<PhoneDTO>>(phones);

                    return Ok(new { message = "Teléfonos consultados exitosamente", obj = phonesDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron teléfonos" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{phoneId}")]
        public async Task<ObjectResult> GetPhonekById(int phoneId)
        {
            try
            {
                Phone phone = await _phoneRepository.GetById(phoneId);

                if (phone != null)
                {
                    PhoneDTO phoneDTO = _mapper.Map<Phone, PhoneDTO>(phone);

                    return Ok(new { message = "Teléfono consultado exitosamente", obj = phoneDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró el teléfono" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPhone([FromBody] PhoneDTO phoneDTO)
        {
            try
            {
                Phone phone = _mapper.Map<PhoneDTO, Phone>(phoneDTO);

                bool created = await _phoneRepository.Add(phone);

                if (created)
                {
                    phoneDTO = _mapper.Map<Phone, PhoneDTO>(phone);

                    return Created("", new { message = "Teléfono almacenad exitosamente", obj = phoneDTO });
                }
                else
                    return BadRequest(new { message = "El teléfono no fue almacenado" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch]
        public async Task<IActionResult> EditPhone([FromBody] PhoneDTO phoneDTO)
        {
            try
            {
                Phone phone = _mapper.Map<PhoneDTO, Phone>(phoneDTO);

                bool edited = await _phoneRepository.Update(phone);

                if (edited)
                {
                    phoneDTO = _mapper.Map<Phone, PhoneDTO>(phone);

                    return Created("", new { message = "Se editó exitosamente.", obj = phoneDTO });
                }
                else
                    return BadRequest(new { message = "El teléfono no fue editado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhoneId(int id)
        {
            try
            {
                Phone phone = await _phoneRepository.Remove(id);

                if (phone == null)
                    return NotFound(new { message = "Teléfono no fue encontrado." });

                return Ok(new { message = "Teléfono eliminado exitosamente.", obj = phone });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
