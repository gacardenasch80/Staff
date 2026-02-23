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
    public class MemberUserRepository
    (
        CompanyContext context
    )
    :
    RepositoryCompany<MemberUser>(context), IMemberUserRepository
    {
        public async Task<MemberUser> GetByEmail(string email)
        {
            try
            {
                MemberUser memberUser =
                await _entities
                .Where
                (
                    memberUser
                    =>
                    memberUser != null
                    &&
                    !string.IsNullOrEmpty(memberUser.Email)
                    &&
                    !string.IsNullOrEmpty(email)
                    &&
                    memberUser.Email.ToLower().Equals(email.ToLower())
                )
                .Include(memberUser => memberUser.Role)
                .Include(memberUser => memberUser.CompanyUser)
                .AsNoTracking()
                .FirstOrDefaultAsync();

                return memberUser;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<List<MemberUser>> GetAllMemberUsersByCompany(int companyUserId)
        {
            List<MemberUser> members =
                await _entities
                .Where
                (
                    memberUser
                    =>
                    memberUser.CompanyUserId == companyUserId
                )
                .Include(memberUser => memberUser.Role)
                .Include(memberUser => memberUser.Job_MemberUser).ThenInclude(job_memberUser => job_memberUser.Job)
                //.Include(memberUser => memberUser.memberUser_TGComercial)
               .AsNoTracking()
               .ToListAsync();

            return members;
        }
    }
}
