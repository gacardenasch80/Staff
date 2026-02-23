using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CandidatesMS.RepositoriesCompany
{
    public interface IMemberUserRepository : IRepositoryCompany<MemberUser>
    {
        Task<MemberUser> GetByEmail(string email);
        Task<List<MemberUser>> GetAllMemberUsersByCompany(int companyUserId);
    }
}