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
    public class Candidate_PostulationController : ControllerBase
    {
        private readonly ICandidate_PostulationRepository _candidate_PostulationRepository;
        private readonly ICandidateRepository _candidateRepository;
        private readonly ICompanyRemoteRepository _companyRemoteRepository;

        private readonly IMapper _mapper;

        public Candidate_PostulationController(ICandidate_PostulationRepository candidate_PostulationRepository,
                                               ICandidateRepository candidateRepository,
                                               ICompanyRemoteRepository companyRemoteRepository,
                                               IMapper mapper)
        {
            _candidate_PostulationRepository = candidate_PostulationRepository;
            _candidateRepository = candidateRepository;
            _companyRemoteRepository = companyRemoteRepository;

            _mapper = mapper;
        }

        [HttpGet("createAllCandidatePostulations")]
        public async Task<ObjectResult> CreateCandidatePostulationByPostulation()
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                List<Postulation> postulations = await _companyRemoteRepository.GetPostulations(values);

                if (postulations != null && postulations.Count > 0)
                {
                    foreach (Postulation postulation in postulations)
                    {
                        JobIdNameDTO job = await _companyRemoteRepository.GetJobMiniById(postulation.jobId);

                        Candidate_Postulation candidatePostulation = new Candidate_Postulation
                        {
                            CandidateId = postulation.candidateId,
                            PostulationId = postulation.postulationId,
                            CompanyUserId = postulation.companyUserId,
                            JobPostingStatusId = job.JobPostingStausId,
                            JobId = postulation.jobId
                        };

                        try
                        {
                            Candidate candidate = await _candidateRepository.GetByCandidateId(postulation.candidateId);

                            List<Candidate_Postulation> candidate_postulations = await _candidate_PostulationRepository.GetByPostulationId(postulation.postulationId);

                            if (candidate != null && candidate_postulations == null || candidate_postulations.Count == 0)
                                await _candidate_PostulationRepository.Add(candidatePostulation);
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }

                return StatusCode(200, new { message = "Relaciones entre postulaciones existentes y candidatos creadas exitosamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCandidatePostulation([FromBody] Candidate_PostulationDTO candidatePostulationDTO)
        {
            try
            {
                bool candidateExists = _candidateRepository.CandidateExistById(candidatePostulationDTO.CandidateId);

                if (!candidateExists)
                    return BadRequest(new { message = "El candidato no existe" });

                Candidate_Postulation candidatePostulation = _mapper.Map<Candidate_PostulationDTO, Candidate_Postulation>(candidatePostulationDTO);

                bool isCreated = await _candidate_PostulationRepository.Add(candidatePostulation);

                if (isCreated)
                    return StatusCode(200, new { message = "La postulación fue creadas exitosamente", obj = candidatePostulation });

                return StatusCode(400, new { message = "La postulación no fue creada" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("anon")]
        public async Task<IActionResult> AddCandidatePostulationAnonymous([FromBody] Candidate_PostulationDTO candidatePostulationDTO)
        {
            try
            {
                bool candidateExists = _candidateRepository.CandidateExistById(candidatePostulationDTO.CandidateId);

                if (!candidateExists)
                    return BadRequest(new { message = "El candidato no existe" });

                Candidate_Postulation candidatePostulation = _mapper.Map<Candidate_PostulationDTO, Candidate_Postulation>(candidatePostulationDTO);

                bool isCreated = await _candidate_PostulationRepository.Add(candidatePostulation);

                if (isCreated)
                    return StatusCode(200, new { message = "La postulación fue creadas exitosamente", obj = candidatePostulation });

                return StatusCode(400, new { message = "La postulación no fue creada" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("editJobPostingStatus/{postulationId}/{jobPostingStatusId}")]
        public async Task<IActionResult> EditJobPostingStatus(int postulationId, int jobPostingStatusId)
        {
            try
            {
                List<Candidate_Postulation> candidatePostulations = await _candidate_PostulationRepository.GetByPostulationId(postulationId);

                if (candidatePostulations != null && candidatePostulations.Count > 0)
                {
                    foreach(Candidate_Postulation candidatePostulation in candidatePostulations)
                    {
                        candidatePostulation.JobPostingStatusId = jobPostingStatusId;

                        //if (jobPostingStatusId != 4 && jobPostingStatusId != 5)
                        {
                            bool isUpdated = await _candidate_PostulationRepository.Update(candidatePostulation);
                        }
                        //else
                        {
                            //await _candidate_PostulationRepository.Remove(candidatePostulation.Candidate_PostulationId);
                        }
                    }
                }

                return StatusCode(200, new { message = "La postulación fue editada exitosamente", obj = candidatePostulations });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("deleteByPostulationId/{postulationId}")]
        public async Task<IActionResult> DeleteByPostulationId(int postulationId)
        {
            try
            {
                bool deleted = await _candidate_PostulationRepository.RemoveByPostulationId(postulationId);
                
                if (deleted)
                    return Ok(new { message = "Postulación borrada exitosamente" });
                else
                    return NotFound(new { message = "No se pudo borrar la postulación" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpDelete("deleteByPostulationIdAnon/{postulationId}")]
        public async Task<IActionResult> DeleteByPostulationIdAnonymous(int postulationId)
        {
            try
            {
                bool deleted = await _candidate_PostulationRepository.RemoveByPostulationId(postulationId);

                if (deleted)
                    return Ok(new { message = "Postulación borrada exitosamente" });
                else
                    return NotFound(new { message = "No se pudo borrar la postulación" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("deleteAllPostulationsWithNotExistsCandidate")]
        public async Task<IActionResult> DeleteAllPostulationsWithNotExistsCandidate()
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                List<Postulation> postulations = await _companyRemoteRepository.GetPostulations(values);

                if (postulations != null && postulations.Count > 0)
                {
                    foreach (Postulation postulation in postulations)
                    {
                        Candidate candidate = await _candidateRepository.GetByCandidateId(postulation.candidateId);

                        if (candidate == null)
                        {
                            bool idDeletedCandidate = await _candidate_PostulationRepository.RemoveByPostulationId(postulation.postulationId);

                            bool idDeletedCompany = await _companyRemoteRepository.DeletePostulationsById(postulation.postulationId, values);
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

        [HttpDelete("deleteAllPostulationsOnlyInCandidate")]
        public async Task<IActionResult> DeleteAllPostulationsOnlyInCandidate()
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                List<Candidate_Postulation> candidate_Postulations = await _candidate_PostulationRepository.GetAll();

                List<Postulation> postulations = await _companyRemoteRepository.GetPostulations(values);

                List<Candidate_Postulation> candidate_PostulationsToLocalDelete = new List<Candidate_Postulation>();

                if (candidate_Postulations != null && candidate_Postulations.Count > 0)
                {
                    foreach (Candidate_Postulation candidate_Postulation in candidate_Postulations)
                    {
                        bool exists = false;

                        int countLocal = 0;

                        if (postulations != null && postulations.Count > 0)
                        {
                            foreach (Postulation postulation in postulations)
                            {
                                if(candidate_Postulation.PostulationId == postulation.postulationId)
                                {
                                    exists = true;
                                }
                            }
                        }

                        foreach (Candidate_Postulation candidate_Postulation2 in candidate_Postulations)
                        {
                            if (candidate_Postulation.PostulationId == candidate_Postulation2.PostulationId)
                            {
                                countLocal++;
                            }
                        }

                        if (!exists)
                        {
                            bool idDeletedCandidate = await _candidate_PostulationRepository.RemoveByPostulationId(candidate_Postulation.PostulationId);

                            bool idDeletedCompany = await _companyRemoteRepository.DeletePostulationsById(candidate_Postulation.PostulationId, values);
                        }

                        if (countLocal > 1)
                        {
                            candidate_PostulationsToLocalDelete.Add(candidate_Postulation);
                        }
                    }
                }

                if (postulations != null && postulations.Count > 0)
                {
                    foreach (Postulation postulation in postulations)
                    {
                        bool exsistBoth = false;

                        if (candidate_Postulations != null && candidate_Postulations.Count > 0)
                        {
                            foreach (Candidate_Postulation candidate_Postulation in candidate_Postulations)
                            {
                                if (postulation.postulationId == candidate_Postulation.PostulationId)
                                {
                                    exsistBoth = true;

                                    break;
                                }
                            }
                        }

                        if (!exsistBoth)
                        {
                            bool idDeletedCompany = await _companyRemoteRepository.DeletePostulationsById(postulation.postulationId, values);
                        }
                    }
                }

                if (candidate_PostulationsToLocalDelete != null && candidate_PostulationsToLocalDelete.Count > 0)
                {
                    foreach (Candidate_Postulation candidate_PostulationToLocalDelete in candidate_PostulationsToLocalDelete)
                    {
                        bool idDeletedCandidate = await _candidate_PostulationRepository.RemoveByPostulationId(candidate_PostulationToLocalDelete.PostulationId);
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
