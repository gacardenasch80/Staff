using AutoMapper;
using CandidatesMS.Models;
using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.Infraestructure;
using CandidatesMS.Repositories;
using CandidatesMS.Repositories.RemoteRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Matching;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static CandidatesMS.Models.RemoteModels.In.PostulationRemoteDTO;

namespace CandidatesMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Candidate_TagController : ControllerBase
    {
        private readonly ICandidate_TagRepository _candidate_TagRepository;
        private readonly ICandidateRepository _candidateRepository;
        private readonly ICompanyRemoteRepository _companyRemoteRepository;

        private readonly IMapper _mapper;

        public Candidate_TagController(ICandidate_TagRepository candidate_TagRepository,
                                               ICandidateRepository candidateRepository,
                                               ICompanyRemoteRepository companyRemoteRepository,
                                               IMapper mapper)
        {
            _candidate_TagRepository = candidate_TagRepository;
            _candidateRepository = candidateRepository;
            _companyRemoteRepository = companyRemoteRepository;

            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("createAllCandidateTags")]
        public async Task<ObjectResult> CreateCandidateTagByCandidate()
        {
            try
            {
                List<CandidateTagInDTO> candidate_Tags = await _companyRemoteRepository.GetAllCandidateTags();

                int count = 0;

                if (candidate_Tags != null && candidate_Tags.Count > 0)
                {
                    foreach (CandidateTagInDTO candidate_Tag in candidate_Tags)
                    {
                        Candidate_Tag candidateTag = new Candidate_Tag
                        {
                            Candidate_TagId = candidate_Tag.candidate_TagId,
                            CandidateId = candidate_Tag.candidateId,
                            TagId = candidate_Tag.tagId,
                            CompanyUserId = candidate_Tag.companyUserId,
                            Name = candidate_Tag.name
                        };

                        try
                        {
                            Candidate_Tag oldCandidate_Tag = await _candidate_TagRepository.GetById(candidate_Tag.candidate_TagId);

                            if (oldCandidate_Tag == null)
                            {
                                await _candidate_TagRepository.Add(candidateTag);

                                count++;
                            }
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                return StatusCode(200, new { message = "Relaciones entre tags existentes y candidatos creadas exitosamente: " + count });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCandidateTag([FromBody] Candidate_TagDTO candidateTagDTO)
        {
            try
            {
                bool candidateExists = _candidateRepository.CandidateExistById(candidateTagDTO.CandidateId);

                if (!candidateExists)
                    return BadRequest(new { message = "El candidato no existe" });

                Candidate_Tag candidateTag = _mapper.Map<Candidate_TagDTO, Candidate_Tag>(candidateTagDTO);

                bool isCreated = await _candidate_TagRepository.Add(candidateTag);

                if (isCreated)
                    return StatusCode(200, new { message = "La tag fue creadas exitosamente", obj = candidateTag });

                return StatusCode(400, new { message = "La tag no fue creada" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("anon")]
        public async Task<IActionResult> AddCandidateTagAnonymous([FromBody] Candidate_TagDTO candidateTagDTO)
        {
            try
            {
                bool candidateExists = _candidateRepository.CandidateExistById(candidateTagDTO.CandidateId);

                if (!candidateExists)
                    return BadRequest(new { message = "El candidato no existe" });

                Candidate_Tag candidateTag = _mapper.Map<Candidate_TagDTO, Candidate_Tag>(candidateTagDTO);

                bool isCreated = await _candidate_TagRepository.Add(candidateTag);

                if (isCreated)
                    return StatusCode(200, new { message = "La tag fue creadas exitosamente", obj = candidateTag });

                return StatusCode(400, new { message = "La tag no fue creada" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch]
        public async Task<IActionResult> Edit([FromBody] Candidate_TagDTO candidateTagDTO)
        {
            try
            {
                Candidate_Tag candidate_Tag = _mapper.Map<Candidate_TagDTO, Candidate_Tag>(candidateTagDTO);

                bool isUpdated = await _candidate_TagRepository.Update(candidate_Tag);

                if (isUpdated)
                    return StatusCode(200, new { message = "La Tag fue editada exitosamente", obj = candidate_Tag });

                return StatusCode(400, new { message = "La Tag no fue editada", obj = candidate_Tag });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("anon")]
        public async Task<IActionResult> EditAnon([FromBody] Candidate_TagDTO candidateTagDTO)
        {
            try
            {
                Candidate_Tag candidate_Tag = _mapper.Map<Candidate_TagDTO, Candidate_Tag>(candidateTagDTO);

                bool isUpdated = await _candidate_TagRepository.Update(candidate_Tag);

                if (isUpdated)
                    return StatusCode(200, new { message = "La Tag fue editada exitosamente", obj = candidate_Tag });

                return StatusCode(400, new { message = "La Tag no fue editada", obj = candidate_Tag });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("deleteByTagId/{tagId}")]
        public async Task<IActionResult> DeleteByTagId(int tagId)
        {
            try
            {
                bool deleted = await _candidate_TagRepository.RemoveByTagId(tagId);

                if (deleted)
                    return Ok(new { message = "Tag borrada exitosamente" });
                else
                    return NotFound(new { message = "No se pudo borrar la Tag" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpDelete("deleteByTagIdAnon/{tagId}")]
        public async Task<IActionResult> DeleteByTagIdAnon(int tagId)
        {
            try
            {
                bool deleted = await _candidate_TagRepository.RemoveByTagId(tagId);

                if (deleted)
                    return Ok(new { message = "Tag borrada exitosamente" });
                else
                    return NotFound(new { message = "No se pudo borrar la Tag" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
