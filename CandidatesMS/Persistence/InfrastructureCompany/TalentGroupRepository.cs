using CandidatesMS.Persistence.DBContext;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Persistence.Infraestructure;
using CandidatesMS.RepositoriesCompany;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Persistence.InfrastructureCompany
{
    public class TalentGroupRepository
    (
        CompanyContext context
    )
    :
    RepositoryCompany<TalentGroup>(context), ITalentGroupRepository
    {
        public async Task<TalentGroup> GetByTalentGroupId(int talentGroupId)
        {
            TalentGroup talentGroup = 
                await _entities
                .Where
                (
                    talentGroup => talentGroup.TalentGroupId == talentGroupId
                )

                .AsNoTracking()

                .Include(talentGroup => talentGroup.TalentGroupPostingStatus)
                .Include(talentGroup => talentGroup.InternalCode)
                .Include(talentGroup => talentGroup.MemberUserTalentGroup)
                
                .AsSplitQuery()
                
                .FirstOrDefaultAsync();
            
            return talentGroup;
        }
    }
}
