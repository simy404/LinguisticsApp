﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LinguisticsAPI.Application.Abstraction.Auth;
using LinguisticsAPI.Application.RequestParameters.Common;
using LinguisticsAPI.Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LinguisticsAPI.Infrastructure.Services.Auth;

public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;
    
    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public TokenResponse GenerateToken(AppUser user)
        => GenerateToken(user, DateTime.Now.AddHours(1));


    public TokenResponse GenerateToken(AppUser user, DateTime expirationTime)
    {
        var claims = PrepareClaims(user);
        var credentials = PrepareCredentials(_configuration["Token:SecurityKey"]);
       
        var token = new JwtSecurityToken(
            issuer: _configuration["Token:Issuer"],
            audience: _configuration["Token:Audience"],
            claims: claims,
            expires: expirationTime,
            signingCredentials: credentials
        );
        
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenString = tokenHandler.WriteToken(token);
        
        return new TokenResponse() { Token= tokenString, Expires = expirationTime };
    }
    
    private SigningCredentials PrepareCredentials(string key)
    {
        var keyBytes = Encoding.UTF8.GetBytes(key);
        var symmetricKey = new SymmetricSecurityKey(keyBytes);
        return new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256);
    }
    
    private IEnumerable<Claim> PrepareClaims(AppUser user)
    {
        if (user.Id == null)
            throw new Exception("unknown user id.");
       
        var claims = new List<Claim>
        {
            new("fullname", user.FullName ?? string.Empty),
            new("username", user.UserName),
            new("id", user.Id.ToString()),
            new("aud",  _configuration["Token:Audience"]),
            new("iss",  _configuration["Token:Issuer"])
        };
        
        return claims;
    }

}