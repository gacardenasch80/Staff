using AutoMapper;
using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class SoftSkillRepository : Repository<SoftSkill>, ISoftSkillRepository
    {
        public SoftSkillRepository(CandidateContext context) : base(context)
        {

        }

        public async Task<List<SoftSkill>> GetAllWithOtherEnd()
        {
            List<SoftSkill> softSkills = await _entities.Where(x => x.SoftSkillId != 30)
                .OrderBy(x => x.SoftSkillName).ToListAsync();

            SoftSkill lastSoftSkill = await _entities.Where(x => x.SoftSkillId == 30).FirstOrDefaultAsync();

            if(lastSoftSkill != null)
            softSkills.Add(lastSoftSkill);

            return softSkills;
        }

        public CandidateContext context
        {
            get { return _context as CandidateContext; }
        }
    }
}
