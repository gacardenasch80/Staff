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
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Controllers
{
    [ApiController]
    [Route("api/personalreference")]
    public class PersonalReferenceController : ControllerBase
    {
        private ICandidateRepository _candidateRepository;
        private IMemberUserRepository _memberUserRepository;
        private IPersonalReferenceRepository _personalReferenceRepository;

        private ICompanyRemoteRepository _companyRemoteRepository;

        private IAuthorizationHelper _authorizationHelper;

        private readonly Services.IValidateMethodsService _validateMethodsService;

        private IMapper _mapper;


        public PersonalReferenceController
        (
            ICandidateRepository candidateRepository,
            IMemberUserRepository memberUserRepository,
            IPersonalReferenceRepository personalReferenceRepository,
            
            ICompanyRemoteRepository companyRemoteRepository,
            
            IAuthorizationHelper authorizationHelper,

            Services.IValidateMethodsService validateMethodsService,

            IMapper mapper
        )
        {
            _candidateRepository = candidateRepository;
            _memberUserRepository = memberUserRepository;
            _personalReferenceRepository = personalReferenceRepository;

            _companyRemoteRepository= companyRemoteRepository;

            _validateMethodsService = validateMethodsService;

            _authorizationHelper = authorizationHelper;

            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ObjectResult> GetAllPersonalReferences()
        {
            List<PersonalReference> personalReferences = await _personalReferenceRepository.GetAll();
            List<PersonalReferenceDTO> personalReferencesDto = _mapper.Map<List<PersonalReference>, List<PersonalReferenceDTO>>(personalReferences);

            return StatusCode(200, personalReferencesDto);
        }

        [HttpGet("{personalReferenceId}")]
        public async Task<ObjectResult> GetPersonalReferenceById(int personalReferenceId)
        {
            try
            {
                PersonalReference personalReference = await _personalReferenceRepository.GetById(personalReferenceId);

                if (personalReference != null)
                {
                    PersonalReferenceDTO personalReferenceDTO = _mapper.Map<PersonalReference, PersonalReferenceDTO>(personalReference);

                    return Ok(new { message = "Estudios consultados exitosamente", obj = personalReferenceDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró el estudio" });
                }
            }
            catch (ArgumentException e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("byCandidateId/{candidateId}")]
        public async Task<ObjectResult> GetByCandidateId(int candidateId)
        {
            bool candidateExists = _candidateRepository.CandidateExistById(candidateId);
            if (candidateExists)
            {
                try
                {
                    List<PersonalReference> personalReferences = await _personalReferenceRepository.GetByCandidateId(candidateId);
                    personalReferences = personalReferences.Where(x => x.IsAddefromCompany == false || x.IsAddefromCompany == null).ToList();
                    List<PersonalReferenceDTO> personalReferenceDTO = _mapper.Map<List<PersonalReference>, List<PersonalReferenceDTO>>(personalReferences);
                    foreach(var x in personalReferenceDTO)
                    {
                        if (x.RelationTypeId == 4)
                            x.RelationType.Name = x.OtherRelationtype;
                    }

                    if (personalReferenceDTO.Count == 0)
                        return StatusCode(404, new { message = "El candidato no registra referencias personales actualmente" });
                    else
                        return Ok(new { message = "Referencias personales consultadas exitosamente", obj = personalReferenceDTO });
                }
                catch (ArgumentException e)
                {
                    return BadRequest(e);
                }
            }
            else
            {
                return StatusCode(404, new { message = "El candidato no existe." });
            }
        }
        [HttpGet("GefromcompanybyCandidateId/{candidateId}")]
        public async Task<ObjectResult> GetfromcompanyByCandidateId(int candidateId)
        {
            bool candidateExists = _candidateRepository.CandidateExistById(candidateId);
            if (candidateExists)
            {
                try
                {
                    StringValues values = "";
                    Request.Headers.TryGetValue("Authorization", out values);

                    if (!candidateExists)
                        return StatusCode(404, new { message = "El candidato no existe." });

                    Candidate candidate = await _candidateRepository.GetByCandidateId(candidateId);

                    List<MemberByToken> memberUser = await _companyRemoteRepository.GetAllMemberUserByToken(values);

                    if (memberUser == null && memberUser.Count > 0)
                        return StatusCode(404, new { message = "El usuario empresa no existe." });

                    List<PersonalReference> personalReferences = await _personalReferenceRepository.GetToOverview(candidateId, memberUser[0].companyUserId);
                    personalReferences = personalReferences.Where(x => x.IsAddefromCompany == true).ToList();
                    List<PersonalReferenceDTO> personalReferenceDTO = _mapper.Map<List<PersonalReference>, List<PersonalReferenceDTO>>(personalReferences);
                    foreach (var x in personalReferenceDTO)
                    {
                        if (x.RelationTypeId == 4)
                            x.RelationType.Name = x.OtherRelationtype;
                    }

                    if (personalReferenceDTO.Count == 0)
                        return StatusCode(404, new { message = "El candidato no registra referencias personales actualmente" });
                    else
                        return Ok(new { message = "Referencias personales consultadas exitosamente", obj = personalReferenceDTO });
                }
                catch (ArgumentException e)
                {
                    return BadRequest(e);
                }
            }
            else
            {
                return StatusCode(404, new { message = "El candidato no existe." });
            }
        }
        [HttpPatch]
        public async Task<IActionResult> EditPersonalReference([FromBody] PersonalReferenceDTO req)
        {
            try
            {
                var personalref = await _personalReferenceRepository.GetpersonalreferenceById(req.PersonalReferenceId);
                if (personalref.IsAddefromCompany == null || personalref.IsAddefromCompany==false )
                {
                    PersonalReference workExperince = _mapper.Map<PersonalReferenceDTO, PersonalReference>(req);

                    bool edited = await _personalReferenceRepository.Update(workExperince);
                    object[] ans = await _candidateRepository.EditEditionDate(req.CandidateId);

                    if (edited && ans != null && ans.Count() == 2 && (bool)ans[0])
                    {
                        PersonalReference personalReferenceFR = await _personalReferenceRepository.GetById(req.PersonalReferenceId);
                        PersonalReferenceDTO res = _mapper.Map<PersonalReference, PersonalReferenceDTO>(personalReferenceFR);

                        return Created("", new { message = "Se editó exitosamente", obj = res });
                    }
                    else
                        return BadRequest(new { message = "La referencia peronal no fue editada" });
                }
                else
                    return BadRequest(new { message = "La referencia peronal no puede ser editada" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("edifromcompany")]
        public async Task<IActionResult> EditfromcompanyPersonalReference([FromBody] PersonalReferenceDTO req)
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

                var personalref = await _personalReferenceRepository.GetpersonalreferenceById(req.PersonalReferenceId);
                
                if(personalref.IsAddefromCompany != null && personalref.IsAddefromCompany == true)
                {
                    PersonalReference personalReference = _mapper.Map<PersonalReferenceDTO, PersonalReference>(req);

                    personalReference.CompanyUserId = memberUser.CompanyUserId;

                    bool edited = await _personalReferenceRepository.Update(personalReference);
                    object[] ans = await _candidateRepository.EditEditionDate(req.CandidateId);

                    if (edited && ans != null && ans.Count() == 2 && (bool)ans[0])
                    {
                        PersonalReference personalReferenceFR = await _personalReferenceRepository.GetById(req.PersonalReferenceId);
                        PersonalReferenceDTO res = _mapper.Map<PersonalReference, PersonalReferenceDTO>(personalReferenceFR);

                        return Created("", new { message = "Se editó exitosamente", obj = res });
                    }
                    else
                        return BadRequest(new { message = "La referencia peronal no fue editada" });
                }
                else
                    return BadRequest(new { message = "La referencia peronal no puede ser editada" });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonalReference([FromBody] PersonalReferenceDTO personalReferenceDTO)
        {
            bool candidateExists = _candidateRepository.CandidateExistById(personalReferenceDTO.CandidateId);
            if (!candidateExists)
                return StatusCode(404, new { message = "El candidato no existe." });
            try
            {
                personalReferenceDTO.IsAddefromCompany = false;
                PersonalReference personalReference = _mapper.Map<PersonalReferenceDTO, PersonalReference>(personalReferenceDTO);
                bool created = await _personalReferenceRepository.Add(personalReference);
                object[] ans = await _candidateRepository.EditEditionDate(personalReferenceDTO.CandidateId);

                if (created && ans != null && ans.Count() == 2 && (bool)ans[0])
                    return Created("", new { message = "Creado exitosamente", obj = personalReferenceDTO });
                else
                    return BadRequest(new { message = "La referencia personal no fue almacenada." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("Addfromcompany")]
        public async Task<IActionResult> AddfromcompanyPersonalReference([FromBody] PersonalReferenceDTO personalReferenceDTO)
        {
            StringValues values = "";
            Request.Headers.TryGetValue("Authorization", out values);

            string validation = "AddOtherInfo";

            bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
            bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

            if (!isMaster && !isAuthorized)
                return StatusCode(403, new { message = "No autorizado" });

            bool candidateExists = _candidateRepository.CandidateExistById(personalReferenceDTO.CandidateId);
            if (!candidateExists)
                return StatusCode(404, new { message = "El candidato no existe." });
            try
            {

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                personalReferenceDTO.IsAddefromCompany = true;
                PersonalReference personalReference = _mapper.Map<PersonalReferenceDTO, PersonalReference>(personalReferenceDTO);

                personalReference.CompanyUserId = memberUser.CompanyUserId;

                bool created = await _personalReferenceRepository.Add(personalReference);
                object[] ans = await _candidateRepository.EditEditionDate(personalReferenceDTO.CandidateId);

                if (created && ans != null && ans.Count() == 2 && (bool)ans[0])
                    return Created("", new { message = "Creado exitosamente", obj = personalReferenceDTO });
                else
                    return BadRequest(new { message = "La referencia personal no fue almacenada." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("removefromcompany/{personalReferenceId}")]
        public async Task<IActionResult> RemovefromcompanyPersonalReferenceById(int personalReferenceId)
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

                var personalref = await _personalReferenceRepository.GetpersonalreferenceById(personalReferenceId);
                if (personalref.IsAddefromCompany != null && personalref.IsAddefromCompany == true)
                {
                    var removed = await _personalReferenceRepository.Remove(personalReferenceId);
                    object[] ans = await _candidateRepository.EditEditionDate(removed.CandidateId);

                    if (removed != null && ans != null && ans.Count() == 2 && (bool)ans[0])
                    {
                        return StatusCode(200, new { message = "Eliminado exitosamente" });
                    }
                    else
                    {
                        return StatusCode(404, new { message = "La referencia personal no existe" });
                    }
                }
                else
                {
                    return StatusCode(404, new { message = "La referencia personal no puede ser eliminada" });
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
        [HttpDelete("{personalReferenceId}")]
        public async Task<IActionResult> RemovePersonalReferenceById(int personalReferenceId)
        {
            try
            {
                var personalref = await _personalReferenceRepository.GetpersonalreferenceById(personalReferenceId);
                if(personalref.IsAddefromCompany==null || personalref.IsAddefromCompany==false)
                {
                    var removed = await _personalReferenceRepository.Remove(personalReferenceId);
                    object[] ans = await _candidateRepository.EditEditionDate(removed.CandidateId);

                    if (removed != null && ans != null && ans.Count() == 2 && (bool)ans[0])
                    {
                        return StatusCode(200, new { message = "Eliminado exitosamente" });
                    }
                    else
                    {
                        return StatusCode(404, new { message = "La referencia personal no existe" });
                    }
                }
                else
                {
                    return StatusCode(404, new { message = "La referencia personal no puede ser eliminada" });
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
