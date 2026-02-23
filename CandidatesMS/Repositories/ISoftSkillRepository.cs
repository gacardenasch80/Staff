using CandidatesMS.Models;
using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ISoftSkillRepository :IRepository<SoftSkill>
    {
        Task<List<SoftSkill>> GetAllWithOtherEnd();
    }
}
