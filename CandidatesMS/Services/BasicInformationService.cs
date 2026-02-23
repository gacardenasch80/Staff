using AutoMapper;
using CandidatesMS.Models;
using CandidatesMS.Models.RemoteModels.In;
using CandidatesMS.Models.RemoteModels.Out;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.Infraestructure.Services;
using CandidatesMS.Repositories;
using CandidatesMS.Repositories.RemoteRepositories;
using CandidatesMS.KeyVault.SecretsModels;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Services
{
    public interface IBasicInformationService
    {
        public Task<CandidateSectionTotalDTO> GetCandidateSection(SearchByIdAndTextWithPaginationDTO search, int companyUserId, int userType, string token);
        public string Initials(string name, string surName);
        public string Name(string name, string surName);
        public Task<string> CreationDate(int candidateId);
        public string GetCreationDateFromString(string creationDate);
        public Task<string> CreationDateEnglish(int candidateId);
        public string GetCreationDateFromStringEnglish(string creationDate);
        public Task<string> CreationDatePopUp(int candidateId);
        public string GetCreationDatePopUpByDate(string creationDateString);
        public Task<string> CreationDatePopUpEnglish(int candidateId);
        public string GetCreationDatePopUpByDateEnglish(string creationDateString);
    }

    public class BasicInformationService : IBasicInformationService
    {
        private IBasicInformationRepository _basicInformationRepository;
        private IMapper _mapper;
        private ICandidateRepository _candidateRepository;
        private IUploadTimeService _uploadTimeService;
        private readonly CognitoConfiguration _settings;
        private readonly ServiceConfigurationDTO _s3Settings;
        private ICompanyRemoteRepository _companyRemoteRepository;
        public BasicInformationService(IBasicInformationRepository basicInformationRepository, IMapper mapper,
                                        ICandidateRepository candidateRepository, IUploadTimeService uploadTimeService,
                                        ICompanyRemoteRepository companyRemoteRepository,
                                        IOptions<CognitoConfiguration> settings, IOptions<ServiceConfigurationDTO> s3settings)
        {
            _basicInformationRepository = basicInformationRepository;
            _mapper = mapper;
            _candidateRepository = candidateRepository;
            _uploadTimeService = uploadTimeService;
            _companyRemoteRepository = companyRemoteRepository;
            _settings = settings.Value;
            _s3Settings = s3settings.Value;
        }

        public async Task<CandidateSectionTotalDTO> GetCandidateSection(SearchByIdAndTextWithPaginationDTO search, int companyUserId, int userType, string token)
        {
            bool isMaster = false;

            if (userType == 0)
                isMaster = true;

            List<Candidate> candidates = new List<Candidate>();

            if(isMaster && !search.Ascending)
                candidates = await _candidateRepository.GetPageSectionCandidateMaster(search.Page, search.PageSize);
            else if (!isMaster && !search.Ascending)
                candidates = await _candidateRepository.GetPageSectionCandidate(search.Page, search.PageSize, userType, companyUserId);
            else if (isMaster && search.Ascending)
                candidates = await _candidateRepository.GetPageSectionAscendingCandidateMaster(search.Page, search.PageSize);
            else
                candidates = await _candidateRepository.GetPageSectionAscendingCandidate(search.Page, search.PageSize, userType, companyUserId);


            if (candidates != null && candidates.Count > 0)
            {
                List<CandidateSectionDTO> candidateSectionListDTO = new List<CandidateSectionDTO>();

                List <PostulationJobNameInDTO> postulations = await _companyRemoteRepository.GetAllPostulationsWithNameAndColourFlag(token);

                List<CandidateTalentGroupNameInDTO> talentGroups = await _companyRemoteRepository.GetAllCandidateTalentWithNameAndColourFlag(token);

                List<CandidateDTO> candidatesDTO = _mapper.Map<List<Candidate>, List<CandidateDTO>>(candidates);

                foreach (var candidate in candidatesDTO)
                {                    
                    var photo = "";
                    var init = "";
                    var name = "";
                    List<string> jobNames = new List<string>();
                    List<string> talentNames = new List<string>();
                    var jobCount = 0;
                    var talentCount = 0;

                    List<PostulationJobNameInDTO> jobs = new List<PostulationJobNameInDTO>();

                    if (postulations != null && postulations.Count > 0)
                    {
                        jobs = postulations.Where(x => x.candidateId == candidate.CandidateId).ToList();
                        
                        if (jobs != null && jobs.Count > 0)
                        {
                            foreach (var job in jobs)
                            {
                                if (job != null)
                                    jobNames.Add(job.jobName);
                            }

                            jobCount = jobNames.Count();
                        }
                    }

                    List<CandidateTalentGroupNameInDTO> talents = new List<CandidateTalentGroupNameInDTO>();

                    if (talentGroups != null && talentGroups.Count > 0)
                    {
                        talents = talentGroups.Where(x => x.candidateId == candidate.CandidateId).ToList();
                        
                        if (talents != null && talents.Count > 0)
                        {
                            foreach (var talent in talents)
                            {
                                if (talent != null)
                                    talentNames.Add(talent.talentGroupName);
                            }

                            talentCount = talentNames.Count();
                        }
                    }

                    string creationDate = await CreationDate(candidate.CandidateId);
                    string creationDatePopUp = await CreationDatePopUp(candidate.CandidateId);
                    string creationDateEnglish = await CreationDateEnglish(candidate.CandidateId);
                    string creationDateEnglishPopUp = await CreationDatePopUpEnglish(candidate.CandidateId); 

                    if(candidate.BasicInformation != null)
                    {
                        if (!String.IsNullOrEmpty(candidate.BasicInformation.Photo) && candidate.BasicInformation.Photo != null)
                            photo = candidate.BasicInformation.Photo;
                        else
                            init = Initials(candidate.BasicInformation.Name, candidate.BasicInformation.Surname);

                        name = Name(candidate.BasicInformation.Name, candidate.BasicInformation.Surname);
                    }
                    if(candidate.BasicInformation == null && !string.IsNullOrEmpty(candidate.Email) && candidate.Email != null)
                    {
                        name = candidate.Email;
                        var sub = name.Substring(0, 2);
                        init = sub.ToUpper();
                    }

                    CandidateSectionDTO candidateSectionDTO = new CandidateSectionDTO()
                    {
                        CandidateId = candidate.CandidateId,
                        Photo = photo,
                        Initials = init,
                        Name = name,
                        CreationDateString = candidate.CreationDate,
                        CreationDate = creationDate,
                        CreationDateEnglish = creationDateEnglish,
                        CreationDatePopUp = creationDatePopUp,
                        CreationDatePopUpEnglish = creationDateEnglishPopUp,
                        Jobs = jobNames,
                        TotalJobs = jobCount,
                        TalentGroups = talentNames,
                        TotalTalentGroups = talentCount,
                        IsDeleteProccess = candidate.IsDeleteProccess
                    };

                    if (jobs != null && jobs.Count > 0)
                    {
                        jobs.OrderByDescending(x => x.creationDate).ToList();

                        candidateSectionDTO.ColourFlag = jobs[0].colourFlag;

                        candidateSectionDTO.ColourFlagToltip = jobs[0].jobName;
                    }

                    if (candidateSectionDTO.ColourFlag == 0 && talents != null && talents.Count > 0)
                    {
                        talents.OrderByDescending(x => x.creationDate).ToList();

                        candidateSectionDTO.ColourFlag = talents[0].colourFlag;

                        candidateSectionDTO.ColourFlagToltip = talents[0].talentGroupName;
                    }

                    if (candidateSectionDTO != null)
                        candidateSectionListDTO.Add(candidateSectionDTO);
                }                

                if (candidateSectionListDTO != null && candidateSectionListDTO.Count > 0)
                {
                    int exsisCompanyUserId = 0;

                    if (_s3Settings.AWSS3.BucketName == "recruitment-bucket-prod")
                        exsisCompanyUserId = 3;
                    else
                        exsisCompanyUserId = 4;

                    int totalCandidates;
                    if (isMaster == true)
                        totalCandidates = await _candidateRepository.CountAllCandidateMaster();
                    else if(exsisCompanyUserId == companyUserId)
                        totalCandidates = await _candidateRepository.CountAllCandidatesToExsis(exsisCompanyUserId);
                    else
                        totalCandidates = await _candidateRepository.CountAllCandidatesFromCompany(companyUserId);

                    for (int i = 0; i < candidateSectionListDTO.Count; i++)
                    {
                        if (i == 0)
                            candidateSectionListDTO[i].Previous = 0;
                        else
                            candidateSectionListDTO[i].Previous = candidateSectionListDTO[i - 1].CandidateId;

                        if (i == candidateSectionListDTO.Count - 1)
                            candidateSectionListDTO[i].Next = 0;
                        else
                            candidateSectionListDTO[i].Next = candidateSectionListDTO[i + 1].CandidateId;
                    }

                    CandidateSectionTotalDTO candidateSectionTotalDTO = new CandidateSectionTotalDTO()
                    {
                        CandidateSectionList = candidateSectionListDTO,
                        TotalCandidates = totalCandidates
                    };
                    return candidateSectionTotalDTO;
                }
                    
                else
                    return null;
            }
            else
            {
                return null;
            }            
        }

        public string Initials(string name, string surName)
        {
            var init = "";
            if (!String.IsNullOrEmpty(name) && name != null && !String.IsNullOrEmpty(surName) && surName != null)
            {
                var initialName = name[0];
                var initialSurnameName = surName[0];
                init = (initialName + "" + initialSurnameName).ToUpper();
            }
            else if (!String.IsNullOrEmpty(name) && String.IsNullOrEmpty(surName))
            {
                var initialName = name[0];
                var secondName = name[1];
                init = (initialName + "" + secondName).ToUpper();
            }

            return init;
        }

        public string Name(string name, string surName)
        {
            var nameCandidate = "";
            if (!String.IsNullOrEmpty(name) && name != null && !String.IsNullOrEmpty(surName) && surName != null)
            {              
                nameCandidate = name + " " + surName;
            }            
            else if (!String.IsNullOrEmpty(name) && String.IsNullOrEmpty(surName))
            {               
                nameCandidate = name;
            }

            return nameCandidate;
        }

        public async Task<string> CreationDate(int candidateId)
        {            
            var candidate = await _candidateRepository.GetByCandidateId(candidateId);
            var date = _uploadTimeService.GetCreationDate(candidate.CreationDate.ToString());
            if(!String.IsNullOrEmpty(date) && date != null)
                return date;
            else
                return "";
        }

        public string GetCreationDateFromString(string creationDate)
        {
            string date = _uploadTimeService.GetCreationDate(creationDate.ToString());

            if (!string.IsNullOrEmpty(date))
                return date;
            
            return "";
        }

        public async Task<string> CreationDateEnglish(int candidateId)
        {
            var candidate = await _candidateRepository.GetByCandidateId(candidateId);
            var date = _uploadTimeService.GetPublicationEnglish(candidate.CreationDate.ToString());
            if (!String.IsNullOrEmpty(date) && date != null)
                return date;
            else
                return "";
        }

        public string GetCreationDateFromStringEnglish(string creationDate)
        {
            string date = _uploadTimeService.GetCreationDateEnglish(creationDate.ToString());

            if (!string.IsNullOrEmpty(date))
                return date;

            return "";
        }

        public async Task<string> CreationDatePopUp(int candidateId)
        {
            var candidate = await _candidateRepository.GetByCandidateId(candidateId);

            try
            {
                DateTime creationDate = DateTime.Now;
                if (DateTime.TryParseExact(candidate.CreationDate, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out creationDate)) ;
                else
                    creationDate = Convert.ToDateTime(candidate.CreationDate);                              

                var date = Convert.ToDateTime(creationDate).ToString("dd MMM yyyy h:mm tt.", new CultureInfo("es-CO"));

                return date;
            }
            catch (Exception)
            {
                return "Fecha no disponible";
            }         
        }

        public string GetCreationDatePopUpByDate(string creationDateString)
        {
            try
            {
                DateTime creationDate = DateTime.Now;

                if (DateTime.TryParseExact(creationDateString, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out creationDate)) ;
                else
                    creationDate = Convert.ToDateTime(creationDateString);

                string date = Convert.ToDateTime(creationDate).ToString("dd MMM yyyy h:mm tt.", new CultureInfo("es-CO"));

                return date;
            }
            catch (Exception)
            {
                return "Fecha no disponible";
            }
        }

        public async Task<string> CreationDatePopUpEnglish(int candidateId)
        {
            var candidate = await _candidateRepository.GetByCandidateId(candidateId);

            try
            {
                DateTime creationDate = DateTime.Now;
                if (DateTime.TryParseExact(candidate.CreationDate, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out creationDate)) ;
                else
                    creationDate = Convert.ToDateTime(candidate.CreationDate);

                var date = Convert.ToDateTime(creationDate).ToString("dd MMM yyyy h:mm tt.", new CultureInfo("en-US"));

                return date;
            }
            catch (Exception)
            {
                return "Fecha no disponible";
            }
        }

        public string GetCreationDatePopUpByDateEnglish(string creationDateString)
        {
            try
            {
                DateTime creationDate = DateTime.Now;

                if (DateTime.TryParseExact(creationDateString, "MM/dd/yyyy HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out creationDate)) ;
                else
                    creationDate = Convert.ToDateTime(creationDateString);

                string date = Convert.ToDateTime(creationDate).ToString("dd MMM yyyy h:mm tt.", new CultureInfo("en-US"));

                return date;
            }
            catch (Exception)
            {
                return "Date not available";
            }
        }
    }
}
