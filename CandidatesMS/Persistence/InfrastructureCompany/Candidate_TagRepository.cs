using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Persistence.Infraestructure;
using CandidatesMS.Persistence.DBContext;
using CandidatesMS.RepositoriesCompany;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CandidatesMS.Persistence.InfrastructureCompany
{
    public class Candidate_TagRepository
    (
        CompanyContext context
    )
    :
    RepositoryCompany<Candidate_Tag>(context), ICandidate_TagRepository
    {
        public async Task<List<Candidate_Tag>> GetTagsByCandidateId(int candidateId)
        {
            List<Candidate_Tag> candidateTags = 
                await _entities
                .Where
                (
                    candidate_tag
                    =>
                    candidate_tag.CandidateId == candidateId
                )
                .ToListAsync();

            return candidateTags;
        }

        public async Task<List<Candidate_Tag>> GetTagsByCandidateAndCompanyUserId(int candidateId, int companyUserId)
        {
            List<Candidate_Tag> candidateTags = 
                await _entities
                .Where
                (
                    candidate_tag
                    =>
                    candidate_tag.CandidateId == candidateId
                    &&
                    candidate_tag.CompanyUserId == companyUserId
                )
                .ToListAsync();

            return candidateTags;
        }
    }
}
