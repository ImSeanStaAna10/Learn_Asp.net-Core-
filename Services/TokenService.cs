using HowToCreateWebAPI.Contracts;
using HowToCreateWebAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HowToCreateWebAPI.Services
{
    public class TokenService: ItokenService
    {
        private readonly TokenValidationParameters _validationParameters;
        private readonly string _secret;

        //CONSTRUCTOR || DEPENDECY INJECTION
        public TokenService(TokenValidationParameters validationParameters, string secret)
        {
            _validationParameters = validationParameters;
            _secret = secret;
        }

        public string GenerateToken(User user)
        {
            var userClaims = new Claim[] {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Email)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                    claims: userClaims,
                    signingCredentials: credentials,
                    expires: DateTime.Now.AddMinutes(3)
                );

            return new JwtSecurityTokenHandler()
                .WriteToken(token);
        }

        public bool isValid(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                tokenHandler.ValidateToken(token, _validationParameters, out SecurityToken securityToken);
            }
            catch
            {
                return false;
            }

            return true;
        }

    }
}
