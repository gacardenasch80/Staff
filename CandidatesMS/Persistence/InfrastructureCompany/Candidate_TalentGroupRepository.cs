using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Persistence.Infraestructure;
using CandidatesMS.RepositoriesCompany;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

namespace CandidatesMS.Persistence.InfrastructureCompany
{
    public class Candidate_TalentGroupRepository
    (
        CompanyContext context
    )
    :
    RepositoryCompany<Candidate_TalentGroup>(context), ICandidate_TalentGroupRepository
    {
        public async Task<List<Candidate_TalentGroup>> GetByCandidateId(int candidateId)
        {
            List<Candidate_TalentGroup> candidateTalentGroups = 
                await _entities
                .Where
                (
                    candidate_talentGroup => candidate_talentGroup.CandidateId == candidateId
                )
                .ToListAsync();

            return candidateTalentGroups;
        }

        public async Task<List<Candidate_TalentGroup>> GetAllByCandidateAndCompanyUserId(int candidateId, int companyUserId)
        {
            List<Candidate_TalentGroup> candidateTalentGroups = 
                await _entities
                .Where
                (
                    candidate_talentGroup
                    =>
                    candidate_talentGroup.CandidateId == candidateId
                    &&
                    candidate_talentGroup.CompanyUserId == companyUserId
                )
                .Include(candidate_talentGroup => candidate_talentGroup.TalentGroup)
                .ToListAsync();

            return candidateTalentGroups;
        }

        public async Task<List<Candidate_TalentGroup>> GetAllByCandidateAndCompanyUserIdByCandidateIds
        (
            List<int> candidateIds,
            int companyUserId
        )
        {
            try
            {
                List<Candidate_TalentGroup> candidate_talentGroups =
                await _entities
                .Where
                (
                    candidate_talentGroup
                    =>
                    candidateIds != null
                    &&
                    candidateIds.Count > 0
                    &&
                    candidate_talentGroup != null
                    &&
                    candidate_talentGroup.TalentGroup != null
                    &&
                    candidate_talentGroup .TalentGroup.CompanyUserId == companyUserId
                    &&
                    candidateIds.Any(candidateId => candidateId == candidate_talentGroup.CandidateId)
                )
                .Include(candidate_talentGroup => candidate_talentGroup.TalentGroup)
                .AsNoTracking()
                .ToListAsync();

                return candidate_talentGroups;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
