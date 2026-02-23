using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class RemoteMailRepository : Repository<RemoteMail>, IRemoteMailRepository
    {
        public RemoteMailRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<int> GetAllAnswerFromMailOwnerId(string MailOwnerId)
        {
            List<RemoteMail> answer = await _entities.Where(x => x.MailOwnerId == MailOwnerId).ToListAsync();
            return answer.Count;
        }

        public async Task<List<RemoteMail>> GetAllMails()
        {
            List<RemoteMail> remoteMails = await _entities
                .Include(x => x.AttachedFilesRemoteMail)
                .Include(x => x.CC)
                .Include(x => x.CCO)
                .ToListAsync();
            
            return remoteMails;
        }
    }
}
