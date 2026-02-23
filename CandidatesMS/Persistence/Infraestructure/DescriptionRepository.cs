using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.Entities;
using CandidatesMS.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.Infraestructure
{
    public class DescriptionRepository : Repository<Description>, IDescriptionRepository
    {
        public DescriptionRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<Description> GetByGuid(string guid)
        {
            Description description = await _entities.Where(x => x.DescriptionGuid == guid).FirstOrDefaultAsync();
            //DescriptionDTO descriptionDTO = _mapper.Map<Description, DescriptionDTO>(description);

            return description;
        }

        public async Task<bool> DescriptionExists(int candidateId)
        {
            Description description = await _entities.Where(x => x.CandidateId == candidateId).FirstOrDefaultAsync();

            if (description != null)
                return true;

            return false;
        }

        public async Task<bool> EditDescription(Description description)
        {
            Description editedDescription = await _entities.Where(x => x.CandidateId == description.CandidateId).FirstOrDefaultAsync();
            editedDescription.Text = description.Text;
            editedDescription.EditionDate = description.EditionDate;
            _context.SaveChanges();

            if (description != null)
                return true;

            return false;
        }

        public async Task<Description> GetByCandidateId(int candidateId)
        {
            Description description = await _entities.Where(x => x.CandidateId == candidateId).FirstOrDefaultAsync();

            return description;
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
