using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using iText.StyledXmlParser.Jsoup.Nodes;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.RepositoriesCompany
{
    public interface ICandidate_TalentGroupRepository : IRepositoryCompany<Candidate_TalentGroup>
    {

        Task<List<Candidate_TalentGroup>> GetByCandidateId(int candidateId);
        Task<List<Candidate_TalentGroup>> GetAllByCandidateAndCompanyUserId(int candidateId, int companyUserId);
        Task<List<Candidate_TalentGroup>> GetAllByCandidateAndCompanyUserIdByCandidateIds(List<int> candidateIds, int companyUserId);
    }
}