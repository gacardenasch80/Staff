using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.RepositoriesCompany
{
    public interface IQuestionRepository : IRepository<Question>
    {
        Task<List<Question>> GetAllQuestionsByJobIdWithAnswersByPostulationId(int jobId, int postulationId);
    }
}
