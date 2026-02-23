using CandidatesMS.Persistence.Entities;
using System.Threading.Tasks;

namespace CandidatesMS.Repositories
{
    public interface ILifePreferenceRepository : IRepository<LifePreference>
    {
        //Task<List<LifePreferenceDTO>> GetAll();
        //Task<CandidateDTO> Add(CandidateDTO candidateDTO);
        //Task<LifePreferenceDTO> GetById(int lifePreferenceyId);
        Task<LifePreference> GetByGuid(string lifePreferenceyGuid);
        //Task<LifePreferenceDTO> Add(LifePreferenceDTO lifePreferenceDTO);
        //Task<LifePreferenceDTO> Edit(int id);
        //Task<LifePreferenceDTO> Delete(int id);
    }
}
