using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.RepositoriesCompany
{
    public interface IEventRepository : IRepositoryCompany<Event>
    {
        Task<List<Event>> GetEventsByCandidateAndCompanyId(int candidateId, int companyUserId, DateTime date);
    }
}
