using AutoMapper;
using CandidatesMS.KeyVault.SecretsModels;
using CandidatesMS.Models;
using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.Models.RemoteModels.Out;
using CandidatesMS.ModelsCompany;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Persistence.Infraestructure.Services;
using CandidatesMS.Repositories;
using CandidatesMS.Repositories.RemoteRepositories;
using CandidatesMS.RepositoriesCompany;
using CandidatesMS.KeyVault.SecretsModels;
using CandidatesMS.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using MimeKit;
using S3bucketDemo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private IMailRepository _mailRepository;
        private ICandidateRepository _candidateRepository;
        private IMemberUserRepository _memberUserRepository;
        private ICompanyRemoteRepository _companyRemoteRepository;
        private IUploadTimeService _uploadTimeService;
        private IBasicInformationRepository _basicInformationRepository;
        private IMatchServerDate _matchServerDate;
        private IRemoteMailService _remoteMailService;
        private IAWSS3FileService _AWSS3FileService;
        private ICCORepository _ccoRepository;
        private ICCRepository _ccRepository;
        private IRemoteMailRepository _remoteMailRepository; 
        private readonly ServiceConfigurationDTO _settings;
        private IMapper _mapper;

        public MailController(ICandidateRepository candidateRepository, ICompanyRemoteRepository companyRemoteRepository, IMemberUserRepository memberUserRepository,
                              IUploadTimeService uploadTimeService, IMatchServerDate matchServerDate, IMailRepository mailRepository,
                              IBasicInformationRepository basicInformationRepository, IRemoteMailService remoteMailService, IAWSS3FileService AWSS3FileService,
                              ICCORepository ccoRepository, ICCRepository ccRepository, IRemoteMailRepository remoteMailRepository, IOptions<ServiceConfigurationDTO> settings,
                              IMapper mapper)
        {
            _candidateRepository = candidateRepository;
            _companyRemoteRepository = companyRemoteRepository;
            _mailRepository = mailRepository;
            _basicInformationRepository = basicInformationRepository;
            _memberUserRepository = memberUserRepository;
            _uploadTimeService = uploadTimeService;
            _matchServerDate = matchServerDate;
            _remoteMailService = remoteMailService;
            _AWSS3FileService = AWSS3FileService;
            _ccoRepository = ccoRepository;
            _ccRepository = ccRepository;
            _remoteMailRepository = remoteMailRepository;
            _settings = settings.Value;

            _mapper = mapper;
        }

        [RequestSizeLimit(60000000)]
        [HttpPost]
        public async Task<IActionResult> AddMail([FromForm] MailDTO mailDTO)
        {

            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                var candidateExists = await _candidateRepository.GetByCandidateId(mailDTO.CandidateId);
                var memberUser = await _companyRemoteRepository.GetMemberUserFromCandidate(values.ToString());
                var nameMember = "";
                var emailMember = "";
                var emailCandidate = "";
                var companyUserId = 0;
                var nameCandidate = "";

                if (candidateExists == null)
                    return StatusCode(404, new { message = "El candidato no existe." });

                if (memberUser == null)
                    return StatusCode(404, new { message = "El miembro usuario no existe." });

                if (candidateExists.Email != null && !String.IsNullOrEmpty(candidateExists.Email))
                    emailCandidate = candidateExists.Email;
                else
                    return StatusCode(404, new { message = "El correo del candidato no existe." });

                if (candidateExists.BasicInformation.Name != null && candidateExists.BasicInformation.Surname != null)
                    nameCandidate = candidateExists.BasicInformation.Name + " " + candidateExists.BasicInformation.Surname;
                else if (candidateExists.BasicInformation.Name != null && candidateExists.BasicInformation.Surname == null)
                    nameCandidate = candidateExists.BasicInformation.Name;
                
                emailMember = memberUser.email;
                companyUserId = memberUser.companyUserId;
                nameMember = memberUser.name + " " + memberUser.surname;                
                    
                Mail mail = _mapper.Map<MailDTO, Mail>(mailDTO);
                mail.CreationDate = _matchServerDate.CreateServerDate();
                mail.EmailMember = emailMember;
                mail.CompanyUserId = companyUserId;
                mail.NameMemberUser = memberUser.name;
                mail.SurnameMemberUser = memberUser.surname;

                List<AttachedFileMail> linksFiles = new List<AttachedFileMail>();

                if (mailDTO.FormFile != null && mailDTO.FormFile.Count > 0)
                {
                    foreach (FormFile file in mailDTO.FormFile)
                    {
                        string[] fileNameSplit = file.FileName.Split(".");

                        string fileNameWithoutExtension = "";

                        if (fileNameSplit != null && fileNameSplit.Count() > 0)
                        {
                            fileNameWithoutExtension = file.FileName.Replace(fileNameSplit[fileNameSplit.Count() - 1], "");
                        }

                        string fileAddress = await _AWSS3FileService.UploadFilesWithPathBucketName(file, "AttachedFilesRecoveredEmails", 
                            fileNameWithoutExtension.Replace(".", "_").Replace(" ", "") + "_" + mail.EmailMember.Replace(".", "_").Replace(" ", "") + DateTime.Now.Ticks.ToString());

                        AttachedFileMail attachedFile = new AttachedFileMail
                        {
                            CandidateId = candidateExists.CandidateId,
                            EmailMemberUser = mail.EmailMember,
                            NameMemberUser = mail.NameMemberUser,
                            SurnameMemberUser = mail.SurnameMemberUser,
                            Name = file.FileName,
                            UploadDate = DateTime.Now.ToString(),
                            FileIdentifier = fileAddress
                        };

                        linksFiles.Add(attachedFile);
                    }
                }

                mail.AttachedFilesMail = linksFiles;

                var createdMail = await _mailRepository.Add(mail);

                if (createdMail != null)
                {
                    if (mailDTO.CCOString != null && mailDTO.CCOString.Count > 0)
                    {
                        foreach (string em in mailDTO.CCOString)
                        {
                            CCO cco = new CCO()
                            {
                                Email = em,
                                MailId = createdMail.MailId
                            };
                            var created = await _ccoRepository.Add(cco);
                        }
                    }

                    if (mailDTO.CCString != null && mailDTO.CCString.Count > 0)
                    {
                        foreach (string em in mailDTO.CCString)
                        {
                            CC cc = new CC()
                            {
                                Email = em,
                                MailId = createdMail.MailId
                            };
                            var created = await _ccRepository.Add(cc);
                        }
                    }

                    return Created("", new { message = "Mail enviado exitosamente"});
                }
                else
                {
                    return BadRequest(new { message = "Mail no fue enviado" });
                }
            }
            catch (Exception ex)
            {
                if(ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.ToString()))
                    return StatusCode(500, new { message = ex.Message });

                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("candidateId/{candidateId}")]
        public async Task<IActionResult> GetMailsById(int candidateId)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                var memberUser = await _companyRemoteRepository.GetMemberUserFromCandidate(values.ToString());
                var companyUserId = 0;
                if(memberUser != null)                
                    companyUserId = memberUser.companyUserId;                
                else
                    return StatusCode(404, new { message = "El miembro usuario no existe." });


                List<Mail> mailsListbd = await _mailRepository.GetAllMailByCandidateId(candidateId, companyUserId);
                
                if(mailsListbd != null && mailsListbd.Count > 0)
                {
                    List<MailDTO> mailsListDTO = _mapper.Map<List<Mail>, List<MailDTO>>(mailsListbd);
                    var memberUserList = await _companyRemoteRepository.GetAllMemberUserByToken(values.ToString());

                    foreach (var mail in mailsListDTO)
                    {                        
                        foreach (var member in memberUserList)
                        {
                            var photo = "";
                            if (mail.EmailMember == member.email)
                            {
                                if (member.photo != null)
                                    photo = member.photo;

                                var first = member.name[0].ToString();
                                var second = member.surname[0].ToString();
                                var initials = (first + second).ToUpper();  
                                mail.FromPrefix = member.name + " " + member.surname;
                                mail.InitialsFrom = initials;
                                mail.CreationInfo = _uploadTimeService.GetCreationDate(mail.CreationDate);
                                mail.CreationInfoPup = _uploadTimeService.GetFormatColombian(mail.CreationDate);
                                mail.Photo = photo;
                                break;
                            }
                        }
                        if (mail.EmailMember != null)
                        {
                            var memberUserTemp = await _memberUserRepository.GetByEmail(mail.EmailMember);

                            if (memberUserTemp == null)
                            {
                                var first = mail.NameMemberUser[0].ToString();
                                var second = mail.SurnameMemberUser[0].ToString();
                                var initials = (first + second).ToUpper();
                                mail.InitialsFrom = initials;
                                mail.FromPrefix = mail.NameMemberUser + " " + mail.SurnameMemberUser;
                                mail.DeleteMember = true;
                            }
                        }
           

                    }

                    return Ok(new { message = "Mails de candidato consultados exitosamente", obj = mailsListDTO });
                }
                else
                    return NotFound(new { message = "El usuario no tiene Mails asociados" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("mailsWithAnswers/{candidateId}")]
        public async Task<IActionResult> EmailAnswers(int candidateId)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);
                bool isMaster = await _companyRemoteRepository.isMaster(values.ToString());
                int companyUserId = 0;

                if (isMaster)
                {
                    MemberUser memberUser = new();

                    if (_settings.AWSS3.BucketName == "recruitment-bucket-dev")
                        memberUser = await _memberUserRepository.GetByEmail("recruitment_owner@exsis.com.co");
                    else
                        memberUser = await _memberUserRepository.GetByEmail("recruitmentmaster@exsis.com.co");

                    companyUserId = memberUser.CompanyUserId;
                }
                else
                {
                    MemberByToken memberUser = await _companyRemoteRepository.GetMemberUserFromCandidate(values.ToString());
                    if (memberUser != null)
                        companyUserId = memberUser.companyUserId;
                    else
                        return StatusCode(404, new { message = "El miembro usuario no existe." });
                }
                

                List<Mail> mails = await _mailRepository.GetAllMailByCandidateId(candidateId, companyUserId);

                MailsAndAnswersCountsDTO answer = new MailsAndAnswersCountsDTO();
                int countQuestions = 0;
                int countAnswers = 0;

                Candidate candidate = await _candidateRepository.GetById(candidateId);
                BasicInformation basicInformation = await _basicInformationRepository.GetByCandidateId(candidateId);

                List<MailDTO> mailsOutput = new List<MailDTO>();

                List<RemoteMail> recoveredMails = await _remoteMailRepository.GetAllMails();

                

                if (mails != null && mails.Count > 0)
                {
                    List<MailDTO> mailsDTO = _mapper.Map<List<Mail>, List<MailDTO>>(mails);
                    List<MemberUser> memberUserList = [];

                    if (isMaster)
                    {
                        List<MemberUser> memberUserRemoteDTOs = [];

                        MemberUser memberUser = new();

                        if (_settings.AWSS3.BucketName == "recruitment-bucket-dev")
                            memberUser = await _memberUserRepository.GetByEmail("recruitment_owner@exsis.com.co");
                        else
                            memberUser = await _memberUserRepository.GetByEmail("recruitmentmaster@exsis.com.co");

                        memberUserRemoteDTOs.Add(memberUser);


                    }
                    else
                        memberUserList = await _memberUserRepository.GetAllMemberUsersByCompany(companyUserId);

                    foreach (MailDTO mail in mailsDTO)
                    {
                        foreach (var member in memberUserList)
                        {
                            if (mail.EmailMember == member.Email)
                            {
                                string fromPrefix = "";
                                string toPrefix = "";

                                if (mail.EmailMember != null)
                                    fromPrefix = mail.EmailMember;

                                if (candidate.Email != null)
                                    toPrefix = candidate.Email;

                                string first = member.Name[0].ToString();
                                string second = member.Surname[0].ToString();
                                string initials = (first + second).ToUpper();

                                mail.FromPrefix = fromPrefix;
                                mail.ToPrefix = toPrefix;

                                mail.From = mail.NameMemberUser + " " + mail.SurnameMemberUser;

                                if (!string.IsNullOrEmpty(basicInformation.Name))
                                    mail.To = basicInformation.Name;
                                if (!string.IsNullOrEmpty(basicInformation.Surname))
                                    mail.To += " " + basicInformation.Surname;

                                mail.InitialsFrom = initials;
                                mail.CreationInfo = _uploadTimeService.GetCreationDate(mail.CreationDate);
                                mail.CreationInfoPup = _uploadTimeService.GetFormatColombian(mail.CreationDate);
                                mail.Photo = mail.EmailMember == member.Email ? member.Photo : "";

                                break;
                            }
                        }
                    }

                    Tuple<List<MailDTO>, Tuple<int, int>> tuple = await _remoteMailService.GetAnwsersLevelsEmails(mailsDTO, candidate, recoveredMails, countQuestions, countAnswers, true, "");

                    mailsOutput = tuple.Item1;
                    countQuestions = tuple.Item2.Item1;
                    countAnswers = tuple.Item2.Item2;

                    mailsOutput.Reverse();

                    answer.CountOut = countQuestions;
                    answer.CountIn = countAnswers;
                    answer.Mails = mailsOutput;

                    return Ok(new { message = "Mails de candidato consultados exitosamente", obj = answer });
                }
                else
                    return NotFound(new { message = "El usuario no tiene Mails asociados" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpPost("saveImage")]
        public async Task<IActionResult> SaveImage([FromForm] IFormFile file)
        {
            try
            {
                StringValues values = "";
                Request.Headers.TryGetValue("Authorization", out values);

                MemberByToken memberUser = await _companyRemoteRepository.GetMemberUserFromCandidate(values.ToString());

                int companyUserId = 0;
                if (memberUser != null)
                    companyUserId = memberUser.companyUserId;
                else
                    return StatusCode(404, new { message = "El miembro usuario no existe." });

                string fileAddress = await _AWSS3FileService.UploadFilesWithPathBucketName(file, "ImagesInSendedEmails", file.FileName.Replace(".png", "").Replace(".PNG", "")
                    .Replace(".jpg", "").Replace(".JPG", "").Replace(".jpeg", "").Replace(".JPEG", "").Replace(".gif", "").Replace(".GIF", "") + DateTime.Now.Ticks.ToString());

                return Ok(new { message = "Imagen guardada exitosamente", obj = fileAddress });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
