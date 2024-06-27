using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace NewsArticleApplication.JWT
{
    public class JwtConfg
    {
        public string Key { get; init; } = string.Empty;
        public string Issuer { get; init; } = string.Empty;

        public string Audience { get; init; } = string.Empty;

        private const string SecurityAlgorithm = SecurityAlgorithms.HmacSha256;

        public SymmetricSecurityKey SecurityKey
        {
            get
            {
                return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
            }
        }

        public SigningCredentials Credentials
        {
            get
            {
                return new SigningCredentials(SecurityKey, SecurityAlgorithm);
            }
        }

        public JwtSecurityToken GenerateAccessTokenObject(List<Claim> claims, DateTime expirationTime)
        {
            var token = new JwtSecurityToken(
                issuer: Issuer,
                audience: Audience,
                claims: claims,
                expires: expirationTime,
                signingCredentials: Credentials
            );
            return token;
        }
    }
}
