using CandidatesMS.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface IMailRepository : IRepository<Mail>
    {
        new Task<Mail> Add(Mail mail);
        Task<List<Mail>> GetAllMailByCandidateId(int candidateId, int companyUserId);
        Task<List<Mail>> GetAllMailByCandidateAndCompanyId(int candidateId, int companyUserId);
    }
}
