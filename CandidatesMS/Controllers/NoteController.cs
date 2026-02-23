using AutoMapper;
using CandidatesMS.KeyVault.SecretsModels;
using CandidatesMS.Models;
using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.Models.RemoteModels.Out;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using CandidatesMS.Repositories.RemoteRepositories;
using CandidatesMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using S3bucketDemo.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CandidatesMS.Controllers
{    
    [ApiController]
    [Route("api/note")]
    public class NoteController : ControllerBase
    {
        private readonly ICandidateRepository _candidateRepository;
        private readonly INoteRepository _noteRepository;
        private IMapper _mapper;
        private readonly IAWSS3FileService _AWSS3FileService;
        private readonly IValidateMethodsService _validateMethodsService;
        private IAttachedFileRepository _attachedFileRepository;
        private IUploadTimeService _uploadTimeService;
        private IMatchServerDate _matchServerDate;
        private ICompanyRemoteRepository _companyRemoteRepository;
        private IMentionMemberUserRepository _mentionMemberUserRepository;
        private IBasicInformationRepository _basicInformationRepository;
        private readonly IHttpClientFactory _httpClient;
        private readonly ServiceConfigurationDTO _settings;

        public NoteController(ICandidateRepository candidateRepository, INoteRepository noteRepository, IMapper mapper, IAWSS3FileService aWSS3FileService, 
            IAttachedFileRepository attachedFileRepository, IUploadTimeService uploadTimeService, IMatchServerDate matchServerDate,
            IValidateMethodsService validateMethodsService,
            ICompanyRemoteRepository companyRemoteRepository, IMentionMemberUserRepository mentionMemberUserRepository,
            IBasicInformationRepository basicInformationRepository, IHttpClientFactory httpClient, IOptions<ServiceConfigurationDTO> settings)
        {
            _candidateRepository = candidateRepository;
            _noteRepository = noteRepository;
            _mapper = mapper;
            _AWSS3FileService = aWSS3FileService;
            _validateMethodsService = validateMethodsService;
            _attachedFileRepository = attachedFileRepository;
            _uploadTimeService = uploadTimeService;
            _matchServerDate = matchServerDate;
            _companyRemoteRepository = companyRemoteRepository;
            _mentionMemberUserRepository = mentionMemberUserRepository;
            _basicInformationRepository = basicInformationRepository;
            _httpClient = httpClient;
            _settings = settings.Value;
        }
        
        [HttpGet()]
        public async Task<ObjectResult> GetAllNotes()
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                List<Note> notesFromRepo = await _noteRepository.GetAll();

                if (notesFromRepo == null)
                {
                    return NotFound(new { message = "No existe notas" });
                }
                else
                {
                    List<NoteDTO> noteDTOs = _mapper.Map<List<Note>, List<NoteDTO>>(notesFromRepo);

                    foreach (var noteDTO in noteDTOs)
                    {
                        string creationInfo = _uploadTimeService.GetNoteCreationInfo(noteDTO.CreationDate);
                        string creationShortInfo = _uploadTimeService.GetNoteCreationShortInfo(noteDTO.CreationDate);

                        //var memberUser = await _companyRemoteRepository.GetMemberUserById(noteDTO.MemberId, values.ToString());
                        //noteDTO.NameMemberUser = memberUser.Name;
                        //noteDTO.SurnameMemberUser = memberUser.Surname;
                        noteDTO.NameMemberUser = noteDTO.NameMemberUser;
                        noteDTO.SurnameMemberUser = noteDTO.SurnameMemberUser;
                        noteDTO.CreationInfo = creationInfo;
                        noteDTO.CreationShortInfo = creationShortInfo;
                        noteDTO.CreationInfoPup = Convert.ToDateTime(noteDTO.CreationDate).ToString("dd MMM yyyy h:mm tt", new CultureInfo("es-CO"));
                    }

                    return Ok(new { message = "Notas consultadas exitosamente", obj = noteDTOs });
                }                
            }
            catch (ArgumentException e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("candidate/numberNotes/{candidateId}")]
        public async Task<IActionResult> GetNotesNumberByCandidateId(int candidateId)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                int numberNotes = await _noteRepository.NumberNotesByCandidateId(candidateId);

                return Ok(new { message = "Numero de notas consultadas exitosamente", obj = numberNotes });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("candidate/numberNotesCandidateAndCompany/{candidateId}/{companyUserId}")]
        public async Task<IActionResult> GetNotesNumberCandidateAndCompanyByCandidateId(int candidateId, int companyUserId)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                int numberNotes = await _noteRepository.NumberNotesByCandidateAndCompanyId(candidateId, companyUserId);

                return Ok(new { message = "Numero de notas consultadas exitosamente", obj = numberNotes });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("candidate/{candidateId}")]
        public async Task<IActionResult> GetNotesByCandidateId(int candidateId)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                //var note = await _noteRepository.GetByCandidateId(candidateId);
                List<Note> notes = await _noteRepository.GetByCandidateId(candidateId);

                if (notes == null)
                {
                    return NotFound(new { message = "No existe el usuario" });
                }
                else
                {
                    List<NoteDTO> noteDTOs = _mapper.Map<List<Note>, List<NoteDTO>>(notes);
                    foreach (var noteDTO in noteDTOs)
                    {
                        string creationInfo = _uploadTimeService.GetNoteCreationInfo(noteDTO.CreationDate);
                        string creationShortInfo = _uploadTimeService.GetNoteCreationShortInfo(noteDTO.CreationDate);

                        var memberUser = await _companyRemoteRepository.GetMemberUserById(noteDTO.MemberId, values.ToString());
                        noteDTO.NameMemberUser = memberUser.Name;
                        noteDTO.SurnameMemberUser = memberUser.Surname;
                        noteDTO.CreationInfo = creationInfo;
                        noteDTO.CreationShortInfo = creationShortInfo;
                        noteDTO.CreationInfoPup = Convert.ToDateTime(noteDTO.CreationDate).ToString("dd MMM yyyy h:mm tt", new CultureInfo("es-CO"));
                    }

                    return Ok(new { message = "La nota asociada al candidato existe", obj = noteDTOs });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("noteId/{noteId}")]
        public async Task<IActionResult> GetNoteById(int noteId)
        {
            try
            {
                var note = await _noteRepository.GetByNoteId(noteId);

                string creationInfo = _uploadTimeService.GetNoteCreationInfo(note.CreationDate);
                string creationShortInfo = _uploadTimeService.GetNoteCreationShortInfo(note.CreationDate);

                if (note == null)
                {
                    return NotFound(new { message = "No existe el usuario" });
                }
                else
                {
                    NoteDTO noteDTO = _mapper.Map<Note, NoteDTO>(note);
                    noteDTO.CreationInfo = creationInfo;
                    noteDTO.CreationShortInfo = creationShortInfo;
                    noteDTO.CreationInfoPup = Convert.ToDateTime(note.CreationDate).ToString("dd MMM yyyy h:mm tt", new CultureInfo("es-CO"));
                    return Ok(new { message = "La nota asociada al candidato existe", obj = noteDTO });
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpPost("{language}")]
        public async Task<IActionResult> AddNote([FromForm] NoteDTO noteDTO, int language)
        {

            try
            {                
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                bool candidateExists = _candidateRepository.CandidateExistById(noteDTO.CandidateId);
                MemberUserRemoteDTO memberUser = await _companyRemoteRepository.GetMemberUserById(noteDTO.MemberId, values.ToString());
                HttpClient client = _httpClient.CreateClient("Companies");
                var url = client.BaseAddress.ToString();
                var path = "";

                if(url.Contains("https://companyms-dev.exsis-recruitment.click"))
                {
                    path = "https://companies-dev.exsis-recruitment.click/candidatos?id=" + noteDTO.CandidateId.ToString();
                }
                else
                {
                    path = "https://www.exstaff.com.co/candidatos?id=" + noteDTO.CandidateId.ToString();
                }

                if (!candidateExists)
                    return StatusCode(404, new { message = "El candidato no existe." });

                if (memberUser == null)
                    return StatusCode(404, new { message = "El miembro usuario no existe." });

                Note note = _mapper.Map<NoteDTO, Note>(noteDTO);
                note.CreationDate = _matchServerDate.CreateServerDate();
                note.PinUp = false;
                note.DatePinUp = Convert.ToDateTime("01/01/0001 00:00:00");
                note.NameMemberUser = memberUser.Name;
                note.SurnameMemberUser = memberUser.Surname;
                note.EmailMember = memberUser.Email;
                note.CompanyUserId = memberUser.CompanyUserId;

                List<string> membersNames = new List<string>();
                List<string> emails = new List<string>();

                if (noteDTO.FormFile != null)
                {
                    var result = await _AWSS3FileService.UploadFile(noteDTO.FormFile, "AttachedFilesNotes");

                    if (result == null)
                        return BadRequest(result);
                    else
                    {
                        note.FileIdentifier = result;
                        note.FileName = noteDTO.FormFile.FileName;
                        note.FileUploadDate = _matchServerDate.CreateServerDate();
                    }
                }
          
                var createdNote = await _noteRepository.Add(note);

                if (createdNote != null)
                {
                    if (noteDTO.Ids != null)
                    {
                        List<MemberUserRemoteDTO> memberUsers = new List<MemberUserRemoteDTO>();
                        foreach (var memberUserId in noteDTO.Ids)
                        {
                            var memberTemp = await _companyRemoteRepository.GetMemberUserById(memberUserId, values.ToString());
                            if (memberTemp != null)
                                memberUsers.Add(memberTemp);
                        }
                            
                        List<MentionMemberUser> mentionMemberUsersList = new List<MentionMemberUser>();

                        foreach (var member in memberUsers)
                        {
                            MentionMemberUser mentionMemberUser = new MentionMemberUser()
                            {
                                MemberId = member.MemberUserId,
                                NoteId = createdNote.NoteId
                            };
                            mentionMemberUsersList.Add(mentionMemberUser);
                            var name = member.Name + " " + member.Surname;
                            membersNames.Add(name);
                            emails.Add(member.Email);
                        }                           

                        await _mentionMemberUserRepository.AddRange(mentionMemberUsersList);
                    }

                    var candidate = await _basicInformationRepository.GetByCandidateId(createdNote.CandidateId);
                    var initialName = createdNote.NameMemberUser[0];
                    var initialSurnameName = createdNote.SurnameMemberUser[0];
                    var initials = initialName + "" + initialSurnameName;
                    var nameCreator = createdNote.NameMemberUser + " " + createdNote.SurnameMemberUser;
                    var nameCandidate = candidate.Name + " " + candidate.Surname;
                    
                    DataMentionEmailDTO dataMentionEmailDTO = new DataMentionEmailDTO()
                    {
                        CreatorName = nameCreator,
                        CreatorInitials = initials,
                        CandidateName = nameCandidate,                        
                        MembersNames = membersNames,
                        MembersEmails = emails,
                        Description = createdNote.NoteDescription,
                        NoteLink = path,
                        CandidateId = createdNote.CandidateId,
                        Language = language
                    };

                    if(dataMentionEmailDTO != null)
                    {
                        var result = _companyRemoteRepository.AddAndAttachEmailToMemberUser(dataMentionEmailDTO, values.ToString());
                    }

                    NoteDTO noteDTOreq = _mapper.Map<Note, NoteDTO>(createdNote);
                        return Created("", new { message = "Nota almacenada exitosamente", obj = noteDTOreq });
                }                        
                else
                {
                    return BadRequest(new { message = "La nota no fue almacenadoa" });
                }               
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("download/{noteId}")]
        public async Task<FileResult> GetFileDownloadByCandidateId(int noteId)
        {
            byte[] byteArr;
            Note note = await _noteRepository.GetByNoteId(noteId);
            if (note == null)
                return null;
            try
            {
                WebClient client = new WebClient();
                System.Uri uri = new System.Uri("https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + note.FileIdentifier);
                //Stream stream = await client.OpenReadTaskAsync(uri);
                Stream stream = await _AWSS3FileService.GetFile(note.FileIdentifier);

                using (var memoryStream = new MemoryStream())
                {
                    stream.Position = 0;
                    stream.CopyTo(memoryStream);
                    byteArr = memoryStream.ToArray();
                }

                var result = File(byteArr, "application/octet-stream");
                result.FileDownloadName = Regex.Replace(note.FileName, @"[^0-9a-zA-Z.]+", "");

                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        [HttpGet("notesAndAnswers/{candidateId}")]
        public async Task<ObjectResult> GetAllNotesAndAnswers(int candidateId)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);                                

                bool exists = _candidateRepository.CandidateExistById(candidateId);
                var memberResponse = await _companyRemoteRepository.GetMemberUserFromCandidate(values.ToString());
                var memberUserList = await _companyRemoteRepository.GetAllMemberUserByToken(values.ToString());

                if (!exists)
                    return NotFound(new { message = "El candidato no existe", obj = exists });
                if (memberResponse == null)
                    return NotFound(new { message = "El miembro de usuario no puede consultar esta información."});              

                //The owner notes are obtained by pin up date and by creation date in ascending order,
                //at the end of the iteration the list is reversed to deliver the notes in order.
                List<Note> notesOwners = await _noteRepository.GetAllNoteOwners(candidateId, memberResponse.companyUserId);
                List<Note> notesAnswers = await _noteRepository.GetAllNoteAnswers(candidateId, memberResponse.companyUserId);
                List<NoteDTO> notesOwnersDTO = _mapper.Map<List<Note>, List<NoteDTO>>(notesOwners);
                List<NoteDTO> notesAnswersDTO = _mapper.Map<List<Note>, List<NoteDTO>>(notesAnswers);
                                                           

                if (notesOwnersDTO == null || notesOwnersDTO.Count == 0)
                    return NotFound(new { message = "El candidato no tiene notas asociadas." });             
                
                List<NoteDTO> notesListDTO = new List<NoteDTO>();
                

                foreach (var noteOwnerDTO in notesOwnersDTO)
                {
                    var initialsOwner = "";
                    var photoOwner = "";
                    noteOwnerDTO.CreationInfo = _uploadTimeService.GetNoteCreationInfo(noteOwnerDTO.CreationDate);
                    noteOwnerDTO.CreationShortInfo = _uploadTimeService.GetNoteCreationShortInfo(noteOwnerDTO.CreationDate);
                    noteOwnerDTO.CreationInfoPup = _uploadTimeService.GetFileTypeCreationInfoPup(noteOwnerDTO.CreationDate);
                    noteOwnerDTO.SortedDate = _uploadTimeService.GetDateWithString(noteOwnerDTO.CreationDate);
                    if (noteOwnerDTO.FileIdentifier != null)
                        noteOwnerDTO.IdentifierLink = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + noteOwnerDTO.FileIdentifier;
                  
                    var memberAvailableOwner = memberUserList.Where(x => x.email == noteOwnerDTO.EmailMember).FirstOrDefault();                    
             
                    if (memberAvailableOwner != null)
                    {
                        noteOwnerDTO.Available = true;
                        if (memberAvailableOwner.name != null && !string.IsNullOrEmpty(memberAvailableOwner.name) 
                            && memberAvailableOwner.surname != null && !string.IsNullOrEmpty(memberAvailableOwner.surname))
                        {
                            var first = memberAvailableOwner.name[0].ToString();
                            var second = memberAvailableOwner.surname[0].ToString();

                            if (memberAvailableOwner.photo != null)
                                photoOwner = memberAvailableOwner.photo;

                            initialsOwner = (first + second).ToUpper();
                            noteOwnerDTO.InitialsMember = initialsOwner;
                            noteOwnerDTO.NameMemberUser = memberAvailableOwner.name;
                            noteOwnerDTO.SurnameMemberUser = memberAvailableOwner.surname;
                            noteOwnerDTO.PhotoMember = photoOwner;
                        }                       
                    }                        
                    else
                        noteOwnerDTO.Available = false;

                    List<NoteDTO> notesAnswersListDTO = new List<NoteDTO>();
                    foreach (var noteAnswerDTO in notesAnswersDTO)
                    {
                        var initialsAnswer = "";
                        var photoAnswer = "";
                        if (noteAnswerDTO.NoteOwnerId == noteOwnerDTO.NoteId)
                        {
                            noteAnswerDTO.CreationInfo = _uploadTimeService.GetNoteCreationInfo(noteAnswerDTO.CreationDate);
                            noteAnswerDTO.CreationShortInfo = _uploadTimeService.GetNoteCreationShortInfo(noteAnswerDTO.CreationDate);
                            noteAnswerDTO.CreationInfoPup = _uploadTimeService.GetFileTypeCreationInfoPup(noteAnswerDTO.CreationDate);
                                                      
                            var memberAvailableAnswer = memberUserList.Where(x => x.email == noteAnswerDTO.EmailMember).FirstOrDefault();
                            if (noteAnswerDTO.FileIdentifier != null)
                                noteAnswerDTO.IdentifierLink = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + noteAnswerDTO.FileIdentifier;

                            if (memberAvailableAnswer != null)
                            {
                                noteAnswerDTO.Available = true;
                                if (memberAvailableAnswer.name != null && !string.IsNullOrEmpty(memberAvailableAnswer.name)
                                    && memberAvailableAnswer.surname != null && !string.IsNullOrEmpty(memberAvailableAnswer.surname))
                                {
                                    var first = memberAvailableAnswer.name[0].ToString();
                                    var second = memberAvailableAnswer.surname[0].ToString();

                                    if (memberAvailableAnswer.photo != null)
                                        photoAnswer = memberAvailableAnswer.photo;

                                    initialsAnswer = (first + second).ToUpper();
                                    noteAnswerDTO.InitialsMember = initialsAnswer;
                                    noteAnswerDTO.NameMemberUser = memberAvailableAnswer.name;
                                    noteAnswerDTO.SurnameMemberUser = memberAvailableAnswer.surname;
                                    noteAnswerDTO.PhotoMember = photoAnswer;
                                }
                            }
                            else
                                noteAnswerDTO.Available = false;

                            notesAnswersListDTO.Add(noteAnswerDTO);                            
                        }
                    }

                    noteOwnerDTO.notesAnswers = notesAnswersListDTO;                 
                    notesListDTO.Add(noteOwnerDTO);                    
                }
                notesListDTO = notesListDTO.OrderByDescending(x => x.DatePinUp).ThenByDescending(x=> x.SortedDate).ToList();
               
                return Ok(new { message = "Notas consultadas exitosamente", obj = notesListDTO });
            }
            catch (ArgumentException e)
            {
                return BadRequest(e);
            }
        }

        [HttpGet("byNotesByFilterDate/{companyUserId}")]
        public IActionResult GetNotesByFilterDate(int companyUserId)
        {
            try
            {
                DateTime dateFilter = _matchServerDate.GetDateTimeByFilterSixtyDays();

                var notesbd = _noteRepository.GetNotesByFilterDate(dateFilter, companyUserId);

                if (notesbd != null)
                {
                    List<NoteDTO> notesListDTO = _mapper.Map<List<Note>, List<NoteDTO>>(notesbd);
                    return Ok(new { message = "Escalas de valores consultadas exitosamente", obj = notesListDTO });
                }
                else
                    return NotFound(new { message = "No existe escala de valor asociada." });
            }
            catch (ArgumentException e)
            {
                return BadRequest(e);
            }
        }

        [HttpPatch("editPinUp/{noteId}")]
        public async Task<ObjectResult> EditPinUp(int noteId)
        {
            try
            {
                Note note = await _noteRepository.GetById(noteId);
                if (note == null)
                    return NotFound(new { message = "La nota no existe." });

                if (note.NoteOwnerId != 0)
                    return BadRequest(new { message = "No se puede fijar una respuesta." });

                if (note.PinUp)
                {
                    note.PinUp = false;
                    note.DatePinUp = Convert.ToDateTime("01/01/0001 00:00:00");
                }
                else
                {
                    note.PinUp = true;
                    note.DatePinUp = _matchServerDate.GetDateTimeByServer();
                }         

                var editNote = await _noteRepository.Update(note);

                if (editNote)
                {
                    var noteDTO = _mapper.Map<Note, NoteDTO>(note);
                    return Created("", new { message = "Se editó exitosamente.", obj = noteDTO });
                }                    
                else
                    return BadRequest(new { message = "La Información Básica no fue editada." });

        }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPatch("{language}")]
        public async Task<IActionResult> EditNote([FromForm] NoteDTO noteDTO, int language)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                bool noteExist = _noteRepository.NoteExistById(noteDTO.NoteId);
                bool candidateExists = _candidateRepository.CandidateExistById(noteDTO.CandidateId);
                var notedb = await _noteRepository.GetById(noteDTO.NoteId);
                MemberUserRemoteDTO memberUser = await _companyRemoteRepository.GetMemberUserById(noteDTO.MemberId, values.ToString());
                List<MentionMemberUser> membersMention = await _mentionMemberUserRepository.GetMentionsByNoteId(notedb.NoteId);
                List<string> sended = new List<string>();
               

                HttpClient client = _httpClient.CreateClient("Companies");
                var url = client.BaseAddress.ToString();
                var path = "";

                if (url.Contains("https://companyms-dev.exsis-recruitment.click"))
                {
                    path = "https://companies-dev.exsis-recruitment.click/candidatos?id=" + noteDTO.CandidateId.ToString();
                }
                else
                {
                    path = "https://www.exstaff.com.co/candidatos?id=" + noteDTO.CandidateId.ToString();
                }

                if (!noteExist)
                    return NotFound(new { message = "La nota no existe." });
                if (!candidateExists)
                    return NotFound(new { message = "El candidato no existe." });
                if (noteDTO.MemberId != notedb.MemberId || noteDTO.CandidateId != notedb.CandidateId)
                    return BadRequest(new { message = "No tiene permiso para editar nota." });

                var note = _mapper.Map<NoteDTO, Note>(noteDTO);

                notedb.NoteDescription = note.NoteDescription;
                List<string> membersNames = new List<string>();
                List<string> emails = new List<string>();
                List<string> emailsRelation = new List<string>();

                membersMention.ForEach(async x =>{
                    MemberUserRemoteDTO memberUser = await _companyRemoteRepository.GetMemberUserById(x.MemberId, values.ToString());
                    if (memberUser != null)
                        emailsRelation.Add(memberUser.Email);
                });


                if (noteDTO.Ids != null)
                {
                    List<MemberUserRemoteDTO> memberUsers = new List<MemberUserRemoteDTO>();
                    foreach (var memberUserId in noteDTO.Ids)
                    {                        
                        var memberTemp = await _companyRemoteRepository.GetMemberUserById(memberUserId, values.ToString());
                        if (memberTemp != null)
                            memberUsers.Add(memberTemp);
                    }

                    if (memberUsers.Count != 0)
                    {
                        List<MentionMemberUserDTO> mentionMemberUsersDTO = new List<MentionMemberUserDTO>();

                        memberUsers.ForEach(x =>
                        {
                            MentionMemberUserDTO mentionMemberUser = new MentionMemberUserDTO()
                            {
                                MemberId = x.MemberUserId,
                                NoteId = notedb.NoteId
                            };
                            mentionMemberUsersDTO.Add(mentionMemberUser);
                            var name = x.Name + " " + x.Surname;
                            membersNames.Add(name);
                            emails.Add(x.Email);
                        });

                        foreach (var member in emails)
                        {
                            var exist = false;
                            foreach (var id in emailsRelation)
                            {
                                if (member == id)
                                {
                                    exist = true;
                                    break;
                                }
                            }
                            if (!exist)
                                sended.Add(member);
                        }

                        List<MentionMemberUser> mentionMemberUsers = _mapper.Map<List<MentionMemberUserDTO>, List<MentionMemberUser>>(mentionMemberUsersDTO);

                        await _mentionMemberUserRepository.AddRange(mentionMemberUsers);

                        var candidate = await _basicInformationRepository.GetByCandidateId(notedb.CandidateId);
                        var initialName = notedb.NameMemberUser[0];
                        var initialSurnameName = notedb.SurnameMemberUser[0];
                        var initials = initialName + "" + initialSurnameName;
                        var nameCreator = notedb.NameMemberUser + " " + notedb.SurnameMemberUser;
                        var nameCandidate = candidate.Name + " " + candidate.Surname;

                        DataMentionEmailDTO dataMentionEmailDTO = new DataMentionEmailDTO()
                        {
                            CreatorName = nameCreator,
                            CreatorInitials = initials,
                            CandidateName = nameCandidate,
                            MembersNames = membersNames,
                            MembersEmails = sended,
                            Description = notedb.NoteDescription,
                            NoteLink = path,
                            Language = language
                        };

                        if (dataMentionEmailDTO != null)
                        {
                            var result = _companyRemoteRepository.AddAndAttachEmailToMemberUser(dataMentionEmailDTO, values.ToString());
                        }
                    }
                }

                if (noteDTO.FormFile == null && noteDTO.KeepFile)
                {
                    notedb.FileIdentifier = null;
                    notedb.FileName = null;
                    notedb.FileUploadDate = null;
                }

                if (noteDTO.FormFile != null)
                {
                    var result = await _AWSS3FileService.UploadFile(noteDTO.FormFile, "AttachedFilesNotes");

                    if (result == null)
                        return BadRequest(result);
                    else
                    {
                        notedb.FileIdentifier = result;
                        notedb.FileName = noteDTO.FormFile.FileName;
                        notedb.FileUploadDate = _matchServerDate.CreateServerDate();
                    }
                }

                bool edited = await _noteRepository.Update(notedb);

                if(edited)
                {
                    noteDTO = _mapper.Map<Note, NoteDTO>(notedb);
                    return Created("", new { message = "Se editó exitosamente la nota.", obj = noteDTO });
                }
                else
                    return BadRequest(new { message = "La nota no fue editada." });
                              
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete("{noteId}/{memberId}")]
        public async Task<IActionResult> RemoveGuestUserById(int noteId, int memberId)
        {
            StringValues values = "";
            Request.Headers.TryGetValue("Authorization", out values);

            string validation = "DeleteNotesEvaluations";

            bool isAuthorized = await _validateMethodsService.GetResponseValidateActionByPermissionNew(validation, values.ToString());

            bool noteExist = _noteRepository.NoteExistById(noteId);
            var note = await _noteRepository.GetById(noteId);
            MemberUserRemoteDTO memberUser = await _companyRemoteRepository.GetMemberUserById(memberId, values.ToString());

            if (!noteExist)
                return NotFound(new { message = "La nota no existe." });
            if (memberUser == null)
                return NotFound(new { message = "El miembro usuario no existe." });
            if (memberId != note.MemberId && !isAuthorized)
                return BadRequest(new { message = "No tiene permiso para eliminar nota." });

            if (note.NoteOwnerId == 0)
            {
                List<Note> notesAnswers = await _noteRepository.GetAllNoteAnswersByNote(note.NoteId);
                if (notesAnswers.Count != 0)
                {
                    foreach (var noteAnswer in notesAnswers)
                    {
                        await _mentionMemberUserRepository.RemoveMentionByNote(noteAnswer.NoteId);
                        if (noteAnswer.FileIdentifier != null)
                        {
                            noteAnswer.FileIdentifier = null;
                            noteAnswer.FileName = null;
                            noteAnswer.FileUploadDate = null;
                        }
                    }
                    _noteRepository.RemoveRange(notesAnswers);
                }
            }

            if (note.FileIdentifier != null)
            {
                note.FileIdentifier = null;
                note.FileName = null;
                note.FileUploadDate = null;
            }

            await _mentionMemberUserRepository.RemoveMentionByNote(note.NoteId);

            var removed = await _noteRepository.Remove(noteId);

            if (removed != null)
                return StatusCode(200, new { message = "Nota eliminada exitosamente." });
            else
                return StatusCode(404, new { message = "No fue posible eliminar la nota." });
            
            
            
        }

        [HttpDelete("deleteFile/{noteId}/{memberId}")]
        public async Task<IActionResult> DeleteFileNote(int noteId, int memberId)
        {
            StringValues values = "";
            Request.Headers.TryGetValue("Authorization", out values);

            bool noteExist = _noteRepository.NoteExistById(noteId);
            var note = await _noteRepository.GetById(noteId);
            MemberUserRemoteDTO memberUser = await _companyRemoteRepository.GetMemberUserById(memberId, values.ToString());

            if (!noteExist)
                return NotFound(new { message = "La nota no existe." });
            if (memberUser == null)
                return NotFound(new { message = "El miembro usuario no existe." });

            if (memberId == note.MemberId || memberUser.RoleName == "SuperAdministrador")
            {
                note.FileIdentifier = null;
                note.FileName = null;
                note.FileUploadDate = null;

                bool edited = await _noteRepository.Update(note);

                if (edited)
                {
                    NoteDTO noteDTO = _mapper.Map<Note, NoteDTO>(note);

                    return Created("", new { message = "Se editó exitosamente la nota.", obj = noteDTO });
                }
                else
                    return BadRequest(new { message = "La nota no fue editada." });
            }
            else
                return BadRequest(new { message = "No tiene permiso para eliminar el archivo de nota." });            
        }


        [HttpGet("sectionCandidate/{page}/{pageSize}")]
        public async Task<IActionResult> GetAllNotesSectionCandidate(int page, int pageSize)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                MemberByToken memberResponse = await _companyRemoteRepository.GetMemberUserFromCandidate(values.ToString());

                int companyUserId = 0;

                if (memberResponse != null)
                    companyUserId = memberResponse.companyUserId;

                var notes = await _noteRepository.GetCandidateSection(page, pageSize, companyUserId, values.ToString());
                return Ok(new { message = "Informaciones básicas consultadas exitosamente", obj = notes});
               
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("SectionCandidateSearch")]
        public async Task<IActionResult> GetAllNotesSectionCandidateSearch([FromBody] SearchByIdAndTextWithPaginationDTO search)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                MemberByToken memberResponse = await _companyRemoteRepository.GetMemberUserFromCandidate(values.ToString());

                int companyUserId = 0;

                if (memberResponse != null)
                    companyUserId = memberResponse.companyUserId;

                var notes = await _noteRepository.GetCandidateSectionSearch(search, companyUserId, values.ToString());

                return Ok(new { message = "Informaciones básicas consultadas exitosamente", obj = notes });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


    }
}
