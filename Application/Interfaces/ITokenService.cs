using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Interfaces
{
    public interface ITokenService
    {
        string GenerateAccessToken(AppUser appUser);
        string GenerateRefreshToken();
        bool ValidateRefreshToken(AppUser appUser, string token);
    }
}
