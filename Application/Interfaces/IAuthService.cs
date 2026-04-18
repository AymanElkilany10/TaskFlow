using TaskFlow.Application.Common;
using TaskFlow.Application.DTOs.Auth;

namespace TaskFlow.Application.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResult> Register(RegisterDto registerDto);
        Task<ServiceResult> Login(LoginDto loginDto);
        Task<ServiceResult> RefreshToken(string refreshToken);
    }
}
