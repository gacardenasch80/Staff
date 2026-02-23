using CandidatesMS.ModelsCompany;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.RepositoriesCompany;
using System.Threading.Tasks;
using System;
using AutoMapper;
using System.Collections.Generic;

namespace CandidatesMS.ServicesCompany
{
    public interface IMemberUserService
    {
        Task<MemberUserDTO> GetMemberUserFromCandidate(string token);
        Task<List<MemberUserDTO>> GetAllMemberUsersFromCompany(int companyUserId);
    }

    public class MemberUserService
    (
        IMemberUserRepository memberUserRepository,

        IValidateMethodsService validateMethodsService,

        IMapper mapper
    )
    :
    IMemberUserService
    {
        private readonly IMemberUserRepository _memberUserRepository = memberUserRepository;

        private readonly IValidateMethodsService _validateMethodsService = validateMethodsService;

        private IMapper _mapper = mapper;

        public async Task<MemberUserDTO> GetMemberUserFromCandidate(string token)
        {
            try
            {
                /* Get MemberUser */

                MemberUser memberUser = await _validateMethodsService.GetMemberUserByToken(token);

                MemberUserDTO memberUserDTO = _mapper.Map<MemberUser, MemberUserDTO>(memberUser);

                /**/

                return memberUserDTO;
            }
            catch (Exception ex)
            {
                return new MemberUserDTO();
            }
        }

        public async Task<List<MemberUserDTO>> GetAllMemberUsersFromCompany(int companyUserId)
        {
            try
            {
                /* Get MemberUsers */

                List<MemberUser> memberUsers = await _memberUserRepository.GetAllMemberUsersByCompany(companyUserId);

                List<MemberUserDTO> memberUsersDTO = _mapper.Map<List<MemberUser>, List<MemberUserDTO>>(memberUsers);

                /**/

                return memberUsersDTO;
            }
            catch (Exception ex)
            {
                return new List<MemberUserDTO>();
            }
        }
    }
}
