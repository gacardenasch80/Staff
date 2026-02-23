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
    public class Candidate_SourceRepository
    (
        CompanyContext context
    )
    :
    RepositoryCompany<Candidate_Source>(context), ICandidate_SourceRepository
    {
        public async Task<List<Candidate_Source>> GetSourcesByCandidateId(int candidateId)
        {
            List<Candidate_Source> candidateSources = 
                await _entities
                .Where
                (
                    candidate_source
                    =>
                    candidate_source.CandidateId == candidateId
                )
                .ToListAsync();

            return candidateSources;
        }

        public async Task<List<Candidate_Source>> GetSourcesByCandidateAndCompanyUserId(int candidateId, int companyUserId)
        {
            List<Candidate_Source> candidateSources =
                await _entities
                .Where
                (
                    candidate_source
                    =>
                    candidate_source.CandidateId == candidateId
                    &&
                    candidate_source.CompanyUserId == companyUserId
                )
                .ToListAsync();

            return candidateSources;
        }
    }
}
