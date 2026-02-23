using AutoMapper;
using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.Infraestructure.Mailer;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using MimeKit;
using S3bucketDemo.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Services
{
    public interface IRemoteMailService
    {
        public Task<List<MimeMessage>> GetEmails();
        Task<Tuple<List<MailDTO>, Tuple<int, int>>> GetAnwsersLevelsEmails(List<MailDTO> mailsDTO, Candidate candidate, List<RemoteMail> recoveredMails, int countQuestions,
            int countAnswers, bool isFirstLevel, string parentMail);
        public Task<List<MailDTO>> GetAnwsersEmails(string from, string to, string fromFull, string toFull, string messageId, List<RemoteMail> inboxList);
        public Task Connect(IImapClient client);
        public Task Disconnect(IImapClient client);
    }

    public class RemoteMailService : IRemoteMailService
    {
        private readonly MailSettingsDTO _mailSettings;
        private IUploadTimeService _uploadTimeService;
        private IAWSS3FileService _AWSS3FileService;
        private IMapper _mapper;

        public RemoteMailService(IOptions<MailSettingsDTO> mailSettings, IUploadTimeService uploadTimeService, IAWSS3FileService AWSS3FileService, IMapper mapper)
        {
            _mailSettings = mailSettings.Value;
            _uploadTimeService = uploadTimeService;
            _AWSS3FileService = AWSS3FileService;
            _mapper = mapper;
        }

        public async Task<List<MimeMessage>> GetEmails()
        {
            try
            {
                List<MailDTO> mails = new List<MailDTO>();

                using (ImapClient client = new ImapClient())
                {
                    //await Disconnect(client);

                    await Connect(client);

                    client.Inbox.Open(FolderAccess.ReadOnly);

                    ImapFolder inbox = (ImapFolder)client.Inbox;

                    List<MimeMessage> inboxList = inbox.Where(x => !string.IsNullOrEmpty(x.InReplyTo)).ToList();

                    return inboxList;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<List<MailDTO>> GetAnwsersEmails(string from, string to, string fromFull, string toFull, string messageId, List<RemoteMail> inboxList)
        {
            List<MailDTO> mails = new List<MailDTO>();

            try
            {
                List<RemoteMail> messages = inboxList.AsEnumerable().Where(x => x.MailOwnerId == messageId).ToList();

                foreach (RemoteMail message in messages)
                {
                    string stringDate = message.CreationDate;

                    var creationInfo = _uploadTimeService.GetCreationDate(stringDate);
                    var creationInfoPup = _uploadTimeService.GetFormatColombian(stringDate);

                    string fromPrefix = "";
                    string toPrefix = "";

                    string[] fromArray = message.From.Split("@");
                    string[] toArray = message.To.Split("@");

                    if (message.From != null)
                        fromPrefix = message.From;

                    if (message.To != null)
                        toPrefix = message.To;

                    List<AttachedFileMailDTO> attachedFiles = new List<AttachedFileMailDTO>();

                    List<AttachedFileRemoteMail> attachments = message.AttachedFilesRemoteMail.ToList();
                    foreach (AttachedFileRemoteMail attachment in attachments)
                    {
                        AttachedFileMailDTO linkAndName = new AttachedFileMailDTO
                        {
                            FileIdentifier = attachment.FileIdentifier,
                            Name = attachment.Name
                        };

                        attachedFiles.Add(linkAndName);
                    }

                    MailDTO mail = new MailDTO()
                    {
                        MessageId = message.MessageId,
                        Subject = message.Subject,
                        MailDescription = message.MailDescription,
                        EmailMember = message.To,
                        EmailCandidate = message.From,
                        CreationInfo = creationInfo,
                        CreationInfoPup = creationInfoPup,
                        AttachedFilesMail = attachedFiles,
                        FromPrefix = fromPrefix,
                        ToPrefix = toPrefix,
                        From = fromPrefix,
                        To = toPrefix,
                        CC = _mapper.Map<List<CCRemote>, List<CCDTO>>(message.CC.ToList()),
                        CCO = _mapper.Map<List<CCORemote>, List<CCODTO>>(message.CCO.ToList())
                    };

                    if (mail.FromPrefix.Contains("fabricaaws") || mail.FromPrefix.Contains("contacto") || mail.FromPrefix.Contains("fabrica.exsis"))
                       mail.FromPrefix = from;
                    if (mail.ToPrefix.Contains("fabricaaws") || mail.ToPrefix.Contains("contacto") || mail.ToPrefix.Contains("fabrica.exsis"))
                        mail.ToPrefix = from;

                    if (mail.FromPrefix == from)
                        mail.From = fromFull;
                    if (mail.FromPrefix == to)
                        mail.From = toFull;

                    if (mail.ToPrefix == to)
                        mail.To = toFull;
                    if (mail.ToPrefix == from)
                        mail.To = fromFull;

                    string[] fromSplit = mail.From.Split(" ");

                    string initials = "";

                    if (fromSplit != null && fromSplit.Count() > 0 && !string.IsNullOrEmpty(fromSplit[0]))
                        initials = fromSplit[0][0].ToString();

                    if (fromSplit != null && fromSplit.Count() > 1 && !string.IsNullOrEmpty(fromSplit[1]))
                        initials += fromSplit[1][0].ToString();

                    mail.InitialsFrom = initials.ToUpper();

                    mails.Add(mail);
                }
            }
            catch(Exception ex)
            {

            }

            return mails;
        }

        public async Task<Tuple<List<MailDTO>, Tuple<int, int>>> GetAnwsersLevelsEmails(List<MailDTO> mailsDTO, Candidate candidate, List<RemoteMail> recoveredMails, int countQuestions,
            int countAnswers, bool isFirstLevel, string parentMail)
        {
            foreach(MailDTO mail in mailsDTO)
            {
                string parentMailNext = parentMail;

                List<MailDTO> mailAnswers = await GetAnwsersEmails(mail.FromPrefix, mail.ToPrefix, mail.From, mail.To, mail.MessageId, recoveredMails);

                if (isFirstLevel)
                {
                    countQuestions++;

                    parentMailNext = mail.FromPrefix;
                }
                else
                {
                    if (parentMailNext == mail.FromPrefix)
                    {
                        countQuestions++;
                    }
                    else
                    {
                        countAnswers++;
                    }
                }

                mailAnswers.Reverse();

                mail.MailsChildren = mailAnswers;

                if (mailAnswers != null && mailAnswers.Count > 0)
                {
                    Tuple<List<MailDTO>, Tuple<int, int>> tuple = await GetAnwsersLevelsEmails(mail.MailsChildren, candidate, recoveredMails, countQuestions, countAnswers, false, parentMailNext);

                    mail.MailsChildren = tuple.Item1;
                    countQuestions = tuple.Item2.Item1;
                    countAnswers = tuple.Item2.Item2;
                }

                //count += mailAnswers.Count();
            }

            Tuple<int, int> intTuple = new Tuple<int, int>(countQuestions, countAnswers);

            return new Tuple<List<MailDTO>, Tuple<int, int>>(mailsDTO, intTuple);
        }

        public async Task Connect(IImapClient client)
        {
            try
            {
                await client.ConnectAsync(_mailSettings.HostImap, _mailSettings.PortImap, SecureSocketOptions.SslOnConnect);

                await client.AuthenticateAsync(_mailSettings.MailImap, _mailSettings.PasswordImap);
            }
            catch (AuthenticationException ex)
            {
                throw;
            }
        }

        public async Task Disconnect(IImapClient client)
        {
            await client.DisconnectAsync(true);
        }
    }
}
