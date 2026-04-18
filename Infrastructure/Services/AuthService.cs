using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TaskFlow.Application.Common;
using TaskFlow.Application.DTOs.Auth;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public AuthService(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<ServiceResult> Register(RegisterDto dto) 
        {

            var existingUser = await _userManager.FindByEmailAsync(dto.Email);
            if (existingUser != null)
                return ServiceResult.FailureResult("User Already Exist !!");

            if (dto.Password != dto.PasswordConfirmed)
                return ServiceResult.FailureResult("Passwords do not match");

            var user = new AppUser
            {
                UserName = dto.Email, 
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                Email = dto.Email,
            };

            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
                return ServiceResult.FailureResult("Register Failed... Try Again");

            return ServiceResult.SuccessResult();
        }
        public async Task<ServiceResult> Login(LoginDto dto) {
            var user =  await _userManager.FindByEmailAsync(dto.Email);
            if (user is null)
                return ServiceResult.FailureResult("User Not Exist..!!");

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, dto.Password);
            if (!isPasswordValid)
                return ServiceResult.FailureResult("Wrong email or password");

            var token = _tokenService.GenerateAccessToken(user);

            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userManager.UpdateAsync(user);


            var authResult = new AuthResultDto
            {
                UserId = user.Id,
                UserName = user.UserName ?? string.Empty,
                Email = user.Email ?? string.Empty,
                Token = token,
                RefreshToken = refreshToken,
                ExpiresAt = DateTime.UtcNow.AddMinutes(60)
            };
            return ServiceResult.SuccessResult(authResult);
        }
        public async Task<ServiceResult> RefreshToken(string refreshToken) {

            var user = await _userManager.Users
            .FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);

            if (user is null)
                return ServiceResult.FailureResult("Invalid refresh token");

            if (!_tokenService.ValidateRefreshToken(user, refreshToken))
                return ServiceResult.FailureResult("Refresh token expired");

            var token = _tokenService.GenerateAccessToken(user);

            var newRefreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(7);
            await _userManager.UpdateAsync(user);

            var authResult = new AuthResultDto
            {
                UserId = user.Id,
                UserName = user.UserName ?? string.Empty,
                Email = user.Email ?? string.Empty,
                Token = token,
                RefreshToken = newRefreshToken,
                ExpiresAt = DateTime.UtcNow.AddMinutes(60)
            };
            return ServiceResult.SuccessResult(authResult);
        }
    }
}
