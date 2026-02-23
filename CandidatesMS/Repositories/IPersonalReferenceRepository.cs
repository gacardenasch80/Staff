using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface IPersonalReferenceRepository : IRepository<PersonalReference>
    {
        Task<List<PersonalReference>> GetToOverview(int candidateId, int companyUserId);
        Task<PersonalReference> GetpersonalreferenceById(int personalReferenceId);
        Task<List<PersonalReference>> GetByCandidateId(int candidateId);
        Task<List<PersonalReference>> GetByCandidateAndCompanyUserId(int candidateId, int companyUserId);

    }
}
