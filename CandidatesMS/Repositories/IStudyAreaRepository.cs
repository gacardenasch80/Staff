using CandidatesMS.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface IStudyAreaRepository : IRepository<StudyArea>
    {
        Task<StudyArea> GetByStudyAreaId(int studyId);
    }
}
