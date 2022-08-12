using ChessTournament.DL.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ChessTournament.IL.Tools
{
    public class TokenManager
    {
        private readonly string _issuer, _audience, _secret;
        public TokenManager(IConfiguration config)
        {
            _issuer = config.GetSection("jwt").GetSection("issuer").Value;
            _audience = config.GetSection("jwt").GetSection("audience").Value;
            _secret = config.GetSection("jwt").GetSection("secret").Value;
        }

        public string GenerateToken(string pseudo, string id, string role)
        {
            if (pseudo is null || id is null || role is null) throw new ArgumentNullException();

            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secret));
            SigningCredentials credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);


            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Surname, pseudo),
                new Claim(ClaimTypes.Sid, id),
                new Claim(ClaimTypes.Role, role)
            };

            JwtSecurityToken token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: credentials,
                issuer: _issuer,
                audience: _audience,
                expires: DateTime.Now.AddDays(1)
                );

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();

            return handler.WriteToken(token);
        }
    }
}
