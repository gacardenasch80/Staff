using AutoMapper;
using CandidatesMS.Helpers;
using CandidatesMS.Models;
using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using CandidatesMS.Repositories.RemoteRepositories;
using CandidatesMS.RepositoriesCompany;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Threading.Tasks;

namespace CandidatesMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyDescriptionController : ControllerBase
    {
        private ICompanyDescriptionRepository _companyDescriptionRepository;
        private IMemberUserRepository _memberUserRepository;

        private ICompanyRemoteRepository _companyRemoteRepository;

        private IAuthorizationHelper _authorizationHelper;

        private readonly Services.IValidateMethodsService _validateMethodsService;

        private IMapper _mapper;

        public CompanyDescriptionController
        (
            ICompanyDescriptionRepository companyDescriptionRepository,
            IMemberUserRepository memberUserRepository,
            
            ICompanyRemoteRepository companyRemoteRepository,
            
            IAuthorizationHelper authorizationHelper,

            Services.IValidateMethodsService validateMethodsService,

            IMapper mapper
        )
        {
            _companyDescriptionRepository = companyDescriptionRepository;
            _memberUserRepository = memberUserRepository;
            _mapper = mapper;
            _companyRemoteRepository = companyRemoteRepository;

            _authorizationHelper = authorizationHelper;

            _validateMethodsService = validateMethodsService;

        }

        [HttpPost]
        public async Task<IActionResult> AddCompanyDescription([FromBody] CompanyDescriptionDTO companyDescriptionDTO)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "AddOtherInfo";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                CompanyDescription companyDescription = _mapper.Map<CompanyDescriptionDTO, CompanyDescription>(companyDescriptionDTO);
                companyDescription.CompanyUserId = memberUser.CompanyUserId;

                bool created = await _companyDescriptionRepository.Add(companyDescription);

                if (created)
                {
                    companyDescriptionDTO = _mapper.Map<CompanyDescription, CompanyDescriptionDTO>(companyDescription);

                    return StatusCode(201, new { message = "Creado exitosamente", obj = companyDescriptionDTO });
                }
                else
                    return BadRequest(new { message = "La descripción no fue almacenada" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{descriptionId}")]
        public async Task<ObjectResult> GetCompanyDescriptionById(int companyDescriptionId)
        {
            try
            {
                CompanyDescription companyDescription = await _companyDescriptionRepository.GetById(companyDescriptionId);

                if (companyDescription != null)
                {
                    CompanyDescriptionDTO companyDescriptionDTO = _mapper.Map<CompanyDescription, CompanyDescriptionDTO>(companyDescription);

                    return Ok(new { message = "Descripción consultada exitosamente", obj = companyDescriptionDTO });
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
        public async Task<ObjectResult> GetCompanyDescriptionByCandidateId(int candidateId)
        {
            try
            {
                bool companyDescriptionExists = await _companyDescriptionRepository.CompanyDescriptionExists(candidateId);

                if (companyDescriptionExists)
                {
                    CompanyDescription companyDescription = await _companyDescriptionRepository.GetByCandidateId(candidateId);

                    if (companyDescription != null)
                    {
                        CompanyDescriptionDTO companyDescriptionDTO = _mapper.Map<CompanyDescription, CompanyDescriptionDTO>(companyDescription);

                        return Ok(new { message = "Descripción consultada exitosamente", obj = companyDescriptionDTO, isTrue = companyDescriptionExists });
                    }
                    else
                    {
                        return Ok(new { message = "No se encontró descripción asociada a el candidato", obj = new DescriptionDTO(), isTrue = companyDescriptionExists });
                    }
                }
                else
                {
                    return NotFound(new { message = "No se encontró descripción asociada a el candidato", isTrue = companyDescriptionExists });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, isTrue = false });
            }
        }

        [HttpGet("byCandidateAndCompanyUserId/{candidateId}/{companyUserId}")]
        public async Task<ObjectResult> GetCompanyDescriptionByCandidateAndCompanyUserId(int candidateId, int companyUserId)
        {
            try
            {
                bool companyDescriptionExists = await _companyDescriptionRepository.CompanyDescriptionExistsByCandidateAndCompanyUserId(candidateId, companyUserId);

                if (companyDescriptionExists)
                {
                    CompanyDescription companyDescription = await _companyDescriptionRepository.GetByCandidateAndCompanyId(candidateId, companyUserId);

                    if (companyDescription != null)
                    {
                        CompanyDescriptionDTO companyDescriptionDTO = _mapper.Map<CompanyDescription, CompanyDescriptionDTO>(companyDescription);

                        return Ok(new { message = "Descripción consultada exitosamente", obj = companyDescriptionDTO, isTrue = companyDescriptionExists });
                    }
                    else
                    {
                        return Ok(new { message = "No se encontró descripción asociada a el candidato", obj = new DescriptionDTO(), isTrue = companyDescriptionExists });
                    }
                }
                else
                {
                    return NotFound(new { message = "No se encontró descripción asociada a el candidato", isTrue = companyDescriptionExists });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message, isTrue = false });
            }
        }

        [HttpPatch]
        public async Task<IActionResult> EditCompanyDescription([FromBody] CompanyDescriptionDTO companyDescriptionDTO)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "EditOtherInfo";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                CompanyDescription companyDescription = _mapper.Map<CompanyDescriptionDTO, CompanyDescription>(companyDescriptionDTO);

                companyDescription.CompanyUserId = memberUser.CompanyUserId;

                bool edited = await _companyDescriptionRepository.Update(companyDescription);

                if (edited)
                {
                    CompanyDescription companyDescriptionFromRepo = await _companyDescriptionRepository.GetByCandidateId(companyDescriptionDTO.CandidateId);
                    companyDescriptionDTO = _mapper.Map<CompanyDescription, CompanyDescriptionDTO>(companyDescriptionFromRepo);

                    return Created("", new { message = "Se editó exitosamente", obj = companyDescriptionDTO });
                }
                else
                    return BadRequest(new { message = "La descripción no fue editada" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{companyDescriptionId}")]
        public async Task<IActionResult> RemoveCompanyDescription(int companyDescriptionId)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string validation = "DeleteOtherInfo";

                bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                if (!isMaster && !isAuthorized)
                    return StatusCode(403, new { message = "No autorizado" });

                var removed = await _companyDescriptionRepository.Remove(companyDescriptionId);

                if (removed != null)
                    return StatusCode(200, new { message = "Eliminado exitosamente" });
                else
                    return StatusCode(404, new { message = "La descripcion no existe" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
