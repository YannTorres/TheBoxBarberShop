﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TheBoxBarberShop.Domain.Entities;
using TheBoxBarberShop.Domain.Security.Tokens;

namespace TheBoxBarberShop.Infrastructure.Security.Tokens;

public class JwtTokenGenerator : IAcessTokenGenerator
{
    private readonly uint _ExpirationTimeMinutes;
    private readonly string _signingKey;
    public JwtTokenGenerator(string signingKey, uint expirationTimeMinutes)
    {
        _signingKey = signingKey;
        _ExpirationTimeMinutes = expirationTimeMinutes;
    }
    public string Generate(User user)
    {
        var claims = new List<Claim>()
        {
            new(ClaimTypes.Name, user.Name),
            new(ClaimTypes.Sid, user.Id.ToString()),
            new(ClaimTypes.Role, user.Role),
        };


        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Expires = DateTime.UtcNow.AddMinutes(_ExpirationTimeMinutes),
            SigningCredentials = new SigningCredentials(SecurityKey(), SecurityAlgorithms.HmacSha256Signature),
            Subject = new ClaimsIdentity(claims)
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var securityToken = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(securityToken);
    }

    private SymmetricSecurityKey SecurityKey()
    {
        var key = Encoding.UTF8.GetBytes(_signingKey);

        return new SymmetricSecurityKey(key);
    }
}
