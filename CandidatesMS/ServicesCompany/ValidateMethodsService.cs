using System;
using System.IdentityModel.Tokens.Jwt;
using System.Threading.Tasks;
using CandidatesMS.Persistence.EntitiesCompany;
using CandidatesMS.RepositoriesCompany;

namespace CandidatesMS.ServicesCompany
{
    public interface IValidateMethodsService
    {
        public Task<MemberUser> GetMemberUserByToken(string JWTString);
        public string EncodeJWT(string JWTString);
    }

    public class ValidateMethodsService
    (
        IMemberUserRepository memberUserRepository
    )
    : IValidateMethodsService
    {
        private readonly IMemberUserRepository _memberUserRepository = memberUserRepository;

        public async Task<MemberUser> GetMemberUserByToken(string JWTString)
        {
            try
            {
                string email = EncodeJWT(JWTString);

                MemberUser memberUser = await _memberUserRepository.GetByEmail(email);

                return memberUser;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public string EncodeJWT(string JWTString)
        {
            JWTString = JWTString.Split(" ")[1];

            JwtSecurityToken jwtToken = new(JWTString);
            JwtPayload payLoad = jwtToken.Payload;

            if (payLoad.TryGetValue("username", out object username))
                return username.ToString();

            if (payLoad.TryGetValue("cognito:username", out username))
                return username.ToString();

            return string.Empty;
        }
    }
}