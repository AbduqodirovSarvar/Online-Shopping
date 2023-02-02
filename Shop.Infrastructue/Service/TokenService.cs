using Microsoft.Extensions.Configuration;
using Shop.Domain.Entities;
using Shop.Infrastructue.Abstracts;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Shop.Infrastructue.Service
{
    public class TokenService : ITokenService
    {
        public string GetToken(User user)
        {
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Name, user.FullName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("Role", user.Role.ToString()),
            };

            var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("secret")),
                SecurityAlgorithms.HmacSha512 );
            var token = new JwtSecurityToken(
                "ok",
                "ok",
                claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials
                );
            var tokenhandler = new JwtSecurityTokenHandler();
            return tokenhandler.WriteToken(token);
        }
    }
}
