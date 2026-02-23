using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ICandidateLanguageOtherRepository : IRepository<Candidate_LanguageOther>
    {
        Task<Candidate_LanguageOther> GetByGuid(string guid);
        Task<List<Candidate_LanguageOther>> GetByCandidateEmail(string candidateEmail);
    }
}
