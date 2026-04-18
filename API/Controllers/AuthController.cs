using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.API.Common;
using TaskFlow.Application.DTOs.Auth;
using TaskFlow.Application.Interfaces;

namespace TaskFlow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<ApiResponse<AuthResultDto>>> Register(RegisterDto request)
        {
            var result = await _authService.Register(request);
            if (!result.IsSuccess)
                return BadRequest(ApiResponse<AuthResultDto>.FailureResponse(result.Message!));

            return Ok(ApiResponse.SuccessResponse("Registration successful"));
        }

        [HttpPost("login")]
        public async Task<ActionResult<ApiResponse<AuthResultDto>>> Login(LoginDto request)
        {
            var result = await _authService.Login(request);

            if (!result.IsSuccess)
                return BadRequest(ApiResponse<AuthResultDto>.FailureResponse(result.Message!));

            return Ok(ApiResponse<AuthResultDto>.SuccessResponse(
                result.Data as AuthResultDto));
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<ApiResponse<AuthResultDto>>> RefreshToken([FromBody] string refreshToken)
        {
            var result = await _authService.RefreshToken(refreshToken);
            if (!result.IsSuccess)
                return BadRequest(ApiResponse<AuthResultDto>.FailureResponse(result.Message!));
            return Ok(ApiResponse<AuthResultDto>.SuccessResponse(
                result.Data as AuthResultDto));


        }
    }
}
