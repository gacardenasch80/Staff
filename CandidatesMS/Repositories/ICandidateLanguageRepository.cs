using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ICandidateLanguageRepository : IRepository<Candidate_Language>
    {
        Task<List<Candidate_Language>> GetAllWithLanguageAndLevel();
        Task<Candidate_Language> GetByGuid(string guid);
        Task<List<Candidate_Language>> GetByCandidateEmail(string candidateEmail);
        Task<List<Candidate_Language>> GetByCandidateId(int candidateId);
        Task<List<Candidate_Language>> GetByCandidateIdAdminView(int candidateId);
        Task<List<Candidate_Language>> GetToOverview(int candidateId, int companyUserId);
    }
}
