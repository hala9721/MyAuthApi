using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using MyAuth.Core.Abstractions;
using MyAuth.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace MyAuth.Infrastructure.Security
{
    internal sealed class TokenService(IOptions<TokenOptions> options) :ITokenService
    {

        public string GenerateToken(UserDto user)
        {
            var opts = options.Value;
            var key= new SymmetricSecurityKey(Encoding.ASCII.GetBytes(opts.Key));
            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new System.Security.Claims.Claim("id", user.Id.ToString()),
                    new System.Security.Claims.Claim(ClaimTypes.Name, user.Username),
                    new System.Security.Claims.Claim(ClaimTypes.Role, user.Role)
                }),
                Expires = DateTime.UtcNow.AddMinutes(opts.ExpirationInMinutes),
                Issuer = opts.Issuer,
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256),
                Audience = opts.Audience,
            };
            return new JsonWebTokenHandler().CreateToken(descriptor);

        }

    }
}
