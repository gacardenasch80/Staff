using AutoMapper;
using CandidatesMS.Models;
using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.Models.RemoteModels.Out;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using CandidatesMS.Repositories.RemoteRepositories;
using CandidatesMS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Controllers.RemoteControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruiteeController : ControllerBase
    {
        private ICandidateRepository _candidateRepository;
        private IEmailRepository _emailRepository;
        private IRecruiteeRemoteRepository _recruiteeRepository;
        private IBasicInformationRepository _basicInformationRepository;
        private IMigrationService _migrationService;
        private IPhoneRepository _phoneRepository;
        private IMapper _mapper;

        public RecruiteeController(IRecruiteeRemoteRepository recruiteeRepository, ICandidateRepository candidateRepository, 
                                    IPhoneRepository phoneRepository, IEmailRepository emailRepository,
                                   IMigrationService migrationService, IMapper mapper, IBasicInformationRepository basicInformationRepository)
        {
            _phoneRepository = phoneRepository;
            _emailRepository = emailRepository;
            _basicInformationRepository = basicInformationRepository;
            _candidateRepository = candidateRepository;
            _recruiteeRepository = recruiteeRepository;
            _migrationService = migrationService;
            _mapper = mapper;
        }

        [HttpGet("candidates")]
        public async Task<IActionResult> GetAllCandidates()
        {
            try
            {
                List<RecruiteeCandidateInDTO> candidates = await _recruiteeRepository.GetCandidates();

                if (candidates != null && candidates.Count > 0)
                {
                    List<RecruiteeCandidateOutDTO> candidatesDTO = _mapper.Map<List<RecruiteeCandidateInDTO>, List<RecruiteeCandidateOutDTO>>(candidates);

                    return Ok(new { message = "Candidatos consultados exitosamente", obj = candidatesDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron candidatos" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("migratecandidates")]
        public async Task<IActionResult> AddAllCandidates()
        {
            StringValues values = "";
            Request.Headers.TryGetValue("Authorization", out values);
            try
            {
                List<RecruiteeCandidateInDTO> candidates = await _recruiteeRepository.GetCandidates();

                if (candidates == null || candidates.Count == 0)
                    return NotFound(new { message = "No se encontraron candidatos" });

                List<RecruiteeCandidateOutDTO> candidatesDTO = _mapper.Map<List<RecruiteeCandidateInDTO>, List<RecruiteeCandidateOutDTO>>(candidates);

                var response = await _migrationService.MigrateCandidates(candidatesDTO, values.ToString());

                //foreach (var cand in candidates) { 
                    //RecruiteeCandidateInDTO candidate = await _recruiteeRepository.GetCandidateById((int)cand.candidate.id);
                    //Candidate candidateCreated = new Candidate() { };

                    //candidateCreated.Email = candidate.candidate.emails[0];
                    //candidateCreated.CandidateGuid = Convert.ToString(Guid.NewGuid());
                    //candidateCreated.CreationDate = DateTime.Now.ToString();
                        
                    //bool created = await _candidateRepository.Add(candidateCreated);
                    //Candidate newCandidate = await _candidateRepository.GetByEmail(candidateCreated.Email);

                    //BasicInformation basicInformation = new BasicInformation()
                    //{
                    //    CandidateId = newCandidate.CandidateId,
                    //    Name = cand.candidate.name,
                    //    DocumentTypeId = 2
                    //};

                    //var basicInfo = await _basicInformationRepository.Add(basicInformation);
                    //var newBasicInfo = await _basicInformationRepository.GetByCandidateId(newCandidate.CandidateId);

                    //if(cand.candidate.phones.Count > 0)
                    //{
                    //    var phone = new Phone()
                    //    {
                    //        BasicInformationId = newBasicInfo.BasicInformationId,
                    //        Number = cand.candidate.phones[0]
                    //    };
                    //    var newphone = _phoneRepository.Add(phone);
                    //}
                    //var nEmails = cand.candidate.emails.Count;
                    //if (nEmails > 1)
                    //{
                    //    List<Email> emails = new List<Email>();
                    //    for (int i = 1; i < nEmails; i++)
                    //    {
                    //        Email email = new Email();
                    //        email.BasicInformationId = newBasicInfo.BasicInformationId;
                    //        email.Mail = cand.candidate.emails[i];
                    //        emails.Add(email);
                    //    }
                    //    await _emailRepository.AddRange(emails);
                    //}

                    //var saved = await _migrationService.SaveCvAsync(cand.candidate.cv_original_url, cand.candidate.name, newCandidate.CandidateId);
                                                
                //}                    
                return Ok(new { message = "Candidatos agregados exitosamente", obj = candidatesDTO });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("migratetags")]
        public async Task<IActionResult> AddAllTags()
        {
            StringValues values = "";
            Request.Headers.TryGetValue("Authorization", out values);
            try
            {
                List<RecruiteeCandidateInDTO> candidates = await _recruiteeRepository.GetExsistsCandidatesAndSecondBigMigration();

                if (candidates == null || candidates.Count == 0)
                    return NotFound(new { message = "No se encontraron candidatos" });

                List<RecruiteeCandidateOutDTO> candidatesDTO = _mapper.Map<List<RecruiteeCandidateInDTO>, List<RecruiteeCandidateOutDTO>>(candidates);

                var response = await _migrationService.MigrateTags(candidatesDTO, values.ToString());
            
                return Ok(new { message = "Tags agregados exitosamente", obj = candidatesDTO });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("migratePhotos")]
        public async Task<IActionResult> AddAllPhotos()
        {
            StringValues values = "";
            Request.Headers.TryGetValue("Authorization", out values);
            try
            {
                List<RecruiteeCandidateInDTO> candidates = await _recruiteeRepository.GetExsistsCandidates();

                if (candidates == null || candidates.Count == 0)
                    return NotFound(new { message = "No se encontraron candidatos" });

                List<RecruiteeCandidateOutDTO> candidatesDTO = _mapper.Map<List<RecruiteeCandidateInDTO>, List<RecruiteeCandidateOutDTO>>(candidates);

                var response = await _migrationService.MigratePhotos(candidatesDTO, values.ToString());

                return Ok(new { message = "Tags agregados exitosamente", obj = candidatesDTO });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("migrateCVs")]
        public async Task<IActionResult> AddAllCVs()
        {
            StringValues values = "";
            Request.Headers.TryGetValue("Authorization", out values);
            try
            {
                List<RecruiteeCandidateInDTO> candidates = await _recruiteeRepository.GetExsistsCandidates();

                if (candidates == null || candidates.Count == 0)
                    return NotFound(new { message = "No se encontraron candidatos" });

                List<RecruiteeCandidateOutDTO> candidatesDTO = _mapper.Map<List<RecruiteeCandidateInDTO>, List<RecruiteeCandidateOutDTO>>(candidates);

                var response = await _migrationService.MigrateCVs(candidatesDTO, values.ToString());

                return Ok(new { message = "CVs agregadas exitosamente", obj = candidatesDTO });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("migrateNotes")]
        public async Task<IActionResult> AddAllNotes()
        {
            StringValues values = "";
            Request.Headers.TryGetValue("Authorization", out values);

            try
            {
                List<CandidateRecruiteeInDTO> candidates = await _recruiteeRepository.GetExsistsCandidatesSingle();

                if (candidates == null || candidates.Count == 0)
                    return NotFound(new { message = "No se encontraron candidatos" });

                var response = await _migrationService.MigrateNotes(candidates);

                return Ok(new { message = "Notas agregadas exitosamente", obj = response });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("migratenulls")]
        public async Task<IActionResult> HaveWorkExpNull()
        {
            StringValues values = "";
            Request.Headers.TryGetValue("Authorization", out values);
            try
            {
                List<RecruiteeCandidateInDTO> candidates = await _recruiteeRepository.GetExsistsCandidates();

                if (candidates == null || candidates.Count == 0)
                    return NotFound(new { message = "No se encontraron candidatos" });

                List<BasicInformation> basicInformations = new List<BasicInformation>();

                foreach(RecruiteeCandidateInDTO candidate in candidates)
                {
                    try
                    {
                        Candidate oldCandidate = await _candidateRepository.GetByEmail(candidate.candidate.emails[0]);

                        BasicInformation basicInformation = await _basicInformationRepository.GetByCandidateId(oldCandidate.CandidateId);

                        await _basicInformationRepository.Update(basicInformation);

                        basicInformations.Add(basicInformation);
                    }
                    catch(Exception e)
                    {
                        continue;
                    }
                }

                return Ok(new { message = "Campos puestos en null exitosamente", obj = basicInformations });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("Getcandidateswhitwoutmail")]
        public async Task<IActionResult> GetCandidatesWhitOutMail()
        {
            try
            {
                List<RecruiteeCandidateInDTO> candidates = await _recruiteeRepository.GetCandidatesWhitOutMail();

                if (candidates != null && candidates.Count > 0)
                {
                    List<RecruiteeCandidateOutDTO> candidatesDTO = _mapper.Map<List<RecruiteeCandidateInDTO>, List<RecruiteeCandidateOutDTO>>(candidates);
                    
                    return Ok(new { message = "Candidatos consultados exitosamente", obj = candidatesDTO });
                }
                else
                {
                    return NotFound(new { message = "No se encontraron candidatos" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpGet("candidatescv")]
        public async Task<IActionResult> GetAllCandidatesCV()
        {
            try
            {
                bool isDownloaded = false;
                isDownloaded = await _recruiteeRepository.GetCandidatesCV();

                if (isDownloaded)
                {
                    return Ok(new { message = "Hojas de vida descargadas exitosamente" });
                }
                else
                {
                    return NotFound(new { message = "No se descargaron las hojas de vida" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("candidates/{candidateId}")]
        public async Task<IActionResult> GetCandidateById(int candidateId)
        {
            try
            {
                RecruiteeCandidateInDTO candidate = await _recruiteeRepository.GetCandidateById(candidateId);

                if (candidate != null)
                {
                    return Ok(new { message = "Candidato consultado exitosamente", obj = candidate });
                }
                else
                {
                    return NotFound(new { message = "No se encontró el candidato" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("migrateNotExistsCandidates")]
        public async Task<IActionResult> AddNotExistsCandidates()
        {
            StringValues values = "";
            Request.Headers.TryGetValue("Authorization", out values);
            try
            {
                List<RecruiteeCandidateInDTO> candidates = await _recruiteeRepository.GetNotExsistsCandidates();

                if (candidates == null || candidates.Count == 0)
                    return NotFound(new { message = "No se encontraron candidatos" });

                List<RecruiteeCandidateOutDTO> candidatesDTO = _mapper.Map<List<RecruiteeCandidateInDTO>, List<RecruiteeCandidateOutDTO>>(candidates);

                var response = await _migrationService.MigrateCandidates(candidatesDTO, values.ToString());
        
                return Ok(new { message = "Candidatos agregados exitosamente", obj = candidatesDTO });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpGet("raw")]
        public async Task<IActionResult> GetCandidatesFirstInfoRaw()
        {
            bool isCreated = await _recruiteeRepository.GetCandidatesFirstInfoRaw();

            if(isCreated)
                return Ok(new { message = "Candidatos agregados exitosamente", obj = isCreated });

            return BadRequest(new { message = "Nose pudieron agregar los candidatos", obj = isCreated });
        }

        [AllowAnonymous]
        [HttpGet("raw/other")]
        public async Task<IActionResult> GetCandidatesSecondInfoRaw()
        {
            bool isUpdated = await _recruiteeRepository.GetCandidatesSecondInfoRaw();

            if (isUpdated)
                return Ok(new { message = "Candidatos editados exitosamente", obj = isUpdated });

            return BadRequest(new { message = "No se pudieron editados los candidatos", obj = isUpdated });
        }

        [AllowAnonymous]
        [HttpGet("raw/notes")]
        public async Task<IActionResult> GetCandidateNotesRaw()
        {
            bool isUpdated = await _recruiteeRepository.GetNotesRaw();

            if (isUpdated)
                return Ok(new { message = "Candidatos editados exitosamente", obj = isUpdated });

            return BadRequest(new { message = "No se pudieron editados los candidatos", obj = isUpdated });
        }

        [AllowAnonymous]
        [HttpGet("raw/cvsphotos")]
        public async Task<IActionResult> GetCandidateCVsAndPhotosRaw()
        {
            List<bool> ans = new List<bool>();
            ans.Add(false);
            ans.Add(false);

            bool isUpdated1 = await _recruiteeRepository.GetCVsRaw();

            if (isUpdated1)
                ans[0] = true;

            bool isUpdated2 = await _recruiteeRepository.GetPhotosRaw();

            if (isUpdated2)
                ans[1] = true;

            return Ok(new { message = "Candidatos editados exitosamente", obj = ans });
        }
    }
}
