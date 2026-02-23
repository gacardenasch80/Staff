using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface IRemoteMailRepository : IRepository<RemoteMail>
    {
        Task<List<RemoteMail>> GetAllMails();
        Task<int> GetAllAnswerFromMailOwnerId(string MailOwnerId);
    }
}
