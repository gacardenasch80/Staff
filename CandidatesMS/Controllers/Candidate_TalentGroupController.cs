using AutoMapper;
using CandidatesMS.Models;
using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using CandidatesMS.Repositories.RemoteRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Candidate_TalentGroupController : ControllerBase
    {
        private readonly ICandidate_TalentGroupRepository _candidate_TalentGroupRepository;
        private readonly ICandidateRepository _candidateRepository;
        private readonly ICompanyRemoteRepository _companyRemoteRepository;

        private readonly IMapper _mapper;

        public Candidate_TalentGroupController(ICandidate_TalentGroupRepository candidate_TalentGroupRepository,
                                               ICandidateRepository candidateRepository,
                                               ICompanyRemoteRepository companyRemoteRepository,
                                               IMapper mapper)
        {
            _candidate_TalentGroupRepository = candidate_TalentGroupRepository;
            _candidateRepository = candidateRepository;
            _companyRemoteRepository = companyRemoteRepository;

            _mapper = mapper;
        }

        [HttpGet("createAllCandidateTalentGroups")]
        public async Task<ObjectResult> CreateCandidateTalentGroupByTalentGroup()
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                List<Candidate_TG> talentGroups = await _companyRemoteRepository.GetCandidate_TalentGroups(values);

                int numberTGs = 0;

                if (talentGroups != null && talentGroups.Count > 0)
                {
                    foreach (Candidate_TG talentGroup in talentGroups)
                    {
                        Candidate_TalentGroupAux candidateTalentGroup = new Candidate_TalentGroupAux
                        {
                            CandidateId = talentGroup.candidateId,
                            Candidate_TalentGroupAuxId = talentGroup.candidate_TalentGroupId,
                            CompanyUserId = talentGroup.companyUserId,
                            TalentGroupId = talentGroup.talentGroupId,
                            TalentGroupStatusId = talentGroup.talentGroupStatusId,
                            TalentGroupPostingStatusId = talentGroup.talentGroupPostingStatusId
                        };

                        try
                        {
                            Candidate candidate = await _candidateRepository.GetByCandidateId(talentGroup.candidateId);

                            if (candidate != null)
                            {
                                await _candidate_TalentGroupRepository.Add(candidateTalentGroup);

                                numberTGs++;
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                return StatusCode(200, new { message = "Relaciones entre grupos de talento existentes y candidatos creadas exitosamente. "
                    + numberTGs + " TGs creados." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCandidateTalentGroup([FromBody] Candidate_TalentGroupDTO candidateTalentGroupDTO)
        {
            try
            {
                bool candidateExists = _candidateRepository.CandidateExistById(candidateTalentGroupDTO.CandidateId);

                if (!candidateExists)
                    return BadRequest(new { message = "El candidato no existe" });

                List<Candidate_TalentGroupAux> candidate_talentGroups = await _candidate_TalentGroupRepository.GetByTalentGroupId(candidateTalentGroupDTO.Candidate_TalentGroupId);

                if(candidate_talentGroups != null && candidate_talentGroups.Count > 0)
                    return BadRequest(new { message = "El registro del grupo de talentos ya existe" });

                Candidate_TalentGroupAux candidateTalentGroup = _mapper.Map<Candidate_TalentGroupDTO, Candidate_TalentGroupAux>(candidateTalentGroupDTO);

                candidateTalentGroup.Candidate_TalentGroupAuxId = candidateTalentGroupDTO.Candidate_TalentGroupId;

                bool isCreated = await _candidate_TalentGroupRepository.Add(candidateTalentGroup);

                if (isCreated)
                    return StatusCode(200, new { message = "El grupo de talento fue creado exitosamente", obj = candidateTalentGroup });

                return StatusCode(400, new { message = "El grupo de talento no fue creado" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("anon")]
        public async Task<IActionResult> AddCandidateTalentGroupAnonymous([FromBody] Candidate_TalentGroupDTO candidateTalentGroupDTO)
        {
            try
            {
                bool candidateExists = _candidateRepository.CandidateExistById(candidateTalentGroupDTO.CandidateId);

                if (!candidateExists)
                    return BadRequest(new { message = "El candidato no existe" });

                Candidate_TalentGroupAux candidateTalentGroup = _mapper.Map<Candidate_TalentGroupDTO, Candidate_TalentGroupAux>(candidateTalentGroupDTO);

                candidateTalentGroup.Candidate_TalentGroupAuxId = candidateTalentGroupDTO.Candidate_TalentGroupId;

                bool isCreated = await _candidate_TalentGroupRepository.Add(candidateTalentGroup);

                if (isCreated)
                    return StatusCode(200, new { message = "El grupo de talento fue creado exitosamente", obj = candidateTalentGroup });

                return StatusCode(400, new { message = "El grupo de talento no fue creado" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }     

        [HttpDelete("deleteByTalentGroupId/{talentGroupId}")]
        public async Task<IActionResult> DeleteByTalentGroupId(int talentGroupId)
        {
            try
            {
                bool deleted = await _candidate_TalentGroupRepository.RemoveByTalentGroupId(talentGroupId);

                if (deleted)
                    return Ok(new { message = "Grupo de talento borrado exitosamente" });
                else
                    return NotFound(new { message = "No se pudo borrar el grupo de talento" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpDelete("deleteByTalentGroupIdAnon/{talentGroupId}")]
        public async Task<IActionResult> DeleteByTalentGroupIdAnonymous(int talentGroupId)
        {
            try
            {
                bool deleted = await _candidate_TalentGroupRepository.RemoveByTalentGroupId(talentGroupId);

                if (deleted)
                    return Ok(new { message = "Grupo de talento borrado exitosamente" });
                else
                    return NotFound(new { message = "No se pudo borrar el grupo de talento" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("deleteAllTGsWithNotExistsCandidate")]
        public async Task<IActionResult> DeleteAllTGsWithNotExistsCandidate()
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                List<Candidate_TG> candidate_talentGroups = await _companyRemoteRepository.GetCandidate_TalentGroups(values);

                if (candidate_talentGroups != null && candidate_talentGroups.Count > 0)
                {
                    foreach (Candidate_TG candidate_talentGroup in candidate_talentGroups)
                    {
                        Candidate candidate = await _candidateRepository.GetByCandidateId(candidate_talentGroup.candidateId);

                        if (candidate == null)
                        {
                            bool idDeletedCandidate = await _candidate_TalentGroupRepository.RemoveByTalentGroupId(candidate_talentGroup.candidate_TalentGroupId);

                            bool idDeletedCompany = await _companyRemoteRepository.DeleteCandidate_TalentGroupsById(candidate_talentGroup.candidate_TalentGroupId, values);
                        }
                    }
                }

                return Ok(new { message = "Grupos de talento borrados exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
