using CandidatesMS.Persistence.EntitiesCompany;
using System.Threading.Tasks;
using System;
using AutoMapper;

namespace CandidatesMS.ServicesCompany
{
    public interface ICompanyUserService
    {
        Task<bool> IsMaster(string token);
    }

    public class CompanyUserService
    (
        IValidateMethodsService validateMethodsService,

        IMapper mapper
    )
    :
    ICompanyUserService
    {
        private readonly IValidateMethodsService _validateMethodsService = validateMethodsService;

        private IMapper _mapper = mapper;

        public async Task<bool> IsMaster(string token)
        {
            try
            {
                /* Get MemberUser */

                MemberUser memberUser = await _validateMethodsService.GetMemberUserByToken(token);

                string email = string.Empty;

                if (memberUser != null)
                    email = memberUser.Email;

                /* Verify if the User is Master */

                if (!string.IsNullOrEmpty(email) && (email == "recruitment_owner@exsis.com.co" || email == "recruitmentmaster@exsis.com.co"))
                    return true;

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
