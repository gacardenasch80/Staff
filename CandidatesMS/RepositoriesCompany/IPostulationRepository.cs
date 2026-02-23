using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.RepositoriesCompany
{
    public interface IPostulationRepository : IRepositoryCompany<Postulation>
    {
        Task<List<Postulation>> GetByPublishedAndClosedByCandidateIds(List<int> candidateIds, int companyUserId);
        Task<List<Postulation>> GetAllByCandidateAndCompanyUserIdOnlyAvailable(int candidateId, int companyUserId, int isMigrated, bool isFromCompanyAndLogin);
    }
}