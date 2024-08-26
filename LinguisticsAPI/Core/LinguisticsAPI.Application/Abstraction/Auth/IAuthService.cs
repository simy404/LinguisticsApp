using LinguisticsAPI.Application.RequestParameters.Common;
using LinguisticsAPI.Domain.Entities.Identity;

namespace LinguisticsAPI.Application.Abstraction.Auth;

public interface IAuthService
{
    TokenResponse GenerateToken(AppUser user);
    
    TokenResponse GenerateToken(AppUser user, DateTime expirationTime);
}