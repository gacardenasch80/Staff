using CandidatesMS.Persistence.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ICandidate_PostulationRepository : IRepository<Candidate_Postulation>
    {
        Task<List<Candidate_Postulation>> GetByPostulationId(int postulationId);
        Task<List<Candidate_Postulation>> GetByCandidateId(int candidateId);
        Task<bool> RemoveByPostulationId(int postulationId);
    }
}
