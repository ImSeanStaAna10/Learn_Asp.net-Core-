using LoginAuthAPI.Contracts;
using LoginAuthAPI.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LoginAuthAPI.Services
{
    public class TokenService: ITokenService
    {
        private const string JWT_SECRET_KEY = "JwtSettings:SecretKey";
        private readonly IConfiguration _configuration;

        //constructor Dependecy Injection
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(User user)
        {
            string? secretKey = _configuration[JWT_SECRET_KEY]!;
            if (string.IsNullOrWhiteSpace(secretKey))
            {
                throw new Exception("JWT secretKey is missing");
            }

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(secretKey)
                );

            var credentials = new SigningCredentials
            (
                key,
                SecurityAlgorithms.HmacSha256
            );

            //claims
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name,  user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            //token
            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                    Convert.ToDouble(_configuration["JwtSettings:ExpiryInMinutes"])
                    ),
                    signingCredentials: credentials
                );


            var tokenHandler = new JwtSecurityTokenHandler();

            //return tokne
            return tokenHandler.WriteToken(token);
        }
    }
}
