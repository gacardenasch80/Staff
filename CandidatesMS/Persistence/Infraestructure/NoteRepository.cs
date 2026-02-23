using AutoMapper;
using CandidatesMS.Infraestructure;
using CandidatesMS.Models;
using CandidatesMS.Models.RemoteModels.Out;
using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.Infraestructure.Services;
using CandidatesMS.Repositories;
using CandidatesMS.Repositories.RemoteRepositories;
using CandidatesMS.KeyVault.SecretsModels;
using CandidatesMS.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class NoteRepository : Repository<Note>, INoteRepository
    {
        private ICompanyRemoteRepository _companyRemoteRepository;
        private IMapper _mapper;
        private IUploadTimeService _uploadTimeService;
        private IBasicInformationService _basicInformationService;
        private readonly CognitoConfiguration _settings;
        private readonly ServiceConfigurationDTO _s3Settings;
        public NoteRepository(CandidateContext context, ICompanyRemoteRepository companyRemoteRepository,
                              IMapper mapper, IUploadTimeService uploadTimeService,
                              IBasicInformationService basicInformationService,
                              IOptions<CognitoConfiguration> settings, IOptions<ServiceConfigurationDTO> s3settings) : base(context)
        {
            _companyRemoteRepository = companyRemoteRepository;
            _mapper = mapper;
            _uploadTimeService = uploadTimeService;
            _basicInformationService = basicInformationService;
            _settings = settings.Value;
            _s3Settings = s3settings.Value;
        }

        public async Task<Note> AddByNote(Note note)
        {
            await _entities.AddAsync(note);
            int states = await _context.SaveChangesAsync();

            if (states != 0)
                return note;

            return null;
        }

        public async Task<List<Note>> GetByCandidateId(int candidateId)
        {
            List<Note> notes = await _entities.Where(x => x.CandidateId == candidateId).ToListAsync();

            return notes;
        }

        public async Task<List<Note>> GetByCandidateAndCompanyUserId(int candidateId, int companyUserId)
        {
            List<Note> notes = await _entities.Where(x => x.CandidateId == candidateId && x.CompanyUserId == companyUserId).ToListAsync();

            return notes;
        }

        public async Task<Note> GetByNoteId(int noteId)
        {
            Note note = await _entities.Where(x => x.NoteId == noteId).FirstOrDefaultAsync();

            return note;
        }

        public new async Task<Note> Add(Note note)
        {
            await _entities.AddAsync(note);
            int states = await _context.SaveChangesAsync();

            if (states != 0)
                return note;

            return null;
        }

        public bool NoteExistById(int noteId)
        {
            var response = _context.Note
                .Where(x => x.NoteId == noteId).AsNoTracking().ToList();
            if (response.Count == 0)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Note>> GetAllNoteOwners(int candidateId, int companyUserId)
        {
            return await _entities.Where(x => x.NoteOwnerId == 0 && x.CandidateId == candidateId && x.CompanyUserId == companyUserId)
                                        .OrderBy(x => x.DatePinUp)
                                        .ThenBy(x => x.CreationDate).ToListAsync();
        }

        public async Task<List<Note>> GetAllNoteAnswers(int candidateId, int companyUserId)
        {
            return await _entities.Where(x => x.NoteOwnerId != 0 && x.CandidateId == candidateId 
                                                && x.CompanyUserId == companyUserId).ToListAsync();
        }
        public async Task<List<Note>> GetAllNoteAnswersByNote(int noteId)
        {
            return await _entities.Where(X => X.NoteOwnerId == noteId).ToListAsync();
        }

        public List<Note> GetNotesByFilterDate(DateTime dateFilter, int companyUserId)
        {
            string[] validformats = new[] { "MM/dd/yyyy", "yyyy/MM/dd", "MM/dd/yyyy HH:mm:ss", "yyyy-MM-dd HH:mm:ss, fff",
                                            "MM/dd/yyyy hh:mm tt", "M/dd/yyyy h:mm:ss tt", "MM/d/yyyy h:mm:ss tt", "M/d/yyyy h:mm:ss tt"};

            List<Note> notesList = _entities.ToList().
                Where(x => DateTime.ParseExact
                (x.CreationDate, validformats, CultureInfo.InvariantCulture) > dateFilter
                && x.CompanyUserId == companyUserId).ToList();

            return notesList;
        }

        public async Task<int> NumberNotesByCandidateId(int candidateId)
        {
            return await _entities.Where(x => x.CandidateId == candidateId && x.NoteOwnerId == 0).CountAsync();
        }

        public async Task<int> NumberNotesByCandidateAndCompanyId(int candidateId, int companyUserId)
        {
            return await _entities.Where(x => x.CandidateId == candidateId && x.CompanyUserId == companyUserId && x.NoteOwnerId == 0).CountAsync();
        }

        public async Task<NoteCandidateSectionTotalDTO> GetCandidateSection(int page, int pageSize, int companyUserId, string token)
        {
            List<Note> notes = await GetPageNoteSectionCandidate(page, pageSize, companyUserId);
            if (notes != null && notes.Count > 0)
            {
                List<NoteSectionDTO> notesSectionDTO = new List<NoteSectionDTO>();
                var postulations = await _companyRemoteRepository.GetAllPostulationsWithName(token);
                var talentGroups = await _companyRemoteRepository.GetAllCandidateTalentWithName(token);

                List<NoteDTO> notesDTO = _mapper.Map<List<Note>, List<NoteDTO>>(notes);
                foreach (NoteDTO note in notesDTO)
                {
                    string photo = "";
                    string init = "";
                    string name = "";
                    List<string> jobNames = new List<string>();
                    List<string> talentNames = new List<string>();
                    int jobCount = 0;
                    int talentCount = 0;
                    if (postulations != null && postulations.Count > 0)
                    {
                        var jobs = postulations.Where(x => x.candidateId == note.CandidateId).ToList();
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

                    if (talentGroups != null && talentGroups.Count > 0)
                    {
                        var talents = talentGroups.Where(x => x.candidateId == note.CandidateId).ToList();
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

                    var CreationDateNote = await CreationDate(note.NoteId);
                    var CreationDateNotePopUp = await CreationDatePopUp(note.NoteId);
                    var CreationDateCandidate = await _basicInformationService.CreationDate(note.CandidateId);
                    var CreationDateCandidatePopUp = await _basicInformationService.CreationDatePopUp(note.CandidateId);

                    var CreationDateNoteEnglish = await CreationDateEnglish(note.NoteId);
                    var CreationDateNoteEnglishPopUp = await CreationDatePopUpEnglish(note.NoteId);
                    var CreationDateCandidateEnglish = await _basicInformationService.CreationDateEnglish(note.CandidateId);
                    var CreationDateCandidateEnglishPopUp = await _basicInformationService.CreationDatePopUpEnglish(note.CandidateId);

                    if (note.candidate.BasicInformation != null)
                    {
                        if (!String.IsNullOrEmpty(note.candidate.BasicInformation.Photo) && note.candidate.BasicInformation.Photo != null)
                            photo = note.candidate.BasicInformation.Photo;
                        else
                            init = _basicInformationService.Initials(note.candidate.BasicInformation.Name, note.candidate.BasicInformation.Surname);

                        name = _basicInformationService.Name(note.candidate.BasicInformation.Name, note.candidate.BasicInformation.Surname);
                    }
                    if (note.candidate.BasicInformation == null && !string.IsNullOrEmpty(note.candidate.Email) && note.candidate.Email != null)
                    {
                        name = note.candidate.Email;
                        var sub = name.Substring(0, 2);
                        init = sub.ToUpper();
                    }
                    CandidateSectionDTO candidateSectionDTO = new CandidateSectionDTO()
                    {
                        CandidateId = note.candidate.CandidateId,
                        Photo = photo,
                        Initials = init,
                        Name = name,
                        CreationDate = CreationDateCandidate,
                        CreationDateEnglish = CreationDateCandidateEnglish,
                        CreationDatePopUp = CreationDateCandidatePopUp,
                        CreationDatePopUpEnglish = CreationDateCandidateEnglishPopUp,
                        Jobs = jobNames,
                        TotalJobs = jobCount,
                        TalentGroups = talentNames,
                        TotalTalentGroups = talentCount,
                        IsDeleteProccess = note.candidate.IsDeleteProccess
                    };
                    NoteSectionDTO noteSectionDTO = new NoteSectionDTO()
                    {
                        NoteDescription = note.NoteDescription,
                        CreationDate = CreationDateNote,
                        CreationDateEnglish = CreationDateNoteEnglish,
                        CreationDatePopUp = CreationDateNotePopUp,
                        CreationDatePopUpEnglish = CreationDateNoteEnglishPopUp,
                        Name = _basicInformationService.Name(note.NameMemberUser, note.SurnameMemberUser),
                        CandidateId = note.candidate.CandidateId,
                        CandidateSection = candidateSectionDTO
                    };
                    if (noteSectionDTO != null)
                        notesSectionDTO.Add(noteSectionDTO);

                }
                if(notesSectionDTO != null && notesSectionDTO.Count > 0)
                {
                    int totalNotes = await countAllNotesPrincipal(companyUserId);

                    for (int i = 0; i < notesSectionDTO.Count; i++)
                    {
                        if (i == 0)
                            notesSectionDTO[i].Previous = 0;
                        else
                            notesSectionDTO[i].Previous = notesSectionDTO[i - 1].CandidateId;

                        if (i == notesSectionDTO.Count - 1)
                            notesSectionDTO[i].Next = 0;
                        else
                            notesSectionDTO[i].Next = notesSectionDTO[i + 1].CandidateId;
                    }

                    NoteCandidateSectionTotalDTO noteCandidateSectionTotalDTO = new NoteCandidateSectionTotalDTO()
                    {
                        TotalNotes = totalNotes,
                        CandidateSectionList = notesSectionDTO
                    };
                    return noteCandidateSectionTotalDTO;
                }
                else
                    return null;

            }
            else
            {
                return null;
            }
        }

        public async Task<List<Note>> GetPageNoteSectionCandidate(int page, int pageSize, int companyUserId)
        {
            List<Note> noteList = await _entities.Where(x => x.CompanyUserId == companyUserId && x.NoteOwnerId == 0).
                Include(x => x.Candidate).ThenInclude(x => x.BasicInformation)
                .OrderByDescending(x => x.NoteId)
                .AsNoTracking().ToListAsync();

            List<Note> pageSources = noteList.Skip((page) * pageSize).Take(pageSize).ToList();

            return pageSources;
        }

        public async Task<string> CreationDate(int noteId)
        {
            var note = await GetByNoteId(noteId);
            var date = _uploadTimeService.GetCreationDate(note.CreationDate.ToString());
            if (!String.IsNullOrEmpty(date) && date != null)
                return date;
            else
                return "";
        }

        public async Task<string> CreationDateEnglish(int noteId)
        {
            var note = await GetByNoteId(noteId);
            var date = _uploadTimeService.GetCreationDateEnglish(note.CreationDate.ToString());
            if (!String.IsNullOrEmpty(date) && date != null)
                return date;
            else
                return "";
        }

        public async Task<string> CreationDatePopUp(int noteId)
        {
            var note = await GetByNoteId(noteId);

            try
            {
                DateTime creationDate = DateTime.Now;
                if (DateTime.TryParseExact(note.CreationDate, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out creationDate)) ;
                else
                    creationDate = Convert.ToDateTime(note.CreationDate);

                var date = Convert.ToDateTime(creationDate).ToString("dd MMM yyyy h:mm tt.", new CultureInfo("es-CO"));

                return date;
            }
            catch (Exception)
            {
                return "Fecha no disponible";
            }
        }

        public async Task<string> CreationDatePopUpEnglish(int noteId)
        {
            var note = await GetByNoteId(noteId);

            try
            {
                DateTime creationDate = DateTime.Now;
                if (DateTime.TryParseExact(note.CreationDate, "MM/dd/yyyy HH:mm:ss", System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out creationDate)) ;
                else
                    creationDate = Convert.ToDateTime(note.CreationDate);

                var date = Convert.ToDateTime(creationDate).ToString("dd MMM yyyy h:mm tt.", new CultureInfo("en-US"));

                return date;
            }
            catch (Exception)
            {
                return "Data unavailable";
            }
        }

        public async Task<int> countAllNotesPrincipal(int companyUserId)
        {
            List<Note> noteList = new List<Note>();

            //int exsisCompanyUserId = 0;

            //if (_s3Settings.AWSS3.BucketName == "recruitment-bucket-prod")
            //    exsisCompanyUserId = 3;
            //else
            //    exsisCompanyUserId = 4;

            //if (companyUserId == exsisCompanyUserId)
            //    noteList = await _entities.Where(x => x.NoteOwnerId == 0 && (x.idm x.CompanyUserId == x.CompanyUserId)).AsNoTracking().ToListAsync();
            //else
                noteList = await _entities.Where(x => x.NoteOwnerId == 0 && x.CompanyUserId == companyUserId).AsNoTracking().ToListAsync();

            return noteList.Count;
        }

        public async Task<NoteGroupDTO> GetNoteWithCandidateAndBasicInformation(List<int> candidatesIds, int page, int pageSize)
        {
            List<Note> notesCandidates = new List<Note>();
            foreach (int candidate in candidatesIds)
            {
                List<Note> note = await _entities.Where(x => x.CandidateId == candidate && x.NoteOwnerId == 0)
                .Include(x => x.Candidate).ThenInclude(x => x.BasicInformation).AsNoTracking().ToListAsync();
                notesCandidates.AddRange(note);
            }
            notesCandidates = notesCandidates.OrderByDescending(x => x.NoteId).ToList();
            List<Note> pageSources = notesCandidates.Skip((page) * pageSize).Take(pageSize).ToList();
            NoteGroupDTO notesReturn = new NoteGroupDTO()
            {
                notesCandidates = pageSources,
                TotalNotes = notesCandidates.Count
            };

            return notesReturn;
        }

        public async Task<NoteCandidateSectionTotalDTO> GetCandidateSectionSearch(SearchByIdAndTextWithPaginationDTO search, int companyUserId, string token)
        {
            string find = search.Text.ToLower().TrimStart().TrimEnd().
                Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ü", "u");
            

            List<Note> notesSearch = await _entities.Where(x => x.CompanyUserId == companyUserId).Include(x => x.Candidate).ThenInclude(x => x.BasicInformation)
                .Where(x => (x.Candidate.BasicInformation.Name.ToLower().Contains(find) || x.Candidate.BasicInformation.Surname.ToLower().Contains(find)
                || (x.Candidate.BasicInformation.Name.ToLower().Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ü", "u").TrimEnd() + " " + x.Candidate.BasicInformation.Surname.ToLower().Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ü", "u").TrimEnd()).Contains(find)
                || x.NoteDescription.ToLower()
                .Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ü", "u")
                .Contains(find)) && x.NoteOwnerId == 0)
                .OrderByDescending(x => x.NoteId)
                .ToListAsync();

            List<Note> pageSources = notesSearch.Skip((search.Page) * search.PageSize).Take(search.PageSize).ToList();

            if (pageSources != null && pageSources.Count > 0)
            {
                List<NoteSectionDTO> notesSectionDTO = new List<NoteSectionDTO>();
                var postulations = await _companyRemoteRepository.GetAllPostulationsWithName(token);
                var talentGroups = await _companyRemoteRepository.GetAllCandidateTalentWithName(token);

                List<NoteDTO> notesDTO = _mapper.Map<List<Note>, List<NoteDTO>>(pageSources);
                foreach (NoteDTO note in notesDTO)
                {
                    string photo = "";
                    string init = "";
                    string name = "";
                    List<string> jobNames = new List<string>();
                    List<string> talentNames = new List<string>();
                    int jobCount = 0;
                    int talentCount = 0;
                    if (postulations != null && postulations.Count > 0)
                    {
                        var jobs = postulations.Where(x => x.candidateId == note.CandidateId).ToList();
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

                    if (talentGroups != null && talentGroups.Count > 0)
                    {
                        var talents = talentGroups.Where(x => x.candidateId == note.CandidateId).ToList();
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

                    var CreationDateNote = await CreationDate(note.NoteId);
                    var CreationDateNotePopUp = await CreationDatePopUp(note.NoteId);
                    var CreationDateCandidate = await _basicInformationService.CreationDate(note.CandidateId);
                    var CreationDateCandidatePopUp = await _basicInformationService.CreationDatePopUp(note.CandidateId);

                    var CreationDateNoteEnglish = await CreationDateEnglish(note.NoteId);
                    var CreationDateNoteEnglishPopUp = await CreationDatePopUpEnglish(note.NoteId);
                    var CreationDateCandidateEnglish = await _basicInformationService.CreationDateEnglish(note.CandidateId);
                    var CreationDateCandidateEnglishPopUp = await _basicInformationService.CreationDatePopUpEnglish(note.CandidateId);

                    if (note.candidate.BasicInformation != null)
                    {
                        if (!String.IsNullOrEmpty(note.candidate.BasicInformation.Photo) && note.candidate.BasicInformation.Photo != null)
                            photo = note.candidate.BasicInformation.Photo;
                        else
                            init = _basicInformationService.Initials(note.candidate.BasicInformation.Name, note.candidate.BasicInformation.Surname);

                        name = _basicInformationService.Name(note.candidate.BasicInformation.Name, note.candidate.BasicInformation.Surname);
                    }
                    if (note.candidate.BasicInformation == null && !string.IsNullOrEmpty(note.candidate.Email) && note.candidate.Email != null)
                    {
                        name = note.candidate.Email;
                        var sub = name.Substring(0, 2);
                        init = sub.ToUpper();
                    }
                    CandidateSectionDTO candidateSectionDTO = new CandidateSectionDTO()
                    {
                        CandidateId = note.candidate.CandidateId,
                        Photo = photo,
                        Initials = init,
                        Name = name,
                        CreationDate = CreationDateCandidate,
                        CreationDateEnglish = CreationDateCandidateEnglish,
                        CreationDatePopUp = CreationDateCandidatePopUp,
                        CreationDatePopUpEnglish = CreationDateCandidateEnglishPopUp,
                        Jobs = jobNames,
                        TotalJobs = jobCount,
                        TalentGroups = talentNames,
                        TotalTalentGroups = talentCount,
                        IsDeleteProccess = note.candidate.IsDeleteProccess
                    };
                    NoteSectionDTO noteSectionDTO = new NoteSectionDTO()
                    {
                        NoteDescription = note.NoteDescription.ToLower().Replace(find, "<em>" + find + "</em>"),
                        CreationDate = CreationDateNote,
                        CreationDateEnglish = CreationDateNoteEnglish,
                        CreationDatePopUpEnglish = CreationDateNoteEnglishPopUp,
                        CreationDatePopUp = CreationDateNotePopUp,
                        Name = _basicInformationService.Name(note.NameMemberUser, note.SurnameMemberUser),
                        CandidateId = note.candidate.CandidateId,
                        CandidateSection = candidateSectionDTO
                    };
                    if (noteSectionDTO != null)
                        notesSectionDTO.Add(noteSectionDTO);

                }
                if (notesSectionDTO != null && notesSectionDTO.Count > 0)
                {
                    for (int i = 0; i < notesSectionDTO.Count; i++)
                    {
                        if (i == 0)
                            notesSectionDTO[i].Previous = 0;
                        else
                            notesSectionDTO[i].Previous = notesSectionDTO[i - 1].CandidateId;

                        if (i == notesSectionDTO.Count - 1)
                            notesSectionDTO[i].Next = 0;
                        else
                            notesSectionDTO[i].Next = notesSectionDTO[i + 1].CandidateId;
                    }

                    NoteCandidateSectionTotalDTO noteCandidateSectionTotalDTO = new NoteCandidateSectionTotalDTO()
                    {
                        TotalNotes = notesSearch.Count,
                        CandidateSectionList = notesSectionDTO
                    };
                    return noteCandidateSectionTotalDTO;
                }
                else
                    return null;

            }
            else
            {
                return null;
            }
        }

        public async Task<NoteGroupDTO> GetNoteWithCandidateAndBasicInformationSearch(List<int> candidatesIds, int page, int pageSize, string text)
        {
            string find = text.ToLower().TrimStart().TrimEnd()
                .Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ü", "u");
            List<Note> notesCandidates = new List<Note>();
            foreach (int candidate in candidatesIds)
            {
                List<Note> note = await _entities.Where(x => x.CandidateId == candidate && x.NoteOwnerId == 0
                && (x.Candidate.BasicInformation.Name.ToLower().Contains(find) || x.Candidate.BasicInformation.Surname.ToLower().Contains(find)
                || (x.Candidate.BasicInformation.Name.ToLower().Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ü", "u").TrimEnd() + " " + x.Candidate.BasicInformation.Surname.ToLower().Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ü", "u").TrimEnd()).Contains(find)
                || x.NoteDescription.ToLower()
                .Replace("á", "a").Replace("é", "e").Replace("í", "i").Replace("ó", "o").Replace("ú", "u").Replace("ü", "u")
                .Contains(find))
                )
                .Include(x => x.Candidate).ThenInclude(x => x.BasicInformation).AsNoTracking().ToListAsync();
                notesCandidates.AddRange(note);
            }
            notesCandidates = notesCandidates.OrderByDescending(x => x.NoteId).ToList();
            List<Note> pageSources = notesCandidates.Skip((page) * pageSize).Take(pageSize).ToList();
            NoteGroupDTO notesReturn = new NoteGroupDTO()
            {
                notesCandidates = pageSources,
                TotalNotes = notesCandidates.Count
            };

            return notesReturn;
        }
    }
}
