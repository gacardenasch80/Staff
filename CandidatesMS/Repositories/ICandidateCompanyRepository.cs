using CandidatesMS.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ICandidateCompanyRepository : IRepository<CandidateCompany>
    {
        Task<List<CandidateCompany>> GetByCandidateId(int candidateId);
        Task<CandidateCompany> GetByCandidateAndCompanyId(int candidateId, int companyUserId);
        Task<bool> AddCandidateCompany(CandidateCompany candidateCompany);
    }
}
