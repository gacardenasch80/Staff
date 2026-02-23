using CandidatesMS.Models;
using CandidatesMS.Models.RemoteModels.Out;
using CandidatesMS.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface INoteRepository : IRepository<Note>
    {
        Task<List<Note>> GetByCandidateId(int candidateId);
        Task<List<Note>> GetByCandidateAndCompanyUserId(int candidateId, int companyUserId);
        Task<Note> GetByNoteId(int noteId);
        new Task<Note> Add(Note note);
        Task<List<Note>> GetAllNoteOwners(int candidateId, int companyUserId);
        Task<List<Note>> GetAllNoteAnswers(int candidateId, int companyUserId);
        Task<List<Note>> GetAllNoteAnswersByNote(int noteId);
        List<Note> GetNotesByFilterDate(DateTime dateFilter, int companyUserId);
        bool NoteExistById(int noteId);
        Task<int> NumberNotesByCandidateId(int candidateId);
        Task<int> NumberNotesByCandidateAndCompanyId(int candidateId, int companyUserId);
        public Task<NoteCandidateSectionTotalDTO> GetCandidateSection(int page, int pageSize, int companyUserId, string token);
        Task<List<Note>> GetPageNoteSectionCandidate(int page, int pageSize, int companyUserId);
        public Task<string> CreationDate(int noteId);
        public Task<string> CreationDateEnglish(int noteId);
        public Task<string> CreationDatePopUp(int noteId);
        public Task<string> CreationDatePopUpEnglish(int noteId);
        public Task<int> countAllNotesPrincipal(int companyUserId);
        Task<NoteGroupDTO> GetNoteWithCandidateAndBasicInformation(List<int> candidatesIds, int page, int pageSize);
        Task<NoteGroupDTO> GetNoteWithCandidateAndBasicInformationSearch(List<int> candidatesIds, int page, int pageSize, string text);
        public Task<NoteCandidateSectionTotalDTO> GetCandidateSectionSearch(SearchByIdAndTextWithPaginationDTO search, int companyUserId, string token);
    }
}
