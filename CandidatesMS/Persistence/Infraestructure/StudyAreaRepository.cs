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
    public class StudyAreaRepository : Repository<StudyArea>, IStudyAreaRepository
    {
        public StudyAreaRepository(CandidateContext context) : base(context)
        {

        }

        public async Task<StudyArea> GetByStudyAreaId(int studyId)
        {
            StudyArea studyArea = await _entities.Where(x => x.StudyAreaId == studyId).FirstOrDefaultAsync();
            return studyArea;
        }
    }
}
