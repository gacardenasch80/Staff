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
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateLanguageController : ControllerBase
    {
        private ICandidateLanguageRepository _candidateLanguageRepository;
        private ICandidateLanguageOtherRepository _candidateLanguageOtherRepository;
        private ILanguageOtherRepository _languageOtherRepository;
        private ILanguageRepository _languageRepository;
        private ICandidateRepository _candidateRepository;
        private IMemberUserRepository _memberUserRepository;

        private ICompanyRemoteRepository _companyRemoteRepository;

        private IAuthorizationHelper _authorizationHelper;

        private readonly Services.IValidateMethodsService _validateMethodsService;

        private IMapper _mapper;

        public CandidateLanguageController
        (
            ICandidateLanguageRepository candidateLanguageRepository, 
            ICandidateLanguageOtherRepository candidateLanguageOtherRepository,
            ILanguageOtherRepository languageOtherRepository,
            ILanguageRepository languageRepository,
            ICandidateRepository candidateRepository,
            IMemberUserRepository memberUserRepository,

            ICompanyRemoteRepository companyRemoteRepository,

            IAuthorizationHelper authorizationHelper,

            Services.IValidateMethodsService validateMethodsService,

            IMapper mapper
        )
        {
            _candidateLanguageRepository = candidateLanguageRepository;
            _candidateLanguageOtherRepository = candidateLanguageOtherRepository;
            _languageOtherRepository = languageOtherRepository;
            _languageRepository = languageRepository;
            _candidateRepository = candidateRepository;
            _memberUserRepository = memberUserRepository;

            _companyRemoteRepository = companyRemoteRepository;

            _validateMethodsService = validateMethodsService;

            _authorizationHelper = authorizationHelper;

            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddCandidateLanguage([FromBody] Candidate_LanguageDTO candidateLanguageDTO)
        {
            /* MODIFICAR MÉTODO DESPUÉS DE TERMINAR EL MULTIEMPRESA */

            try
            {
                Candidate_Language candidateLanguage = new();
                MemberUser memberUser = new();

                if (candidateLanguageDTO.AdminView)
                {
                    StringValues values = "";
                    Request.Headers.TryGetValue("Authorization", out values);

                    string validation = "AddProfileInfo";

                    bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                    bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                    if (!isMaster && !isAuthorized)
                        return StatusCode(403, new { message = "No autorizado" });

                    string memberEmail = _authorizationHelper.GetEmailFromToken(Request);

                    memberUser = await _memberUserRepository.GetByEmail(memberEmail);
                }


                candidateLanguage = _mapper.Map<Candidate_LanguageDTO, Candidate_Language>(candidateLanguageDTO);
                candidateLanguage.Candidate_LanguageGuid = Convert.ToString(Guid.NewGuid());

                if (memberUser != null)
                    candidateLanguage.CompanyUserId = memberUser.CompanyUserId;

                bool created = await _candidateLanguageRepository.Add(candidateLanguage);
                object[] ans = await _candidateRepository.EditEditionDate(candidateLanguageDTO.CandidateId);

                if (created && ans != null && ans.Count() == 2 && (bool)ans[0])
                {
                    candidateLanguageDTO = _mapper.Map<Candidate_Language, Candidate_LanguageDTO>(candidateLanguage);

                    return Created("", new { message = "Creado exitosamente", obj = candidateLanguageDTO });
                }
                else
                    return BadRequest(new { message = "El Lenguaje del Candidato no fue almacenado" });
               
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("other")]
        public async Task<IActionResult> AddCandidateLanguageOther([FromBody] Candidate_LanguageDTO candidateLanguageDTO)
        {
            /* MODIFICAR MÉTODO DESPUÉS DE TERMINAR EL MULTIEMPRESA */

            try
            {
                MemberUser memberUser = new();

                if (candidateLanguageDTO.AdminView)
                {
                    StringValues values = "";
                    Request.Headers.TryGetValue("Authorization", out values);

                    string validation = "AddProfileInfo";

                    bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                    bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                    if (!isMaster && !isAuthorized && !candidateLanguageDTO.AdminView)
                        return StatusCode(403, new { message = "No autorizado" });

                    string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                    memberUser = await  _memberUserRepository.GetByEmail(memberEmail);
                }

                LanguageOther languageOther = new LanguageOther()
                {
                    LanguageOtherName = candidateLanguageDTO.LanguageOtherName,
                    CandidateId = candidateLanguageDTO.CandidateId,                    
                    LanguageOtherGuid = Convert.ToString(Guid.NewGuid()),
                    AdminView = candidateLanguageDTO.AdminView,
                    CompanyUserId = memberUser.CompanyUserId
                };
                if (memberUser != null)
                    languageOther.CompanyUserId = memberUser.CompanyUserId;

                bool languageCreated = await _languageOtherRepository.Add(languageOther);
                object[] ans = await _candidateRepository.EditEditionDate(candidateLanguageDTO.CandidateId);

                if (languageCreated && ans != null && ans.Count() == 2 && (bool)ans[0])
                {
                    return Created("", new { message = "Creado exitosamente"});
                }
                else
                    return BadRequest(new { message = "El Lenguaje alterno no fue almacenado" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCandidatesLanguage()
        {
            try
            {
                List<Candidate_Language> candidatesLanguage = await _candidateLanguageRepository.GetAll();
                List<LanguageOther> candidatesLanguageOther = await _languageOtherRepository.GetAll();

                if (candidatesLanguage.Count > 0 || candidatesLanguageOther.Count > 0)
                {
                    List<Candidate_LanguageDTO> candidatesLanguageDTO = _mapper.Map<List<Candidate_Language>, List<Candidate_LanguageDTO>>(candidatesLanguage);
                    List<Candidate_LanguageDTO> candidatesLanguageOtherDTO = new List<Candidate_LanguageDTO>();

                    foreach (var item in candidatesLanguageOther)
                    {
                        Candidate_LanguageDTO dto = new Candidate_LanguageDTO()
                        {
                            Candidate_LanguageId = item.LanguageOtherId,
                            Candidate_LanguageGuid = item.LanguageOtherGuid,
                            CandidateId = item.CandidateId,
                            LanguageOtherName = item.LanguageOtherName
                        };
                        candidatesLanguageOtherDTO.Add(dto);
                    }

                    return Ok(new { message = "Lenguajes de Candidatos consultados exitosamente", obj1 = candidatesLanguageDTO, obj2 = candidatesLanguageOtherDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron Lenguajes de Candidatos" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<ObjectResult> GetCandidateLanguageById(int id)
        {
            try
            {
                Candidate_Language candidateLanguage = await _candidateLanguageRepository.GetById(id);

                if (candidateLanguage != null)
                {
                    Candidate_LanguageDTO candidateLanguageDTO = _mapper.Map<Candidate_Language, Candidate_LanguageDTO>(candidateLanguage);

                    return Ok(new { message = "Lenguaje de Candidato consultado exitosamente", obj = candidateLanguageDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró el Lenguaje de Candidato" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("other/{id}")]
        public async Task<ObjectResult> GetCandidateLanguageOtherById(int id)
        {
            try
            {
                LanguageOther candidateLanguage = await _languageOtherRepository.GetById(id);

                if (candidateLanguage != null)
                {
                    Candidate_LanguageDTO candidateLanguageDTO = new Candidate_LanguageDTO()
                    {
                        Candidate_LanguageId = candidateLanguage.LanguageOtherId,
                        Candidate_LanguageGuid = candidateLanguage.LanguageOtherGuid,
                        CandidateId = candidateLanguage.CandidateId,
                        LanguageOtherName = candidateLanguage.LanguageOtherName
                    };

                    return Ok(new { message = "Lenguaje de Candidato consultado exitosamente", obj = candidateLanguageDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró el Lenguaje de Candidato" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("guid/{guid}")]
        public async Task<ObjectResult> GetCandidateLanguageByGuid(string guid)
        {
            try
            {
                Candidate_Language candidateLanguage = await _candidateLanguageRepository.GetByGuid(guid);

                if (candidateLanguage != null)
                {
                    Candidate_LanguageDTO candidateLanguageDTO = _mapper.Map<Candidate_Language, Candidate_LanguageDTO>(candidateLanguage);

                    return Ok(new { message = "Lenguaje de Candidato consultado exitosamente", obj = candidateLanguageDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró el Lenguaje de Candidato" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("other/guid/{guid}")]
        public async Task<ObjectResult> GetCandidateLanguageOtherByGuid(string guid)
        {
            try
            {
                Candidate_LanguageOther candidateLanguage = await _candidateLanguageOtherRepository.GetByGuid(guid);

                if (candidateLanguage != null)
                {
                    Candidate_LanguageDTO candidateLanguageDTO = new Candidate_LanguageDTO()
                    {
                        Candidate_LanguageId = candidateLanguage.Candidate_LanguageOtherId,
                        Candidate_LanguageGuid = candidateLanguage.Candidate_LanguageOtherGuid,
                        CandidateId = candidateLanguage.CandidateId,
                        LanguageLevelId = candidateLanguage.LanguageLevelId,
                        LanguageId = candidateLanguage.LanguageOtherId
                    };

                    return Ok(new { message = "Lenguaje de Candidato consultado exitosamente", obj = candidateLanguageDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontró el Lenguaje de Candidato" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("email/{email}")]
        public async Task<ObjectResult> GetCandidateLanguagesByCandidateEmail(string email)
        {
            try
            {
                List<Candidate_Language> candidatesLanguage = await _candidateLanguageRepository.GetByCandidateEmail(email);
                List<Candidate_LanguageOther> candidatesLanguageOther = await _candidateLanguageOtherRepository.GetByCandidateEmail(email);

                if (candidatesLanguage.Count > 0 || candidatesLanguageOther.Count > 0)
                {
                    List<Candidate_LanguageDTO> candidatesLanguageDTO = _mapper.Map<List<Candidate_Language>, List<Candidate_LanguageDTO>>(candidatesLanguage);
                    List<Candidate_LanguageDTO> candidatesLanguageOtherDTO = new List<Candidate_LanguageDTO>();

                    foreach (var item in candidatesLanguageOther)
                    {
                        LanguageDTO _language = new LanguageDTO()
                        {
                            LanguageName = item.LanguageOther.LanguageOtherName
                        };
                        LanguageLevelDTO _languageLevel = new LanguageLevelDTO()
                        {
                            LanguageLevelName = item.LanguageLevel.LanguageLevelName
                        };

                        Candidate_LanguageDTO dto = new Candidate_LanguageDTO()
                        {
                            Candidate_LanguageId = item.Candidate_LanguageOtherId,
                            Candidate_LanguageGuid = item.Candidate_LanguageOtherGuid,
                            CandidateId = item.CandidateId,
                            LanguageId = item.LanguageOtherId,
                            Language = _language,
                            LanguageLevel = _languageLevel,
                            LanguageLevelId = item.LanguageLevelId
                        };
                        candidatesLanguageOtherDTO.Add(dto);
                    }

                    return Ok(new { message = "Lenguajes de Candidato consultados exitosamente", obj1 = candidatesLanguageDTO, obj2 = candidatesLanguageOtherDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron lenguajes de Candidato" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpPatch]
        public async Task<IActionResult> EditCandidateLanguage([FromBody] Candidate_LanguageDTO candidateLanguageDTO)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                string memberEmail = _authorizationHelper.GetEmailFromToken(Request);
                MemberUser memberUser = await _memberUserRepository.GetByEmail(memberEmail);

                Candidate_Language candidateLanguage = _mapper.Map<Candidate_LanguageDTO, Candidate_Language>(candidateLanguageDTO);

                if (memberUser != null)
                    candidateLanguage.CompanyUserId = memberUser.CompanyUserId;

                bool edited = await _candidateLanguageRepository.Update(candidateLanguage);
                object[] ans = await _candidateRepository.EditEditionDate(candidateLanguageDTO.CandidateId);

                if (edited && ans != null && ans.Count() == 2 && (bool)ans[0])
                {
                    //candidateTechnicalAbilityDTO = _mapper.Map<BasicInformation, BasicInformationDTO>(basicInfo);
                    return Created("", new { message = "El Idioma del candidato se editó exitosamente.", obj = candidateLanguageDTO });
                }
                else
                    return BadRequest(new { message = "El Idioma del candidato no fue editado." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("candidateid/{CandidateId}")]
        public async Task<ObjectResult> GetCandidateLanguagesByCandidateId(int candidateId)
        {
            /* MODIFICAR MÉTODO DESPUÉS DE TERMINAR EL MULTIEMPRESA */

            try
            {
                List<Candidate_Language> candidatesLanguage = await _candidateLanguageRepository.GetByCandidateId(candidateId);
                List<LanguageOther> candidatesLanguageOther = await _languageOtherRepository.GetByCandidateId(candidateId);

                if (candidatesLanguage.Count > 0 || candidatesLanguageOther.Count > 0)
                {
                    List<Candidate_LanguageDTO> candidatesLanguageDTO = _mapper.Map<List<Candidate_Language>, List<Candidate_LanguageDTO>>(candidatesLanguage);
                    List<Candidate_LanguageDTO> candidatesLanguageOtherDTO = new List<Candidate_LanguageDTO>();

                    foreach (var item in candidatesLanguageOther)
                    {
                        Candidate_LanguageDTO dto = new Candidate_LanguageDTO()
                        {
                            Candidate_LanguageId = item.LanguageOtherId,
                            Candidate_LanguageGuid = item.LanguageOtherGuid,
                            CandidateId = item.CandidateId,
                            LanguageOtherName = item.LanguageOtherName
                        };
                        candidatesLanguageOtherDTO.Add(dto);
                    }

                    return Ok(new { message = "Lenguajes de Candidato consultados exitosamente", obj1 = candidatesLanguageDTO, obj2 = candidatesLanguageOtherDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron lenguajes de Candidato" });
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("adminview/candidateid/{CandidateId}")]
        public async Task<ObjectResult> GetCandidateLanguagesByCandidateIdAdminView(int candidateId)
        {
            try
            {
                //StringValues values = "";
                //Request.Headers.TryGetValue("Authorization", out values);

                //string validation = "AddProfileInfo";

                //bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                //bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                //if (!isMaster && !isAuthorized)
                //    return StatusCode(403, new { message = "No autorizado" });

                List<Candidate_Language> candidatesLanguage = await _candidateLanguageRepository.GetByCandidateIdAdminView(candidateId);
                List<LanguageOther> candidatesLanguageOther = await _languageOtherRepository.GetByCandidateIdAdminView(candidateId);

                List<Candidate_Language> candidatesLanguageSend = new List<Candidate_Language>();
                List<LanguageOther> candidatesLanguageOtherSend = new List<LanguageOther>();

                if (candidatesLanguage.Count > 0 || candidatesLanguageOther.Count > 0)
                {
                    foreach (var language in candidatesLanguage)
                    {
                        if(language.AdminView)
                        {
                            candidatesLanguageSend.Add(language);
                        }
                    }

                    foreach (var language in candidatesLanguageOther)
                    {
                        if (language.AdminView)
                        {
                            candidatesLanguageOtherSend.Add(language);
                        }
                    }

                    List<Candidate_LanguageDTO> candidatesLanguageDTO = _mapper.Map<List<Candidate_Language>, List<Candidate_LanguageDTO>>(candidatesLanguageSend);
                    List<Candidate_LanguageDTO> candidatesLanguageOtherDTO = new List<Candidate_LanguageDTO>();

                    foreach (var item in candidatesLanguageOtherSend)
                    {
                        Candidate_LanguageDTO dto = new Candidate_LanguageDTO()
                        {
                            Candidate_LanguageId = item.LanguageOtherId,
                            Candidate_LanguageGuid = item.LanguageOtherGuid,
                            CandidateId = item.CandidateId,
                            LanguageOtherName = item.LanguageOtherName,
                            AdminView = item.AdminView
                        };
                        candidatesLanguageOtherDTO.Add(dto);
                    }

                    return Ok(new { message = "Lenguajes de Candidato consultados exitosamente", obj1 = candidatesLanguageDTO, obj2 = candidatesLanguageOtherDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron lenguajes de Candidato" });
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{id}/{adminView}")]
        public async Task<IActionResult> DeleteCandidateLanguage(int id, int adminView)
        {
            try
            {
                if (adminView == 1)
                {
                    StringValues values = "";
                    Request.Headers.TryGetValue("Authorization", out values);

                    string validation = "DeleteProfileInfo";

                    bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                    bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                    if (!isMaster && !isAuthorized)
                        return StatusCode(403, new { message = "No autorizado" });
                }

                Candidate_Language candidateLanguage = await _candidateLanguageRepository.GetById(id);

                if (candidateLanguage == null)
                    return NotFound(new { message = "El Idioma del candidato no fue encontrado." });

                await _candidateLanguageRepository.Remove(candidateLanguage.Candidate_LanguageId);
                object[] ans = await _candidateRepository.EditEditionDate(candidateLanguage.CandidateId);

                Candidate_LanguageDTO candidateLanguageDTO = _mapper.Map<Candidate_Language, Candidate_LanguageDTO>(candidateLanguage);

                return Ok(new { message = "Idioma del candidato eliminado exitosamente.", obj = candidateLanguageDTO });                
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("other/{id}/{adminView}")]
        public async Task<IActionResult> DeleteCandidateLanguageOther(int id, int adminView)
        {
            try
            {
                if (adminView == 1)
                {
                    StringValues values = "";
                    Request.Headers.TryGetValue("Authorization", out values);

                    string validation = "DeleteProfileInfo";

                    bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());
                    bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());

                    if (!isMaster && !isAuthorized)
                        return StatusCode(403, new { message = "No autorizado" });
                }

                LanguageOther candidateLanguage = await _languageOtherRepository.GetById(id);
                object[] ans = await _candidateRepository.EditEditionDate(candidateLanguage.CandidateId);

                await _languageOtherRepository.Remove(candidateLanguage.LanguageOtherId);

                return Ok(new { message = "Idioma del candidato eliminado exitosamente."});
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

    }
}
