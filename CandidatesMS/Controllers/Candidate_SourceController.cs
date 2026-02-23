using AutoMapper;
using CandidatesMS.Models;
using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.Infraestructure;
using CandidatesMS.Repositories;
using CandidatesMS.Repositories.RemoteRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Candidate_SourceController : ControllerBase
    {
        private readonly ICandidate_SourceRepository _candidate_SourceRepository;
        private readonly ICandidateRepository _candidateRepository;
        private readonly ICompanyRemoteRepository _companyRemoteRepository;

        private readonly IMapper _mapper;

        public Candidate_SourceController(ICandidate_SourceRepository candidate_SourceRepository,
                                               ICandidateRepository candidateRepository,
                                               ICompanyRemoteRepository companyRemoteRepository,
                                               IMapper mapper)
        {
            _candidate_SourceRepository = candidate_SourceRepository;
            _candidateRepository = candidateRepository;
            _companyRemoteRepository = companyRemoteRepository;

            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("createAllCandidateSources")]
        public async Task<ObjectResult> CreateCandidateSourceByCandidate()
        {
            try
            {
                int count = 0;

                List<CandidateSourceInDTO> candidate_Sources = await _companyRemoteRepository.GetAllCandidateSources();

                if (candidate_Sources != null && candidate_Sources.Count > 0)
                {
                    foreach (CandidateSourceInDTO candidate_Source in candidate_Sources)
                    {
                        Candidate_Source candidateSource = new Candidate_Source
                        {
                            Candidate_SourceId = candidate_Source.candidate_SourceId,
                            CandidateId = candidate_Source.candidateId,
                            SourceId = candidate_Source.sourceId,
                            CompanyUserId = candidate_Source.companyUserId,
                            Name = candidate_Source.name
                        };

                        try
                        {
                            await _candidate_SourceRepository.Add(candidateSource);

                            count++;
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                return StatusCode(200, new { message = "Relaciones entre sources existentes y candidatos creadas exitosamente. Creados: " + count });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCandidateSource([FromBody] Candidate_SourceDTO candidateSourceDTO)
        {
            try
            {
                bool candidateExists = _candidateRepository.CandidateExistById(candidateSourceDTO.CandidateId);

                if (!candidateExists)
                    return BadRequest(new { message = "El candidato no existe" });

                Candidate_Source candidateTag = _mapper.Map<Candidate_SourceDTO, Candidate_Source>(candidateSourceDTO);

                bool isCreated = await _candidate_SourceRepository.Add(candidateTag);

                if (isCreated)
                    return StatusCode(200, new { message = "La source fue creadas exitosamente", obj = candidateTag });

                return StatusCode(400, new { message = "La source no fue creada" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("anon")]
        public async Task<IActionResult> AddCandidateSourceAnonymous([FromBody] Candidate_SourceDTO candidateSourceDTO)
        {
            try
            {
                bool candidateExists = _candidateRepository.CandidateExistById(candidateSourceDTO.CandidateId);

                if (!candidateExists)
                    return BadRequest(new { message = "El candidato no existe" });

                Candidate_Source candidateSource = _mapper.Map<Candidate_SourceDTO, Candidate_Source>(candidateSourceDTO);

                bool isCreated = await _candidate_SourceRepository.Add(candidateSource);

                if (isCreated)
                    return StatusCode(200, new { message = "La source fue creadas exitosamente", obj = candidateSource });

                return StatusCode(400, new { message = "La source no fue creada" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch]
        public async Task<IActionResult> Edit([FromBody] Candidate_SourceDTO candidateSourceDTO)
        {
            try
            {
                Candidate_Source candidate_Source = _mapper.Map<Candidate_SourceDTO, Candidate_Source>(candidateSourceDTO);

                bool isUpdated = await _candidate_SourceRepository.Update(candidate_Source);

                if(isUpdated)
                    return StatusCode(200, new { message = "La Source fue editada exitosamente", obj = candidate_Source });

                return StatusCode(400, new { message = "La Source no fue editada", obj = candidate_Source });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("anon")]
        public async Task<IActionResult> EditAnon([FromBody] Candidate_SourceDTO candidateSourceDTO)
        {
            try
            {
                Candidate_Source candidate_Source = _mapper.Map<Candidate_SourceDTO, Candidate_Source>(candidateSourceDTO);

                bool isUpdated = await _candidate_SourceRepository.Update(candidate_Source);

                if (isUpdated)
                    return StatusCode(200, new { message = "La Source fue editada exitosamente", obj = candidate_Source });

                return StatusCode(400, new { message = "La Source no fue editada", obj = candidate_Source });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("deleteBySourceId/{sourceId}")]
        public async Task<IActionResult> DeleteBySourceId(int sourceId)
        {
            try
            {
                bool deleted = await _candidate_SourceRepository.RemoveBySourceId(sourceId);

                if (deleted)
                    return Ok(new { message = "Source borrada exitosamente" });
                else
                    return NotFound(new { message = "No se pudo borrar la Source" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpDelete("deleteBySourceIdAnon/{sourceId}")]
        public async Task<IActionResult> DeleteBySourceIdAnon(int sourceId)
        {
            try
            {
                bool deleted = await _candidate_SourceRepository.RemoveBySourceId(sourceId);

                if (deleted)
                    return Ok(new { message = "Source borrada exitosamente" });
                else
                    return NotFound(new { message = "No se pudo borrar la Source" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
