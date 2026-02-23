using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using System.Threading.Tasks;

namespace CandidatesMS.RepositoriesCompany
{
    public interface ITalentGroupRepository : IRepositoryCompany<TalentGroup>
    {
        Task<TalentGroup> GetByTalentGroupId(int talentGroupId);
    }
}