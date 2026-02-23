using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.RepositoriesCompany
{
    public interface ICandidate_SourceRepository : IRepositoryCompany<Candidate_Source>
    {
        Task<List<Candidate_Source>> GetSourcesByCandidateId(int candidateId);
        Task<List<Candidate_Source>> GetSourcesByCandidateAndCompanyUserId(int candidateId, int companyUserId);
    }
}
