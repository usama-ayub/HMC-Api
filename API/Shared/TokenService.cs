using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using API.Model;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System;

namespace API.Shared
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _key;
        public TokenService(IConfiguration configuration)
        {
            var token = configuration["TokenKey"];
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(token));
        }
        public string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                 new Claim(JwtRegisteredClaimNames.Email,user.Email),
                 new Claim(JwtRegisteredClaimNames.Name,user.UserName),
                 new Claim("id",user.Id),
                 new Claim("active",user.IsActive.ToString()),
            };
            var creds = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = creds
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}