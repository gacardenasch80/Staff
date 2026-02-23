using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Persistence.Infraestructure;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Infraestructure
{
    public class MaritalStatusRepository : Repository<MaritalStatus>, IMaritalStatusRepository
    {
        //private readonly CandidateContext _context;
        //private readonly IMapper _mapper;

        public MaritalStatusRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<MaritalStatus> GetByGuid(string Guid)
        {
            MaritalStatus maritalStatus = await _context.MaritalStatus.Where(x => x.MaritalStatusGuid == Guid).FirstOrDefaultAsync();
           
            return maritalStatus;
        }

        public async  Task<List<MaritalStatus>> GetAllmarital()
        {
            List<MaritalStatus> maritalStatus = await _context.MaritalStatus.ToListAsync();
            return maritalStatus;
        }

        public async Task<MaritalStatus> GetByIdWithoutNull(int maritalStatusId)
        {
            if (maritalStatusId == 0 || maritalStatusId == 6)
                return null;

            MaritalStatus maritalStatus = await _entities.Where(x => x.MaritalStatusId == maritalStatusId).FirstOrDefaultAsync();

            return maritalStatus;
        }



        public async Task<List<MaritalStatus>> GetAllMaritalStatusesExceptZero()
        {
            List<MaritalStatus> maritalStatus = await _entities.Where(x => x.MaritalStatusId != 6)
                .OrderByDescending(x => x.MaritalStatusId).ToListAsync();

            return maritalStatus;
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
