using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Persistence.Infraestructure;
using CandidatesMS.RepositoriesCompany;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.InfrastructureCompany
{
    public class QuestionRepository
    (
        CompanyContext context
    )
    :
    RepositoryCompany<Question>(context), IQuestionRepository
    {
        public async Task<List<Question>> GetAllQuestionsByJobIdWithAnswersByPostulationId(int jobId, int postulationId)
        {
            List<Question> questions =
                await _entities
                .Where
                (
                    question => question.JobId == jobId
                )
               .Include(question => question.Answers)
               .Where
               (
                    question => question.Answers.Any
                    (
                        answer => answer.PostulationId == postulationId
                    )
                )
               .ToListAsync();

            return questions;
        }
    }
}
