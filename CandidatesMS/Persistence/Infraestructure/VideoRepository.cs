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
    public class VideoRepository : Repository<Video>, IVideoRepository
    {
        public VideoRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<Video> GetByCandidateId(int candidateId)
        {
            Video video = await _entities.Where(x => x.CandidateId == candidateId).FirstOrDefaultAsync();
            return video;
        }

        public async Task<Video> GetByGuid(string guid)
        {
            Video video = await _entities.Where(x => x.VideoGuid == guid).FirstOrDefaultAsync();
            //DescriptionDTO descriptionDTO = _mapper.Map<Description, DescriptionDTO>(description);

            return video;
        }

        public async Task<bool> VideoExists(int candidateId)
        {
            Video video = await _entities.Where(x => x.CandidateId == candidateId).FirstOrDefaultAsync();

            if (video != null)
                return true;

            return false;
        }

        /// <summary>
        /// Getting context
        /// </summary>
        public CandidateContext context
        {
            get { return _context as CandidateContext; }
        }
    }
}
