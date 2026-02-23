using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace CandidatesMS.RepositoriesCompany
{
    public interface ICandidate_TagRepository : IRepositoryCompany<Candidate_Tag>
    {
        Task<List<Candidate_Tag>> GetTagsByCandidateId(int candidateId);
        Task<List<Candidate_Tag>> GetTagsByCandidateAndCompanyUserId(int candidateId, int companyUserId);
    }
}
