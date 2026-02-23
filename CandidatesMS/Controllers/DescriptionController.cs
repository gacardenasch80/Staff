using AutoMapper;
using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using CandidatesMS.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
namespace CandidatesMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DescriptionController : ControllerBase
    {
        private IMatchServerDate _matchServerDate;
        private IDescriptionRepository _descriptionRepository;
        private ICandidateRepository _candidateRepository;
        private IMapper _mapper;
        private IUploadTimeService _uploadTimeService;        

        public DescriptionController(IDescriptionRepository descriptionRepository, ICandidateRepository candidateRepository,
            IMapper mapper, IUploadTimeService uploadTimeService, IMatchServerDate matchServerDate)
        {
            _descriptionRepository = descriptionRepository;
            _candidateRepository = candidateRepository;
            _mapper = mapper;
            _uploadTimeService = uploadTimeService;
            _matchServerDate = matchServerDate;
        }

        [HttpPost]
        public async Task<IActionResult> AddDescription([FromBody] DescriptionDTO descriptionDTO)
        {
            try
            {
                //descriptionDTO.CandidateEditionDate = DateTime.Now.AddHours(-5).ToString();
                descriptionDTO.DescriptionId = 0;
                Description description = _mapper.Map<DescriptionDTO, Description>(descriptionDTO);
                description.DescriptionGuid = Convert.ToString(Guid.NewGuid());
                description.EditionDate = _matchServerDate.CreateServerDate();

                bool created = await _descriptionRepository.Add(description);
                object[] ans = await _candidateRepository.EditEditionDate(descriptionDTO.CandidateId);

                if (created && ans != null && ans.Count() == 2 && (bool)ans[0])
                {
                    descriptionDTO = _mapper.Map<Description, DescriptionDTO>(description);

                    return Created("", new { message = "Creado exitosamente", obj = descriptionDTO });
                }
                else
                    return BadRequest(new { message = "La descripción no fue almacenada" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch]
        public async Task<IActionResult> EditDescription([FromBody] DescriptionDTO descriptionDTO)
        {
            try
            {
                Description description = _mapper.Map<DescriptionDTO, Description>(descriptionDTO);                
                description.EditionDate = _matchServerDate.CreateServerDate(); ;
                bool edited = await _descriptionRepository.EditDescription(description);
                object[] ans = await _candidateRepository.EditEditionDate(descriptionDTO.CandidateId);
                
                if (edited && ans != null && ans.Count() == 2 && (bool)ans[0])
                {
                    Description descriptionFromRepo = await _descriptionRepository.GetByCandidateId(descriptionDTO.CandidateId);
                                        
                    descriptionDTO = _mapper.Map<Description, DescriptionDTO>(descriptionFromRepo);                                  

                    return Created("", new { message = "Se editó exitosamente", obj = descriptionFromRepo });
                }
                else
                    return BadRequest(new { message = "La descripción no fue editada" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDescriptions()
        {
            try
            {
                List<Description> descriptions = await _descriptionRepository.GetAll();

                if (descriptions != null && descriptions.Count > 0)
                {
                    List<DescriptionDTO> descriptionsDTO = _mapper.Map<List<Description>, List<DescriptionDTO>>(descriptions);

                    return Ok(new { message = "Descripciones consultadas exitosamente", obj = descriptionsDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron descripciones" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{descriptionId}")]
        public async Task<ObjectResult> GetDescriptionById(int descriptionId)
        {
            try
            {
                Description description = await _descriptionRepository.GetById(descriptionId);

                if (description != null)
                {
                    DescriptionDTO descriptionDTO = _mapper.Map<Description, DescriptionDTO>(description);

                    object[] editionAnswer = await _candidateRepository.EditEditionDate(descriptionDTO.CandidateId);

                    if ((bool)editionAnswer[0])
                        descriptionDTO.CandidateEditionDate = editionAnswer[1].ToString();

                    return Ok(new { message = "Descripción consultada exitosamente", obj = descriptionDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró la descripción" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("guid/{descriptionGuid}")]
        public async Task<ObjectResult> GetDescriptionByGuid(string descriptionGuid)
        {
            try
            {
                Description description = await _descriptionRepository.GetByGuid(descriptionGuid);

                if (description != null)
                {
                    DescriptionDTO descriptionDTO = _mapper.Map<Description, DescriptionDTO>(description);

                    object[] editionAnswer = await _candidateRepository.EditEditionDate(descriptionDTO.CandidateId);

                    if ((bool)editionAnswer[0])
                        descriptionDTO.CandidateEditionDate = editionAnswer[1].ToString();

                    return Ok(new { message = "Descripción consultada exitosamente", obj = descriptionDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró la descripción" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("candidate/{candidateId}")]
        public async Task<ObjectResult> GetDescriptionByCandidateId(int candidateId)
        {
            try
            {
                bool descriptionExists = await _descriptionRepository.DescriptionExists(candidateId);

                if (descriptionExists)
                {
                    Description description = await _descriptionRepository.GetByCandidateId(candidateId);

                    if (description != null)
                    {
                        DescriptionDTO descriptionDTO = _mapper.Map<Description, DescriptionDTO>(description);
                        descriptionDTO.CandidateEditionDate = description.EditionDate;

                        object[] editionAnswer = await _candidateRepository.EditEditionDate(candidateId);

                        if ((bool)editionAnswer[0])
                        {
                            //descriptionDTO.CandidateEditionDate = editionAnswer[1].ToString();
                            //var dateEdit = editionAnswer[1].ToString();
                            descriptionDTO.CreationInfo = _uploadTimeService.GetEditInfo(description.EditionDate);
                            descriptionDTO.CreationShortInfo = _uploadTimeService.GetFileTypeCreationShortInfo(description.EditionDate);
                            descriptionDTO.CandidateEditionDate = _uploadTimeService.GetFileTypeCreationInfoPup(description.EditionDate);

                        }
                            

                        return Ok(new { message = "Descripción consultada exitosamente", obj = descriptionDTO, isTrue = descriptionExists });
                    }
                    else
                    {
                        return Ok(new { message = "No se encontró descripción asociada a el candidato", obj = new DescriptionDTO(), isTrue = descriptionExists });
                    }
                }
                else
                {
                    return NotFound(new { message = "No se encontró descripción asociada a el candidato" , isTrue = descriptionExists });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, isTrue = false });
            }
        }

        [HttpDelete("{descriptionId}")]
        public async Task<IActionResult> RemoveDescription(int descriptionId)
        {
            try
            {
                var removed = await _descriptionRepository.Remove(descriptionId);
                object[] ans = await _candidateRepository.EditEditionDate(removed.CandidateId);

                if (removed != null && ans != null && ans.Count() == 2 && (bool)ans[0])
                {
                    return StatusCode(200, new { message = "Eliminado exitosamente" });
                }
                else
                {
                    return StatusCode(404, new { message = "La descripcion no existe" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
