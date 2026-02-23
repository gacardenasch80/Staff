using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class StudyStateRepository : Repository<StudyState>, IStudyStateRepository
    {
        public StudyStateRepository(CandidateContext context) : base(context)
        {

        }

        public async Task<StudyState> GetByStudyStateId(int studyId)
        {
            StudyState studyState = await _entities.Where(x => x.StudyStateId == studyId).FirstOrDefaultAsync();
            return studyState;
        }
    }
}
