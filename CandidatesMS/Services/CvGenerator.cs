using CandidatesMS.Helpers;
using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using CandidatesMS.Repositories.RemoteRepositories;
using MimeKit;
using S3bucketDemo.Helpers;
using S3bucketDemo.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using iText.Html2pdf;
using iText.Layout;
using iText.Kernel.Pdf;
using CandidatesMS.RepositoriesCompany;
using CandidatesMS.Persistence.EntitiesCompany;
using DocumentFormat.OpenXml.Math;

namespace CandidatesMS.Services
{
    public interface ICvGenerator
    {
        Task<bool> CreateCvByCandidateIdAsync(int candidateId, int language, string token);
        Task<bool> CreateCvByCandidateAndCompanyIdAsync(int candidateId, int companyUserId, int language, string token);
        Task<bool> CvGeneratedExistByCandidateId(int candidateId);
        Task<bool> CvGeneratedExistByCandidateAndCompanyId(int candidateId, int companyUserId);
        Task<bool> RemoveCvGeneratedByCandidateId(int candidateId);
        Task<bool> RemoveCvGeneratedByCandidateAndCompanyId(int candidateId, int companyUserId);
        Task<bool> RemoveCvGeneratedByCandidateIdMaster(int candidateId);
        Task<bool> CvGeneratedContactExistByCandidateId(int candidateId);
        Task<bool> CvGeneratedContactExistByCandidateAndCompanyId(int candidateId, int companyUserId);
        Task<bool> RemoveCvGeneratedContactByCandidateId(int candidateId);
        Task<bool> RemoveCvGeneratedContactByCandidateAndCompanyId(int candidateId, int companyUserId);
        Task<bool> RemoveCvGeneratedContactByCandidateIdMaster(int candidateId);
        Task<bool> CvGeneratedExistByCandidateIdMaster(int candidateId);
        Task<bool> CvGeneratedContactExistByCandidateIdMaster(int candidateId);
        Task<byte[]> GetDocFileUrls(int candidateId, bool isMaster);
        Task<byte[]> GetDocFileUrlsByCompany(int candidateId, int companyUserId, bool isMaster);
        Task<Dictionary<string, dynamic>> GetDocFileDownloadByCompany(int candidateId, int companyUserId, int cvType, int fileType, bool isMaster);
        Task<string> GetFileName(int candidateId);
        void RemoveUrlsFile(string path);
    }
    public class CvGenerator : ICvGenerator
    {
        private ICandidateRepository _candidateRepository;
        private IDescriptionRepository _descriptionRepository;
        private ICompanyDescriptionRepository _companyDescriptionRepository;
        private IRecruiteeRemoteRepository _recruiteeRepository;
        private IAWSS3BucketHelper _aWSS3FileHelper;
        private ICVRepository _cvRepository;
        private IBasicInformationRepository _basicInformationRepository;
        private IEmailRepository _emailRepository;
        private IPhoneRepository _phoneRepository;
        private ICandidateJobPreferenceRepository _candidateJobPreferenceRepository;
        private IWorkExperienceRepository _workExperienceRepository;
        private IStudyRepository _studyRepository;
        private ICandidateTechnicalAbilityRepository _candidateTechnicalAbilityRepository;
        private ICompanyRemoteRepository _companyRemoteRepository;
        private IAuthorizationHelper _authorizationHelper;
        private IStudyStateRepository _studyStateRepository;
        private ICompany_Candidate_TimeAvailabilityRepository _company_Candidate_TimeAvailabilityRepository;
        private ICompany_Candidate_WellnessRepository _company_Candidate_WellnessRepository;
        private ICandidateCompanyRepository _candidateCompanyRepository;
        private ICompanyCandidateJobPreferenceRepository _companyCandidateJobPreferenceRepository;
        private IWellnessRepository _wellnessRepository;
        private ITimeAvailabilityRepository _timeAvailabilityRepository;
        private ITechnicalAbilityLevelRepository _technicalAbilityLevelRepository;
        private ICvService _cvService;
        private IAWSS3FileService _AWSS3FileService;
        private IMatchServerDate _matchServerDate;      
        
        private ICompanyUserRepository _companyUserRepository;
        private IMemberUserRepository _memberUserRepository;

        public CvGenerator
            (
                            ICandidateRepository candidateRepository, IRecruiteeRemoteRepository recruiteeRemoteRepository,
                            IWorkExperienceRepository workExperienceRepository, IStudyRepository studyRepository,
                            IAuthorizationHelper authorizationHelper, ICvService cvService, IAWSS3FileService AWSS3FileService,
                            ICandidateTechnicalAbilityRepository candidateTechnicalAbilityRepository, 
                            ICompanyRemoteRepository companyRemoteRepository, IStudyStateRepository studyStateRepository,
                            IDescriptionRepository descriptionRepository, ICandidateJobPreferenceRepository candidateJobPreferenceRepository,
                            IAWSS3BucketHelper aWSS3FileHelper, ICVRepository cVRepository, ICandidateCompanyRepository candidateCompanyRepository,
                            IBasicInformationRepository basicInformationRepository,
                            ICompany_Candidate_TimeAvailabilityRepository company_Candidate_TimeAvailabilityRepository,
                            ICompany_Candidate_WellnessRepository company_Candidate_WellnessRepository,
                            ICompanyCandidateJobPreferenceRepository companyCandidateJobPreferenceRepository,
                            IWellnessRepository wellnessRepository, ITimeAvailabilityRepository timeAvailabilityRepository,
                            ITechnicalAbilityLevelRepository technicalAbilityLevelRepository,
                            IEmailRepository emailRepository, IPhoneRepository phoneRepository, ICompanyDescriptionRepository companyDescriptionRepository,
                            IMatchServerDate matchServerDate,

                            ICompanyUserRepository companyUserRepository,
                            IMemberUserRepository memberUserRepository
            )
        {
            _candidateRepository = candidateRepository;
            _studyStateRepository = studyStateRepository;
            _authorizationHelper = authorizationHelper;
            _companyRemoteRepository = companyRemoteRepository;
            _descriptionRepository = descriptionRepository;
            _companyDescriptionRepository = companyDescriptionRepository;
            _candidateJobPreferenceRepository = candidateJobPreferenceRepository;
            _cvRepository = cVRepository;
            _aWSS3FileHelper = aWSS3FileHelper;
            _recruiteeRepository = recruiteeRemoteRepository;
            _candidateCompanyRepository = candidateCompanyRepository;
            _basicInformationRepository = basicInformationRepository;
            _company_Candidate_TimeAvailabilityRepository = company_Candidate_TimeAvailabilityRepository;
            _company_Candidate_WellnessRepository = company_Candidate_WellnessRepository;
            _emailRepository = emailRepository;
            _phoneRepository = phoneRepository;
            _workExperienceRepository = workExperienceRepository;
            _studyRepository = studyRepository;
            _candidateTechnicalAbilityRepository = candidateTechnicalAbilityRepository;
            _companyCandidateJobPreferenceRepository = companyCandidateJobPreferenceRepository;
            _wellnessRepository = wellnessRepository;
            _timeAvailabilityRepository = timeAvailabilityRepository;
            _technicalAbilityLevelRepository = technicalAbilityLevelRepository;
            _cvService = cvService;
            _AWSS3FileService = AWSS3FileService;
            _matchServerDate = matchServerDate;

            _companyUserRepository = companyUserRepository;
            _memberUserRepository = memberUserRepository;
        }

        public async Task<bool> CreateCvByCandidateIdAsync(int candidateId, int language, string token)
        {         
            List<string> fileValues = await GetFileTemplateAsync(language);
            var generated = await GenerateCvs(candidateId, fileValues, language, token);

            if (!generated)
                return false;

            var fileIdentifier = await _AWSS3FileService.UploadCVFileMigration(fileValues[3], "GeneratedCV");
            var fileContactIdentifier = await _AWSS3FileService.UploadCVFileMigration(fileValues[2], "GeneratedContactCV");
            var success = await _cvService.UploadCvRecordAsync(fileIdentifier[0], candidateId, token);
            var successContact = await _cvService.UploadCvRecordAsync(fileContactIdentifier[0], candidateId, token);

            if (success && successContact)
                return true;

            return false;
        }

        public async Task<bool> CreateCvByCandidateAndCompanyIdAsync(int candidateId, int companyUserId, int language, string token)
        {
            List<string> fileValues = await GetFileTemplateAsync(language);
            var generated = await GenerateCvByCandidateIdAsync(candidateId, companyUserId, fileValues, language, token);

            if (!generated)
                return false;

            var fileIdentifier = await _AWSS3FileService.UploadCVFileMigration(fileValues[3], "GeneratedCV");
            var fileContactIdentifier = await _AWSS3FileService.UploadCVFileMigration(fileValues[2], "GeneratedContactCV");
            var success = await _cvService.UploadCvRecordWithCompanyAsync(fileIdentifier[0], candidateId, companyUserId, token);
            var successContact = await _cvService.UploadCvRecordWithCompanyAsync(fileContactIdentifier[0], candidateId, companyUserId, token);

            if (success && successContact)
                return true;

            return false;
        }


        public async Task<bool> GenerateCvByCandidateIdAsync(int candidateId, int companyUserId, List<string> fileValues, int language, string token)
        {
            bool isMaster = await _companyRemoteRepository.isMaster(token);

            string html = fileValues[1];
            string htmlContact = fileValues[0];
            string filePath = fileValues[3];
            string fileContactPath = fileValues[2];

            var candidate = await _candidateRepository.GetById(candidateId);
            var description = await _descriptionRepository.GetByCandidateId(candidateId);
            var companyDescription = await _companyDescriptionRepository.GetByCandidateAndCompanyId(candidateId, companyUserId);
            var basicInfo = await _basicInformationRepository.GetByCandidateId(candidateId);
            var candidateCompany = await _candidateCompanyRepository.GetByCandidateAndCompanyId(candidateId, companyUserId);
            if (basicInfo == null)
                return false;

            List<Candidate_Wellness> candidateWellness = await _candidateJobPreferenceRepository.GetWellnessByCandidateId(candidateId);
            List<Candidate_TimeAvailability> candidate_TimeAvailabilities = await _candidateJobPreferenceRepository.GetTimeAvailabilityByCandidateId(candidateId);
            List<Company_Candidate_Wellness> companyWellness = 
                await _company_Candidate_WellnessRepository.GetToOverview(candidateId, companyUserId);
            List<Company_Candidate_TimeAvailability> company_TimeAvailabilities = 
                await _company_Candidate_TimeAvailabilityRepository.GetToOverview(candidateId, companyUserId);
            List<WorkExperience> workExperiences = new List<WorkExperience>();
            List<Study> studies = new List<Study>();
            List<Candidate_TechnicalAbility> technicalAbilities = new List<Candidate_TechnicalAbility>();

            if (isMaster == true)
            {
                studies = await _studyRepository.GetByCandidateIdAdminViewMaster(candidateId);
                technicalAbilities = await _candidateTechnicalAbilityRepository.GetByCandidateIdMaster(candidateId);
                workExperiences = await _workExperienceRepository.GetAdminViewByCandidateIdMaster(candidateId);
            }
            else
            {
                studies = await _studyRepository.GetToOverview(candidateId, companyUserId);
                technicalAbilities = await _candidateTechnicalAbilityRepository.GetToOverview(candidateId, companyUserId);
                workExperiences = await _workExperienceRepository.GetToOverview(candidateId, companyUserId);
            }

            CompanyUser companyUser = await _companyUserRepository.GetById(companyUserId);

            if (!string.IsNullOrEmpty(basicInfo.Photo))
            {
                var divPhoto = $"<img class=\"profile\" src=\"{basicInfo.Photo}\" alt=\"\" ></img>";
                html = html.Replace("<!--photo-->", divPhoto);
                htmlContact = htmlContact.Replace("<!--photo-->", divPhoto);
                File.WriteAllText(filePath, html);
                File.WriteAllText(fileContactPath, htmlContact);
            }
            else if (companyUser != null && !string.IsNullOrEmpty(companyUser.LogoIdentifier))
            {
                var divPhoto = $"<img class=\"profile\" src=\"https://recruitment-bucket-dev.s3.amazonaws.com/{companyUser.LogoIdentifier}\" alt=\"\"></img>";
                html = html.Replace("<!--photo-->", divPhoto);
                htmlContact = htmlContact.Replace("<!--photo-->", divPhoto);

                var divProfile = $"<img class=\"img-right-company\" src=\"https://recruitment-bucket-dev.s3.amazonaws.com/{companyUser.LogoIdentifier}\" alt=\"\"></img>";

                html = html.Replace("<!--logoCompany-->", divProfile);
                htmlContact = htmlContact.Replace("<!--logoCompany-->", divProfile);

                File.WriteAllText(filePath, html);
                File.WriteAllText(fileContactPath, htmlContact);
            }
            else
            {
                var divPhoto = $"<img class=\"profile\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/exstaff-logo.png\" alt=\"\"></img>";
                html = html.Replace("<!--photo-->", divPhoto);
                htmlContact = htmlContact.Replace("<!--photo-->", divPhoto);

                var divProfile = $"<img class=\"img-right-company\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/exstaff-logo.png\" alt=\"\"></img>";

                html = html.Replace("<!--logoCompany-->", divProfile);
                htmlContact = htmlContact.Replace("<!--logoCompany-->", divProfile);

                File.WriteAllText(filePath, html);
                File.WriteAllText(fileContactPath, htmlContact);
            }

            if (basicInfo.Name != "" && basicInfo.Name != null)
            {
                var divName = $"<h1 class=\"name\">{basicInfo.Name} {basicInfo.Surname}</h1>";

                var divCandidate = string.Empty;

                if (language == 1) // Español
                    divCandidate = $"<h1 class=\"name\">Candidato Exsis</h1>";
                if(language == 2) // English
                    divCandidate = $"<h1 class=\"name\">Exsis Candidate</h1>";

                html = html.Replace("<!--name-->", divCandidate);
                htmlContact = htmlContact.Replace("<!--name-->", divName);
                File.WriteAllText(filePath, html);
                File.WriteAllText(fileContactPath, htmlContact);
            }

            if (description != null)
            {
                var divDescription = $"<p class=\"txt-profile\">{description.Text}</p>";
                html = html.Replace("<!--description-->", divDescription);
                htmlContact = htmlContact.Replace("<!--description-->", divDescription);
                File.WriteAllText(filePath, html);
                File.WriteAllText(fileContactPath, htmlContact);
            }

            if (isMaster == false)
            {
                if ((description == null || string.IsNullOrEmpty(description.Text)) && companyDescription != null)
                {
                    var divCompanyDescription = $"<p class=\"txt-profile\">{companyDescription.Text}</p>";
                    html = html.Replace("<!--description-->", divCompanyDescription);
                    htmlContact = htmlContact.Replace("<!--description-->", divCompanyDescription);
                    File.WriteAllText(filePath, html);
                    File.WriteAllText(fileContactPath, htmlContact);
                }
            }

            /**/

            List<string> jobPreferences = new List<string>();
            string divJobpreferences = "";

            if (candidateWellness != null && candidateWellness.Count > 0)
                foreach (Candidate_Wellness wellness in candidateWellness)
                    if (wellness != null && wellness.Wellness != null && !string.IsNullOrEmpty(wellness.Wellness.WellnessName))
                        jobPreferences.Add(wellness.Wellness.WellnessName);

            if (candidate_TimeAvailabilities != null && candidate_TimeAvailabilities.Count > 0)
                foreach (Candidate_TimeAvailability timeAvailability in candidate_TimeAvailabilities)
                    if (timeAvailability != null && timeAvailability.TimeAvailability != null && !string.IsNullOrEmpty(timeAvailability.TimeAvailability.TimeAvailabilityName))
                        jobPreferences.Add(timeAvailability.TimeAvailability.TimeAvailabilityName);

            if (companyWellness != null && companyWellness.Count > 0)
                foreach (Company_Candidate_Wellness wellness in companyWellness)
                {
                    Wellness wellnessFromDB = await _wellnessRepository.GetById(wellness.WellnessId);

                    if (wellnessFromDB != null && !string.IsNullOrEmpty(wellnessFromDB.WellnessName))
                        jobPreferences.Add(wellnessFromDB.WellnessName);
                }

            if (company_TimeAvailabilities != null && company_TimeAvailabilities.Count > 0)
                foreach (Company_Candidate_TimeAvailability timeAvailability in company_TimeAvailabilities)
                {
                    TimeAvailability timeAvailabilityFromDB = await _timeAvailabilityRepository.GetById(timeAvailability.TimeAvailabilityId);

                    if (timeAvailabilityFromDB != null && !string.IsNullOrEmpty(timeAvailabilityFromDB.TimeAvailabilityName))
                        jobPreferences.Add(timeAvailabilityFromDB.TimeAvailabilityName);
                }

            if (jobPreferences != null && jobPreferences.Count > 0)
            {
                foreach (string jobPreference in jobPreferences)
                {
                    divJobpreferences += $"<div class=\"boxWorkExperience w-full\">" +
                                       $"<div class=\"w - full mb - 2\">" +
                                              $"{jobPreference}" +
                                              $"</div>" +
                                    $"</div>";
                }

                html = html.Replace("<!--jobpreferences-->", divJobpreferences);
                htmlContact = htmlContact.Replace("<!--jobpreferences-->", divJobpreferences);
                File.WriteAllText(filePath, html);
            }

            /**/

            if (candidate.Email != "")
            {
                var divEmail = $"<li class=\"email\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/mail.png\" alt=\"\"></img><a href=\"\"> {candidate.Email} </a></li>";
                htmlContact = htmlContact.Replace("<!--email-->", divEmail);
                File.WriteAllText(fileContactPath, htmlContact);
            }

            if (isMaster == false)
            {
                if (basicInfo.Emails.Count > 0)
                {
                    var divEmails = "";
                    foreach (var email in basicInfo.Emails)
                    {
                        if (email.CompanyUserId == 0 || email.CompanyUserId == companyUserId)
                        {
                            divEmails += $"<li class=\"email\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/mail.png\" alt=\"\"></img><a href=\"\"> {email.Mail} </a></li>";
                        }
                    }

                    htmlContact = htmlContact.Replace("<!--emails-->", divEmails);
                    File.WriteAllText(fileContactPath, htmlContact);
                }
            }


            if (basicInfo.Cellphone != "" && basicInfo.Cellphone != null)
            {
                var divPhone = $"<li class=\"phone\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/phone.png\" alt=\"\"></img><a href=\"\"> {GetPhones(basicInfo.Cellphone, basicInfo.Phone)} </a></li>";
                htmlContact = htmlContact.Replace("<!--phone-->", divPhone);
                File.WriteAllText(fileContactPath, htmlContact);
            }

            if (isMaster == false)
            {
                if (basicInfo.Phones.Count > 0)
                {
                    var divPhones = "";
                    foreach (var phone in basicInfo.Phones)
                    {
                        if (phone.CompanyUserId == 0 || phone.CompanyUserId == companyUserId)
                        {
                            divPhones += $"<li class=\"phone\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/phone.png\" alt=\"\"></img><a href=\"\"> {phone.Number} </a></li>";
                        }
                    }

                    htmlContact = htmlContact.Replace("<!--phones-->", divPhones);
                    File.WriteAllText(fileContactPath, htmlContact);
                }
            }


            if (basicInfo.LinkedInURL != "" && basicInfo.LinkedInURL != null && basicInfo.LinkedInURL != null)
            {
                string linkedInShort = string.Empty;

                string[] linkedInSplit = [];

                if (!string.IsNullOrEmpty(basicInfo.LinkedInURL))
                {
                    linkedInSplit = basicInfo.LinkedInURL.Split("?");

                    if (linkedInSplit != null)
                    {
                        if (linkedInSplit.Length > 0)
                            linkedInShort = linkedInSplit[0];
                        else
                            linkedInShort = basicInfo.LinkedInURL;
                    }
                }                

                string divLinkedIn = $"<li class=\"linkedin\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/linkedin.png\" alt=\"\"></img><a href=\"{HttpURL(linkedInShort)}\" target=\"_blank\"> @{GetNickName(linkedInShort)} </a></li>";

                htmlContact = htmlContact.Replace("<!--linkedin-->", divLinkedIn);
                File.WriteAllText(fileContactPath, htmlContact);
            }

            if (basicInfo.FacebookURL != "" && basicInfo.FacebookURL != null)
            {
                var divFaceBook = $"<li class=\"facebook\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/facebook.png\" alt=\"\"></img><a href=\"{HttpURL(basicInfo.FacebookURL)}\" target=\"_blank\"> @{GetNickName(basicInfo.FacebookURL)} </a></li>";
                htmlContact = htmlContact.Replace("<!--facebook-->", divFaceBook);
                File.WriteAllText(fileContactPath, htmlContact);
            }

            if (basicInfo.GitHubURL != "" && basicInfo.GitHubURL != null)
            {
                var divGitHub = $"<li class=\"github\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/github.png\" alt=\"\"></img><a href=\"{HttpURL(basicInfo.GitHubURL)}\" target=\"_blank\"> @{GetNickName(basicInfo.GitHubURL)} </a></li>";
                htmlContact = htmlContact.Replace("<!--github-->", divGitHub);
                File.WriteAllText(fileContactPath, htmlContact);
            }

            if (basicInfo.BitBucketURL != "" && basicInfo.BitBucketURL != null)
            {
                var divBitBucket = $"<li class=\"bitbucket\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/bitbucket.png\" alt=\"\"></img><a href=\"{HttpURL(basicInfo.BitBucketURL)}\" target=\"_blank\"> @{GetNickName(basicInfo.BitBucketURL)} </a></li>";
                htmlContact = htmlContact.Replace("<!--bitbucket-->", divBitBucket);
                File.WriteAllText(fileContactPath, htmlContact);
            }

            if (basicInfo.TwitterURL != "" && basicInfo.TwitterURL != null)
            {
                var divTwitter = $"<li class=\"twitter\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/x.png\" alt=\"\"></img><a href=\"{HttpURL(basicInfo.TwitterURL)}\" target=\"_blank\"> @{GetNickName(basicInfo.TwitterURL)} </a></li>";
                htmlContact = htmlContact.Replace("<!--twitter-->", divTwitter);
                File.WriteAllText(fileContactPath, htmlContact);
            }

            if (isMaster == false)
            {
                if (basicInfo.SocialNetworks.Count > 0)
                {
                    var divLinkedIns = "";
                    var divFaceBooks = "";
                    var divTwitters = "";
                    var divLinks = "";

                    foreach (var sn in basicInfo.SocialNetworks)
                    {
                        if (sn.CompanyUserId == 0 || sn.CompanyUserId == companyUserId)
                        {
                            string linkedInShort = string.Empty;

                            string[] linkedInSplit = [];

                            if (!string.IsNullOrEmpty(sn.Link))
                            {
                                linkedInSplit = sn.Link.Split("?");

                                if (linkedInSplit != null)
                                {
                                    if (linkedInSplit.Length > 0)
                                        linkedInShort = linkedInSplit[0];
                                    else
                                        linkedInShort = sn.Link;
                                }
                            }

                            if (sn.Link.Contains("facebook"))
                                divFaceBooks += $"<li class=\"facebook\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/facebook.png\" alt=\"\"></img><a href=\"{HttpURL(sn.Link)}\" target=\"_blank\"> @{GetNickName(sn.Link)} </a></li>";
                            else if (sn.Link.Contains("linkedin"))
                                divLinkedIns += $"<li class=\"linkedin\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/linkedin.png\" alt=\"\"></img><a href=\"{HttpURL(linkedInShort)}\" target=\"_blank\"> @{GetNickName(linkedInShort)} </a></li>";
                            else if (sn.Link.Contains("twitter"))
                                divTwitters += $"<li class=\"twitter\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/x.png\" alt=\"\"></img><a href=\"{HttpURL(sn.Link)}\" target=\"_blank\"> @{GetNickName(sn.Link)} </a></li>";
                            else
                                divLinks += $"<li class=\"link\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/mundoblanco.png\" alt=\"\"></img><a href=\"{HttpURL(sn.Link)}\" target=\"_blank\"> @{GetNickName(sn.Link)} </a></li>";
                        }
                    }

                    htmlContact = htmlContact.Replace("<!--facebooks-->", divFaceBooks);
                    File.WriteAllText(fileContactPath, htmlContact);
                    htmlContact = htmlContact.Replace("<!--linkedins-->", divLinkedIns);
                    File.WriteAllText(fileContactPath, htmlContact);
                    htmlContact = htmlContact.Replace("<!--twitters-->", divTwitters);
                    File.WriteAllText(fileContactPath, htmlContact);
                    htmlContact = htmlContact.Replace("<!--linkssocial-->", divLinks);
                    File.WriteAllText(fileContactPath, htmlContact);
                }
            }

            if (isMaster == false)
            {
                if (basicInfo.UserLinks.Count > 0)
                {
                    var divGitHubs = "";
                    var divBitBuckets = "";
                    var divLinks = "";

                    foreach (var ul in basicInfo.UserLinks)
                    {
                        if (ul.CompanyUserId == 0 || ul.CompanyUserId == companyUserId)
                        {
                            if (ul.Link.Contains("github"))
                                divGitHubs += $"<li class=\"github\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/github.png\" alt=\"\"></img><a href=\"{HttpURL(ul.Link)}\" target=\"_blank\"> @{GetNickName(ul.Link)} </a></li>";
                            else if (ul.Link.Contains("bitbucket"))
                                divBitBuckets += $"<li class=\"bitbucket\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/bitbucket.png\" alt=\"\"></img><a href=\"{HttpURL(ul.Link)}\" target=\"_blank\"> @{GetNickName(ul.Link)} </a></li>";
                            else
                                divLinks += $"<li class=\"link\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/mundoblanco.png\" alt=\"\"></img><a href=\"{HttpURL(ul.Link)}\" target=\"_blank\"> @{GetNickName(ul.Link)} </a></li>";
                        }
                    }

                    htmlContact = htmlContact.Replace("<!--githubs-->", divGitHubs);
                    File.WriteAllText(fileContactPath, htmlContact);
                    htmlContact = htmlContact.Replace("<!--bitbuckets-->", divBitBuckets);
                    File.WriteAllText(fileContactPath, htmlContact);
                    htmlContact = htmlContact.Replace("<!--links-->", divLinks);
                    File.WriteAllText(fileContactPath, htmlContact);
                }
            }

            if (workExperiences.Count() > 0)
            {
                var divWorks = "";

                foreach (var work in workExperiences)
                {
                    if (work.CompanyUserId == 0 || work.CompanyUserId == companyUserId)
                    {
                        var divFunctions = GetFunacions(work.Functions);
                        divWorks += $"<div class=\"boxWorkExperience w-full\">" +
                                       $"<div class=\"w-full mb-2\">" +
                                            $"<p class=\"titlesWorkExperience\"><span class=\"dot\"></span>{work.Position}</p>" +
                                            $"<p class=\"tstWorkExperienceItem\">{GetJobDates(work.StartDate, work.EndDate)}, {work.Company}</p>" +
                                            $"<p class=\"tstWorkExperienceItem\">{GetLocation(work)}</p>" +
                                       $"</div>" +
                                       $"{GetFunacions(work.Functions)}" +
                                    $"</div>";
                    }
                }

                html = html.Replace("<!--workexperience-->", divWorks);
                htmlContact = htmlContact.Replace("<!--workexperience-->", divWorks);
                File.WriteAllText(filePath, html);
                File.WriteAllText(fileContactPath, htmlContact);
            }

            if (studies.Count() > 0)
            {
                var divStudies = "";

                foreach (var study in studies)
                {
                    if (study.CompanyUserId == 0 || study.CompanyUserId == companyUserId)
                    {
                        divStudies += $"<div class=\"boxWorkExperience w-full\">" +
                                  $"<div class=\"w - full mb - 2\">" +
                                        $"<p class=\"titlesWorkExperience\"><span class=\"dot\"></span>{study.Institution}</p>" +
                                        $"{await GetProfession(study, token)}" +
                                        $"{await GetEndYear(study)}" +
                                  $"</div>" +
                                  $"</div>";
                    }

                }

                html = html.Replace("<!--studies-->", divStudies);
                htmlContact = htmlContact.Replace("<!--studies-->", divStudies);
                File.WriteAllText(filePath, html);
                File.WriteAllText(fileContactPath, htmlContact);
            }

            if (technicalAbilities.Count() > 0)
            {
                var divTechnicalAbilities = "";

                foreach (var technicalAbility in technicalAbilities)
                {
                    if (technicalAbility.CompanyUserId == 0 || technicalAbility.CompanyUserId == companyUserId)
                    {
                        TechnicalAbilityLevel technicalAbilityLevel = await _technicalAbilityLevelRepository.GetById((int)technicalAbility.TechnicalAbilityLevelId);

                        string techAbilityLevel = "";

                        if (technicalAbilityLevel != null && !string.IsNullOrEmpty(technicalAbilityLevel.Level))
                            techAbilityLevel = technicalAbilityLevel.Level;

                        var technicalAbilityName =
                        divTechnicalAbilities += $"<div class=\"boxWorkExperience w-full\">" +
                                       $"<div class=\"w - full mb - 2\">" +
                                              $"<b class=\"titlesWorkExperience\">{GetTechnicalDicipline(technicalAbility)}</b>:  {techAbilityLevel}" +
                                              $"</div>" +
                                    $"</div>";
                    }
                }

                html = html.Replace("<!--habilities-->", divTechnicalAbilities);
                htmlContact = htmlContact.Replace("<!--habilities-->", divTechnicalAbilities);
                File.WriteAllText(filePath, html);
                File.WriteAllText(fileContactPath, htmlContact);
            }

            return true;
        }

        private async Task<bool> GenerateCvs(int candidateId, List<string> fileValues, int language, string token)
        {
            bool isMaster = await _companyRemoteRepository.isMaster(token);

            string html = fileValues[1];
            string htmlContact = fileValues[0];
            string filePath = fileValues[3];
            string fileContactPath = fileValues[2];

            var candidate = await _candidateRepository.GetById(candidateId);
            var description = await _descriptionRepository.GetByCandidateId(candidateId);
            var companyDescription = await _companyDescriptionRepository.GetByCandidateId(candidateId);
            var basicInfo = await _basicInformationRepository.GetByCandidateId(candidateId);
            if (basicInfo == null)
                return false;
            
            List<Candidate_Wellness> candidateWellness = await _candidateJobPreferenceRepository.GetWellnessByCandidateId(candidateId);
            List<Candidate_TimeAvailability> candidate_TimeAvailabilities = await _candidateJobPreferenceRepository.GetTimeAvailabilityByCandidateId(candidateId);
            List<WorkExperience> workExperiences = new List<WorkExperience>();
            List<Study> studies = new List<Study>();
            List<Candidate_TechnicalAbility> technicalAbilities = new List<Candidate_TechnicalAbility>();
            if (isMaster == true)
            {
                //Cambiar metodos 
                studies = await _studyRepository.GetByCandidateIdAdminViewMaster(candidateId);
                technicalAbilities = await _candidateTechnicalAbilityRepository.GetByCandidateIdMaster(candidateId);
                workExperiences = await _workExperienceRepository.GetAdminViewByCandidateIdMaster(candidateId);
            }
            else
            {


                MemberUser memberUser = await _memberUserRepository.GetByEmail(candidate.EmailMember);

                int companyUserId = 0;

                if (memberUser == null)
                    companyUserId = memberUser.CompanyUserId;

                studies = await _studyRepository.GetByCandidateIdAdminView(candidateId, companyUserId);
                technicalAbilities = await _candidateTechnicalAbilityRepository.GetByCandidateId(candidateId);
                workExperiences = await _workExperienceRepository.GetAdminViewByCandidateId(candidateId, companyUserId);
            }




            if (basicInfo.Photo != "" && basicInfo.Photo != null)
            {
                var divPhoto = $"<img class=\"profile\" src=\"{basicInfo.Photo}\" alt=\"\"></img>";
                html = html.Replace("<!--photo-->", divPhoto);
                htmlContact = htmlContact.Replace("<!--photo-->", divPhoto);
                System.IO.File.WriteAllText(filePath, html);
                System.IO.File.WriteAllText(fileContactPath, htmlContact);
            }
            else
            {
                var divPhoto = $"<img class=\"profile\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/_logo.JPG\" alt=\"\"></img>";
                html = html.Replace("<!--photo-->", divPhoto);
                htmlContact = htmlContact.Replace("<!--photo-->", divPhoto);
                System.IO.File.WriteAllText(filePath, html);
                System.IO.File.WriteAllText(fileContactPath, htmlContact);
            }

            if (basicInfo.Name != "" && basicInfo.Name != null)
            {
                var divName = $"<h1 class=\"name\">{basicInfo.Name} {basicInfo.Surname}</h1>";

                var divCandidate = string.Empty;

                if (language == 1) // Español
                    divCandidate = $"<h1 class=\"name\">Candidato Exsis</h1>";
                if (language == 2) // English
                    divCandidate = $"<h1 class=\"name\">Exsis Candidate</h1>";

                html = html.Replace("<!--name-->", divCandidate);
                htmlContact = htmlContact.Replace("<!--name-->", divName);
                System.IO.File.WriteAllText(filePath, html);
                System.IO.File.WriteAllText(fileContactPath, htmlContact);
            }

            if (description != null)
            {
                var divDescription = $"<p class=\"txt-profile\">{description.Text}</p>";
                html = html.Replace("<!--description-->", divDescription);
                htmlContact = htmlContact.Replace("<!--description-->", divDescription);
                System.IO.File.WriteAllText(filePath, html);
                System.IO.File.WriteAllText(fileContactPath, htmlContact);
            }

            if (isMaster == false)
            {
                if ((description == null || string.IsNullOrEmpty(description.Text)) && companyDescription != null)
                {
                    var divCompanyDescription = $"<p class=\"txt-profile\">{companyDescription.Text}</p>";
                    html = html.Replace("<!--description-->", divCompanyDescription);
                    htmlContact = htmlContact.Replace("<!--description-->", divCompanyDescription);
                    System.IO.File.WriteAllText(filePath, html);
                    System.IO.File.WriteAllText(fileContactPath, htmlContact);
                }
            }


            if (candidateWellness.Count > 0 || candidate_TimeAvailabilities.Count > 0)
            {
                List<string> jobPreferences = new List<string>();
                string divJobpreferences = "";

                foreach (Candidate_Wellness wellness in candidateWellness)
                    jobPreferences.Add(wellness.Wellness.WellnessName);

                foreach (Candidate_TimeAvailability timeAvailability in candidate_TimeAvailabilities)
                    jobPreferences.Add(timeAvailability.TimeAvailability.TimeAvailabilityName);

                foreach (string jobPreference in jobPreferences)
                {
                    divJobpreferences += $"<div class=\"w - full mb - 2\">" +
                                         $"<span class=\"dot\"></span>" +
                                         $"<p class=\"ml - 15\">{jobPreference}</p></div>";
                }
                html = html.Replace("<!--jobpreferences-->", divJobpreferences);
                htmlContact = htmlContact.Replace("<!--jobpreferences-->", divJobpreferences);
                System.IO.File.WriteAllText(filePath, html);
                System.IO.File.WriteAllText(fileContactPath, htmlContact);
            }

            if (candidate.Email != "")
            {
                var divEmail = $"<li class=\"email\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/mail.png\" alt=\"\"></img><a href=\"\">  {candidate.Email}</a></li>";
                htmlContact = htmlContact.Replace("<!--email-->", divEmail);
                System.IO.File.WriteAllText(fileContactPath, htmlContact);
            }

            if (isMaster == false)
            {
                if (basicInfo.Emails.Count > 0)
                {
                    var divEmails = "";
                    foreach (var email in basicInfo.Emails)
                        divEmails += $"<li class=\"email\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/mail.png\" alt=\"\"></img><a href=\"\">  {email.Mail}</a></li>";

                    htmlContact = htmlContact.Replace("<!--emails-->", divEmails);
                    System.IO.File.WriteAllText(fileContactPath, htmlContact);
                }
            }


            if (basicInfo.Cellphone != "" && basicInfo.Cellphone != null)
            {
                var divPhone = $"<li class=\"phone\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/phone.png\" alt=\"\"></img><a href=\"\">  {GetPhones(basicInfo.Cellphone, basicInfo.Phone)} </a></li>";
                htmlContact = htmlContact.Replace("<!--phone-->", divPhone);
                System.IO.File.WriteAllText(fileContactPath, htmlContact);
            }

            if (isMaster == false)
            {
                if (basicInfo.Phones.Count > 0)
                {
                    var divPhones = "";
                    foreach (var phone in basicInfo.Phones)
                        divPhones += $"<li class=\"phone\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/phone.png\" alt=\"\"></img><a href=\"\">  {phone.Number} </a></li>";
                    htmlContact = htmlContact.Replace("<!--phones-->", divPhones);
                    System.IO.File.WriteAllText(fileContactPath, htmlContact);
                }
            }


            if (basicInfo.LinkedInURL != "" && basicInfo.LinkedInURL != null && basicInfo.LinkedInURL != null)
            {
                string linkedInShort = string.Empty;

                string[] linkedInSplit = [];

                if (!string.IsNullOrEmpty(basicInfo.LinkedInURL))
                {
                    linkedInSplit = basicInfo.LinkedInURL.Split("?");

                    if (linkedInSplit != null)
                    {
                        if (linkedInSplit.Length > 0)
                            linkedInShort = linkedInSplit[0];
                        else
                            linkedInShort = basicInfo.LinkedInURL;
                    }
                }


                var divLinkedIn = $"<li class=\"linkedin\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/linkedin.png\" alt=\"\"></img><a href=\"{HttpURL(linkedInShort)}\" target=\"_blank\">  @{GetNickName(linkedInShort)}</a></li>";
                htmlContact = htmlContact.Replace("<!--linkedin-->", divLinkedIn);
                System.IO.File.WriteAllText(fileContactPath, htmlContact);
            }

            if (basicInfo.FacebookURL != "" && basicInfo.FacebookURL != null)
            {
                var divFaceBook = $"<li class=\"facebook\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/facebook.png\" alt=\"\"></img><a href=\"{HttpURL(basicInfo.FacebookURL)}\" target=\"_blank\">  @{GetNickName(basicInfo.FacebookURL)}</a></li>";
                htmlContact = htmlContact.Replace("<!--facebook-->", divFaceBook);
                System.IO.File.WriteAllText(fileContactPath, htmlContact);
            }

            if (basicInfo.GitHubURL != "" && basicInfo.GitHubURL != null)
            {
                var divGitHub = $"<li class=\"github\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/github.png\" alt=\"\"></img><a href=\"{HttpURL(basicInfo.GitHubURL)}\" target=\"_blank\">  @{GetNickName(basicInfo.GitHubURL)}</a></li>";
                htmlContact = htmlContact.Replace("<!--github-->", divGitHub);
                System.IO.File.WriteAllText(fileContactPath, htmlContact);
            }

            if (basicInfo.BitBucketURL != "" && basicInfo.BitBucketURL != null)
            {
                var divBitBucket = $"<li class=\"bitbucket\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/bitbucket.png\" alt=\"\"></img><a href=\"{HttpURL(basicInfo.BitBucketURL)}\" target=\"_blank\">  @{GetNickName(basicInfo.BitBucketURL)}</a></li>";
                htmlContact = htmlContact.Replace("<!--bitbucket-->", divBitBucket);
                System.IO.File.WriteAllText(fileContactPath, htmlContact);
            }

            if (basicInfo.TwitterURL != "" && basicInfo.TwitterURL != null)
            {
                var divTwitter = $"<li class=\"twitter\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/x.png\" alt=\"\"></img><a href=\"{HttpURL(basicInfo.TwitterURL)}\" target=\"_blank\">  @{GetNickName(basicInfo.TwitterURL)}</a></li>";
                htmlContact = htmlContact.Replace("<!--twitter-->", divTwitter);
                System.IO.File.WriteAllText(fileContactPath, htmlContact);
            }

            if (isMaster == false)
            {
                if (basicInfo.SocialNetworks.Count > 0)
                {
                    var divLinkedIns = "";
                    var divFaceBooks = "";
                    var divTwitters = "";
                    var divLinks = "";
                    foreach (var sn in basicInfo.SocialNetworks)
                    {
                        string linkedInShort = string.Empty;

                        string[] linkedInSplit = [];

                        if (!string.IsNullOrEmpty(sn.Link))
                        {
                            linkedInSplit = sn.Link.Split("?");

                            if (linkedInSplit != null)
                            {
                                if (linkedInSplit.Length > 0)
                                    linkedInShort = linkedInSplit[0];
                                else
                                    linkedInShort = sn.Link;
                            }
                        }

                        if (sn.Link.Contains("facebook"))
                            divFaceBooks += $"<li class=\"facebook\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/facebook.png\" alt=\"\"></img><a href=\"{HttpURL(sn.Link)}\" target=\"_blank\">  @{GetNickName(sn.Link)}</a></li>";
                        else if (sn.Link.Contains("linkedin"))
                            divLinkedIns += $"<li class=\"linkedin\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/linkedin.png\" alt=\"\"></img><a href=\"{HttpURL(linkedInShort)}\" target=\"_blank\">  @{GetNickName(linkedInShort)}</a></li>";
                        else if (sn.Link.Contains("twitter"))
                            divTwitters += $"<li class=\"twitter\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/x.png\" alt=\"\"></img><a href=\"{HttpURL(sn.Link)}\" target=\"_blank\">  @{GetNickName(sn.Link)}</a></li>";
                        else
                            divLinks += $"<li class=\"link\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/mundoblanco.png\" alt=\"\"></img><a href=\"{HttpURL(sn.Link)}\" target=\"_blank\">  @{GetNickName(sn.Link)}</a></li>";
                    }
                    htmlContact = htmlContact.Replace("<!--facebooks-->", divFaceBooks);
                    System.IO.File.WriteAllText(fileContactPath, htmlContact);
                    htmlContact = htmlContact.Replace("<!--linkedins-->", divLinkedIns);
                    System.IO.File.WriteAllText(fileContactPath, htmlContact);
                    htmlContact = htmlContact.Replace("<!--twitters-->", divTwitters);
                    System.IO.File.WriteAllText(fileContactPath, htmlContact);
                    htmlContact = htmlContact.Replace("<!--linkssocial-->", divLinks);
                    System.IO.File.WriteAllText(fileContactPath, htmlContact);
                }
            }


            if (isMaster == false)
            {
                if (basicInfo.UserLinks.Count > 0)
                {
                    var divGitHubs = "";
                    var divBitBuckets = "";
                    var divLinks = "";
                    foreach (var ul in basicInfo.UserLinks)
                    {
                        if (ul.Link.Contains("github"))
                            divGitHubs += $"<li class=\"github\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/github.png\" alt=\"\"></img><a href=\"{HttpURL(ul.Link)}\" target=\"_blank\">  @{GetNickName(ul.Link)}</a></li>";
                        else if (ul.Link.Contains("bitbucket"))
                            divBitBuckets += $"<li class=\"bitbucket\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/bitbucket.png\" alt=\"\"></img><a href=\"{HttpURL(ul.Link)}\" target=\"_blank\">  @{GetNickName(ul.Link)}</a></li>";
                        else
                            divLinks += $"<li class=\"link\"> <img class=\"icon-social\" src=\"https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/images/mundoblanco.png\" alt=\"\"></img><a href=\"{HttpURL(ul.Link)}\" target=\"_blank\">  @{GetNickName(ul.Link)}</a></li>";
                    }
                    htmlContact = htmlContact.Replace("<!--githubs-->", divGitHubs);
                    System.IO.File.WriteAllText(fileContactPath, htmlContact);
                    htmlContact = htmlContact.Replace("<!--bitbuckets-->", divBitBuckets);
                    System.IO.File.WriteAllText(fileContactPath, htmlContact);
                    htmlContact = htmlContact.Replace("<!--links-->", divLinks);
                    System.IO.File.WriteAllText(fileContactPath, htmlContact);
                }
            }

            if (workExperiences.Count() > 0)
            {
                var divWorks = "";
                foreach (var work in workExperiences)
                {
                    var divFunctions = GetFunacions(work.Functions);
                    divWorks += $"<div class=\"boxWorkExperience w-full\">" +
                                   $"<div class=\"w-full mb-2\">" +
                                        $"<p class=\"titlesWorkExperience\"><span class=\"dot\"></span>{work.Position}</p>" +
                                        $"<p class=\"tstWorkExperienceItem\">{GetJobDates(work.StartDate, work.EndDate)}, {work.Company}</p>" +
                                        $"<p class=\"tstWorkExperienceItem\">{GetLocation(work)}</p>" +
                                   $"</div>" +
                                   $"{GetFunacions(work.Functions)}" +
                                $"</div>";
                }
                html = html.Replace("<!--workexperience-->", divWorks);
                htmlContact = htmlContact.Replace("<!--workexperience-->", divWorks);
                System.IO.File.WriteAllText(filePath, html);
                System.IO.File.WriteAllText(fileContactPath, htmlContact);
            }

            if (studies.Count() > 0)
            {
                var divStudies = "";
                foreach (var study in studies)
                {
                    divStudies += $"<div class=\"boxWorkExperience w-full\">" +
                                  $"<div class=\"w - full mb - 2\">" +
                                        $"<p class=\"titlesWorkExperience\"><span class=\"dot\"></span>{study.Institution}</p>" +
                                        $"{await GetProfession(study, token)}" +
                                        $"{await GetEndYear(study)}" +
                                  $"</div>" +
                                  $"</div>";

                }
                html = html.Replace("<!--studies-->", divStudies);
                htmlContact = htmlContact.Replace("<!--studies-->", divStudies);
                System.IO.File.WriteAllText(filePath, html);
                System.IO.File.WriteAllText(fileContactPath, htmlContact);
            }

            if (technicalAbilities.Count() > 0)
            {
                var divTechnicalAbilities = "";
                foreach (var technicalAbility in technicalAbilities)
                {
                    var technicalAbilityName =
                    divTechnicalAbilities += $"<div class=\"boxWorkExperience w-full\">" +
                                       $"<div class=\"w - full mb - 2\">" +
                                              $"<b class=\"titlesWorkExperience\">{GetTechnicalDicipline(technicalAbility)}</b>:  {technicalAbility.TechnicalAbilityLevel}" +
                                              $"</div>" +
                                    $"</div>";
                }
                html = html.Replace("<!--habilities-->", divTechnicalAbilities);
                htmlContact = htmlContact.Replace("<!--habilities-->", divTechnicalAbilities);
                System.IO.File.WriteAllText(filePath, html);
                System.IO.File.WriteAllText(fileContactPath, htmlContact);
            }

            return true;
        }

        private string GetTechnicalDicipline(Candidate_TechnicalAbility technicalAbility)
        {
            if (technicalAbility.TechnicalAbilityTechnologyId == 54)
                return technicalAbility.Other;
            return technicalAbility.Discipline;
        }

        private string GetPhones(string cellphone, string phone)
        {
            var phones = cellphone;
            if (phone != null && phone != null)
                phones += $"  -  {phone}";
            return phones;
        }

        private async Task<string> GetProfession(Study study, string token)
        {
            if (study.JobProfessionId == 118)
                return $"<p class=\"tstWorkExperienceItem\">{study.OtherJobProfession}</p>";

            var profession = await _companyRemoteRepository.GetJobProfessionById(study.JobProfessionId, token);
            if(profession != null)                
                return $"<p class=\"tstWorkExperienceItem\">{profession.Profession}</p>";
            return "";
        }

        private async Task<object> GetEndYear(Study study)
        {
            if(study.CompletionStudies == "true")
            {
                try
                {
                    double ticks = double.Parse(study.EndDate);

                    DateTime date = (new DateTime(1970, 1, 1)).AddMilliseconds(ticks);

                    return $"<p class=\"tstWorkExperienceItem\">{date.ToString("yyyy", new CultureInfo("es-ES"))}</p>";
                }          
                catch(Exception)
                {
                    return $"<p class=\"tstWorkExperienceItem\">N/A</p>";
                }
            }
            else
            {
                double ticks = 0;

                if (study != null && !string.IsNullOrEmpty(study.StartDate))
                    ticks = double.Parse(study.StartDate);

                DateTime date = (new DateTime(1970, 1, 1)).AddMilliseconds(ticks);

                StudyState studyState = await _studyStateRepository.GetById(study.StudyStateId);

                string startDateInfo = string.Empty;

                try
                {
                    startDateInfo = $"<p class=\"tstWorkExperienceItem\">Fecha inicio {date.ToString("dd/mm/yyyy", new CultureInfo("es-ES"))}</p>";
                }
                catch (Exception)
                {
                    startDateInfo = $"<p class=\"tstWorkExperienceItem\">Fecha inicio N/A</p>";
                }

                startDateInfo += $"<p class=\"tstWorkExperienceItem\">{studyState.Name}</p>";

                return startDateInfo;
            }
        }

        private object GetFunacions(string functions)
        {
            if(functions != "" && functions != null)
                return $"<div><div class=\"flex flex-wrap mb-1\">" +
                            $"<p class=\"titlesWorkExperience\">Funciones y logros:&nbsp;</p> " +
                            $"<p class=\"tstWorkExperienceItem\">{functions}</p>" +
                       $"</div></div>";
            return "";
        }

        private object GetLocation(WorkExperience work)
        {
            if(string.IsNullOrEmpty(work.CityName))
                return "";

            if (work.CountryName != null && work.CityName != null)
                return $"<p class=\"tstWorkExperienceItem\">{work.CityName}, {work.CountryName}</p>";

            return "";
        }

        private string GetJobDates(string startDate, string endDate)
        {
            string response = string.Empty;

            try
            {
                double ticks = double.Parse(startDate);

                DateTime date = (new DateTime(1970, 1, 1)).AddMilliseconds(ticks);

                string _startDate = date.ToString("MMMM yyyy", new CultureInfo("es-ES"));

                response = _startDate + " - ";
            }
            catch (Exception)
            {
                response = "N/A - ";
            }

            if (endDate != null && endDate != "null")
            {
                try
                {
                    double ticks = double.Parse(endDate);

                    DateTime date = (new DateTime(1970, 1, 1)).AddMilliseconds(ticks);

                    string _endDate = date.ToString("MMMM yyyy", new CultureInfo("es-ES"));

                    return response + _endDate;
                }
                catch(Exception)
                {
                    response = response + "N/A";
                }
            }

            return response + "Actualmente ";
        }

        private string GetNickName(string url)
        {
            string[] words = url.Split('/');

            if(words[words.Count() - 1].Count() == 0 && words[words.Count() - 2].Length < 20)
                return words[words.Count() - 2];
            else if(words[words.Count() - 1].Length < 20)
                return words[words.Count() - 1];

            if (!string.IsNullOrEmpty(url) && url.Count() >= 20)
                url = url.Substring(0, 20);

            return url;
        }

        private string HttpURL(string url)
        {
            if (url.Count() >= 4 && url.Substring(0, 4).ToLower() != "http")
                return "http://" + url;

            return url;
        }

        public async Task<List<string>> GetFileTemplateAsync(int language)
        {
            List<string> values = new List<string>();
            string currentPath = Directory.GetCurrentDirectory();
            string folderPath = Path.GetFullPath(Path.Combine(currentPath, "Files"));
            Directory.CreateDirectory(folderPath);

            //Get cv html
            WebClient client = new WebClient();

            Uri uri = null;
            Uri uriNoContact = null;

            if(language == 1) // Español
                uri = new Uri("https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/PlantilaXHTML.html");
            if(language == 2) // English
                uri = new Uri("https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/PlantilaXHTMLEnglish.html");

            Stream stream = await client.OpenReadTaskAsync(uri);
            StreamReader reader = new StreamReader(stream);
            var html = reader.ReadToEnd().ToString();

            if (language == 1) // Español
                uriNoContact = new Uri("https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/PlantilaXHTMLNoContact.html");
            if (language == 2) // English
                uriNoContact = new Uri("https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/PlantilaXHTMLNoContactEnglish.html");

            Stream streamNoContact = await client.OpenReadTaskAsync(uriNoContact);
            StreamReader readerNoContact = new StreamReader(streamNoContact);
            var htmlNoContact = readerNoContact.ReadToEnd().ToString();

            string fileNoContactPath = Path.GetFullPath(Path.Combine(folderPath, "htmlInfo.html"));

            string fileContactPath = Path.GetFullPath(Path.Combine(folderPath, "htmlContactInfo.html"));

            stream.Close();
            reader.Close();

            streamNoContact.Close();
            readerNoContact.Close();

            File.WriteAllText(fileNoContactPath, htmlNoContact);
            File.WriteAllText(fileContactPath, html);

            values.Add(html);
            values.Add(htmlNoContact);
            values.Add(fileContactPath);
            values.Add(fileNoContactPath);

            return values;
        }

        public async Task<bool> CvGeneratedExistByCandidateId(int candidateId)
        {
            var cvs = await _cvRepository.GetAllByCandidateId(candidateId);
            foreach(var cv in cvs)
                if (cv.CvIdentifier.Contains("GeneratedCV"))
                    return true;
            return false;
        }

        public async Task<bool> CvGeneratedExistByCandidateAndCompanyId(int candidateId, int companyUserId)
        {
            var cvs = await _cvRepository.GetAllByCandidateIdAndCompanyUserId(candidateId, companyUserId);
            foreach (var cv in cvs)
                if (cv.CvIdentifier.Contains("GeneratedCV"))
                    return true;
            return false;
        }

        public async Task<bool> CvGeneratedContactExistByCandidateId(int candidateId)
        {
            var cvs = await _cvRepository.GetAllByCandidateId(candidateId);
            foreach (var cv in cvs)
                if (cv.CvIdentifier.Contains("GeneratedContactCV"))
                    return true;
            return false;
        }

        public async Task<bool> CvGeneratedContactExistByCandidateAndCompanyId(int candidateId, int companyUserId)
        {
            var cvs = await _cvRepository.GetAllByCandidateIdAndCompanyUserId(candidateId, companyUserId);
            foreach (var cv in cvs)
                if (cv.CvIdentifier.Contains("GeneratedContactCV"))
                    return true;
            return false;
        }

        public async Task<bool> CvGeneratedExistByCandidateIdMaster(int candidateId)
        {
            var cvs = await _cvRepository.GetAllByCandidateIdMaster(candidateId);
            foreach (var cv in cvs)
                if (cv.CvIdentifier.Contains("GeneratedCV"))
                    return true;
            return false;
        }

        public async Task<bool> CvGeneratedContactExistByCandidateIdMaster(int candidateId)
        {
            var cvs = await _cvRepository.GetAllByCandidateIdMaster(candidateId);
            foreach (var cv in cvs)
                if (cv.CvIdentifier.Contains("GeneratedContactCV"))
                    return true;
            return false;
        }

        public async Task<bool> RemoveCvGeneratedByCandidateId(int candidateId)
        {
            var cvs = await _cvRepository.GetAllByCandidateId(candidateId);
            foreach (var cv in cvs)
            {
                if (cv.CvIdentifier.Contains("GeneratedCV"))
                {
                    cv.UploadDate = _matchServerDate.GetDateTimeByServer().ToString();
                    await _cvRepository.Remove(cv.CVId);
                    //await _AWSS3FileService.DeleteFile(cv.CvIdentifier);
                }
            }
            return true;
        }

        public async Task<bool> RemoveCvGeneratedByCandidateAndCompanyId(int candidateId, int companyUserId)
        {
            var cvs = await _cvRepository.GetAllByCandidateIdAndCompanyUserId(candidateId, companyUserId);
            foreach (var cv in cvs)
            {
                if (cv.CvIdentifier.Contains("GeneratedCV"))
                {
                    cv.UploadDate = _matchServerDate.GetDateTimeByServer().ToString();
                    await _cvRepository.Remove(cv.CVId);
                    //await _AWSS3FileService.DeleteFile(cv.CvIdentifier);
                }
            }
            return true;
        }

        public async Task<bool> RemoveCvGeneratedContactByCandidateId(int candidateId)
        {
            var cvs = await _cvRepository.GetAllByCandidateId(candidateId);
            foreach (var cv in cvs)
            {
                if (cv.CvIdentifier.Contains("GeneratedContactCV"))
                {
                    cv.UploadDate = _matchServerDate.GetDateTimeByServer().ToString();
                    await _cvRepository.Remove(cv.CVId);
                    //await _AWSS3FileService.DeleteFile(cv.CvIdentifier);
                }
            }
            return true;
        }

        public async Task<bool> RemoveCvGeneratedContactByCandidateAndCompanyId(int candidateId, int companyUserId)
        {
            var cvs = await _cvRepository.GetAllByCandidateIdAndCompanyUserId(candidateId, companyUserId);
            foreach (var cv in cvs)
            {
                if (cv.CvIdentifier.Contains("GeneratedContactCV"))
                {
                    cv.UploadDate = _matchServerDate.GetDateTimeByServer().ToString();
                    await _cvRepository.Remove(cv.CVId);
                    //await _AWSS3FileService.DeleteFile(cv.CvIdentifier);
                }
            }
            return true;
        }

        public async Task<bool> RemoveCvGeneratedByCandidateIdMaster(int candidateId)
        {
            var cvs = await _cvRepository.GetAllByCandidateIdMaster(candidateId);
            foreach (var cv in cvs)
            {
                if (cv.CvIdentifier.Contains("GeneratedCV"))
                {
                    cv.UploadDate = _matchServerDate.GetDateTimeByServer().ToString();
                    await _cvRepository.Remove(cv.CVId);
                    //await _AWSS3FileService.DeleteFile(cv.CvIdentifier);
                }
            }
            return true;
        }

        public async Task<bool> RemoveCvGeneratedContactByCandidateIdMaster(int candidateId)
        {
            var cvs = await _cvRepository.GetAllByCandidateIdMaster(candidateId);
            foreach (var cv in cvs)
            {
                if (cv.CvIdentifier.Contains("GeneratedContactCV"))
                {
                    cv.UploadDate = _matchServerDate.GetDateTimeByServer().ToString();
                    await _cvRepository.Remove(cv.CVId);
                    //await _AWSS3FileService.DeleteFile(cv.CvIdentifier);
                }
            }
            return true;
        }



        public async Task<byte[]> GetDocFileUrls(int candidateId,bool isMaster)
        {
            byte[] byteArr;
            List<CV> cvs = new List<CV>();
            if(isMaster==true)
                cvs = await _cvRepository.GetAllByCandidateIdMaster(candidateId);
            else
                cvs = await _cvRepository.GetAllByCandidateId(candidateId);

            string folderPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "Files"));
            string filePath = Path.GetFullPath(Path.Combine(folderPath, await GetFileName(candidateId)));
            var content = "";
            
            foreach (var cv in cvs)
            {
                if (cv.CvIdentifier.Contains("GeneratedCV") || cv.CvIdentifier.Contains("GeneratedContactCV"))
                    content += cv.CvIdentifierLink + "\n";
            }
            System.IO.File.WriteAllText(filePath, content);
            var fsSource = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
            using (var memoryStream = new MemoryStream())
            {
                fsSource.CopyTo(memoryStream);
                byteArr = memoryStream.ToArray();
                fsSource.Close();
                File.Delete(filePath);
            }
            return byteArr;
        }

        public async Task<byte[]> GetDocFileUrlsByCompany(int candidateId, int companyUserId, bool isMaster)
        {
            byte[] byteArr;
            List<CV> cvs = new List<CV>();
            if (isMaster == true)
                cvs = await _cvRepository.GetAllByCandidateIdMaster(candidateId);
            else
                cvs = await _cvRepository.GetAllByCandidateIdAndCompanyUserId(candidateId, companyUserId);

            string folderPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "Files"));
            string filePath = Path.GetFullPath(Path.Combine(folderPath, await GetFileName(candidateId)));
            var content = "";

            foreach (var cv in cvs)
            {
                if (cv.CvIdentifier.Contains("GeneratedCV") || cv.CvIdentifier.Contains("GeneratedContactCV"))
                    content += cv.CvIdentifierLink + "\n";
            }
            System.IO.File.WriteAllText(filePath, content);
            var fsSource = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite);
            using (var memoryStream = new MemoryStream())
            {
                fsSource.CopyTo(memoryStream);
                byteArr = memoryStream.ToArray();
                fsSource.Close();
                File.Delete(filePath);
            }
            return byteArr;
        }

        public async Task<Dictionary<string, dynamic>> GetDocFileDownloadByCompany(int candidateId, int companyUserId, int cvType, int fileType, bool isMaster)
        {
            byte[] byteArr;

            Dictionary<string, dynamic> returnType = new Dictionary<string, dynamic>();

            List<CV> cvs = new List<CV>();

            if (isMaster == true)
                cvs = await _cvRepository.GetAllByCandidateIdMaster(candidateId);
            else
                cvs = await _cvRepository.GetAllByCandidateIdAndCompanyUserId(candidateId, companyUserId);

            string folderPath = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), "Files"));
            string filePath = Path.GetFullPath(Path.Combine(folderPath, await GetFileName(candidateId)));

            string name = "";
            string htmlUrlAddress = "";

            foreach (var cv in cvs)
            {
                if (cvType == 1 && cv.CvIdentifier.Contains("GeneratedCV"))
                {
                    htmlUrlAddress = cv.CvIdentifierLink;
                    name = cv.Name;

                    break;
                }
                if (cvType == 2 && cv.CvIdentifier.Contains("GeneratedContactCV"))
                {
                    htmlUrlAddress = cv.CvIdentifierLink;
                    name = cv.Name;

                    break;
                }
            }

            try
            {
                MemoryStream memoryStream = null;

                WebClient htmlClient = new WebClient();
                Uri htmlUri = new Uri(htmlUrlAddress);

                Stream htmlStream = await htmlClient.OpenReadTaskAsync(htmlUri);

                StreamReader htmlReader = new StreamReader(htmlStream);

                string htmlBody = htmlReader.ReadToEnd();

                byte[] htmlBytes = Encoding.UTF8.GetBytes(htmlBody);

                BodyBuilder htmlBuilder = new BodyBuilder
                {
                    HtmlBody = htmlBody,
                    TextBody = htmlBody
                };

                if (fileType == 1)
                {
                    name = name.Replace(".html", ".pdf");

                    Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

                    var workStream = new MemoryStream();

                    ConverterProperties properties = new ConverterProperties();
                    WriterProperties writerProperties = new WriterProperties();

                    properties.SetBaseUri("https://recursos-correos-lambda.s3.amazonaws.com/Plantilla+Pdf/assets/css/orbit-1.css");

                    writerProperties.UseSmartMode();
                    writerProperties.SetFullCompressionMode(true);

                    using (PdfWriter pdfWriter = new PdfWriter(workStream, writerProperties))
                    {
                        pdfWriter.SetCloseStream(false);

                        using (Document document = HtmlConverter.ConvertToDocument(htmlBody, pdfWriter, properties))
                        {
                            document.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.CENTER);
                            document.SetMargins(0, 0, 0, 0);
                        }
                    }

                    workStream.Position = 0;

                    memoryStream = workStream;
                }
                else if (fileType == 2)
                {
                    memoryStream = new MemoryStream(Encoding.UTF8.GetBytes(htmlBuilder.HtmlBody));
                }

                returnType["memoryStream"] = memoryStream;
                returnType["name"] = name;

                return returnType;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void RemoveUrlsFile(string path)
        {
            File.Delete(path);
        }

        public string GetFileName(string name, string surname)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetFileName(int candidateId)
        {
            var nameFile = "CV ";
            var candidate = await _basicInformationRepository.GetByCandidateId(candidateId);
            nameFile += candidate.Name;
            if (candidate.Surname != "" || candidate.Surname != null)
                nameFile += $" {candidate.Surname}";
            nameFile += $".txt";
            nameFile = nameFile.Replace(" ", "_");
            return nameFile;
        }
    }
}
