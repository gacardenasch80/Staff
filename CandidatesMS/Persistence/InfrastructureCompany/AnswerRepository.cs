using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Persistence.Infraestructure;
using CandidatesMS.RepositoriesCompany;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.InfrastructureCompany
{
    public class AnswerRepository
    (
        CompanyContext context
    )
    :
    RepositoryCompany<Answer>(context), IAnswerRepository
    {
        public async Task<List<Answer>> GetAllAnswersByQuestonIdIdAndPostulationId(int questionId, int postulationId)
        {
            List<Answer> answers =
                await _entities
                .Where
                (
                    answer => answer.QuestionId == questionId && answer.PostulationId == postulationId
                )
               .ToListAsync();

            return answers;
        }
    }
}
