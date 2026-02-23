using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Persistence.Infraestructure;
using CandidatesMS.RepositoriesCompany;
using iText.StyledXmlParser.Jsoup.Select;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.InfrastructureCompany
{
    public class EvaluationRepository
    (
        CompanyContext context
    )
    :
    RepositoryCompany<Evaluation>(context), IEvaluationRepository
    {
        public async Task<List<Evaluation>> GetEvaluationsByCandidateAndJobIdAfterEditionDate
        (
            int candidateId,
            int jobId,
            PercentCriteria percentCriteria
        )
        {
            List<Evaluation> evaluations = 
                await _entities
                .Where
                (
                    evaluation
                    =>
                    evaluation.CandidateId == candidateId
                    &&
                    evaluation.JobId == jobId
                    &&
                    evaluation.CreationDate >= percentCriteria.EditionDate
                )
                .Include(evaluation => evaluation.Evaluation_EvaluationCriteria)
                .OrderByDescending(evaluation => evaluation.CreationDate)
                .ToListAsync();

            return evaluations;
        }

        public async Task<List<Evaluation>> GetEvaluationsByCandidateAndTalentGroupIdAfterEditionDate
        (
            int candidateId,
            int talentGroupId,
            PercentCriteria percentCriteria
        )
        {
            List<Evaluation> evaluations =
                await _entities
                .Where
                (
                    evaluation => evaluation.CandidateId == candidateId
                    &&
                    evaluation.TalentGroupId == talentGroupId
                    &&
                    evaluation.CreationDate >= percentCriteria.EditionDate
                )
                .Include(evaluation => evaluation.Evaluation_EvaluationCriteria)
                .OrderByDescending(evaluation => evaluation.CreationDate)
                .ToListAsync();

            return evaluations;
        }

        public async Task<Evaluation> GetEvaluationByIdWithCriterias
        (
            int evaluationId
        )
        {
            Evaluation evaluation = 
                await _entities
                .Where
                (
                    evaluation => evaluation.EvaluationId == evaluationId
                    )
               .Include(evaluation => evaluation.Evaluation_EvaluationCriteria)
               .FirstOrDefaultAsync();

            return evaluation;
        }
    }
}
