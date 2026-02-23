using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace CandidatesMS.Persistence.Infraestructure
{
    public class Candidate_TalentGroupRepository : Repository<Candidate_TalentGroupAux>, ICandidate_TalentGroupRepository
    {
        public Candidate_TalentGroupRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<List<Candidate_TalentGroupAux>> GetByTalentGroupId(int candidate_talentGroupId)
        {
            List<Candidate_TalentGroupAux> candidate_talentGroups = await _entities.Where(x => x.Candidate_TalentGroupAuxId == candidate_talentGroupId).ToListAsync();

            return candidate_talentGroups;
        }

        public async Task<List<Candidate_TalentGroupAux>> GetByCandidateId(int candidateId)
        {
            List<Candidate_TalentGroupAux> candidate_talentGroups = await _entities.Where(x => x.CandidateId == candidateId).ToListAsync();

            return candidate_talentGroups;
        }

        public async Task<bool> RemoveByTalentGroupId(int candidate_talentGroupId)
        {
            Candidate_TalentGroupAux candidate_talentGroup = await _entities.Where(x => x.Candidate_TalentGroupAuxId == candidate_talentGroupId).FirstOrDefaultAsync();

            if(candidate_talentGroup != null)
            {
                _entities.Remove(candidate_talentGroup);

                int states = await _context.SaveChangesAsync();

                if (states != 0)
                    return true;
            }

            return false;
        }
    }
}
