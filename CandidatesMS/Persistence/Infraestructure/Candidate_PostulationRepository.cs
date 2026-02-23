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
    public class Candidate_PostulationRepository : Repository<Candidate_Postulation>, ICandidate_PostulationRepository
    {
        public Candidate_PostulationRepository(CandidateContext context) : base(context)
        {
        }

        public async Task<List<Candidate_Postulation>> GetByPostulationId(int postulationId)
        {
            List <Candidate_Postulation> postulations = await _entities.Where(x => x.PostulationId == postulationId).ToListAsync();

            return postulations;
        }

        public async Task<List<Candidate_Postulation>> GetByCandidateId(int candidateId)
        {
            List<Candidate_Postulation> postulations = await _entities.Where(x => x.CandidateId == candidateId).ToListAsync();

            return postulations;
        }

        public async Task<bool> RemoveByPostulationId(int postulationId)
        {
            Candidate_Postulation candidatePostulation = await _entities.Where(x => x.PostulationId == postulationId).FirstOrDefaultAsync();

            if (candidatePostulation != null)
            {
                _entities.Remove(candidatePostulation);

                int states = await _context.SaveChangesAsync();

                if (states != 0)
                    return true;
            }

            return false;
        }
    }
}
