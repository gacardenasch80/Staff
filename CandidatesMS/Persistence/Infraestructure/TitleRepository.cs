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
    public class TitleRepository : Repository<Title>, ITitleRepository
    {
        public TitleRepository(CandidateContext context) : base(context)
        {

        }

        public async Task<Title> GetByGuid(string Guid)
        {
            Title title = await _context.Title.Where(x => x.TitleGuid == Guid).FirstOrDefaultAsync();

            return title;
        }

        public async Task<Title> GetByTitleId(int studyId)
        {
            Title title = await _entities.Where(x => x.TitleId == studyId).FirstOrDefaultAsync();
            return title;
        }
    }
}
