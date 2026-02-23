using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.RepositoriesCompany
{
    public interface IAnswerRepository : IRepositoryCompany<Answer>
    {
        Task<List<Answer>> GetAllAnswersByQuestonIdIdAndPostulationId(int questionId, int postulationId);
    }
}