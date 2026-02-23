using CandidatesMS.Models.RemoteModels.In;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories.RemoteRepositories
{
    public interface IRecruiteeRemoteRepository
    {
        Task<List<RecruiteeCandidateInDTO>> GetCandidates();
        Task<List<RecruiteeCandidateInDTO>> GetExsistsCandidates();
        Task<List<RecruiteeCandidateInDTO>> GetExsistsCandidatesAndSecondBigMigration();
        
        Task<List<CandidateRecruiteeInDTO>> GetExsistsCandidatesSingle();
        Task<List<RecruiteeCandidateInDTO>> GetCandidatesWhitOutMail();
        Task<bool> GetCandidatesCV();
        Task<RecruiteeCandidateInDTO> GetCandidateById(int id);
        Task<List<NoteRecruitee>> MigrateNotes(List<CandidateRecruiteeInDTO> candidates);
        Task<List<RecruiteeCandidateInDTO>> GetNotExsistsCandidates();

        Task<bool> GetCandidatesFirstInfoRaw();
        Task<bool> GetCandidatesSecondInfoRaw();
        Task<bool> GetNotesRaw();
        Task<bool> GetCVsRaw();
        Task<bool> GetPhotosRaw();
    }
}
