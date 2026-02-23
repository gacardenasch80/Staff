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
    public class GenderRepository : Repository<Gender>, IGenderRepository
    {
        public GenderRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<Gender> GetByGuid(string Guid)
        {
            Gender gender = await _entities.Where(x => x.GenderGuid == Guid).FirstOrDefaultAsync();

            return gender;
        }

        public async Task<Gender> GetByIdWithoutNull(int genderId)
        {
            if (genderId == 0 || genderId == 4)
                return null;

            Gender gender = await _entities.Where(x => x.GenderId == genderId).FirstOrDefaultAsync();

            return gender;
        }

        public async Task<List<Gender>> GetAllGenders()
        {
            List<Gender> genders = await _entities.ToListAsync();

            return genders;
        }

        public async Task<List<Gender>> GetAllGendersExceptZero()
        {
            List<Gender> genders = await _entities.Where(x => x.GenderId != 4)
                .OrderByDescending(x => x.GenderId).ToListAsync();

            return genders;
        }

        //public async Task<Gender> GetById(int id) => await _context.Gender.AsNoTracking().SingleOrDefaultAsync(g => g.GenderId == id);
    }
}
