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
    public class StudyTypeRepository : Repository<StudyType>, IStudyTypeRepository
    {
        public StudyTypeRepository(CandidateContext context) : base(context)
        { }

        public async Task<StudyType> GetByStudyTypeId(int studyId)
        {
            StudyType studyType = await _entities.Where(x => x.StudyTypeId == studyId).FirstOrDefaultAsync();
            return studyType;
        }
    }
}
