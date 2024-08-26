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
      //GenerateToken(user);
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
            new("fullname", user.FullName),
            new("username", user.UserName),
            new("id", user.Id.ToString()),
            new("aud",  _configuration["Token:Audience"])
        };

        // var roleClaims = user.Permissions
        //     .Select(p => new Claim("role", p.ToString()));
        // claims.AddRange(roleClaims);
        return claims;
    }

}