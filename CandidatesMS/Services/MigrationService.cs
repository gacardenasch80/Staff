using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.Models.RemoteModels.Out;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.Infraestructure.Services;
using CandidatesMS.Repositories;
using CandidatesMS.Repositories.RemoteRepositories;
using CandidatesMS.KeyVault.SecretsModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing.Matching;
using Microsoft.Extensions.Options;
using S3bucketDemo.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace CandidatesMS.Services
{
    public interface IMigrationService
    {
        Task<bool> MigrateCandidates(List<RecruiteeCandidateOutDTO> candidates, string values);
        Task<bool> MigrateTags(List<RecruiteeCandidateOutDTO> candidates, string values);
        Task<bool> MigratePhotos(List<RecruiteeCandidateOutDTO> candidates, string values);
        Task<bool> MigrateCVs(List<RecruiteeCandidateOutDTO> candidates, string values);
        Task<bool> MigrateNotes(List<CandidateRecruiteeInDTO> candidates);
        Task<bool> SaveCvAsync(string url, string name, int candidateId);
        Task<string> SaveCVRawAsync(string url, string name, int candidateId);
        Task<string> MigratePhotosRaw(string url);
    }
    public class MigrationService : IMigrationService
    {
        private ICandidateRepository _candidateRepository;
        private IRecruiteeRemoteRepository _recruiteeRepository;
        private IAWSS3FileService _aWSS3FileService;
        private ICVRepository _cvRepository;
        private IBasicInformationRepository _basicInformationRepository;
        private IEmailRepository _emailRepository;
        private IPhoneRepository _phoneRepository;
        private IUserLinkRepository _userLinkRepository;
        private ISocialNetworkRepository _socialNetworkRepository;
        private ICompanyRemoteRepository _companyRemoteRepository;
        private INoteRepository _noteRepository;
        private readonly ServiceConfigurationDTO _settings;

        public MigrationService(ICandidateRepository candidateRepository, IRecruiteeRemoteRepository recruiteeRemoteRepository,
                                IUserLinkRepository userLinkRepository, ISocialNetworkRepository socialNetworkRepository,
                                IAWSS3FileService aWSS3FileService, ICVRepository cVRepository, IBasicInformationRepository basicInformationRepository,
                                IEmailRepository emailRepository, IPhoneRepository phoneRepository, ICompanyRemoteRepository companyRemoteRepository, INoteRepository noteRepository,
                                      IOptions<ServiceConfigurationDTO> settings)
        {
            _candidateRepository = candidateRepository;
            _userLinkRepository = userLinkRepository;
            _socialNetworkRepository = socialNetworkRepository;
            _cvRepository = cVRepository;
            _aWSS3FileService = aWSS3FileService;
            _recruiteeRepository = recruiteeRemoteRepository;
            _basicInformationRepository = basicInformationRepository;
            _emailRepository = emailRepository;
            _phoneRepository = phoneRepository;
            _companyRemoteRepository = companyRemoteRepository;
            _noteRepository = noteRepository;
            _settings = settings.Value;
        }

        public async Task<bool> MigrateCandidates(List<RecruiteeCandidateOutDTO> candidates, string values)
        {
            try
            {
                foreach (var candidate in candidates)
                {
                    if (candidate != null && candidate.candidate != null)
                    {
                        try
                        {
                            var existCandidateByEmail = await _candidateRepository.CandidateExistByEmail(candidate.candidate.emails[0]);

                            if (existCandidateByEmail)
                            {
                                continue;
                            }

                            RecruiteeCandidateInDTO candidateDto = await _recruiteeRepository.GetCandidateById((int)candidate.candidate.id);
                            //RecruiteeCandidateInDTO candidateDto = await _recruiteeRepository.GetCandidateById(10674070);

                            //if (!string.IsNullOrEmpty(firstEmail))
                            //    existCandidateByEmail = await _candidateRepository.CandidateExistByEmail(firstEmail);

                            Candidate candidateCreated = new Candidate() { };
                            candidateCreated.Email = candidate.candidate.emails[0];
                            candidateCreated.CandidateGuid = Convert.ToString(Guid.NewGuid());
                                                     
                            /**/

                            string[] validformats = ["MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss, fff",
                                            "MM/dd/yyyy hh:mm tt", "M/dd/yyyy h:mm:ss tt", "MM/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm:ss tt",
                                            "dd/MM/yyyy hh:mm:ss tt","dd/MM/yyyy hh:mm:ss","dd/MM/yyyy h:mm:ss","dd/MM/yyyy h:mm:ss ff",
                                            "dd/MM/yyyy h:mm:ss tt","dd/MM/yyyy hh:mm:ss ff","M/dd/yyyy hh:mm:ss tt",
                                "M/dd/yyyy HH:mm:ss", "M/d/yyyy HH:mm:ss", "MM/d/yyyy HH:mm:ss"];

                            candidateCreated.CreationDate = DateTime.Now.ToLocalTime().ToString("MM/dd/yyyy HH:mm:ss");

                            candidateCreated.CreationDateNoText = DateTime.ParseExact(candidateCreated.CreationDate.Replace(".", ""), validformats, CultureInfo.InvariantCulture, DateTimeStyles.None);

                            /**/

                            candidateCreated.IsMigrated = 1;

                            bool created = await _candidateRepository.AddMigration(candidateCreated);

                            if (!created)
                                continue;

                            Candidate newCandidate = await _candidateRepository.GetByEmail(candidateCreated.Email);

                            BasicInformation basicInformation = new BasicInformation()
                            {
                                Photo = "",
                                Name = "",
                                Surname = "",
                                Document = "",
                                Country = "",
                                City = "",
                                Address = "",
                                Phone = "",
                                Cellphone = "",
                                BirthDate = "",
                                HaveWorkExperience = 2,
                                LinkedInURL = "",
                                FacebookURL = "",
                                TwitterURL = "",
                                GitHubURL = "",
                                BitBucketURL = "",
                                CandidateId = 0,
                                DocumentTypeId = null,
                                MaritalStatusId = 6,
                                GenderId = 4,
                                SalaryAspiration = "",
                                CurrencyId = 6
                            };

                            basicInformation.CandidateId = newCandidate.CandidateId;
                            basicInformation.Name = candidate.candidate.name;
                            basicInformation.Photo = await GetS3UrlPhoto(candidate.candidate.photo_url);

                            await _basicInformationRepository.Add(basicInformation);
                            var basicInfo = await _basicInformationRepository.GetByCandidateId(newCandidate.CandidateId);

                            var nEmails = candidate.candidate.emails.Count;
                            if (nEmails > 1)
                            {
                                List<Email> emails = new List<Email>();
                                for (int i = 1; i < nEmails; i++)
                                {
                                    Email email = new Email();
                                    email.BasicInformationId = basicInfo.BasicInformationId;
                                    email.Mail = candidate.candidate.emails[i];
                                    emails.Add(email);
                                }
                                await _emailRepository.AddRange(emails);
                            }

                            if (candidate.candidate.phones.Count > 0)
                            {
                                List<Phone> phones = new List<Phone>();
                                foreach (string phone in candidate.candidate.phones)
                                {
                                    Phone telephone = new Phone
                                    {
                                        BasicInformationId = basicInfo.BasicInformationId,
                                        Number = phone
                                    };

                                    phones.Add(telephone);
                                }
                                await _phoneRepository.AddRange(phones);
                            }

                            if (candidate.candidate.links.Count > 0)
                            {
                                List<UserLink> userLinks = new List<UserLink>();
                                List<SocialNetwork> socialNetworks = new List<SocialNetwork>();

                                for (int i = 0; i < candidate.candidate.links.Count; i++)
                                {
                                    var link = candidate.candidate.links[i].ToString();
                                    if (link.Contains("facebook") || link.Contains("linkedin") || link.Contains("twitter"))
                                    {
                                        SocialNetwork sn = new SocialNetwork();
                                        sn.BasicInformationId = basicInfo.BasicInformationId;
                                        sn.Link = link;
                                        socialNetworks.Add(sn);
                                    }
                                    else
                                    {
                                        UserLink ul = new UserLink();
                                        ul.BasicInformationId = basicInfo.BasicInformationId;
                                        ul.Link = link;
                                        userLinks.Add(ul);
                                    }
                                }
                                await _userLinkRepository.AddRange(userLinks);
                                await _socialNetworkRepository.AddRange(socialNetworks);
                            }

                            if (candidate.candidate.social_links.Count > 0)
                            {
                                List<UserLink> userLinks = new List<UserLink>();
                                List<SocialNetwork> socialNetworks = new List<SocialNetwork>();

                                for (int i = 0; i < candidate.candidate.social_links.Count; i++)
                                {
                                    var link = candidate.candidate.social_links[i].ToString();
                                    if (link.Contains("facebook") || link.Contains("linkedin") || link.Contains("twitter"))
                                    {
                                        SocialNetwork sn = new SocialNetwork();
                                        sn.BasicInformationId = basicInfo.BasicInformationId;
                                        sn.Link = link;
                                        socialNetworks.Add(sn);
                                    }
                                    else
                                    {
                                        UserLink ul = new UserLink();
                                        ul.BasicInformationId = basicInfo.BasicInformationId;
                                        ul.Link = link;
                                        userLinks.Add(ul);
                                    }
                                }

                                await _userLinkRepository.AddRange(userLinks);
                                await _socialNetworkRepository.AddRange(socialNetworks);
                            }

                            if (candidate.candidate.tags.Count > 0)
                            {
                                for (int i = 0; i < candidate.candidate.tags.Count; i++)
                                {
                                    var tag = new TagInDTO();
                                    tag.Name = candidate.candidate.tags[i];
                                    tag.CompanyUserId = 3;
                                    await _companyRemoteRepository.AddAndAttachTagToCandidate(newCandidate.CandidateId, tag, values);
                                }
                            }

                            if (candidate.candidate.sources.Count > 0)
                            {
                                for (int i = 0; i < candidate.candidate.sources.Count; i++)
                                {
                                    var tag = new SourceInDTO();
                                    tag.Name = candidate.candidate.sources[i];
                                    tag.CompanyUserId = 3;
                                    await _companyRemoteRepository.AddAndAttachSourceToCandidate(newCandidate.CandidateId, tag, values);
                                }
                            }


                            var saved = await SaveCvAsync(candidate.candidate.cv_original_url, candidate.candidate.name, newCandidate.CandidateId);
                        }
                        catch (Exception e)
                        {
                            continue;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No se pudo agregar el candidato: " + ex.InnerException);
            }
        }

        public async Task<bool> MigrateTags(List<RecruiteeCandidateOutDTO> candidates, string values)
        {
            try
            {
                foreach (var candidate in candidates)
                {
                    try
                    {
                        Candidate oldCandidate = await _candidateRepository.GetByEmail(candidate.candidate.emails[0]);

                        if (oldCandidate.IsMigrated == 1)
                        {
                            if (candidate.candidate.tags.Count > 0)
                            {
                                for (int i = 0; i < candidate.candidate.tags.Count; i++)
                                {
                                    var tag = new TagInDTO();
                                    tag.Name = candidate.candidate.tags[i];
                                    tag.CompanyUserId = 3;
                                    await _companyRemoteRepository.AddAndAttachTagToCandidate(oldCandidate.CandidateId, tag, values);
                                }
                            }

                            if (candidate.candidate.sources.Count > 0)
                            {
                                for (int i = 0; i < candidate.candidate.sources.Count; i++)
                                {
                                    var tag = new SourceInDTO();
                                    tag.Name = candidate.candidate.sources[i];
                                    tag.CompanyUserId = 3;
                                    await _companyRemoteRepository.AddAndAttachSourceToCandidate(oldCandidate.CandidateId, tag, values);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        continue;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No se pudo agregar el candidato: " + ex.InnerException);
            }
        }

        public async Task<bool> MigratePhotos(List<RecruiteeCandidateOutDTO> candidates, string values)
        {
            try
            {
                foreach (var candidate in candidates)
                {
                    try
                    {
                        Candidate oldCandidate = await _candidateRepository.GetByEmail(candidate.candidate.emails[0]);

                        if (oldCandidate != null && oldCandidate.IsMigrated == 1)
                        {
                            if (candidate != null && candidate.candidate != null && !string.IsNullOrEmpty(candidate.candidate.photo_url))
                            {
                                BasicInformation basicInformation = await _basicInformationRepository.GetByCandidateId(oldCandidate.CandidateId);

                                if (string.IsNullOrEmpty(basicInformation.Photo))
                                {
                                    basicInformation.Photo = await GetS3UrlPhoto(candidate.candidate.photo_url);

                                    bool isTrue = await _basicInformationRepository.Update(basicInformation);
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        continue;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No se pudo agregar el candidato: " + ex.InnerException);
            }
        }

        public async Task<bool> MigrateCVs(List<RecruiteeCandidateOutDTO> candidates, string values)
        {
            try
            {
                foreach (var candidate in candidates)
                {
                    try
                    {
                        Candidate oldCandidate = await _candidateRepository.GetByEmail(candidate.candidate.emails[0]);

                        if (oldCandidate != null && oldCandidate.IsMigrated == 1)
                        {
                            if (candidate != null && candidate.candidate != null && !string.IsNullOrEmpty(candidate.candidate.cv_original_url))
                            {
                                var saved = await SaveCvAsync(candidate.candidate.cv_original_url, candidate.candidate.name, oldCandidate.CandidateId);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        continue;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("No se pudo agregar CV: " + ex.InnerException);
            }
        }

        private async Task<string> GetS3UrlPhoto(string photo_url)
        {
            if (photo_url == null || photo_url == "")
                return null;
            // Get the current directory.
            string currentPath = Directory.GetCurrentDirectory();
            string folderPath = Path.GetFullPath(Path.Combine(currentPath, "Files"));
            System.IO.Directory.CreateDirectory(folderPath);

            Uri uri = new Uri(photo_url);
            string filename = "";
            string filePath;

            try
            {

                if (uri.IsFile || true)
                {
                    filename = Path.GetFileName(uri.LocalPath);
                    filePath = folderPath + "/" + filename;
                    WebClient Client = new WebClient();

                    Client.DownloadFile(photo_url, filePath);
                }
                else
                    return null;

                var response = await _aWSS3FileService.UploadCVFileMigration(filePath, "Photo");
                if (response == null)
                    return null;

                return "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + response[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private async Task<string> GetS3UrlNoteFiles(string file_url)
        {
            if (file_url == null || file_url == "")
                return null;
            // Get the current directory.
            string currentPath = Directory.GetCurrentDirectory();
            string folderPath = Path.GetFullPath(Path.Combine(currentPath, "Files"));
            System.IO.Directory.CreateDirectory(folderPath);

            Uri uri = new Uri(file_url);
            string filename = "";
            string filePath;

            try
            {

                if (uri.IsFile || true)
                {
                    filename = Path.GetFileName(uri.LocalPath);
                    filePath = folderPath + "/" + filename;
                    WebClient Client = new WebClient();

                    Client.DownloadFile(file_url, filePath);
                }
                else
                    return null;

                var response = await _aWSS3FileService.UploadCVFileMigration(filePath, "AttachedFilesNotes");
                if (response == null)
                    return null;

                //return "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + response[0];
                return response[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> SaveCvAsync(string url, string name, int candidateId)
        {
            // Get the current directory.
            string currentPath = Directory.GetCurrentDirectory();
            string folderPath = Path.GetFullPath(Path.Combine(currentPath, "Files"));
            System.IO.Directory.CreateDirectory(folderPath);

            if (url == null || url == "")
                return false;
            Uri uri = new Uri(url);
            string filename = name + "_";
            string filePath;

            try
            {

                if (uri.IsFile || true)
                {
                    filename += Path.GetFileName(uri.LocalPath);
                    filePath = folderPath + "/" + filename;
                    WebClient Client = new WebClient();

                    Client.DownloadFile(url, filePath);
                }
                else
                    return false;

                var response = await _aWSS3FileService.UploadCVFileMigration(filePath, "CV");
                if (response == null)
                    return false;

                CV cvUser = new CV();
                cvUser.CandidateId = candidateId;
                cvUser.CVGuid = Convert.ToString(Guid.NewGuid());
                cvUser.CvIdentifier = response[0];
                cvUser.CvIdentifierLink = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + response[0];
                if (response.Count == 2)
                    cvUser.CvIdentifierLink = "https://" + _settings.AWSS3.BucketName + ".s3.amazonaws.com/" + response[1];
                await _cvRepository.DeleteOverViewCv(candidateId);
                cvUser.OverViewCv = true;
                cvUser.IsFromCandidate = false;

                cvUser.Name = name;
                cvUser.FileTypeId = 6;
                cvUser.UploadDate = DateTime.Now.ToString();

                bool created = await _cvRepository.Add(cvUser);
                if (created)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        public async Task<string> SaveCVRawAsync(string url, string name, int candidateId)
        {
            // Get the current directory.
            string currentPath = Directory.GetCurrentDirectory();
            string folderPath = Path.GetFullPath(Path.Combine(currentPath, "Files"));
            System.IO.Directory.CreateDirectory(folderPath);

            if (url == null || url == "")
                return null;
            Uri uri = new Uri(url);
            string filename = name + "_";
            string filePath;

            try
            {

                if (uri.IsFile || true)
                {
                    filename += Path.GetFileName(uri.LocalPath);
                    filePath = folderPath + "/" + filename;
                    WebClient Client = new WebClient();

                    Client.DownloadFile(url, filePath);
                }
                else
                    return null;

                var response = await _aWSS3FileService.UploadCVFileRaw(filePath, "CV");
                if (response == null)
                    return null;

                CV cvUser = new CV();
                cvUser.CandidateId = candidateId;
                cvUser.CVGuid = Convert.ToString(Guid.NewGuid());
                cvUser.CvIdentifier = response[0];
                cvUser.CvIdentifierLink = "https://recruitee-bucket-prod.s3.amazonaws.com/" + response[0];
                if (response.Count == 2)
                    cvUser.CvIdentifierLink = "https://recruitee-bucket-prod.s3.amazonaws.com/" + response[1];
                await _cvRepository.DeleteOverViewCv(candidateId);
                cvUser.OverViewCv = true;

                cvUser.Name = name;
                cvUser.FileTypeId = 6;
                cvUser.UploadDate = DateTime.Now.ToString();

                return cvUser.CvIdentifierLink;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> MigratePhotosRaw(string url)
        {
            try
            {
                string newURL = "";

                if (!string.IsNullOrEmpty(url))
                {
                    newURL = await GetS3UrlPhotoRaw(url);
                }

                return newURL;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private async Task<string> GetS3UrlPhotoRaw(string photo_url)
        {
            if (photo_url == null || photo_url == "")
                return null;
            // Get the current directory.
            string currentPath = Directory.GetCurrentDirectory();
            string folderPath = Path.GetFullPath(Path.Combine(currentPath, "Files"));
            System.IO.Directory.CreateDirectory(folderPath);

            Uri uri = new Uri(photo_url);
            string filename = "";
            string filePath;

            try
            {

                if (uri.IsFile || true)
                {
                    filename = Path.GetFileName(uri.LocalPath);
                    filePath = folderPath + "/" + filename;
                    WebClient Client = new WebClient();

                    Client.DownloadFile(photo_url, filePath);
                }
                else
                    return null;

                var response = await _aWSS3FileService.UploadCVFileRaw(filePath, "Photo");
                if (response == null)
                    return null;

                return "https://recruitee-bucket-prod.s3.amazonaws.com/" + response[0];
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async static Task<string> GetImageAsBase64Url(string url)
        {
            using (var client = new HttpClient())
            {
                var bytes = await client.GetByteArrayAsync(url);
                return Convert.ToBase64String(bytes);
            }
        }

        public async Task MappingNotes(List<NoteRecruitee> notesRecruitee, int parentId)
        {
            foreach (NoteRecruitee noteRecruitee in notesRecruitee)
            {
                try
                {
                    int candidateId = 0;

                    if (parentId == 0)
                        candidateId = (int)noteRecruitee.candidateId;
                    else
                    {
                        Note noteParent = await _noteRepository.GetById(parentId);

                        candidateId = noteParent.CandidateId;
                    }

                    DateTime auxCreationDate;
                    if (!DateTime.TryParse(noteRecruitee.created_at, out auxCreationDate))
                    {
                        // handle parse failure
                    }

                    Note note = new Note
                    {
                        CandidateId = candidateId,
                        CompanyUserId = 3, // 3 en prod, 4 en dev
                        CreationDate = auxCreationDate.ToString("MM/dd/yyyy hh:mm:ss"),
                        Available = true,
                        EmailMember = "analista.seleccion@exsis.com.co",
                        MemberId = 2,
                        NameMemberUser = "Analista",
                        SurnameMemberUser = "Selección",
                        NoteDescription = noteRecruitee.body,
                        NoteOwnerId = parentId
                    };

                    if (noteRecruitee.pinned_at != null)
                    {
                        DateTime myDate;
                        if (!DateTime.TryParse(noteRecruitee.pinned_at, out myDate))
                        {
                            // handle parse failure
                        }

                        note.PinUp = true;
                        note.DatePinUp = myDate;
                    }

                    if (noteRecruitee.attachments != null && noteRecruitee.attachments.Length > 0 &&
                        noteRecruitee.attachments[0].file_url != null && noteRecruitee.attachments[0].filename != null && noteRecruitee.attachments[0].created_at != null)
                    {
                        DateTime auxFileCreationDate;
                        if (!DateTime.TryParse(noteRecruitee.attachments[0].created_at, out auxFileCreationDate))
                        {
                            // handle parse failure
                        }

                        note.FileIdentifier = await GetS3UrlNoteFiles(noteRecruitee.attachments[0].file_url.ToString());
                        note.FileName = noteRecruitee.attachments[0].filename;
                        note.FileUploadDate = auxFileCreationDate.ToString("MM/dd/yyyy hh:mm:ss");
                    }

                    Note noteCreated = await _noteRepository.Add(note);

                    if (noteRecruitee.replies != null && noteRecruitee.replies.Length > 0)
                    {
                        await MappingNotes(noteRecruitee.replies.ToList(), noteCreated.NoteId);
                    }
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
        }

        public async Task<bool> MigrateNotes(List<CandidateRecruiteeInDTO> candidates)
        {
            List<NoteRecruitee> notesRecruitee = await _recruiteeRepository.MigrateNotes(candidates);

            await MappingNotes(notesRecruitee, 0);

            return true;
        }
    }
}
