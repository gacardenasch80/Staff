using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace CandidatesMS.Helpers
{
    public interface IAuthorizationHelper
    {
        string GetToken(HttpRequest request);
        string GetEmailFromToken(HttpRequest request);
    }
    public class AuthorizationHelper : IAuthorizationHelper
    {
        public AuthorizationHelper()
        {
        }

        public string GetEmailFromToken(HttpRequest request)
        {
            var token = GetToken(request);

            var handler = new JwtSecurityTokenHandler();
            var decodedValue = handler.ReadJwtToken(token);

            var email = "";
            
            email = decodedValue.Claims.First(x => x.Type == "email" || x.Type == "username").Value;

            return email;
        }

        public string GetToken(HttpRequest request)
        {
            StringValues values = "";
            request.Headers.TryGetValue("Authorization", out values);
            string token = values.ToString().Split(" ")[1];

            return token;
        }
    }
}
