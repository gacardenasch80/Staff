using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;

namespace CandidatesMS.Persistence.Infraestructure.Services
{
    public class AttachedFileMailRepository : Repository<AttachedFileMail>, IAttachedFileMailRepository
    {
        public AttachedFileMailRepository(CandidateContext context) : base(context)
        {
        }
    }
}
