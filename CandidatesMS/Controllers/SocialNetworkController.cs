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
    public class SocialNetworkController : ControllerBase
    {
        private ISocialNetworkRepository _socialNetworkRepository;
        private IMapper _mapper;

        public SocialNetworkController(ISocialNetworkRepository socialNetworkRepository, IMapper mapper)
        {
            _socialNetworkRepository = socialNetworkRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSocialNetworks()
        {
            try
            {
                List<SocialNetwork> socialNetworks = await _socialNetworkRepository.GetAllOrderedById();

                if (socialNetworks != null && socialNetworks.Count > 0)
                {
                    List<SocialNetworkDTO> socialNetworksDTO = _mapper.Map<List<SocialNetwork>, List<SocialNetworkDTO>>(socialNetworks);

                    return Ok(new { message = "Redes sociales consultadas exitosamente", obj = socialNetworksDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron redes sociales" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddSocialNetwork([FromBody] SocialNetworkDTO socialNetworkDTO)
        {
            try
            {
                SocialNetwork socialNetwork = _mapper.Map<SocialNetworkDTO, SocialNetwork>(socialNetworkDTO);

                bool created = await _socialNetworkRepository.Add(socialNetwork);

                if (created)
                {
                    socialNetworkDTO = _mapper.Map<SocialNetwork, SocialNetworkDTO>(socialNetwork);

                    return Created("", new { message = "Red social almacenada exitosamente", obj = socialNetworkDTO });
                }
                else
                    return BadRequest(new { message = "La red social no fue almacenada" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch]
        public async Task<IActionResult> EditSocialNetwork([FromBody] SocialNetworkDTO socialNetworkDTO)
        {
            try
            {
                SocialNetwork socialNetwork = _mapper.Map<SocialNetworkDTO, SocialNetwork>(socialNetworkDTO);

                bool edited = await _socialNetworkRepository.Update(socialNetwork);

                if (edited)
                {
                    socialNetworkDTO = _mapper.Map<SocialNetwork, SocialNetworkDTO>(socialNetwork);

                    return Created("", new { message = "Se editó exitosamente.", obj = socialNetworkDTO });
                }
                else
                    return BadRequest(new { message = "La red social no fue editada." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSocialNetworkById(int id)
        {
            try
            {
                SocialNetwork socialNetwork = await _socialNetworkRepository.Remove(id);

                if (socialNetwork == null)
                    return NotFound(new { message = "La red social no fue encontrada." });

                return Ok(new { message = "Red social eliminada exitosamente.", obj = socialNetwork });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
