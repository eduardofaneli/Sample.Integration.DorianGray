using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Sample.Integration.Api.Models;
using Sample.Integration.Api.Options;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sample.Integration.Api.Services
{
    public static class TokenService
    {        
        public static string GenerateToken(IConfiguration configuration, User user)
        {
            var authorization = configuration.GetSection(AuthenticationOptions.Key).Get<AuthenticationOptions>();

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(authorization.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Username.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())                    
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
